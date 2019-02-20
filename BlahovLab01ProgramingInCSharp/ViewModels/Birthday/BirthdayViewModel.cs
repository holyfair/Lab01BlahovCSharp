using BlahovLab01ProgramingInCSharp.Exceptions;
using BlahovLab01ProgramingInCSharp.Tools;
using BlahovLab01ProgramingInCSharp.Tools.Menegers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BlahovLab01ProgramingInCSharp.ViewModels.Birthday
{
    internal class BirthdayViewModel : BaseViewModel
    {
        private enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        private enum Animal
        {
            Monkey,
            Cock,
            Dog,
            Pig,
            Rat,
            Bull,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat
        }
        private DateTime _dateOfBirth = DateTime.Today;
        private int _age;
        private string _westZodiac;
        private string _chinZodiac;
        private bool _canStart = true;

        private RelayCommand<object> _closeCommand;
        private RelayCommand<object> _startCommand;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public bool CanStart
        {
            get
            {
                return _canStart;
            }
            set
            {
                _canStart = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;

                if (_dateOfBirth > DateTime.Today.AddYears(-_age))
                    _age--;

                if (_age > 135 || _dateOfBirth > DateTime.Today)
                    throw new IllegalAgeException();

                OnPropertyChanged();
            }
        }

        public string WestZodiac
        {
            get
            {
                return _westZodiac;
            }
            set
            {
                _westZodiac = value;
                OnPropertyChanged();
            }
        }

        public string ChinZodiac
        {
            get
            {
                return _chinZodiac;
            }
            set
            {
                _chinZodiac = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> StartCommand
        {
            get
            {
                return _startCommand ?? (_startCommand = new RelayCommand<object>(
                          StartIplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

        private async void StartIplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            CanStart = false;
            await Task.Run(() => Thread.Sleep(2000));
            try
            {
                Age = DateTime.Today.Year - _dateOfBirth.Year;
                if (DateTime.Today.Month == _dateOfBirth.Month && DateTime.Today.Day == _dateOfBirth.Day)
                    MessageBox.Show("Happy birthday!!!");

                await Task.Run(() => Thread.Sleep(1000));
                CalcWestZodiak();
                CalcChinZodiac();
            }
            catch (IllegalAgeException e)
            {
                MessageBox.Show(e.Message);
            }
            CanStart = true;
            LoaderManeger.Instance.HideLoader();
        }

        private void CalcWestZodiak()
        {
            Month _month = (Month)DateOfBirth.Month;
            int _day = DateOfBirth.Day;

            switch (_month)
            {
                case Month.January:
                    WestZodiac = _day < 20 ? ("Козерог") : ("Водолей");
                    break;
                case Month.February:
                    WestZodiac = _day < 19 ? ("Водолей") : ("Рыбы");
                    break;
                case Month.March:
                    WestZodiac = _day < 21 ? ("Рыбы") : ("Овен");
                    break;
                case Month.April:
                    WestZodiac = _day < 21 ? ("Овен") : ("Телец");
                    break;
                case Month.May:
                    WestZodiac = _day < 21 ? ("Телец") : ("Близнецы");
                    break;
                case Month.June:
                    WestZodiac = _day < 21 ? ("Близнецы") : ("Рак");
                    break;
                case Month.July:
                    WestZodiac = _day < 23 ? ("Рак") : ("Лев");
                    break;
                case Month.August:
                    WestZodiac = _day < 23 ? ("Лев") : ("Дева");
                    break;
                case Month.September:
                    WestZodiac = _day < 24 ? ("Дева") : ("Весы");
                    break;
                case Month.October:
                    WestZodiac = _day < 24 ? ("Весы") : ("Скорпион");
                    break;
                case Month.November:
                    WestZodiac = _day < 22 ? ("Скорпион") : ("Стрелец");
                    break;
                case Month.December:
                    WestZodiac = _day < 22 ? ("Стрелец") : ("Козерог");
                    break;
            }

        }

        private void CalcChinZodiac()
        {
            Animal _animal = (Animal)(_dateOfBirth.Year % 12);

            switch (_animal)
            {
                case Animal.Monkey:
                    ChinZodiac = "Обезьяна";
                    break;
                case Animal.Cock:
                    ChinZodiac = "Петушара";
                    break;
                case Animal.Dog:
                    ChinZodiac = "Собака";
                    break;
                case Animal.Pig:
                    ChinZodiac = "Свинья";
                    break;
                case Animal.Rat:
                    ChinZodiac = "Крыса";
                    break;
                case Animal.Bull:
                    ChinZodiac = "Бык";
                    break;
                case Animal.Tiger:
                    ChinZodiac = "Тигр";
                    break;
                case Animal.Rabbit:
                    ChinZodiac = "Кролик";
                    break;
                case Animal.Dragon:
                    ChinZodiac = "Дракон";
                    break;
                case Animal.Snake:
                    ChinZodiac = "Змея";
                    break;
                case Animal.Horse:
                    ChinZodiac = "Лошадь";
                    break;
                case Animal.Goat:
                    ChinZodiac = "Коза";
                    break;
            }

        }

        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_dateOfBirth.ToString());
        }
        
    }
}