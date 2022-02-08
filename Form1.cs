using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace EditorTexto {
    public partial class frmEditor : Form {

        StringReader leitura = null; 

        public frmEditor() {
            InitializeComponent();
        }

        private void sirToolStripMenuItem_Click(object sender, EventArgs e) {
            Close(); 
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 se = new AboutBox1();
            se.ShowDialog(); 
        }

        private void btnAbrir_Click(object sender, EventArgs e) {
            abrir(); 
        }

        private void novo() {
            richTextBox1.Clear();
            richTextBox1.Focus(); 

        }

        private void abrir() {
            this.openFileDialog1.Title = "Abrir arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\thiag\Documents\CFB Cursos\Aulas\Parte2\EditorTexto\";
            openFileDialog1.Filter = "(*.TXT)|*.TXT";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK) {
                try {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName,FileMode.Open,FileAccess.Read);
                    StreamReader leitor = new StreamReader(arquivo);
                    leitor.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Clear();
                    string linha = leitor.ReadLine(); 
                    while(linha != null) {
                        this.richTextBox1.Text += linha + "\n";
                        linha = leitor.ReadLine(); 

                    }
                    leitor.Close(); 
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro de leitura: " + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       private void salvar() {
            try {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter cfb_stream_writer = new StreamWriter(arquivo);
                    cfb_stream_writer.Flush();
                    cfb_stream_writer.BaseStream.Seek(0, SeekOrigin.Begin);
                    cfb_stream_writer.Write(this.richTextBox1.Text);
                    cfb_stream_writer.Flush();
                    cfb_stream_writer.Close(); 
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Erro na gravação: " + ex.Message, "Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            novo(); 
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e) {
            novo(); 
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            salvar(); 
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e) {
            salvar(); 
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e) {
            abrir(); 
        }

        private void copiar() {
            if(richTextBox1.SelectionLength > 0) {
                richTextBox1.Copy();
            }
        }
        private void recortar() {
            if(richTextBox1.SelectionLength > 0) {
                richTextBox1.Cut(); 
            }
        }

        private void colar() {
            richTextBox1.Paste(); 
        }

        private void btnCopiar_Click(object sender, EventArgs e) {
            copiar(); 
        }

        private void btnColar_Click(object sender, EventArgs e) {
            colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e) {
            copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e) {
            colar();
        }

        private void negrito() {

            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;
            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);

            if (n == false) {
                if (i == true & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == true & s == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (i == false & s == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
            }
            else {
                if (i == true & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (i == true & s == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
        }

        private void italico() {

            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;
            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);

            if (i == false) { 
                if (n == true & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == false & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == true & s == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false & s == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
            else {
                if (n == true & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false & s == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (n == true & s == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
            }
        }

        private void sublinhado() {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool s = false, n = false, i = false;
            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);

            if (s == false) {
                if (n == true & i == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == false & i == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == true & i == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false & i == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
            }
            else {
                if (n == true & i == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false & i == true) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
                else if (n == true & i == false) {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
            }
        }

        private void alinharEsquerda() {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinharDireita() {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alinharCentro() {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void imprimir() {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto); 
            if(printDialog1.ShowDialog() == DialogResult.OK) {
                this.printDocument1.Print(); 
            }
        }



        private void btnNegrito_Click(object sender, EventArgs e) {
            negrito();
        }

        private void btnItalico_Click(object sender, EventArgs e) {
            italico(); 
        }

        private void btnSublinhado_Click(object sender, EventArgs e) {
            sublinhado(); 
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e) {
            negrito(); 
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e) {
            italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e) {
            sublinhado(); 
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e) {
            recortar(); 
        }

        private void btnRecortar_Click(object sender, EventArgs e) {
            recortar(); 
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e) {
            alinharCentro(); 
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e) {
            alinharEsquerda(); 
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e) {
            alinharDireita(); 
        }

        private void btnEsquerda_Click(object sender, EventArgs e) {
            alinharEsquerda();
        }

        private void btnCentro_Click(object sender, EventArgs e) {
            alinharCentro();
        }

        private void btnDireita_Click(object sender, EventArgs e) {
            alinharDireita();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e) {
            imprimir(); 
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            float linhasPagina = 0;
            float PosY = 0;
            int contador = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            if(margemEsquerda < 5) {
                margemEsquerda = 20; 
            }
            
            if (margemSuperior < 5) {
                margemSuperior = 20;
            }
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black); 
        }
    }
}
