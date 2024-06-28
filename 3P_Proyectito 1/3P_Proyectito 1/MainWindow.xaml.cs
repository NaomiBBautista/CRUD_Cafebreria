//Main Window
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media.Animation;
using System.Security.Cryptography;

namespace _3P_Proyectito_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conectateSQL;
        public MainWindow()
        {
            InitializeComponent();

            string conectarseBD = ConfigurationManager.ConnectionStrings["_3P_Proyectito_1.Properties.Settings." +
                "POEV_3P_Proyectito1ConnectionString"].ConnectionString;
            conectateSQL = new SqlConnection(conectarseBD);
            MostrarContenido();
            Fade(bor, 0, 0.1);
            Fade(nvoId, 0, 0.1);
            Fade(nvoTitulo, 0, 0.1);
            Fade(nvoAutor, 0, 0.1);
            Fade(nvoGenero, 0, 0.1);
            Fade(nvoPaginas, 0, 0.1);
            Fade(uId, 0, 0.1);
            Fade(uTitulo, 0, 0.1);
            Fade(uAutor, 0, 0.1);
            Fade(uGenero, 0, 0.1);
            Fade(uPaginas, 0, 0.1);
            Fade(btnActualizar1, 0, 0.1);
        }

        private void Fade(object sender, double opacity, double seconds)
        {
            switch (sender.GetType().Name)
            {
                case "Border":
                    Border bor = (Border)sender;
                    DoubleAnimation animbor = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    bor.BeginAnimation(Border.OpacityProperty, animbor);
                    break;

                case "Button":
                    Button but = (Button)sender;
                    DoubleAnimation animbut = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    but.BeginAnimation(Border.OpacityProperty, animbut);
                    break;

                case "Label":
                    Label lb = (Label)sender;
                    DoubleAnimation animlb = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    lb.BeginAnimation(Border.OpacityProperty, animlb);
                    break;

                case "TextBox":
                    TextBox txbox = (TextBox)sender;
                    DoubleAnimation animtxbox = new DoubleAnimation(opacity, TimeSpan.FromSeconds(seconds));
                    txbox.BeginAnimation(Border.OpacityProperty, animtxbox);
                    break;

                default:
                    break;
            }
        }

        private void MostrarContenido()
        {
            try
            {
                string consulta = "SELECT * FROM libros";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaId = new DataTable();
                    adaptadorSQL.Fill(tablaId);
                    losId.DisplayMemberPath = "id_libro";
                    losId.SelectedValuePath = "id_libro";
                    losId.ItemsSource = tablaId.DefaultView;
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                string consulta = "SELECT * FROM libros";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaTitulos = new DataTable();
                    adaptadorSQL.Fill(tablaTitulos);
                    losTitulos.DisplayMemberPath = "titulo";
                    losTitulos.SelectedValuePath = "id_libro";
                    losTitulos.ItemsSource = tablaTitulos.DefaultView;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                string consulta = "SELECT * FROM libros";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaAutores = new DataTable();
                    adaptadorSQL.Fill(tablaAutores);
                    losAutores.DisplayMemberPath = "autor";
                    losAutores.SelectedValuePath = "id_libro";
                    losAutores.ItemsSource = tablaAutores.DefaultView;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                string consulta = "SELECT * FROM libros";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaGeneros = new DataTable();
                    adaptadorSQL.Fill(tablaGeneros);
                    losGeneros.DisplayMemberPath = "genero";
                    losGeneros.SelectedValuePath = "id_libro";
                    losGeneros.ItemsSource = tablaGeneros.DefaultView;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            try
            {
                string consulta = "SELECT * FROM libros";
                SqlDataAdapter adaptadorSQL = new SqlDataAdapter(consulta, conectateSQL);
                using (adaptadorSQL)
                {
                    DataTable tablaPaginas = new DataTable();
                    adaptadorSQL.Fill(tablaPaginas);
                    lasPaginas.DisplayMemberPath = "paginas";
                    lasPaginas.SelectedValuePath = "id_libro";
                    lasPaginas.ItemsSource = tablaPaginas.DefaultView;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (losTitulos.SelectedValue != null)
            {
                int idLibro = Convert.ToInt32(losTitulos.SelectedValue);

                string consulta = "DELETE FROM libros WHERE id_libro = @elid";
                SqlCommand miComandoSQL = new SqlCommand(consulta, conectateSQL);
                miComandoSQL.Parameters.AddWithValue("@elid", idLibro);

                try
                {
                    conectateSQL.Open();
                    miComandoSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el libro: " + ex.Message);
                }
                finally
                {
                    conectateSQL.Close();
                }

                MostrarContenido();
            }
            else
            {
                MessageBox.Show("Seleccione un libro para borrar.");
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "INSERT INTO libros (id_libro, titulo, autor, genero, paginas) VALUES (@id, @titulo, @autor, @genero, @paginas)";
            SqlCommand miComandoI = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miComandoI.Parameters.AddWithValue("@id", cId1.Text);
            miComandoI.Parameters.AddWithValue("@titulo", cTitulo2.Text);
            miComandoI.Parameters.AddWithValue("@autor", cAutor.Text);
            miComandoI.Parameters.AddWithValue("@genero", cGenero.Text);
            miComandoI.Parameters.AddWithValue("@paginas", cPaginas.Text);
            miComandoI.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();
            cId1.Text = "";
            cTitulo2.Text = "";
            cAutor.Text = "";
            cGenero.Text = "";
            cPaginas.Text = "";
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Fade(bor, 100, 0.1);
            Fade(nvoId, 100, 0.1);
            Fade(nvoTitulo, 100, 0.1);
            Fade(nvoAutor, 100, 0.1);
            Fade(nvoGenero, 100, 0.1);
            Fade(nvoPaginas, 100, 0.1);
            Fade(uId, 100, 0.1);
            Fade(uTitulo, 100, 0.1);
            Fade(uAutor, 100, 0.1);
            Fade(uGenero, 100, 0.1);
            Fade(uPaginas, 100, 0.1);
            Fade(btnActualizar1, 100, 0.1);
        }

        private void btnActualizar1_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "UPDATE libros SET id_libro = @id, titulo = @titulo," +
                " autor = @autor, genero = @genero, paginas = @paginas WHERE id_libro = @elid";
            SqlCommand miCommandI = new SqlCommand(consulta, conectateSQL);
            conectateSQL.Open();
            miCommandI.Parameters.AddWithValue("@elid", losTitulos.SelectedValue);
            miCommandI.Parameters.AddWithValue("@id", nvoId.Text);
            miCommandI.Parameters.AddWithValue("@titulo", nvoTitulo.Text);
            miCommandI.Parameters.AddWithValue("@autor", nvoAutor.Text);
            miCommandI.Parameters.AddWithValue("@genero", nvoGenero.Text);
            miCommandI.Parameters.AddWithValue("@paginas", nvoPaginas.Text);
            miCommandI.ExecuteNonQuery();
            conectateSQL.Close();
            MostrarContenido();
            Fade(bor, 0, 0.1);
            Fade(nvoId, 0, 0.1);
            Fade(nvoTitulo, 0, 0.1);
            Fade(nvoAutor, 0, 0.1);
            Fade(nvoGenero, 0, 0.1);
            Fade(nvoPaginas, 0, 0.1);
            Fade(uId, 0, 0.1);
            Fade(uTitulo, 0, 0.1);
            Fade(uAutor, 0, 0.1);
            Fade(uGenero, 0, 0.1);
            Fade(uPaginas, 0, 0.1);
            Fade(btnActualizar1, 0, 0.1);
        }
    }

}
