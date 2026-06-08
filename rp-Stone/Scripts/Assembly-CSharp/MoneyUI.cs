using System.Collections.Generic;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
	private class HandString
	{
		private Item lastItem;

		private long lastCount = -1L;

		public string value;

		public bool UpdateForItem(Item item, List<Data.Resource> resourcesToShow)
		{
			if (item == null || item.id == "stones")
			{
				lastItem = null;
				value = null;
			}
			else if (!string.IsNullOrEmpty(item.hudSymbol))
			{
				long num = ItemCount(item);
				if (lastItem != item || lastCount != num)
				{
					lastItem = item;
					lastCount = num;
					value = item.hudSymbol + " " + num;
					return true;
				}
			}
			return false;
		}

		private long ItemCount(Item item)
		{
			if (item.id == "stones")
			{
				return InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone);
			}
			return item.count;
		}
	}

	private const string STONE_THROWING_ITEM_ID = "stones";

	private AsciiString money = new AsciiString();

	private List<string> hudStringsTop = new List<string>();

	private GameStates.State lastGameState;

	private Data.Quest lastPlayedQuest;

	private Weapon lastLeftHand;

	private Weapon lastRightHand;

	private int progressFlagCount;

	private List<Data.Resource> resourcesToShow = new List<Data.Resource>();

	private Dictionary<int, long> lastResourceCounts = new Dictionary<int, long>();

	private Dictionary<int, string> resourceStrings = new Dictionary<int, string>();

	private HandString leftHandString = new HandString();

	private HandString rightHandString = new HandString();

	private static MoneyUI _singleton;

	public bool hideTopHUD { get; set; }

	public static MoneyUI singleton => _singleton;

	public void Clear()
	{
		lastPlayedQuest = null;
		resourcesToShow.Clear();
		lastResourceCounts.Clear();
		resourceStrings.Clear();
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, GameStates.State gameState)
	{
		if (!Hud.IsEnabled(Hud.Flag.RESOURCES) || ((gameState == GameStates.State.Playing || gameState == GameStates.State.PlayPaused || gameState == GameStates.State.PlayChoiceDialog || gameState == GameStates.State.SequentialPopupRewards || gameState == GameStates.State.SightstoneCharacterDialog) && (hideTopHUD || (GameStates.Singleton.level.QuestData != null && (GameStates.Singleton.level.QuestData.hideHUD || GameStates.Singleton.level.QuestData.hideTopHUD)))))
		{
			return;
		}
		int value = 32;
		for (int i = 0; i < 1; i++)
		{
			for (int j = 0; j < r.width; j++)
			{
				r.SetCell(j + offsetX, i + offsetY, value);
			}
		}
		if (IsShop())
		{
			offsetX += GameStates.Singleton.gateShopScreen.moneyHudOffsetX;
		}
		if (hudStringsTop.Count == 1)
		{
			DrawCenter(hudStringsTop[0], r, offsetX, offsetY);
			return;
		}
		if (hudStringsTop.Count == 2)
		{
			DrawLeft_4th(hudStringsTop[0], r, offsetX, offsetY);
			DrawRight_4th(hudStringsTop[1], r, offsetX, offsetY);
			return;
		}
		if (hudStringsTop.Count == 3)
		{
			DrawLeft_6th(hudStringsTop[0], r, offsetX, offsetY);
			DrawCenter(hudStringsTop[1], r, offsetX, offsetY);
			DrawRight_6th(hudStringsTop[2], r, offsetX, offsetY);
			return;
		}
		if (hudStringsTop.Count == 4)
		{
			DrawLeft(hudStringsTop[0], r, offsetX, offsetY);
			DrawLeft_4th(hudStringsTop[1], r, offsetX, offsetY);
			DrawRight_4th(hudStringsTop[2], r, offsetX, offsetY);
			DrawRight(hudStringsTop[3], r, offsetX, offsetY);
			return;
		}
		int num = 0;
		for (int k = 0; k < hudStringsTop.Count; k++)
		{
			num += hudStringsTop[k].Length;
		}
		float num2 = (float)(r.width - 2 - num) / (float)(hudStringsTop.Count - 1);
		float num3 = 0f;
		offsetX--;
		for (int l = 0; l < hudStringsTop.Count; l++)
		{
			string text = hudStringsTop[l];
			DrawLeft(text, r, offsetX, offsetY);
			int num4 = Mathf.RoundToInt(num2);
			num3 += num2 - (float)num4;
			offsetX += text.Length + num4;
			if (num3 >= 0.5f)
			{
				num3 -= 1f;
				offsetX++;
			}
			else if (num3 <= -0.5f)
			{
				num3 += 1f;
				offsetX--;
			}
		}
	}

	private void DrawLeft(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Left;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + 2, offsetY);
	}

	private void DrawRight(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Right;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width - 2, offsetY);
	}

	private void DrawCenter(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Center;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width / 2, offsetY);
	}

	private void DrawLeft_6th(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Center;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width * 2 / 7, offsetY);
	}

	private void DrawRight_6th(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Center;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width - r.width * 2 / 7, offsetY);
	}

	private void DrawLeft_5th(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Center;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width * 4 / 14, offsetY);
	}

	private void DrawRight_5th(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Center;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width - r.width * 4 / 13, offsetY);
	}

	private void DrawLeft_4th(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Center;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width * 4 / 11, offsetY);
	}

	private void DrawRight_4th(string moneyString, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		money.alignment = AsciiString.Alignment.Center;
		money.SetValue(moneyString);
		money.Draw(r, offsetX + r.width - r.width * 4 / 11, offsetY);
	}

	public void RefreshResourcesToShow()
	{
		lastGameState = GameStates.State.None;
	}

	private void Update()
	{
		bool flag = false;
		if (lastGameState != GameStates.Singleton.CurrentState || lastPlayedQuest != GameStates.Singleton.level.QuestData || lastLeftHand != GameStates.Singleton.hero.LeftHand || lastRightHand != GameStates.Singleton.hero.RightHand || progressFlagCount != ProgressFlags.GetFlagCount())
		{
			lastGameState = GameStates.Singleton.CurrentState;
			lastPlayedQuest = GameStates.Singleton.level.QuestData;
			lastLeftHand = GameStates.Singleton.hero.LeftHand;
			lastRightHand = GameStates.Singleton.hero.RightHand;
			progressFlagCount = ProgressFlags.GetFlagCount();
			flag = true;
			resourcesToShow.Clear();
			if (IsShop())
			{
				resourcesToShow.Add(Data.Resource.Xi);
			}
			else if (IsPlaying())
			{
				if (lastPlayedQuest != null)
				{
					if (ProgressFlags.GetFlag("show_stone") && lastPlayedQuest.resourceCollected == Data.Resource.Stone)
					{
						resourcesToShow.Add(Data.Resource.Stone);
					}
					if (ProgressFlags.GetFlag("show_wood") && lastPlayedQuest.resourceCollected == Data.Resource.Wood)
					{
						resourcesToShow.Add(Data.Resource.Wood);
					}
					if (ProgressFlags.GetFlag("show_tar") && lastPlayedQuest.resourceCollected == Data.Resource.Tar)
					{
						resourcesToShow.Add(Data.Resource.Tar);
					}
					if (ProgressFlags.GetFlag("show_bronze") && lastPlayedQuest.resourceCollected == Data.Resource.Bronze)
					{
						resourcesToShow.Add(Data.Resource.Bronze);
					}
					if (ProgressFlags.GetFlag("show_xi") && !lastPlayedQuest.safe)
					{
						resourcesToShow.Add(Data.Resource.Xi);
					}
					if (ProgressFlags.GetFlag("show_palm_leaves") && lastPlayedQuest.resourceCollected == Data.Resource.PalmLeaves)
					{
						resourcesToShow.Add(Data.Resource.PalmLeaves);
					}
					if (ProgressFlags.GetFlag("show_ivory") && lastPlayedQuest.resourceCollected == Data.Resource.Ivory)
					{
						resourcesToShow.Add(Data.Resource.Ivory);
					}
					if (ProgressFlags.GetFlag("show_gold") && lastPlayedQuest.resourceCollected == Data.Resource.Gold)
					{
						resourcesToShow.Add(Data.Resource.Gold);
					}
				}
				if (!resourcesToShow.Contains(Data.Resource.Stone) && ((lastLeftHand != null && lastLeftHand.id == "stones") || (lastRightHand != null && lastRightHand.id == "stones")))
				{
					resourcesToShow.Insert(0, Data.Resource.Stone);
				}
			}
			else
			{
				if (ProgressFlags.GetFlag("show_stone"))
				{
					resourcesToShow.Add(Data.Resource.Stone);
				}
				if (ProgressFlags.GetFlag("show_wood"))
				{
					resourcesToShow.Add(Data.Resource.Wood);
				}
				if (ProgressFlags.GetFlag("show_tar"))
				{
					resourcesToShow.Add(Data.Resource.Tar);
				}
				if (ProgressFlags.GetFlag("show_bronze"))
				{
					resourcesToShow.Add(Data.Resource.Bronze);
				}
				if (ProgressFlags.GetFlag("show_xi"))
				{
					resourcesToShow.Add(Data.Resource.Xi);
				}
				if (ProgressFlags.GetFlag("show_palm_leaves"))
				{
					resourcesToShow.Add(Data.Resource.PalmLeaves);
				}
				if (ProgressFlags.GetFlag("show_ivory"))
				{
					resourcesToShow.Add(Data.Resource.Ivory);
				}
				if (ProgressFlags.GetFlag("show_gold"))
				{
					resourcesToShow.Add(Data.Resource.Gold);
				}
			}
		}
		for (int i = 0; i < resourcesToShow.Count; i++)
		{
			Data.Resource resource = resourcesToShow[i];
			int key = (int)resource;
			if (!lastResourceCounts.ContainsKey(key))
			{
				lastResourceCounts.Add(key, -1L);
				resourceStrings.Add(key, "");
			}
			long resourceOfType = InventoryResources.singleton.GetResourceOfType(resource);
			if (resourceOfType != lastResourceCounts[key])
			{
				flag = true;
				lastResourceCounts[key] = IterateVisibleCount(resourceOfType, lastResourceCounts[key]);
				resourceStrings[key] = BuildResourceString(lastResourceCounts[key], resource);
			}
		}
		if (IsPlaying())
		{
			flag |= leftHandString.UpdateForItem(GameStates.Singleton.hero.LeftHand, resourcesToShow);
			flag |= rightHandString.UpdateForItem(GameStates.Singleton.hero.RightHand, resourcesToShow);
		}
		if (!flag)
		{
			return;
		}
		hudStringsTop.Clear();
		if (IsPlaying())
		{
			if (leftHandString.value != null)
			{
				hudStringsTop.Add(leftHandString.value);
			}
			if (rightHandString.value != null)
			{
				hudStringsTop.Add(rightHandString.value);
			}
		}
		for (int j = 0; j < resourcesToShow.Count; j++)
		{
			int key2 = (int)resourcesToShow[j];
			hudStringsTop.Add(resourceStrings[key2]);
		}
	}

	public static long IterateVisibleCount(long targetValue, long displayedValue)
	{
		long num = targetValue - displayedValue;
		displayedValue = ((num > 0 && num <= 10) ? (displayedValue + 1) : ((num >= 0 || num < -10) ? (displayedValue + num / 10) : (displayedValue - 1)));
		return displayedValue;
	}

	public static string BuildResourceString(long count, Data.Resource resourceType)
	{
		string text = "?";
		switch (resourceType)
		{
		case Data.Resource.Stone:
			text = "o ";
			break;
		case Data.Resource.Wood:
			text = "_/`";
			break;
		case Data.Resource.Tar:
			text = "≈ ";
			break;
		case Data.Resource.Xi:
			text = '@'.ToString();
			break;
		case Data.Resource.Bronze:
			text = ":.";
			break;
		case Data.Resource.PalmLeaves:
			text = "//";
			break;
		case Data.Resource.Ivory:
			text = "(\\";
			break;
		case Data.Resource.Gold:
			text = "°";
			break;
		}
		string text2 = Utils.FormatNumber(count);
		return text + text2;
	}

	public static string GetResourceName(Data.Resource type, bool plural)
	{
		return type switch
		{
			Data.Resource.Stone => Te.xt(plural ? "tid_resource_stone_plural" : "tid_resource_stone_singular"), 
			Data.Resource.Wood => Te.xt(plural ? "tid_resource_wood_plural" : "tid_resource_wood_singular"), 
			Data.Resource.Tar => Te.xt(plural ? "tid_resource_tar_plural" : "tid_resource_tar_singular"), 
			Data.Resource.Bronze => Te.xt(plural ? "tid_resource_bronze_plural" : "tid_resource_bronze_singular"), 
			_ => Te.xt(type.ToString()), 
		};
	}

	public static string GetResourceCostFormatted(Data.Resource resourceType, int costAmount)
	{
		switch (resourceType)
		{
		case Data.Resource.Stone:
			return costAmount switch
			{
				5 => Te.xt("tid_pickup_5_stones"), 
				1 => Te.xt("1 Stone"), 
				_ => string.Format(Te.xt("{0} Stones"), Utils.FormatNumber(costAmount)), 
			};
		case Data.Resource.Wood:
			if (costAmount != 1)
			{
				return string.Format(Te.xt("{0} Wood"), Utils.FormatNumber(costAmount));
			}
			return Te.xt("1 Wood");
		case Data.Resource.Tar:
			if (costAmount != 1)
			{
				return string.Format(Te.xt("{0} Tar"), Utils.FormatNumber(costAmount));
			}
			return Te.xt("1 Tar");
		case Data.Resource.Bronze:
			if (costAmount != 1)
			{
				return string.Format(Te.xt("{0} Bronze"), Utils.FormatNumber(costAmount));
			}
			return Te.xt("1 Bronze");
		case Data.Resource.Xi:
			return "@ " + Utils.FormatNumber(costAmount);
		default:
			return "?" + Utils.FormatNumber(costAmount);
		}
	}

	private string BuildConsumableItemString(long count, Item item)
	{
		return item.hudSymbol + Utils.FormatNumber(count);
	}

	private bool IsPlaying()
	{
		if (GameStates.Singleton.IsPlaying())
		{
			return GameStates.Singleton.CurrentState != GameStates.State.PlayItemScreen;
		}
		return false;
	}

	private bool IsShop()
	{
		GameStates gameStates = GameStates.Singleton;
		if (gameStates.CurrentState != GameStates.State.GateShopScreen)
		{
			if (gameStates.previousState == GameStates.State.GateShopScreen)
			{
				return gameStates.CurrentState == GameStates.State.SequentialPopupRewards;
			}
			return false;
		}
		return true;
	}

	private void Awake()
	{
		_singleton = this;
	}
}
