using System.Windows;
using VarAPI.Models;
using Flurl;
using Flurl.Http;
using System;
using VarAPI.Exceptions;

namespace VarAPI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ClickOnSaveButton(object sender, RoutedEventArgs e)
        {
            String token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6dHJ1ZSwiaWF0IjoxNjM3NDUzNzA4LCJqdGkiOiI5NzlkZTc3Yi0yMmJjLTQwMDUtYTgyYi1kNGI4ODNmZjM0ZTkiLCJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiMjNiMTU0YjctOTIxMS00NjhkLTk4NTYtZThhMTYxOGZkM2QyIiwibmJmIjoxNjM3NDUzNzA4LCJleHAiOjE2Mzc0NzUzMDh9.zyOlvSKMHd5ltsgoHS5D4eugpYn4TE9hB6XBWLEPk4E;"
            Varamiento varamiento = new Varamiento {                                
                finalizado = true,
                nombreInformante = Informante.Text,
                telefonoInformante = Telefono.Text,
                direccionInformante = Direccion.Text,
                ordenAnimal = Orden.Text,
                condicionAnimal = Condicion.Text,
                numeroAnimales = int.Parse(Numero.Text),
                observaciones = Observations.Text,
                facilAcceso = FacilAcceso.IsChecked ?? false,
                acantilado = Acantilado.IsChecked ?? false,
                sustrato = Sustrato.Text,
                primeraVezVisto = PrimerAvistamiento.Text,
                fechaAvistamiento = Fecha.Text,
                pais = Pais.Text,
                estado = Estado.Text,
                ciudad = Ciudad.Text,
                localidad = Localidad.Text,
                informacionAdicionalUbicacion = AditionalInfoOfLocation.Text,
                latitud = Latitud.Text,
                longitud = Longitud.Text
            };
            try
            {
                var response = "http://ec2-3-137-222-34.us-east-2.compute.amazonaws.com/yo/varamientos"
                .WithOAuthBearerToken(token)
                    .PostJsonAsync(varamiento)
                .ReceiveJson().GetAwaiter().GetResult();
            } catch(FlurlHttpException flurlException)
            {
                var error = flurlException.GetResponseJsonAsync<NetworkException>().GetAwaiter().GetResult();
                Console.WriteLine(error);
                Console.WriteLine(flurlException.Message);
            }
        }
    }
}