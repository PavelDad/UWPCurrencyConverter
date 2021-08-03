using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPCurrency_Converter.Model
{
    /// <summary>
    /// Класс для хранения списка валют
    /// </summary>
    [Serializable]
    public class Valute
    {
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
