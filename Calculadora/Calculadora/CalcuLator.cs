using System.Runtime.InteropServices;

namespace Calculadora
{
    public partial class CalcuLator : Form
    {
        DialogResult d;
        double resultado = 0;
        string operacion = "";
        bool UseOperacion = false;
        public CalcuLator()
        {
            InitializeComponent();
            
        }
      


        private void Form1_Load(object sender, EventArgs e)
        {
         
            Opacity = 0.95;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            CalcScreen.Text = "0";
        }

      

        private void btn_Click(object sender, EventArgs e)
        {   
            if((CalcScreen.Text == "0") || UseOperacion){
                CalcScreen.Text = "";
            }
            UseOperacion = false;



            Button boton = (Button)sender;
            if (boton.Text == ".")
            {
                if (!CalcScreen.Text.Contains("."))

                    CalcScreen.Text = CalcScreen.Text + boton.Text;
            }
            else
            
                CalcScreen.Text = CalcScreen.Text + boton.Text;
            
            
            
        }

        private void simb_click(object sender, EventArgs e)
        {
            Button button = (Button)sender; 
            operacion = button.Text;
            resultado = double.Parse(CalcScreen.Text);
            lblHistorial.Text = resultado + " " + operacion;
            UseOperacion = true; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalcScreen.Text = "";
            lblHistorial.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            ListViewGroup Resultados = new ListViewGroup("Resultados", HorizontalAlignment.Left);
            switch (operacion)
            {

                case "+":
                    CalcScreen.Text = (resultado + Double.Parse(CalcScreen.Text)).ToString();
                    ListaResultados.Items.Add(CalcScreen.Text);
                    break;
                case "x":
                    if (Double.Parse(CalcScreen.Text) == 0 && resultado > 0) 
                    {
                        d= MessageBox.Show("Al parecer multiplicaste por 0, en este universo aun es imposible. Vuelve a intentar el calculo por favor", "Error de universo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (d == DialogResult.Yes)
                        {
                            Close();
                        }
                      
                   
                    }
                    else
                    {
                        CalcScreen.Text = (resultado * Double.Parse(CalcScreen.Text)).ToString();
                        ListaResultados.Items.Add(CalcScreen.Text);
                    }
                    break;
                case "-":
                    CalcScreen.Text = (resultado - Double.Parse(CalcScreen.Text)).ToString();
                    ListaResultados.Items.Add(CalcScreen.Text);
                    break;
                case "/":
                    CalcScreen.Text = (resultado / Double.Parse(CalcScreen.Text)).ToString();
                    ListaResultados.Items.Add(CalcScreen.Text);
                    break;
            }
        }

       
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}