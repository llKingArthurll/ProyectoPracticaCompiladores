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
            String noReservada;
            String operadores = "";

            //Valores de Patterns para tipos de accesos
            String ptnPublic = "public";
            String ptnPrivate = "private";
            String ptnMain = "main";
            String ptnStatic = "static";
            String ptnVoid = "void";

            //Valores de Patterns para sentencias condicionales
            String ptnIf = "if";
            String ptnSwitch = "switch";
            String ptnWhile = "while";
            String ptnDo = "do";
            String ptnFor = "for";
            String ptnForEach = "foreach";
            //String ptnNull = "null";

            //Valores de Patterns para tipos de datos
            String ptnString = "string";
            String ptnInt = "int";
            String ptnDouble = "double";
            String ptnBoolean = "bool";
            String ptnFloat = "float";
            String ptnChar = "char";
            String ptnConst = "const";

            //Seleccion de estados para pasar
            int estado = 0;
            int seleccion = 0;
            int acceso;
            bool error = true;

            //Delimitador si termina con llave o punto y coma
            if (Regex.Match(valores, "}$").Success)
            {
                valores = valores.Replace("\r\n", "");
                valores = valores.Replace(" ", "");
                estado = 1;
            }
            else if (Regex.Match(valores, ";$").Success)
            {
                valores = valores.Replace(" ", "");
                estado = 2;
            }
            else
            {
                MessageBox.Show("Error al finalizar la sentencia", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEntrada.Clear();
            }

            //Validando el inicio del programa
            if (estado == 1)
            {
                //Valida si inicia en public o private
                switch (true)
                {
                    case bool _ when Regex.IsMatch(valores, @"\A" + ptnPublic):
                        valores = valores.Replace(ptnPublic, "");
                        reservada = reservada + ptnPublic + "\r\n";
                        acceso = 1;
                        break;
                    case bool _ when Regex.IsMatch(valores, @"\A" + ptnPrivate):
                        valores = valores.Replace(ptnPrivate, "");
                        reservada = reservada + ptnPrivate + "\r\n";
                        acceso = 1;
                        break;
                    default:
                        acceso = 2;
                        break;
                }
                if (acceso == 1)
                {
                    //Valida si continua static
                    if (Regex.Match(valores, @"\A" + ptnStatic).Success)
                    {
                        valores = valores.Replace(ptnStatic, "");
                        reservada = reservada + ptnStatic + "\r\n";
                        //Valida si continúa void
                        if (Regex.Match(valores, @"\A" + ptnVoid).Success)
                        {
                            valores = valores.Replace(ptnVoid, "");
                            reservada = reservada + ptnVoid + "\r\n";
                            //Valida si continúa main
                            if (Regex.Match(valores, @"\A" + ptnMain).Success)
                            {
                                valores = valores.Replace(ptnMain, "");
                                reservada = reservada + ptnMain + "\r\n";
                                //Valida si empieza con {
                                if (Regex.Match(valores, @"\A{").Success)
                                {
                                    valores = valores.Replace("{", "");
                                    valores = valores.Replace("}", "");
                                    seleccion = 1;
                                }
                            }
                        }
                    }
                }
                else if (acceso == 2)
                {
                    seleccion = 1;
                }
            }
            else if (estado == 2)
            {
                seleccion = 2;
            }
            //Ejecución de patterns para sentencias condicionales
            if (seleccion == 1)
            {
                if (Regex.Match(valores, @"\A" + ptnIf).Success || Regex.Match(valores, @"\A" + ptnSwitch).Success || Regex.Match(valores, @"\A" + ptnWhile).Success || Regex.Match(valores, @"\A" + ptnDo).Success || Regex.Match(valores, @"\A" + ptnFor).Success || Regex.Match(valores, @"\A" + ptnForEach).Success)
                {
                    switch (true)
                    {
                        case bool _ when Regex.IsMatch(valores, ptnIf):
                            reservada = reservada + ptnIf + "\r\n";
                            valores = valores.Replace(ptnIf, "");
                            seleccion = 3;
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnSwitch):
                            reservada = reservada + ptnSwitch + "\r\n";
                            valores = valores.Replace(ptnSwitch, "");
                            seleccion = 3;
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnWhile):
                            reservada = reservada + ptnWhile + "\r\n";
                            valores = valores.Replace(ptnWhile, "");
                            seleccion = 3;
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnDo):
                            reservada = reservada + ptnDo + "\r\n";
                            valores = valores.Replace(ptnDo, "");
                            seleccion = 3;
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnForEach):
                            reservada = reservada + ptnForEach + "\r\n";
                            valores = valores.Replace(ptnForEach, "");
                            seleccion = 3;
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnFor):
                            reservada = reservada + ptnFor + "\r\n";
                            valores = valores.Replace(ptnFor, "");
                            seleccion = 3;
                            break;
                        default:
                            MessageBox.Show("¡Error de sintaxis!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Error de sintaxis, favor de revisar la escritura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEntrada.Clear();
                }
            }

            //Ejecución de las sentencias de asignaciones
            if (seleccion == 2)
            {
                if (Regex.Match(valores, @"\A" + ptnString).Success || Regex.Match(valores, @"\A" + ptnInt).Success || Regex.Match(valores, @"\A" + ptnDouble).Success || Regex.Match(valores, @"\A" + ptnBoolean).Success || Regex.Match(valores, @"\A" + ptnFloat).Success || Regex.Match(valores, @"\A" + ptnChar).Success || Regex.Match(valores, @"\A" + ptnConst).Success)
                {
                    switch (true)
                    {
                        case bool _ when Regex.IsMatch(valores, ptnString):
                            reservada = reservada + ptnString + "\r\n";
                            valores = valores.Replace(ptnString, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnInt):
                            reservada = reservada + ptnInt + "\r\n";
                            valores = valores.Replace(ptnInt, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnDouble):
                            reservada = reservada + ptnDouble + "\r\n";
                            valores = valores.Replace(ptnDouble, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnBoolean):
                            reservada = reservada + ptnBoolean + "\r\n";
                            valores = valores.Replace(ptnBoolean, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnFloat):
                            if (Regex.Match(valores, "f$").Success)
                            {
                                reservada = reservada + ptnFloat + "\r\n";
                                reservada = reservada + "f" + "\r\n";
                                valores = valores.Replace(ptnFloat, "");
                                valores = valores.Replace("f", "");
                            }
                            else
                            {
                                MessageBox.Show("Error de sintaxis, favor de revisar la escritura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtEntrada.Clear();
                            }
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnChar):
                            reservada = reservada + ptnChar + "\r\n";
                            valores = valores.Replace(ptnChar, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnConst):
                            reservada = reservada + ptnConst + "\r\n";
                            valores = valores.Replace("const", "");
                            break;
                        default:
                            MessageBox.Show("Error de sintaxis, favor de revisar la escritura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtEntrada.Clear();
                            break;
                    }
                }
            }
            if (seleccion == 3)
            {
                switch (true)
                {
                    case bool _ when Regex.IsMatch(valores, ptnString):
                        reservada = reservada + ptnString + "\r\n";
                        valores = valores.Replace(ptnString, "");
                        break;
                    case bool _ when Regex.IsMatch(valores, ptnInt):
                        reservada = reservada + ptnInt + "\r\n";
                        valores = valores.Replace(ptnInt, "");
                        break;
                    case bool _ when Regex.IsMatch(valores, ptnDouble):
                        reservada = reservada + ptnDouble + "\r\n";
                        valores = valores.Replace(ptnDouble, "");
                        break;
                    case bool _ when Regex.IsMatch(valores, ptnBoolean):
                        reservada = reservada + ptnBoolean + "\r\n";
                        valores = valores.Replace(ptnBoolean, "");
                        break;
                    case bool _ when Regex.IsMatch(valores, ptnFloat):
                        if (Regex.Match(valores, "f$").Success)
                        {
                            reservada = reservada + ptnFloat + "\r\n";
                            reservada = reservada + "f" + "\r\n";
                            valores = valores.Replace(ptnFloat, "");
                            valores = valores.Replace("f", "");
                        }
                        else
                        {
                            MessageBox.Show("Error de sintaxis, favor de revisar la escritura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtEntrada.Clear();
                        }
                        break;
                    case bool _ when Regex.IsMatch(valores, ptnChar):
                        reservada = reservada + ptnChar + "\r\n";
                        valores = valores.Replace(ptnChar, "");
                        break;
                    case bool _ when Regex.IsMatch(valores, ptnConst):
                        reservada = reservada + ptnConst + "\r\n";
                        valores = valores.Replace("const", "");
                        break;
                    default:
                        MessageBox.Show("Error de sintaxis, favor de revisar la escritura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEntrada.Clear();
                        break;
                }
            }
            while (error == true)
            {
                switch (true)
                {
                    case bool _ when Regex.IsMatch(valores, "<="):
                        operadores = operadores + "<=" + "\r\n";
                        valores = valores.Replace("<=", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, ">="):
                        operadores = operadores + ">=" + "\r\n";
                        valores = valores.Replace(">=", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, "!="):
                        operadores = operadores + "!=" + "\r\n";
                        valores = valores.Replace("!=", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, @"\+\+"):
                        operadores = operadores + "++" + "\r\n";
                        valores = valores.Replace("++", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, "--"):
                        operadores = operadores + "--" + "\r\n";
                        valores = valores.Replace("--", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, "<"):
                        operadores = operadores + "<" + "\r\n";
                        valores = valores.Replace("<", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, ">"):
                        operadores = operadores + ">" + "\r\n";
                        valores = valores.Replace(">", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, "="):
                        operadores = operadores + "=" + "\r\n";
                        valores = valores.Replace("=", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, @"\+"):
                        operadores = operadores + "+" + "\r\n";
                        valores = valores.Replace("+", "\r\n");
                        break;
                    case bool _ when Regex.IsMatch(valores, "-"):
                        operadores = operadores + "-" + "\r\n";
                        valores = valores.Replace("-", "\r\n");
                        break;
                    default:
                        error = false;
                        break;
                }
            }

            //Valores Finales
            noReservada = valores;
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
