using EronCoreProject.Config;
using EronCoreProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EronCoreProject.Entegrations
{
    public class EronEntegration
    {
        private string _baseUrl = "http://eronsoftware.com:55301/KULLANICI/";
        private string GetRequest(string url, IEronModel eronModel, List<KeyValuePair<string, string>> headers)
        {

            var httpRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + url);
            httpRequest.Method = "POST";
            foreach (var item in headers)
            {
                httpRequest.Headers[item.Key] = item.Value;
            }
            httpRequest.ContentType = "text";
            var data = JsonConvert.SerializeObject(eronModel);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }
            var result = "";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
        public bool Login(AuthenticationModel login)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("islem", "LOGIN"));
            headers.Add(new KeyValuePair<string, string>("ptoken", "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt"));
            string response = this.GetRequest("authentication", login, headers);
            if (response == "" || response == null)
                return false;
            var authResponse = JsonConvert.DeserializeObject<List<AuthenticationResponseModel>>(response);
            if (authResponse.Count == 0)
                return false;
            if (authResponse.First().UTOKEN == "" || authResponse.First().UTOKEN == null)
                return false;
            AppData.LoginUser = authResponse.First();
            return true;
        }
        public bool Logout()
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("islem", "LOGOUT"));
            headers.Add(new KeyValuePair<string, string>("ptoken", "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt"));
            headers.Add(new KeyValuePair<string, string>("utoken", AppData.LoginUser.UTOKEN));
            string response = this.GetRequest("authentication", null, headers);
            if (response == "" || response == null)
                return false;
            var logoutResponse = JsonConvert.DeserializeObject<List<LogoutResponseModel>>(response);
            if (logoutResponse.Count == 0)
                return false;
            if (logoutResponse.First().S == "F")
                return false;
            AppData.LoginUser = null;
            return true;
        }
        public List<CategoryListResponseModel> GetAllCategories()
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("islem", "KATEGORI_LISTESI"));
            headers.Add(new KeyValuePair<string, string>("ptoken", "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt"));
            headers.Add(new KeyValuePair<string, string>("utoken", AppData.LoginUser.UTOKEN));
            string response = this.GetRequest("kategori", null, headers);
            if (response == "" || response == null)
                return new List<CategoryListResponseModel>();
            return JsonConvert.DeserializeObject<List<CategoryListResponseModel>>(response);
        }
        public List<CategoryResponseModel> CategoryAdd(CategoryAddModel model)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("islem", "KATEGORI_LISTESI_EKLE"));
            headers.Add(new KeyValuePair<string, string>("ptoken", "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt"));
            headers.Add(new KeyValuePair<string, string>("utoken", AppData.LoginUser.UTOKEN));
            string response = this.GetRequest("kategori", model, headers);
            if (response == "" || response == null)
                return new List<CategoryResponseModel>();
            return JsonConvert.DeserializeObject<List<CategoryResponseModel>>(response);
        }
        public List<CategoryResponseModel> CategoryUpdate(CategoryUpdateModel model)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("islem", "KATEGORI_LISTESI_DUZENLE"));
            headers.Add(new KeyValuePair<string, string>("ptoken", "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt"));
            headers.Add(new KeyValuePair<string, string>("utoken", AppData.LoginUser.UTOKEN));
            string response = this.GetRequest("kategori", model, headers);
            if (response == "" || response == null)
                return new List<CategoryResponseModel>();
            return JsonConvert.DeserializeObject<List<CategoryResponseModel>>(response);
        }
        public List<CategoryResponseModel> CategoryDelete(CategoryDeleteModel model)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("islem", "KATEGORI_LISTESI_SIL"));
            headers.Add(new KeyValuePair<string, string>("ptoken", "OPp60lBs9vqqNiAvzM2QPsgVuzHvld4ZShVGqlYqEcEgi2BGFt"));
            headers.Add(new KeyValuePair<string, string>("utoken", AppData.LoginUser.UTOKEN));
            string response = this.GetRequest("kategori", model, headers);
            if (response == "" || response == null)
                return new List<CategoryResponseModel>();
            return JsonConvert.DeserializeObject<List<CategoryResponseModel>>(response);
        }
    }
}