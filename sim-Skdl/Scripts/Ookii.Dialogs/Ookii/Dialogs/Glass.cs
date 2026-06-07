using System.Drawing;
using System.Windows.Forms;

namespace Ookii.Dialogs
{
	public static class Glass
	{
		public static bool OSSupportsDwmComposition => false;

		public static bool IsDwmCompositionEnabled => false;

		public static void ExtendFrameIntoClientArea(this IWin32Window window, Padding glassMargin)
		{
		}

		public static void DrawCompositedText(IDeviceContext dc, string text, Font font, Rectangle bounds, Padding padding, Color foreColor, int glowSize, TextFormatFlags textFormat)
		{
		}

		public static Size MeasureCompositedText(IDeviceContext dc, string text, Font font, TextFormatFlags textFormat)
		{
			return default(Size);
		}
	}
}
