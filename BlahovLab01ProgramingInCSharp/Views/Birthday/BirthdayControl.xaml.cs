using BlahovLab01ProgramingInCSharp.ViewModels.Birthday;
using System.Windows.Controls;

namespace BlahovLab01ProgramingInCSharp.Views.Birthday
{
    public partial class BirthdayControl : UserControl
    {
        internal BirthdayControl()
        {
            InitializeComponent();
            DataContext = new BirthdayViewModel();
        }
    }
}
