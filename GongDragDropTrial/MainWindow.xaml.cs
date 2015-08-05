using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GongSolutions.Wpf.DragDrop;

namespace GongDragDropTrial
{
    // http://wpf.2000things.com/2014/01/31/999-using-a-canvas-as-the-items-panel-for-a-listbox/
    public partial class MainWindow : INotifyPropertyChanged, IDropTarget
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var random = new Random();

            var maxLeft = this.Width - 100;
            var maxTop = this.Height - 100;

            MainItems =
                new ObservableCollection<Thing>(
                    new[] { "Regulus", "Dubhe", "Denebola", "Gienah", "Acrux" }
                    .Select(
                        name =>
                            new Thing(name, random.Next((int)maxLeft), random.Next((int)maxTop))));

            Source = new ObservableCollection<Thing>(
                new[]
                {
                    "Rigel",
                    "Zubenelgenubi",
                    "Kochab",
                    "Alpheca",
                    "Antares",
                    "Atria",
                    "Sabic",
                    "Shaula",
                    "Rasalhague",
                    "Eltanin"
                }.Select(name => new Thing(name, 0, 0)));
            ;
        }

        private ObservableCollection<Thing> mainItems;
        private ObservableCollection<Thing> source;

        public ObservableCollection<Thing> MainItems
        {
            get { return mainItems; }
            set
            {
                mainItems = value;
                RaisePropertyChanged("MainItems");
            }
        }

        public ObservableCollection<Thing> Source
        {
            get { return source; }
            set
            {
                source = value;
                RaisePropertyChanged("Source");
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
            this.Title = DateTime.Now.ToLongTimeString();
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            throw new NotImplementedException();
        }
    }

    public class Thing
    {
        public string Name { get; private set; }
        public double Left { get; set; }
        public double Top { get; set; }

        public Thing(string name, double top, double left)
        {
            Name = name;
            Left = left;
            Top = top;
        }
    }
}