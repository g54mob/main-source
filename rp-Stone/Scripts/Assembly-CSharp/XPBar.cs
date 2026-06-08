using UnityEngine;

public class XPBar : AsciiSprite
{
	public int levelNumber = 1;

	public int startXP;

	public int endXP = 100;

	public int totalXP = 100;

	public bool isMaxLevel;

	public float fillDuration = 1f;

	public bool playing;

	public bool loop;

	public AsciiString numberLabel;

	public AsciiString xpCurrentLabel;

	public AsciiString xpNextGoalLabel;

	public AsciiString maxLabel;

	public Color fillColor = Color.white;

	public int barWidth = 13;

	public int barOffsetX = -5;

	private float calculatedFillDuration;

	private int xpLength;

	private float elapsedTime;

	private float percent;

	private int prevLevelNumber = -1;

	public float pitchMin = 0.9f;

	public float pitchMax = 1.1f;

	private int _lastCurrentXP = -1;

	public void PrepareToShow()
	{
		playing = false;
		loop = false;
		elapsedTime = 0f;
		ProcomputeVariables();
		RefreshVisuals();
	}

	public void Play()
	{
		playing = true;
	}

	public void ClearXPValues()
	{
		xpCurrentLabel.Clear();
		xpNextGoalLabel.Clear();
	}

	private void ProcomputeVariables()
	{
		totalXP = Mathf.Max(1, totalXP);
		endXP = Mathf.Min(endXP, totalXP);
		xpLength = Mathf.Max(1, endXP - startXP);
		float num = 0.2f;
		float t = (float)xpLength / 40f;
		calculatedFillDuration = Mathf.Clamp(Mathf.Lerp(num, fillDuration, t), num, fillDuration);
	}

	public void SkipToEnd()
	{
		elapsedTime = calculatedFillDuration;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		bool flag = (levelNumber >= 10 && levelNumber <= 99) || levelNumber > 999;
		if (flag)
		{
			offsetX++;
		}
		if (prevLevelNumber != levelNumber)
		{
			prevLevelNumber = levelNumber;
			numberLabel.SetValue(Mathf.Max(1, levelNumber).ToString());
			SetFrameIndex(flag ? 1 : 0);
		}
		numberLabel.Draw(r, offsetX, offsetY);
		if (isMaxLevel)
		{
			maxLabel.Draw(r, offsetX, offsetY);
		}
		else
		{
			xpCurrentLabel.Draw(r, offsetX, offsetY);
			xpNextGoalLabel.Draw(r, offsetX, offsetY);
		}
		float num = percent * (float)barWidth;
		int num2 = Mathf.FloorToInt(num);
		float num3 = num - (float)num2;
		int i;
		for (i = 0; i < num2; i++)
		{
			SetCellFill(r, i + barOffsetX + offsetX, offsetY, fillColor);
		}
		if (i < barWidth)
		{
			SetCellFill(r, i + barOffsetX + offsetX, offsetY, fillColor * num3);
		}
	}

	private void SetCellFill(AsciiRenderProcedural r, int x, int y, Color c)
	{
		if (x >= r.clip.left && x < r.width - r.clip.right)
		{
			AsciiCellProcedural cell = r.GetCell(x, y);
			cell.SetBackground(c);
			cell.SetForeground((c.r < 0.5f) ? ColorConstants.white : ColorConstants.black);
		}
	}

	private void Update()
	{
		if (!playing)
		{
			return;
		}
		if (elapsedTime >= calculatedFillDuration)
		{
			if (loop)
			{
				elapsedTime = 0f;
				ProcomputeVariables();
			}
			else
			{
				elapsedTime = calculatedFillDuration;
				playing = false;
			}
		}
		elapsedTime += Utils.deltaTime;
		RefreshVisuals();
	}

	public void RefreshVisuals()
	{
		float num = Mathf.Min(1f, elapsedTime / calculatedFillDuration);
		percent = ((float)startXP + (float)xpLength * num) / (float)totalXP;
		if (percent >= 1f || isMaxLevel)
		{
			percent = 1f;
			isMaxLevel = true;
		}
		int num2 = ((num >= 1f) ? endXP : Mathf.Min(totalXP, (int)(percent * (float)totalXP)));
		if (_lastCurrentXP != num2)
		{
			_lastCurrentXP = num2;
			xpCurrentLabel.SetValue(num2.ToString());
			if (num2 != startXP)
			{
				Sfx sfx = SfxController.singleton.Play("xp_tick");
				if (sfx != null)
				{
					sfx.SetPitch(pitchMin + (pitchMax - pitchMin) * num);
				}
			}
		}
		xpNextGoalLabel.SetValue("/" + totalXP);
	}
}
