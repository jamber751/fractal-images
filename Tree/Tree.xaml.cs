namespace Algo8.Tree;

public partial class Tree : ContentPage
{
    TreeDrawable drawable;

    public Tree()
    {
        InitializeComponent();
        drawable = (TreeDrawable)treeCanvas.Drawable;
        Slider.Value = 1;
    }

    void Slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
        int value = (int)e.NewValue;
        treeCanvas.Invalidate();
    }
}
