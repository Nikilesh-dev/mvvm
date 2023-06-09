
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;

namespace MVVM.ViewModel
{
    public class LogicViewModel : HelperMvvm
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnChanged();
            }
        }

        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnChanged();
            }
        }

        private string _mail;
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnChanged();
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnChanged();
            }
        }

        public ICommand GetButton { get; }

        public ICommand UpdateButton { get; }

        public ICommand RegisterButton { get; }

        public LogicViewModel()
        {
           GetButton = new Relaycommand(Get);
           RegisterButton = new Relaycommand(Register);
           UpdateButton = new Relaycommand(Update);
        }

        AccessViewModel access = new AccessViewModel();
        public void Update()
        {
            String Query = $"UPDATE Details Set Name = '{_Name}',Email = '{_mail}',PhoneNumber = {_phone} WHERE UserId = '{_userId}'";
            ConnectionViewModel con = new ConnectionViewModel();
            con.ProQuery = Query;
            int q = con.Query();
        }

        public void Register()
        {
            String Query = $"INSERT INTO Details VALUES ('{_Name}','{_userId}','{_mail}',{_phone})";
            ConnectionViewModel con = new ConnectionViewModel();
            con.ProQuery = Query;
            int q = con.Query();
         
        }

        public void Get()
        {
            String Query = $"Select * from Details Where UserId = '{_userId}'";
            ConnectionViewModel con = new ConnectionViewModel();
            con.ProQuery = Query;
            DataSet dataSet = new DataSet();
            con.dataset().Fill(dataSet);

            for (int i = 0; i <= dataSet.Tables[0].Rows.Count - 1; i++)
            {
                DataRow dataRow = (DataRow)dataSet.Tables[0].Rows[i];
                Name = dataRow["Name"].ToString();
                Mail = dataRow["Email"].ToString();
                Phone = dataRow["PhoneNumber"].ToString();
                UserId = dataRow["UserId"].ToString();
            }

        }

    }
}
