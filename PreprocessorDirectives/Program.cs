/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System;
using System.Diagnostics;

//#define TERSE
//#define VERBOSE
namespace ConditionalAttributes
{
    /// <summary>
    /// Preprocessor directives that determines whether the code is run when the method is called. 
    /// It will still pass the method to the compiler, but will not execute the code:
    /// </summary>
    class Program
    {
        [Conditional("VERBOSE"), Conditional("TERSE")]
        static void VerbosTerse()
        {
            Console.WriteLine("Is written if verbose or terse is specified.");
        }

        [Conditional("VERBOSE")]
        static void Verbose()
        {
            Console.WriteLine("Is written if verbose is specified.");
        }

        [Conditional("TERSE")]
        static void Terse()
        {
            Console.WriteLine("Is written if terse is specified.");
        }
        static void Main(string[] args)
        {
            VerbosTerse();
            Terse();
            Verbose();
            Console.ReadKey();
        }
    }
}
