using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using NLog.Config;
using NLog;
using NLog.Targets;
using NLog.Fluent;
using Newtonsoft.Json;



namespace Transactions
{
    class Program
    {
        public static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Task 3\transactionlog.log", Layout = @"${longdate} ${level}-${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            logger.Log(LogLevel.Info, "Logger started");

            var path = @"C:\Work\Task 3\Transactions2013.json";
            //Read all text into string dataJson
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(path));

            // string readText = File.ReadAllText(path);



            //using (var RDR = new StreamReader(@"C:\Work\Task 3\Transactions2013.json"))
            //{
            //   if (!RDR.EndOfStream)  { RDR.ReadLine(); }             
            //    while (!RDR.EndOfStream)
            //    {
            //        try
            //        {
            //            var splits = RDR.ReadLine().Split(',');
            //            var transaction = new Transaction(splits[0], splits[1], splits[2], splits[3], splits[4]);

            //            transactions.Add(transaction);
            //        }
            //        catch
            //        {
            //            logger.Log(LogLevel.Error, "One of the transactions is dodgy");
            //        }
            //    }
            //}

            Console.WriteLine("Transactions:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine("{0} owes {1} £{2}", transaction.FromAccount, transaction.ToAccount, transaction.Amount);
            }
            Console.ReadLine();
        }
    }
    public class Transaction
    {
        public string Date;
        public string ToAccount;
        public string FromAccount;
        public string Narative;
        public decimal Amount;

        public Transaction(string Date, string To, string From, string Narative, string Amount)
        {
            this.Date = Date;
            this.ToAccount = To;
            this.FromAccount = From;
            this.Narative = Narative;
            this.Amount = decimal.Parse(Amount);
        }
        //public string GetDescription()
        //{
        //    return Date+ " "+ To+" "+ From+ " "+ Narative+" " + Amount;
    }

    public class CustomException
    {
        private string v;
        private List<Transaction> transactions;

        public CustomException(string v)
        {
            this.v = v;
        }

        public CustomException(List<Transaction> transactions)
        {
            this.transactions = transactions;
        }
    }

    public class Csvfile
    {
        public string Date;
        public string To;
        public string From;
        public string Narative;
        public decimal Amount;


        public Csvfile(string Date, string To, string From, string Narative, string Amount)
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