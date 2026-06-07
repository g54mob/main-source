using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
	public int MaxColumns = 4;

	public float PreferredButtonHeight = 24f;

	public bool UsePreferred;

	public Vector2 Spacing;

	public bool UseUIBorder;

	public bool TopLeft = true;

	public bool TopRight = true;

	public bool BottomLeft = true;

	public bool BottomRight = true;

	public bool KeepSquare;

	public bool PreferSplit;

	public int MinRows = 1;

	public override float preferredHeight
	{
		get
		{
			if (UsePreferred)
			{
				int num = Mathf.CeilToInt((float)base.rectChildren.Count / (float)MaxColumns);
				return (float)num * PreferredButtonHeight + (float)base.padding.vertical + Spacing.y * (float)(num - 1);
			}
			return base.preferredHeight;
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

	private void SetLayout()
	{
		int num = Mathf.CeilToInt((float)base.rectChildren.Count / (float)MaxColumns);
		bool flag = false;
		if (num < MinRows && base.rectTransform.rect.height / (float)num > base.rectTransform.rect.width)
		{
			num = MinRows;
			flag = true;
		}
		else if (PreferSplit && base.rectChildren.Count < MinRows * MaxColumns)
		{
			flag = true;
		}
		float num2 = (UsePreferred ? PreferredButtonHeight : ((base.rectTransform.rect.height - (float)base.padding.vertical - Spacing.y * (float)(num - 1)) / (float)num));
		for (int i = 0; i < num; i++)
		{
			bool flag2 = i == 0;
			bool flag3 = i == num - 1;
			int num3 = MaxColumns;
			if (flag)
			{
				num3 = Mathf.CeilToInt((float)base.rectChildren.Count / (float)num);
			}
			int num4 = i * num3;
			int num5 = Mathf.Min(base.rectChildren.Count, num4 + num3) - num4;
			float num6 = (base.rectTransform.rect.width - (float)base.padding.horizontal - Spacing.x * (float)(num5 - 1)) / (float)num5;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = num6;
			float num10 = num2;
			if (KeepSquare)
			{
				num9 = (num10 = Mathf.Min(num6, num2));
				num7 = (num6 - num9) / 2f;
				num8 = (num2 - num10) / 2f;
			}
			for (int j = 0; j < num5; j++)
			{
				bool flag4 = j == 0;
				bool flag5 = j == num5 - 1;
				RectTransform rectTransform = base.rectChildren[num4 + j];
				SetChildAlongAxis(rectTransform, 0, num7 + (float)base.padding.left + (float)j * num6 + (float)j * Spacing.x, num9);
				SetChildAlongAxis(rectTransform, 1, num8 + (float)base.padding.top + (float)i * Spacing.y + (float)i * num2, num10);
				if (!UseUIBorder || !Application.isPlaying)
				{
					continue;
				}
				Image component = rectTransform.GetComponent<Image>();
				GUIProgressBar gUIProgressBar = null;
				Sprite spr;
				if (component == null)
				{
					gUIProgressBar = rectTransform.GetComponent<GUIProgressBar>();
					spr = (((object)gUIProgressBar != null) ? gUIProgressBar.MySprite : null);
				}
				else
				{
					spr = component.sprite;
				}
				Image[] array = null;
				if (component == null && gUIProgressBar == null)
				{
					array = rectTransform.GetComponentsInChildren<Image>();
				}
				if ((!(component != null) && !(gUIProgressBar != null) && (array == null || array.Length == 0)) || !ObjectDatabase.Instance.IsValidBorderSprite(spr))
				{
					continue;
				}
				Sprite sprite = ObjectDatabase.Instance.GetSprite(flag2 && flag5 && TopRight, flag3 && flag5 && BottomRight, flag3 && flag4 && BottomLeft, flag2 && flag4 && TopLeft);
				if (gUIProgressBar != null)
				{
					gUIProgressBar.MySprite = sprite;
					continue;
				}
				if (component != null)
				{
					component.sprite = sprite;
					continue;
				}
				for (int k = 0; k < array.Length; k++)
				{
					array[k].sprite = sprite;
				}
			}
		}
	}
}
