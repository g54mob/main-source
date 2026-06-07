using System;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class LineTool : DrawingTool
	{
		private Vector2Int startingShapePoint;

		private CreateLine selectLine;

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

		private void DrawLine(uint colorIndex)
		{
		}
	}
}
