using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using EF.Language.FormsAPI5.Controllers.Model;
using EFTrueProgramCodeService;
using Microsoft.AspNetCore.Mvc;


namespace EF.Language.FormsAPI5.Controllers
{
    /// <summary>
    /// A class used to return true program code from the poseidon WCF service
    /// </summary>
    /// 
    [Route("TrueProgram")]
    [Produces("application/json")]
    public class TrueProgramController : Controller
    {
        [Route("GetTrueProgramCode"),HttpPost]
        public async Task<string> GetTrueProgramCode([FromBody]TrueProgramModel formModel)
        {
            EFPosProgramConversionServiceClient programSvcClient = new EFPosProgramConversionServiceClient();
            string program = "";
            try
            {


                WebFormSubmission wfs = new WebFormSubmission
                {
                    ProgramCode = formModel.ProgramCode,
                    EfComMarketCode = formModel.MarketCode,
                    CountryCode = formModel.CountryCode,
                    EntrySourceCode = formModel.EntrySourceCode

                };

                if (formModel.DateOfBirth != null)
                    wfs.DateOfBirth = (DateTime)formModel.DateOfBirth;
                else
                    wfs.DateOfBirth = DateTime.MinValue;



                if (programSvcClient.State != CommunicationState.Opened)
                    await programSvcClient.OpenAsync();

                program = await programSvcClient.GetPosProgramCodeAsync(wfs);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                try
                {
                    if (programSvcClient.State != CommunicationState.Faulted)
                        await programSvcClient.CloseAsync();
                    else
                        programSvcClient.Abort();
                }
                catch
                {
                    programSvcClient.Abort();
                }
            }
            return program;
        }

       
    }
}