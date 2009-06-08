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

namespace Twitiriqui.Backend
{
    public class Status
    {

        static Dictionary<string, int> MonthMap = new Dictionary<string, int>
        {
            {"Jan", 1},
            {"Feb", 2},
            {"Mar", 3},
            {"Apr", 4},
            {"May", 5},
            {"Jun", 6},
            {"Jul", 7},
            {"Aug", 8},
            {"Sep", 9},
            {"Oct", 10},
            {"Nov", 11},
            {"Dec", 12}
        };

        public DateTime CreationDate;

        public string CreationDateFromUTCString
        {
            set
            {
                //parse date format: Fri Mar 13 16:23:34 +0000 2009
                var dateSections = value.Split(' ');

                var year = int.Parse(dateSections[5]);
                var month = MonthMap[dateSections[1]];
                var day = int.Parse(dateSections[2]);
                var timeSection = dateSections[3].Split(':');
                var hour = int.Parse(timeSection[0]);
                var minutes = int.Parse(timeSection[1]);
                var seconds = int.Parse(timeSection[2]);

                CreationDate = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Utc);
            }
        }

        public long ID;
        public string Text;
        public string Source;
        public User User;
        public long InReplyToStatudID;
        public string InReplyToScreenName;
    }
}
