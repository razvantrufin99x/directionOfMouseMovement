namespace directionOfMouseMovement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Graphics g;


        //i can add the time here 

        public int prevposx=0, prevposy=0;
        public int cpointx = 0, cpointy = 0;

        public int difx = 0, dify = 0;

        public string direction(string left, string right, string up, string down)
        {

            string ret = "";

            if (left == "plus" && right == "plus") { ret = "ERROR"; return ret; }
            if (up == "plus" && down == "plus") { ret = "ERROR"; return ret; }

            //DELETE HALF FROM HERE
            if (left == "plus" && right == "minus") { ret = "RIGHT"; }
            else if (up == "plus") { ret += "+DOWN"; }
            else if (up == "minus") { ret += "+UP"; }
            else if (down == "plus") { ret += "+UP"; }
            else if (down == "minus") { ret += "+DOWN"; }
            ret += ":";
            if (right == "plus" && left == "minus") { ret += "LEFT"; }
            else if (up == "plus") { ret += "+DOWN"; }
            else if (up == "minus") { ret += "+UP"; }
            else if (down == "plus") { ret += "+UP"; }
            else if (down == "minus") { ret += "+DOWN"; }

            return ret;



        }


        public string determindirectionLeft(int curent, int precedent)
        {
            if (curent > precedent) { return "plus"; }
            else if (curent < precedent) { return "minus"; }
            return "EQUAL";
        }

        public string determindirectionRight(int curent, int precedent)
        {
            if (curent < precedent) { return "plus"; }
            else if (curent > precedent) { return "minus"; }
            return "EQUAL";
        }
        public string determindirectionUp(int curent, int precedent)
        {
            if (curent > precedent) { return "plus"; }
            else if (curent < precedent) { return "minus"; }
            return "EQUAL";
        }

        public string determindirectionDown(int curent, int precedent)
        {
            if (curent < precedent) { return "plus"; }
            else if (curent > precedent) { return "minus"; }
            return "EQUAL";
        }

        public int diferentaAB(int a, int b)
        {
            return a - b;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            cpointx = e.X;
            cpointy = e.Y;
        }

        public static float GetAngleOfLineBetweenTwoPoints(PointF p1, PointF p2)
        {
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return (float)(Math.Atan2(yDiff, xDiff) * (180 / Math.PI));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          g.Clear(BackColor);
        string L = determindirectionLeft(e.X, prevposx);
        string R = determindirectionRight(e.X, prevposx);
        string U = determindirectionUp(e.Y, prevposy);
        string D = determindirectionDown(e.Y, prevposy);

        string rezultat = direction(L, R, U, D);
        Text  = rezultat ;
        Text += ": L:" + diferentaAB(e.X,prevposx);
        Text += " T:" + diferentaAB(e.Y, prevposy);
      



            g.DrawLine(new Pen(Color.Black,1), new Point(e.X, e.Y), new Point(prevposx, prevposy));
            g.DrawLine(new Pen(Color.Red, 1), new Point(e.X, e.Y), new Point(cpointx, cpointy));
            g.DrawLine(new Pen(Color.Green, 1), new Point(prevposx, prevposy), new Point(cpointx, cpointy));

            g.DrawLine(new Pen(Color.Black, 1), new Point(0,0), new Point(prevposx, prevposy));
            g.DrawLine(new Pen(Color.Red, 1), new Point(0,0), new Point(cpointx, cpointy));
            g.DrawLine(new Pen(Color.Black, 1), new Point(Width, Height-20), new Point(prevposx, prevposy));
            g.DrawLine(new Pen(Color.Red, 1), new Point(Width, Height-20), new Point(cpointx, cpointy));

            g.DrawLine(new Pen(Color.Black, 1), new Point(Width, 0), new Point(prevposx, prevposy));
            g.DrawLine(new Pen(Color.Red, 1), new Point(Width, 0), new Point(cpointx, cpointy));
            g.DrawLine(new Pen(Color.Black, 1), new Point(0, Height-20), new Point(prevposx, prevposy));
            g.DrawLine(new Pen(Color.Red, 1), new Point(0, Height-20), new Point(cpointx, cpointy));


            prevposx = e.X;
            prevposy = e.Y;
            Text +=":::" + e.X.ToString() + " : " + e.Y.ToString();
            Text += ":::: " + GetAngleOfLineBetweenTwoPoints(new Point(e.X, e.Y), new Point(cpointx, cpointy)).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();

        }
    }
}