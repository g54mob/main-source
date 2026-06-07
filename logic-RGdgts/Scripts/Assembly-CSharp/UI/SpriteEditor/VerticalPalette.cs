using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SpriteEditor
{
	public class VerticalPalette : MonoBehaviour
	{
		public PaletteAsset currentPalette;

		private ImagePixelSelection pixelSelection;

		[SerializeField]
		private UIGrid superimposedGrid;

		private Texture2D texture;

		private RawImage paletteRaw;

		private int cols;

		private int rows;

		private int gridXSize;

		private int gridYSize;

		private Vector2 paletteUIPixelSize;

		private int squareSize;

		[SerializeField]
		private RectTransform area;

		[SerializeField]
		private Image mainColorArea;

		[SerializeField]
		private Image mainTransparentArea;

		[SerializeField]
		private Image secondColorArea;

		[SerializeField]
		private Image secondTransparentArea;

		private Material transparentBoxMaterial;

		[SerializeField]
		public RectTransform mainColorBoxRT;

		[SerializeField]
		public RectTransform secondColorBoxRT;

		private paletteSelectColorBox mainColorBox;

		private int boxSize;

		[HideInInspector]
		public uint selectedMainColorIndex;

		[HideInInspector]
		public uint selectedSecondColorIndex;

		private uint transparentColorIndex;

		[SerializeField]
		private GameObject transparentPalettePanels;

		[HideInInspector]
		public PaletteStates paletteStatus;

		private Action OnEndEditPalette;

		private Action OnSmallPanelButtonClose;

		private MultitoolColorPickerService changeColor;

		public void Init(Action OnEndEditPalette, Action OnSmallPanelButtonClose)
		{
		}

		public void SetPalette(PaletteAsset currentPalette)
		{
		}

		private void SetColorSelectorSize()
		{
		}

		private void SetStartingColors()
		{
		}

		private void SetTexture()
		{
		}

		private void MoveSelector(Vector2 coords, RectTransform selectionBox)
		{
		}

		public void OnColorSelectedLeft()
		{
		}

		public void OnColorSelectedRight()
		{
		}

		public void SelectMainColor()
		{
		}

		public void ColorColorArea(bool mainColor)
		{
		}

		public void ChangeTransparentBkg(bool isMain, Color color)
		{
		}

		public void SetMainColorBox(Vector2 coords)
		{
		}

		public void SelectSecondColor()
		{
		}

		public void SetSecondColorBox(Vector2 coords)
		{
		}

		public void SetMainColorBoxIndex(uint index)
		{
		}

		public void SetSecondColorBoxIndex(uint index)
		{
		}

		public void MoveSelectorIndex(uint index, RectTransform selectionBox)
		{
		}

		public void SetMainTransparent()
		{
		}

		public void SetSecondTransparent()
		{
		}

		public uint ColorIndexFromTransform(Vector2 coords)
		{
			return 0u;
		}

		public void ChangeStatus(PaletteStates state)
		{
		}

		private void ChangeToEdit()
		{
		}

		private void ChangeToDraw()
		{
		}

		private void CloseSmallPanel()
		{
		}

		public void ChangeColor()
		{
		}

		public void OnColorChange(Color32 color)
		{
		}

		private void ResetMainColor()
		{
		}
	}
}
