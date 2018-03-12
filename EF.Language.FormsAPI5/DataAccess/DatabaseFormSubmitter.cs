using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using EF.Language.FormsAPI5.Model;
using Microsoft.Extensions.Configuration;

namespace EF.Language.FormsAPI5.DataAccess
{
    public class DatabaseFormSubmitter: IFormSubmitter
    {
        private IConfiguration _configuration;


        /// <summary>
        /// Reading data from configuration
        /// </summary>
        /// <param name="configuration"></param>
        public DatabaseFormSubmitter(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Tester method
        /// </summary>
        /// <returns></returns>
        public string SubmitTester()
        {
            return Convert.ToString(_configuration.GetValue(typeof(string), "HelloMessage"));
        }

        /// <summary>
        /// Method to submit brochure
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string SubmitBrochure(KinesisModel model)
        {

            string FormID;
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("FormsAPIConnection"));
            SqlCommand command = new SqlCommand("WebForm_SubmitBrochure");


            try
            {
                command.Parameters.AddWithValue("@productCode", model.Fields.WebFormData.ProductCode);
                command.Parameters.AddWithValue("@programCode", model.Fields.WebFormData.ProgramCode);
                command.Parameters.AddWithValue("@secondaryProductCode", string.Empty);
                command.Parameters.AddWithValue("@secondaryProgramCode", string.Empty);
                command.Parameters.AddWithValue("@eFComMarketCode", model.Fields.WebFormData.EFComMarketCode);
                command.Parameters.AddWithValue("@BrowseCountryCode", model.Fields.WebFormData.BrowseCountryCode);
                command.Parameters.AddWithValue("@firstName", model.Fields.WebFormData.FirstName);
                command.Parameters.AddWithValue("@lastName", model.Fields.WebFormData.LastName);
                command.Parameters.AddWithValue("@nickName", model.Fields.WebFormData.NickName);
                command.Parameters.AddWithValue("@email", model.Fields.WebFormData.Email);
                command.Parameters.AddWithValue("@mobileEmail", string.Empty);

                if (model.Fields.WebFormData.PhoneType=="MP")
                {
                    command.Parameters.AddWithValue("@homePhone", string.Empty);
                    command.Parameters.AddWithValue("@mobilePhone", model.Fields.WebFormData.PhoneNumber);
                }
                else
                {
                    command.Parameters.AddWithValue("@homePhone", model.Fields.WebFormData.PhoneNumber);
                    command.Parameters.AddWithValue("@mobilePhone", string.Empty);
                }

                if (model.Fields.WebFormData.DateOfBirth !=null )
                {
                    command.Parameters.AddWithValue("@dateOfBirth", model.Fields.WebFormData.DateOfBirth);
                }
                else
                {
                    command.Parameters.AddWithValue("@dateOfBirth", DBNull.Value);
                }
                

                command.Parameters.AddWithValue("@addressLine1", model.Fields.WebFormData.AddressLine1??string.Empty);
                command.Parameters.AddWithValue("@addressLine2", model.Fields.WebFormData.AddressLine2);
                command.Parameters.AddWithValue("@addressLine3", model.Fields.WebFormData.AddressLine3);
                command.Parameters.AddWithValue("@postalCode", model.Fields.WebFormData.PostalCode);
                command.Parameters.AddWithValue("@city", model.Fields.WebFormData.City);
                command.Parameters.AddWithValue("@stateRegionName", model.Fields.WebFormData.StateRegionName);
                command.Parameters.AddWithValue("@stateRegionCode", model.Fields.WebFormData.StateRegionCode);
                command.Parameters.AddWithValue("@countryCode", model.Fields.WebFormData.CountryCode);
                command.Parameters.AddWithValue("@citizenshipCode", model.Fields.WebFormData.CitizenshipCode);
                command.Parameters.AddWithValue("@gender", model.Fields.WebFormData.Gender);
                command.Parameters.AddWithValue("@comments", model.Fields.WebFormData.Comments);
                command.Parameters.AddWithValue("@userSelectedSourceCode", model.Fields.WebFormData.UserSelectedSourceCode);
                command.Parameters.AddWithValue("@wantsMoreInfo", model.Fields.WebFormData.WantsMoreInfo);
                command.Parameters.AddWithValue("@wantsBrochure", model.Fields.WebFormData.WantsBrochure??false);
                command.Parameters.AddWithValue("@agents", string.Empty);
                command.Parameters.AddWithValue("@isParent", model.Fields.WebFormData.IsParents??false);
                command.Parameters.AddWithValue("@parentFirstName", model.Fields.WebFormData.ParentsFirstName);
                command.Parameters.AddWithValue("@parentLastName", model.Fields.WebFormData.ParentsLastName);
                command.Parameters.AddWithValue("@parentEmail", model.Fields.WebFormData.ParentsEmail);
                command.Parameters.AddWithValue("@parentPhone", model.Fields.WebFormData.ParentsPhoneNo);
                command.Parameters.AddWithValue("@ParentType", model.Fields.WebFormData.ParentType);
                command.Parameters.AddWithValue("@companyName", model.Fields.WebFormData.CompanyName);
                command.Parameters.AddWithValue("@enqFormId", model.Fields.WebFormData.EnqFormId);
                command.Parameters.AddWithValue("@enqFormType", model.Fields.WebFormData.EnqFormType);
                command.Parameters.AddWithValue("@partnerCode", model.Fields.WebFormData.PartnerCode);
                command.Parameters.AddWithValue("@eTag", model.Fields.WebFormData.Etag);
                command.Parameters.AddWithValue("@rawEtag", model.Fields.WebFormData.RawEtag);
                command.Parameters.AddWithValue("@keywords", model.Fields.WebFormData.Keywords);
                command.Parameters.AddWithValue("@referringUrl", model.Fields.WebFormData.ReferringUrl);
                command.Parameters.AddWithValue("@triton_id", model.Fields.WebFormData.TritonID);
                command.Parameters.AddWithValue("@formUrl", model.Fields.WebFormData.FormUrl);
                command.Parameters.AddWithValue("@entrySourceCode", model.Fields.WebFormData.EntrySourceCode);
                command.Parameters.AddWithValue("@visitId", Guid.Empty);
                command.Parameters.AddWithValue("@externalReferringUrl", model.Fields.WebFormData.ExternalReferringUrl);
                command.Parameters.AddWithValue("@entryPage", DBNull.Value);
                command.Parameters.AddWithValue("@divisionCode", model.Fields.WebFormData.DivisionCode);
                command.Parameters.AddWithValue("@customerActivityTypeCode", model.Fields.WebFormData.CustomerActivityTypeCode);
                command.Parameters.AddWithValue("@activityFrom", model.Fields.WebFormData.ActivityFrom);
                command.Parameters.AddWithValue("@isUnsolicited", model.Fields.WebFormData.IsUnsolicited);

                command.Parameters.AddWithValue("@postData", DBNull.Value);
                command.Parameters.AddWithValue("@state", model.Fields.WebFormData.State);
                command.Parameters.AddWithValue("@region", model.Fields.WebFormData.Region);
                command.Parameters.AddWithValue("@campaignName", DBNull.Value);
                command.Parameters.AddWithValue("@campaignQuestionAnswer", DBNull.Value);
                if (string.Equals(model.Fields.WebFormData.DeliveryPreference,"EB",StringComparison.InvariantCultureIgnoreCase))
                {
                    command.Parameters.AddWithValue("@isEBrochure", true);
                }
                else
                {
                    command.Parameters.AddWithValue("@isEBrochure", false);
                }
                
                command.Parameters.AddWithValue("@tmq", DBNull.Value);


                command.Parameters.AddWithValue("@formCaptureId", DBNull.Value);
                command.Parameters.AddWithValue("@IsCompleted", model.Fields.WebFormData.IsCompleted);
                command.Parameters.AddWithValue("@latitude", model.Fields.WebFormData.Latitude);
                command.Parameters.AddWithValue("@longitude", model.Fields.WebFormData.Longitude);
                command.Parameters.AddWithValue("@googlePartialMatch", model.Fields.WebFormData.GooglePartialMatch);
                command.Parameters.AddWithValue("@googleLocationType", model.Fields.WebFormData.GoogleLocationType);
                command.Parameters.AddWithValue("@languageCode", model.Fields.WebFormData.LanguageCode);
                command.Parameters.AddWithValue("@isMobileDevice", DBNull.Value);
                command.Parameters.AddWithValue("@jobTitle", model.Fields.WebFormData.JobtTitle);
                command.Parameters.AddWithValue("@tritonVisitID", model.Fields.WebFormData.TritonVisitID);
                command.Parameters.AddWithValue("@representative_id", DBNull.Value);
                command.Parameters.AddWithValue("@representativeMarket_id", DBNull.Value);
                command.Parameters.AddWithValue("@DeviceType", model.Fields.WebFormData.DeviceType);
                command.Parameters.AddWithValue("@PreferredOffice", DBNull.Value);
                command.Parameters.AddWithValue("@isGroup", model.Fields.WebFormData.IsGroup);
                command.Parameters.AddWithValue("@PageViewID", model.Fields.WebFormData.TritonPageViewID);

                command.Parameters.AddWithValue("@WeChatID", DBNull.Value);
                command.Parameters.AddWithValue("@WeChatUnionID", DBNull.Value);
                command.Parameters.AddWithValue("@CampaignAllocationCode", DBNull.Value);
                command.Parameters.AddWithValue("@CampaignAllocationPrograms", DBNull.Value);
                var outParameter= new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                outParameter.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(outParameter);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                
                command.Connection = sqlConnection;
                sqlConnection.Open();
                command.ExecuteScalar();

                FormID = Convert.ToString(command.Parameters["@ReturnValue"].Value);



            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

            return FormID;
        }





       
    }
}
    