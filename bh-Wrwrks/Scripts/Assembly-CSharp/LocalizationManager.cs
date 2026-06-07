using System;
using TMPro;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
	[Serializable]
	public class Locale
	{
		public Sprite langMenuButton;

		public Sprite newGame;

		public Sprite collection;

		public Sprite settings;

		public Sprite quit;

		public Sprite continueButton;

		public Sprite wishlist;

		public Sprite resume;

		public Sprite mainmenu;

		public Sprite nextRoundButton;

		public Sprite rerollButton;

		public Sprite rerollButtonPoor;

		public Sprite lockShop;

		public Sprite unlockShop;

		public Sprite hideShopButton;

		public Sprite showShopButton;

		public Sprite skipPerkButton;

		public Sprite shopSellPrompt;

		public Sprite shopFrame;

		public Sprite perkFrame;

		public Sprite endlessButton;

		public Sprite retryButton;

		public Sprite menuButton;

		public Sprite settingsItems;

		public Sprite[] resolutionText;

		public Sprite settingApply;

		public Sprite settingRevert;

		public Sprite newGameItems;

		public Sprite newGameStart;

		public Sprite[] newGameClasses;

		public Sprite[] newGameDifficultyDesc;

		public Sprite[] newGameDifficultyTitle;

		public Sprite collectionItems;

		public Sprite quitWarn;

		public Sprite quitDesktopWarn;

		public Sprite quitConfirm;

		public Sprite quitButton;

		public Sprite wishItems;

		public Sprite wishButton;

		public Sprite continueItems;

		public Sprite continueMenuButton;

		public Sprite continueAbandon;

		public Sprite[] errorPopups;

		public Sprite waveBox;

		public Tooltip tooltip;

		public TMP_FontAsset font;

		public float fontSize;

		public Sprite[] branchPopups;

		public Sprite showBankButton;

		public Sprite hideBankButton;

		public Sprite bankFrame;
	}

	public enum Text
	{
		Win = 0,
		Lose = 1,
		Congrats = 2,
		DemoComplete = 3,
		WaveClear = 4,
		Reward = 5,
		HPBonus = 6,
		UnlockWizard = 7,
		UnlockGoblin = 8,
		UnlockDifficulty = 9,
		DifficultyAdd = 10,
		Unlock = 11,
		NoUpgrade = 12,
		Wave = 13,
		Endless = 14,
		Saint = 15,
		Squid = 16,
		Mothership = 17,
		Loop = 18,
		Wizard = 19,
		Goblin = 20
	}

	private SaveManager.Language currLang;

	public Locale English;

	public Locale Japanese;

	public Locale currentLocale;

	public Tooltip tooltipEN;

	private Dungeon dungeon => Dungeon.Instance;

	private Mainmenu mainmenu => dungeon.mainmenu;

	private SaveManager.GameSave saveData => dungeon.saveData;

	public void SetLang(SaveManager.Language lang)
	{
		if (lang != currLang)
		{
			dungeon.saveData.language = lang;
			dungeon.saveManager.SaveGame();
			currLang = lang;
			switch (lang)
			{
			case SaveManager.Language.English:
				SetLocale(English);
				break;
			case SaveManager.Language.Japanese:
				SetLocale(Japanese);
				break;
			}
		}
	}

	public void SetLocale(Locale lang)
	{
		currentLocale = lang;
		dungeon.tooltip.Hide(force: true);
		dungeon.tooltip = lang.tooltip;
		mainmenu.langMenuButton.SetSprite(lang.langMenuButton);
		mainmenu.buttons[0].SetSprite(dungeon.paused ? lang.resume : (dungeon.saveData.savedRun ? lang.continueButton : lang.newGame));
		mainmenu.buttons[1].SetSprite(dungeon.demo ? lang.wishlist : lang.collection);
		mainmenu.buttons[2].SetSprite(lang.settings);
		mainmenu.buttons[3].SetSprite(dungeon.paused ? lang.mainmenu : lang.quit);
		mainmenu.ResolutionContainer.GetComponentsInChildren<UIButton>()[0].SetSprite(lang.settingRevert);
		mainmenu.ResolutionContainer.GetComponentsInChildren<UIButton>()[1].SetSprite(lang.settingApply);
		dungeon.nextRoundButton.SetSprite(lang.nextRoundButton);
		dungeon.toggleShopButton.SetSprite(lang.hideShopButton);
		dungeon.shop.lockButton.SetSprite(dungeon.shop.locked ? lang.unlockShop : lang.lockShop);
		dungeon.shop.restockButton.SetSprite(lang.rerollButton);
		dungeon.perks.skipButton.SetSprite(lang.skipPerkButton);
		dungeon.shop.sellScreen.GetComponentsInChildren<SpriteRenderer>()[1].sprite = lang.shopSellPrompt;
		dungeon.shop.GetComponentInChildren<SpriteRenderer>().sprite = lang.shopFrame;
		dungeon.perks.GetComponentInChildren<SpriteRenderer>().sprite = lang.perkFrame;
		dungeon.retryButton.SetSprite(lang.retryButton);
		dungeon.endlessButton.SetSprite(lang.endlessButton);
		dungeon.gameOverButton.SetSprite(lang.menuButton);
		dungeon.board.errorMove.GetComponent<SpriteRenderer>().sprite = lang.errorPopups[0];
		dungeon.board.dupeError.GetComponent<SpriteRenderer>().sprite = lang.errorPopups[1];
		dungeon.board.bankError.GetComponent<SpriteRenderer>().sprite = lang.errorPopups[3];
		dungeon.waveText.transform.parent.GetComponent<SpriteRenderer>().sprite = lang.waveBox;
		dungeon.currLevel = dungeon.currLevel;
		dungeon.bank.GetComponentInChildren<SpriteRenderer>().sprite = lang.bankFrame;
		foreach (UIButton button in dungeon.perks.buttons)
		{
			TMP_Text[] componentsInChildren = button.GetComponentsInChildren<TMP_Text>();
			foreach (TMP_Text obj in componentsInChildren)
			{
				obj.font = lang.font;
				obj.fontSize = lang.fontSize;
			}
		}
		dungeon.perks.RefreshPerkText();
		switch (mainmenu.currState)
		{
		case Mainmenu.State.Start:
		{
			StartMenu component4 = mainmenu.currMenu.GetComponent<StartMenu>();
			component4.menuItems.sprite = lang.newGameItems;
			component4.startButton.SetSprite(lang.newGameStart);
			component4.classSprite.sprite = lang.newGameClasses[saveData.currCharacter];
			component4.difficultyText.sprite = lang.newGameDifficultyDesc[saveData.currDifficulty];
			component4.difficultyNum.sprite = lang.newGameDifficultyTitle[saveData.currDifficulty];
			break;
		}
		case Mainmenu.State.Collection:
			mainmenu.currMenu.GetComponent<CollectionMenu>().items.sprite = lang.collectionItems;
			break;
		case Mainmenu.State.Settings:
		{
			SettingsMenu component5 = mainmenu.currMenu.GetComponent<SettingsMenu>();
			component5.items.sprite = lang.settingsItems;
			component5.resButton.SetSprite(lang.resolutionText[saveData.videoPrefs.resolution]);
			break;
		}
		case Mainmenu.State.Quit:
		{
			QuitMenu component3 = mainmenu.currMenu.GetComponent<QuitMenu>();
			component3.button.bg.sprite = (dungeon.paused ? lang.quitConfirm : lang.quitButton);
			component3.warning.sprite = (dungeon.paused ? lang.quitWarn : lang.quitDesktopWarn);
			break;
		}
		case Mainmenu.State.Wish:
		{
			WishlistMenu component2 = mainmenu.currMenu.GetComponent<WishlistMenu>();
			component2.items.sprite = lang.wishItems;
			component2.wishbutton.SetSprite(lang.wishButton);
			break;
		}
		case Mainmenu.State.Continue:
		{
			ContinueMenu component = mainmenu.currMenu.GetComponent<ContinueMenu>();
			component.items.sprite = lang.continueItems;
			component.contButton.SetSprite(lang.continueMenuButton);
			component.abandonButton.SetSprite(lang.continueAbandon);
			break;
		}
		default:
			Debug.LogWarning("CANT LOCALIZE MENU " + mainmenu.currState);
			break;
		case Mainmenu.State.Intro:
			break;
		}
	}

	public (string, string) GetTutorialMessage(int index)
	{
		SaveManager.Language language = saveData.language;
		if (language == SaveManager.Language.English || language != SaveManager.Language.Japanese)
		{
			return GetTutorialMessageEN(index);
		}
		return GetTutorialMessageJP(index);
	}

	private (string, string) GetTutorialMessageEN(int index)
	{
		string text = "";
		string text2 = "";
		switch (index)
		{
		case 0:
			text = "WEAPONS";
			text2 = "Your Weapons are controlled by input Modules";
			break;
		case 1:
			text = "MODULES";
			text2 = "Module outputs are controlled using [white]Sliders[/g] and [white]Dials[/g]";
			break;
		case 2:
			text = "ITEMS";
			text2 = "[white]Items[/g] are either\nWeapons or Modules";
			break;
		case 3:
			text = "COMBAT";
			text2 = "Press [white]GO[/g] to start combat when ready";
			break;
		case 4:
			text = "UPGRADES";
			text2 = "Drag two of the same item together to [g]Upgrade[/g] it";
			break;
		default:
			text = "ERROR";
			text2 = "MISSING TUTORIAL TEXT";
			break;
		}
		return (text, text2);
	}

	private (string, string) GetTutorialMessageJP(int index)
	{
		string item;
		string item2;
		switch (index)
		{
		case 0:
			item = "武器";
			item2 = "インプットモジュールで武器を支配する";
			break;
		case 1:
			item = "モジュール";
			item2 = "[white]スライダー[/g]と[white]ダイヤル[/g]でアウトプットモジュールを支配する";
			break;
		case 2:
			item = "アイテム";
			item2 = "武器とモジュールどちらともは[white]アイテム[/g]だ";
			break;
		case 3:
			item = "戦闘";
			item2 = "用意したら[white]ゴー[/g]押して戦闘を始める";
			break;
		case 4:
			item = "アップグレード";
			item2 = "同じアイテム二つを一緒に引きずれて[g]アップグレード[/g]する";
			break;
		default:
			item = "ERROR";
			item2 = "MISSING TUTORIAL TEXT";
			break;
		}
		return (item, item2);
	}

	public (string, string, string) GetButtonTip(UIButton.func func, float data = 0f, bool locked = false)
	{
		SaveManager.Language language = saveData.language;
		if (language == SaveManager.Language.English || language != SaveManager.Language.Japanese)
		{
			return GetButtonTipEN(func, data, locked);
		}
		return GetButtonTipJP(func, data, locked);
	}

	public (string, string, string) GetButtonTipEN(UIButton.func func, float data, bool locked)
	{
		string item = "";
		string item2 = "";
		string item3 = "";
		switch (func)
		{
		case UIButton.func.StartCharacterSelect:
			if (locked)
			{
				item = "LOCKED";
				item2 = (dungeon.demo ? "Not available in demo" : $"Defeat [white]Wave {10f * data}[/g] to unlock character");
			}
			else if (data == 0f)
			{
				item = "KNIGHT";
				item2 = "Starts with\nbasic [white]Sword[/g] kit";
				item3 = "[green]+25 Max HP[/g]";
			}
			else if (data == 1f)
			{
				item = "WIZARD";
				item2 = "Starts with\nbasic Wand kit";
				item3 = "+1 DMG to Wands";
			}
			else if (data == 2f)
			{
				item = "GOBLIN";
				item2 = "Starts with [g]+$5[/g]\nand in [white]Shop[/g]";
				item3 = "[g]-$1[/g] on [white]rerolls[/g]";
			}
			break;
		case UIButton.func.StartDifficulty:
			item = "LOCKED";
			item2 = "Win on [white]current difficulty[/g] to unlock next";
			break;
		case UIButton.func.ShopLock:
			item = (dungeon.shop.locked ? "UNLOCK" : "LOCK");
			item2 = (dungeon.shop.locked ? "Allow shop restock" : "Stop shop restock");
			break;
		case UIButton.func.ToggleState:
		{
			int num = dungeon.bank.modules.Length;
			int num2 = num;
			Module[] modules = dungeon.bank.modules;
			for (int i = 0; i < modules.Length; i++)
			{
				if (modules[i] == null)
				{
					num2--;
				}
			}
			item = ((dungeon.toggleStateButton.bg.sprite == dungeon.bankIcon) ? $"BANK <color=#DBDBDB>[{num2}/{num}]</color>" : "SHOW SHOP");
			break;
		}
		}
		return (item, item2, item3);
	}

	public (string, string, string) GetButtonTipJP(UIButton.func func, float data, bool locked)
	{
		string item = "";
		string item2 = "";
		string item3 = "";
		switch (func)
		{
		case UIButton.func.StartCharacterSelect:
			if (locked)
			{
				item = "ロックしている";
				item2 = (dungeon.demo ? "デモに入手不可能" : $"[white]ウェーブ{10f * data}[/g]負かしてキャラクターをアンロックできる");
			}
			else if (data == 0f)
			{
				item = "ナイト";
				item2 = "始めに基本的な\n[white]剣[/g]キットがある";
				item3 = "[green]+25 <size=6.25>マックス</size> HP[/g]";
			}
			else if (data == 1f)
			{
				item = "ウィザード";
				item2 = "始めに基本的な\nワンドキットがある";
				item3 = "<size=6.25>ワンド</size> +1 DMG";
			}
			else if (data == 2f)
			{
				item = "ゴブリン";
				item2 = "始めに +$5\nと[white]ショップ[/g]";
				item3 = "<size=6.25>[white]リロール[/g]価格</size> [g]-$1[/g]";
			}
			break;
		case UIButton.func.StartDifficulty:
			item = "ロックしている";
			item2 = "[white]今難易[/g]で勝って次のアンロックする";
			break;
		case UIButton.func.ShopLock:
			item = (dungeon.shop.locked ? "アンロック" : "ロック");
			item2 = (dungeon.shop.locked ? "ショップリストックやらす" : "ショップリストック止める");
			break;
		case UIButton.func.ToggleState:
		{
			int num = dungeon.bank.modules.Length;
			int num2 = num;
			Module[] modules = dungeon.bank.modules;
			for (int i = 0; i < modules.Length; i++)
			{
				if (modules[i] == null)
				{
					num2--;
				}
			}
			item = ((dungeon.toggleStateButton.bg.sprite == dungeon.bankIcon) ? $"バンク <color=#DBDBDB>[{num2}/{num}]</color>" : "ショップ表示");
			break;
		}
		}
		return (item, item2, item3);
	}

	public string GetText(Text t)
	{
		SaveManager.Language language = saveData.language;
		if (language == SaveManager.Language.English || language != SaveManager.Language.Japanese)
		{
			return GetTextEN(t);
		}
		return GetTextJP(t);
	}

	private string GetTextEN(Text t)
	{
		return t switch
		{
			Text.Congrats => "CONGRATULATIONS!", 
			Text.Win => "YOU WIN!", 
			Text.Lose => "YOU DIED", 
			Text.DemoComplete => "DEMO COMPLETE", 
			Text.WaveClear => "WAVE CLEARED", 
			Text.Reward => "REWARD", 
			Text.HPBonus => "HP BONUS", 
			Text.NoUpgrade => "NO UPGRADE", 
			Text.UnlockWizard => "UNLOCKED WIZARD", 
			Text.UnlockGoblin => "UNLOCKED GOBLIN", 
			Text.Wizard => "THE WIZARD", 
			Text.Goblin => "THE GOBLIN", 
			Text.Unlock => "UNLOCKED:", 
			Text.UnlockDifficulty => $"DIFFICULTY {dungeon.saveData.maxDiffUnlock + 1}", 
			Text.DifficultyAdd => $"NEW DIFFICULTY: {dungeon.saveData.maxDiffUnlock + 1}", 
			Text.Wave => "WAVE", 
			Text.Endless => "ENDLESS", 
			Text.Saint => "Goblin Saint", 
			Text.Squid => "King Squid", 
			Text.Mothership => "Mothership", 
			Text.Loop => "LOOP", 
			_ => "ERROR", 
		};
	}

	private string GetTextJP(Text t)
	{
		string text = "<size=6.25>";
		switch (t)
		{
		case Text.Congrats:
			text += "御目出度う<size=10>!</size>";
			break;
		case Text.Win:
			text += "勝った<size=10>!</size>";
			break;
		case Text.Lose:
			text += "死んだ";
			break;
		case Text.DemoComplete:
			text += "デモ終わり";
			break;
		case Text.WaveClear:
			text += "ウェーブクリア";
			break;
		case Text.Reward:
			text += "褒美";
			break;
		case Text.HPBonus:
			text += "<size=10>HP</size> ボーナス";
			break;
		case Text.NoUpgrade:
			text += "NO UPGRADE";
			break;
		case Text.UnlockWizard:
			text += "アンロックウィザード";
			break;
		case Text.UnlockGoblin:
			text += "アンロックゴブリン";
			break;
		case Text.Wizard:
			text += "ウィザード";
			break;
		case Text.Goblin:
			text += "ゴブリン";
			break;
		case Text.Unlock:
			text += "アンロック<size=10>:</size>";
			break;
		case Text.UnlockDifficulty:
			text += $"難易度 <size=10>{dungeon.saveData.maxDiffUnlock + 1}</size>";
			break;
		case Text.DifficultyAdd:
			text += $"新しい難易度: <size=10>{dungeon.saveData.maxDiffUnlock + 1}</size>";
			break;
		case Text.Wave:
			text += "ウェーブ";
			break;
		case Text.Endless:
			text += "エンドレス";
			break;
		case Text.Saint:
			text += "ゴブリン聖人";
			break;
		case Text.Squid:
			text += "イカ王";
			break;
		case Text.Mothership:
			text += "母船";
			break;
		case Text.Loop:
			text += "ループ";
			break;
		default:
			return "ERROR";
		}
		return text + "</size>";
	}
}
