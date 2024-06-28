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

namespace _3P_Proyectito_1
{
    /// <summary>
    /// Lógica de interacción para Tic_Tac_Toe.xaml
    /// </summary>
    public partial class Tic_Tac_Toe : Window
    {
        private string nombreJugador1;
        private string nombreJugador2;
        private string simboloJugador1;
        private string simboloJugador2;
        private string jugadorActual;
        private int contadorMovimientos;
        private Button[] botones;

        public Tic_Tac_Toe()
        {
            InitializeComponent();
            botones = new[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
        }

        private void cmbSimbolo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            simboloJugador1 = ((ComboBoxItem)cmbSimbolo.SelectedItem).Content.ToString();
            simboloJugador2 = simboloJugador1 == "X" ? "O" : "X";
            txtSimbolo2.Text = simboloJugador2;

            if (!string.IsNullOrEmpty(nombreJugador2))
            {
                cmbSimbolo.IsEnabled = false;
                txtNombreJugador2.IsEnabled = true;
                jugadorActual = nombreJugador1;
                txtResultado.Content = "Turno de: " + jugadorActual;
            }
        }


        private void btnComenzar_Click(object sender, RoutedEventArgs e)
        {
            nombreJugador1 = txtNombreJugador1.Text;
            nombreJugador2 = txtNombreJugador2.Text;

            if (string.IsNullOrEmpty(nombreJugador1) || string.IsNullOrEmpty(nombreJugador2))
            {
                MessageBox.Show("Por favor, ingrese los nombres de ambos jugadores.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            jugadorActual = nombreJugador1;
            contadorMovimientos = 0;

            foreach (Button boton in botones)
            {
                boton.Content = "";
                boton.IsEnabled = true;
            }

            simboloJugador1 = ((ComboBoxItem)cmbSimbolo.SelectedItem).Content.ToString();
            simboloJugador2 = simboloJugador1 == "X" ? "O" : "X";
            txtSimbolo2.Text = simboloJugador2;

            txtResultado.Content = "Turno de: " + jugadorActual;
            cmbSimbolo.IsEnabled = false;
            txtNombreJugador2.IsEnabled = false;
        }


        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;

            if (boton.Content.ToString() != "")
                return;

            contadorMovimientos++;
            boton.Content = jugadorActual == nombreJugador1 ? simboloJugador1 : simboloJugador2;

            if (VerificarGanador())
            {
                txtResultado.Content = jugadorActual + " ha ganado!";
                DisableRemainingButtons();
                return;
            }

            if (contadorMovimientos == 9)
            {
                txtResultado.Content = "Empate";
                return;
            }

            cmbSimbolo.IsEnabled = true;
            txtNombreJugador2.IsEnabled = true;
            jugadorActual = jugadorActual == nombreJugador1 ? nombreJugador2 : nombreJugador1;
            txtResultado.Content = "Turno de: " + jugadorActual;
        }

        private bool VerificarGanador()
        {
            if (botones[0].Content == botones[1].Content && botones[1].Content == botones[2].Content && botones[0].Content.ToString() != "")
                return true;
            if (botones[3].Content == botones[4].Content && botones[4].Content == botones[5].Content && botones[3].Content.ToString() != "")
                return true;
            if (botones[6].Content == botones[7].Content && botones[7].Content == botones[8].Content && botones[6].Content.ToString() != "")
                return true;
            if (botones[0].Content == botones[3].Content && botones[3].Content == botones[6].Content && botones[0].Content.ToString() != "")
                return true;
            if (botones[1].Content == botones[4].Content && botones[4].Content == botones[7].Content && botones[1].Content.ToString() != "")
                return true;
            if (botones[2].Content == botones[5].Content && botones[5].Content == botones[8].Content && botones[2].Content.ToString() != "")
                return true;
            if (botones[0].Content == botones[4].Content && botones[4].Content == botones[8].Content && botones[0].Content.ToString() != "")
                return true;
            if (botones[2].Content == botones[4].Content && botones[4].Content == botones[6].Content && botones[2].Content.ToString() != "")
                return true;

            return false;
        }

        private void DisableRemainingButtons()
        {
            foreach (Button boton in botones)
            {
                if (boton.IsEnabled)
                    boton.IsEnabled = false;
            }
        }

        private void btnReiniciar_Click(object sender, RoutedEventArgs e)
        {
            nombreJugador1 = txtNombreJugador1.Text;
            nombreJugador2 = txtNombreJugador2.Text;

            if (string.IsNullOrEmpty(nombreJugador1) || string.IsNullOrEmpty(nombreJugador2))
            {
                MessageBox.Show("Por favor, ingrese los nombres de ambos jugadores.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            jugadorActual = nombreJugador1;
            contadorMovimientos = 0;

            foreach (Button boton in botones)
            {
                boton.Content = "";
                boton.IsEnabled = true;
            }

            cmbSimbolo.IsEnabled = true;
            txtNombreJugador2.IsEnabled = true;
            cmbSimbolo.SelectedItem = simboloJugador1 == "X" ? cmbSimbolo.Items[0] : cmbSimbolo.Items[1];
            simboloJugador2 = simboloJugador1 == "X" ? "O" : "X";
            txtSimbolo2.Text = simboloJugador2;

            txtResultado.Content = "Turno de: " + jugadorActual;
        }

    
    }
}
