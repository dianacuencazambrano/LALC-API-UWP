﻿using LALC_UWP.Models;
using LALCXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LALCXamarin.Views.Subcategorias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearSubcategoria : ContentPage
    {
        public static int categoriaid = new int(); 
        CrearSubcategoriaViewModel _viewModel;
        public CrearSubcategoria()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CrearSubcategoriaViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        private async void CrearNuevaSubcategoria(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Nombre.Text))
            {
                await DisplayAlert("Nombre vacío", "La subcategoría debe tener un nombre", "OK");
            }
            else
            {
                bool answer = await DisplayAlert("Crear", "¿Está seguro de crear la subcategoría?", "Si", "No");
                if (answer)
                {
                    Subcategoria subcategoriaCreada = new Subcategoria
                    {
                        Nombre = Nombre.Text,
                        CategoriaID = categoriaid,
                        Descripcion = Descripcion.Text,
                        Color = "#" + ColorPick.ViewModel.Hex.ToString()
                    };
                    _viewModel.OnCrearSubcategoria(subcategoriaCreada);
                }
            }
        }

        private async void CancelarCrear(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Salir sin guardar", "¿Está seguro de salir sin crear la categoria?", "Si", "No");

            if (answer)
            {
                await Navigation.PopAsync();
            }
        }
    }
}