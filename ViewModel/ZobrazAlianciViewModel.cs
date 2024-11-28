using BCSH1_SEM_SOKOL.Model;
using BCSH1_SEM_SOKOL.ViewModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

public class ZobrazAlianciViewModel : INotifyPropertyChanged
{
    // Aliance hráče
    private Aliance _aliance;

    public Aliance Aliance
    {
        get { return _aliance; }
        set
        {
            _aliance = value;
            OnPropertyChanged(nameof(Aliance));
        }
    }
    // Počet hráčů v alianci
    private int _pocetHracuAliance;
    public int PocetHracuAliance
    {
        get { return _pocetHracuAliance; }
        set
        {
            if (_pocetHracuAliance != value)
            {
                _pocetHracuAliance = value;
                OnPropertyChanged(nameof(PocetHracuAliance));
            }
        }
    }
    // Celková populace aliance
    private int _celkovaPopulaceAliance;
    public int CelkovaPopulaceAliance
    {
        get { return _celkovaPopulaceAliance; }
        set
        {
            if (_celkovaPopulaceAliance != value)
            {
                _celkovaPopulaceAliance = value;
                OnPropertyChanged(nameof(CelkovaPopulaceAliance));
            }
        }
    }
    // Vybraný hráč
    private Hrac _vybranyHrac;

    public Hrac VybranyHrac
    {
        get { return _vybranyHrac; }
        set
        {
            _vybranyHrac = value;
            OnPropertyChanged(nameof(VybranyHrac));
        }
    }
    // ObservableCollection pro zobrazení hráčů aliance
    public ObservableCollection<Hrac> HraciAliance { get; } = new ObservableCollection<Hrac>();
    // Hlavní viewModel okno
    private MainWindowViewModel _mainWindowViewModel;
    // Příkazy pro zavření okna a odebrání hráče
    public RelayCommand ZavritCommand { get; }
    public RelayCommand OdebratCommand { get; }

    // Konstruktor, který přijímá alianci a MainWindowViewModel pro inicializaci
    public ZobrazAlianciViewModel(Aliance aliance, MainWindowViewModel mainWindowViewModel)
    {
        Aliance = aliance;

        _mainWindowViewModel = mainWindowViewModel;

        ZavritCommand = new RelayCommand(Zavrit);

        OdebratCommand = new RelayCommand(OdebratHrace);

        foreach (var hrac in _aliance.Hraci)
        {
            HraciAliance.Add(hrac);
        }

        PocetHracuAliance = _aliance.Hraci.Count;

        CelkovaPopulaceAliance = _aliance.Hraci.SelectMany(h => h.Vesnice).Sum(v => v.Populace);
    }

    // Metoda pro zavření aktuálního okna
    private void Zavrit()
    {
        Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        window.Close();
    }

    // Metoda pro odebrání vybraného hráče z aliance
    private void OdebratHrace()
    {
        if (VybranyHrac == null)
        {
            MessageBox.Show("Nebyl vybrán žádný hráč k odebrání!");
            return;
        }

        _aliance.Hraci.Remove(VybranyHrac);

        foreach (var vesnice in _mainWindowViewModel._vesnice.Where(v => v.Vlastnik == VybranyHrac).ToList())
        {
            _mainWindowViewModel._vesnice.Remove(vesnice);
        }

        _mainWindowViewModel._hraci.Remove(VybranyHrac);

        _mainWindowViewModel.AktualizujKolekce();

        AktualizujOkno();
    }

    // Metoda pro aktualizaci zobrazení hráčů v alianci a výpočtu počtu hráčů a populace
    private void AktualizujOkno()
    {
        HraciAliance.Clear();

        foreach (var hrac in _aliance.Hraci)
        {
            HraciAliance.Add(hrac);
        }

        PocetHracuAliance = _aliance.Hraci.Count;

        CelkovaPopulaceAliance = _aliance.Hraci.SelectMany(h => h.Vesnice).Sum(v => v.Populace);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Metoda pro vyvolání PropertyChanged události
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}