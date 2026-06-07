using System;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class DrawingTool
	{
		public SESelectedArea selectedArea;

		public uint[] referenceMouseDownPixelColor;

		public Vector2Int fullImageSize;

		public ImagePixelSelection zoomImage;

		public int zoomMaskSize;

		public VerticalPalette verticalPalette;

		public SpriteSheetAsset asset;

		public Action AddToHistory;

		private SECoordinatesConverter coordConverter;

		protected SEFilter filter;

		public bool insideFilter;

		public virtual void Init(DrawingToolParameters par, Action AddToHistory)
		{
		}

		public virtual void SetAsset(SpriteSheetAsset asset)
		{
		}

		public virtual void ChooseTool()
		{
		}

		public virtual void EmptyTool()
		{
		}

		public virtual void MouseDownLeft()
		{
		}

		public virtual void MouseDownRight()
		{
		}

		public virtual void MouseMoveLeft()
		{
		}

		public virtual void MouseMoveRight()
		{
		}

		public virtual void MouseUpLeft()
		{
		}

		public virtual void MouseUpRight()
		{
		}

		public int ConvertZoomCoordToPixelIndex(Vector2 zoomCoords)
		{
			return 0;
		}

		public Vector2 ConvertMatrixZoomToMatrixFull(Vector2 zoomCoords)
		{
			return default(Vector2);
		}

		public int ConvertMatrixFullToAssetIndex(Vector2Int coords)
		{
			return 0;
		}

		public Vector2Int ConvertIndexToMatrixFull(int index)
		{
			return default(Vector2Int);
		}

		public bool CheckInsideSelection(float x, float y)
		{
			return false;
		}

		public bool CheckInsideFilter(int x, int y)
		{
			return false;
		}

		public bool CheckInsideImage(int x, int y)
		{
			return false;
		}
	}
}
