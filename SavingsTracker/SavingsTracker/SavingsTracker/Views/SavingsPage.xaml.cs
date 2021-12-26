﻿using SavingsTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SavingsTracker.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class SavingsPage : ContentPage
   {
      public SavingsPage()
      {
         InitializeComponent();
      }

      protected override void OnAppearing()
      {
         var vm = (SavingsPageViewModel)BindingContext;
         vm.RefreshViewCommand.Execute(vm);

         base.OnAppearing();
      }
   }
}