using System;
public abstract class Shape
{
    private string color;

    //set color of the shape
    public void setColor(string c) { color = c; }
    //get the color of the shape
    public string getColor() { return color; }

    //get the area of the shape
    public abstract double area();

    //get the perimeter of the shape
    public abstract double perimeter();

    //move shape
    public abstract void move(double a, double b);

    //render the shape
    public abstract string render();
}

public class Box: Shape
{
    private double left;
    private double top;
    private double right;
    private double bottom;
    public Box(string color, double l, double t, double r, double b)
    {
        left = l;
        top = t;
        right = r;
        bottom = b;
        this.setColor(color);
    }

    //getters for points
    public void setLeft(double l) { left = l; }
    public void setTop(double t) { top = t; }
    public void setRight(double r) { right = r; }
    public void setBottom(double b) { bottom = b; }
    public double getLeft() { return left; }
    public double getTop() { return top; }
    public double getRight() { return right; }
    public double getBottom() { return bottom; }

    //gets the area of the box
    public override double area()
    {
        return Math.Abs((right - left) * (top - bottom));
    }

    //gets the perimeter of the box
    public override double perimeter()
    {
        return Math.Abs(left - right) * 2 + Math.Abs(top - bottom) * 2;
    }

    //displays the box
    public override string render()
    {
        return ("Box(" + this.getColor() + "," +  Convert.ToString(left) + "," +  Convert.ToString(top) + "," + Convert.ToString(right) + "," + Convert.ToString(bottom) + ")");
    }

    //moves the box
    public override void move(double h, double v)
    {
        left += h;
        right += h;
        top += v;
        bottom += v;
    }
}

public class Circle : Shape
{
    private double centerx;
    private double centery;
    private double radius;

    public Circle(string color, double ho, double vo, double r)
    {
        centerx = ho;
        centery = vo;
        radius = r;
        this.setColor(color);
    }

    //getters and setters for points
    public void setCenterX(double x) { centerx = x; }
    public void setCenterY(double y) { centery = y; }
    public void setRadius(double r) { radius = r; }
    public double getCenterX() { return centerx; }
    public double getCenterY() { return centery; }
    public double getRadius() { return radius; }

    //gets the area of the circle
    public override double area()
    {
        return Math.PI * radius * radius;
    }

    //gets the perimeter of the circle
    public override double perimeter()
    {
        return Math.PI * radius * 2;
    }

    //displays the circle
    public override string render()
    {
        return ("Circle(" + this.getColor() + "," + Convert.ToString(centerx) + "," + Convert.ToString(centery) + "," + Convert.ToString(radius) + ")");
    }

    //moves the circle
    public override void move(double h, double v)
    {
        centerx += h;
        centery += v;
    }
}

public class Triangle : Shape
{
    private double leftx;
    private double lefty;
    private double topx;
    private double topy;
    private double rightx;
    private double righty;
    public Triangle(string color, double lx, double ly, double tx, double ty, double rx, double ry)
    {
        leftx = lx;
        lefty = ly;
        topx = tx;
        topy = ty;
        rightx = rx;
        righty = ry;
        this.setColor(color);
    }

    //getters and setters for points
    public void setCornerX1(double lx) { leftx = lx; }
    public void setCornerY1(double ly) { lefty = ly; }
    public void setCornerX2(double tx) { topx = tx; }
    public void setCornerY2(double ty) { topy = ty; }
    public void setCornerX3(double rx) { rightx = rx; }
    public void setCornerY3(double ry) { righty = ry; }
    public double getCornerX1() { return leftx; }
    public double getCornerY1() { return lefty; }
    public double getCornerX2() { return topx; }
    public double getCornerY2() { return topy; }
    public double getCornerX3() { return rightx; }
    public double getCornerY3() { return righty; }

    //gets the area of the triangle using paul bourke's technique
    public override double area()
    {
        double area = 0;
        area += (rightx + leftx) * (righty - lefty);
        area += (leftx + topx) * (lefty - topy);
        area += (topx + rightx) * (topy - righty);
        return Math.Abs(area * .5);
    }

    //gets the perimeter of the triangle using pythagorean theorem three times
    public override double perimeter()
    {
        double length1 = 0, length2 = 0, length3 = 0;
        length1 = Math.Sqrt(Math.Pow(topx - leftx, 2) + Math.Pow(topy - lefty, 2));
        length2 = Math.Sqrt(Math.Pow(rightx - topx, 2) + Math.Pow(topy - righty, 2));
        length3 = Math.Sqrt(Math.Pow(rightx - leftx, 2) + Math.Pow(righty - lefty, 2));
        return Math.Abs(length1 + length2 + length3);
    }

    //displays the triangle
    public override string render()
    {
        return "Triangle(" + this.getColor() + "," + Convert.ToString(leftx) + "," + Convert.ToString(lefty) + "," + Convert.ToString(topx)
            + "," + Convert.ToString(topy) + "," + Convert.ToString(rightx) + "," + Convert.ToString(righty) + ")";
    }

    //moves the triangle
    public override void move(double h, double v)
    {
        leftx += h;
        topx += h;
        rightx += h;
        lefty += v;
        topy += v;
        righty += v;
    }
}

public class Polygon : Shape
{
    public Polygon(string color, double[] p, int n)
    {
        points = p;
        num = n;
        this.setColor(color);
    }

    //getters and setters for points
    public double[] points { get; set; }
    public int num { get; set; }
    //check that change is within range
    public void setVertexX(int x, double change) 
    { 
        if(x * 2 < num * 2)
            points[x * 2] = change; 
    }
    //check that change is within range
    public void setVertexY(int y, double change) 
    {
        // mult by 2 to ajust for all of the data being in one array
         if (y * 2 < num * 2)
            points[y * 2] = change; 
    }
    public int getNumpoints() { return num; }
    public double getVertexX(int x)
    { 
        //mult by 2 to ajust for all of the data being in one array
        return points[x * 2];
    }

    public double getVertexY(int y) 
    {
        //mult by 2 to ajust for all of the data being in one array
        return points[y * 2];
    }
    //gets the area of the polygon using paul Bourke's technique
    public override double area()
    {
        double area = 0;
        //double to account for everything being in one array
        int j = num * 2 - 2;

        //Bourke's technique
        for (int i = 0; i < num * 2; i+=2)
        {
            area += (points[j] + points[i]) * (points[j + 1] - points[i + 1]); 
            j = i;
        }

        return Math.Abs(area * .5);
    }

    //gets the perimeter of the polygon using pythagorean theorem num times
    public override double perimeter()
    {
        double perimeter = 0;
        //double to account for everything being in one array
        int j = num * 2 - 2;

        //gets perimeter using pythagorean theorem
        for (int i = 0; i < num * 2; i+=2)
        {
            perimeter += Math.Sqrt( Math.Pow((points[j] - points[i]), 2) + Math.Pow((points[j + 1] - points[i + 1]), 2)); 
            j = i;
        }
        return perimeter; 
    }

    //displays the polygon
    public override string render()
    {
        string render = "Polygon(" + Convert.ToString(this.getColor()) + "," + Convert.ToString(num);
        foreach(double d in points)
        {
            render += "," + Convert.ToString(d);
        }

        return render + ")";
    }

    //moves the polygon
    public override void move(double h, double v)
    {
        for (int i = 0; i < num * 2; i += 2)
        {
            points[i] += h;
            points[i + 1] += v;
        }
    }
}



