using BlahovLab01ProgramingInCSharp.ViewModels;
using System.Windows;

namespace BlahovLab01ProgramingInCSharp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
