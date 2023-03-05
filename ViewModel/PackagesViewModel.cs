using DeliveryManager.App.Database;
using DeliveryManager.App.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryManager.App.ViewModel
{
    public class PackagesViewModel : ViewModelBase
    {
        private PackagesDbContext _context;
        private ObservableCollection<Package> _packages;
        private Package _selectedPackage;
        private int _selectedRow = -1;

        public PackagesViewModel(string databasePath)
        {
            _context = new PackagesDbContext(databasePath);
            SelectedPackage = new Package();
            LoadPackages();
        }

        public ObservableCollection<Package> Packages
        {
            get { return _packages; }
            set { Set(ref _packages, value); }
        }

        public Package SelectedPackage
        {
            get { return _selectedPackage; }
            set { Set(ref _selectedPackage, value); }
        }

        public ICommand AddRowCommand => new RelayCommand(() =>
        {
            // Add a new Package object to the Packages collection
            var package = new Package();
            Packages.Add(package);

            // Set the SelectedPackage to the new Package object
            SelectedPackage = package;
        });

        public ICommand SaveChangesCommand => new RelayCommand(() =>
        {
            SavePackage(SelectedPackage);
        });

        public ICommand CancelChangesCommand => new RelayCommand(() =>
        {
            LoadPackages();
        });

        public void LoadPackages()
        {
            Packages = new ObservableCollection<Package>(_context.Packages.ToList());
        }

        public void SavePackage(Package package)
        {
            _context.InsertOrReplace(package);
            _context.Commit();
            LoadPackages();
        }

        public void DeletePackage(Package package)
        {
            _context.Delete(package);
            _context.Commit();
            Packages.Remove(package);
        }
    }

}
