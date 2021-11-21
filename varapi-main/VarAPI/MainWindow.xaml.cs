using System.Windows;
using VarAPI.Models;
using Flurl;
using Flurl.Http;
using System;
using VarAPI.Exceptions;

namespace VarAPI
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

        private void ClickOnSaveButton(object sender, RoutedEventArgs e)
        {
            Varamiento varamiento = new Varamiento {                                
                finalizado = true,
                nombreInformante = InformerName.Text,
                telefonoInformante = InformerPhone.Text,
                direccionInformante = InformerAddress.Text,
                ordenAnimal = AnimalOrder.Text,
                condicionAnimal = AnimalCondition.Text,
                numeroAnimales = int.Parse(NumberOfAnimals.Text),
                observaciones = Observations.Text,
                facilAcceso = EaseOfAccess.IsChecked ?? false,
                acantilado = Cliff.IsChecked ?? false,
                sustrato = Substratum.Text,
                primeraVezVisto = FirstSightIn.Text,
                fechaAvistamiento = DateOfSighting.Text,
                pais = Country.Text,
                estado = State.Text,
                ciudad = City.Text,
                localidad = Location.Text,
                informacionAdicionalUbicacion = AditionalInfoOfLocation.Text,
                latitud = Latitude.Text,
                longitud = Length.Text
            };

            try
            {
                var response = "http://ec2-3-137-222-34.us-east-2.compute.amazonaws.com/yo/varamientos"
                .WithOAuthBearerToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6dHJ1ZSwiaWF0IjoxNjM3NDQ2OTYwLCJqdGkiOiI5YjQ5YzhhOS05Y2IzLTRhM2ItOTUwYi1mMTM3MjVmYWMxNTciLCJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiZjIyN2UxZGEtMTU4ZC00ODZiLWJjY2EtNzU2NjI2YzNjOTE3IiwibmJmIjoxNjM3NDQ2OTYwLCJleHAiOjE2Mzc0Njg1NjB9.jFhHTTInSEb0N4gIXBkJQX4vXr6CaS8RT94gIaCfq7E")
                    .PostJsonAsync(varamiento)
                .ReceiveJson().GetAwaiter().GetResult();

                Console.WriteLine(response);
            } catch(FlurlHttpException flurlException)
            {
                var error = flurlException.GetResponseJsonAsync<NetworkException>().GetAwaiter().GetResult();
                Console.WriteLine(error);
                Console.WriteLine(flurlException.Message);
            }

        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            ListaVaramientos lv = new ListaVaramientos();
            lv.Show();
            this.Close();
        }
    }
}
