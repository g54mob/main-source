using System;
using UnityEngine;

public class AuraCircleSprite : AsciiSprite
{
	public float radius = 7f;

	public float walkX = 0.5f;

	public float verticalScale = 0.5f;

	public float funcAmplitude = 0.05f;

	public float funcFrequency = 150f;

	public float waveVel = 1f;

	public float velocity = 1f;

	public float animVerticalOffset;

	public float angle;

	public float finalYOffset;

	private float minWalk = 0.01f;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX -= pivotX;
		offsetY -= pivotY;
		float num = radius * radius;
		float num2 = Mathf.Max(minWalk, walkX);
		float num3 = 0f - Mathf.Ceil(radius);
		float num4 = 0f - num3;
		float f = angle * (MathF.PI / 180f);
		float num5 = Mathf.Cos(f);
		float num6 = Mathf.Sin(f);
		for (float num7 = num3; num7 <= num4; num7 += num2)
		{
			float num8 = num7 * num7;
			float num9 = num7 / radius;
			float num10 = Mathf.Cos(funcFrequency * (num9 + Time.realtimeSinceStartup * waveVel));
			float num11 = funcAmplitude * num10 * Mathf.Cos(1.5f * num9 * Mathf.Sin(6.3f * num9)) * (3f + Mathf.Cos(3f * num9));
			float num12 = Mathf.Repeat(Time.realtimeSinceStartup * velocity, 2f) - 1f;
			num12 = Mathf.Sin(num12 * MathF.PI * -0.5f) - num12 * animVerticalOffset;
			float num13 = num12 * Mathf.Sqrt(1f - num9 * num9);
			num13 *= radius;
			num11 += num13;
			float num14 = num7 * num5 - num11 * num6;
			float num15 = (num11 * num5 + num7 * num6) * verticalScale + finalYOffset;
			int num16 = Mathf.RoundToInt(num15);
			int num17 = Mathf.RoundToInt(Mathf.Abs(num14));
			int x = offsetX + ((num14 < 0f) ? (-num17) : num17);
			int y = offsetY + num16;
			AsciiCellProcedural cell = r.GetCell(x, y);
			if (cell == null)
			{
				continue;
			}
			char c = (char)cell.GetValue();
			bool flag = (num15 < 0f && ((float)num16 > num15 || num15 - (float)num16 < -0.5f)) || (num15 >= 0f && ((float)num16 > num15 || num15 - (float)num16 > 0.5f));
			if (!(num8 + num11 * num11 <= num))
			{
				continue;
			}
			cell.SetForeground(colorOverride);
			if (c == ':')
			{
				continue;
			}
			if (flag)
			{
				if (c == '.')
				{
					cell.SetValue(58);
				}
				else
				{
					cell.SetValue(39);
				}
			}
			else if (c == '\'')
			{
				cell.SetValue(58);
			}
			else
			{
				cell.SetValue(46);
			}
		}
	}

	public override void Load()
	{
	}
}
