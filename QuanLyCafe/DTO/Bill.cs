using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime dateCheckIn, DateTime dateCheckOut, int status, int discount)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.Id = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            var dataCheckOutTmp = row["dateCheckOut"];
            if (dataCheckOutTmp.ToString() != "") 
                this.DateCheckOut = (DateTime?)row["dateCheckOut"];
            this.Status = (int)row["status"];
            this.Discount = (int)row["discount"];
        }

        private int status;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int id;
        private int discount;

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
