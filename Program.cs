using System;

namespace ControllerDI
{
    interface UIView
    {
        public void View(string message);
    }

    class PieChart : UIView
    {
        public void View(string model)
        {
            //PieChart view code
            Console.WriteLine(model+" PieChart view activated");
        }
    }

    class TableView : UIView
    {
        public void View(string model)
        {
            //Table view code
            Console.WriteLine(model + " TableView view activated");
        }
    }

    class BarChart : UIView
    {
        public void View(string model)
        {
            //BarChart view code
            Console.WriteLine(model + " BarChart view activated");
        }
    }

    class ViewController
    {
        UIView action = null;

        //DI by Property
        public UIView Action_variable
        {
            get { return action; }
            set { action = value; }
        }

        //DI by Constructor
        public ViewController(UIView ThisImplementation)
        {
            this.action = ThisImplementation;
        }

        //DI by Method
        public void DisplayView(UIView ThisImplementation, string model)
        {
            this.action = ThisImplementation;
            action.View(model);
        }

        public void Display(string model)
        {
            if (action == null)
            {
                action = new TableView();
            }
            action.View(model);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UIView Test");
            BarChart BarView = new BarChart();
            PieChart PieView = new PieChart();

            //By Constructor
            ViewController vc1 = new ViewController(BarView);
            vc1.Display("ModelA.db");

            ViewController vc2 = new ViewController(null);
            vc2.Display("ModelB.db");

            //By Method
            ViewController vc3 = new ViewController(null);
            vc3.DisplayView(PieView, "ModelC.db");

            //By Property
            ViewController vc4 = new ViewController(null);
            vc4.Action_variable = PieView;
            vc4.Display("ModelD.db");

        }
    }
}
