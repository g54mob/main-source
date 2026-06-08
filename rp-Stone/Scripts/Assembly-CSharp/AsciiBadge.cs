using System;
using UnityEngine;

[Serializable]
public class AsciiBadge
{
	public Color backgroundColor = Color.red;

	public float secondsPerFrame = 0.05f;

	public AsciiString badgeString;

	private int _number;

	private float nextBadgeSizeChangeTime;

	private char[] badgeDrawSymbols = new char[3] { '·', '•', '◘' };

	private int badgeDrawStep = -2;

	private int lastBadgeNumberDrawn;

	private const int minStepValue = -2;

	public int number
	{
		get
		{
			return _number;
		}
		set
		{
			if (_number != value)
			{
				_number = value;
				UpdateString();
			}
		}
	}

	public void SkipAnimation()
	{
		if (number == 0)
		{
			badgeDrawStep = -2;
		}
		else
		{
			badgeDrawStep = badgeDrawSymbols.Length;
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (nextBadgeSizeChangeTime < Time.realtimeSinceStartup)
		{
			nextBadgeSizeChangeTime = Time.realtimeSinceStartup + secondsPerFrame;
			if (number == 0)
			{
				badgeDrawStep--;
			}
			else
			{
				badgeDrawStep++;
			}
			badgeDrawStep = Mathf.Clamp(badgeDrawStep, -2, badgeDrawSymbols.Length);
		}
		if (badgeDrawStep < 0)
		{
			return;
		}
		if (badgeDrawStep == badgeDrawSymbols.Length)
		{
			badgeString.Draw(r, offsetX, offsetY);
			return;
		}
		int x = offsetX + badgeString.PositionX;
		int y = offsetY + badgeString.PositionY;
		int value = SpecialSymbols.Map(badgeDrawSymbols[badgeDrawStep]);
		Color color = badgeString.backgroundColor;
		if (color != Color.white)
		{
			r.SetCell(x, y, value, color);
		}
	}

	private void UpdateString()
	{
		if (number < 0)
		{
			badgeString.SetValue("!");
		}
		else if (number > 0)
		{
			badgeString.SetValue(number.ToString());
		}
		badgeString.backgroundColor = backgroundColor;
	}
}
