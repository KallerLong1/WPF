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

namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for Border.xaml
    /// </summary>
    public partial class Border : Window
    {
        public Border()
        {
            InitializeComponent();
        }

        public void Render()
        {
            this.Show();
            this.Dispatcher.Invoke(new Action(() => {
                this.Left = 500;
                this.Top = 100;
                this.Width = 200;
                this.Height = 200;
            }));

        }
    }
}
