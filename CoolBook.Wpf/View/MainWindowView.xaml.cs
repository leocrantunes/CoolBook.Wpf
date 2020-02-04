using CoolBook.Wpf.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using CoolBook.Wpf.Model;

namespace CoolBook.Wpf.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public ObservableCollection<ChatWindowView> ChatViews;
        
        public MainWindowView()
        {
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
            
            ChatViews = new ObservableCollection<ChatWindowView>();

            var chat = new ChatWindowView(new SpaceBook("Leo"));
            chat.Closed += Chat_Closed;
            chat.Show();

            var chat2 = new ChatWindowView(new SpaceBook("Nathalia"));
            chat2.Closed += Chat_Closed;
            chat2.Show();

            InitializeComponent();
        }

        public MainWindowViewModel ViewModel { get; set; }

        private void BtnCreateChat_Click(object sender, RoutedEventArgs e)
        {
            var chat = new ChatWindowView(new SpaceBook(ViewModel.Name));
            chat.Closed += Chat_Closed;
            chat.Show();
        }

        private void Chat_Closed(object sender, System.EventArgs e)
        {
            var view = sender as ChatWindowView;
            var chat = ChatViews.FirstOrDefault(c => c.Name == view.ViewModel.SpaceBook.Name);
            if (chat != null)
            {
                ChatViews.RemoveAt(ChatViews.IndexOf(chat));
            }
        }
    }
}
