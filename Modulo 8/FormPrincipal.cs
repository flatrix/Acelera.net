using System.Security.Policy;
using System.Windows.Forms;

namespace Modulo_8
{
    public partial class FormPrincipal : Form
    {
        Graphics g = null;
        int commits = 0;
        int posXCommit = 5;
        int posYCommit = 0;
        int larCommit = 60;
        int altCommit = 40;
        Branchs head;
        List<Branchs> listaBranchs = new List<Branchs>();


        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnComando_Click(object sender, EventArgs e)
        {
            g = pbGrafico.CreateGraphics();
            processaComando(txbComando.Text);
        }

        /// <summary>
        /// Faz o processamento do comando digitado pelo usuario
        /// </summary>
        /// <param name="comando">Comando digitado</param>
        private void processaComando(string comando)
        {
            lbStatus.Text = "";
            string[] comandos = comando.Split(' ');
            if (comandos.Length >= 2)
            {
                if (comandos[0] == "git")
                {
                    if (head != null)
                    {
                        switch (comandos[1])
                        {

                            case "commit":

                                if (comandos.Length > 2)
                                {
                                    string mensagem = comando.Substring(11, comando.Length - 11);
                                    mensagem = mensagem.Replace("\"", "");
                                    runCommit(mensagem);
                                }
                                else lbStatus.Text = "Digite a mensagem para o commit...";

                                break;
                            case "branch":
                                if (comandos.Length > 2)
                                {
                                    string nomeBranch = comandos[2];
                                    geraBranch(nomeBranch);
                                    
                                }
                                else lbStatus.Text = "Digite o nome do branch";
                                break;
                            default:
                                lbStatus.Text = "Comando GIT ainda não implementado";
                                break;
                        }
                    }
                    else
                    {
                        if (comandos[1] == "init")
                        {
                            posYCommit = pbGrafico.Height / 2;
                            head = new Branchs("MASTER");
                            head.PosX = posXCommit;
                            head.PosY = posYCommit;

                            listaBranchs.Add(head);
                            lbStatus.Text = "Git Iniciado";
                            desenhaInit();
                        }
                        else lbStatus.Text = "Git não foi iniciado";
                    }

                }
                else lbStatus.Text = "Comando: " + comandos[0] + " não reconhecido";
            }
            else lbStatus.Text = "Favor digitar o comando acima";
            txbComando.Text = "";
            txbComando.Focus();
        }

        private void geraBranch(string nomeBranch)
        {
            Branchs novoBranch = new Branchs(nomeBranch);
            novoBranch.PosX = head.PosX;
            novoBranch.PosY = head.PosY - altCommit;
            head = novoBranch;
            listaBranchs.Add(novoBranch);
            runBranch(head.Nome);
        }

        private void runBranch(string nome)
        {
            g.DrawLine(new Pen(Color.Blue, 1), new Point(head.PosX-15, head.PosY + (altCommit / 2)+altCommit), new Point(head.PosX, head.PosY + (altCommit / 2)));

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            g.DrawString("Branch:"+nome, new Font("Verdana", 10), Brushes.Blue, new PointF(head.PosX + (larCommit / 2)+15, head.PosY +altCommit+5), sf);
            
            head.PosX += 15;
        }

        private string geraHash(int v)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, v)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        private void desenhaInit()
        {
            posYCommit = pbGrafico.Height / 2;
            g = pbGrafico.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(0, 0, pbGrafico.Width, pbGrafico.Height));
        }

        private void runCommit(string mensagem)
        {
            string hash = geraHash(7);
            lbStatus.Text = "Executando COMMIT com a mensagem: \"" + mensagem + "\" - " + hash;
            desenhaCommit(mensagem, hash);
            commits++;

        }

        private void desenhaCommit(string mensagem, string hash)
        {
            g.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(head.PosX, head.PosY, larCommit, altCommit));

            g.DrawLine(new Pen(Color.Blue, 1), new Point(head.PosX , head.PosY+ (altCommit/2)), new Point(head.PosX -15, head.PosY + (altCommit/2)));

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            g.DrawString(hash, new Font("Verdana", 10), Brushes.Blue, new PointF(head.PosX + (larCommit / 2), head.PosY - 5), sf);

            g.DrawString(mensagem, new Font("Verdana", 8), Brushes.Red, new PointF(head.PosX + (larCommit / 2), head.PosY + (altCommit / 2)), sf);
            head.PosX += 15 + larCommit;
            commits++;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

            txbComando.Focus();
        }
    }
}