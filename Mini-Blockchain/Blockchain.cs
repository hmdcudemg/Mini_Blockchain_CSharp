using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_Blockchain
{
    class Blockchain
    {
        public List<Block> _chain;
        private String _unconfirmed_transactions;

        public Blockchain()
        {
            _chain = new List<Block>();
            _unconfirmed_transactions = "{}";
            Genesis_Block();
        }

        public void Genesis_Block()
        {
            String transactions = "{}";
            Block genesis_block = new Block(transactions, "0");
            _chain.Add(genesis_block);
        }

        public (String, Block) Add_Block(String transactions)
        {
            string previous_hash = (_chain[_chain.Count - 1])._hash;
            Block new_block = new Block(transactions, previous_hash);
            //String proof = Proof_of_Work(new_block);
            _chain.Add(new_block);
            return ("", new_block);
        }

        public void Print_Blocks()
        {
            for (int i = 0; i < _chain.Count; i++)
            {
                Block current_block = _chain[i];
                Console.WriteLine("Block {0} {1}", i, current_block.ToString());
                Console.WriteLine(current_block.Print_Contents() + "\n\r");
            }
        }

        public bool Validate_Chain()
        {
            for (int i = 1; i <= _chain.Count; i++)
            {
                Block current = _chain[i];
                Block previous = _chain[i - 1];
                if (current._hash != current.GenerateHash())
                {
                    Console.WriteLine("The current hash of the block does not equal the generated hash of the block.");
                    return false;
                }
                if (current._previous_hash != previous.GenerateHash())
                {
                    Console.WriteLine("The previous block's hash does not equal the previous hash value stored in the current block.");
                    return false;
                }
            }
            return true;
        }

        public String Proof_of_Work(Block block, int difficulty = 2)
        {
            String proof = block.GenerateHash();
            while (proof[difficulty] != '0' * difficulty)
            {
                block._nonce += 1;
                proof = block.GenerateHash();
                Console.WriteLine(proof);
            }
            block._nonce = 0;
            return proof;
        }
    }
}
