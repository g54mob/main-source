using System;
using System.Collections.Generic;
using UnityEngine;

public class QuickCheats : MonoBehaviour
{
	private enum State
	{
		Default = 0,
		Treasures = 1,
		SaveData = 2,
		CodeRedemption = 3,
		ProgressFlags = 4,
		CrashReports = 5,
		Leaderboards = 6,
		Misc = 7
	}

	public string unlockQuest;

	private static bool UNLOCK_QUEST_BUTTON = true;

	public TextAsset specialSaveFile;

	public TextAsset specialSaveFile2;

	private static bool treasureButtonsExpanded;

	private string addItemId = "sword";

	private ItemData.Element addItemElement;

	private string addItemLevel = "1";

	private string addItemQuantity = "1";

	private ItemData.Rarity.Type addItemRarity;

	private static bool ADD_ITEM_BUTTON = true;

	private State currentState;

	private static bool closeCheatScreen;

	private static int lastTouchCount;

	private float _x;

	private float _y;

	private float _w = 150f;

	private float _h = 20f;

	private int confirmDeleteIndex = -1;

	private string clearCrashDatabaseVersion = "enter version";

	private string leaderboardId = "";

	private string leaderboardType = "event";

	private string leaderboardEndDate = "yyyy-mm-dd";

	public static bool ToggleCheatScreen()
	{
		lastTouchCount = Input.touchCount;
		return false;
	}

	public static void UpdateCheats()
	{
		UpdateMoneyCheats();
		UpdateRestartProgressCheat();
		UpdateXPCheat();
		UpdateTrailerCheats();
	}

	private void OnEnable()
	{
		closeCheatScreen = false;
	}

	private void OnDisable()
	{
	}

	private void SetState(State newState)
	{
		currentState = newState;
	}

	private void OnGUI()
	{
	}

	private void ToggleButton(State state, string label, Action guiFunction)
	{
		if (currentState == state)
		{
			if (GUILayout.Button(label + " [-]"))
			{
				SetState(State.Default);
			}
			else
			{
				guiFunction();
			}
		}
		else if (GUILayout.Button(label + " [+]"))
		{
			SetState(state);
		}
	}

	private bool AddButton(string label, float heightBonus = 0f)
	{
		bool result = GUI.Button(new Rect(_x, _y, _w, _h + heightBonus), label);
		_y += _h + heightBonus + 5f;
		return result;
	}

	private void AddLabel(string label)
	{
		GUI.Label(new Rect(_x, _y, _w, _h), label);
		_y += _h + 5f;
	}

	private void AddSpace(float amount)
	{
		_y += amount;
	}

	private string AddTextField(string value)
	{
		value = GUI.TextField(new Rect(_x, _y, _w, _h), value);
		_y += _h + 5f;
		return value;
	}

	private void GUITreasures()
	{
	}

	private void GUISaveFiles()
	{
	}

	private void GUICodeRedemption()
	{
	}

	private void GUIProgressFlags()
	{
	}

	private void GUICrashReports()
	{
	}

	private void GUILeaderboards()
	{
	}

	private void GUIMiscellaneous()
	{
	}

	private void LoadSaveFile(SaveFiles.SaveFileMeta file)
	{
		SaveFiles.singleton.LoadSaveFile(file.saveId);
		GameSave.selectedSaveFile = file;
		GameSave.activeSaveFile = file;
		GameStates.Singleton.UpdateNavBarForProgressFlags();
	}

	private void AddTreasure(string treasureId)
	{
		List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		TreasureItem item = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", treasureId, possibleElements);
		Inventory.Singleton.AddItem(item);
	}

	public static bool SkipAheadKeyPressed()
	{
		return false;
	}

	private static void UpdateXPCheat()
	{
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.X))
		{
			GameStates.Singleton.level.XpEarned += 1000;
		}
	}

	private static void UpdateRestartProgressCheat()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			Input.GetKeyDown(KeyCode.R);
		}
	}

	private static void UpdateMoneyCheats()
	{
	}

	private static void IncreaseResource(Data.Resource type)
	{
	}

	private static void ReduceResource(Data.Resource type)
	{
	}

	private static void UpdateTrailerCheats()
	{
	}

	private void AddKillerLoadout()
	{
		int level = ItemFactory.CalculateItemLevelFromDisplayLevel(11f);
		int rngSeed = 0;
		ItemData.Rarity rarity = new ItemData.Rarity(ItemData.Rarity.Type.Transcendent);
		rarity.Roll(rngSeed);
		rarity.levelBonus = 21;
		Item item = ItemFactory.singleton.MakeItemWithLevelAndAbilities("socketed_long_sword", level, ItemData.Element.Vigor, rngSeed, rarity);
		item.hasInteracted = true;
		Inventory.Singleton.AddItem(item);
		GameStates.Singleton.hero.LeftHand = item as Weapon;
		rngSeed = 10;
		rarity = new ItemData.Rarity(ItemData.Rarity.Type.Transcendent);
		rarity.Roll(rngSeed);
		rarity.levelBonus = 21;
		item = ItemFactory.singleton.MakeItemWithLevelAndAbilities("socketed_shield", level, ItemData.Element.Fire, rngSeed, rarity);
		item.hasInteracted = true;
		Inventory.Singleton.AddItem(item);
		GameStates.Singleton.hero.RightHand = item as Weapon;
	}
}
