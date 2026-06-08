using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CodeRedemptionScreen : PopUpModalScreen
{
	public const string CODE_RESET_CLOCKS = "clk";

	public const string CODE_GRANT_KI = "ki";

	public const string CODE_RENAME_PLAYER = "ren";

	public const string CODE_GRANT_ENCHANT = "enc";

	public const string CODE_ITEMS = "its";

	public const string CODE_SPECIFIC_ITEM = "itm";

	public const string CODE_TREASURES = "trs";

	public const string CODE_RANDOM_SHINY = "shi";

	public const string CODE_SIGNATURE = "sig";

	public const string CODE_SUBSCRIPTION = "sub";

	public const string CODE_LEVEL = "lvl";

	private const int TOKEN_LENGTH = 6;

	private const string TOKEN_PREFS_KEY = "CODE_REDEEM_TOKEN";

	private const string LABEL_COPIED = "tid_code_redemption_0";

	private const string LABEL_SUCCESS = "tid_code_redemption_1";

	private const string LABEL_INVALID = "tid_code_redemption_2";

	public DialogNineSlice bg;

	public AsciiString title;

	public DialogButton generateCodeButton;

	public AsciiString generatedCodeLabel;

	public DialogButton redeemCodeButton;

	public AsciiString redeemStatusLabel;

	private string lastSuccessfulInstruction;

	private CheatUnlockStonescript cheatUnlockStonescript;

	private static string nextItemSignature;

	private float statusMessageTime;

	public static void Export(string userCode, string instructions)
	{
	}

	private static bool Import(string userCode, string instructions)
	{
		try
		{
			string text = StringCipher.Decrypt(instructions, GameConfig.singleton.GetSalt() + userCode + Features.VERSION.ToString());
			string[] array = SlimJson.ParseArray("{arr:[" + text + "]}", "arr");
			if (array.Length != 0)
			{
				EnsureSaveFileIsLoaded();
			}
			for (int i = 0; i < array.Length; i++)
			{
				switch (array[i])
				{
				case "clk":
				{
					Utils.LogIfEditor("Resetting Clocks");
					HeroSettings.ResetClock();
					ShopController.singleton.ResetClock();
					UndeadCryptIntro.ResetClock();
					OfflineFarmController.singleton.ResetClock();
					CustomQuestsController.Singleton.ClearEpicCooldown();
					WeeklyQuestsController.singleton.ResetClock();
					BaseEventController2 activeEventController = EventController.singleton.GetActiveEventController();
					if (activeEventController != null && activeEventController.objectives != null)
					{
						activeEventController.objectives.ResetClock();
					}
					break;
				}
				case "ki":
					i++;
					if (i < array.Length)
					{
						Utils.LogIfEditor("Grant " + array[i] + " Ki");
						int num = Utils.ParseInt(array[i]);
						if (num > 0 && num <= 100000)
						{
							InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, num);
						}
					}
					break;
				case "ren":
					i++;
					if (i < array.Length)
					{
						string text2 = array[i];
						Utils.LogIfEditor("Renaming player to " + text2);
						HeroSettings.name = text2;
					}
					break;
				case "enc":
					i++;
					if (i < array.Length)
					{
						int rarityBonus = Utils.ParseInt(array[i]);
						Item item6 = ItemFactory.singleton.MakeEnchantmentWithBonus(rarityBonus);
						item6.signature = nextItemSignature;
						nextItemSignature = null;
						Inventory.Singleton.AddItem(item6);
					}
					break;
				case "its":
				{
					i++;
					if (i >= array.Length)
					{
						break;
					}
					int num2 = Utils.ParseInt(array[i]);
					if (num2 >= 2)
					{
						string[] array2 = new string[4] { "sword", "shield", "crossbow", "quarterstaff" };
						for (int j = 0; j < array2.Length; j++)
						{
							Item item = ItemFactory.singleton.MakeItemWithLevel(array2[j], 1);
							item.LoadAbilities();
							Inventory.Singleton.AddItem(item, num2);
						}
						num2 /= 2;
						ItemData.Element[] array3 = new ItemData.Element[5]
						{
							ItemData.Element.Poison,
							ItemData.Element.Vigor,
							ItemData.Element.AEther,
							ItemData.Element.Fire,
							ItemData.Element.Ice
						};
						for (int k = 0; k < array3.Length; k++)
						{
							Item item2 = ItemFactory.singleton.MakeItemWithLevelAndAbilities("wand", 1, array3[k]);
							item2.LoadAbilities();
							Inventory.Singleton.AddItem(item2, num2);
						}
					}
					break;
				}
				case "itm":
				{
					string itemId = "sword";
					ItemData.Element element = ItemData.Element.Stone;
					i++;
					if (i < array.Length && array[i].StartsWith('{'))
					{
						string itemSjson = array[i];
						Item item4 = ItemFactory.singleton.ItemFromString(itemSjson);
						if (nextItemSignature != null)
						{
							item4.signature = nextItemSignature;
							nextItemSignature = null;
						}
						if (item4 != null)
						{
							Inventory.Singleton.AddItem(item4, item4.count, updateAchievements: false);
						}
						break;
					}
					if (i < array.Length)
					{
						itemId = array[i];
					}
					i++;
					if (i < array.Length)
					{
						int num3 = Utils.ParseInt(array[i]);
						if (num3 >= 1)
						{
							Item item5 = ItemFactory.singleton.MakeItemWithLevel(itemId, 1);
							item5.element = element;
							item5.LoadAbilities();
							item5.signature = nextItemSignature;
							nextItemSignature = null;
							Inventory.Singleton.AddItem(item5, num3, updateAchievements: false);
						}
					}
					break;
				}
				case "trs":
				{
					List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
					TreasureItem item3 = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_2", possibleElements);
					Inventory.Singleton.AddItem(item3);
					item3 = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_3", possibleElements);
					Inventory.Singleton.AddItem(item3);
					item3 = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_4", possibleElements);
					Inventory.Singleton.AddItem(item3);
					break;
				}
				case "shi":
				{
					TreasureItem treasureItem = TreasureFactory.singleton.MakeShinyTreasure(0, 11);
					treasureItem.signature = nextItemSignature;
					nextItemSignature = null;
					Inventory.Singleton.AddItem(treasureItem);
					break;
				}
				case "sig":
					i++;
					if (i < array.Length)
					{
						nextItemSignature = array[i];
					}
					break;
				case "sub":
					i++;
					if (i < array.Length)
					{
						string subId = array[i];
						SubscriptionController.singleton.AddGifted(subId);
					}
					break;
				case "lvl":
					i++;
					if (i < array.Length)
					{
						int changeAmount = Utils.ParseInt(array[i]);
						Utils.LogIfEditor("Changing player level by " + changeAmount);
						XPController.singleton.ChangeLevelNumber(changeAmount);
					}
					break;
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}

	public override void Show()
	{
		base.Show();
		redeemStatusLabel.Clear();
		cheatUnlockStonescript.enabled = true;
	}

	public override void Hide()
	{
		base.Hide();
		lastSuccessfulInstruction = null;
		cheatUnlockStonescript.enabled = false;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		generateCodeButton.UpdateTic();
		redeemCodeButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		bg.Draw(r, offsetX, offsetY);
		title.Draw(r, offsetX, offsetY);
		generateCodeButton.Draw(r, offsetX, offsetY);
		generatedCodeLabel.Draw(r, offsetX, offsetY);
		redeemCodeButton.Draw(r, offsetX, offsetY);
		redeemStatusLabel.Draw(r, offsetX, offsetY);
	}

	private static void EnsureSaveFileIsLoaded()
	{
		if (GameSave.activeSaveFile == null)
		{
			SaveFiles.singleton.LoadSaveFile(GameSave.selectedSaveFile);
			GameSave.activeSaveFile = GameSave.selectedSaveFile;
		}
	}

	private void HandleGenerateCodePressed(DialogButton btn)
	{
		string userCode = GetUserCode();
		generatedCodeLabel.SetValue(userCode);
		ShowStatus(Te.xt("tid_code_redemption_0"));
		GUIUtility.systemCopyBuffer = userCode;
		CodeRedemptionServices.singleton.SetCode(userCode);
	}

	private void HandleRedeemCodePressed(DialogButton btn)
	{
		string strFromClipboard = GUIUtility.systemCopyBuffer;
		string text = strFromClipboard.ToLower();
		string userCode = GetUserCode();
		switch (text)
		{
		case "import":
			HandleCheatUnlockStonescript();
			return;
		case "nukesaves":
			ClearAllSaveData();
			return;
		case "shop":
			UnlockShops();
			return;
		case "testnotifs":
			LocalNotifications.TEST_NOTIFICATIONS = !LocalNotifications.TEST_NOTIFICATIONS;
			return;
		}
		if (strFromClipboard == lastSuccessfulInstruction)
		{
			ShowStatus(Te.xt("tid_code_redemption_1"));
			return;
		}
		if (string.IsNullOrEmpty(userCode))
		{
			ShowStatus(Te.xt("tid_code_redemption_2"));
			return;
		}
		CodeRedemptionServices.singleton.GetRedemptionToken(userCode, delegate(string redemptionToken)
		{
			if (string.IsNullOrEmpty(redemptionToken))
			{
				redemptionToken = strFromClipboard;
			}
			if (redemptionToken != userCode)
			{
				if (Import(userCode, redemptionToken))
				{
					ClearUserCode();
					ShowStatus(Te.xt("tid_code_redemption_1"));
					lastSuccessfulInstruction = redemptionToken;
				}
				else
				{
					ShowStatus(Te.xt("tid_code_redemption_2"));
				}
			}
			else
			{
				ShowStatus(Te.xt("tid_code_redemption_2"));
			}
		});
	}

	private void ShowStatus(string message)
	{
		redeemStatusLabel.SetValue(message);
		redeemStatusLabel.color = ColorConstants.white;
		statusMessageTime = 3f;
	}

	protected override void Update()
	{
		base.Update();
		if (statusMessageTime > 0f)
		{
			statusMessageTime -= Time.deltaTime;
			if (statusMessageTime <= 0f)
			{
				redeemStatusLabel.Clear();
			}
			else if (statusMessageTime < 2f)
			{
				redeemStatusLabel.color = Color.Lerp(Color.black, ColorConstants.white, statusMessageTime / 2f);
			}
		}
	}

	private void ClearUserCode()
	{
		PlayerPrefs.DeleteKey("CODE_REDEEM_TOKEN");
		generatedCodeLabel.Clear();
	}

	private string GetUserCode()
	{
		string text = "";
		if (PlayerPrefs.HasKey("CODE_REDEEM_TOKEN"))
		{
			text = PlayerPrefs.GetString("CODE_REDEEM_TOKEN");
		}
		else
		{
			text = GenerateNewUserCode();
			PlayerPrefs.SetString("CODE_REDEEM_TOKEN", text);
			PlayerPrefs.Save();
		}
		return text;
	}

	public static string GenerateNewUserCode()
	{
		string text = "";
		using RandomNumberGenerator randomNumberGenerator = new RNGCryptoServiceProvider();
		byte[] array = new byte[6];
		randomNumberGenerator.GetBytes(array);
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i] % 36;
			if (num >= 10)
			{
				num += 7;
			}
			num += 48;
			text += (char)num;
		}
		return text;
	}

	private void HandleCheatUnlockStonescript()
	{
		ShowStatus(Te.xt("Automate"));
		EnsureSaveFileIsLoaded();
		QuestController.singleton.MakeAvailable("automate");
		AchievementController.singleton.ReportImportTyped();
	}

	private void ClearAllSaveData()
	{
		ShowStatus(Te.xt("All save data cleared"));
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
		GameSave.ClearAllSaveFiles();
	}

	private void UnlockShops()
	{
		ShowStatus("Shops unlocked");
		EnsureSaveFileIsLoaded();
		if (QuestController.singleton != null)
		{
			QuestController.singleton.MakeAvailable("mushroom_shop");
			QuestController.singleton.MakeAvailable("uulaa_shop");
		}
		if (InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi) == 0L)
		{
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, 100L);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		generateCodeButton.OnPressed -= HandleGenerateCodePressed;
		redeemCodeButton.OnPressed -= HandleRedeemCodePressed;
		cheatUnlockStonescript.OnCheat -= HandleCheatUnlockStonescript;
	}

	protected override void Awake()
	{
		base.Awake();
		generateCodeButton.OnPressed += HandleGenerateCodePressed;
		redeemCodeButton.OnPressed += HandleRedeemCodePressed;
		cheatUnlockStonescript = GetComponent<CheatUnlockStonescript>();
		cheatUnlockStonescript.OnCheat += HandleCheatUnlockStonescript;
		cheatUnlockStonescript.enabled = false;
	}
}
