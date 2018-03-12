using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Language.FormsAPI5.Model
{
    /// <summary>
    /// Class used to store web form data to be sent to kinesis
    /// </summary>
    /// 
    public class FormDataModel
    {

        public string FormType { get; set; }
        public WebFormSubmissionModel WebFormData { get; set; }

        public PriceQuotationModel PriceQuoteData { get; set; }
    }

    /// <summary>
    /// Data related to webformsubmission is stored here(Data going to webformsubmission)
    /// </summary>
    public class WebFormSubmissionModel
    {
        public WebFormSubmissionModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            NickName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            DateOfBirth = null;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            HouseNumber = string.Empty;
            ApartmentNumber = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
            StateRegionName = string.Empty;
            StateRegionCode = string.Empty;
            CountryCode = string.Empty;
            CitizenshipCode = string.Empty;
            Gender = string.Empty;
            UserSelectedSourceCode = string.Empty;
            Comments = string.Empty;
            CompanyName = string.Empty;
            JobtTitle = string.Empty;
            WantsMoreInfo = string.Empty;
            IsParents = null;
            ParentsFirstName = string.Empty;
            ParentsLastName = string.Empty;
            ParentsEmail = string.Empty;
            ParentsPhoneNo = string.Empty;
            ParentType = ' ';
            IsGroup = null;
            DeliveryPreference = string.Empty;
            YesEmailMarketting = null;
            WantsBrochure = null;
            DivisionCode = string.Empty;
            State = string.Empty;
            Region = string.Empty;


            RouteAddress = string.Empty;
            LongRouteAddress = string.Empty;
            GooglePartialMatch = string.Empty;
            GoogleLocationType = string.Empty;
            Neighborhood = string.Empty;
            SubLocality = string.Empty;

            PhoneType = string.Empty;
            ProductCode = string.Empty;
            ProgramCode = string.Empty;
            EFComMarketCode = string.Empty;
            BrowseCountryCode = string.Empty;
            EnqFormId = string.Empty;
            EnqFormType = string.Empty;
            LanguageCode = string.Empty;
            ActivityFrom = string.Empty;
            IsUnsolicited = false;
            FormType = string.Empty;
            AddressType = string.Empty;
            IsCompleted = null;
            IsEbrochure = null;
            DifferentCountryAddressCode = string.Empty;
            GoogleCountryCode = string.Empty;

            CustomerActivityTypeCode = string.Empty;
            ReferringUrl = string.Empty;
            ExternalReferringUrl = string.Empty;
            Etag = string.Empty;
            RawEtag = string.Empty;
            IsExpressCall = null;
            DeviceType = string.Empty;
            EntrySourceCode = string.Empty;
            Keywords = string.Empty;
            FormUrl = string.Empty;
            PartnerCode = string.Empty;
            TritonID = 0;
            TritonVisitID = 0;
            TritonPageViewID = 0;
            Latitude = 0;
            Longitude = 0;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateRegionName { get; set; }
        public string StateRegionCode { get; set; }
        public string CountryCode { get; set; }
        public string CitizenshipCode { get; set; }
        public string Gender { get; set; }
        public string UserSelectedSourceCode { get; set; }
        public string Comments { get; set; }
        public string CompanyName { get; set; }
        public string JobtTitle { get; set; }
        public string WantsMoreInfo { get; set; }
        public bool? IsParents { get; set; }
        public string ParentsFirstName { get; set; }
        public string ParentsLastName { get; set; }
        public string ParentsEmail { get; set; }
        public string ParentsPhoneNo { get; set; }
        public char ParentType { get; set; }
        public bool? IsGroup { get; set; }
        public string DeliveryPreference { get; set; }
        public bool? YesEmailMarketting { get; set; }
        public bool? WantsBrochure { get; set; }
        public string DivisionCode { get; set; }
        public string State { get; set; }
        public string Region { get; set; }

        #region Address
        public string RouteAddress { get; set; }
        public string LongRouteAddress { get; set; }
        public string GooglePartialMatch { get; set; }
        public string GoogleLocationType { get; set; }
        public string Neighborhood { get; set; }
        public string SubLocality { get; set; }

        #endregion

        #region Internal Data
        public string PhoneType { get; set; }
        public string ProductCode { get; set; }
        public string ProgramCode { get; set; }
        public string EFComMarketCode { get; set; }
        public string BrowseCountryCode { get; set; }
        public string EnqFormId { get; set; }
        public string EnqFormType { get; set; }
        public string LanguageCode { get; set; }
        public string ActivityFrom { get; set; }
        public bool IsUnsolicited { get; set; }
        public string FormType { get; set; }
        public string AddressType { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsEbrochure { get; set; }
        public string DifferentCountryAddressCode { get; set; }
        public string GoogleCountryCode { get; set; }
        #endregion

        #region Tracking
        public string CustomerActivityTypeCode { get; set; }
        public string ReferringUrl { get; set; }
        public string ExternalReferringUrl { get; set; }
        public string Etag { get; set; }
        public string RawEtag { get; set; }
        public bool? IsExpressCall { get; set; }
        public string DeviceType { get; set; }
        public string EntrySourceCode { get; set; }
        public string Keywords { get; set; }
        public string FormUrl { get; set; }
        public string PartnerCode { get; set; }
        public Int64 TritonID { get; set; }
        public Int64 TritonVisitID { get; set; }
        public Int64 TritonPageViewID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        #endregion
    }

    /// <summary>
    /// Data stored in webformpricequote is stored here
    /// </summary>
    public class PriceQuotationModel
    {
        public PriceQuotationModel()
        {
            PQDestinationCode = string.Empty;
            PQCourseCode = string.Empty;
            PQAccommodationCode = string.Empty;
            PQQuoteDuration = string.Empty;
            PQQuoteWhen = string.Empty;

        }
        public string PQDestinationCode { get; set; }
        public string PQCourseCode { get; set; }
        public string PQAccommodationCode { get; set; }
        public string PQQuoteDuration { get; set; }
        public string PQQuoteWhen { get; set; }
    }
}
