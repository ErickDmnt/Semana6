using System.Net;

namespace Semana6.Views;


public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            using (HttpClient cliente = new HttpClient())
            {
                var param = new Dictionary<string, string>
            {
                { "nombre", txtNombre.Text },
                { "apellido", txtApellido.Text },
                { "edad", txtEdad.Text }
            };

                var content = new FormUrlEncodedContent(param);
                HttpResponseMessage response = await cliente.PostAsync("http://192.168.100.2/Semana6/estudiantews.php", content);

                response.EnsureSuccessStatusCode();

                // Navegar a la nueva p�gina solo si la respuesta fue exitosa
                await Navigation.PushAsync(new vEstudiante());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("alerta", ex.Message, "OK");
        }
    }
}