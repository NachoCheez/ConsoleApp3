using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace ConsoleApp3
{

    public class Rootobject
    {
        public int count { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class Entry
    {
        public string? API { get; set; }
        public string? Description { get; set; }
        public string? Auth { get; set; }
        public bool HTTPS { get; set; }
        public string? Cors { get; set; }
        public string? Link { get; set; }
        public string? Category { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            InternaliseAPI intern = new InternaliseAPI();
            intern.GetDetails();
        }
    }
    class InternaliseAPI
    {
        public void GetDetails()
        {
            string json = new WebClient().DownloadString("https://api.publicapis.org/entries");
            Rootobject entrs = JsonConvert.DeserializeObject<Rootobject>(json);
            foreach (var entry in entrs.entries)
            {
                Console.WriteLine(entry);
            }
            int count = 0;
            List<List<Entry>> splitList = new List<List<Entry>>();
            List < Entry > etry = new List<Entry>();
            foreach (var i in entrs.entries)
            {
                etry.Add(i);
                count++;
                if (count == 50)
                {
                    splitList.Add(etry);
                    count = 0;
                    etry= new List<Entry>();
                }
            }
            splitList.Add(etry);
        }
    }

    //class Entry
    //{
    //    public string? API { get; set; }
    //    public string? Description { get; set; }
    //    public string? Auth { get; set; }
    //    public bool HTTPS { get; set; }
    //    public string? Cors { get; set; }
    //    public string? Link { get; set; }
    //    public string? Animals { get; set; }
    //}
}
