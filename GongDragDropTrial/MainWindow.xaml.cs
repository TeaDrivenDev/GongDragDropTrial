using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GongDragDropTrial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            CityList = new ObservableCollection<City>
            {
                new City("Duluth", 46.83, 92.18),
                new City("Redmond", 44.27, 121.15),
                new City("Tucson", 32.12, 110.93),
                new City("Denver", 39.75, 104.87),
                new City("Boston", 42.37, 71.03),
                new City("Tampa", 27.97, 82.53)
            };
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

    public static class Constants
    {
        public const double LatTop = 50.0;
        public const double LatBottom = 24.0;

        public const double LongLeft = 125.0;
        public const double LongRight = 66.0;
    }

    public class LatValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double latitude = (double)value;
            double height = (double)parameter;

            int top = (int)((Constants.LatTop - latitude) / (Constants.LatTop - Constants.LatBottom) * height);
            return top;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LongValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double longitude = (double)value;
            double width = (double)parameter;

            int left = (int)((Constants.LongLeft - longitude) / (Constants.LongLeft - Constants.LongRight) * width);
            return left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}