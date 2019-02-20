using System.ComponentModel;

namespace BlahovLab01ProgramingInCSharp.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        System.Windows.Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
