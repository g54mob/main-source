using System;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class DrawShapeTool : DrawingTool
	{
		private Vector2Int startingShapePoint;

		private Vector2Int endPoint;

		private bool reverseColor;

		protected bool fixedCentre;

		private CreateShape selectShape;

		public void SetFixedCentre(bool fixedCentre)
		{
		}

		public override void Init(DrawingToolParameters parameters, Action AddToHistory)
		{
		}

		public override void SetAsset(SpriteSheetAsset asset)
		{
		}

		public override void ChooseTool()
		{
		}

		public void SetShapeTool(DrawToolState toolState)
		{
		}

		public void SetFixedPoint(bool fixedCentre)
		{
		}

		public override void MouseDownLeft()
		{
		}

		public override void MouseDownRight()
		{
		}

		public override void MouseMoveLeft()
		{
		}

		public override void MouseMoveRight()
		{
		}

		public override void MouseUpLeft()
		{
		}

		public override void MouseUpRight()
		{
		}

		private void Draw()
		{
		}

		private uint MainColor()
		{
			return 0u;
		}

		private uint SecondaryColor()
		{
			return 0u;
		}

		private bool ForceInside(int r, bool filter, bool image)
		{
			return false;
		}

		private bool ForceInsideImage(int r)
		{
			return false;
		}

		private bool ForceInsideFilter(int r)
		{
			return false;
		}
	}
}
