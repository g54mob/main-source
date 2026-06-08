using UnityEngine;

public class RewardProgressCard : AsciiObject
{
	private enum RewardCardState
	{
		Hidden = 0,
		In1 = 1,
		In2 = 2,
		PreIncrementPause = 3,
		Incrementing = 4,
		LevelUp1 = 5,
		LevelUp2 = 6,
		LevelUp3 = 7,
		PostLevelUpPause = 8,
		Out = 9
	}

	private readonly int LEVEL_UP_DURATION = 15;

	public int iconPosX;

	public int iconPosY;

	public FilledProgressBar progressBar;

	public bool autosizeProgressBar = true;

	public AsciiString starTotalLabel;

	public int difficultyStarsX;

	public AsciiString enchantBonusLabel;

	public AsciiString descLabel;

	public AsciiString descLabel2;

	private RewardCardState currentRewardCardState;

	private int elapsedRewardCardTics;

	private int initialWidth;

	private int initialHeight;

	private int multiLineLayoutOffset;

	private Item item;

	private AsciiSprite icon;

	private float f_posX;

	private float f_velX;

	public float f_accelX = 1f;

	public float f_deccelX = 2f;

	public float f_accelOutX = 1f;

	private int currentProgress;

	private int targetProgress;

	private int maxProgress;

	private int showStars;

	private string desc;

	private Item nextItem;

	private int nextTargetProgress;

	private int nextMaxProgress;

	private bool levelUpPending;

	public void Setup(Item item, int currentProgress, int targetProgress, int maxProgress, int showStars = 0)
	{
		if (!(nextItem != null) || currentRewardCardState < RewardCardState.In1 || currentRewardCardState > RewardCardState.LevelUp3)
		{
			this.item = item;
			this.currentProgress = currentProgress;
			this.targetProgress = targetProgress;
			this.maxProgress = maxProgress;
			this.showStars = showStars;
			if (showStars > 0)
			{
				starTotalLabel.SetValue("☆ " + showStars);
			}
			else
			{
				starTotalLabel.Clear();
			}
			nextItem = null;
			UpdateContents();
			if (currentRewardCardState == RewardCardState.Hidden || currentRewardCardState == RewardCardState.Out)
			{
				SetRewardCardState(RewardCardState.In1);
			}
			else if (currentRewardCardState != RewardCardState.In1 && currentRewardCardState != RewardCardState.In2 && currentRewardCardState != RewardCardState.PreIncrementPause)
			{
				SetRewardCardState(RewardCardState.Incrementing);
			}
		}
	}

	public void Setup(Item item, int currentProgress, int targetProgress, int maxProgress, string desc)
	{
		this.desc = desc;
		Setup(item, currentProgress, targetProgress, maxProgress);
	}

	public void Setup(Item item, int currentProgress, int targetProgress, int maxProgress, string desc, int showStars)
	{
		this.desc = desc;
		Setup(item, currentProgress, targetProgress, maxProgress, showStars);
	}

	public void SetupNext(Item item, int nextTargetProgress, int nextProgress)
	{
		nextItem = item;
		this.nextTargetProgress = nextTargetProgress;
		nextMaxProgress = nextProgress;
	}

	private void UpdateContents()
	{
		if (item != null)
		{
			icon = item.GetIcon();
		}
		else
		{
			icon = null;
		}
		progressBar.percent = (float)currentProgress / (float)maxProgress;
		progressBar.targetPercent = progressBar.percent;
		if (autosizeProgressBar)
		{
			int num = Mathf.FloorToInt(Mathf.Log10(maxProgress)) + 1;
			progressBar.Width = num * 2 + 5;
			if (IsMaxedOut())
			{
				progressBar.label.SetValue(Te.xt("tid_ui_max_xp"));
				progressBar.label.alignment = AsciiString.Alignment.Center;
				progressBar.label.PositionX = progressBar.Width / 2;
			}
			else
			{
				progressBar.label.SetValue(currentProgress + "/" + maxProgress);
				progressBar.label.alignment = AsciiString.Alignment.Right;
				progressBar.label.PositionX = progressBar.Width - 3;
			}
			Width = initialWidth + progressBar.Width - 7;
		}
		else
		{
			progressBar.label.SetValue(currentProgress + "/" + maxProgress);
		}
		descLabel2.Clear();
		if (string.IsNullOrEmpty(desc))
		{
			descLabel.Clear();
			return;
		}
		int preferredWidth = Width - 2;
		string[] array = Utils.BreakIntoLines(desc, preferredWidth);
		descLabel.SetValue(array[0]);
		multiLineLayoutOffset = 1;
		Height = initialHeight + 1;
		if (array.Length > 1)
		{
			descLabel2.SetValue(array[1]);
			multiLineLayoutOffset++;
			Height++;
		}
	}

