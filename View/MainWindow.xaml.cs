using BCSH1_SEM_SOKOL.ViewModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BCSH1_SEM_SOKOL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel viewModel = new MainWindowViewModel();

            DataContext = viewModel;
        }

        // Metoda pro ověření formátu textu v textovém poli pro souřadnice X a Y po ztrátě focusu
        private void XY_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int cislo;
                if (!int.TryParse(textBox.Text, out cislo) || cislo < -200 || cislo > 200)
                {
                    MessageBox.Show("Zadávejte čísla v rozsahu od -200 do 200.");
                    textBox.Text = "0";
                }
            }
        }

        // Metoda pro ověření formátu textu v textovém poli pro populaci po ztrátě focusu
        private void Population_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int cislo;
                if (!int.TryParse(textBox.Text, out cislo) || cislo < 0)
                {
                    MessageBox.Show("Populace musí být větší nebo rovna 0.");
                    textBox.Text = "0";
                }
            }
        }
    }
}