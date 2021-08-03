using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPCurrency_Converter.Model
{
    /// <summary>
    /// Класс для сериализации JSON данных с сервера
    /// </summary>
    [Serializable]
    public class DataSerialize
    {
        public Dictionary<string, Valute> Valute { get; set; }
    }
}