	private bool IsMaxedOut()
	{
		if (currentProgress == targetProgress)
		{
			return currentProgress == maxProgress;
		}
		return false;
	}

	public void LevelUpAnim()
	{
		levelUpPending = true;
	}

	private void SetRewardCardState(RewardCardState newState)
	{
		switch (newState)
		{
		case RewardCardState.In1:
			f_posX = 0f;
			f_velX = 0f;
			break;
		case RewardCardState.PreIncrementPause:
			f_posX = -Width;
			break;
		case RewardCardState.Incrementing:
			progressBar.targetPercent = (float)targetProgress / (float)maxProgress;
			break;
		case RewardCardState.LevelUp1:
			levelUpPending = false;
			SfxController.singleton.Play("level_up");
			break;
		case RewardCardState.LevelUp2:
			showStars = 0;
			break;
		case RewardCardState.LevelUp3:
			progressBar.targetPercent = (float)targetProgress / (float)maxProgress;
			break;
		case RewardCardState.Out:
			f_velX = 0f;
			break;
		}
		currentRewardCardState = newState;
		elapsedRewardCardTics = 0;
	}

	public override void UpdateTic()
	{
		if (currentRewardCardState == RewardCardState.Hidden)
		{
			return;
		}
		elapsedRewardCardTics++;
		if (currentRewardCardState == RewardCardState.In1)
		{
			f_velX -= f_accelX;
			f_posX += f_velX;
			if (f_posX < (float)(-Width))
			{
				SetRewardCardState(RewardCardState.In2);
			}
		}
		else if (currentRewardCardState == RewardCardState.In2)
		{
			f_velX += f_deccelX;
			f_posX += f_velX;
			if (f_posX >= (float)(-Width))
			{
				SetRewardCardState(RewardCardState.PreIncrementPause);
			}
		}
		else if (currentRewardCardState == RewardCardState.PreIncrementPause && elapsedRewardCardTics >= 15)
		{
			SetRewardCardState(RewardCardState.Incrementing);
		}
		else if (currentRewardCardState == RewardCardState.Incrementing && elapsedRewardCardTics >= 30 && progressBar.percent >= progressBar.targetPercent - 0.001f)
		{
			if (nextItem != null || levelUpPending)
			{
				SetRewardCardState(RewardCardState.LevelUp1);
			}
			else
			{
				SetRewardCardState(RewardCardState.PostLevelUpPause);
			}
		}
		else if (currentRewardCardState == RewardCardState.LevelUp1 && elapsedRewardCardTics >= LEVEL_UP_DURATION)
		{
			SetRewardCardState(currentRewardCardState + 1);
		}
		else if (currentRewardCardState == RewardCardState.LevelUp2)
		{
			if (elapsedRewardCardTics >= LEVEL_UP_DURATION)
			{
				SetRewardCardState(currentRewardCardState + 1);
			}
			else if (elapsedRewardCardTics == LEVEL_UP_DURATION / 2 && nextItem != null)
			{
				item = nextItem;
				nextItem = null;
				currentProgress = nextMaxProgress;
				targetProgress = nextTargetProgress;
				maxProgress = nextMaxProgress;
				UpdateContents();
			}
		}
		else if (currentRewardCardState == RewardCardState.LevelUp3 && elapsedRewardCardTics >= LEVEL_UP_DURATION)
		{
			SetRewardCardState(currentRewardCardState + 1);
		}
		else if (currentRewardCardState == RewardCardState.PostLevelUpPause && elapsedRewardCardTics >= 30)
		{
			SetRewardCardState(RewardCardState.Out);
		}
		else if (currentRewardCardState == RewardCardState.Out)
		{
			f_velX += f_accelOutX;
			f_posX += f_velX;
			if (f_posX > 0f)
			{
				SetRewardCardState(RewardCardState.Hidden);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentRewardCardState == RewardCardState.Hidden)
		{
			return;
		}
		offsetX += PositionX;
		offsetX += Mathf.RoundToInt(f_posX);
		offsetY += PositionY;
		DrawBorder(r, offsetX, offsetY);
		if (icon != null)
		{
			icon.Draw(r, offsetX + iconPosX, offsetY + iconPosY);
		}
		if ((currentRewardCardState == RewardCardState.Incrementing || currentRewardCardState == RewardCardState.LevelUp3 || currentRewardCardState == RewardCardState.PostLevelUpPause) && !IsMaxedOut())
		{
			int num = Mathf.RoundToInt((float)maxProgress * progressBar.percent);
			progressBar.label.SetValue(num + "/" + maxProgress);
		}
		progressBar.Draw(r, offsetX, offsetY + multiLineLayoutOffset);
		descLabel.Draw(r, offsetX, offsetY);
		descLabel2.Draw(r, offsetX, offsetY);
		if (showStars > 0)
		{
			int num2 = offsetX + 4 + progressBar.Width / 2;
			int offsetY2 = offsetY + 3 + multiLineLayoutOffset;
			if (currentRewardCardState <= RewardCardState.Incrementing)
			{
				QuestRowStarString.Draw(r, num2 + difficultyStarsX, offsetY2, showStars);
			}
			else
			{
				starTotalLabel.Draw(r, num2, offsetY2);
			}
		}
		if (item != null)
		{
			int num3 = item.GetRarityBonus();
			if (num3 == 0 && item is TreasureItem)
			{
				Data.ItemInTreasure[] itemsInTreasure = (item as TreasureItem).itemsInTreasure;
				foreach (Data.ItemInTreasure itemInTreasure in itemsInTreasure)
				{
					num3 = Mathf.Max(num3, itemInTreasure.rarityBonus);
				}
			}
			if (num3 > 0)
			{
				enchantBonusLabel.SetValue("+" + num3);
				if (num3 < 16)
				{
					enchantBonusLabel.color = ItemData.Rarity.GetColorForBonus(num3);
					enchantBonusLabel.isRainbow = false;
				}
				else
				{
					enchantBonusLabel.isRainbow = true;
				}
				enchantBonusLabel.Draw(r, offsetX, offsetY);
			}
		}
		if (currentRewardCardState == RewardCardState.LevelUp1)
		{
			SetBrightness(r, offsetX, offsetY, (float)elapsedRewardCardTics / (float)LEVEL_UP_DURATION);
		}
		else if (currentRewardCardState == RewardCardState.LevelUp2)
		{
			SetBrightness(r, offsetX, offsetY, 1f);
		}
		else if (currentRewardCardState == RewardCardState.LevelUp3)
		{
			SetBrightness(r, offsetX, offsetY, 1f - (float)elapsedRewardCardTics / (float)LEVEL_UP_DURATION);
		}
	}

	private void DrawBorder(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < Width; i++)
		{
			int x = i + offsetX;
			for (int j = 0; j < Height; j++)
			{
				int y = j + offsetY;
				char c = ' ';
				if (i == 0)
				{
					c = ((j != 0) ? ((j != Height - 1) ? '│' : '└') : '┌');
				}
				else if (i == Width - 1)
				{
					c = ((j != 0) ? ((j != Height - 1) ? '│' : '┘') : '┐');
				}
				else if (j == 0 || j == Height - 1)
				{
					c = '─';
				}
				r.SetCell(x, y, SpecialSymbols.Map(c), ColorConstants.darkGrey, ColorConstants.black);
			}
		}
	}

	private void SetBrightness(AsciiRenderProcedural r, int offsetX, int offsetY, float percent)
	{
		for (int i = 0; i < Width; i++)
		{
			int x = i + offsetX;
			for (int j = 0; j < Height; j++)
			{
				int y = j + offsetY;
				AsciiCellProcedural cell = r.GetCell(x, y);
				if (cell != null)
				{
					cell.SetForeground(Color.Lerp(cell.GetForeground(), ColorConstants.white, percent));
					cell.SetBackground(Color.Lerp(cell.GetBackground(), ColorConstants.white, percent));
				}
			}
		}
	}

	private void Start()
	{
		initialWidth = Width;
		initialHeight = Height;
	}
}
