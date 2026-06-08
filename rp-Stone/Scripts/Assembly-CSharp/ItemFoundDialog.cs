using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemFoundDialog : ScrollBG
{
	public enum DialogMode
	{
		Normal = 0,
		CustomQuest = 1
	}

	public int itemPosX = 1;

	public int itemPosY = 1;

	public AsciiString title;

	public AsciiString amountLabel;

	public AsciiString anyKeyLabel;

	public AsciiString levelLabel;

	private bool levelShowing;

	private bool amountShowing;

	private bool isMaxLevel;

	private bool lostItemCombineStarAndCount = true;

	public int overCount1LevelOffsetX = -1;

	private Color initialLevelLabelColor;

	public int abbreviationsX;

	public int abbreviationsY;

	public int closeTicDelay = 20;

	public int anyKeyTicDelay = 20;

	public int anyKeyBlinkPeriod = 6;

	public int showRewardDelay = 10;

	private AsciiSprite icon;

	private Item _item;

	private int _count;

	private bool _wasAutoUpgraded;

	private Color initialTitleColor;

	private int initialLevelLabelY;

	public DialogMode mode;

	private List<int> abbreviationSymbols;

	private List<Color> abbreviationColors;

	public event Action OnDone;

	public void Setup(Item item, int count, bool wasAutoUpgraded = false)
	{
		_item = item;
		_count = count;
		_wasAutoUpgraded = wasAutoUpgraded;
		UpdateTitleLabel();
		UpdateAmountLabel();
		UpdateLevelString();
		UpdateAbilityAbbreviations();
		AdjustLayout();
	}

	private void UpdateTitleLabel()
	{
		if (_item == null)
		{
			icon = null;
			title.Clear();
			return;
		}
		_item.GetRarityType();
		icon = _item.GetIcon();
		if (icon == null)
		{
			Utils.LogError("couldn't load icon for item " + _item.id);
		}
		if (_wasAutoUpgraded)
		{
			title.SetValue(Te.xt("tid_w2e_upgraded") + _item.GetName());
			title.color = initialTitleColor * ColorConstants.yellow;
		}
		else
		{
			title.SetValue(_item.GetName());
			title.color = initialTitleColor * _item.GetLabelColor();
		}
	}

	private void UpdateAmountLabel()
	{
		if (_count <= 1)
		{
			amountLabel.Clear();
			amountShowing = false;
		}
		else
		{
			amountLabel.SetValue("x" + _count);
			amountShowing = true;
		}
	}

	private void UpdateLevelString()
	{
		levelShowing = true;
		Item item = _item;
		if (item == null || ItemFactory.GetLevelDisplayValueForItem(item) <= 1f)
		{
			levelLabel.Clear();
			levelShowing = false;
			return;
		}
		isMaxLevel = ItemFactory.GetLevelDisplayIntegerForItem(item) == ItemFactory.MAX_DISPLAY_LEVEL;
		levelLabel.PositionY = initialLevelLabelY;
		if (lostItemCombineStarAndCount && item.isLost)
		{
			string value;
			if (isMaxLevel)
			{
				value = ItemFactory.GetStarRatingStringForItem(item);
			}
			else if (item.lostCount == 1)
			{
				value = Te.xt("tid_anvil_11");
				levelLabel.PositionY++;
			}
			else
			{
				int lostCount = item.lostCount;
				int nextLostCountGoal = item.GetNextLostCountGoal();
				value = lostCount + "/" + nextLostCountGoal;
				value = ((nextLostCountGoal >= 10) ? ("[" + value + "]") : ("[ " + value + " ]"));
			}
			levelLabel.SetValue(value);
		}
		else if (item.showLevelInTitle)
		{
			string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
			levelLabel.SetValue(starRatingStringForItem);
		}
		else
		{
			levelLabel.Clear();
			levelShowing = false;
		}
		if (ItemFactory.GetLevelDisplayIntegerForItem(item) == ItemFactory.MAX_DISPLAY_LEVEL)
		{
			levelLabel.color = item.GetLabelColor();
		}
		else
		{
			levelLabel.color = initialLevelLabelColor * item.GetLabelColor();
		}
	}

	private void AdjustLayout()
	{
		if (levelShowing && !amountShowing)
		{
			levelLabel.alignment = AsciiString.Alignment.Center;
			levelLabel.PositionX = 0;
			return;
		}
		if (amountShowing && !levelShowing)
		{
			amountLabel.alignment = AsciiString.Alignment.Center;
			amountLabel.PositionX = 0;
			return;
		}
		levelLabel.alignment = AsciiString.Alignment.Right;
		levelLabel.PositionX = 0;
		amountLabel.alignment = AsciiString.Alignment.Left;
		amountLabel.PositionX = 2;
	}

	private void UpdateAbilityAbbreviations()
	{
		Item item = _item;
		if (abbreviationSymbols != null)
		{
			abbreviationSymbols.Clear();
			abbreviationColors.Clear();
		}
		if (!(item != null) || item.abilities == null || !item.procGenAbilities)
		{
			return;
		}
		for (int i = 0; i < item.abilities.Count; i++)
		{
			ItemData.Ability ability = item.abilities[i];
			if (ability.abbreviation == null || ability.abbreviation.Length <= 0)
			{
				continue;
			}
			Color color = ColorConstants.lightGrey;
			if (ability.applyRarity)
			{
				ItemData.Rarity.Type rarityType = item.GetRarityType();
				if (rarityType == ItemData.Rarity.Type.Transcendent)
				{
					color = ColorConstants.black;
				}
				else
				{
					color *= ItemData.Rarity.GetColorForRarity(rarityType);
				}
			}
			AddAbbreviation(ability.abbreviation[0], color);
		}
	}

	private void AddAbbreviation(int symbol, Color color)
	{
		if (abbreviationSymbols == null)
		{
			abbreviationSymbols = new List<int>();
			abbreviationColors = new List<Color>();
		}
		abbreviationSymbols.Add(symbol);
		abbreviationColors.Add(color);
	}

	public void Show()
	{
		SetState(State.In);
	}

	public void Hide()
	{
		if (_item != null && _item.id == "star_stone")
		{
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.StarStone, GameStates.State.StarstoneQuestTransition);
		}
		else if (_item != null && _item.id == "xi_stone")
		{
			ProgressFlags.SetFlag("show_xi");
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, 5L);
			QuestController.singleton.MakeAvailable("upgrade_workstation_3");
			GameStates.Singleton.CompleteQuest(stopAudio: false);
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.XiStone, GameStates.State.SoulstoneQuestTransition);
		}
		else if (_item != null && _item.id == "xp_stone")
		{
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.XpStone, GameStates.State.SoulstonePlayTransition);
			GameStates.Singleton.ScheduleXpDialog();
			GameStates.Singleton.level.XpEarned = XPController.singleton.nextXpThreshold;
		}
		else if (_item != null && _item.id == "ouroboros_stone")
		{
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.OuroborosStone, GameStates.State.OuroborosPlayTransition);
		}
		else if (_item != null && _item.id == "quest_stone")
		{
			GameStates.Singleton.CompleteQuest(stopAudio: false);
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.QuestStone, GameStates.State.QuestStoneFTUETransition);
		}
		else if (_item != null && _item.id == "fissure_stone")
		{
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.FissureStone, GameStates.State.SoulstonePlayTransition);
		}
		else if (_item != null && _item.id == "triskelion_stone")
		{
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.TriskelionStone, GameStates.State.SoulstonePlayTransition);
		}
		else if (_item != null && _item.id == "mind_stone")
		{
			GameStates.Singleton.CompleteQuest(stopAudio: false);
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.MindStone, GameStates.State.SoulstoneQuestTransition);
		}
		else if (_item != null && _item.id == "moon_stone")
		{
			GameStates.Singleton.CompleteQuest(stopAudio: false);
			GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.MoonStone, GameStates.State.EpilogueCredits);
		}
		else
		{
			SfxController.singleton.Play("treasure_close");
		}
		SetState(State.Out);
	}

	public void FireDone()
	{
		this.OnDone?.Invoke();
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && base.ElapsedStateTics >= CloseTicDelay() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
		{
			Hide();
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Idle && base.ElapsedStateTics >= CloseTicDelay())
		{
			if (AsciiMouse.singleton.up0)
			{
				Hide();
			}
			else if (mode == DialogMode.Normal && base.ElapsedStateTics >= 20 && GameStates.Singleton.previousState == GameStates.State.Playing && _item is TreasureItem && OuroborosWeapon.IsEnabled())
			{
				Hide();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (scaleX >= 0.1f)
		{
			int num = (int)((float)Width * scaleX);
			int num2 = offsetX + PositionX + (Width - num) / 2;
			r.PushClip(new AsciiRenderProcedural.Clip
			{
				left = num2,
				right = num2
			});
			if (icon != null)
			{
				icon.Draw(r, offsetX + itemPosX, offsetY + itemPosY);
			}
			title.Draw(r, offsetX, offsetY);
			if (amountShowing)
			{
				amountLabel.Draw(r, offsetX, offsetY);
			}
			if (levelShowing)
			{
				levelLabel.Draw(r, offsetX, offsetY);
			}
			if (abbreviationSymbols != null && abbreviationSymbols.Count > 0)
			{
				int num3 = offsetX + abbreviationsX;
				int y = offsetY + abbreviationsY;
				for (int i = 0; i < abbreviationSymbols.Count; i++)
				{
					Color color = abbreviationColors[i];
					if (color == ColorConstants.black)
					{
						color = AsciiString.GetRainbowColor(i, 2);
					}
					r.SetCell(num3, y, abbreviationSymbols[i], color);
					num3++;
				}
			}
			r.PopClip();
		}
		if (base.CurrentState == State.Idle && base.ElapsedStateTics >= AnyKeyTicDelay() && (base.ElapsedStateTics - AnyKeyTicDelay()) % anyKeyBlinkPeriod < anyKeyBlinkPeriod / 2)
		{
			anyKeyLabel.Draw(r, offsetX, offsetY);
		}
	}

	private int CloseTicDelay()
	{
		return closeTicDelay;
	}

	private int ShowRewardDelay()
	{
		return showRewardDelay;
	}

	private int AnyKeyTicDelay()
	{
		return anyKeyTicDelay;
	}

	protected override void Start()
	{
		base.Start();
		initialTitleColor = title.color;
		initialLevelLabelColor = levelLabel.color;
		initialLevelLabelY = levelLabel.PositionY;
		SetState(State.Disabled);
	}
}
