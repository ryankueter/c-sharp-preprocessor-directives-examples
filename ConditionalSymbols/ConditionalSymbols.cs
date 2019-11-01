/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System;
using System.Diagnostics;

//#define DIAGNOSTICS
//#undef DEBUG
namespace ConditionalSymbols
{
    /// <summary>
    /// Contain commands that are preprocessor directives and are preceded by #.
    /// 
    /// Can be defined in the assembly’s properties under "Build" and under General.
    /// Are symbols that you can use that specify whether a block of code should compile.
    /// #undef DEBUG can be used to undefine a constant.
    /// 
    /// With System.Diagnostics, the Conditional Attribute can be used if the symbol is defined. The following will run the display method, but only if the #undef is commented out.
    /// 
    /// Symbol file is the debug database that contains debug symbols for the application.
    /// Symbol Server provides debug database information for an application in place of a local file.TFS can store.pdb files.
    /// pdbcopy can be used to edit the .pdb file. You can include a list of symbols to remove.
    /// </summary>
    /// 
    class ConditionalSymbols
    {
        public void Run()
        {
            Robot.DebugMode = true;

            var m = new Robot(name: "Robby");
            Console.ReadKey();
        }

        [Conditional("DEBUG")]
        static void DebugMessage(string message)
        {
            Console.WriteLine(message);

        }

        [Obsolete("This method is obsolete.Call NewMethod instead.", false)]
        public void ObsoleteExample()
        {

        }

        /// <summary>
        /// #warning This version of the library is no longer maintained. 
        /// #pragma can be used to disable warning for a block of code:
        /// #pragma warning disable
        /// #pragma warning restore
        /// You can also disable specific warnings:
        /// #pragma warning disable CS1998
        /// #line 1 can be set to report the line number.
        /// #line can be used to hide blocks of code:
        /// #line hidden
        /// #line default
        /// </summary>
        public void Error()
        {

        }

        /// <summary>
        /// [DebuggerStepThrough] attribute can be applied to a class or method to have the debugger skip that method.
        /// </summary>
        [DebuggerStepThrough]
        public void SkipMethod()
        {

        }

        public class Robot
        {
            public static bool DebugMode = false;
            public string Name { get; set; }
            public Robot(string name)
            {
                Name = name;
#if DIAGNOSTICS && DEBUG
                Console.WriteLine("Diagnostics and debugging is enabled.");
#else
                Console.WriteLine("Diagnostics and debugging is not enabled.");
#endif
            }
        }
    }
}
