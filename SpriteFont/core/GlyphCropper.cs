using System;
using System.Drawing;

namespace mage {
    
    public static class GlyphCropper {

        // Crops unused space from around the edge of a glyph bitmap.
        public static void Crop(Glyph glyph) {
            if (glyph == null) {
                throw new NullReferenceException("The given glyph may not be equal to null.");
            }

            // Crop the top.
            while ((glyph.Region.Height > 1) && BitmapUtils.MatchesAlpha(0, glyph.Bitmap, new Rectangle(glyph.Region.X, glyph.Region.Y, glyph.Region.Width, 1))) {
                ++glyph.Region.Y;
                --glyph.Region.Height;
                ++glyph.OffsetY;
            }

            // Crop the bottom.
            while ((glyph.Region.Height > 1) && BitmapUtils.MatchesAlpha(0, glyph.Bitmap, new Rectangle(glyph.Region.X, glyph.Region.Bottom - 1, glyph.Region.Width, 1))) {
                --glyph.Region.Height;
            }

            // Crop the left.
            while ((glyph.Region.Width > 1) && BitmapUtils.MatchesAlpha(0, glyph.Bitmap, new Rectangle(glyph.Region.X, glyph.Region.Y, 1, glyph.Region.Height))) {
                ++glyph.Region.X;
                --glyph.Region.Width;
                ++glyph.OffsetX;
            }

            // Crop the right.
            while ((glyph.Region.Width > 1) && BitmapUtils.MatchesAlpha(0, glyph.Bitmap, new Rectangle(glyph.Region.Right - 1, glyph.Region.Y, 1, glyph.Region.Height))) {
                --glyph.Region.Width;
                ++glyph.AdvanceX;
            }
        }
    }
}
