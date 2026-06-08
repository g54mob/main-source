using UnityEngine;

public class AsciiSpritePPShiny : AsciiSpritePPShader
{
	public Color tint = Color.white;

	public float velocity = 2.5f;

	public float power = 10.1f;

	[Range(0f, 5f)]
	public float amplitude = 1.7f;

	[Range(0f, 1f)]
	public float darken = 0.35f;

	[Range(0f, 1f)]
	public float shineWhiteness = 0.65f;

	private bool isEffectEnabled = true;

	private float elapsedTime;

	public void SetEffectEnabled(bool value)
	{
		isEffectEnabled = value;
	}

	private void Update()
	{
		if (isEffectEnabled)
		{
			elapsedTime += Time.deltaTime * velocity;
		}
	}

	protected override void ApplyShading(AsciiCellProcedural cell, AsciiData.Page page, int[][] data, int i, int j, int x, int y)
	{
		Color color = cell.GetForeground();
		color *= tint;
		if (isEffectEnabled)
		{
			float t = (Mathf.Sin(elapsedTime * 0.5f + (float)i * 3f / (float)page.width + (float)j * 3f / (float)page.height) + 1f) / 2f;
			color = Color.Lerp(color, color * darken, t);
			t = Mathf.Pow(Mathf.Sin(elapsedTime + (float)i / (float)page.width - (float)j / (float)page.height), power);
			if (float.IsNaN(t))
			{
				t = 0f;
			}
			t *= amplitude;
			Color b = Color.Lerp(color * (t + 1f), ColorConstants.white, shineWhiteness);
			color = Color.Lerp(color, b, t);
		}
		cell.SetForeground(color);
	}
}
