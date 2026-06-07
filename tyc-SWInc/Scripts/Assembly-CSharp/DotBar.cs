using UnityEngine;
using UnityEngine.UI;

public class DotBar : MaskableGraphic
{
	public RectOffset padding;

	public Texture DotImage;

	public int Count;

	public float InnerPadding;

	public bool KeepSquare;

	public Color Highlight;

	public Color Normal;

	public Vector4 SliceBorders;

	private float _value;

	public override Texture mainTexture
	{
		get
		{
			if (!(DotImage == null))
			{
				return DotImage;
			}
			return Graphic.s_WhiteTexture;
		}
	}

	public float Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			UpdateMe();
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Vector2 corner = Vector2.zero - base.rectTransform.pivot;
		Vector2 corner2 = Vector2.one - base.rectTransform.pivot;
		corner = new Vector2(corner.x * base.rectTransform.rect.width, corner.y * base.rectTransform.rect.height);
		corner2 = new Vector2(corner2.x * base.rectTransform.rect.width, corner2.y * base.rectTransform.rect.height);
		GUIProgressBar.Draw9Slice(corner, corner2, SliceBorders, color, vh);
		float num = (corner2.x - corner.x - (float)(padding.right + padding.left) - InnerPadding * ((float)Count - 1f)) / (float)Count;
		float num2 = corner.x + (float)padding.left;
		float num3 = corner2.y - corner.y - (float)(padding.bottom + padding.top);
		float num4 = num;
		float num5 = 0f;
		if (KeepSquare)
		{
			num = (num3 = Mathf.Min(num, num3));
			num5 = (num4 - num) / 2f;
		}
		int num6 = Mathf.RoundToInt(Value * (float)(Count - 1));
		for (int i = 0; i < Count; i++)
		{
			ColorBarButton.DrawRectUV(new Rect(num2 + num5, corner.y + (float)padding.top, num, num3), (i == num6) ? Highlight : Normal, vh);
			num2 += num4 + InnerPadding;
		}
	}

	private void UpdateMe()
	{
		SetVerticesDirty();
	}
}
