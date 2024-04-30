﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora {
    public partial class frmCalculus : Form {
        double ValorAnterior;
        string operacao;
        bool primeiraoperacao = true;
        double resultado;
        public frmCalculus() {
            InitializeComponent();
        } private void Clicou_Click(object sender, EventArgs e) {
            Button botaoApertado = (Button)sender;

            if (txtVisor.Text == "0") {
                txtVisor.Clear();
            } switch (botaoApertado.Name) {
                case "btnOne":
                    txtVisor.AppendText("1");
                break;
                case "btnTwo":
                    txtVisor.Text += "2";
                break;
                case "btnThree":
                    txtVisor.Text += "3";
                break;
                case "btnFour":
                txtVisor.Text += "4";
                break;
                case "btnFive":
                    txtVisor.Text += "5";
                break;
                case "btnSix":
                    txtVisor.Text += "6";
                break;
                case "btnSeven":
                    txtVisor.Text += "7";
                break;
                case "btnEight":
                    txtVisor.Text += "8";
                break;
                case "btnNine":
                    txtVisor.Text += "9";
                break;
                case "btnZero":
                    txtVisor.Text += "0";
                break;
                case "btnDot":
                    if(txtVisor.Text == "") {
                        txtVisor.Text += "0.";
                    } else {
                        txtVisor.Text += ".";
                    } break;
            }
        }
        private void btnClean_Click(object sender, EventArgs e) {
            txtVisor.Clear();
            txtHistory.Clear();
            txtVisor.Text = "0";
            ValorAnterior = 0;
            primeiraoperacao = true;
        }
        private void btnBack_Click(object sender, EventArgs e) {
            if (txtVisor.Text != "") {
                 txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            double calculoAnterior;
            if (txtVisor.Text != ""){
                if (primeiraoperacao == true) {
                    ValorAnterior = double.Parse(txtVisor.Text);
                    txtHistory.Text += txtVisor.Text + "+";
                    txtVisor.Clear();
                    operacao = "+";
                    primeiraoperacao = false;
                } else if (operacao == "√") {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text =  valorRaiz + "+";
                    
                    ValorAnterior = valorRaiz;
                    operacao = "+"; 
                } else {
                    calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "+";
                    txtVisor.Clear();
                    ValorAnterior = calculoAnterior;
                    operacao = "+";
                }
            }
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "") {
                if (primeiraoperacao == true) {
                    ValorAnterior = double.Parse(txtVisor.Text);
                    txtHistory.Text += txtVisor.Text + "-";
                    txtVisor.Clear();
                    operacao = "-";
                    primeiraoperacao = false;
                } else if (operacao == "√") {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text = valorRaiz + "-";

                    ValorAnterior = valorRaiz;
                    operacao = "-";
                } else {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "-";
                    txtVisor.Clear();
                    ValorAnterior = calculoAnterior;
                    operacao = "-";
                }
            }
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if(txtVisor.Text != "") {
                if (primeiraoperacao == true) {
                    ValorAnterior = double.Parse(txtVisor.Text);
                    txtHistory.Text = txtVisor.Text + "x";
                    txtVisor.Clear();
                    operacao = "x";
                    primeiraoperacao = false;

                } else if (operacao == "√") {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text = valorRaiz + "x";

                    ValorAnterior = valorRaiz;
                    operacao = "x";

                } else {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "x";
                    txtVisor.Clear();
                    ValorAnterior = calculoAnterior;
                    operacao = "x";
                }
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "")
            {
                if (primeiraoperacao == true)
                {
                    ValorAnterior = double.Parse(txtVisor.Text);
                    txtHistory.Text = txtVisor.Text + "/";
                    txtVisor.Clear();
                    operacao = "/";
                    primeiraoperacao = false;

                }
                else if (operacao == "√")
                {
                    double valorRaiz = double.Parse(txtVisor.Text);
                    txtVisor.Clear();
                    txtHistory.Text = valorRaiz + "/";

                    ValorAnterior = valorRaiz;
                    operacao = "/";

                }
                else
                {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = Convert.ToString(calculoAnterior) + "/";
                    txtVisor.Clear();
                    ValorAnterior = calculoAnterior;
                    operacao = "/";
                }
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (txtVisor.Text != "")
            {
                if (primeiraoperacao == true)
                {
                    ValorAnterior = double.Parse(txtVisor.Text);
                    txtHistory.Text = "Raiz " + txtVisor.Text;
                    operacao = "√";
                    txtVisor.Text = Convert.ToString(Calculo());
                    
                    primeiraoperacao = false;

                }
                else
                {
                    double calculoAnterior = Calculo();

                    txtHistory.Text = "Raiz " + calculoAnterior;
                    txtVisor.Text = Convert.ToString(Math.Sqrt(calculoAnterior));
                    ValorAnterior = double.Parse(txtVisor.Text);
                    operacao = "√";
                }
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            txtVisor.Text = Convert.ToString(Calculo());
            txtHistory.Clear();
            primeiraoperacao = true;
        }
        public double Calculo()
        {
            double Valor = double.Parse(txtVisor.Text);
            switch (operacao)
            {
                case "+":
                     resultado = ValorAnterior + Valor;
                    break;
                case "-":
                    resultado = ValorAnterior - Valor;
                    break;
                case "x":
                    resultado = ValorAnterior * Valor;
                    break;
                case "/":
                    resultado = ValorAnterior / Valor;
                    break;
                case "√":
                    resultado = Math.Sqrt(double.Parse(txtVisor.Text));
                    break;
            }
            return resultado;
        }
    }
}
