using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;



namespace Transactions
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                // Transactions transaction1 = new Transactions();
                //Transactions transaction2 = new Transactions();
                //Transactions transaction3 = new Transactions();
                //Transactions transaction4 = new Transactions();
                //Transactions transaction5 = new Transactions();
                //Console.WriteLine(transaction1.GetDescription());
                //Console.WriteLine(transaction2.GetDescription());
                //Console.WriteLine(transaction3);
                // Console.ReadLine();

                // List<string> myList = new List<string>();
                //List<decimal> mylist = new List<decimal>();

                // Console.WriteLine(myList.Aggregate((a, n) => a + "," + n));
                // Console.ReadLine();

            }       
            {
                List<Transaction> transactions = new List<Transaction>();
                

                using (var RD = new StreamReader(@"C:\Work\Task 3\Transactions2014.csv"))
                {
                    RD.ReadLine();
                    while (!RD.EndOfStream)
                    {
                        var splits = RD.ReadLine().Split(',');
                        var transaction = new Transaction(splits[0], splits[1], splits[2], splits[3], splits[4]);

                        transactions.Add(transaction);

                    }
                    {
                        
                    }
                }

                Console.WriteLine("Transactions:");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine("{0} owes {1} £{2}", transaction.From, transaction.To, transaction.Amount);
                }

                Console.ReadLine();
            }
           
        }
    }
    class Transaction
    {
        public string Date;
        public string To;
        public string From;
        public string Narative;
        public decimal Amount;

        public Transaction()
        {
            //Date = splits[1] ;
            //To = ;
            //From = ;
            //Narative = ;
            //Amount = 9.5M;
        }
        public Transaction(string Date, string To, string From, string Narative, string Amount)
        {
            this.Date = Date;
            this.To = To;
            this.From = From;
            this.Narative = Narative;
            this.Amount = decimal.Parse(Amount);
        }
        //public string GetDescription()
        //{
        //    return Date+ " "+ To+" "+ From+ " "+ Narative+" " + Amount;
        }

       
    }
    


