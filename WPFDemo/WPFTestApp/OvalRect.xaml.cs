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

namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for OvalRect.xaml
    /// </summary>
    public partial class OvalRect : Node
    {
        public Brush Stroke
        {
            get
            {
                
                return this.rec.Stroke;
            }
            set
            {
                if (value != this.rec.Stroke)
                {
                    this.rec.Stroke = value;
                }
            }
        }
        public OvalRect()
        {
            InitializeComponent();
        }
    }

    public partial class OvalRect 
    {
        
    }
}
