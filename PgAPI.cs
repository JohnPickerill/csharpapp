using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Flurl;

namespace restClient {
    class PgAPI {

        private T deserialize<T>(string strJSON) {
            T _obj = JsonConvert.DeserializeObject<T>(strJSON);
            return _obj;
            }

        private T request<T>(string method, string url) {
            string data = string.Empty;
            CookieContainer cookieContainer = new CookieContainer();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = method;
            req.CookieContainer = cookieContainer;
            req.MaximumAutomaticRedirections = 5;
            req.AllowAutoRedirect = true;
            req.UseDefaultCredentials = true;
            req.PreAuthenticate = false;
            //req.Credentials = CredentialCache.DefaultCredentials;
            req.Credentials = CredentialCache.DefaultNetworkCredentials;
            //req.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            // Allow certificate errors
            //NetworkCredential nc = System.Net.CredentialCache.DefaultNetworkCredentials;
            //nc = CredentialCache.DefaultCredentials;
            // = new NetworkCredential("cs062jp", "", "DITI");
            //req.Credentials = nc;
            CredentialCache credCache = new CredentialCache();
            credCache.Add(new Uri("http://guide-dev.lr.net"), "Negotiate",
                          CredentialCache.DefaultNetworkCredentials);
            req.Credentials = credCache;

            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse()) {
                if (response.StatusCode != HttpStatusCode.OK) {
                    throw new ApplicationException("error " + response.StatusCode);
                    }
                using (Stream responseStream = response.GetResponseStream()) {
                    if (responseStream != null) {
                        using (StreamReader reader = new StreamReader(responseStream)) {
                            data = reader.ReadToEnd();
                            }
                        }
                    }
                }
            return deserialize<T>(data);
            }



        public string get_main() {
            string url = "https://guide-dev.lr.net/ui/wip";
            url = "https://federate.landregistry.gov.uk/adfs/oauth2/authorize?response_type=code&client_id=5c0d7771-c3d2-4e9c-88de-ea887da0557e&redirect_uri=https://guide-dev.lr.net/login&resource=https://guide-dev.lr.net/login&state=ui";

            string mainpage = request<string>("GET", url);
            return mainpage;
            }






        }
    }
