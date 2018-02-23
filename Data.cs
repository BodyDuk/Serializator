using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    [Serializable]
    class Data
    {
        //клас який відповідає за збереження даних та шляху до них
        public string folder
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }
    }
}
