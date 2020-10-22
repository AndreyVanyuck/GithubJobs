using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App2.Models
{
    public class JobOffer : INotifyPropertyChanged
    {
        //  public string Id { get; set; }
        public string id;
        public string Id
        {
            get { return Id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        //public string Type { get; set; }
        public string type;
        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        // public string Url { get; set; }
        public string url;
        public string Url
        {
            get { return url; }
            set
            {
                if (url != value)
                {
                    url = value;
                    OnPropertyChanged("Url");
                }
            }
        }
        // public string Created_at { get; set; }
        public string created_at;
        public string Created_at
        {
            get { return created_at; }
            set
            {
                if (created_at != value)
                {
                    created_at = value;
                    OnPropertyChanged("Created_at");
                }
            }
        }
        //public string Company { get; set; }
        public string company;
        public string Company
        {
            get { return company; }
            set
            {
                if (company != value)
                {
                    company = value;
                    OnPropertyChanged("Company");
                }
            }
        }
        //public string Company_url { get; set; }
        public string company_url;
        public string Company_url
        {
            get { return company_url; }
            set
            {
                if (company_url != value)
                {
                    company_url = value;
                    OnPropertyChanged("Company_url");
                }
            }
        }
       // public string Location { get; set; }
        public string location;
        public string Location
        {
            get { return location; }
            set
            {
                if (location != value)
                {
                    location = value;
                    OnPropertyChanged("Location");
                }
            }
        }
        //public string Title { get; set; }
        public string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
       // public string Description { get; set; }
        public string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
       // public string How_to_apply { get; set; }
        public string how_to_apply;
        public string How_to_apply
        {
            get { return how_to_apply; }
            set
            {
                if (how_to_apply != value)
                {
                    how_to_apply = value;
                    OnPropertyChanged("How_to_apply");
                }
            }
        }
       public string Company_logo { get; set; }
       // public string company_logo;
       /* public string Company_logo
        {
            get { return company_logo; }
            set
            {
                if (company_logo != value)
                {
                    company_logo = value;
                    OnPropertyChanged("Company_logo");
                }
            }
        }*/
        public TimeSpan TimeSpan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
