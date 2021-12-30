using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class FPO
    {
        public string room; //Линейная скорость распространения пламени, м/с, 
        public double v; //Линейная скорость распространения пламени, м/с, 
        public double ψF; //Удельная массовая скорость выгорания, кг/м2с,
        public double Q;  // Низшая теплота сгорания материала, МДж/кг, 
        public double Dm; //Дымообразующая способность горящего материала, Нп·м2/кг,
        public double Lo2;//Удельный расход кислорода, кг/кг, 
        public double Lco2;//Выделение СО2 при сгорании 1 кг материала, кг/кг,
        public double Lco;//Выделение СО при сгорании 1 кг материала, кг/кг, 
        public double Lhcl; //Выделение HCL при сгорании 1 кг материала, кг/кг,  


    }
}
