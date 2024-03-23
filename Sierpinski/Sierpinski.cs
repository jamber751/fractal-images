namespace Algo8.Sierpinski
{
    public class TriangleDrawable : IDrawable
    {
        public int maxLevel = 1;
        private Color[] colors = { Colors.Green, Colors.SteelBlue, Colors.LightSalmon, Colors.LightSlateGray, Colors.LimeGreen };

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

            drawTriangle(canvas, 0, new PointF(500, 0), new PointF(0, 1000), new PointF(1000, 1000));
        }

        public void drawTriangle(ICanvas canvas, int level, PointF mid, PointF left, PointF right)
        {
            if (level > maxLevel) return;

            PathF path = new PathF();
            path.MoveTo(mid);
            path.LineTo(left);
            path.LineTo(right);
            path.Close();

            canvas.FillColor = colors[level % 5];
            canvas.FillPath(path);

            PointF midMid = getMidPoint(left, right);
            PointF leftMid = getMidPoint(mid, left);
            PointF rightMid = getMidPoint(mid, right);

            drawTriangle(canvas, ++level, mid, leftMid, rightMid);
            drawTriangle(canvas, level, leftMid, left, midMid);
            drawTriangle(canvas, level, midMid, rightMid, right);
        }

        private PointF getMidPoint(PointF point1, PointF point2)
        {
            return new PointF((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);
        }
    }
}