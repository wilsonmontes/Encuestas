using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encuestas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallesEncuestaView : ContentPage
	{
        private readonly string[] equipos = { "Colombia", "Peru", "Brasil", "Rusia", "Alemania", "Argentina"};
		public DetallesEncuestaView ()
		{
			InitializeComponent ();
            btnAgregareq.Clicked += BtnAgregareq_Clicked;
            btnAceptar.Clicked += BtnAceptar_Clicked;

        }

        private async void BtnAceptar_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(entNombre.Text) || string.IsNullOrEmpty(lbEquipoFav.Text)){
                await DisplayAlert("Datos incompletos","Por favor ingrese los campos","Aceptar");
                return;
            }
            var enc = new Encuesta()
            {
                Nombre = entNombre.Text,
                EquipoFavorito = lbEquipoFav.Text,
                FechaNacimiento = dtNac.Date
            };
            MessagingCenter.Send((ContentPage)this, Mensajes.EncuestaCompleta, enc);
            await Navigation.PopAsync();
        }

        private async void BtnAgregareq_Clicked(object sender, EventArgs e)
        {
            var equipoFavorito = await DisplayActionSheet(Literales.TituloEqFav,null,null,equipos);

            if (!string.IsNullOrEmpty(equipoFavorito))
            {
                lbEquipoFav.Text = equipoFavorito;
            }
        }
    }
}