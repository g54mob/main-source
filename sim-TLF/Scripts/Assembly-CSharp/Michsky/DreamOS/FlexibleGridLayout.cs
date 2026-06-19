using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class FlexibleGridLayout : LayoutGroup
	{
		public enum FitType
		{
			Uniform = 0,
			Width = 1,
			Height = 2,
			FixedRow = 3,
			FixedColumn = 4
		}

		[Header("Layout")]
		public Vector2 spacing;

		public Vector2 cellSize = new Vector2(100f, 100f);

		public int rows;

		public int columns;

		[Header("Settings")]
		public FitType fitType;

		public bool fitX;

		public bool fitY;

		public override void CalculateLayoutInputHorizontal()
		{
			base.CalculateLayoutInputHorizontal();
			if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform)
			{
				fitX = true;
				fitY = true;
				float f = Mathf.Sqrt(base.transform.childCount);
				rows = Mathf.CeilToInt(f);
				columns = Mathf.CeilToInt(f);
			}
			if (fitType == FitType.Width || fitType == FitType.FixedColumn)
			{
				rows = Mathf.CeilToInt((float)base.transform.childCount / (float)columns);
			}
			else if (fitType == FitType.Height || fitType == FitType.FixedRow)
			{
				rows = Mathf.CeilToInt((float)base.transform.childCount / (float)rows);
			}
			float width = base.rectTransform.rect.width;
			float height = base.rectTransform.rect.height;
			float num = width / (float)columns - spacing.x / (float)columns * 2f - (float)base.padding.left / (float)columns - (float)base.padding.right / (float)columns;
			float num2 = height / (float)rows - spacing.y / (float)rows * 2f - (float)base.padding.top / (float)rows - (float)base.padding.bottom / (float)rows;
			cellSize.x = (fitX ? num : cellSize.x);
			cellSize.y = (fitY ? num2 : cellSize.y);
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < base.rectChildren.Count; i++)
			{
				num4 = i / columns;
				num3 = i % columns;
				RectTransform rect = base.rectChildren[i];
				float pos = cellSize.x * (float)num3 + spacing.x * (float)num3 + (float)base.padding.left;
				float pos2 = cellSize.y * (float)num4 + spacing.y * (float)num4 + (float)base.padding.top;
				SetChildAlongAxis(rect, 0, pos, cellSize.x);
				SetChildAlongAxis(rect, 1, pos2, cellSize.y);
			}
		}

		public override void CalculateLayoutInputVertical()
		{
			base.enabled = false;
			base.enabled = true;
		}

		public override void SetLayoutHorizontal()
		{
		}

		public override void SetLayoutVertical()
		{
		}
	}
}
