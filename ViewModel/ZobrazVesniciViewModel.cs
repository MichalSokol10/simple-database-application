using BCSH1_SEM_SOKOL.Model;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;

public class ZobrazVesniciViewModel : INotifyPropertyChanged
{
    // Vesnice hráče
    private Vesnice _vesnice;

    public Vesnice Vesnice
    {
        get { return _vesnice; }
        set
        {
            _vesnice = value;
            OnPropertyChanged(nameof(Vesnice));
        }
    }

    // Příkaz pro zavření okna
    public RelayCommand ZavritCommand { get; }

    // Konstruktor, který přijímá objekt vesnice a inicializuje příkazy.
    public ZobrazVesniciViewModel(Vesnice vesnice)
    {
        Vesnice = vesnice;

        ZavritCommand = new RelayCommand(Zavrit);
    }

    // Metoda pro zavření okna, když uživatel klikne na tlačítko pro zavření.
    private void Zavrit()
    {
        Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        window.Close();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Metoda pro vyvolání události změny vlastnosti.
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}