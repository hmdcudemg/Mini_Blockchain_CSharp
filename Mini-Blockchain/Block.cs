using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Mini_Blockchain
{
    class Block
    {
        private DateTime _time_stamp;
        public String _transactions { get; set; }
        public String _previous_hash { get; set; }
        public int _nonce { get; set; }
        public String _hash { get; internal set; }

        public Block(String transactions, String previous_hash)
        {
            _time_stamp = DateTime.Now;
            _transactions = transactions;
            _previous_hash = previous_hash;
            _nonce = 0;
            _hash = GenerateHash();
        }

        public String GenerateHash()
        {
            String block_header = _time_stamp.ToString("dd/MM/yyyy HH:mm:ss.mm") + _transactions.ToString() + _previous_hash.ToString() + _nonce.ToString();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(block_header));

                StringBuilder builder = new StringBuilder();
                foreach (byte val in bytes)
                {
                    builder.Append(val.ToString("X2"));
                }
                return builder.ToString();
            }
        }

        public String Print_Contents()
        {
            String valor = "Timestamp: " + _time_stamp + "\n\rTransactions: " + _transactions.ToString() + "\n\rCurrent Hash: " + _hash + "\n\rPrevious Hash: " + _previous_hash;
            return valor;
        }
    }
}
