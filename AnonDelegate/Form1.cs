using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonDelegate
{
    public partial class Form1 : Form
    {
        private string test;

        public Form1()
        {
            InitializeComponent();

            //anonymous eventhandler
            this.btnAnon.Click += delegate (Object sender, EventArgs e)
            {
                MessageBox.Show(((Button)sender).Name + " does stuff");
            };

            //anonymous eventhandler lambda version
            this.btnLambda.Click += (sender, e) => MessageBox.Show("Do stuff");
        }   


        Parent dad = null;
        Parent mom = null;
        /// <summary>
        /// Create parents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Create Parent instances
            dad = new Parent("male");
            mom = new Parent("female");
        }

        Child child1 = null;
        Child child2 = null;
        Child child3 = null;



        public string Test1
        {
            get
            {
                return test;
            }

            set
            {
                test = value;
            }
        }

        /// <summary>
        /// Create children
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            //Create Child isntances and register methods
            child1 = new Child("Luke", dad.Listening);
            child2 = new Child("Chewbacca", dad.Listening);
            child3 = new Child("Lando", dad.Listening);
            child3.RegisterSaying(mom.Listening);
            //child2.sayingHandlers += mom.Listening;   //cant do this, the instance is private

            //event version
            //child1.sayingHandlers2 += mom.Listening;

        }

        /// <summary>
        /// Make child say
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //Call the method childDoes, this method then invokes the registered methods
            child1.childDoes();
            child2.childDoes();
            child3.childDoes();
        }

        /// <summary>
        /// Example of nameless / anonymous method registration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //Notice the method keeps its scope and can access local variables when invoked
            string secretMessage = "Only I know, because I am a local variable";

            child2?.RegisterSaying(delegate (string message) {
                Console.WriteLine("Secret message is: '" + secretMessage + "' ,childmessage is: " + message);
            });

            //event version
            //short hand registration of nameless / anonymous method
            //child3.sayingHandlers2 += delegate (string newMessage)
            //{
            //    Console.WriteLine("A more known syntax: " + newMessage);
            //};

        }

        #region --------------------- Generic delegates -----------------------------------
        

        /// <summary>
        /// Generic delegate example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //action is void
            //Funct returns a value
            Action<string, string> strangeDelegate = new Action<string, string>(child1.SayingAndJumping);            

            strangeDelegate += child2.SayingAndJumping;
            strangeDelegate("hard to read", " Or so I think");          
            
        }


        private void Button8_Click(object sender, EventArgs e)
        {
            //action is void
            //Funct returns a value

            Func<int, string> strangeDelegateWInt = new Func<int, string>(this.gen);
            Console.WriteLine(strangeDelegateWInt(20));
        }

        public string gen(int it) {
            return "The int is: " + it;
        }

        #endregion

        #region --------------------- The magical all knowing oracle -----------------------------------


        private delegate void answerDel(string person);
        TheOracle theOracle = null;

        private void button6_Click(object sender, EventArgs e)
        {
            string IAmThink = "When will the sun shine again!!";//Local variable, so the scope is only inside the button6_Click eventhandler method

            theOracle = new TheOracle();
            //theOracle.answerDelInstance += delegate (string person)
            //{
            //    MessageBox.Show(person + " you are thinking: " + IAmThink);
            //};
            //int i = 0;
            //lambda version
            theOracle.answerDelInstance += (personPara) => { MessageBox.Show(personPara + " you are thinking: " + IAmThink); int i =0; };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.theOracle.ICanTellWhatYouAreThinking("Frank");
        }

        /// <summary>
        /// Oracle class definition
        /// </summary>
        class TheOracle
        {
            public answerDel answerDelInstance { get; set; }

            public void ICanTellWhatYouAreThinking(string theAskingPerson)
            {
                answerDelInstance?.Invoke(theAskingPerson);
            }
        }

        #endregion


    }
}
