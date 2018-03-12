using System;

namespace EF.Language.FormsAPI5.Controllers.Model
{
    /// <summary>
    /// Input model for true program code service
    /// </summary>
    public class TrueProgramModel
    {
        public string ProgramCode { get; set; }
        public string MarketCode { get; set; }
        public string CountryCode { get; set; }
        public string EntrySourceCode { get; set; }
        public DateTime DateOfBirth{ get; set; }

    }
}