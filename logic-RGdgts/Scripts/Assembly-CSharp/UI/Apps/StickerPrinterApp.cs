using System.Collections;
using System.Collections.Generic;
using UI.Elements;
using UI.SpriteEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Apps
{
	public class StickerPrinterApp : MultiToolEditorApp
	{
		private SpriteSheetAsset selectedAsset;

		public UIGrid grid;

		public UIButton printButton;

		public UIButton reverseColorButton;

		[SerializeField]
		private SESelection selectionPanel;

		private CreateSquare selectSquare;

		private Vector2Int startingShapePoint;

		private CreateShapeParameters selection;

		private bool isColorInverted;

		[SerializeField]
		private RectTransform preview;

		[SerializeField]
		private Image transparentPreviewBKG;

		[SerializeField]
		private Image transparentBKG;

		private StickerData stickerData;

		private StickerData[] fontStickerData;

		private SECoordinatesConverter coordConverter;

		private List<Vector2Int> selectionCoords;

		private Vector2Int fullImageSize;

		public ImagePixelSelection fullImage;

		private Material imageMaterial;

		public override void Init()
		{
		}

		public void SetGridAndCustomColor(UIGrid grid, Material transparentBkgMaterial)
		{
		}

		private void InvertColor()
		{
		}

		public void PrintSticker()
		{
		}

		private IEnumerator WaitToShowPreview()
		{
			return null;
		}

		public override void AppStart()
		{
		}

		private void RefreshGridSize()
		{
		}

		private void ResetApp()
		{
		}

		public override void AppStop()
		{
		}

		private void MouseDownLeft()
		{
		}

		private void MouseMoveLeft()
		{
		}

		private void MouseUp()
		{
		}

		private void LoadPreview()
		{
		}

		private void PrintingPreview(int pixels)
		{
		}

		private void ResizePreview(int width, int height)
		{
		}

		public Texture2D ConvertPixelIndexArrayToTexture(List<int> selectedIndexes, Color[] colorArray, int width, int height)
		{
			return null;
		}

		private List<int> RefreshCoordsToIndexInsideFilter()
		{
			return null;
		}

		public int ConvertMatrixFullToAssetIndex(Vector2Int coords)
		{
			return 0;
		}

		public override void EditAsset(Asset asset)
		{
		}

		private void SetImagePalette(PaletteAsset palette)
		{
		}

		private void SetRawImage()
		{
		}

		private Vector2Int TLCoords(Vector2 coords)
		{
			return default(Vector2Int);
		}

		private Vector2Int BRCoords(Vector2 coords)
		{
			return default(Vector2Int);
		}

		private void GridAreaFormCoords(Vector2 coords)
		{
		}

		private void OnInputFieldChange()
		{
		}

		private StickerData GetFontLetter()
		{
			return null;
		}

		private void RefreshTitle()
		{
		}
	}
}
