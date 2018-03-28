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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Border b = new Border();
        public MainWindow()
        {
            InitializeComponent();
            rec.Stroke = new SolidColorBrush(Colors.Red);
        }

        private DrawingBrush _gridBrush;
        private void canvas_backGround_Loaded(object sender, RoutedEventArgs e)
        {
            if (_gridBrush == null)
            {
                _gridBrush = new DrawingBrush(new GeometryDrawing(
                    new SolidColorBrush(Colors.White),
                         new Pen(new SolidColorBrush(Color.FromArgb(100,Colors.Blue.R, Colors.Blue.G, Colors.Blue.B)), 1.0),
                             new RectangleGeometry(new Rect(0, 0, 20, 20))));
                _gridBrush.Stretch = Stretch.None;
                _gridBrush.TileMode = TileMode.Tile;
                _gridBrush.Viewport = new Rect(0.0, 0.0, 20, 20);
                _gridBrush.ViewportUnits = BrushMappingMode.Absolute;
                canvas_backGround.Background = _gridBrush;
            }
        }


        private void TreeView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                TreeViewItem sitem = tv_Activities.SelectedItem as TreeViewItem;

                System.Windows.DragDrop.DoDragDrop(tv_Activities, tv_Activities, DragDropEffects.Move);
                //Adorner
                //                DragDropAdorner adorner = new DragDropAdorner(sender as TreeViewItem);
                //                15     mAdornerLayer = AdornerLayer.GetAdornerLayer(mTopLevelGrid);
                //                16     mAdornerLayer.Add(adorner);
                //                17
                //18     DataItem dataItem = listBoxItem.Content as DataItem;
                //                19     DataObject dataObject = new DataObject(dataItem.Clone());
                //                20     // Here, we should notice that dragsource param will specify on which 
                //21 // control the drag&drop event will be fired
                //22     System.Windows.DragDrop.DoDragDrop(mListBox, dataObject, DragDropEffects.Copy);
            }
        }

        private void canvas_backGround_Drap(object sender, DragEventArgs e)
        {
            if (e.Effects == DragDropEffects.Move)
            {
                TreeViewItem item = e.Data.GetData(typeof(TreeViewItem)) as TreeViewItem;
                Point p = e.GetPosition(canvas_backGround);

                canvas_backGround.Children.Add(test(p.X, p.Y));
            }
        }

        private Rectangle test(double x, double y)
        {
            Rectangle r = new Rectangle();
            r.Width = 100;
            r.Height = 100;
            r.Fill = new SolidColorBrush(Colors.Red);
            r.Margin = new Thickness(x, y, 0, 0);
            r.RadiusX = 10;
            r.RadiusY = 10;

            return r;
        }

        private void canvas_backGround_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(this.canvas_backGround);
                
            }
        }

        private void rec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            b.Render();
        }
    }
}
