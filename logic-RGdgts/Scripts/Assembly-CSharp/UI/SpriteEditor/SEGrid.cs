using System;
using TMPro;
using UI.Elements;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEGrid : UIGrid
	{
		[SerializeField]
		private UIInputField widthPx;

		[SerializeField]
		private UIInputField heightPx;

		[SerializeField]
		private TMP_Text widthText;

		[SerializeField]
		private TMP_Text heightText;

		public UIButton confirmGrid;

		private int originalSizeColorIndex;

		private int errorSizeColorIndex;

		public bool gridIsChanging;

		public override void Init(int w, int h, Action<Vector2Int> OnGridChange = null, Color? defaultColor = null)
		{
		}

		public override void ResetGridParameters(int sizeX, int sizeY, Color? color = null, Vector2Int? off = null)
		{
		}

		public override void SetColor(Color color)
		{
		}

		public override void SaveColor(Color color)
		{
		}

		public override void SetAlpha(float alpha)
		{
		}

		public int SizeX()
		{
			return 0;
		}

		public int SizeY()
		{
			return 0;
		}

		public (int, int) SetGridSize()
		{
			return default((int, int));
		}

		public void ApplyGridSize()
		{
		}

		private void OnGridValueChanged(TMP_InputField inputField, TMP_Text text)
		{
		}

		public int GetTotalCellNumber()
		{
			return 0;
		}

		public Vector2Int GetCellCoords()
		{
			return default(Vector2Int);
		}

		public bool CheckPower2GridForInput()
		{
			return false;
		}

		public bool CheckPower2Grid(int w, int h)
		{
			return false;
		}

		public void ResetGridPanel()
		{
		}

		public void SetGridPanelParameters(int w, int h)
		{
		}
	}
}
