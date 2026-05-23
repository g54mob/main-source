using ThreeDISevenZeroR.UnityGifDecoder.Model;
using UnityEngine;

namespace ThreeDISevenZeroR.UnityGifDecoder
{
	public class GifCanvas
	{
		private Color32[] canvasColors;

		private Color32[] revertDisposalBuffer;

		private int canvasWidth;

		private int canvasHeight;

		private bool canvasIsEmpty;

		private Color32[] framePalette;

		private GifDisposalMethod frameDisposalMethod;

		private int frameCanvasPosition;

		private int frameCanvasRowEndPosition;

		private int frameTransparentColorIndex;

		private int frameRowCurrent;

		private int frameX;

		private int frameY;

		private int frameWidth;

		private int frameHeight;

		private int[] frameRowStart;

		private int[] frameRowEnd;

		public Color32[] Colors => null;

		public bool FlipVertically { get; set; }

		public Color32 BackgroundColor { get; set; }

		public GifCanvas()
		{
		}

		public GifCanvas(int width, int height)
		{
		}

		public void SetSize(int width, int height)
		{
		}

		public void Reset()
		{
		}

		public void BeginNewFrame(int x, int y, int width, int height, Color32[] palette, int transparentColorIndex, bool isInterlaced, GifDisposalMethod disposalMethod)
		{
		}

		public void OutputPixel(int color)
		{
		}

		public void FillWithColor(int x, int y, int width, int height, Color32 color)
		{
		}

		private void RouteFrameDrawing(int x, int y, int width, int height, bool deinterlace)
		{
		}
	}
}
