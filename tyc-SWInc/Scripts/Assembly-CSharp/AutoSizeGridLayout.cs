using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSizeGridLayout : LayoutGroup
{
	public float RowHeight = 24f;

	public bool ForceHeight;

	public bool SetPreferred;

	public bool UsePreferred;

	public bool CrossPattern;

	public float MinWidth = 128f;

	public Vector2 Spacing;

	private float _lastRows = 1f;

	public override float preferredHeight
	{
		get
		{
			if (ForceHeight)
			{
				float num = base.rectTransform.rect.width - (float)base.padding.horizontal;
				int num2 = Mathf.Min(base.rectChildren.Count, Mathf.FloorToInt(num / MinWidth));
				return (float)Mathf.CeilToInt((float)base.rectChildren.Count / (float)num2) * RowHeight;
			}
			if (SetPreferred)
			{
				return _lastRows;
			}
			return base.preferredHeight;
		}
	}

	public override void CalculateLayoutInputVertical()
	{
	}

	public override void SetLayoutHorizontal()
	{
		float num = base.rectTransform.rect.width - (float)base.padding.horizontal;
		int num2 = Mathf.Min(base.rectChildren.Count, Mathf.FloorToInt(num / MinWidth));
		if (num2 <= 0)
		{
			return;
		}
		int num3 = Mathf.CeilToInt((float)base.rectChildren.Count / (float)num2);
		int num4 = 0;
		int num5 = 0;
		float num6 = num / (float)num2 - Spacing.x;
		float num7 = (base.rectTransform.rect.height - (float)base.padding.vertical) / (float)num3 - Spacing.y;
		float num8 = (ForceHeight ? RowHeight : num7);
		float num9 = (ForceHeight ? (num7 / 2f - RowHeight / 2f) : 0f);
		float[] array = null;
		if (UsePreferred)
		{
			array = new float[num2];
		}
		List<RectTransform> list = base.rectChildren;
		if (CrossPattern)
		{
			list = new List<RectTransform>();
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					int num10 = j * num3 + i;
					if (num10 < base.rectChildren.Count)
					{
						list.Add(base.rectChildren[num10]);
					}
				}
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			float num11 = (UsePreferred ? RowHeight : num8);
			if (!ForceHeight)
			{
				ILayoutElement componentInChildren = list[k].GetComponentInChildren<ILayoutElement>();
				if (componentInChildren != null)
				{
					num11 = componentInChildren.preferredHeight;
				}
			}
			SetChildAlongAxis(list[k], 0, (float)base.padding.left + (float)num5 * num6 + Spacing.x * (float)num5, num6 + ((num5 == num2 - 1) ? Spacing.x : 0f));
			float num12 = (UsePreferred ? array[num5] : ((float)num4 * num8));
			SetChildAlongAxis(list[k], 1, num9 + (float)base.padding.top + num12 + Spacing.y * (float)num4, num11 + ((num4 == num3 - 1) ? Spacing.y : 0f));
			if (UsePreferred)
			{
				array[num5] += num11;
			}
			num5++;
			if (num5 == num2)
			{
				num5 = 0;
				num4++;
			}
		}
		_lastRows = num9 + (float)base.padding.top + (UsePreferred ? array.MaxOrDefault(0f) : ((float)num4 * num8)) + Spacing.y * (float)num4;
	}

	public override void SetLayoutVertical()
	{
	}
}
