using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordenar
{
    public partial class Form1 : Form
    {
        private List<int> numeros = new List<int>();
        public Form1()
        {
            InitializeComponent();

        }
        private List<int> listaNumeros = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            string numero = textBoxInsertar.Text;
            try
            {
                int parsedNumber = ParseNumero(numero);
                numeros.Add(parsedNumber);
                Números.Items.Add(parsedNumber);
                textBoxInsertar.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ParseNumero(string numero)
        {
            if (int.TryParse(numero, out int parsedNumber))
            {
                return parsedNumber;
            }
            else
            {
                throw new FormatException();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdenarAscendente(numeros);
            ActualizarListBox();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            OrdenarDescendente(numeros);
            ActualizarListBox();
        }
        private void OrdenarAscendente(List<int> lista)
        {
            lista.Sort();
        }

        private void OrdenarDescendente(List<int> lista)
        {
            lista.Sort();
            lista.Reverse();
        }

        private void ActualizarListBox()
        {
            Números.Items.Clear();
            Números.Items.AddRange(numeros.Select(n => (object)n).ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                int numeroBuscado = int.Parse(textBoxBuscar.Text);
                int indice = BuscarNumero(numeroBuscado);

                if (indice != -1)
                {
                    Números.SelectedIndex = indice;
                    MessageBox.Show($"El número {numeroBuscado} se encuentra en la posición {indice}.");
                }
                else
                {
                    MessageBox.Show($"El número {numeroBuscado} no se encuentra en la lista.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un número válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }
            textBoxBuscar.Clear(); // Limpiar el textBoxBuscar
        }

        private int BuscarNumero(int numero)
        {
            for (int i = 0; i < Números.Items.Count; i++)
            {
                int numeroActual = (int)Números.Items[i];
                if (numeroActual == numero)
                {
                    return i; // Se encontró el número en la posición i
                }
            }

            return -1; // El número no se encontró en la lista
        }
        private int BuscarNumeroRecursivo(int numero, int inicio, int fin)
        {
            if (inicio > fin)
            {
                return -1; // El número no se encontró en la lista
            }

            int medio = (inicio + fin) / 2;
            int numeroMedio = (int)Números.Items[medio];

            if (numero == numeroMedio)
            {
                return medio; // Se encontró el número en la posición medio
            }
            else if (numero < numeroMedio)
            {
                return BuscarNumeroRecursivo(numero, inicio, medio - 1); // Buscar en la mitad izquierda
            }
            else
            {
                return BuscarNumeroRecursivo(numero, medio + 1, fin); // Buscar en la mitad derecha
            }
        }
        private void EliminarNumero(int numero)
        {
            bool eliminado = false;

            for (int i = Números.Items.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt32(Números.Items[i]) == numero)
                {
                    Números.Items.RemoveAt(i);
                    eliminado = true;
                }
            }

            if (eliminado)
            {
                MessageBox.Show($"El número {numero} ha sido eliminado de la lista.");
            }
            else
            {
                MessageBox.Show($"El número {numero} no se encuentra en la lista.");
            }

            textBoxEliminar.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                int numeroEliminar = int.Parse(textBoxEliminar.Text);
                EliminarNumero(numeroEliminar);

            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un número válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }
        }

        private void MostrarLista()
        {
            Números.Items.Clear();
            foreach (var numero in listaNumeros)
            {
                Números.Items.Add(numero);
            }
        }
    }
}































