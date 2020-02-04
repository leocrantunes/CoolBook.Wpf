using CoolBook.Wpf.Model;
using CoolBook.Wpf.ViewModel;
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
using System.Windows.Shapes;

namespace CoolBook.Wpf.View
{
    /// <summary>
    /// Interaction logic for ChatWindowView.xaml
    /// </summary>
    public partial class ChatWindowView : Window
    {
        public ChatWindowView(SpaceBook myCoolBook)
        {
            ViewModel = new ChatWindowViewModel(myCoolBook);
            DataContext = ViewModel;
            
            InitializeComponent();
        }

        public ChatWindowViewModel ViewModel { get; set; }
        
        private void BtnSendGift_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SendGift();
        }

        private void BtnSendPoke_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SendPoke();
        }
    }
}
