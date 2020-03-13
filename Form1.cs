using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace restClient {
    public partial class Form1 : Form {

        DocsAPI docsApi = new DocsAPI("http://localhost:9995/", "STUB", "titleplan");

        PgAPI pgAPI = new PgAPI();

        public Form1() {
            InitializeComponent();
        }

        private void resOut(string resVal) {
            tbResponse.Text = resVal;
        }


        #region UI events
        private void btnRequest_Click(object sender, EventArgs e) {
            resOut("Getting ...");
            string[] titles = docsApi.get_titles();
            resOut(JsonConvert.SerializeObject(titles, Formatting.Indented));
        }

        private void btnVersions_Click(object sender, EventArgs e) {
            resOut("Getting ...");
            List<string> versions = docsApi.get_versions<List<string>>("unknown", "latest");
            resOut(JsonConvert.SerializeObject(versions, Formatting.Indented));
        }



        private void bPG_Click(object sender, EventArgs e) {
           //
           String mainPage = pgAPI.get_main();




 
            }



        private void btnObjects_Click_1(object sender, EventArgs e) {
            resOut("Getting ...");
            List<Dictionary<string, object>> objects = docsApi.get_objects<List<Dictionary<string, object>>>("unknown", "latest", "latest");
            resOut(JsonConvert.SerializeObject(objects, Formatting.Indented));
        }


        private void btnObject_Click(object sender, EventArgs e) {
            resOut("Getting ...");
            Dictionary<string, object> _object = docsApi.get_object<Dictionary<string, object>>("unknown", "latest", "latest", "1");
            resOut(JsonConvert.SerializeObject(_object, Formatting.Indented));
        }

        #endregion

        private void btnImage_Click(object sender, EventArgs e) {
            resOut("Getting ...");
            Dictionary<string, object> _object = docsApi.get_object<Dictionary<string, object>>("unknown", "latest", "latest", "1");
            string url = (string)_object["obj-url"];
            resOut(JsonConvert.SerializeObject(url, Formatting.Indented));
            imageBox.ImageLocation = url;

        }


        }
}
