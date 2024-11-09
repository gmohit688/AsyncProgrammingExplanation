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
        private async void button1_Click(object sender, EventArgs e)
        {
            LogMessage("Started Tasks");

            Task task1 = WashAndDryClothes();
            Task task2 = CleanHouse();
            Task task3 = CookFood();

            await Task.WhenAll(task1, task2, task3);
            LogMessage("Completed Tasks");
        }
        private async Task WashAndDryClothes()
        {
            string clothes = await WashClothes();
            DryClothes(clothes);
        }

        private async Task CookFood()
        {
            LogMessage("Started Cooking Food");
            await Task.Delay(2000);
            LogMessage("Completed Cooking Food");
        }

        private async Task CleanHouse()
        {
            LogMessage("Started Cleaning House");
            await Task.Delay(2000);
            LogMessage("Completed Cleaning House");
        }

        private async Task DryClothes(string clothes)
        {
            LogMessage("Drying Clothes");
            await Task.Delay(1000);
            LogMessage("Completed Drying Clothes");
        }

        private async Task<string> WashClothes()
        {
            LogMessage("Washing Clothes");
            await Task.Delay(1000);
            LogMessage("Completed Washing Colthes");
            return "Wet Clothes";
        }
    }
}
