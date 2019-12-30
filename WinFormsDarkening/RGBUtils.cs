using System.Drawing;


namespace WinFormsDarkening
{
    class RGBUtils
    {
        public static Color FlipContrast (Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }
        public static Color FlipContrastDark(Color color)
        {
            int R = color.R > 255 / 2 ? 255 - color.R : color.R;
            int G = color.G > 255 / 2 ? 255 - color.G : color.G;
            int B = color.B > 255 / 2 ? 255 - color.B : color.B;
            return Color.FromArgb(R,G, B);
        }
    }
}
