namespace Algo8.Tree
{
    public class TreeDrawable : IDrawable
    {
        private double startLength = 200;
        private double dAngle = 30 * Math.PI / 180;
        private double factor = 1.3;

        private Color rootColor = Color.FromArgb("#2C2019");
        private Color[] leafColors = { Color.FromArgb("#3F8727"), Color.FromArgb("#59B936"), Color.FromArgb("#596422") };

        public Random rnd = new Random();

        public int maxLevel = 20;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            PointF start = new PointF(600, 1000);
            drawVetka(canvas, start, 0, 0, startLength);
        }

        public void drawVetka(ICanvas canvas, PointF start, int level, double currentAngle, double length)
        {
            canvas.StrokeColor = rootColor;
            canvas.StrokeSize = maxLevel - level * 2 <= 0 ? 1 : maxLevel - level * 2;

            if (level == maxLevel) return;

            if (level >= maxLevel - 5 && level <= maxLevel - 1)
            {
                canvas.StrokeSize = level - 12;
                if (level == maxLevel - 1) canvas.StrokeSize = 10;
                canvas.StrokeColor = leafColors[rnd.Next(0, 3)];
            }

            if (level == 0)
            {
                PointF end = new PointF(start.X, start.Y - (float)length);
                canvas.DrawLine(start, end);
                drawVetka(canvas, end, level + 1, currentAngle, length / factor);
            }

            else
            {
                double lengthRight = rnd.Next((int)(length / 1.3), (int)(length / 1.2));
                double rightAngle = currentAngle - dAngle * rnd.Next(30, 170) / 100;

                double newX = start.X - lengthRight * Math.Sin(rightAngle);
                double newY = start.Y - lengthRight * Math.Cos(rightAngle);

                PointF endRight = new PointF((float)newX, (float)newY);
                canvas.DrawLine(start, endRight);

                double lengthLeft = rnd.Next((int)(length / 1.3), (int)(length / 1.2));
                double leftAngle = currentAngle + dAngle * rnd.Next(30, 170) / 100;

                newX = start.X - lengthLeft * Math.Sin(leftAngle);
                newY = start.Y - lengthLeft * Math.Cos(leftAngle);

                PointF endLeft = new PointF((float)newX, (float)newY);
                canvas.DrawLine(start, endLeft);

                int nextLevelRight, nextLevelLeft;
                if (level == maxLevel - 1)
                {
                    nextLevelRight = maxLevel;
                    nextLevelLeft = maxLevel;
                }
                else
                {
                    nextLevelRight = level + rnd.Next(1, 3);
                    nextLevelLeft = level + rnd.Next(1, 3);
                    if (nextLevelRight >= maxLevel - 1) nextLevelRight = maxLevel - 1;
                    if (nextLevelLeft >= maxLevel - 1) nextLevelLeft = maxLevel - 1;
                }
                drawVetka(canvas, endRight, nextLevelRight, rightAngle, lengthRight);
                drawVetka(canvas, endLeft, nextLevelLeft, leftAngle, lengthLeft);
            }
        }

    }
}

