using CurrencyExchange.cAuxiliar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyExchange
{

    public partial class MainWindow : Window
    {
        cCurrency currency = null;
        cConversions conversions = null;
        cDataConversion cData = new cDataConversion();


        List<cConversions> Feed = new List<cConversions>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblLocalTime.Content = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ssss");

            foreach (string vCode in Enum.GetNames(typeof(cCurrency.Currency)))
            {
                
                cmbxCurrency1.Items.Add(vCode);
                cmbxCurrency2.Items.Add(vCode);
            }

        }


        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MinimizeWindow(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Converter(object sender, RoutedEventArgs e)
        {
            try
            {
                currency = new cCurrency();
                conversions = new cConversions();

                cmbxCurrency1.IsDropDownOpen = false;
                cmbxCurrency2.IsDropDownOpen = false;

                var vItem1 = cmbxCurrency1.SelectedItem;
                var vItem2 = cmbxCurrency2.SelectedItem;


                if (vItem1 != null && vItem2 != null && !string.IsNullOrEmpty(txtValor1.Text))
                {
                    string vResult = cApi.GetRequest(vItem1?.ToString());

                    var vObjConverted = cData.ConvertJson(vResult);

                    if (vObjConverted == null)
                        return;
                    
                    string vCurrency1 = vItem1?.ToString() ?? "";
                    string vCurrency2 = vItem2?.ToString() ?? "";
                    double vRate = cData.ConvertToDouble(vObjConverted["rates"][vItem2?.ToString()]);
                    double vValue1 = cData.ConvertToDouble(txtValor1.Text);
                    double vValue2 = currency.Convert(vValue1, vRate);

                    Feed.Add(conversions.AddFeed(vCurrency1, vCurrency2, vRate, vValue1, vValue2));


                    txtValue2.Text = cData.ConvertToString(vValue2);

                    lblValorTitulo.Content = txtValor1.Text;
                    lblCodeTitulo.Content = vItem1.ToString();

                    lblValorResultado.Content = txtValue2.Text;
                    lblCodeValorResultado.Content = vItem2.ToString();

                    dgConversions.ItemsSource = Feed;
                    dgConversions.Items.Refresh();

                }

            }
            catch (Exception)
            {

            }
        }
    }
}
