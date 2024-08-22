using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonDelegate
{
    //Definition of the delegate
    //It is not part of the class Parent, but it is in the namespace 
    public delegate void SayingHandler(string sound);

    class Parent
    {
        private string m_gender = "";

        public Parent(string gender)
        {
            m_gender = gender;
            
        }

        /// <summary>
        /// Public method, that has the same signature as the delegate
        /// This is the method that we will register on the delegate instance variable
        /// The instance variable is in the Child class 
        /// </summary>
        /// <param name="sound"></param>
        public void Listening(string sound)
        {
            Console.WriteLine(this.m_gender +" Parent hears "+sound);
        }

    }
}
