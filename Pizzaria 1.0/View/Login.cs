using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria_1._0.View
{   
    public partial class Login : Form
    {

        static Abertura tela = new Abertura();

        string login = "1";
        string senha = "1";
        int exec = 0;


        public Login()
        {            
            try
            {
                if (exec == 0)
                {
                    tela.Show();
                    exec++;
                    var t = Task.Run(async delegate
                    {
                        await Task.Delay(3000);
                        InitializeComponent();
                    });
                    t.Wait();
                }
                else
                {
                    InitializeComponent();
                }
            }
            catch
            {
                MessageBox.Show("Erro não identificado, por favor, tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            tela.Dispose();

            if (txtLogin.Text.Equals(login) && txtSenha.Text.Equals(senha))
            {
                PDV pdv = new PDV();
                pdv.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário e senha inválidos!");
            }
        }
    }
}
