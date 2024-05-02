using System.Text.Json;

namespace ClimaTempoBia;

public partial class MainPage : ContentPage
{
		const string url= "https://api.hgbrasil.com/weather?woeid=455927&key=f3ec7adf";
		Resposta resposta;

   
		async void AtualizaTempo()

		{
			try
			{ 
				var HttClient = new HttpClient();
				var Response = await HttpClient.GetAsync(url);
				if (Response.IsSuccessStatusCode)				
				{
					var content = await Response.Content.ReadAsStringAsync();
					resposta = JsonSerializer.Deserialize<Resposta>(content);
					PreencherTela();
				}

			}

			catch (Exception e)
			{

			}
		}

         public MainPage()
	    {
		    InitializeComponent();
		    AtualizaTempo();
	    }

		void PreencherTela()
		{
			temp.Text = resposta.results.temp.ToString();
			city.Text = resposta.results.city;
			description.Text = resposta.results.description;
			rain.Text = resposta.results.rain.ToString();
			humidity.Text = resposta.results.humidity.ToString();
			sunrise.Text = resposta.results.sunrise;
			sunset.Text = resposta.results.sunset;
			wind_speedy.Text = resposta.results.wind_speedy.ToString();
			wind_cardinal.Text = resposta.results.wind_cardinal.ToString();
			moon_phase.Text = resposta.results.moon_phase;

			if (resposta.results.moon_phase=="new")
				moon_phase.Text = "Nova";

			else if (resposta.results.moon_phasee=="first_quarter ")
					moon_phase.Text = "Quarto Crescente";

			else if (resposta.results.moon_phase=="waxing_gibbous ")
					moon_phase.Text = "Crescente";
									
			else if (resposta.results.moon_phase=="full ")
					moon_phase.Text = "Cheia";
											
			else if (resposta.results.moon_phase=="waning_gibbous  ")
					moon_phase.Text = "Gibosa Minguante";

			else if (resposta.results.moon_phase=="last_quarter   ")
					moon_phase.Text = "Quarto minguante";

			else if (resposta.results.moon_phase=="waning_crescent ")
					moon_phase.Text = "Lua minguante";

			if (resposta.results.currently=="dia")
			{
				if(resposta.results.rain>=10)
				   background.Source="diachuva.png";
				else if (resposta.results.cloudness>=10)
						background.Source="dianublado.png";
				else
					background.Source="diaclaro.png";
			}

		}


     
	
}