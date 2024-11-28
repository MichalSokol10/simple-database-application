using BCSH1_SEM_SOKOL.Model;
using BCSH1_SEM_SOKOL.ViewModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

public class ZobrazHraceViewModel : INotifyPropertyChanged
{
    // Hráč
    private Hrac _hrac;

    public Hrac Hrac
    {
        get { return _hrac; }
        set
        {
            _hrac = value;
            OnPropertyChanged(nameof(Hrac));
        }
    }
    // Počet vesnic daného hráče
    private int _pocetVesnicHrace;
    public int PocetVesnicHrace
    {
        get { return _pocetVesnicHrace; }
        set
        {
            if (_pocetVesnicHrace != value)
            {
                _pocetVesnicHrace = value;
                OnPropertyChanged(nameof(PocetVesnicHrace));
            }
        }
    }
    // Celková populace daného hráče
    private int _celkovaPopulaceHrace;
    public int CelkovaPopulaceHrace
    {
        get { return _celkovaPopulaceHrace; }
        set
        {
            if (_celkovaPopulaceHrace != value)
            {
                _celkovaPopulaceHrace = value;
                OnPropertyChanged(nameof(CelkovaPopulaceHrace));
            }
        }
    }

    // Vybraná vesnice hráče
    private Vesnice _vybranaVesnice;

    public Vesnice VybranaVesnice
    {
        get { return _vybranaVesnice; }
        set
        {
            _vybranaVesnice = value;
            OnPropertyChanged(nameof(VybranaVesnice));
        }
    }
    // Kolekce vesnic daného hráče
    public ObservableCollection<Vesnice> VesniceHrace { get; } = new ObservableCollection<Vesnice>();

    // Instanci hlavního ViewModelu
    private MainWindowViewModel _mainWindowViewModel;

    // Příkaz pro zavření okna.
    public RelayCommand ZavritCommand { get; }

    // Příkaz pro odebrání vesnice.
    public RelayCommand OdebratCommand { get; }

    // Konstruktor, který přijímá objekt hráče a inicializuje všechny potřebné hodnoty.
    public ZobrazHraceViewModel(Hrac hrac, MainWindowViewModel mainWindowViewModel)
    {
        Hrac = hrac;

        _mainWindowViewModel = mainWindowViewModel;

        ZavritCommand = new RelayCommand(Zavrit);

        OdebratCommand = new RelayCommand(OdebratVesnici);

        foreach (var vesnice in _hrac.Vesnice)
        {
            VesniceHrace.Add(vesnice);
        }

        PocetVesnicHrace = _hrac.Vesnice.Count;

        CelkovaPopulaceHrace = _hrac.Vesnice.Sum(v => v.Populace);
    }

    // Metoda pro zavření aktuálního okna.
    private void Zavrit()
    {
        Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        window.Close();
    }

    // Metoda pro odebrání vybrané vesnice od hráče.
    private void OdebratVesnici()
    {
        if (VybranaVesnice == null)
        {
            MessageBox.Show("Nebyla vybrána žádná vesnice k odebrání!");
            return;
        }

        _hrac.Vesnice.Remove(VybranaVesnice);

        _mainWindowViewModel._vesnice.Remove(VybranaVesnice);

        _mainWindowViewModel.AktualizujKolekce();

        AktualizujOkno();
    }

    // Metoda pro aktualizaci informací v UI po provedení změny.
    private void AktualizujOkno()
    {
        VesniceHrace.Clear();

        foreach (var vesnice in _hrac.Vesnice)
        {
            VesniceHrace.Add(vesnice);
        }

        PocetVesnicHrace = _hrac.Vesnice.Count;

        CelkovaPopulaceHrace = _hrac.Vesnice.Sum(v => v.Populace);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Metoda pro vyvolání události změny vlastnosti
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}