﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAG.Model
{
    public class Customer
    {
        public Customer()
        {
            BrokerageAccounts = new HashSet<BrokerageAccount>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(2)]
        public string State { get; set; }
        public int Zip { get; set; }
        [StringLength(10)]
        public string CustomerCode { get; set; }
        public string NewPropertyAdded { get; set; }

        public  ICollection<BrokerageAccount> BrokerageAccounts { get; set; }


    }
}
