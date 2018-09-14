using System;
using System.Collections.Generic;

namespace Mini_Blockchain
{
    class Program
    {
        static String _block_one_transactions = "{\"sender\":\"Alice\", \"receiver\": \"Bob\", \"amount\":\"50\"}";
        static String _block_two_transactions = "{ \"sender\": \"Bob\", \"receiver\":\"Cole\", \"amount\":\"25\" }";
        static String _block_three_transactions = "{ \"sender\":\"Alice\", \"receiver\":\"Cole\", \"amount\":\"35\" }";
        static String _fake_transactions = "{ \"sender\": \"Bob\", \"receiver\":\"Cole, Alice\", \"amount\":\"25\" }";
        static void Main(string[] args)
        {
            Blockchain local_blockchain = new Blockchain();
            //local_blockchain.Print_Blocks();

            local_blockchain.Add_Block(_block_one_transactions);
            local_blockchain.Add_Block(_block_two_transactions);
            local_blockchain.Add_Block(_block_three_transactions);
            local_blockchain.Print_Blocks();

            local_blockchain._chain[2]._transactions = _fake_transactions;
            Console.WriteLine("With the fake transactions");
            local_blockchain.Print_Blocks();
            local_blockchain.Validate_Chain();

            Console.ReadKey();
        }
    }
}
