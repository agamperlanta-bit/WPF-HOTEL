using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_HOTEL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void City_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Hotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrice();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            int nights = 0;
            decimal pricePerNight = 0;
            decimal totalPrice = 0;

            if (Calendear1.SelectedDate != null &&
                Calendear2.SelectedDate != null)
            {
                DateTime startDate = Calendear1.SelectedDate.Value;
                DateTime endDate = Calendear2.SelectedDate.Value;

                if (endDate > startDate)
                {
                    nights = (endDate - startDate).Days;
                }

                if (endDate <= startDate)
                {
                    NightsText.Text = "תאריך הסיום חייב להיות אחרי תאריך ההתחלה";
                }

                if (endDate > startDate)
                {
                    NightsText.Text = $"מספר לילות: {nights}";
                }
            }

            if (Calendear1.SelectedDate == null ||
                Calendear2.SelectedDate == null)
            {
                NightsText.Text = "מספר לילות: 0";
            }

            if (Hotel.SelectedItem != null)
            {
                ComboBoxItem selectedHotel =
                    (ComboBoxItem)Hotel.SelectedItem;

                if (selectedHotel.Content.ToString() == "קינג ג'ורג'")
                {
                    pricePerNight = 500;
                }

                if (selectedHotel.Content.ToString() == "סטאי")
                {
                    pricePerNight = 1200;
                }

                if (selectedHotel.Content.ToString() == "דניאל")
                {
                    pricePerNight = 800;
                }
            }

            if (Calendear1.SelectedDate != null &&
                Calendear2.SelectedDate != null &&
                Calendear2.SelectedDate > Calendear1.SelectedDate &&
                Hotel.SelectedItem != null)
            {
                totalPrice = nights * pricePerNight;
                PriceText.Text = $"סכום לתשלום: {totalPrice:N0} ₪";
            }

            if (Hotel.SelectedItem == null ||
                Calendear1.SelectedDate == null ||
                Calendear2.SelectedDate == null ||
                Calendear2.SelectedDate <= Calendear1.SelectedDate)
            {
                PriceText.Text = "סכום לתשלום: 0 ₪";
            }
        }

        private void RoomType_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadio = sender as RadioButton;
            string level = selectedRadio.Content.ToString();
            if (level == "חדר יחיד")
                MessageBox.Show("פינוק: חלק אמבטיה");
             if (level == "חדר זוגי")
                MessageBox.Show("פינוק: בקבוק יין ושוקולדים");
             if (level == "חדר טריפל")
                MessageBox.Show("פינוק: מגש פירות");
            if (level == "חדר לארבעה")
                MessageBox.Show("פינוק: מגש פירות ושוקלדים");

        }
    }
}











