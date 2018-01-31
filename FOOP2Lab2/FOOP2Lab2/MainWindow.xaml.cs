using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace FOOP2Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rn = new Random();
        List<Player> playerList = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreatePlayers();
            lbox_playerList.ItemsSource = playerList;
        }

        private void CreatePlayers()
        {
            DateTime startDate = new DateTime(2000, 1, 1);
            for (int i = 0; i < 20; i++)
            {

                int range = (DateTime.Now - startDate).Days;
                playerList.Add(new Player("Player" + i, startDate.AddDays(rn.Next(range))));

            }
        }

        private void btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if(tbox_Name.ToString()!= null )
            {
                DateTime dt = dp_DateOfBirth.SelectedDate.Value;
                playerList.Add(new Player(tbox_Name.Text, dt));
                lbox_playerList.ItemsSource = "";
                lbox_playerList.ItemsSource = playerList;

                
                
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(playerList);
            Console.WriteLine(json);
            FileStream fs = new FileStream("players.json", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(json);

            sw.Dispose();
            sw.Close();
            fs.Dispose();
            fs.Close();
        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("players.json", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            List<Player> pl = (List < Player > )JsonConvert.DeserializeObject(sr.ReadLine());

            sr.Dispose();
            sr.Close();
            fs.Dispose();
            fs.Close();
        }
    }
}
