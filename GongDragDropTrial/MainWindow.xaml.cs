using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using GongSolutions.Wpf.DragDrop;

namespace GongDragDropTrial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // http://wpf.2000things.com/2014/01/31/999-using-a-canvas-as-the-items-panel-for-a-listbox/
    public partial class MainWindow : Window, INotifyPropertyChanged, IDropTarget
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var random = new Random();

            var maxLeft = this.Width - 100;
            var maxTop = this.Height - 100;

            CityList =
                new ObservableCollection<City>(
                    new[] { "Asdkjgk", "lksjdfkljsd", "klsjdfkljs" }.Select(
                        name =>
                            new City(name, random.Next((int)maxLeft), random.Next((int)maxTop))));
        }

        private ObservableCollection<City> cityList;

        public ObservableCollection<City> CityList
        {
            get { return cityList; }
            set
            {
                cityList = value;
                RaisePropertyChanged("CityList");
            }
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            throw new NotImplementedException();
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            throw new NotImplementedException();
        }
    }

    public class City
    {
        public string Name { get; private set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public City(string name, double latitude, double longitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
        }
    }

    //public static class Constants
    //{
    //    public const double LatTop = 50.0;
    //    public const double LatBottom = 24.0;

    //    public const double LongLeft = 125.0;
    //    public const double LongRight = 66.0;
    //}

    //public class LatValueConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        double latitude = (double)value;
    //        double height = (double)parameter;

    //        int top = (int)((Constants.LatTop - latitude) / (Constants.LatTop - Constants.LatBottom) * height);
    //        return top;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class LongValueConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        double longitude = (double)value;
    //        double width = (double)parameter;

    //        int left = (int)((Constants.LongLeft - longitude) / (Constants.LongLeft - Constants.LongRight) * width);
    //        return left;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}