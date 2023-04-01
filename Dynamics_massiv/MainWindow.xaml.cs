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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dynamics_massiv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> ints = new List<int>();
        private Stack<Mountains> mountains = new Stack<Mountains>();
        private OurList<int> ourList = new OurList<int>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void txtMassiv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 ||
                e.Key == Key.OemComma || e.Key == Key.Back) return;
            e.Handled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < int.Parse(txtSize.Text); i++)
            {
                int n = random.Next(-50, 50);
                ints.Add(n);
                txbGenMassiv.Text += n.ToString("F2") + " ";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int max = ints[0];
            int indx = 0;
            for (int i = 1; i < ints.Count; i++)
            {
                if (ints[i] > max)
                {
                    max = ints[i];
                    indx = i;
                }
            }

            txbResult.Text = indx.ToString();

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            int overall_height = 0;
            foreach (Mountains mount in mountains)
            {
                overall_height += mount.Height;
            }
            overall_height /=  mountains.Count;
            Result.Text=overall_height.ToString();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Mountains mount = new Mountains(nameMountain.Text, int.Parse(heightMountain.Text));
              
            mountains.Push(mount);
            TreeViewItem item = new TreeViewItem();
            item.Tag = "Запись " + mountains.Count;
            item.Header = "Запись " + mountains.Count;
            item.Items.Add(mount.Name);
            item.Items.Add(mount.Height);
            treeView.Items.Add(item);
            nameMountain.Clear();
            heightMountain.Clear();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(txtLab8.Text);
                ourList.Add(n);
                list8.Items.Add(n);
                txtLab8.Clear();
                updateList8();
            }
            catch
            {

            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 0;
                foreach (int item in ourList)
                {
                    if (item < 0) ourList.Insert(10, i);
                    i++;
                }
                updateList8();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateList8()
        {
            list8.Items.Clear();
            foreach (int i in ourList)
            {
                list8.Items.Add(i);
            }
        }
    }
}
