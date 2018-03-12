using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Language.FormsAPI5.Model
{
    public class KinesisModel
    {
     
            public Guid FormSessionID { get; set; }
            public string TrueProgramCode { get; set; }
            public FormDataModel Fields { get; set; }
        
    }
}
