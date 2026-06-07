using System;
using System.Collections.Generic;
using UI.Common;
using UIUtilities;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SESelectedArea
	{
		public SESelectionShapes selectionShape;

		public SelectionRowsAndCols externalSquareSize;

		public Vector2Int fullImageSize;

		public SESelection selectionPanel;

		public Vector2Int start;

		public Vector2Int end;

		public List<Vector2Int> selectionCoords;

		public uint[] selectionPixelsColor;

		public uint[] originalUnderSelectionPixelColors;

		public List<int> selectedPixelIndex;

		public bool ignoreTransparency;

		public Action OnSelectionDelete;

		public Action OnSelectionCut;

		public Action OnSelectionCopy;

		public Action OnSelectionPaste;

		public Action OnSelectionFlip;

		public Action<bool, bool> OnChangeSelectionToActive;

		public List<Vector2Int> copiedSelectionCoords;

		public Vector2Int copiedFilterTLPosition;

		public uint[] copiedPixelsColor;

		public Vector2Int flipCopiedFilterTLPosition;

		public uint[] flipCopiedPixelsColor;

		public List<Vector2Int> flipCopiedSelectionCoords;

		public SESelectionShapes copiedShape;

		public SESelectionShapes flipCopiedShape;

		private bool pasted;

		private CheckInsideBoundaries checkBoundaries;

		private SECoordinatesConverter convert;

		public void Init(Vector2Int fullImageSize, SESelectionShapes selectionShape, SESelection selectionPanel)
		{
		}

		public void SetSelectionShape(SESelectionShapes selectionShape)
		{
		}

		public void ClearCopy()
		{
		}

		public void SetParametersSelection(Vector2Int start, Vector2Int end, List<int> pixels)
		{
		}

		public void SetSelectionCoords(List<Vector2Int> selectionC)
		{
		}

		public void SetSelectionCoords(Vector2Int start, Vector2Int end, List<Vector2Int> selectionCoords)
		{
		}

		public void SetSelectionIndexColor(List<int> selectionIndexColor)
		{
		}

		public void SetVisiblePixels(List<int> visiblePixels)
		{
		}

		public void SetSelectedPixelColor(uint[] referenceImage)
		{
		}

		public void SetSelectedPixelColor(List<int> referenceImage)
		{
		}

		public void ResetToImageSelection()
		{
		}

		private List<Vector2Int> PixelToCoords(List<int> pixels)
		{
			return null;
		}

		public void ResetToFilterSelection(SEFilter filter)
		{
		}

		public void RefreshPanel()
		{
		}

		public List<int> GetSelectionPixels()
		{
			return null;
		}

		public bool IsSelectionActive()
		{
			return false;
		}

		public bool CheckInsideImageBorders(int x, int y)
		{
			return false;
		}

		public bool CheckInsideFilter(int x, int y, SEFilter filter)
		{
			return false;
		}

		public bool CheckInsideSelection(int x, int y, bool treatAsFreeSelection = true)
		{
			return false;
		}

		public void DeleteSelection(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		public void CutSelection(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		public void CopySelection(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		private void Copy(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		private void CopyForFlip(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		private bool CheckSameImage(SpriteSheetAsset asset)
		{
			return false;
		}

		public void PasteSelection()
		{
		}

		public void PasteFlip()
		{
		}

		public void HorizontalFlip(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		public uint[] HorizontalPixelFlip(uint[] arrayToFlip, int r, int c)
		{
			return null;
		}

		public void VerticalFlip(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		public void DiagonalFlip(SpriteSheetAsset asset, SEFilter filter)
		{
		}

		public void Delete(SpriteSheetAsset asset, bool createHole)
		{
		}

		public void ResetUnderSelectionImage(SpriteSheetAsset asset)
		{
		}

		public void CreateHole(uint[] referencePixelsColor)
		{
		}

		public SelectionParameters GetCopyForHistory()
		{
			return null;
		}
	}
}
