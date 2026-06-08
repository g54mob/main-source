using UnityEngine;

public class AsciiSpritePPPrismatic : AsciiSpritePPShader
{
	public Color tint = Color.black;

	private float period = 1f;

	public float lerpSpeed = 10f;

	private static float lastTime;

	private static Color targetColor;

	private Color currentColor;

	private bool isEffectEnabled = true;

	public void SetEffectEnabled(bool value)
	{
		isEffectEnabled = value;
	}

	private static Color RandomColor()
	{
		float value = Random.value;
		float s = 1.1f - 0.1f / (Random.value + 0.11f);
		float v = 1.1f - 0.1f / (Random.value + 0.11f);
		return Color.HSVToRGB(value, s, v);
	}

	private void Update()
	{
		if (!isEffectEnabled)
		{
			return;
		}
		if (tint != Color.black)
		{
			currentColor = tint;
			return;
		}
		bool flag = false;
		if (Time.realtimeSinceStartup - lastTime >= period * 4f)
		{
			lastTime = Time.realtimeSinceStartup;
			flag = true;
		}
		else
		{
			while (Time.realtimeSinceStartup - lastTime >= period)
			{
				lastTime += period;
				flag = true;
			}
		}
		if (flag)
		{
			targetColor = RandomColor();
		}
		float t = Time.deltaTime * lerpSpeed;
		currentColor = Color.Lerp(currentColor, targetColor, t);
	}

	protected override void ApplyShading(AsciiCellProcedural cell, AsciiData.Page page, int[][] data, int i, int j, int x, int y)
	{
		if (isEffectEnabled)
		{
			cell.SetForeground(currentColor);
		}
	}
}
