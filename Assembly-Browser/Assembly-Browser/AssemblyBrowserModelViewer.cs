using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Assembly_Browser
{
    public class AssemblyBrowserModelViewer : INotifyPropertyChanged
    {
        AssemblyReader assemblyReader;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void LoadAssembly(object o)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Assemblies|*.dll;*.exe",
                Title = "Select assembly",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                assemblyReader = new AssemblyReader(openFileDialog.FileName);
                OnPropertyChanged();
            }
        }

        public Command LoadCommand
        { get; protected set; }

        public AssemblyBrowserModelViewer()
        {
            assemblyReader = null;
            LoadCommand = new Command(LoadAssembly);
        }
    }
}
