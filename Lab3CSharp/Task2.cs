using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    using System;
    using System.Collections.Generic;

    public class Document
    {
        protected string documentNumber;
        protected DateTime date;
        protected decimal amount;

        public Document(string documentNumber, DateTime date, decimal amount)
        {
            this.documentNumber = documentNumber;
            this.date = date;
            this.amount = amount;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Document Number: {documentNumber}");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Amount: {amount:C}");
        }
    }

    // Клас рахунок
    public class Invoice : Document
    {
        private string seller;
        private string buyer;
        private string description;

        public Invoice(
            string documentNumber,
            DateTime date,
            decimal amount,
            string seller,
            string buyer,
            string description
        )
            : base(documentNumber, date, amount)
        {
            this.seller = seller;
            this.buyer = buyer;
            this.description = description;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Seller: {seller}");
            Console.WriteLine($"Buyer: {buyer}");
            Console.WriteLine($"Description: {description}");
        }
    }

    public class Receipt : Document
    {
        private string payer;

        public Receipt(string documentNumber, DateTime date, decimal amount, string payer)
            : base(documentNumber, date, amount)
        {
            this.payer = payer;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Payer: {payer}");
        }
    }

    // Клас накладна
    public class Waybill : Document
    {
        private string sender;
        private string receiver;
        private List<string> goods;

        public Waybill(
            string documentNumber,
            DateTime date,
            decimal amount,
            string sender,
            string receiver,
            List<string> goods
        )
            : base(documentNumber, date, amount)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.goods = goods;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Sender: {sender}");
            Console.WriteLine($"Receiver: {receiver}");
            Console.WriteLine("Goods:");
            foreach (var item in goods)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
