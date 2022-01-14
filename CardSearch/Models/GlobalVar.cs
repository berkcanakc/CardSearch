using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Web;

namespace CardSearch.Models
{
    public class GlobalVar
    {
        static public List<CardModel> scard = new List<CardModel>();
        static public List<CardModel> cardres = new List<CardModel>();
        static public List<CardModel> detay = new List<CardModel>();
        static bool apicontrol = true;
        static public int id = 0;

        public static void Veriler()
        {
            using (var client = new HttpClient())
            {
                if (apicontrol == true)
                {
                    IEnumerable<CardModel> card = null;
                    client.BaseAddress = new Uri("https://yugiohapi.azurewebsites.net/api/");
                    var responseTask = client.GetAsync("commands");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readJob = result.Content.ReadAsAsync<IList<CardModel>>();
                        readJob.Wait();
                        card = readJob.Result;
                        foreach (var items in card)
                        {
                            int id = items.id;
                            string yol = id.ToString();
                            string anayol = "https://storage.googleapis.com/ygoprodeck.com/pics/";
                            string path = anayol + yol + ".jpg";
                            items.img = path;
                            scard.Add(items);
                            cardres.Add(items);
                        }
                    }
                    else
                    {
                        card = Enumerable.Empty<CardModel>();
                    }
                }
                apicontrol = false;
            }
        }
        public static void search(string searcher)
        {
            cardres.Clear();
            if (!String.IsNullOrEmpty(searcher))
            {
                foreach (var item in scard)
                {

                    if (item.name.ToLower().Contains(searcher.ToLower()) || item.desc.ToLower().Contains(searcher.ToLower()) || item.atk.ToString() == searcher || item.def.ToString() == searcher || item.linkval.ToString() == searcher || item.scale.ToString() == searcher || item.type.ToLower().Contains(searcher.ToLower()) || item.race.ToLower().Contains(searcher.ToLower()) || item.level.ToString() == searcher)
                    {
                        cardres.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in scard)
                {
                    cardres.Add(item);
                }
            }
        }
        public static void Detail(int ?id)
        {
            detay.Clear();
            foreach (var item in cardres)
            {
                if (item.id == id)
                {
                    detay.Add(item);
                }
            }

        }

    }
}