﻿using System.Globalization;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SavingsTracker.Services
{
   public static class Settings
   {
      public static class SupportedCultures
      {
         public const string DefaultLanguage = "DefaultLanguage";
         public const string English = "En";
         public const string Hungarian = "Hu";
      }

      public static class SupportedThemes
      {
         public const string DefaultTheme = "DefaultTheme";
         public const string Light = "Light";
         public const string dark = "Dark";
      }

      public static string Culture
      {
         get
         {
            return Preferences.Get("Culture", SupportedCultures.DefaultLanguage);
         }
         set
         {
            Preferences.Set("Culture", value);
            UpdateAppCulture();
         }
      }

      public static string Theme
      {
         get
         {
            return Preferences.Get("Theme", SupportedThemes.DefaultTheme);
         }
         set
         {
            Preferences.Set("Theme", value);
            UpdateAppTheme();
         }
      }

      public static void UpdateAppTheme()
      {
         if (Theme == SupportedThemes.DefaultTheme)
         {
            App.Current.UserAppTheme = OSAppTheme.Unspecified;
         }
         else if (Theme == SupportedThemes.Light)
         {
            App.Current.UserAppTheme = OSAppTheme.Light;
         }
         else if (Theme == SupportedThemes.dark)
         {
            App.Current.UserAppTheme = OSAppTheme.Dark;
         }
      }

      public static void UpdateAppCulture()
      {
         if (Culture == SupportedCultures.DefaultLanguage)
         {
            LocalizationResourceManager.Current.CurrentCulture = CultureInfo.InstalledUICulture;
         }
         else 
         {
            CultureInfo language = new CultureInfo(Culture);
            LocalizationResourceManager.Current.CurrentCulture = language;
         }
      }
   }
}
