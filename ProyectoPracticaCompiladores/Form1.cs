using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPracticaCompiladores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            //Valores de inicio de las cajas de texto
            String valores = txtEntrada.Text;
            String reservada = "";
            String noReservada = "";
            String operadores = "";

            //Valores de Patterns para sentencias condicionales
            String ptnIf = "if";
            String ptnSwitch = "switch";
            String ptnWhile = "while";
            String ptnDo = "do";
            String ptnFor = "for";
            String ptnForEach = "foreach";

            //Valores de Patterns para tipos de datos
            String ptnString = "string";
            String ptnInt = "int";
            String ptnDouble = "double";
            String ptnBoolean = "boolean";
            String ptnFloat = "float";
            String ptnChar = "char";
            String ptnConst = "const";

            int seleccion = 0;
            if (Regex.Match(valores, "}$").Success)
            {
                seleccion = 1;
            }
            else if (Regex.Match(valores, ";$").Success)
            {
                seleccion = 2;
            }
            else
            {
                MessageBox.Show("Error de sintaxis", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEntrada.Clear();
            }

            if (seleccion == 1)
            {
                if (Regex.Match(valores, @"\Aif").Success || Regex.Match(valores, @"\Aswitch").Success || Regex.Match(valores, @"\Awhile").Success || Regex.Match(valores, @"\Ado").Success || Regex.Match(valores, @"\Afor").Success || Regex.Match(valores, @"\Aforeach").Success)
                {
                    switch (true)
                    {
                        //esta mrd está pndja xd
                        case bool _ when Regex.IsMatch(valores, ptnIf):
                            reservada = "if";
                            valores = valores.Replace("if", "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnSwitch):
                            reservada = "switch";
                            valores = valores.Replace("switch", "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnWhile):
                            reservada = "while";
                            valores = valores.Replace("while", "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnDo):
                            reservada = "do";
                            valores = valores.Replace("do", "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnForEach):
                            reservada = "foreach";
                            valores = valores.Replace("foreach", "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnFor):
                            reservada = "for";
                            valores = valores.Replace("for", "");
                            break;
                        default:
                            MessageBox.Show("No se encontró ninguna sintaxis", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                    seleccion = 2;
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna sintaxis", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEntrada.Clear();
                }
            }
            if (seleccion == 2)
            {
                switch (true)
                {
                    case bool _ when Regex.IsMatch(valores, ptnString):
                        reservada = "string";
                        valores = valores.Replace("string", "");
                        break;
                }
                valores = valores.Replace(";", "");

            }
            switch (true)
            {
                case bool _ when Regex.IsMatch(valores, "<="):
                    operadores = "Menor igual";
                    break;
                case bool _ when Regex.IsMatch(valores, ">="):
                    operadores = "Mayor igual";
                    break;
                case bool _ when Regex.IsMatch(valores, "=="):
                    operadores = "Igual";
                    break;
                case bool _ when Regex.IsMatch(valores, "!="):
                    operadores = "Diferente";
                    break;
                case bool _ when Regex.IsMatch(valores, "<"):
                    operadores = "Menor";
                    break;
                case bool _ when Regex.IsMatch(valores, ">"):
                    operadores = "Mayor";
                    break;
                case bool _ when Regex.IsMatch(valores, @"\+\+"):
                    operadores = "Aumento";
                    break;
                case bool _ when Regex.IsMatch(valores, "--"):
                    operadores = "Disminución";
                    break;
            }

            //Salida de las cajas de texto
            txtReservadas.Text = reservada;
            txtNoReservadas.Text = noReservada;
            txtOperadores.Text = operadores;

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtEntrada.Clear();
            txtReservadas.Clear();
            txtNoReservadas.Clear();
            txtOperadores.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
