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
            Text += ":::" + e.X.ToString() + " : " + e.Y.ToString();
            float u = GetAngleOfLineBetweenTwoPoints(new Point(e.X, e.Y), new Point(cpointx, cpointy));
            Text += ":::: " + u.ToString();

            g.DrawLine(new Pen(Color.Black, 1), new Point(e.X, e.Y), new Point(prevposx, prevposy));
            g.DrawLine(new Pen(Color.Red, 1), new Point(e.X, e.Y), new Point(cpointx, cpointy));
            

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
            


            //gaseste punctul invers pozitiei actuale eXY fata de punctul selectat cpointXY
            //a.i. punctul de partea cealalta a cpointXY in oglinda este creat de un patrulater care are in coltul A eXY
            // .... si in mijloc pe cpointXY.
            //daca A(1,1) si M(6,6) atunci C(?,?) = Mx + Ax = Cx si Cy = Ay - My
            float cx=e.X;
            float cy=e.Y;
            if (e.X > cpointx)
            {
                cx = cpointx-( e.X - cpointx);
  
            }

            if (e.Y > cpointy)
            {
                cy = cpointy-(e.Y - cpointy);
            }

            if (e.X < cpointx)
            {
                cx = cpointx + ( cpointx - e.X);

            }

            if (e.Y < cpointy)
            {
                cy = cpointy + ( cpointy - e.Y);
            }



            g.DrawLine(new Pen(Color.Red, 1), new Point(e.X,e.Y), new Point((int)cx,(int)cy));


            //calculati punctele unde o dreapta trasat de la eXY la cpointXY va atinge marginile ferestrei sau a unui cerc 
            //sau prelungiti dreptele eXY prin cXY in fata si spate pana atinge o margine data fereastra sau raza unui cerc
            if (e.X > cpointx)
            {
                cx = cpointx - (e.X - cpointx) * 20;

            }

            if (e.Y > cpointy)
            {
                cy = cpointy - (e.Y - cpointy) * 20;
            }

            if (e.X < cpointx)
            {
                cx = cpointx + (cpointx - e.X) * 20;

            }

            if (e.Y < cpointy)
            {
                cy = cpointy + (cpointy - e.Y)*20;
            }
            
            int pcx1 = (int)cx;
            int pcy1 = (int)cy;

            g.DrawLine(new Pen(Color.Red, 1), new Point(e.X, e.Y), new Point((int)cx, (int)cy));


            if (e.X > cpointx)
            {
                cx = e.X - ( cpointx - e.X) * 20;

            }

            if (e.Y > cpointy)
            {
                cy = e.Y - (cpointy - e.Y ) * 20;
            }

            if (e.X < cpointx)
            {
                cx = e.X + (e.X - cpointx ) * 20;

            }

            if (e.Y < cpointy)
            {
                cy = e.Y + (e.Y - cpointy ) * 20;
            }

            int pcx2 = (int)cx;
            int pcy2 = (int)cy;

            g.DrawLine(new Pen(Color.Red, 1), new Point(cpointx, cpointy), new Point((int)cx, (int)cy));

            //find the intersections with margins

            Line AB = new Line();
            Line H1 = new Line();
            Line V1 = new Line();
            Line H2 = new Line();
            Line V2 = new Line();
            
            AB.x1 = pcx1;
            AB.y1 = pcy1;
            AB.x2 = pcx2;
            AB.y2 = pcy2;


            //UP
            H1.x1 = 0;
            H1.y1 = 0;
            H1.x2 = Width;
            H1.y2 = 0;

            //LEFT
            V1.x1 = 0;
            V1.y1 = 0;
            V1.x2 = 0;
            V1.y2 = Height;
            //DOWN
            H2.x1 =0;
            H2.y1 = Height;
            H2.x2 = Width;
            H2.y2 = Height;

            //RIGHT
            V2.x1 = Width;
            V2.y1 = 0;
            V2.x2 = Width;
            V2.y2 = Height;

            pPoint A1 = FindIntersection(AB , H1 , 0.001);
            pPoint B1 = FindIntersection(AB, V1, 0.001);
            pPoint A2 = FindIntersection(AB, H2, 0.001);
            pPoint B2 = FindIntersection(AB, V2, 0.001);

            g.DrawLine(new Pen(Color.Red, 1) , (int)A1.x, (int)A1.y, (int)B1.x, (int)B1.y);
            g.DrawLine(new Pen(Color.Red, 1), (int)A2.x, (int)A2.y, (int)B2.x, (int)B2.y);
            g.DrawLine(new Pen(Color.Red, 1), (int)A1.x, (int)A1.y, (int)A2.x, (int)B2.y);
            g.DrawLine(new Pen(Color.Red, 1), (int)B1.x, (int)B1.y, (int)B2.x, (int)B2.y);

            g.DrawEllipse(new Pen(Color.Red, 2), (int)A1.x, (int)A2.x,5,5);
            g.DrawEllipse(new Pen(Color.Red, 2), (int)A2.x, (int)A2.x, 5, 5);
            g.DrawEllipse(new Pen(Color.Red, 2), (int)B1.x, (int)B1.x, 5, 5);
            g.DrawEllipse(new Pen(Color.Red, 2), (int)B1.x, (int)B2.x, 5, 5);


            prevposx = e.X;
            prevposy = e.Y;
                }



        public struct Line
        {
            public double x1 { get; set; }
            public double y1 { get; set; }

            public double x2 { get; set; }
            public double y2 { get; set; }
        }

        public struct pPoint
        {
            public double x { get; set; }
            public double y { get; set; }
        }

       
            //  Returns Point of intersection if do intersect otherwise default Point (null)
            public static pPoint FindIntersection(Line lineA, Line lineB, double tolerance = 0.001)
            {
                double x1 = lineA.x1, y1 = lineA.y1;
                double x2 = lineA.x2, y2 = lineA.y2;

                double x3 = lineB.x1, y3 = lineB.y1;
                double x4 = lineB.x2, y4 = lineB.y2;

                // equations of the form x = c (two vertical lines)
                if (Math.Abs(x1 - x2) < tolerance && Math.Abs(x3 - x4) < tolerance && Math.Abs(x1 - x3) < tolerance)
                {
                    throw new Exception("Both lines overlap vertically, ambiguous intersection points.");
                }

                //equations of the form y=c (two horizontal lines)
                if (Math.Abs(y1 - y2) < tolerance && Math.Abs(y3 - y4) < tolerance && Math.Abs(y1 - y3) < tolerance)
                {
                    throw new Exception("Both lines overlap horizontally, ambiguous intersection points.");
                }

                //equations of the form x=c (two vertical parallel lines)
                if (Math.Abs(x1 - x2) < tolerance && Math.Abs(x3 - x4) < tolerance)
                {
                    //return default (no intersection)
                    return default(pPoint);
                }

                //equations of the form y=c (two horizontal parallel lines)
                if (Math.Abs(y1 - y2) < tolerance && Math.Abs(y3 - y4) < tolerance)
                {
                    //return default (no intersection)
                    return default(pPoint);
                }

                //general equation of line is y = mx + c where m is the slope
                //assume equation of line 1 as y1 = m1x1 + c1 
                //=> -m1x1 + y1 = c1 ----(1)
                //assume equation of line 2 as y2 = m2x2 + c2
                //=> -m2x2 + y2 = c2 -----(2)
                //if line 1 and 2 intersect then x1=x2=x & y1=y2=y where (x,y) is the intersection point
                //so we will get below two equations 
                //-m1x + y = c1 --------(3)
                //-m2x + y = c2 --------(4)

                double x, y;

                //lineA is vertical x1 = x2
                //slope will be infinity
                //so lets derive another solution
                if (Math.Abs(x1 - x2) < tolerance)
                {
                    //compute slope of line 2 (m2) and c2
                    double m2 = (y4 - y3) / (x4 - x3);
                    double c2 = -m2 * x3 + y3;

                    //equation of vertical line is x = c
                    //if line 1 and 2 intersect then x1=c1=x
                    //subsitute x=x1 in (4) => -m2x1 + y = c2
                    // => y = c2 + m2x1 
                    x = x1;
                    y = c2 + m2 * x1;
                }
                //lineB is vertical x3 = x4
                //slope will be infinity
                //so lets derive another solution
                else if (Math.Abs(x3 - x4) < tolerance)
                {
                    //compute slope of line 1 (m1) and c2
                    double m1 = (y2 - y1) / (x2 - x1);
                    double c1 = -m1 * x1 + y1;

                    //equation of vertical line is x = c
                    //if line 1 and 2 intersect then x3=c3=x
                    //subsitute x=x3 in (3) => -m1x3 + y = c1
                    // => y = c1 + m1x3 
                    x = x3;
                    y = c1 + m1 * x3;
                }
                //lineA & lineB are not vertical 
                //(could be horizontal we can handle it with slope = 0)
                else
                {
                    //compute slope of line 1 (m1) and c2
                    double m1 = (y2 - y1) / (x2 - x1);
                    double c1 = -m1 * x1 + y1;

                    //compute slope of line 2 (m2) and c2
                    double m2 = (y4 - y3) / (x4 - x3);
                    double c2 = -m2 * x3 + y3;

                    //solving equations (3) & (4) => x = (c1-c2)/(m2-m1)
                    //plugging x value in equation (4) => y = c2 + m2 * x
                    x = (c1 - c2) / (m2 - m1);
                    y = c2 + m2 * x;

                    //verify by plugging intersection point (x, y)
                    //in orginal equations (1) & (2) to see if they intersect
                    //otherwise x,y values will not be finite and will fail this check
                    if (!(Math.Abs(-m1 * x + y - c1) < tolerance
                        && Math.Abs(-m2 * x + y - c2) < tolerance))
                    {
                        //return default (no intersection)
                        return default(pPoint);
                    }
                }

                //x,y can intersect outside the line segment since line is infinitely long
                //so finally check if x, y is within both the line segments
                if (IsInsideLine(lineA, x, y) &&
                    IsInsideLine(lineB, x, y))
                {
                    return new pPoint { x = x, y = y };
                }

                //return default (no intersection)
                return default(pPoint);

            }

            // Returns true if given point(x,y) is inside the given line segment
            private static bool IsInsideLine(Line line, double x, double y)
            {
                return (x >= line.x1 && x <= line.x2
                            || x >= line.x2 && x <= line.x1)
                       && (y >= line.y1 && y <= line.y2
                            || y >= line.y2 && y <= line.y1);
            }
        



        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();

        }
    }
}