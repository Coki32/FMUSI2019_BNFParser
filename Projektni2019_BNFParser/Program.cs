﻿using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Projektni2019_BNFParser
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] rules = File.ReadLines("./config/config.bnf").ToArray();
            BNFRuleset ruleset = new BNFRuleset(rules);
            string[] tests = File.ReadAllLines("./test/lines.txt");
            StringBuilder sb = new StringBuilder();
            foreach (string test in tests)
            {
                ruleset.Parse(test);
            }
        }
        static void Main2(string[] args)
        {
            string[] rules =
            {
                "<sum> ::= <sum> <pm> <prod> | <prod> ",
                "<pm> ::= regex([+-]) ",
                "<pp> ::= \"*\" | \"/\"",
                "<prod> ::= <prod> <pp> <fact> | <fact>",
                "<fact> ::= \"(\" <sum> \")\" | <num>",
                "<open> ::= \"(\"",
                "<close> ::= \")\"",
                "<num> ::= regex([0-9]+) "
            };
            BNFRuleset ruleset = new BNFRuleset(rules);
            ruleset.Parse("1+(2223*3+4)");
        }
    }
}
