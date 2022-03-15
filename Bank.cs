using System;

namespace Heist
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGaurdScore { get; set; }
        public bool IsSecure
        {
            get
            {
                if (AlarmScore > 0 || VaultScore > 0 || SecurityGaurdScore > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}