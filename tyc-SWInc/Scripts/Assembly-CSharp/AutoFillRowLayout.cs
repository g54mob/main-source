using UnityEngine;
using UnityEngine.UI;

public class AutoFillRowLayout : LayoutGroup
{
	public float RowHeight = 24f;

	public Vector2 Spacing;

	public bool SetPreferred;

	private float _lastHeight;

	public override float preferredHeight
	{
		get
		{
			if (!SetPreferred)
			{
				return base.preferredHeight;
			}
			return _lastHeight;
		}
	}

	public override void CalculateLayoutInputVertical()
	{
		SetLayout();
	}

	public override void SetLayoutHorizontal()
	{
	}

	public override void SetLayoutVertical()
	{
	}

	private void SetLayout()
	{
		float width = base.rectTransform.rect.width;
		int num = 0;
		float num2 = base.padding.left;
		bool flag = true;
		for (int i = 0; i < base.rectChildren.Count; i++)
		{
			RectTransform rectTransform = base.rectChildren[i];
			int num3;
			if (!flag)
			{
				num3 = ((num2 + rectTransform.rect.width > width - (float)base.padding.right) ? 1 : 0);
				if (num3 != 0)
				{
					num++;
					num2 = base.padding.left;
					_lastHeight += RowHeight;
				}
			}
			else
			{
				num3 = 0;
			}
			SetChildAlongAxis(rectTransform, 0, num2);
			SetChildAlongAxis(rectTransform, 1, (float)base.padding.top + (float)num * (RowHeight + Spacing.y), RowHeight);
			num2 += rectTransform.rect.width + Spacing.x;
			flag = (byte)num3 != 0;
		}
		_lastHeight = (float)(num + 1) * RowHeight + (float)base.padding.vertical + Spacing.y * (float)num;
	}
}
