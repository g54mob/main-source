using UnityEngine;

public class AsciiSpritePPRainbow : AsciiSpritePPShader
{
	public float rainbowSize = 2f;

	public float velocity = -0.4f;

	[Range(-1f, 1f)]
	public float luminance = 0.5f;

	private float elapsedTime;

	private void Update()
	{
		elapsedTime += Time.deltaTime * velocity;
	}

	protected override void ApplyShading(AsciiCellProcedural cell, AsciiData.Page page, int[][] data, int i, int j, int x, int y)
	{
		cell.SetForeground(GetRainbowHue(elapsedTime + (float)i / (rainbowSize * (float)page.width)));
	}

	private Color GetRainbowHue(float t)
	{
		Color a = Color.HSVToRGB(Mathf.Repeat(t, 1f), 1f, 1f);
		if (luminance < 0f)
		{
			return Color.Lerp(a, Color.black, 0f - luminance);
		}
		return Color.Lerp(a, Color.white, luminance);
	}

	public Color ToRGB(float Hue, float Luminosity, float Saturation = 1f)
	{
		Color result = default(Color);
		if (Saturation == 0f)
		{
			result.r = (int)(byte)(Luminosity * 255f);
			result.g = (int)(byte)(Luminosity * 255f);
			result.b = (int)(byte)(Luminosity * 255f);
		}
		else
		{
			float num = ((!((double)Luminosity < 0.5)) ? (Luminosity + Saturation - Saturation * Luminosity) : (Luminosity * (1f + Saturation)));
			float v = 2f * Luminosity - num;
			result.r = (int)(byte)(255f * Hue_2_RGB(v, num, Hue + 0f));
			result.g = (int)(byte)(255f * Hue_2_RGB(v, num, Hue));
			result.b = (int)(byte)(255f * Hue_2_RGB(v, num, Hue - 0f));
		}
		return result;
	}

	private float Hue_2_RGB(float v1, float v2, float vH)
	{
		if (vH < 0f)
		{
			vH += 1f;
		}
		if (vH > 1f)
		{
			vH -= 1f;
		}
		if (6f * vH < 1f)
		{
			return v1 + (v2 - v1) * 6f * vH;
		}
		if (2f * vH < 1f)
		{
			return v2;
		}
		if (3f * vH < 2f)
		{
			return v1 + (v2 - v1) * (0f - vH) * 6f;
		}
		return v1;
	}
}
