using CoolBook.Wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBook.Wpf.ViewModel
{
    public class MainWindowViewModel
    {
        public string Name { get; set; }

        public MainWindowViewModel()
        {
            Name = string.Empty;
        }
    }
}
