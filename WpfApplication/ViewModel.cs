using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assembly_Browser;
using Assembly_Browser.model;
using Microsoft.Win32;
using WpfApplication.Annotations;

namespace WpfApplication
{
    public class ViewModel : INotifyPropertyChanged
    {
        private AssemblyBrowser _assemblyBrowser;
        public string Info
        {
            get;
            set;
        }

        public ViewModel()
        {
            Info = "";
            LoadCommand = new BrowserCommand(LoadAssembly);
        }

        private void LoadAssembly(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Assembly (*.dll) | *.dll";
            if (openFileDialog.ShowDialog() == true && openFileDialog.FileName != null)
            {
               _assemblyBrowser = new AssemblyBrowser(openFileDialog.FileName);
                string result = "";
                foreach (Namespace ns in _assemblyBrowser.GetAllNamespaces())
                {
                    result += ns.ToString();
                }

                Info = result;
                OnPropertyChanged("Info");
            }
        }

        public BrowserCommand LoadCommand { get; protected set; }
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}