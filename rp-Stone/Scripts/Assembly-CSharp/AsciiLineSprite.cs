using System;
using Stonescript.Types;
using UnityEngine;

public class AsciiLineSprite : AsciiSprite
{
	public Vector2 start;

	public Vector2 end;

	public float dissolve;

	public float thickness;

	public float verticalScale = 2f;

	public bool debugBG;

	private float thresholdA = 0.1f;

	private float stepThreshA = 0.26f;

	private float thresholdB = 0.27f;

	private float thresholdC = 0.36f;

	private float stepThreshC = 0.27f;

	private float thresholdD = 0.54f;

	private float thresholdE = 0.75f;

	private float thresholdF = 0.84f;

	private float stepThreshF = 0.4f;

	private System.Random rnd;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Draw(r, offsetX, offsetY, 1f, ColorConstants.white);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		if (thickness > 0f)
		{
			Vector2 vector = new Vector2(end.x - start.x, (end.y - start.y) * verticalScale);
			vector.Normalize();
			float num = vector.y * thickness;
			float num2 = (0f - vector.x) * thickness;
			num2 /= verticalScale;
			DoDraw(r, offsetX, offsetY, colorMultiply, tint, start.x + num, start.y + num2, end.x + num, end.y + num2);
			DoDraw(r, offsetX, offsetY, colorMultiply, tint, start.x - num, start.y - num2, end.x - num, end.y - num2);
		}
		else
		{
			DoDraw(r, offsetX, offsetY, colorMultiply, tint, start.x, start.y, end.x, end.y);
		}
	}

	private void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint, float startX, float startY, float endX, float endY)
	{
		startX += (float)offsetX;
		endX += (float)offsetX;
		startY += (float)offsetY;
		endY += (float)offsetY;
		float num = startX;
		float num2 = endX;
		float num3 = startY;
		float num4 = endY;
		if (num > num2)
		{
			num = endX;
			num2 = startX;
			num3 = endY;
			num4 = startY;
		}
		float num5 = num2 - num;
		if (!(num5 > 1f))
		{
			return;
		}
		float num6 = 0f;
		float num7 = Mathf.Repeat(num, 1f);
		num6 = ((!(num7 > 0.5f)) ? (num6 - num7) : (num6 + num7));
		float num8 = 0f;
		if (num3 != num4)
		{
			num8 = Mathf.Abs(num3 - num4) / num5;
		}
		InitIntegrityRng(offsetX + (offsetY << 5));
		while (num6 < num5)
		{
			float t = num6 / num5;
			float f = num + num6;
			float num9 = Mathf.Lerp(num3, num4, t);
			num6 += 1f;
			if (!TestIntegrity())
			{
				continue;
			}
			AsciiCellProcedural cell = r.GetCell(Mathf.RoundToInt(f), Mathf.FloorToInt(num9));
			if (cell == null)
			{
				continue;
			}
			Color foreground = colorOverride * colorMultiply * tint;
			cell.SetForeground(foreground);
			float num10 = Mathf.Repeat(num9, 1f);
			if (num10 < thresholdA && num8 < stepThreshA && num8 < stepThreshF)
			{
				cell.SetValue(SpecialSymbols.Map('\u00af'));
			}
			else if (num10 > thresholdF && num8 < stepThreshF)
			{
				cell.SetValue(95);
			}
			else if (num10 < thresholdB)
			{
				if (num4 > num3)
				{
					cell.SetValue(96);
				}
				else
				{
					cell.SetValue(SpecialSymbols.Map('\u00b4'));
				}
			}
			else if (num10 < thresholdC && num8 < stepThreshC)
			{
				cell.SetValue(39);
			}
			else if (num10 > thresholdE && num8 < stepThreshC)
			{
				cell.SetValue(44);
			}
			else if (num10 > thresholdD)
			{
				cell.SetValue(46);
			}
			else
			{
				cell.SetValue(45);
			}
			if (debugBG)
			{
				cell.SetBackground(ColorConstants.darkGrey);
			}
		}
	}

	private bool TestIntegrity()
	{
		if (dissolve <= 0f)
		{
			return true;
		}
		return rnd.NextDouble() <= (double)(1f - dissolve);
	}

	private void InitIntegrityRng(int seed)
	{
		rnd = new System.Random(seed);
	}

	public override void Load()
	{
	}

	[StonescriptNativeGetter("startX")]
	public object Property_GetStartX()
	{
		return start.x;
	}

	[StonescriptNativeSetter("startX")]
	public void Property_SetStartX(object value)
	{
		start.x = DataTypes.ToFloat(value);
	}

	[StonescriptNativeGetter("startY")]
	public object Property_GetStartY()
	{
		return start.y;
	}

	[StonescriptNativeSetter("startY")]
	public void Property_SetStartY(object value)
	{
		start.y = DataTypes.ToFloat(value);
	}

	[StonescriptNativeGetter("endX")]
	public object Property_GetEndX()
	{
		return end.x;
	}

	[StonescriptNativeSetter("endX")]
	public void Property_SetEndX(object value)
	{
		end.x = DataTypes.ToFloat(value);
	}

	[StonescriptNativeGetter("endY")]
	public object Property_GetEndY()
	{
		return end.y;
	}

	[StonescriptNativeSetter("endY")]
	public void Property_SetEndY(object value)
	{
		end.y = DataTypes.ToFloat(value);
	}
}
