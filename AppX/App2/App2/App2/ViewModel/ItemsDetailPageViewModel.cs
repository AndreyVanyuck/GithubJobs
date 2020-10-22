using App2.Models;
using App2.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class ItemsDetailPageViewModel : IEnumerable<JobOffer>
    {
        public List<JobOffer> Jobs { get; set; }
        public JobOffer Item { get; set; }
        public ItemsDetailPageViewModel()
        {
            Jobs = LoadData("https://jobs.github.com/positions.json?page=6").Result;
        }
        public ItemsDetailPageViewModel(JobOffer job)
        {
            Item = job;
        }
        public ItemsDetailPageViewModel(string url)
        {
            Jobs = LoadData(url).Result;
        }

        public async Task<List<JobOffer>> LoadData(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync();
            List<JobOffer> jobOffer = new List<JobOffer>();

            try
            { 
            if (content[0] == '[')
            {
                content = content.Substring(1, content.Length - 2);
            }
            while (content != null)
            {
                var indexOfEndOneModel = content.IndexOf('}');
                string newContent = "";
                if (indexOfEndOneModel != content.Length - 1)
                {
                    newContent = content.Substring(indexOfEndOneModel + 2);
                }
                else
                {
                    jobOffer.Add(JsonConvert.DeserializeObject<JobOffer>(content));
                    jobOffer[jobOffer.Count - 1].Created_at = GetCreated_at(jobOffer[jobOffer.Count - 1]);

                    return await Task.FromResult(jobOffer);
                }
                content = content.Remove(indexOfEndOneModel + 1);
                jobOffer.Add(JsonConvert.DeserializeObject<JobOffer>(content));
                jobOffer[jobOffer.Count - 1].Created_at = GetCreated_at(jobOffer[jobOffer.Count - 1]);
               
                content = newContent;
            }
                return await Task.FromResult(jobOffer);
            }
            catch { }

            return await Task.FromResult(jobOffer);
        }

        private async Task<JobOffer> GetData(string url)
        { 
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync();
            JobOffer jobOffer = JsonConvert.DeserializeObject<JobOffer>(content);
            return await Task.FromResult(jobOffer);
        }

        private string GetCreated_at(JobOffer jobOffer)
        {
            jobOffer.TimeSpan = GetTimeSpan(jobOffer.Created_at);
            if (jobOffer.TimeSpan.Days > 30)
            {
                jobOffer.Created_at = Convert.ToString(jobOffer.TimeSpan.Days / 30 + " months ago");
            }
            else
            {
                if (jobOffer.TimeSpan.Days > 0)
                {
                    jobOffer.Created_at = Convert.ToString(jobOffer.TimeSpan.Days + " days ago");
                }
                else
                {
                    if (jobOffer.TimeSpan.Minutes < 60)
                    {
                        jobOffer.Created_at = Convert.ToString(jobOffer.TimeSpan.Minutes + " minutes ago");
                    }
                    else
                    {
                        jobOffer.Created_at = Convert.ToString("about " + jobOffer.TimeSpan.Hours + " hours ago");
                    }
                }
            }
            return jobOffer.Created_at;
        }
        private TimeSpan GetTimeSpan(string created_at)
        {
            DateTime dateNow = DateTime.UtcNow;

            int numberOfMonth = -1;
            string nameOfMonth = created_at.Substring(4, 3);
            switch (nameOfMonth)
            {
                case "Jan":
                    numberOfMonth = 1;
                    break;
                case "Feb":
                    numberOfMonth = 2;
                    break;
                case "Mar":
                    numberOfMonth = 3;
                    break;
                case "Apr":
                    numberOfMonth = 4;
                    break;
                case "May":
                    numberOfMonth = 5;
                    break;
                case "Jun":
                    numberOfMonth = 6;
                    break;
                case "Jul":
                    numberOfMonth = 7;
                    break;
                case "Aug":
                    numberOfMonth = 8;
                    break;
                case "Sep":
                    numberOfMonth = 9;
                    break;
                case "Oct":
                    numberOfMonth = 10;
                    break;
                case "Nov":
                    numberOfMonth = 11;
                    break;
                case "Dec":
                    numberOfMonth = 12;
                    break;
            }
            DateTime dateTimeOfCreateAt = new DateTime(Convert.ToInt32(created_at.Substring(24, 4)), numberOfMonth, Convert.ToInt32(created_at.Substring(8, 2)), Convert.ToInt32(created_at.Substring(11, 2)), Convert.ToInt32(created_at.Substring(14, 2)), Convert.ToInt32(created_at.Substring(17, 2)));
            TimeSpan timeSpan = dateNow - dateTimeOfCreateAt;
            return timeSpan;
        }
        public IEnumerator<JobOffer> GetEnumerator()
        {
            return ((IEnumerable<JobOffer>)Jobs).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<JobOffer>)Jobs).GetEnumerator();
        }
    }
}
