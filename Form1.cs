
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.Entity;

namespace F1_standings
{
    public partial class MainForm : Form
    {
        private readonly F1Context _context;
        private bool _dataLoadedFromApi = false;
        private HashSet<int> _yearsWithData = new HashSet<int>();


        public MainForm()
        {
            InitializeComponent();
            _context = new F1Context();
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            int year;
            if (!int.TryParse(txtYear.Text, out year))
            {
                MessageBox.Show("Nieprawid�owy format roku. Wymagany format XXXX");
                return;
            }

            if (year < 1950 || year > 2023)
            {
                MessageBox.Show("Rok musi by� z zakresu od 1950 do 2023.");
                return;
            }

            if (!_yearsWithData.Contains(year))
            {
                string jsonData = await FetchDataFromAPI(year);
                if (jsonData != null)
                {
                    DisplayDrivers(jsonData);
                    _yearsWithData.Add(year);
                }
            }
            else
            {
                MessageBox.Show("Dane dla tego roku zosta�y ju� pobrane.");
                DisplayDriversFromDatabase();
            }
        }

        private async Task<string> FetchDataFromAPI(int year)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = $"http://ergast.com/api/f1/{year}/drivers.json";
                    string response = await client.GetStringAsync(apiUrl);
                    return response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d: {ex.Message}");
                return null;
            }
        }

        private void DisplayDrivers(string jsonData)
        {
            try
            {
                var driversResponse = JsonSerializer.Deserialize<RootObject>(jsonData);

                listBoxDrivers.Items.Clear(); // Wyczyszczenie listy przed dodaniem nowych danych
                foreach (var driverData in driversResponse.MRData.DriverTable.Drivers)
                {
                    // Sprawdzenie, czy kierowca ju� istnieje w bazie danych
                    var existingDriver = _context.Drivers.FirstOrDefault(d => d.driverId == driverData.driverId);
                    if (existingDriver == null)
                    {
                        // Tworzenie nowego obiektu Driver na podstawie danych z API
                        var driver = new Driver
                        {
                            driverId = driverData.driverId,
                            url = driverData.url,
                            givenName = driverData.givenName,
                            familyName = driverData.familyName,
                            dateOfBirth = driverData.dateOfBirth,
                            nationality = driverData.nationality
                        };

                        // Dodanie nowego kierowcy do bazy danych
                        AddDriver(driver);

                        // Dodanie nowego kierowcy do listBoxDrivers
                        listBoxDrivers.Items.Add(driver.ToString());
                    }
                    else
                    {
                        // Je�li kierowca ju� istnieje w bazie danych, dodaj go tylko do listBoxDrivers
                        listBoxDrivers.Items.Add(existingDriver.ToString());
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d: {ex.Message}");
            }
        }

        private void DisplayDriversFromDatabase()
        {
            try
            {
                var driversFromDb = _context.Drivers.ToList();

                listBoxDrivers.Items.Clear(); // Wyczyszczenie listy przed dodaniem nowych danych
                foreach (var driver in driversFromDb)
                {
                    listBoxDrivers.Items.Add(driver.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d: {ex.Message}");
            }
        }

        private void AddDriver(Driver driver)
        {
            var existingDriver = _context.Drivers.FirstOrDefault(d => d.driverId == driver.driverId);
            if (existingDriver == null)
            {
                _context.Drivers.Add(driver);
                _context.SaveChanges();
            }
        }

        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            // Pobierz dane wprowadzone przez u�ytkownika z p�l tekstowych
            string driverId = txtDriverId.Text;
            string givenName = txtGivenName.Text;
            string familyName = txtFamilyName.Text;
            string dateOfBirth = txtDateOfBirth.Text;
            string nationality = txtNationality.Text;

            // Sprawd�, czy wszystkie pola s� wype�nione
            if (string.IsNullOrEmpty(driverId) || string.IsNullOrEmpty(givenName) ||
                string.IsNullOrEmpty(familyName) || string.IsNullOrEmpty(dateOfBirth) ||
                string.IsNullOrEmpty(nationality))
            {
                MessageBox.Show("Prosz� wype�ni� wszystkie pola.");
                return;
            }

            // Utw�rz nowy obiekt Driver na podstawie danych wprowadzonych przez u�ytkownika
            var newDriver = new Driver()
            {
                driverId = driverId,
                givenName = givenName,
                familyName = familyName,
                dateOfBirth = dateOfBirth,
                nationality = nationality
            };

            // Wywo�aj metod� dodawania kierowcy do bazy danych
            AddDriver(newDriver);

            // Zaktualizuj list� kierowc�w wy�wietlan� na interfejsie u�ytkownika
            UpdateDriversList();

            // Opcjonalnie wyczy�� pola tekstowe po dodaniu kierowcy
            ClearTextBoxes();
        }

        private void UpdateDriversList()
        {
            try
            {
                // Pobierz list� kierowc�w z bazy danych
                var driversFromDb = _context.Drivers.ToList();

                // Wyczy�� list� wy�wietlan� w listBoxDrivers
                listBoxDrivers.Items.Clear();

                // Dodaj ka�dego kierowc� do listBoxDrivers
                foreach (var driver in driversFromDb)
                {
                    listBoxDrivers.Items.Add(driver.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d podczas aktualizacji listy kierowc�w: {ex.Message}");
            }
        }

        private void RemoveDriver(int driverId)
        {
            try
            {
                var driverToRemove = _context.Drivers.FirstOrDefault(d => d.Id == driverId);
                if (driverToRemove != null)
                {
                    _context.Drivers.Remove(driverToRemove);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d podczas usuwania kierowcy: {ex.Message}");
            }
        }


        private void btnRemoveDriver_Click(object sender, EventArgs e)
        {
            try
            {
                // Pobierz zaznaczone indeksy kierowc�w do usuni�cia
                var selectedIndices = listBoxDrivers.SelectedIndices.Cast<int>().ToList();

                // Iteruj przez zaznaczone indeksy i usu� odpowiadaj�ce im kierowc�w
                foreach (var index in selectedIndices)
                {
                    // Pobierz identyfikator kierowcy na podstawie indeksu w ListBox
                    int driverIdToRemove = _context.Drivers.ElementAt(index).Id;
                    // Usu� kierowc� na podstawie jego identyfikatora
                    RemoveDriver(driverIdToRemove);
                }

                // Zaktualizuj list� kierowc�w wy�wietlan� na interfejsie u�ytkownika
                UpdateDriversList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d podczas usuwania kierowc�w: {ex.Message}");
            }
        }

        private void ClearAllDrivers()
        {
            _context.Drivers.RemoveRange(_context.Drivers); // Usu� wszystkie kierowc�w z bazy danych
            _context.SaveChanges(); // Zapisz zmiany
            UpdateDriversList(); // Od�wie� list� kierowc�w
        }

        private void btnClearDatabase_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Czy na pewno chcesz wyczy�ci� ca�� baz� danych kierowc�w?",
                                                "Potwierd� czyszczenie bazy danych",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                ClearAllDrivers(); // Wywo�aj metod� do czyszczenia bazy danych
            }
        }

        private void ClearTextBoxes()
        {
            // Wyczy�� zawarto�� p�l tekstowych
            txtGivenName.Text = "";
            txtFamilyName.Text = "";
            txtDateOfBirth.Text = "";
            txtNationality.Text = "";
            txtDriverId.Text = "";
        }


        private void FilterDriversList(string searchText)
        {
            try
            {
                var filteredDrivers = _context.Drivers.Where(d =>
                    d.driverId.Contains(searchText) ||
                    d.givenName.Contains(searchText) ||
                    d.familyName.Contains(searchText) ||
                    d.dateOfBirth.Contains(searchText) ||
                    d.nationality.Contains(searchText)
                ).ToList();

                UpdateDriversList(filteredDrivers); // Aktualizacja listy wy�wietlanej na interfejsie u�ytkownika
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d podczas filtrowania listy kierowc�w: {ex.Message}");
            }
        }


        // Metoda do sortowania listy kierowc�w na podstawie wybranego kryterium
        private void SortDriversList(string sortBy)
        {
            try
            {
                List<Driver> sortedDrivers = null;

                switch (sortBy)
                {
                    case "ID":
                        sortedDrivers = _context.Drivers.OrderBy(d => d.driverId).ToList();
                        break;
                    case "Imi�":
                        sortedDrivers = _context.Drivers.OrderBy(d => d.givenName).ToList();
                        break;
                    case "Nazwisko":
                        sortedDrivers = _context.Drivers.OrderBy(d => d.familyName).ToList();
                        break;
                    case "Data urodzenia":
                        sortedDrivers = _context.Drivers.OrderBy(d => d.dateOfBirth).ToList();
                        break;
                    case "Narodowo��":
                        sortedDrivers = _context.Drivers.OrderBy(d => d.nationality).ToList();
                        break;
                    default:
                        break;
                }

                UpdateDriversList(sortedDrivers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d podczas sortowania listy kierowc�w: {ex.Message}");
            }
        }


        // Metoda aktualizuj�ca list� kierowc�w na interfejsie u�ytkownika
        private void UpdateDriversList(List<Driver> drivers)
        {
            try
            {
                listBoxDrivers.Items.Clear(); // Wyczy�� list� wy�wietlan� w listBoxDrivers

                // Dodaj ka�dego kierowc� do listBoxDrivers
                foreach (var driver in drivers)
                {
                    listBoxDrivers.Items.Add(driver.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d podczas aktualizacji listy kierowc�w: {ex.Message}");
            }
        }

        // Obs�uga zdarzenia klikni�cia przycisku "Filtruj"
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            FilterDriversList(searchText);
        }

        // Obs�uga zdarzenia zmiany wyboru sortowania
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sortBy = cmbSort.SelectedItem?.ToString(); // Pobierz wybran� warto�� z ComboBox

                if (!string.IsNullOrEmpty(sortBy))
                {
                    SortDriversList(sortBy); // Wywo�aj metod� sortowania
                }
                else
                {
                    UpdateDriversList(); // Je�li nie wybrano �adnej opcji sortowania, zaktualizuj list� bez sortowania
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d podczas sortowania listy kierowc�w: {ex.Message}");
            }
        }
        
    }
}
