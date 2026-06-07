using UnityEngine;

namespace UI.SpriteEditor
{
	public class DrawingToolParameters
	{
		public VerticalPalette verticalPalette;

		public SEFilter filter;

		public SESelectedArea selection;

		public ImagePixelSelection zoomImage;

		public Vector2Int fullImageSize;

		public int zoomMaskSize;

		public bool insideFilter;

		public void Init(VerticalPalette verticalPalette, SEFilter filter, SESelectedArea selection, ImagePixelSelection zoomImage, Vector2Int fullImageSize, int zoomMaskSize, bool insideFilter)
		{
		}
	}
}
