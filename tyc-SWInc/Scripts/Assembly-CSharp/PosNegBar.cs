using UnityEngine;
using UnityEngine.UI;

public class PosNegBar : MaskableGraphic
{
	public Vector2 IconSize;

	public Color PositiveColor;

	public Color NegativeColor;

	public bool FromCenter = true;

	public Texture IconTexture;

	public RectOffset Padding;

	public float IconSpacing;

	private float _positive = 3.5f;

	private float _negative = 3.5f;

	public override Texture mainTexture
	{
		get
		{
			return IconTexture;
		}
	}

	public float Positive
	{
		get
		{
			return _positive;
		}
		set
		{
			_positive = value;
			SetVerticesDirty();
		}
	}

	public float Negative
	{
		get
		{
			return _negative;
		}
		set
		{
			_negative = value;
			SetVerticesDirty();
		}
	}

	public void SetValues(float positive, float negative)
	{
		_positive = positive;
		_negative = negative;
		SetVerticesDirty();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (Positive <= 0f && Negative <= 0f)
		{
			return;
		}
		Vector2 zero = Vector2.zero;
		Vector2 zero2 = Vector2.zero;
		zero.x = 0f;
		zero.y = 0f;
		zero2.x = 1f;
		zero2.y = 1f;
		zero.x -= base.rectTransform.pivot.x;
		zero.y -= base.rectTransform.pivot.y;
		zero2.x -= base.rectTransform.pivot.x;
		zero2.y -= base.rectTransform.pivot.y;
		zero.x *= base.rectTransform.rect.width;
		zero.y *= base.rectTransform.rect.height;
		zero2.x *= base.rectTransform.rect.width;
		zero2.y *= base.rectTransform.rect.height;
		zero += new Vector2(Padding.left, Padding.bottom);
		zero2 -= new Vector2(Padding.right, Padding.top);
		if (FromCenter)
		{
			float num = (zero.x + zero2.x) / 2f;
			int num2 = Mathf.CeilToInt(Positive);
			for (int i = 0; i < num2; i++)
			{
				float alpha = 1f;
				if (i == num2 - 1)
				{
					alpha = 1f - ((float)num2 - Positive);
				}
				DrawIcon(num + (float)i * (IconSize.x + IconSpacing), zero2.y, PositiveColor, alpha, false, vh);
			}
			num2 = Mathf.CeilToInt(Negative);
			for (int j = 0; j < num2; j++)
			{
				float alpha2 = 1f;
				if (j == num2 - 1)
				{
					alpha2 = 1f - ((float)num2 - Negative);
				}
				DrawIcon(num - (float)(j + 1) * (IconSize.x + IconSpacing), zero2.y, NegativeColor, alpha2, true, vh);
			}
			return;
		}
		int num3 = Mathf.CeilToInt(Positive);
		for (int k = 0; k < num3; k++)
		{
			float alpha3 = 1f;
			if (k == num3 - 1)
			{
				alpha3 = 1f - ((float)num3 - Positive);
			}
			DrawIcon(zero2.x - (float)(k + 1) * (IconSize.x + IconSpacing), zero2.y, PositiveColor, alpha3, false, vh);
		}
		num3 = Mathf.CeilToInt(Negative);
		for (int l = 0; l < num3; l++)
		{
			float alpha4 = 1f;
			if (l == num3 - 1)
			{
				alpha4 = 1f - ((float)num3 - Negative);
			}
			DrawIcon(zero.x + (float)l * (IconSize.x + IconSpacing), zero2.y, NegativeColor, alpha4, true, vh);
		}
	}

	private void DrawIcon(float x, float y, Color col, float alpha, bool leftToRight, VertexHelper vh)
	{
		Color color = (col * this.color).Alpha(alpha);
		int num = ((!leftToRight) ? 1 : 0);
		int num2 = (leftToRight ? 1 : 0);
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				position = new Vector3(x, y, 0f),
				uv0 = new Vector2(num, 1f),
				color = color
			},
			new UIVertex
			{
				position = new Vector3(x + IconSize.x, y, 0f),
				uv0 = new Vector2(num2, 1f),
				color = color
			},
			new UIVertex
			{
				position = new Vector3(x + IconSize.x, y - IconSize.y, 0f),
				uv0 = new Vector2(num2, 0f),
				color = color
			},
			new UIVertex
			{
				position = new Vector3(x, y - IconSize.y, 0f),
				uv0 = new Vector2(num, 0f),
				color = color
			}
		});
	}
}
