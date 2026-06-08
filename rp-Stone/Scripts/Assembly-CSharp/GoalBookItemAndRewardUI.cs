using UnityEngine;

public class GoalBookItemAndRewardUI : AsciiObject
{
	public int itemX;

	public int itemY;

	public AsciiString enchantBonusLabel;

	public Color progressBarColor = ColorConstants.lightGrey;

	public int progressBarX;

	public int progressBarY;

	private AsciiSprite itemIcon;

	private AsciiSprite treasureIcon;

	private int currentProgress;

	private int goalCount;

	private bool allComplete;

	private int defaultHeight = -1;

	private bool isAnimating;

	private int elapsedTics;

	public void Setup(string iconPath, ItemData.Element element, int currentProgress, int goalCount, int rewardEnchantBonus, bool transitionBetweenGoals)
	{
		isAnimating = transitionBetweenGoals;
		elapsedTics = 0;
		itemIcon = IconLoader.Singleton.GetSharedIcon(iconPath, 'o', ItemData.CharForElement(element));
		if (itemIcon != null)
		{
			itemIcon.Load();
		}
		if (defaultHeight <= 0)
		{
			defaultHeight = Height;
		}
		if (itemIcon != null && itemIcon.height > 5)
		{
			Height = defaultHeight + 1;
		}
		this.currentProgress = currentProgress;
		this.goalCount = goalCount;
		if (currentProgress < goalCount)
		{
			Color colorForBonus = ItemData.Rarity.GetColorForBonus(rewardEnchantBonus);
			if (treasureIcon != null)
			{
				treasureIcon.colorOverride = colorForBonus;
			}
			enchantBonusLabel.color = colorForBonus;
			enchantBonusLabel.SetValue("+" + rewardEnchantBonus);
			allComplete = false;
		}
		else
		{
			allComplete = true;
		}
	}

	public void NextProgressStep()
	{
	}

	public override void UpdateTic()
	{
		if (isAnimating && ++elapsedTics >= 15)
		{
			isAnimating = false;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		AsciiRenderProcedural.Clip clip = r.clip;
		clip.top = 0;
		r.PushClip(clip, computeIntersection: false);
		if (allComplete)
		{
			if (itemIcon != null)
			{
				itemIcon.Draw(r, offsetX + itemX + 7, offsetY + itemY);
			}
			r.PopClip();
			return;
		}
		if (itemIcon != null)
		{
			itemIcon.Draw(r, offsetX + itemX, offsetY + itemY);
		}
		r.PopClip();
		if (goalCount > 5)
		{
			offsetX--;
		}
		if (treasureIcon != null)
		{
			treasureIcon.Draw(r, offsetX, offsetY);
		}
		enchantBonusLabel.Draw(r, offsetX, offsetY);
		int num = offsetX + progressBarX;
		int y = offsetY + progressBarY;
		for (int i = 0; i < goalCount + 2; i++)
		{
			Color rewardGreen = progressBarColor;
			int value = 91;
			if (i == goalCount + 1)
			{
				value = 93;
			}
			else if (i - 1 == currentProgress)
			{
				value = 111;
				rewardGreen = ColorConstants.rewardGreen;
				if (isAnimating)
				{
					switch (elapsedTics / 3)
					{
					case 0:
						rewardGreen = progressBarColor;
						value = SpecialSymbols.Map('·');
						break;
					case 1:
						value = SpecialSymbols.Map('·');
						break;
					case 2:
						value = SpecialSymbols.Map('•');
						break;
					case 4:
						value = SpecialSymbols.Map('O');
						break;
					}
				}
			}
			else if (i == currentProgress && isAnimating)
			{
				int num2 = elapsedTics / 3;
				value = SpecialSymbols.Map('•');
				if (num2 == 0)
				{
					rewardGreen = ColorConstants.rewardGreen;
					value = 111;
				}
				switch (num2)
				{
				case 1:
					value = 111;
					break;
				case 3:
					value = SpecialSymbols.Map('·');
					break;
				}
			}
			else if (i - 1 > currentProgress)
			{
				value = SpecialSymbols.Map('·');
			}
			else if (i > 0)
			{
				value = SpecialSymbols.Map('•');
			}
			r.SetCell(num + i, y, value, rewardGreen);
		}
	}

	private void Awake()
	{
		treasureIcon = GetComponent<AsciiSprite>();
	}
}
