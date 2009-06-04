/*
    This file is part of Twitiriqui.

    Twitiriqui is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Twitiriqui is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Twitiriqui.  If not, see <http://www.gnu.org/licenses/>.
  
    Copyright 2009 Alberto Avila

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Web;

namespace Twitiriqui.Backend
{
    public class Api
    {

        NetworkCredential _credential;

        NetworkCredential Credential
        {
            get
            {
                if (_credential == null)
                    _credential = new NetworkCredential(Username, Password);
                return _credential;
            }
        }

        public string Username { get; set; }

        public string Password { get; set; }


        IEnumerable<Status> GetFriendsTimeLine(string parameters)
        {
            var document = GetDocumentFromRequest("http://twitter.com/statuses/friends_timeline.xml?" + parameters);

            var results = from status in document.Descendants("status")
                          select GetStatusFromXml(status);
            return results;
        }

        public IEnumerable<Status> GetFriendsTimeLine(Status status, bool getNewerStatus)
        {
            if (getNewerStatus)
                return GetFriendsTimeLine(status);
            return GetFriendsTimeLine("count=21&max_id=" + status.ID);
        }

        public IEnumerable<Status> GetFriendsTimeLine(Status lastStatus)
        {
            return GetFriendsTimeLine("since_id=" + lastStatus.ID);
        }

        public IEnumerable<Status> GetFriendsTimeLine(int count)
        {
            return GetFriendsTimeLine("count=" + count);
        }

        public IEnumerable<User> GetFollowers()
        {
            return GetUserList(GetDocumentFromRequest("http://twitter.com/statuses/followers.xml"));
        }

        public IEnumerable<User> GetFriends()
        {
            return GetUserList(GetDocumentFromRequest("http://twitter.com/statuses/friends.xml"));
        }

        IEnumerable<User> GetUserList(XDocument document)
        {
            var results = from user in document.Descendants ("user")
                          select GetUserFromXml(user);

            return results;

        }

        User GetUserFromXml(XElement user)
        {
            if (user == null)
                return null;
            return new User
            {
                ID = long.Parse(user.Element("id").Value),
                Name = user.Element("name").Value,
                ScreenName = user.Element("screen_name").Value,
                Location = user.Element("location").Value,
                ImageUrl = user.Element("profile_image_url").Value,
                Followers = int.Parse(user.Element("followers_count").Value),
                Url = user.Element("url").Value,
                LastStatus = GetStatusFromXml(user.Element("status"))
            };
        }

        Status GetStatusFromXml(XElement status)
        {
            if (status == null)
                return null;
            return new Status
            {
                ID = int.Parse(status.Element("id").Value),
                Source = status.Element("source").Value,
                Text = status.Element("text").Value,
                CreationDateFromUTCString = status.Element("created_at").Value,
                User = GetUserFromXml(status.Element("user"))
            };
        }

        public IEnumerable<Status> GetFriendsTimeLine()
        {
            return GetFriendsTimeLine(20);
        }



        public Status PostStatus(string status)
        {
            var url = "http://twitter.com/statuses/update.xml";
            var data = "status=" + HttpUtility.UrlEncode(status);

            return GetStatusFromXml(GetDocumentFromRequestWithPostData(url, data).Descendants("status").First());

        }

        HttpWebRequest GetRequest(string url)
        {
            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.ServicePoint.Expect100Continue = false;
            request.Credentials = Credential;

            return request;
        }

        XDocument GetDocumentFromRequest(HttpWebRequest request)
        {
            try
            {
                var stream = new StreamReader(request.GetResponse().GetResponseStream());
                var document = XDocument.Load(stream);
                stream.Close();
                return document;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ReceiveFailure)
                    throw new TwitterNotAvaibleException();
                var response = e.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new BadCredentialsException();
                if (response.StatusCode == HttpStatusCode.BadGateway ||
                    response.StatusCode == HttpStatusCode.ServiceUnavailable)
                    throw new TwitterNotAvaibleException();
                throw e;
            }
        }

        XDocument GetDocumentFromRequest(string url)
        {
            return GetDocumentFromRequest(GetRequest(url));
        }

        XDocument GetDocumentFromRequestWithPostData(string url, string postData)
        {
            var request = GetRequest(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            return GetDocumentFromRequest(request);

        }
    }
}
