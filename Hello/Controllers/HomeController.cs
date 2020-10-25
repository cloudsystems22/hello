using Hello.Classes;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Constants.PreApproval;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;

namespace Hello.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Assinatura(int plano)
        {

            string element = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int count = 8;
            Random random = new Random();
            string str = new string(Enumerable.Repeat<string>(element, count).Select<string, char>((Func<string, char>)(s => s[random.Next(s.Length)])).ToArray<char>());

            string tokenAss = "";
            string planoStr = "";
            decimal valorPlan = 0;
            string idPlano = "";
            string refereciaSolicit = str.ToString();
            switch (plano)
            {
                case 1:
                    ViewBag.Img = "banners-planos-um.png";
                    ViewBag.TituloPlano = "Plano Controle - 5Gb";
                    planoStr = "Plano Controle - 3Gb";
                    ViewBag.CodPlano = "ED286F04-6363-E7A8-8464-9FACDBECCAB9";
                    tokenAss = "ED286F04-6363-E7A8-8464-9FACDBECCAB9";
                    valorPlan = Convert.ToDecimal("49.99");
                    idPlano = "8112e29e94175905bafca5bf437d253e";
                    ViewBag.Link = "http://pag.ae/7VhogQScN";
                    break;

                case 2:
                    ViewBag.Img = "banners-planos-um.png";
                    ViewBag.TituloPlano = "Plano Controle - 5Gb";
                    planoStr = "Plano Controle - 5Gb";
                    ViewBag.CodPlano = "ED286F04-6363-E7A8-8464-9FACDBECCAB9";
                    tokenAss = "ED286F04-6363-E7A8-8464-9FACDBECCAB9";
                    valorPlan = Convert.ToDecimal("49.99");
                    idPlano = "8112e29e94175905bafca5bf437d253e";
                    ViewBag.Link = "http://pag.ae/7VhogQScN";
                    break;

                case 3:
                    ViewBag.Img = "banners-planos-dois.png";
                    ViewBag.TituloPlano = "Plano Controle - 10Gb";
                    planoStr = "Plano Controle - 10Gb";
                    ViewBag.CodPlano = "5BEFCBEB-2424-4430-0432-9F9828128A99";
                    tokenAss = "5BEFCBEB-2424-4430-0432-9F9828128A99";
                    valorPlan = Convert.ToDecimal("59.99");
                    idPlano = "3977db37c524d10bfe85c89feb2c3fa6";
                    ViewBag.Link = "http://pag.ae/7VfxmPNKs";
                    break;

                case 4:
                    ViewBag.Img = "banners-planos-tres.png";
                    ViewBag.TituloPlano = "Plano Controle - 15Gb";
                    planoStr = "Plano Controle - 15Gb";
                    ViewBag.Botao = "<form action='https://pagseguro.uol.com.br/pre-approvals/request.html' method='post'>" +
                                    "<input type='hidden' name = 'code' value = '24A399FC11115222240B3FB33815223B' />" +
                                    "<input type='hidden' name = 'iot' value = 'button' />" +
                                    "<input type='image' src='https://stc.pagseguro.uol.com.br/public/img/botoes/assinaturas/120x53-assinar.gif' name='submit' alt='Pague com PagSeguro - É rápido, grátis e seguro!' width='120' height='53' /></form> ";
                    ViewBag.CodPlano = "24A399FC-1111-5222-240B-3FB33815223B";
                    tokenAss = "24A399FC-1111-5222-240B-3FB33815223B";
                    valorPlan = Convert.ToDecimal("69.99");
                    idPlano = "eb909df23502218d04537c87e84ccc2b";
                    ViewBag.Link = "http://pag.ae/7Vg-1AZcN";
                    break;

                case 5:
                    ViewBag.Img = "banners-planos-quatro.png";
                    ViewBag.TituloPlano = "Plano Controle - 20Gb";
                    planoStr = "Plano Controle - 20Gb";
                    ViewBag.CodPlano = "B1C63082-5252-EE01-1448-9F9EA998F655";
                    tokenAss = "B1C63082-5252-EE01-1448-9F9EA998F655";
                    valorPlan = Convert.ToDecimal("79.99");
                    idPlano = "05d95904a4ad1b27c911cab692b2f544";
                    ViewBag.Link = "http://pag.ae/7Vh5iBxw9";
                    break;

                case 6:
                    ViewBag.Img = "banners-planos-cinco.png";
                    ViewBag.TituloPlano = "Plano Controle - 50Gb";
                    planoStr = "Plano Controle - 50Gb";
                    ViewBag.CodPlano = "A64D4245-4848-4397-745C-8FBA5DB91A89";
                    tokenAss = "A64D4245-4848-4397-745C-8FBA5DB91A89";
                    valorPlan = Convert.ToDecimal("99.99");
                    idPlano = "15b808f045b411fac57159017b31fe35";
                    ViewBag.Link = "http://pag.ae/7Vhcmk9Eq";
                    break;
            }
            ViewBag.Plano = plano;

            //AdesaoPlanos(idPlano,valorPlan, idPlano, planoStr, refereciaSolicit);
            return View();
        }

        [HttpPost]
        public ActionResult Assinatura(int plano, string assunto, string nomeAss, string emailAss, string cepAss, string bairroAss, string logradouroAss, string numeroAss, string cidadeAss, string estadoAss, string numTelAss, string complementoAss, string numDDDAss, string cpfAss, string rgAss, string cellDDD, string numCell, string tipoNum, string radGroupBtn2_1, string radGroupBtn2_2, HttpPostedFileBase pdfFile, string newsletter)
        {

            ViewBag.Plano = plano;
            string linhaTipoDoc = "";
            string linhaTipoCli = "";
            string receberNoticias = "";

            string Path = "~/Attachments";

            if (pdfFile.FileName.EndsWith("pdf") || pdfFile.FileName.EndsWith("jpg"))
            {
                //string arquivoEx = Server.MapPath(@"\Attachments\" + pdfFile.FileName);
                try
                {
                    FilesUpload.UploadPhoto(pdfFile, Path);
                }
                catch
                {
                    ViewBag.Erro1 = "O arquivo já está sendo utilizado em outro processo! Por favor renomeio o arquivo ou atualize o site clicando em " + "<i class=''></i>" + " e tente novamente!";
                }


                string arquivoPdf = string.Format("{0}/{1}", Path, pdfFile);
            }

            if (radGroupBtn2_1 == "on")
            {
                linhaTipoDoc = "<tr><td style='width:120px;'>CPF:</td><td style='width:380px'>" + cpfAss + "</td></tr>";
            }
            else if (radGroupBtn2_2 == "on")
            {
                linhaTipoDoc = "<tr><td style='width:120px;'>CNPJ:</td><td style='width:380px'>" + cpfAss + "</td></tr>";
            }

            if (newsletter == "on")
            {
                receberNoticias = "<tr><td style='width:120px;'></td><td style='width:380px'>Aceito receber notícias e promoções.</td></tr>";
            }
            else
            {
                receberNoticias = "<tr><td style='width:120px;'></td><td style='width:380px'>Não solicitei receber notícias e promoções.</td></tr>";
            }

            MailMessage objEmail = new MailMessage();
            //objEmail.From = new MailAddress("pediulogistica@uniglobaltelecom.com");
            objEmail.From = new MailAddress(emailAss);
            //objEmail.ReplyTo = new MailAddress("davidfico22@gmail.com", "damico@mdk.net.br");
            objEmail.To.Add("contato@hellocelular.com.br");
            //objEmail.To.Add("davidfico22@gmail.com");
            objEmail.Bcc.Add("damico@mdk.net.br");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assunto;
            string anexo = Server.MapPath(@"\Attachments\" + pdfFile.FileName);
            objEmail.Attachments.Add(new Attachment(anexo));
            objEmail.Body = "<h3 style='font-family:Arial'>" + nomeAss + "</h3>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr style='background-color:#0a2f59'>" +
                "<td style='width:120px;'><img src='http://www.unioperadora.com.br/assets/img/logo/LogoEasySim4u.png' alt='Logo Unioperadora' style='width:120px' /></td>" +
                "<td style='width:380px'><h3 style='font-family:Arial; color:white; text-align:center'>Assinatura - " + assunto + "</h3></td></tr></table>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                linhaTipoDoc +
                "<tr><td style='width:120px;'>RG:</td><td style='width:380px'>" + rgAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Email:</td><td style='width:380px'>" + emailAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Fone:</td><td style='width:380px'>" + "(" + numDDDAss + ")" + numTelAss + "</td></tr>" +
                "<tr><td style='width:120px;'>CEP:</td><td style='width:380px'>" + cepAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Bairro:</td><td style='width:380px'>" + bairroAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Logradouro:</td><td style='width:380px'>" + logradouroAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Numero:</td><td style='width:380px'>" + numeroAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Compl.:</td><td style='width:380px'>" + complementoAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Cidade:</td><td style='width:380px'>" + cidadeAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Estado:</td><td style='width:380px'>" + estadoAss + "</td></tr>" +
                "<tr><td style='width:120px;'>Cell:</td><td style='width:380px'>" + "(" + cellDDD + ")" + numCell + "</td></tr>" +
                receberNoticias +
                "<tr><td style='width:120px;'></td><td style='width:380px'>Concordo com os termos de uso. " + nomeAss + "- CPF:" + cpfAss + "</td></tr>";
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = "mail.unioperadora.com.br";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            objSmtp.Credentials = new NetworkCredential("contato_easy@unioperadora.com", "Campinas2020");
            objSmtp.Send(objEmail);

            string urlPag = "";
            switch (plano)
            {
                case 1:
                    urlPag = "http://pag.ae/7VhogQScN";
                    break;

                case 2:
                    urlPag = "http://pag.ae/7VfxmPNKs";
                    break;

                case 3:
                    urlPag = "http://pag.ae/7Vg-1AZcN";
                    break;

                case 4:
                    urlPag = "http://pag.ae/7Vh5iBxw9";
                    break;

                case 5:
                    urlPag = "http://pag.ae/7Vhcmk9Eq";
                    break;
            }
            return Redirect(urlPag);
        }


        public void ativacaoHello()
        {
            var client = new RestSharp.RestClient("www.yescontrol.com.br/api/activate");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "PHPSESSID=jr5nmbeo1dckulrg5bo12gljk6");
            request.AddParameter("application/json", "{\"customer\":\"hellonacional\", \"token\":\"EF058C69-8BA107-49D6-A4A7-04C0DB3E9FA4\", \"nome\":\"DAVID FICO\", \"simcard\":\"998565284\", \"ddd\":\"19\", \"email\":\"davidfico22@gmail.com\", \"Da22\"}", ParameterType.RequestBody);

            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            var response = client.Get(request);
        }

        public void ativacaoHelloII()
        {
            var client = new RestSharp.RestClient("www.yescontrol.com.br/api/activate");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("token", "EF058C69-8BA107-49D6-A4A7-04C0DB3E9FA4");
            request.AddHeader("customer", "hellonacional");
            request.AddHeader("Cookie", "PHPSESSID=94hqpalvusam43ublad2piu1r2");
            request.AddParameter("application/json", "{\"nome\":\"DAVID FICO\", \"simcard\":\"998565284\", \"ddd\":\"19\", \"email\":\"davidfico22@gmail.com\", \"Da22\"}", ParameterType.RequestBody);

            var response = client.Get(request);
            Console.WriteLine(response);
        }
       

        public async Task<string> AtivacaoAsync(string nome, string simcard, string ddd, string documento, string celular, string email, string logradouro, string numero, string bairro, string cep, string cidade, string estado, string senha)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("customer", "hellonacional"),
                new KeyValuePair<string, string>("token", "EF058C69-8BA107-49D6-A4A7-04C0DB3E9FA4"),
                new KeyValuePair<string, string>("nome", nome),
                new KeyValuePair<string, string>("simcard", simcard),
                new KeyValuePair<string, string>("ddd", ddd),
                new KeyValuePair<string, string>("documento", documento),
                new KeyValuePair<string, string>("celular", celular),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("logradouro", logradouro),
                new KeyValuePair<string, string>("numero", numero),
                new KeyValuePair<string, string>("bairro", bairro),
                new KeyValuePair<string, string>("cep", cep),
                new KeyValuePair<string, string>("cidade", cidade),
                new KeyValuePair<string, string>("estado", estado),
                new KeyValuePair<string, string>("senha", senha)
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.yescontrol.com.br/api");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var jwt = await response.Content.ReadAsStringAsync();
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var accessToken = jwtDynamic.Value<string>("access_token");
            //Debug.WriteLine(jwt);

            return accessToken;
        }





        [HttpPost]
        public JsonResult CheckOut(string plano, string tokenAss, string valor, string nome, string codArea, string phone, string email, string logradouro, string number, string complement, string bairro, string cep, string cidade, string uf)
        {
            //URI de checkout.
            string credenciais = "af5da14e-1d7f-4e4a-b3eb-848692cf2b3fa0f8b638473da3c1a7ed9438b11b0cb0c109-92ac-45f7-b082-738db55cb886";
            string uri = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout?" + credenciais;
            string uriAdsaoPlano = @"T https://ws.pagseguro.uol.com.br/pre-approvals?" + credenciais;

            //Conjunto de parâmetros/formData.
            System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection();
            postData.Add("email", "uni@yescelular.com.br");
            postData.Add("token", tokenAss);
            postData.Add("currency", "BRL");
            postData.Add("itemId1", "0001");
            postData.Add("itemDescription1", plano);
            postData.Add("itemAmount1", valor);
            postData.Add("itemQuantity1", "1");
            postData.Add("itemWeight1", "200");
            postData.Add("reference", "REF1234");
            postData.Add("senderName", nome);
            postData.Add("senderAreaCode", codArea);
            postData.Add("senderPhone", phone);
            postData.Add("senderEmail", email);
            postData.Add("shippingAddressRequired", "true");
            postData.Add("shippingAddressStreet", logradouro);
            postData.Add("shippingAddressNumber", number);
            postData.Add("shippingAddressComplement", complement);
            postData.Add("shippingAddressDistrict", bairro);
            postData.Add("shippingAddressPostalCode", cep);
            postData.Add("shippingAddressCity", cidade);
            postData.Add("shippingAddressState", uf);
            postData.Add("shippingAddressCountry", "BRA");

            //String que receberá o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                var result = wc.UploadValues(uri, postData);

                //Obtém string do XML.
                xmlString = Encoding.ASCII.GetString(result);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obtém código de transação (Checkout).
            var code = xmlDoc.GetElementsByTagName("code")[0];

            //Obtém data de transação (Checkout).
            var date = xmlDoc.GetElementsByTagName("date")[0];

            //Monta a URL para pagamento.
            var paymentUrl = string.Concat("https://sandbox.pagseguro.uol.com.br/v2/checkout/payment.html?code=", code.InnerText);

            //Retorna dados para HTML.
            //return Json(paymentUrl);
            return Json(new { paymentUrl }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public JsonResult ConsultarPlanosRest()
        //{
        //    var client = new RestSharp.RestClient("https://ws.sandbox.pagseguro.uol.com.br/pre-approvals/request");
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("content-type", "application/xml; charset=ISO-8859-1");
        //    request.AddHeader("Accept", "application/vnd.pagseguro.com.br.v3+xml;charset=ISO-8859-1");
        //    //request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=ISO-8859-1");
        //    //request.AddHeader("Content-Type", "application/json; charset=utf-8");
        //    request.RequestFormat = DataFormat.Xml;
        //    //request.AddParameter("Content-Type", "application/x-www-form-urlencoded; charset=ISO-8859-1");
        //    request.AddParameter("email", "uni@yescelular.com.br");
        //    request.AddParameter("token", "35FA5DC5D426485784C9A5FB13FD2E43");
        //    IRestResponse response = client.Execute(request);

        //    return Json(response);
        //}

        //[HttpPost]
        //public JsonResult CriarPlanoRest()
        //{
        //    var client = new RestSharp.RestClient("https://ws.sandbox.pagseguro.uol.com.br/pre-approvals/request");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("content-type", "application/xml; charset=ISO-8859-1");
        //    request.AddHeader("Accept", "application/vnd.pagseguro.com.br.v3+xml;charset=ISO-8859-1");
        //    //request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=ISO-8859-1");
        //    //request.AddHeader("Content-Type", "application/json; charset=utf-8");
        //    request.RequestFormat = DataFormat.Xml;
        //    //request.AddParameter("Content-Type", "application/x-www-form-urlencoded; charset=ISO-8859-1");
        //    request.AddParameter("email", "uni@yescelular.com.br");
        //    request.AddParameter("token", "35FA5DC5D426485784C9A5FB13FD2E43");
        //    IRestResponse response = client.Execute(request);

        //    return Json(response);
        //}

        //[HttpPost]
        //public JsonResult AdesaoPlanoRest()
        //{
        //    var client = new RestSharp.RestClient("https://ws.sandbox.pagseguro.uol.com.br/pre-approvals");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("content-type", "application/xml; charset=ISO-8859-1");
        //    request.AddHeader("Accept", "application/vnd.pagseguro.com.br.v3+xml;charset=ISO-8859-1");
        //    //request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=ISO-8859-1");
        //    //request.AddHeader("Content-Type", "application/json; charset=utf-8");
        //    request.RequestFormat = DataFormat.Xml;
        //    //request.AddParameter("Content-Type", "application/x-www-form-urlencoded; charset=ISO-8859-1");
        //    request.AddParameter("email", "uni@yescelular.com.br");
        //    request.AddParameter("token", "35FA5DC5D426485784C9A5FB13FD2E43");
        //    request.AddParameter("plan", "B533C30AF1F14D2AA4B95FB8759FE0D0");
        //    request.AddParameter("reference", "REF1234");
        //    request.AddParameter("sender.name", "DAVID");
        //    request.AddParameter("sender.email", "davidfico22@sandbox.pagseguro.com.br");
        //    request.AddParameter("sender.ip", "192.168.0.1");
        //    request.AddParameter("sender.hash", "hash");
        //    request.AddParameter("sender.phone.areaCode", "19");
        //    request.AddParameter("sender.phone.number", "9999999");
        //    request.AddParameter("paymentMethod.type", "");
        //    request.AddParameter("paymentMethod.creditCard.token", "30303030303000004");
        //    request.AddParameter("paymentMethod.creditCard.holder.name", "DAVID FICO");
        //    request.AddParameter("paymentMethod.creditCard.holder.birthDate", "22/05/1978");

        //    IRestResponse response = client.Execute(request);

        //    return Json(response);
        //}


        [HttpPost]
        public JsonResult CriarPlano()
        {

            string uriCriarPlanSandbox = @"https://ws.sandbox.pagseguro.uol.com.br/pre-approvals/request";
            System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection
            {
                { "email", "uni@yescelular.com.br" },
                { "token", "35FA5DC5D426485784C9A5FB13FD2E43" },
                { "currency", "BRL" },
                { "reference", "REF1" },
                { "preApprovalName", "Plano Controle 15Gb" },
                { "preApprovalCharge", "AUTO" },
                //{ "sender.ip", "192.168.0.1" },
                //{ "sender.hash", "hash" },
                { "preApprovalPeriod", "MONTHLY" },
                { "preApprovalAmountPerPayment", "79.90" },
                { "preApprovalDetails", "Plano controle sera cobrado mensamente todo dia 12" },
                { "receiverEmail", "davidfico22@sandbox.pagseguro.com.br" }

                //{ "preApprovalCharge", "auto" },
                //{ "preApprovalName", "Assinatura mensal" },
                //{ "preApprovalDetails", "Cobrança de valor mensal para assinatura" },
                //{ "preApprovalAmountPerPayment", "199.99"},
                //{ "preApprovalPeriod", "MONTHLY"}
            };
            //String que receberá o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                //wc.Headers[HttpRequestHeader.ContentType] = "application/xml;charset=ISO-8859-1";

                //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                var result = wc.UploadValues(uriCriarPlanSandbox, postData);
                //var sessao = wc.UploadValues(uriAdSessaoSandbox, null);

                //Obtém string do XML.
                xmlString = Encoding.ASCII.GetString(result);
                //xmlString = Encoding.ASCII.GetString(sessao);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obtém código de transação (Checkout).
            var code = xmlDoc.GetElementsByTagName("code")[0];

            //Obtém data de transação (Checkout).
            var date = xmlDoc.GetElementsByTagName("date")[0];

            //Monta a URL para pagamento.
            var paymentUrl = string.Concat("https://pagseguro.uol.com.br/checkout/v2/pre-approvals/nc/sender-identification.jhtml?t=", code.InnerText);

            //Retorna dados para HTML.
            return Json(paymentUrl);
            //return Json(true);

        }



        [HttpPost]
        public JsonResult AdesaoPlano(int plano, string nome, string cpf, string codArea, string phone, string email, string logradouro, string number, string complement, string bairro, string cep, string cidade, string uf)
        {


            string alphnumerico = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int count = 8;
            Random random = new Random();
            string str = new string(Enumerable.Repeat<string>(alphnumerico, count).Select<string, char>((Func<string, char>)(s => s[random.Next(s.Length)])).ToArray<char>());
            string tokenAss = "";
            string planoStr = "";
            decimal valorPlan = 0;
            string idPlano = "";
            string refInter = "";
            string refereciaSolicit = str.ToString();
            switch (plano)
            {
                case 1:
                    planoStr = "Plano Controle - 10Gb";
                    tokenAss = "5BEFCBEB-2424-4430-0432-9F9828128A99";
                    valorPlan = Convert.ToDecimal("59,90");
                    idPlano = "3977db37c524d10bfe85c89feb2c3fa6";
                    break;

                case 2:
                    planoStr = "Plano Controle - 15Gb";
                    tokenAss = "24A399FC-1111-5222-240B-3FB33815223B";
                    valorPlan = Convert.ToDecimal("79,90");
                    idPlano = "eb909df23502218d04537c87e84ccc2b";
                    break;

                case 3:
                    refInter = "CRT20GB";
                    planoStr = "Plano Controle - 20Gb";
                    tokenAss = "B1C63082-5252-EE01-1448-9F9EA998F655";
                    valorPlan = Convert.ToDecimal("89,90");
                    idPlano = "05d95904a4ad1b27c911cab692b2f544";
                    break;

            }

            //URI de checkout.
            string credenciais = "af5da14e-1d7f-4e4a-b3eb-848692cf2b3fa0f8b638473da3c1a7ed9438b11b0cb0c109-92ac-45f7-b082-738db55cb886";
            string credencSandbox = "35FA5DC5D426485784C9A5FB13FD2E43";

            string uriAdsaoPlano = @"https://ws.pagseguro.uol.com.br/pre-approvals?" + credenciais;
            //string uriAdPlanSandbox = @"https://ws.sandbox.pagseguro.uol.com.br/pre-approvals?email=uni@yescelular.com.br&token=35FA5DC5D426485784C9A5FB13FD2E43";
            string uriAdPlanSandbox = @"https://ws.sandbox.pagseguro.uol.com.br/pre-approvals";


            //Conjunto de parâmetros/formData.
            System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection
            {
                { "email", "uni@yescelular.com.br" },
                { "token", "35FA5DC5D426485784C9A5FB13FD2E43" },
                { "plan", tokenAss },
                { "currency", "BRL" },
                { "reference", "REF1" },
                { "senderName", nome },
                { "senderEmail", email },
                //{ "sender.ip", "192.168.0.1" },
                //{ "sender.hash", "hash" },
                { "sender.phone.areaCode", codArea },
                { "sender.phone.numero", phone },
                { "sender.address.street", logradouro },
                { "sender.address.number", number },
                { "sender.address.complement", complement },
                { "sender.address.district", bairro },
                { "sender.address.city", cidade },
                { "sender.address.state", uf },
                { "sender.address.postalCode", cep },
                { "sender.documents.type", "CPF" },
                { "sender.documents.value", cpf }

                //{ "preApprovalCharge", "auto" },
                //{ "preApprovalName", "Assinatura mensal" },
                //{ "preApprovalDetails", "Cobrança de valor mensal para assinatura" },
                //{ "preApprovalAmountPerPayment", "199.99"},
                //{ "preApprovalPeriod", "MONTHLY"}
        };

            //String que receberá o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                var result = wc.UploadValues(uriAdPlanSandbox, postData);
                //var sessao = wc.UploadValues(uriAdSessaoSandbox, null);

                //Obtém string do XML.
                xmlString = Encoding.ASCII.GetString(result);
                //xmlString = Encoding.ASCII.GetString(sessao);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obtém código de transação (Checkout).
            var code = xmlDoc.GetElementsByTagName("code")[0];

            //Obtém data de transação (Checkout).
            var date = xmlDoc.GetElementsByTagName("date")[0];

            //Monta a URL para pagamento.
            var paymentUrl = string.Concat("https://sandbox.pagseguro.uol.com.br/v2/checkout/payment.html?code=", code.InnerText);

            //Retorna dados para HTML.
            //return Json(paymentUrl);
            return Json(new { paymentUrl }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult VendaProd()
        {


            //URI de checkout.
            string credenciais = "af5da14e-1d7f-4e4a-b3eb-848692cf2b3fa0f8b638473da3c1a7ed9438b11b0cb0c109-92ac-45f7-b082-738db55cb886";
            string credencSandbox = "35FA5DC5D426485784C9A5FB13FD2E43";

            string uriSandbox = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout";



            //Conjunto de parâmetros/formData.
            System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection
            {
                { "email", "uni@yescelular.com.br" },
                { "token", "35FA5DC5D426485784C9A5FB13FD2E43" },
                { "currency", "BRL" },
                { "itemId1", "0001" },
                { "itemDescription1", "NOTEBOOK SEMP TOSHIBA" },
                { "itemAmount1", "3000.00" },
                { "itemQuantity1", "1" },
                { "itemWeight", "200" },
                { "reference", "REF1" },
                { "senderName", "David Fico" },
                { "senderAreaCode", "19" },
                { "senderPhone", "99999999" },
                { "senderEmail", "davidfico22@sandbox.pagseguro.com.br" },
                { "shippingAddressRequirede", "false" }
            };

            //String que receberá o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                var result = wc.UploadValues(uriSandbox, postData);
                //var sessao = wc.UploadValues(uriAdSessaoSandbox, null);

                //Obtém string do XML.
                xmlString = Encoding.ASCII.GetString(result);
                //xmlString = Encoding.ASCII.GetString(sessao);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obtém código de transação (Checkout).
            var code = xmlDoc.GetElementsByTagName("code")[0];

            //Obtém data de transação (Checkout).
            var date = xmlDoc.GetElementsByTagName("date")[0];

            //Monta a URL para pagamento.
            var paymentUrl = string.Concat("https://sandbox.pagseguro.uol.com.br/v2/checkout/payment.html?code=", code.InnerText);

            //Retorna dados para HTML.
            //return Json(paymentUrl);
            return Json(paymentUrl);
        }



        [HttpPost]
        public JsonResult Sessao()
        {


            string uriAdSessaoSandbox = @"https://ws.sandbox.pagseguro.uol.com.br/sessions";

            System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection
            {
                { "email", "uni@yescelular.com.br" },
                { "token", "35FA5DC5D426485784C9A5FB13FD2E43" }

            };

            //String que receberá o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                var sessao = wc.UploadValues(uriAdSessaoSandbox, postData);

                //Obtém string do XML.

                xmlString = Encoding.ASCII.GetString(sessao);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obtém código de transação (Checkout).
            var code = xmlDoc.GetElementsByTagName("code")[0];

            //Obtém data de transação (Checkout).
            var date = xmlDoc.GetElementsByTagName("id")[0];
            string sessaoStr = xmlDoc.InnerText;

            return Json(new { sessaoStr }, JsonRequestBehavior.AllowGet);
        }




        public ActionResult SucessoAss()
        {
            return View();
        }


        public JsonResult EnviaEmail(string assunto, string nome, string email, string cep, string bairro, string logradouro, string numero, string cidade, string estado, string telefone, string mensagem, string complemento)
        {
            MailMessage objEmail = new MailMessage();
            //objEmail.From = new MailAddress("pediulogistica@uniglobaltelecom.com");
            objEmail.From = new MailAddress(email);
            //objEmail.ReplyTo = new MailAddress("davidfico22@gmail.com", "damico@mdk.net.br");
            objEmail.To.Add("contato@hellocelular.com.br");
            //objEmail.To.Add("davidfico22@gmail.com");
            objEmail.Bcc.Add("damico@mdk.net.br");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assunto;
            objEmail.Body = "<h3 style='font-family:Arial'>" + nome + "</h3>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr style='background-color:#0a2f59'>" +
                "<td style='width:120px;'><img src='http://www.unioperadora.com.br/assets/img/logo/logo.png' alt='Logo Unioperadora' style='width:120px' /></td>" +
                "<td style='width:380px'><h3 style='font-family:Arial; color:white; text-align:center'>" + assunto + "</h3></td></tr></table>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr><td>Email:</td><td>" + email + "</td></tr>" +
                "<tr><td>Fone:</td><td>" + telefone + "</td></tr>" +
                "<tr><td>CEP:</td><td>" + cep + "</td></tr>" +
                "<tr><td>Bairro:</td><td>" + bairro + "</td></tr>" +
                "<tr><td>Logradouro:</td><td>" + logradouro + "</td></tr>" +
                "<tr><td>Numero:</td><td>" + numero + "</td></tr>" +
                "<tr><td>Compl.:</td><td>" + complemento + "</td></tr>" +
                "<tr><td>Cidade:</td><td>" + cidade + "</td></tr>" +
                "<tr><td>Estado:</td><td>" + estado + "</td></tr>" +
                "<tr><td colspan='2'>Mensagem:</td></tr>" +
                "<tr><td colspan='2'>" + mensagem + "</td></tr>";
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = "mail.unioperadora.com.br";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            objSmtp.Credentials = new NetworkCredential("contato_easy@unioperadora.com", "Campinas2020");
            objSmtp.Send(objEmail);


            return Json(true);
        }

        [HttpPost]
        public JsonResult EnviaEmail2(string assunto, string nome, string email, string telefone, string mensagem)
        {

            MailMessage objEmail = new MailMessage();
            //objEmail.From = new MailAddress("pediulogistica@uniglobaltelecom.com");
            objEmail.From = new MailAddress(email);
            //objEmail.ReplyTo = new MailAddress("davidfico22@gmail.com", "damico@mdk.net.br");
            objEmail.To.Add("contato@hellocelular.com.br");
            //objEmail.To.Add("davidfico22@gmail.com");
            objEmail.Bcc.Add("damico@mdk.net.br");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assunto;
            objEmail.Body = "<h3 style='font-family:Arial'>" + nome + "</h3>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr style='background-color:#0a2f59'>" +
                "<td style='width:120px;'><img src='http://www.unioperadora.com.br/assets/img/logo/LogoEasySim4u.png' alt='Logo Unioperadora' style='width:120px' /></td>" +
                "<td style='width:380px'><h3 style='font-family:Arial; color:white; text-align:center'>" + assunto + "</h3></td></tr></table>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr><td>Email:</td><td>" + email + "</td></tr>" +
                "<tr><td>Fone:</td><td>" + telefone + "</td></tr>" +
                "<tr><td colspan='2'>Mensagem:</td></tr>" +
                "<tr><td colspan='2'>" + mensagem + "</td></tr>";
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = "mail.unioperadora.com.br";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            objSmtp.Credentials = new NetworkCredential("contato_easy@unioperadora.com", "Campinas2020");
            objSmtp.Send(objEmail);


            return Json(true);
        }

        [HttpPost]
        public JsonResult EnviaEmail3(string assunto, string nome, string email, string cep, string bairro, string logradouro, string numero, string cidade, string estado, string telefone, string iccid, string complemento, string numDDD, string numerocell, string tipoNumero, string rg, string cpf)
        {


            MailMessage objEmail = new MailMessage();
            //objEmail.From = new MailAddress("pediulogistica@uniglobaltelecom.com");
            objEmail.From = new MailAddress(email);
            //objEmail.ReplyTo = new MailAddress("davidfico22@gmail.com", "damico@mdk.net.br");
            objEmail.To.Add("ativacao@unioperadora.com.br");
            //objEmail.To.Add("davidfico22@gmail.com");
            objEmail.Bcc.Add("damico@mdk.net.br");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assunto;
            objEmail.Body = "<h3 style='font-family:Arial'>" + nome + "</h3>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr style='background-color:#0a2f59'>" +
                "<td style='width:120px;'><img src='http://www.unioperadora.com.br/assets/img/logo/LogoEasySim4u.png' alt='Logo Unioperadora' style='width:120px' /></td>" +
                "<td style='width:380px'><h3 style='font-family:Arial; color:white; text-align:center'>Ativação - " + assunto + "</h3></td></tr></table>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr><td style='width:120px;'>RG:</td><td style='width:380px'>" + rg + "</td></tr>" +
                "<tr><td style='width:120px;'>CPF:</td><td style='width:380px'>" + cpf + "</td></tr>" +
                "<tr><td style='width:120px;'>Email:</td><td style='width:380px'>" + email + "</td></tr>" +
                "<tr><td style='width:120px;'>Fone:</td><td style='width:380px'>" + telefone + "</td></tr>" +
                "<tr><td style='width:120px;'>CEP:</td><td style='width:380px'>" + cep + "</td></tr>" +
                "<tr><td style='width:120px;'>Bairro:</td><td style='width:380px'>" + bairro + "</td></tr>" +
                "<tr><td style='width:120px;'>Logradouro:</td><td style='width:380px'>" + logradouro + "</td></tr>" +
                "<tr><td style='width:120px;'>Numero:</td><td style='width:380px'>" + numero + "</td></tr>" +
                "<tr><td style='width:120px;'>Compl.:</td><td style='width:380px'>" + complemento + "</td></tr>" +
                "<tr><td style='width:120px;'>Cidade:</td><td style='width:380px'>" + cidade + "</td></tr>" +
                "<tr><td style='width:120px;'>Estado:</td><td style='width:380px'>" + estado + "</td></tr>" +
                "<tr><td style='width:120px;'>ICCID:</td><td style='width:380px'>" + iccid + "</td></tr>" +
                "<tr><td style='width:120px;'>Cell:</td><td style='width:380px'>" + "(" + numDDD + ")" + numerocell + "</td></tr>" +
                "<tr><td style='width:120px;'>Tipo:</td><td style='width:380px'>" + tipoNumero + "</td></tr>";
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = "mail.unioperadora.com.br";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            objSmtp.Credentials = new NetworkCredential("contato_easy@unioperadora.com", "Campinas2020");
            objSmtp.Send(objEmail);


            return Json(true);
        }


        [HttpPost]
        public JsonResult AnexarArquivo(HttpPostedFileBase pdfFile)
        {
            string Path = "~/Attachments";
            if (pdfFile.FileName.EndsWith("pdf"))
            {
                FilesUpload.UploadPhoto(pdfFile, Path);
                string arquivoPdf = string.Format("{0}/{1}", Path, pdfFile);
                return Json(new { pdfFile }, JsonRequestBehavior.AllowGet);
            }
            return Json(true);
        }

        [HttpPost]
        public ActionResult AttachmentFile(HttpPostedFileBase pdfFile)
        {
            string Path = "~/Attachments";
            if (pdfFile.FileName.EndsWith("pdf"))
            {
                FilesUpload.UploadPhoto(pdfFile, Path);
                string arquivoPdf = string.Format("{0}/{1}", Path, pdfFile);
                return View();
            }
            return View();
        }


        [HttpPost]
        public JsonResult EnviaEmailPlanRecorr(string assunto, string nome, string email, string cep, string bairro, string logradouro, string numero, string cidade, string estado, string telefone, string complemento, string numDDD, string cpf, string rg, string cellDDD, string cellNum, string tipoNum, string tipoCliente, HttpPostedFileBase pdfFile)
        {

            string linhaTipoDoc = "";
            string linhaTipoCli = "";

            string Path = "~/Attachments";
            if (pdfFile.FileName.EndsWith("pdf") || pdfFile.FileName.EndsWith("jpg"))
            {

                if (System.IO.File.Exists(Path + "/" + pdfFile.FileName))
                {
                    System.IO.File.Delete(Path + "/" + pdfFile.FileName);
                }

                FilesUpload.UploadPhoto(pdfFile, Path);
                string arquivoPdf = string.Format("{0}/{1}", Path, pdfFile);
            }

            if (tipoCliente == "PessoaFísica")
            {
                linhaTipoDoc = "<tr><td style='width:120px;'>CPF:</td><td style='width:380px'>" + cpf + "</td></tr>";
            }
            else if (tipoCliente == "PessoaJurídica")
            {
                linhaTipoDoc = "<tr><td style='width:120px;'>CNPJ:</td><td style='width:380px'>" + cpf + "</td></tr>";
            }

            MailMessage objEmail = new MailMessage();
            //objEmail.From = new MailAddress("pediulogistica@uniglobaltelecom.com");
            objEmail.From = new MailAddress(email);
            //objEmail.ReplyTo = new MailAddress("davidfico22@gmail.com", "damico@mdk.net.br");
            objEmail.To.Add("ativacao@unioperadora.com.br");
            //objEmail.To.Add("davidfico22@gmail.com");
            objEmail.Bcc.Add("damico@mdk.net.br");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = assunto;
            string anexo = Server.MapPath(@"\Attachments\" + pdfFile);
            objEmail.Attachments.Add(new Attachment(anexo));
            objEmail.Body = "<h3 style='font-family:Arial'>" + nome + "</h3>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                "<tr style='background-color:#0a2f59'>" +
                "<td style='width:120px;'><img src='http://www.unioperadora.com.br/assets/img/logo/LogoEasySim4u.png' alt='Logo Unioperadora' style='width:120px' /></td>" +
                "<td style='width:380px'><h3 style='font-family:Arial; color:white; text-align:center'>Assinatura - " + assunto + "</h3></td></tr></table>" +
                "<table style='width:500px; height:70px; font-family:Arial; border:0px'>" +
                linhaTipoDoc +
                "<tr><td style='width:120px;'>RG:</td><td style='width:380px'>" + rg + "</td></tr>" +
                "<tr><td style='width:120px;'>Email:</td><td style='width:380px'>" + email + "</td></tr>" +
                "<tr><td style='width:120px;'>Fone:</td><td style='width:380px'>" + "(" + numDDD + ")" + telefone + "</td></tr>" +
                "<tr><td style='width:120px;'>CEP:</td><td style='width:380px'>" + cep + "</td></tr>" +
                "<tr><td style='width:120px;'>Bairro:</td><td style='width:380px'>" + bairro + "</td></tr>" +
                "<tr><td style='width:120px;'>Logradouro:</td><td style='width:380px'>" + logradouro + "</td></tr>" +
                "<tr><td style='width:120px;'>Numero:</td><td style='width:380px'>" + numero + "</td></tr>" +
                "<tr><td style='width:120px;'>Compl.:</td><td style='width:380px'>" + complemento + "</td></tr>" +
                "<tr><td style='width:120px;'>Cidade:</td><td style='width:380px'>" + cidade + "</td></tr>" +
                "<tr><td style='width:120px;'>Estado:</td><td style='width:380px'>" + estado + "</td></tr>" +

                "<tr><td style='width:120px;'>Cell:</td><td style='width:380px'>" + "(" + cellDDD + ")" + cellNum + "</td></tr>";
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = "mail.unioperadora.com.br";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            objSmtp.Credentials = new NetworkCredential("contato_easy@unioperadora.com", "Campinas2020");
            objSmtp.Send(objEmail);


            return Json(true);
        }



        [HttpPost]
        public JsonResult CriarPlanoAPI()
        {
            bool isSandbox = true;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new preApproval request
            PreApprovalRequest preApproval = new PreApprovalRequest();

            // Sets the currency
            preApproval.Currency = Currency.Brl;

            // Sets a reference code for this preApproval request, it is useful to identify this payment in future notifications.
            preApproval.Reference = "REF1234";

            // Sets the preApproval informations
            var now = DateTime.Now;
            preApproval.PreApproval = new PreApproval();
            preApproval.PreApproval.Charge = Charge.Manual;
            preApproval.PreApproval.Name = "Seguro contra roubo do Notebook";
            preApproval.PreApproval.AmountPerPayment = 100.00m;
            preApproval.PreApproval.MaxAmountPerPeriod = 100.00m;
            preApproval.PreApproval.MaxPaymentsPerPeriod = 5;
            preApproval.PreApproval.Details = string.Format("Todo dia {0} será cobrado o valor de {1} referente ao seguro contra roubo do Notebook.", now.Day, preApproval.PreApproval.AmountPerPayment.ToString("C2"));
            preApproval.PreApproval.Period = Period.Monthly;
            preApproval.PreApproval.DayOfMonth = now.Day;
            preApproval.PreApproval.InitialDate = now;
            preApproval.PreApproval.FinalDate = now.AddMonths(6);
            preApproval.PreApproval.MaxTotalAmount = 600.00m;

            // Sets the url used by PagSeguro for redirect user after ends checkout process
            preApproval.RedirectUri = new Uri("http://www.lojamodelo.com.br/retorno");

            // Sets the url used for user review the signature or read the rules
            preApproval.ReviewUri = new Uri("http://www.lojamodelo.com.br/revisao");

            SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), "12345678909");
            preApproval.Sender.Documents.Add(senderCPF);

            try
            {
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

                Uri preApprovalRedirectUri = preApproval.Register(credentials);

                Console.WriteLine("URL do pagamento : " + preApprovalRedirectUri);
                Console.ReadKey();
            }
            catch (PagSeguroServiceException exception)
            {
                Console.WriteLine(exception.Message + "\n");

                foreach (ServiceError element in exception.Errors)
                {
                    Console.WriteLine(element + "\n");
                }
                Console.ReadKey();
            }

            return Json(true);
        }

        [HttpPost]
        public JsonResult AdesaoPlanoAPI()
        {
            bool isSandbox = true;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new payment request
            PaymentRequest payment = new PaymentRequest();

            // Sets the currency
            payment.Currency = Currency.Brl;

            // Add an item for this preApproval payment request
            payment.Items.Add(new Item("0001", "Seguro contra roubo do Notebook", 1, 10.00m));

            // Sets a reference code for this payment request, it is useful to identify this payment in future notifications.
            payment.Reference = "REF1234";
            payment.Sender = new Sender("DAVID FICO", "davidfico22@sandbox.pagseguro.com.br", new Phone("19", "99999999"));

            // Sets the previous preApproval code
            payment.PreApprovalCode = "B533C30AF1F14D2AA4B95FB8759FE0D0";

            try
            {
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
                String result = PreApprovalService.ChargePreApproval(credentials, payment);

                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (PagSeguroServiceException exception)
            {
                Console.WriteLine(exception.Message + "\n");

                foreach (ServiceError element in exception.Errors)
                {
                    Console.WriteLine(element + "\n");
                }
                Console.ReadKey();
            }
            return Json(true);
        }

        [HttpPost]
        public JsonResult FindPlanoAPI()
        {
            bool isSandbox = true;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // TODO: Substitute the code below with a valid preApproval code for your transaction
            String preApprovalCode = "B533C30AF1F14D2AA4B95FB8759FE0D0";

            //try
            //{
            AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

            PreApprovalTransaction result = PreApprovalSearchService.SearchByCode(credentials, preApprovalCode);
            //return Json(result);
            //Console.WriteLine(result);
            //Console.ReadKey();
            //}
            //catch (PagSeguroServiceException exception)
            //{
            //Console.WriteLine(exception.Message + "\n");

            //foreach (ServiceError element in exception.Errors)
            //{
            //Console.WriteLine(element + "\n");
            //}
            //Console.ReadKey();
            //}
            return Json(result);
        }

        [HttpPost]
        public JsonResult CancelAssinatura()
        {
            bool isSandbox = true;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // TODO: Substitute the code below with a valid transaction code for your transaction
            String transactionCode = "B533C30AF1F14D2AA4B95FB8759FE0D0";

            try
            {
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
                bool cancelResult = PreApprovalService.CancelPreApproval(credentials, transactionCode);

                Console.WriteLine(cancelResult);
                Console.ReadKey();
            }
            catch (PagSeguroServiceException exception)
            {
                Console.WriteLine(exception.Message + "\n");

                foreach (ServiceError element in exception.Errors)
                {
                    Console.WriteLine(element + "\n");
                }
                Console.ReadKey();
            }
            return Json(true);
        }

        public ActionResult TermosUso()
        {
            return View();
        }

    }
}