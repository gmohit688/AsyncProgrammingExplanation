namespace AsyncProgrammingExplanation
{
    public partial class Form1 : Form
    {
        List<String> messages = new List<String>();
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = messages;
        }
        private void LogMessage(string msg)
        {
            messages.Add(DateTime.Now.ToLongTimeString() + " : " + msg);
            listBox1.DataSource = null;  // Remove the binding
            listBox1.DataSource = messages;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LogMessage("Started Tasks");

            string clothes = WashClothes();
            DryClothes(clothes);
            CleanHouse();
            CookFood();

            LogMessage("Completed Tasks");
        }

        private void CookFood()
        {
            LogMessage("Started Cooking Food");
            Task.Delay(2000).Wait();
            LogMessage("Completed Cooking Food");
        }

        private void CleanHouse()
        {
            LogMessage("Started Cleaning House");
            Task.Delay(2000).Wait();
            LogMessage("Completed Cleaning House");
        }

        private void DryClothes(string clothes)
        {
            LogMessage("Drying Clothes");
            Task.Delay(1000).Wait();
            LogMessage("Completed Drying Clothes");
        }

        private string WashClothes()
        {
            LogMessage("Washing Clothes");
            Task.Delay(1000).Wait();
            LogMessage("Completed Washing Colthes");
            return "Wet Clothes";
        }
    }
}
