using UnityEngine;
using UnityEngine.UI;

public class StaggeredLayout : LayoutGroup
{
	public float Width = 20f;

	public float Height = 20f;

	public float ExtraHeight = 40f;

	public int MinRow = 3;

	public Vector2 Spacing = new Vector2(1f, 1f);

	public override float preferredHeight
	{
		get
		{
			return (float)base.padding.vertical + Spacing.y + Height * 2f;
		}
	}

	public override float preferredWidth
	{
		get
		{
			int num = base.rectChildren.Count;
			if (base.rectChildren.Count > MinRow)
			{
				num = Mathf.CeilToInt((float)num * 0.5f);
			}
			return (float)base.padding.horizontal + (float)num * Width + (float)Mathf.Max(0, num - 1) * Spacing.x;
		}
	}

	public override void CalculateLayoutInputVertical()
	{
	}

	public override void SetLayoutHorizontal()
	{
		if (base.rectChildren.Count <= MinRow)
		{
			for (int i = 0; i < base.rectChildren.Count; i++)
			{
				RectTransform rect = base.rectChildren[i];
				SetChildAlongAxis(rect, 0, (float)base.padding.left + (float)i * Width + (float)i * Spacing.x, Width);
				SetChildAlongAxis(rect, 1, (float)base.padding.top + Height + Spacing.y, Height + ExtraHeight);
			}
			return;
		}
		bool flag = (base.rectChildren.Count & 1) == 1;
		int j = 0;
		int num;
		for (num = base.rectChildren.Count / 2; j < num; j++)
		{
			RectTransform rect2 = base.rectChildren[j];
			SetChildAlongAxis(rect2, 0, (flag ? (Width * 0.5f) : 0f) + (float)base.padding.left + (float)j * Width + (float)j * Spacing.x, Width);
			SetChildAlongAxis(rect2, 1, base.padding.top, Height + ExtraHeight);
		}
		for (; j < base.rectChildren.Count; j++)
		{
			RectTransform rect3 = base.rectChildren[j];
			int num2 = j - num;
			SetChildAlongAxis(rect3, 0, (float)base.padding.left + (float)num2 * Width + (float)num2 * Spacing.x, Width);
			SetChildAlongAxis(rect3, 1, (float)base.padding.top + Height + Spacing.y, Height + ExtraHeight);
		}
	}

	public override void SetLayoutVertical()
	{
	}
}
