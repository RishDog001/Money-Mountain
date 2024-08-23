using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMountain
{
    public static class LifelineManager
    {
        public static bool Lifeline1Used { get; set; } = false;
        public static bool Lifeline2Used { get; set; } = false;

        public static void UseLifeline(int lifelineNumber)
        {
            switch (lifelineNumber)
            {
                case 1:
                    Lifeline1Used = true;
                    break;
                case 2:
                    Lifeline2Used = true;
                    break;
            }
        }
    }
}