using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Semana6.Views;

public partial class vEstudiante : ContentPage
{

	private const string Url = "http://192.168.100.66/Semana6/estudiantews.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Modelos.Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		Mostrar();
	}

	public async void Mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Modelos.Estudiante> mostrar = JsonConvert.DeserializeObject<List<Modelos.Estudiante>>(content);
		est = new ObservableCollection<Modelos.Estudiante>(mostrar);
		listaEstudiantes.ItemsSource = est;
	}
}