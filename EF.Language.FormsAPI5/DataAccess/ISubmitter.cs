using EF.Language.FormsAPI5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Language.FormsAPI5.DataAccess
{
    /// <summary>
    /// The interface configured on the startup file to save Form data(Dot Net Core)
    /// </summary>
    public interface IFormSubmitter
    {
        string SubmitTester();
        string SubmitBrochure(KinesisModel model);
    }
}
