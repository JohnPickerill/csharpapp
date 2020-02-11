using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Flurl;

namespace restClient
{
 


    class DocsAPI {
        private string apiUrl;
        private string region;
        private string docType;
        private string baseUrl;
        
        public DocsAPI(string apiUrl, string region, string docType) {
            this.apiUrl = apiUrl;
            this.region = region;
            this.docType = docType;
            this.baseUrl = Url.Combine(apiUrl, region);
        }


        public class titleList {
            public List<string> titles { get; set; }
        }

        private T  deserialize<T>(string strJSON) {
            T _obj = JsonConvert.DeserializeObject<T>(strJSON);
            return _obj;
        }
         

        private T request<T>(string method, string url) {
            string data = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = method;

            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse()) {
                if (response.StatusCode != HttpStatusCode.OK){
                    throw new ApplicationException("error " + response.StatusCode);
                }
                using (Stream responseStream = response.GetResponseStream()){
                    if (responseStream != null) {
                        using (StreamReader reader = new StreamReader(responseStream)){
                            data = reader.ReadToEnd();
                        } 
                    }
                }                    
            }
            return deserialize<T>(data);
        }


        private string makeUrl(string api, params string[] nodes) {
            string reqUrl = Url.Combine(this.baseUrl, api, this.docType);
            foreach (string node in nodes)
                reqUrl = Url.Combine(reqUrl, node);
            return reqUrl;

        }

        public string[] get_titles() {
            string url = makeUrl("docs","titles");

            string[] titles = request<string[]>("GET", url);
            return titles;
        }

        public T get_versions<T>(string title, string document) {
            string url = makeUrl("docs", "titles", title, "documents", "latest", "versions" );

            T versions = request<T>("GET", url);
            return versions;
        }

        public T get_objects<T>(string title, string document, string version) {
            string url = makeUrl("docs", "titles", title, "documents", document, "versions", version, "objects");

            T __object = request<T>("GET", url);
            return __object;
        }

        public T get_object<T>(string title, string document, string version, string _object) {
            string url = makeUrl("docs", "titles", title, "documents", document, "versions", version, "objects", _object);

            T __object = request<T>("GET", url);
            return __object;
        }


    }
}
