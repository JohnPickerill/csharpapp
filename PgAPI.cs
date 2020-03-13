using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Flurl;
using System.Web;
using System.Windows.Forms;

namespace restClient {
    class PgAPI {

        CookieContainer cookieContainer = new CookieContainer();
        string url = "https://guide.lr.net/ui/wip";
        //url = "https://federate.landregistry.gov.uk/adfs/oauth2/authorize?response_type=code&client_id=5c0d7771-c3d2-4e9c-88de-ea887da0557e&redirect_uri=https://guide-dev.lr.net/login&resource=https://guide-dev.lr.net/login&state=ui";
        //url = "https://federate.landregistry.gov.uk/adfs/oauth2/authorize?response_type=code&client_id=c8e88a9d-854e-4570-a8b5-5a702ec3e578&redirect_uri=https://guide.lr.net/login&resource=https://guide.lr.net/login&state=ui";


            
        public PgAPI() {

            WebBrowser wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;
            wb.Navigated += new WebBrowserNavigatedEventHandler(getCookie);
            wb.Navigate(url, false);

            }


        private T deserialize<T>(string strJSON) {
            T _obj = JsonConvert.DeserializeObject<T>(strJSON);
            return _obj;
            }


        private HttpWebRequest GetNewRequest(string targetUrl) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            request.Method = "GET";
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = false;
            //req.UseDefaultCredentials = false;
            //request.Credentials = CredentialCache.DefaultCredentials;
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            request.Headers.Add("cache-control", "no-cache");
            return request;
            }

        CookieContainer cookies = new CookieContainer();
        private void getCookie(object sender,
            WebBrowserNavigatedEventArgs e) {
            string baseURL = ((WebBrowser)sender).Url.GetLeftPart(System.UriPartial.Authority);
            //Uri url = ((WebBrowser)sender).Url;
            Uri url = new Uri(baseURL);
            string scookies = FullWebBrowserCookie.GetCookieInternal(url, false);
            cookieContainer.SetCookies(url, scookies.Replace(';', ','));
        }



        private T getit<T>(string method, string url) {
            string data = string.Empty;
            //HttpCookieCollection httpCookies = HttpContext.Current.Request.Cookies;


            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebRequest req = GetNewRequest(url);
           
            //req.CookieContainer = cookieContainer;
            //req.MaximumAutomaticRedirections = 5;
            //req.AllowAutoRedirect = false;
            
            //req.PreAuthenticate = false;
            //req.Credentials = CredentialCache.DefaultCredentials;
            
            //req.Proxy = new WebProxy("127.0.0.1", 8888);   
            //req.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

            //NetworkCredential nc = System.Net.CredentialCache.DefaultNetworkCredentials;
            //nc = CredentialCache.DefaultCredentials;
            // = new NetworkCredential("cs062jp", "", "DITI");
            //req.Credentials = nc;
            //CredentialCache credCache = new CredentialCache();
            //credCache.Add(new Uri("https://federate.landregistry.gov.uk/adfs/oauth2/authorize"), "Negotiate",
            //              CredentialCache.DefaultNetworkCredentials);
            //req.Credentials = credCache;
            // Allow certificate errors
            //req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            //req.Headers.Add("Sec-Fetch-Dest", "document");
            //req.Headers.Add("Sec-Fetch-Mode", "navigate");
            //req.Headers.Add("Sec-Fetch-Site", "none");
            //req.Headers.Add("Sec-Fetch-User", "?1");
            //req.Headers.Add("Upgrade-Insecure-Requests", "1");
            

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            

            while (response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Found) {
                string redirect = response.Headers["Location"];
                req = GetNewRequest(response.Headers["Location"]);
                response.Close();
                response = (HttpWebResponse)req.GetResponse();
                }
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
            /*
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
            */
            return deserialize<T>(data);
            }


        public string get_main() {

            string mainpage = getit<string>("GET", url);
            return mainpage;
            }

        }
    }
