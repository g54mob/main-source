using UnityEngine;
using UnityEngine.UI;

public class DynamicGridLayout : LayoutGroup
{
	public float[] Columns;

	public float RowHeight = 24f;

	public bool AutoRowHeight;

	public bool LastFill;

	public bool ForceMinHeight;

	public Vector2 Spacing;

	private static float[] DefaultColumn = new float[1] { 1f };

	public override float preferredHeight
	{
		get
		{
			if (!AutoRowHeight)
			{
				return GetFullHeight();
			}
			return base.preferredHeight;
		}
	}

	public override float minHeight
	{
		get
		{
			if (!ForceMinHeight)
			{
				return base.minHeight;
			}
			return preferredHeight;
		}
	}

	public override void CalculateLayoutInputVertical()
	{
	}

	public override void SetLayoutHorizontal()
	{
		SetLayout();
	}

	public override void SetLayoutVertical()
	{
	}

	private float GetRowHeight()
	{
		float height = base.rectTransform.rect.height;
		float num = Mathf.Ceil((float)base.rectChildren.Count / (float)Mathf.Max(1, Columns.Length));
		return (height - (float)base.padding.vertical - Spacing.y * num) / num;
	}

	private float GetChildHeight(RectTransform t, float actualHeight)
	{
		return Mathf.Max(LayoutUtility.GetMinHeight(t), actualHeight);
	}

	private float GetFullHeight()
	{
		if (Columns == null)
		{
			return base.padding.vertical;
		}
		float[] array = ((Columns.Length != 0) ? Columns : DefaultColumn);
		float num = base.padding.top;
		float num2 = RowHeight;
		for (int i = 0; i < base.rectChildren.Count; i++)
		{
			num2 = Mathf.Max(GetChildHeight(base.rectChildren[i], RowHeight), num2);
			if (base.rectChildren[i].name.StartsWith("-F") || (i > 0 && (i + 1) % array.Length == 0))
			{
				num += num2 + Spacing.y;
				num2 = RowHeight;
			}
		}
		return num - Spacing.y + (float)base.padding.bottom;
	}

	private void SetLayout()
	{
		if (Columns == null)
		{
			return;
		}
		float[] array = ((Columns.Length != 0) ? Columns : DefaultColumn);
		float num = 0f;
		float num2 = 0f;
		foreach (float num3 in array)
		{
			if (num3 > 0f)
			{
				num += num3;
			}
			else
			{
				num2 -= num3;
			}
		}
		if (num == 0f)
		{
			num = 1f;
			array = DefaultColumn;
		}
		float num4 = (AutoRowHeight ? GetRowHeight() : RowHeight);
		float num5 = base.padding.left;
		float num6 = base.padding.top;
		float num7 = base.rectTransform.rect.width - (float)base.padding.horizontal - Spacing.x * (float)(array.Length - 1) - num2;
		float num8 = num4;
		int num9 = 0;
		for (int j = 0; j < base.rectChildren.Count; j++)
		{
			int num10 = num9 % array.Length;
			bool flag = false;
			if (num10 == 0)
			{
				num5 = base.padding.left;
				if (base.rectChildren[j].name.StartsWith("-F"))
				{
					flag = true;
				}
			}
			float num11 = 0f - array[num10];
			float num12 = (AutoRowHeight ? num4 : GetChildHeight(base.rectChildren[j], num4));
			if (flag)
			{
				num11 = num7 + Spacing.x * (float)(array.Length - 1);
				if (j == base.rectChildren.Count - 1 && LastFill)
				{
					num12 = base.rectTransform.rect.height - num6;
				}
			}
			else if (num11 < 0f)
			{
				num11 = (0f - num7) * (num11 / num);
			}
			num8 = Mathf.Max(num12, num8);
			SetChildAlongAxis(base.rectChildren[j], 0, num5, num11);
			SetChildAlongAxis(base.rectChildren[j], 1, num6, num12);
			num5 += num11 + Spacing.x;
			if (flag)
			{
				num9 += array.Length - 1;
			}
			if (num9 > 0 && (num9 + 1) % array.Length == 0)
			{
				num6 += num8 + Spacing.y;
				num8 = num4;
			}
			num9++;
		}
	}
}
