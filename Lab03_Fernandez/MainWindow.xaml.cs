using Microsoft.Data.SqlClient;
using System;
using System.Data;
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

namespace Lab03_Fernandez
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection("Data Source=LAB1502-03;Initial Catalog=TiendaDB;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection =
                new SqlConnection("Data Source=LAB1502-03;" +
                "Initial Catalog=TiendaDB;Integrated Security=True;" +
                "TrustServerCertificate=True");

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlCommand command = new SqlCommand("Select * from Products", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                connection.Close();

                dgListarTable.ItemsSource = null;
           
                dgListarTable.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection connection =
               new SqlConnection("Data Source=LAB1502-03;" +
               "Initial Catalog=TiendaDB;Integrated Security=True;" +
               "TrustServerCertificate=True");

            List<Product> product = new List<Product>();

            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Products", connection);
            SqlDataReader dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                product.Add(new Product
                {
                    ProductId = dataReader["ProductID"].ToString(),
                    Name = dataReader["Name"].ToString(),
                    Price = dataReader["Price"].ToString(),
                });

            }

            connection.Close();
            dgListarReader.ItemsSource = product;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection =
               new SqlConnection("Data Source=LAB1502-03;" +
               "Initial Catalog=TiendaDB;Integrated Security=True;" +
               "TrustServerCertificate=True");

                connection.Open();
                DataTable dataTable = new DataTable();
                SqlCommand command = new SqlCommand("SELECT Name FROM Products WHERE Name LIKE @name");
                SqlDataReader dataReader = command.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                connection.Close();

                dgBuscar.ItemsSource = null;

                dgBuscar.ItemsSource = dataTable.DefaultView;

            }
            catch (Exception ex)
            {
            }
        }
    }
}