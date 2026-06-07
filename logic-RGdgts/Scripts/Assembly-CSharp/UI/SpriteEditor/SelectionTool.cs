using System;
using System.Collections.Generic;
using UI.Common;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SelectionTool : DrawingTool
	{
		private Vector2Int mouseDownPoint;

		private Vector2Int currentMousePoint;

		private SESelectionShapes shape;

		private CreateShape selectionDrawer;

		public SelectionToolStates _currentSelectionState;

		public List<Vector2Int> selectedCoordsBeforeMoving;

		private List<SelectionParameters> selectionHistory;

		public SelectionToolStates currentSelectionState
		{
			get
			{
				return default(SelectionToolStates);
			}
			set
			{
			}
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

		public override void EmptyTool()
		{
		}

		public void SetSelectTool(SESelectionShapes shape, List<SelectionParameters> selectionHistory)
		{
		}

		private void MouseDownFree()
		{
		}

		private void MouseUpFreeSelected()
		{
		}

		private void MouseMoveFreeSelected()
		{
		}

		private List<Vector2Int> CloseSelection()
		{
			return null;
		}

		private List<Vector2Int> PointsInsideSelection(List<Vector2Int> orderedBoundaries)
		{
			return null;
		}

		private bool IsPointInSelection(int x, int y, List<Vector2Int> orderedBoundaries)
		{
			return false;
		}

		private void MouseDownShape()
		{
		}

		private void MouseMoveShapeSelected()
		{
		}

		private void AddCoordsToListOnce(Vector2Int coords, List<Vector2Int> l)
		{
		}

		private void MouseUpShapeSelected()
		{
		}

		private void MouseDownAllMoving()
		{
		}

		private void MouseMoveAllMoving()
		{
		}

		private void MouseUpSquareMoving()
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

		private void SetUnselected()
		{
		}

		public void Delete()
		{
		}

		public void Cut()
		{
		}

		public void Copy()
		{
		}

		public void Paste(bool flip = false)
		{
		}

		private void Select()
		{
		}

		private List<int> ResetSelectedAreaInsideFilter(List<Vector2Int> selectionC)
		{
			return null;
		}

		private void Move()
		{
		}

		public void ResetSamePosition()
		{
		}

		private void MoveDelta(Vector2Int coordDelta, List<Vector2Int> startingCoords)
		{
		}

		private void ResetSelectedAreaInsideImage(Vector2Int diff, List<Vector2Int> startingCoords)
		{
		}
	}
}
