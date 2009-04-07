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
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
  
    Copyright 2009 Alberto Avila

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twitiriqui.Backend;

namespace Twitiriqui.WinFormsGUI
{
    public partial class LogonWindow : Form
    {
        public LogonWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                var api = new Api { Username = username.Text, Password = password.Text };
                new MainViewWindow(api, api.GetFriends()).Show();
                Hide();
            }
            catch (BadCredentialsException)
            {
                MessageBox.Show("Bad user");
            }
            catch (TwitterNotAvaibleException)
            {
                MessageBox.Show("Server down");
            }
        }
    }
}
