/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalAttributes
{
    /// <summary>
    /// Tests if an attribute class is attached to a class.
    /// </summary>
    class IsDefinedExample
    {
        void Run()
        {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
                Console.WriteLine("Person can be serialized");

            Console.ReadKey();
        }

        [Serializable]
        public class Person
        {
            public string Name;

            public int Age;

            [NonSerialized]
            // No need to save this
            private int screenPosition;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
                screenPosition = 0;
            }
        }
    }
}
