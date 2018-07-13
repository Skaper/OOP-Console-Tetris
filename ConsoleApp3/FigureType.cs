using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class FigureType
    {
        public static readonly string L1 = "¤n¤n¤¤";
        public static readonly string L2 = "¤¤¤n¤";
        public static readonly string L3 = "¤¤n ¤n ¤";
        public static readonly string L4 = "  ¤n¤¤¤";
        public static readonly string J1 = " ¤n ¤n¤¤";
        public static readonly string J2 = "¤  n¤¤¤";
        public static readonly string J3 = "¤¤n¤n¤";
        public static readonly string J4 = "¤¤¤n  ¤";
        public static readonly string O = "¤¤n¤¤";
        public static readonly string I1 = "¤n¤n¤n¤";
        public static readonly string I2 = "¤¤¤¤";
        public static readonly string S1 = " ¤¤n¤¤ ";
        public static readonly string S2 = "¤n¤¤n ¤";
        public static readonly string S3 = " ¤¤n¤¤";
        public static readonly string S4 = "¤n¤¤n ¤";
        public static readonly string Z1 = "¤¤n ¤¤";
        public static readonly string Z2 = " ¤n¤¤n¤";
        public static readonly string Z3 = "¤¤ n ¤¤";
        public static readonly string Z4 = " ¤n¤¤n¤ ";
        public static readonly string T1 = " ¤n¤¤¤";
        public static readonly string T2 = "¤n¤¤n¤";
        public static readonly string T3 = "¤¤¤n ¤";
        public static readonly string T4 = " ¤n¤¤n ¤";
        public static readonly List<string> FUGURES_L = new List<string>() { L1, L2, L3, L4 };
        public static readonly List<string> FUGURES_J = new List<string>() { J1, J2, J3, J4 };
        public static readonly List<string> FUGURES_O = new List<string>() { O };
        public static readonly List<string> FUGURES_I = new List<string>() { I1, I2 };
        public static readonly List<string> FUGURES_S = new List<string>() { S1, S2, S3, S4 };
        public static readonly List<string> FUGURES_Z = new List<string>() { Z1, Z2, Z3, Z4 };
        public static readonly List<string> FUGURES_T = new List<string>() { T1, T2, T3, T4 };

    }
    class FiguresList
    {
        private int index = 0;
        private List<String> listString;
        private List<FiguresList> listFigures;


        public FiguresList()
        {
            listFigures = new List<FiguresList>() {
                new FiguresList(FigureType.FUGURES_L),
                new FiguresList(FigureType.FUGURES_J),
                new FiguresList(FigureType.FUGURES_O),
                new FiguresList(FigureType.FUGURES_I),
                new FiguresList(FigureType.FUGURES_S),
                new FiguresList(FigureType.FUGURES_Z),
                new FiguresList(FigureType.FUGURES_T)};
        }
        public List<FiguresList> GetList()
        {
            return listFigures;
        }

        public FiguresList(List<string> list)
        {
            this.listString = list;
        }

        public string First()
        {
            return listString[0];
        }

        public string Rotate()
        {
            if (index + 1 < listString.Count)
            {
                index += 1;
                return listString[index];
            }
            else
            {
                index = 0;
                return listString[0];
            }
            
        }
        public void CancelRotate()
        {
            index -= 1;
            if(index < 0)
            {
                index = listString.Count-1;
            }
        }
       
    }
}
