using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Corporate_University
{
    public class Participants
    {
        public int _EmpId;
        public static string Company_Name;
        private int Fmarks;
        private int Webmarks;
        private int dotnetmarks;
        public int _FoundationMarks
        {
            set
            {
                if(value> 100)
                {
                    Fmarks = 0;
                }
                else if (value < 0)
                {
                    Fmarks = 0;
                }
                else
                {
                    Fmarks = value;
                }
            }
            get
            {
                return Fmarks;
            }
        }
        public int _WebBasicMarks
        {
            set
            {
                if (value > 100)
                {
                    Webmarks = 0;
                }
                else if (value < 0)
                {
                    Webmarks = 0;
                }
                else
                {
                    Webmarks = value;
                }
            }
            get
            {
                return Webmarks;
            }
        }
        public int _DotNetMarks
        {
            set
            {
                if (value > 100)
                {
                    dotnetmarks = 0;
                }
                else if (value < 0)
                {
                    dotnetmarks = 0;
                }
                else
                {
                    dotnetmarks = value;
                }
            }
            get
            {
                return dotnetmarks;
            }
        }

        private int Total_Marks = 300;
        private int _Percentage;

        public Participants()
        {

        }
       /* public Participants(int empId, int foundationMarks, int webBasicMarks, int dotNetMarks)
        {
            *//*this._EmpId = empId;
            this._FoundationMarks = foundationMarks > 100 ? 0 : foundationMarks;
            this._WebBasicMarks= webBasicMarks> 100 ? 0: webBasicMarks;
            this._DotNetMarks= dotNetMarks > 100 ? 0 : dotNetMarks ;
            this._ObtainedMarks = _FoundationMarks + _WebBasicMarks + _DotNetMarks;*//*
        }*/

        static Participants()
        {
            Company_Name = "Corporate University";
        }

        /*public void ObtainedMarks()
        {
            this._ObtainedMarks = _FoundationMarks + _WebBasicMarks + _DotNetMarks;
        }*/
        public float Percentage()
        {
            this._Percentage = (_FoundationMarks + _WebBasicMarks + _DotNetMarks) / 3;
            return this._Percentage; 
        }
        public int TotalMarks()
        {
            return _FoundationMarks + _WebBasicMarks + _DotNetMarks;
        }
           
         
    }
}
