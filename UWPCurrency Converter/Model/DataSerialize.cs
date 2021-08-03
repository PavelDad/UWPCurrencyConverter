using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPCurrency_Converter.Model
{
    [Serializable]
    public class DataSerialize
    {
        public Dictionary<string, Valute> Valute { get; set; }
    }
}
