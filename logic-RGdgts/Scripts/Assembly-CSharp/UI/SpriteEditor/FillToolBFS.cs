using System;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class FillToolBFS : DrawingTool
	{
		private uint startingColor;

		private uint targetColor;

		public override void Init(DrawingToolParameters parameters, Action AddToHistory)
		{
		}

		public override void SetAsset(SpriteSheetAsset asset)
		{
		}

		public override void ChooseTool()
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

		public void ColorArea(Vector2? externalCoords = null)
		{
		}

		public void BFS(Vector2 startingFillCoords)
		{
		}

		public void FloodFill(Vector2Int startingFullPixel)
		{
		}

		private bool CheckInsideFF(Vector2Int p)
		{
			return false;
		}
	}
}
