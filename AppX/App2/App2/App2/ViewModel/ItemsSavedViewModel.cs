using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModel
{
    public class ItemsSavedViewModel
    {
        public ObservableCollection<JobOffer> SavedJobs { get; set; }

        public ItemsSavedViewModel()
        {

        }

        public async Task<List<JobOffer>> LoadData(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync();
            List<JobOffer> jobOffer = new List<JobOffer>();
            jobOffer.Add(JsonConvert.DeserializeObject<JobOffer>(content));
            return await Task.FromResult(jobOffer);
        }

    }
    }
