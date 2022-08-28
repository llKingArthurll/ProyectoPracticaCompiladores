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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            //Valores de inicio de las cajas de texto
            String valores = txtEntrada.Text;
            valores = valores.ToLower();
            String valores1 = valores;
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
            String ptnElse = "else";
            String ptnSwitch = "switch";
            String ptnBreak = "break";
            String ptnCase = "case";
            String ptnWhile = "while";
            String ptnDo = "do";
            String ptnFor = "for";
            String ptnForEach = "foreach";
            String ptnReturn = "return";
            String ptnArray = "array";
            //String ptnNull = "null";

            //Valores de Patterns para tipos de datos
            String ptnString = "string";
            String ptnMostrar = "mostrar";
            String ptnInt = "int";
            String ptnDouble = "double";
            String ptnBoolean = "bool";
            String ptnFloat = "float";
            String ptnChar = "char";
            String ptnConst = "const";

            //Valor de Pattern para Inicio de Programa
            String ptnInicio = "iniciamos";

            //Valor de Pattern para Fin de Programa
            String ptnFin = "terminamos";

            //Seleccion de estados para pasar
            int estado = 0;
            int seleccion = 0;
            int acceso;  //Shhhhshh
            bool error = true;

            //Valida que FIN del programa
            if (Regex.Match(valores, @"}(\s*)(terminamos)", RegexOptions.Multiline).Success)
            {
                valores = valores.Replace("\r\n" + ptnFin, "");
                reservada = reservada + ptnFin + "\r\n";
                //MessageBox.Show(valores + ": DETECTADO");
                estado = 1;
            }
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
                //txtEntrada.Clear();
                return;
            }

            //Validando el inicio del programa
            if (estado == 1)
            {
                acceso = 0;
                //Valida que inicie en INICIAMOS
                if (Regex.Match(valores, @"\A" + ptnInicio).Success)
                {
                    valores = valores.Replace(ptnInicio, "");
                    reservada = reservada + ptnInicio + "\r\n";
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
                                MessageBox.Show("1: " + valores);
                                //(){stringnombre="fiore";}
                                seleccion = 1;
                                //Valida si empieza con {
                                //if (Regex.Match(valores, "}$").Success)
                                //{
                                //    valores = valores.Replace("{", "");
                                //    seleccion = 1;
                                //    valores = valores.Replace("}", "");
                                //}

                            }
                        }
                        else if (Regex.Match(valores, "(\\w\\S+)[\\(]").Success)
                        {
                            MessageBox.Show("1: " + valores);
                            //    Funtion1
                            //O tmb seleccion 1
                            seleccion = 1;
                            MessageBox.Show("2: " + valores);
                        }
                    }
                    //    Funtion1
                    //O tmb seleccion 1
                    seleccion = 1;
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
                if (Regex.Match(valores, ptnString).Success || Regex.Match(valores, @".*" + ptnElse).Success || Regex.Match(valores, @"\A" + ptnInt).Success || Regex.Match(valores, @"\A" + ptnDouble).Success || Regex.Match(valores, @"\A" + ptnBoolean).Success || Regex.Match(valores, @"\A" + ptnFloat).Success || Regex.Match(valores, @"\A" + ptnChar).Success || Regex.Match(valores, @"\A" + ptnConst).Success || Regex.Match(valores, @"\A" + ptnReturn).Success || Regex.Match(valores, @"\A" + ptnCase).Success || Regex.Match(valores, @".*" + ptnBreak).Success || Regex.Match(valores, @"\A" + ptnMostrar).Success || Regex.Match(valores, @"\A" + ptnArray).Success)
                {
                    while (error == true)
                    {
                        switch (true)
                        {
                            case bool _ when Regex.IsMatch(valores, ptnConst):
                                reservada = reservada + ptnConst + "\r\n";
                                valores = valores.Replace("const", "");
                                break;
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
                                    //txtEntrada.Clear();
                                }
                                break;
                            case bool _ when Regex.IsMatch(valores, ptnChar):
                                reservada = reservada + ptnChar + "\r\n";
                                valores = valores.Replace(ptnChar, "");
                                break;
                            default:
                                error = false;
                                break;
                        }
                    }
                }
                if (Regex.Match(valores, ptnIf).Success || Regex.Match(valores, ptnElse).Success || Regex.Match(valores,ptnSwitch).Success || Regex.Match(valores,ptnWhile).Success || Regex.Match(valores,ptnDo).Success || Regex.Match(valores,ptnFor).Success || Regex.Match(valores, ptnForEach).Success || Regex.Match(valores,ptnMostrar).Success || Regex.Match(valores,ptnArray).Success)
                {
                    switch (true)
                    {
                        case bool _ when Regex.IsMatch(valores, ptnIf):
                            reservada = reservada + ptnIf + "\r\n";
                            valores = valores.Replace(ptnIf, "");
                            seleccion = 3;
                            break;
                        //case bool _ when Regex.IsMatch(valores, ptnElse):
                        //    reservada = reservada + ptnElse + "\r\n";
                        //    valores = valores.Replace(ptnElse, "");
                        //    seleccion = 3;
                        //    MessageBox.Show("FUNCA seleccion3");
                        //    break;
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
                            return;
                    }
                }
            }

            //Ejecución de las sentencias de asignaciones
            if (seleccion == 2)
            {
                if (Regex.Match(valores, ptnString).Success || Regex.Match(valores, ptnElse).Success || Regex.Match(valores,ptnInt).Success || Regex.Match(valores, ptnDouble).Success || Regex.Match(valores, ptnBoolean).Success || Regex.Match(valores,ptnFloat).Success || Regex.Match(valores,ptnChar).Success || Regex.Match(valores, ptnConst).Success || Regex.Match(valores, ptnReturn).Success || Regex.Match(valores, ptnCase).Success || Regex.Match(valores, ptnBreak).Success || Regex.Match(valores, ptnMostrar).Success || Regex.Match(valores, ptnArray).Success)
                {
                    while (error == true)
                    {
                        switch (true)
                        {
                            case bool _ when Regex.IsMatch(valores, ptnConst):
                                reservada = reservada + ptnConst + "\r\n";
                                valores = valores.Replace("const", "");
                                break;
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
                                    return;
                                    //txtEntrada.Clear();
                                }
                                break;
                            case bool _ when Regex.IsMatch(valores, ptnChar):
                                reservada = reservada + ptnChar + "\r\n";
                                valores = valores.Replace(ptnChar, "");
                                break;
                            //case bool _ when Regex.IsMatch(valores, ptnElse):
                            //    reservada = reservada + ptnElse + "\r\n";
                            //    valores = valores.Replace(ptnElse, "");
                            //    break;
                            default:
                                error = false;
                                break;
                        }
                    }
                    error = true;
                    seleccion = 3;
                }
            }
            if (seleccion == 3)
            {
                while (error == true)
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
                        case bool _ when Regex.IsMatch(valores, ptnArray):
                            reservada = reservada + ptnArray + "\r\n";
                            valores = valores.Replace(ptnArray, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnReturn):
                            reservada = reservada + ptnReturn + "\r\n";
                            valores = valores.Replace(ptnReturn, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnCase):
                            reservada = reservada + ptnCase + "\r\n";
                            valores = valores.Replace(ptnCase, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnBreak):
                            reservada = reservada + ptnBreak + "\r\n";
                            valores = valores.Replace(ptnBreak, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnElse):
                            reservada = reservada + ptnElse + "\r\n";
                            valores = valores.Replace(ptnElse, "");
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
                                return;
                                //txtEntrada.Clear();
                            }
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnChar):
                            reservada = reservada + ptnChar + "\r\n";
                            valores = valores.Replace(ptnChar, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnMostrar):
                            reservada = reservada + ptnMostrar + "\r\n";
                            valores = valores.Replace(ptnMostrar, "");
                            break;
                        case bool _ when Regex.IsMatch(valores, ptnConst):
                            reservada = reservada + ptnConst + "\r\n";
                            valores = valores.Replace("const", "");
                            break;

                        default:
                            error = false;
                            break;

                    }
                }
                error = true;
                seleccion = 4;

            }
            if (seleccion == 4)
            {
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
                        case bool _ when Regex.IsMatch(valores, @"\*"):
                            operadores = operadores + "*" + "\r\n";
                            valores = valores.Replace("*", "\r\n");
                            break;
                        case bool _ when Regex.IsMatch(valores, @"\/"):
                            operadores = operadores + "/" + "\r\n";
                            valores = valores.Replace("/", "\r\n");
                            break;
                        case bool _ when Regex.IsMatch(valores, @"\%"):
                            operadores = operadores + "%" + "\r\n";
                            valores = valores.Replace("%", "\r\n");
                            break;
                        case bool _ when Regex.IsMatch(valores, "=="):
                            operadores = operadores + "==" + "\r\n";
                            valores = valores.Replace("==", "\r\n");
                            break;
                        case bool _ when Regex.IsMatch(valores, @"\^"):
                            operadores = operadores + "^" + "\r\n";
                            valores = valores.Replace("^", "\r\n");
                            break;
                        default:
                            error = false;
                            break;
                    }
                }
            }

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
    }
}