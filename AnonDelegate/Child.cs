using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonDelegate
{
    class Child
    {
        //The instance variable, containing a reference to the SayingHandler deletage
        private SayingHandler sayingHandlers;



        //event version
        //RegisterSaying / UnRegisterSaying are not needed if we use the event keyword
        //public event SayingHandler sayingHandlers2;

        private string m_name = "";

        /// <summary>
        /// The constructor takes a SayingHandler (The Parent Listening method)
        /// And registeres it, using the short hand notation (+=, instead of combine)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sh"></param>
        public Child(string name, SayingHandler sh)
        {
            
            //System.MulticastDelegate  //the superclass of a custom Delegate
            this.m_name = name;
            sayingHandlers += sh;            
            //sayingHandlers = (SayingHandler) Delegate.Combine(sayingHandlers, sh);
        }

        public Child(string name)
        {
            this.m_name = name;            
        }

        /// <summary>
        ///This method invokes the registered methods of the SayingHandler 
        ///The ?.Invoke is a short hand notation for != null (Actually Invoke is only necessary when using the short hand notation)
        /// </summary>
        public void childDoes()
        {
            //Console.WriteLine("child "+this.m_name + " is saying something" );
            //if (sayingHandlers != null)
            //{
            //    //sayingHandlers(this.m_name + ": I am sleeping");
            //    sayingHandlers.Invoke(this.m_name + ": I am sleeping");
            //}
            sayingHandlers?.Invoke(this.m_name + " I am sleeping");

            //event version
            //sayingHandlers2?.Invoke("Yes it works");
        }

        public void RegisterSaying(SayingHandler sh) {
            sayingHandlers += sh;
            //sayingHandlers = (SayingHandler)Delegate.Combine(sayingHandlers, sh);

            //sayingHandlers.GetInvocationList
        }

        public void UnRegisterSaying(SayingHandler sh)
        {
            sayingHandlers -= sh;
            //sayingHandlers = (SayingHandler)Delegate.Remove(sayingHandlers, sh);
        }

        /// <summary>
        /// This method is used for the generic delegate example
        /// </summary>
        /// <param name="mes1"></param>
        /// <param name="mes2"></param>
        public void SayingAndJumping(string mes1, string mes2)
        {
            Console.WriteLine(this.m_name + ", mes1:"+mes1+" - mes2:"+mes2);
        }
    }
}
