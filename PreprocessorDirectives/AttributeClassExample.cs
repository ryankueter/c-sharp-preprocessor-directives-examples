using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalAttributes
{
    class AttributeClassExample
    {
        void Run()
        {
            Attribute a = Attribute.GetCustomAttribute(
                typeof(Person), typeof(ProgrammerAttribute));

            ProgrammerAttribute p = (ProgrammerAttribute)a;

            Console.WriteLine("Programmer: {0}", p.Programmer);

            Console.ReadKey();
        }

        [AttributeUsage(AttributeTargets.Class)]
        class ProgrammerAttribute : Attribute
        {
            private string programmerValue;

            public ProgrammerAttribute(string programmer)
            {
                programmerValue = programmer;
            }

            public string Programmer
            {
                get
                {
                    return programmerValue;
                }
            }
        }

        [ProgrammerAttribute(programmer: "Fred")]
        class Person
        {
            // This would cause a compilation error as we 
            // are only allowed to apply this attribute to classes
            // [ProgrammerAttribute(programmer: "Fred")]

            public string Name { get; set; }
        }

    }
}
