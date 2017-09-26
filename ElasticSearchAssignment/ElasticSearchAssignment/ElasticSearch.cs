using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ElasticSearchAssignment
{
    public class ElasticSearch
    {
        ElasticClient client = null;
        public ElasticSearch()
        {
            var uri = new Uri("http://172.16.14.236:9200/");
            var settings = new ConnectionSettings(uri);
            client = new ElasticClient(settings);
            settings.DefaultIndex("log");
            client.Index("log");
        }
        public List<Log> GetResult(string index, string type)
        {
            if (client.IndexExists("log").Exists)
            {
                var response = client.Search<Log>();
                return response.Documents.ToList();
            }
            return null;
        }

        public List<Log> GetResult(string condition)
        {
            var response = client.Search<Log>(s => s
                         .Index("log")
                         .Type("data")
                         .Query(q => q.Match(x => x.Field("Name").Query(condition))));
            List<Log> list = new List<Log>();
            foreach (var hit in response.Hits)
            {
                list.Add(hit.Source);
            }
            return list;
        }

        public void AddNewIndex(Log log)
        {
            client.Index<Log>(log, null);
        }
    }
}

