using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View_WPF
{
	/// <summary>
	/// Interaction logic for ShowOwner.xaml
	/// </summary>
	public partial class ShowOwner : Window
	{
		public ShowOwner()
		{
			InitializeComponent();
		}

		Ex28_Rewriting.Control cont = new Ex28_Rewriting.Control();
		private void backreturn(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}

		private void btn_DeletePet(object sender, RoutedEventArgs e)
		{
			cont.DeletePet(Pets.Na)
		}

		private void btn_ShowPets(object sender, RoutedEventArgs e)
		{
		
				Pets.ItemsSource = cont.ShowPets().Select(pet => pet.Name + '\t' + pet.OwnerId);
			
		}
	}
}
