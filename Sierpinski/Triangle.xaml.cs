namespace Algo8.Sierpinski;

public partial class Triangle : ContentPage
{
    TriangleDrawable drawable;

    public Triangle()
    {
        InitializeComponent();
        drawable = (TriangleDrawable)triangleCanvas.Drawable;
        Slider.Value = 1;
    }

    void Slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
        int value = (int)e.NewValue;
        drawable.maxLevel = value;
        triangleCanvas.Invalidate();
    }
}