using UnityEngine;

public class PugTextDigits : MonoBehaviour
{
	public PugFont font;

	public int integerDigits = 4;

	public int decimalDigits;

	public int radix = 10;

	public bool stripLeadingZeros = true;

	public int commaInterval;

	public bool sign;

	public PugTextStyle style = new PugTextStyle
	{
		horizontalAlignment = PugTextStyle.HorizontalAlignment.right
	};

	private SpriteRenderer[] allSRs;

	private SpriteRenderer overflowSR;

	private SpriteRenderer[] integerSRs;

	private SpriteRenderer[] decimalSRs;

	private SpriteRenderer[] commaSRs;

	private Sprite[] numbers;

	private Sprite plus;

	private Sprite minus;

	private Sprite overflow;

	private const string numberChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	[Header("Leave this blank to auto-generate SRs")]
	public SpriteRenderer[] hardcodedSRs;

	[Header("Won't work properly for floats")]
	public bool alignLeft;

	private void Awake()
	{
		int num = 0;
		string text = "";
		for (int i = 0; i < integerDigits; i++)
		{
			if (commaInterval > 0 && i != 0 && i % commaInterval == 0)
			{
				text = "," + text;
				num++;
			}
			text = "0" + text;
		}
		if (sign)
		{
			text = "+" + text;
		}
		if (decimalDigits > 0)
		{
			text += ".";
			for (int j = 0; j < decimalDigits; j++)
			{
				text += "9";
			}
		}
		if (hardcodedSRs == null || hardcodedSRs.Length == 0)
		{
			font.RenderNonPooled(text, style, base.transform, out var _, out var _);
			allSRs = GetComponentsInChildren<SpriteRenderer>();
		}
		else
		{
			allSRs = hardcodedSRs;
		}
		commaSRs = new SpriteRenderer[num];
		integerSRs = new SpriteRenderer[integerDigits];
		decimalSRs = new SpriteRenderer[decimalDigits];
		overflowSR = allSRs[0];
		int num2 = num - 1;
		int num3 = integerDigits - 1;
		int num4 = 0;
		for (int k = 0; k < text.Length; k++)
		{
			switch (text[k])
			{
			case '+':
				overflowSR = allSRs[k];
				break;
			case ',':
				commaSRs[num2--] = allSRs[k];
				break;
			case '0':
				integerSRs[num3--] = allSRs[k];
				break;
			case '9':
				decimalSRs[num4++] = allSRs[k];
				break;
			}
		}
		numbers = new Sprite[radix];
		for (int l = 0; l < radix; l++)
		{
			numbers[l] = font.GetGlyphSprite("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"[l]);
		}
		plus = font.GetGlyphSprite('+');
		minus = font.GetGlyphSprite('-');
		overflow = font.GetGlyphSprite('#');
	}

	public void RenderInt(int n)
	{
		bool flag = false;
		if (n < 0)
		{
			flag = true;
			n = -n;
		}
		int num = 0;
		int num2 = n;
		for (int i = 0; i < integerSRs.Length; i++)
		{
			integerSRs[i].enabled = true;
			int num3 = num2 % radix;
			if (num3 != 0)
			{
				num = i;
			}
			integerSRs[i].sprite = numbers[num3];
			num2 /= radix;
		}
		int num4 = num + 1;
		if (stripLeadingZeros)
		{
			for (int j = num + 1; j < integerSRs.Length; j++)
			{
				integerSRs[j].enabled = false;
			}
		}
		if (num2 != 0)
		{
			overflowSR.enabled = true;
			overflowSR.sprite = overflow;
		}
		else if (sign)
		{
			overflowSR.enabled = true;
			overflowSR.sprite = (flag ? minus : plus);
		}
		if (alignLeft && num4 < integerSRs.Length)
		{
			int num5 = integerSRs.Length - num4;
			for (int num6 = num4 - 1; num6 >= 0; num6--)
			{
				integerSRs[num6 + num5].enabled = true;
				integerSRs[num6 + num5].sprite = integerSRs[num6].sprite;
			}
			for (int k = 0; k < num5; k++)
			{
				integerSRs[k].enabled = false;
			}
		}
	}

	public void RenderFloat(float n)
	{
		RenderInt((int)n);
		if (n < 0f)
		{
			n *= -1f;
		}
		float num = n - (float)(int)n;
		for (int i = 0; i < decimalSRs.Length; i++)
		{
			num *= (float)radix;
			int num2 = (int)num % radix;
			decimalSRs[i].sprite = numbers[num2];
		}
	}
}
