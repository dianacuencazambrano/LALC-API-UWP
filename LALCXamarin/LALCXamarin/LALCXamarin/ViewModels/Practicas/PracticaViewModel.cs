﻿using LALCXamarin.Services;
using LALC_UWP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LALCXamarin.ViewModels.Practicas
{
    
    public class PracticaViewModel
    {
        public LalcAPI lalcAPI { get; set; }
        public String Title { get; set; }

        public PracticaViewModel()
        {
            Title = "Historial de prácticas";
            lalcAPI = new LalcAPI();
        }

        public async Task<List<Practica>> OnAppearing()
        {
            return await lalcAPI.GetPracticas();
        }


    }
}
