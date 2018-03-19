using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EF.Language.FormsAPI5.DataAccess;
using EF.Language.AWS.Kinesis.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EF.Language.FormsAPI5.Controllers
{
    [Produces("application/json")]
    [Route("FormSubmitter")]
    public class FormSubmitterController : Controller
    {
        private IFormSubmitter _formsubmitter { get; set; }


        /// <summary>
        /// Dependency injection to pass the type of submitter to use(.Net Core feature)
        /// </summary>
        /// <param name="formSubmitter"></param>
        public FormSubmitterController(IFormSubmitter formSubmitter)
        {
            _formsubmitter = formSubmitter;
        }

        [Route("SubmitFormGet"),HttpGet]
        public string SubmitFormGet()
        {
            return _formsubmitter.SubmitTester();
        }

        /// <summary>
        /// A generic method to be called to save form data to 
        /// WFS
        /// </summary>
        /// <param name="formdata">JSON formatted form data</param>
        /// <returns></returns>
        [Route("SubmitFormPost"),HttpPost]
        public string SubmitFormPost([FromBody]JObject formdata)
        {
            try
            {


                KinesisFormDataModel formModel = Newtonsoft.Json.JsonConvert.DeserializeObject<KinesisFormDataModel>(formdata.ToString());
                System.IO.File.AppendAllText("Log.log", string.Format("Form enter - {0}", formModel.SessionId.ToString()));
                return _formsubmitter.SubmitBrochure(formModel);


            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Error.log", ex.Message);
                return ex.Message + " - "+ ex.StackTrace ;
            }

           
           
        }

    }
}