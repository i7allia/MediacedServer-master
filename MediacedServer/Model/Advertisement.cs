using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediacedServer.Model
{
    public class Advertisement
    {
        public int id { get; set; }
        public String name { get; set; }
        
        public String phoneNumber { get; set; }
        public String email { get; set; }
        
        public float salaryusd { get; set; }
        public float courseOfUSD { get; set; }
        public float salarybyn { get; set; }


        public Advertisement(int id, String name, 
            String phoneNumber, String email, float salaryusd,
            float courseOfUSD, float salarybyn)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.salaryusd = salaryusd;
            this.courseOfUSD = courseOfUSD;
            this.salarybyn = salarybyn;
        }

        public Advertisement()
        {
            this.id = 0;
            this.name = "";
            this.phoneNumber = "";
            this.email = "";
            this.salaryusd = 0.0f;
            this.courseOfUSD = 0.0f;
            this.salarybyn = 0.0f;
        }

    }
}
