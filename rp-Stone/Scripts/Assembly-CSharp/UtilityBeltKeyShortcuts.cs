using System.Collections.Generic;
using UnityEngine;

public class UtilityBeltKeyShortcuts : MonoBehaviour
{
	public class Loadout
	{
		public int index;

		public string leftHand;

		public string rightHand;

		public string faerie;

		public string leftItemName;

		public string rightItemName;

		public string faerieItemName;

		public bool leftItemInvalid;

		public bool rightItemInvalid;

		public bool faerieItemInvalid;

		public bool hasAnyInvalid;

		public static Loadout FromString(string sjson)
		{
			return new Loadout
			{
				index = SlimJson.ParseInt(sjson, "index"),
				leftHand = SlimJson.Parse(sjson, "leftHand"),
				rightHand = SlimJson.Parse(sjson, "rightHand"),
				faerie = SlimJson.Parse(sjson, "faerie"),
				leftItemName = SlimJson.Parse(sjson, "leftItemName"),
				rightItemName = SlimJson.Parse(sjson, "rightItemName"),
				faerieItemName = SlimJson.Parse(sjson, "faerieItemName")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("index", index);
			if (!string.IsNullOrEmpty(leftHand))
			{
				SlimJson.AddProperty("leftHand", leftHand);
			}
			if (!string.IsNullOrEmpty(rightHand))
			{
				SlimJson.AddProperty("rightHand", rightHand);
			}
			if (!string.IsNullOrEmpty(faerie))
			{
				SlimJson.AddProperty("faerie", faerie);
			}
			if (!string.IsNullOrEmpty(leftItemName))
			{
				SlimJson.AddProperty("leftItemName", leftItemName);
			}
			if (!string.IsNullOrEmpty(rightItemName))
			{
				SlimJson.AddProperty("rightItemName", rightItemName);
			}
			if (!string.IsNullOrEmpty(faerieItemName))
			{
				SlimJson.AddProperty("faerieItemName", faerieItemName);
			}
			return SlimJson.EndSerialization();
		}
	}

	private static string LOADOUT_SAVED_MESSAGE = " Loadout saved. Press {0} to recall equipment. ";

	private static string LOADOUT_RECALLED_MESSAGE_1 = " Equipped: {0} ";

	private static string LOADOUT_RECALLED_MESSAGE_2 = " Equipped: {0} and {1} ";

	private static string LOADOUT_RECALLED_MESSAGE_3 = " Equipped: {0}, {1} and {2} ";

	private static string LOADOUT_NOT_FOUND_MESSAGE = " No loadout at number {0}. Press Control + Number to save equipment. ";

	private static string LOADOUT_INVALID_1 = " {0} is no longer in your inventory. ";

	private static string LOADOUT_INVALID_2 = " {0} and {1} are no longer in your inventory. ";

	private static string LOADOUT_INVALID_3 = " {0}, {1} and {2} are no longer in your inventory. ";

	private List<Loadout> loadouts = new List<Loadout>();

	private Dictionary<int, Loadout> loadoutsDict = new Dictionary<int, Loadout>();

	public bool inputEnabled = true;

	public bool printEnabled = true;

	public int selectedIndex { get; private set; }

	public List<Loadout> Loadouts => loadouts;

	public static UtilityBeltKeyShortcuts singleton { get; private set; }

	private void Update()
	{
		if (!Application.isFocused || !ProgressFlags.GetFlag("utility_belt"))
		{
			return;
		}
		GameStates gameStates = GameStates.Singleton;
		GameStates.State currentState = gameStates.CurrentState;
		if (!inputEnabled || !gameStates.hero.canChangeEquipment || currentState < GameStates.State.QuestScreen)
		{
			return;
		}
		switch (currentState)
		{
		case GameStates.State.ItemScreen:
			if (gameStates.itemScreen.currentState == ItemScreen.State.NameTagInput)
			{
				break;
			}
			goto default;
		default:
			if (!MindStoneScreen.IsEditing())
			{
				Evaluate(1, KeyCode.Alpha1, KeyCode.Keypad1);
				Evaluate(2, KeyCode.Alpha2, KeyCode.Keypad2);
				Evaluate(3, KeyCode.Alpha3, KeyCode.Keypad3);
				Evaluate(4, KeyCode.Alpha4, KeyCode.Keypad4);
				Evaluate(5, KeyCode.Alpha5, KeyCode.Keypad5);
				Evaluate(6, KeyCode.Alpha6, KeyCode.Keypad6);
				Evaluate(7, KeyCode.Alpha7, KeyCode.Keypad7);
				Evaluate(8, KeyCode.Alpha8, KeyCode.Keypad8);
				Evaluate(9, KeyCode.Alpha9, KeyCode.Keypad9);
				Evaluate(0, KeyCode.Alpha0, KeyCode.Keypad0);
			}
			break;
		case GameStates.State.MoonstoneRestartTransition:
		case GameStates.State.PlayAbilityActivated:
		case GameStates.State.PlaySettingsScreen:
			break;
		}
	}

	private void Evaluate(int bindingIndex, KeyCode alphaCode, KeyCode keypadCode)
	{
		if (Input.GetKeyDown(alphaCode) || Input.GetKeyDown(keypadCode))
		{
			if (IsControlPressed())
			{
				SaveLoadout(bindingIndex);
				return;
			}
			RecallLoadout(bindingIndex);
			AchievementController.singleton.ReportEquipmentChanged();
		}
	}

	private Loadout SaveLoadout(int bindingIndex, bool showMessage = true)
	{
		Loadout loadout;
		if (loadoutsDict.ContainsKey(bindingIndex))
		{
			loadout = loadoutsDict[bindingIndex];
		}
		else
		{
			loadout = new Loadout();
			loadout.index = bindingIndex;
			loadoutsDict[bindingIndex] = loadout;
			loadouts.Add(loadout);
		}
		Hero hero = GameStates.Singleton.hero;
		if (hero.LeftHand != null)
		{
			loadout.leftHand = hero.LeftHand.GetGroupId();
			loadout.leftItemName = MakeItemName(hero.LeftHand);
		}
		else
		{
			loadout.leftHand = null;
			loadout.leftItemName = null;
		}
		if (hero.RightHand != null)
		{
			loadout.rightHand = hero.RightHand.GetGroupId();
			loadout.rightItemName = MakeItemName(hero.RightHand);
		}
		else
		{
			loadout.rightHand = null;
			loadout.rightItemName = null;
		}
		_CheckForInvalidItems(loadout);
		if (showMessage)
		{
			GameplayActionMessages.SetMessage(string.Format(Te.xt(LOADOUT_SAVED_MESSAGE), bindingIndex));
		}
		return loadout;
	}

	private string MakeItemName(Item item)
	{
		string text = item.GetName();
		if (item.level >= 1 && item.showLevelInTitle)
		{
			string starRatingStringForItem = ItemFactory.GetStarRatingStringForItem(item);
			text = text + " " + starRatingStringForItem;
		}
		return text;
	}

	public void UpdatedSelectedLoadoutFromCurrentEquipment()
	{
		if (selectedIndex >= 0)
		{
			SaveLoadout(selectedIndex, showMessage: false);
		}
	}

	public void CheckForInvalidItems()
	{
		for (int i = 0; i < loadouts.Count; i++)
		{
			_CheckForInvalidItems(loadouts[i]);
		}
	}

	private void _CheckForInvalidItems(Loadout loadout)
	{
		loadout.leftItemInvalid = false;
		loadout.rightItemInvalid = false;
		loadout.faerieItemInvalid = false;
		loadout.hasAnyInvalid = false;
		if (!string.IsNullOrEmpty(loadout.leftHand) && !Inventory.Singleton.HasItemByGroupId(loadout.leftHand))
		{
			loadout.leftItemInvalid = true;
			loadout.hasAnyInvalid = true;
		}
		if (!string.IsNullOrEmpty(loadout.rightHand) && !Inventory.Singleton.HasItemByGroupId(loadout.rightHand))
		{
			loadout.rightItemInvalid = true;
			loadout.hasAnyInvalid = true;
		}
		if (!string.IsNullOrEmpty(loadout.faerie) && !Inventory.Singleton.HasItemByGroupId(loadout.faerie))
		{
			loadout.faerieItemInvalid = true;
			loadout.hasAnyInvalid = true;
		}
	}

	public Loadout GetLoadout(int bindingIndex)
	{
		if (loadoutsDict.ContainsKey(bindingIndex))
		{
			return loadoutsDict[bindingIndex];
		}
		return null;
	}

	public void RecallLoadout(int bindingIndex)
	{
		GameStates gameStates = GameStates.Singleton;
		if (!loadoutsDict.ContainsKey(bindingIndex))
		{
			PrintGameplayActionMessage(LOADOUT_NOT_FOUND_MESSAGE, bindingIndex);
			return;
		}
		selectedIndex = bindingIndex;
		Loadout loadout = loadoutsDict[bindingIndex];
		_CheckForInvalidItems(loadout);
		Hero hero = gameStates.hero;
		Weapon weapon = null;
		Weapon weapon2 = null;
		List<string> list = new List<string>();
		if (loadout.leftItemInvalid)
		{
			list.Add(loadout.leftItemName);
		}
		else if (!string.IsNullOrEmpty(loadout.leftHand))
		{
			weapon = Inventory.Singleton.GetWeapon(loadout.leftHand);
		}
		if (loadout.rightItemInvalid)
		{
			list.Add(loadout.rightItemName);
		}
		else if (!string.IsNullOrEmpty(loadout.rightHand))
		{
			weapon2 = Inventory.Singleton.GetWeapon(loadout.rightHand);
		}
		if (loadout.faerieItemInvalid)
		{
			list.Add(loadout.faerieItemName);
		}
		else if (!string.IsNullOrEmpty(loadout.faerie))
		{
			Inventory.Singleton.GetWeapon(loadout.faerie);
		}
		if (list.Count >= 3)
		{
			PrintGameplayActionMessage(LOADOUT_INVALID_3, list[0], list[1], list[2]);
		}
		else if (list.Count == 2)
		{
			PrintGameplayActionMessage(LOADOUT_INVALID_2, list[0], list[1]);
		}
		else if (list.Count == 1)
		{
			PrintGameplayActionMessage(LOADOUT_INVALID_1, list[0]);
		}
		list.Clear();
		if (weapon == null && hero.LeftHand != null)
		{
			hero.Unequip(hero.LeftHand);
		}
		if (weapon2 == null && hero.RightHand != null)
		{
			hero.Unequip(hero.RightHand);
		}
		if (weapon != null)
		{
			if (weapon != hero.LeftHand)
			{
				if (hero.LeftHand != null)
				{
					hero.Unequip(hero.LeftHand);
				}
				hero.EquipLeft(weapon);
			}
			if (!loadout.hasAnyInvalid)
			{
				list.Add(loadout.leftItemName);
			}
		}
		if (weapon2 != null)
		{
			if (weapon2 != hero.RightHand)
			{
				if (hero.RightHand != null)
				{
					hero.Unequip(hero.RightHand);
				}
				hero.EquipRight(weapon2);
			}
			if (!loadout.hasAnyInvalid)
			{
				list.Add(loadout.rightItemName);
			}
		}
		if (gameStates.CurrentState == GameStates.State.ItemScreen || gameStates.CurrentState == GameStates.State.PlayItemScreen)
		{
			gameStates.itemScreen.UpdateContents();
		}
		if (list.Count == 1)
		{
			PrintGameplayActionMessage(LOADOUT_RECALLED_MESSAGE_1, list[0]);
		}
		else if (list.Count == 2)
		{
			PrintGameplayActionMessage(LOADOUT_RECALLED_MESSAGE_2, list[0], list[1]);
		}
		else if (list.Count >= 3)
		{
			PrintGameplayActionMessage(LOADOUT_RECALLED_MESSAGE_3, list[0], list[1], list[2]);
		}
		gameStates.abilityActivationHUD.UpdateContents();
	}

	private void PrintGameplayActionMessage(string message, string param0, string param1 = "", string param2 = "")
	{
		if (printEnabled)
		{
			GameplayActionMessages.SetMessage(string.Format(Te.xt(message), param0, param1, param2));
		}
	}

	private void PrintGameplayActionMessage(string message, int param)
	{
		if (printEnabled)
		{
			GameplayActionMessages.SetMessage(string.Format(Te.xt(message), param));
		}
	}

	public void ReportCraft(ItemFactory.Result craftResult)
	{
		Weapon resultingItem = (Weapon)craftResult.resultingItem;
		ReportCraft((Weapon)craftResult.itemA, resultingItem);
		ReportCraft((Weapon)craftResult.itemB, resultingItem);
	}

	public void ReportCraft(ItemFactory.FuseResult craftResult)
	{
		ReportCraft((Weapon)craftResult.primaryItem, (Weapon)craftResult.resultPrimaryItem);
		ReportCraft((Weapon)craftResult.boostItemA, (Weapon)craftResult.resultBoostItemA);
		ReportCraft((Weapon)craftResult.boostItemB, (Weapon)craftResult.resultBoostItemB);
		ReportCraft((Weapon)craftResult.boostItemC, (Weapon)craftResult.resultBoostItemC);
	}

	public void ReportCraft(Weapon ingredientItem, Weapon resultingItem)
	{
		if (ingredientItem != null && resultingItem != null)
		{
			ReportCraft(ingredientItem.id, ingredientItem.GetGroupId(), ingredientItem.handType, resultingItem);
		}
	}

	public void ReportCraft(string ingredientItemId, string ingredientItemGroupId, Weapon.HandType ingredientItemHandType, Weapon resultingItem)
	{
		for (int i = 0; i < loadouts.Count; i++)
		{
			Loadout loadout = loadouts[i];
			if (ingredientItemId == resultingItem.id || (!Inventory.Singleton.HasItemByGroupId(ingredientItemGroupId) && ingredientItemHandType == resultingItem.handType))
			{
				if (loadout.leftHand == ingredientItemGroupId)
				{
					loadout.leftHand = resultingItem.GetGroupId();
					loadout.leftItemName = MakeItemName(resultingItem);
				}
				else if (loadout.rightHand == ingredientItemGroupId)
				{
					loadout.rightHand = resultingItem.GetGroupId();
					loadout.rightItemName = MakeItemName(resultingItem);
				}
				else if (loadout.faerie == ingredientItemGroupId)
				{
					loadout.faerie = resultingItem.GetGroupId();
					loadout.faerieItemName = MakeItemName(resultingItem);
				}
			}
		}
	}

	private bool IsControlPressed()
	{
		if (!Input.GetKey(KeyCode.LeftControl))
		{
			return Input.GetKey(KeyCode.RightControl);
		}
		return true;
	}

	public void CheckUserInterfaceFTUE()
	{
		if (loadouts.Count <= 0)
		{
			selectedIndex = 1;
			SaveLoadout(1, showMessage: false);
			SetLoadout(4, "star_stone", "hatchet");
			SetLoadout(5, null, "shovel");
			SetLoadout(6, null, "sight_stone");
		}
	}

	private void SetLoadout(int bindingIndex, string leftItemCriteria, string rightItemCriteria, string faerieItemCriteria = null)
	{
		Loadout loadout = SaveLoadout(bindingIndex, showMessage: false);
		loadout.leftHand = null;
		loadout.leftItemName = null;
		if (leftItemCriteria != null)
		{
			Item item = Inventory.Singleton.FindBestWeapon(leftItemCriteria, Weapon.HandType.LeftOrRight);
			if (item != null)
			{
				loadout.leftHand = item.GetGroupId();
				loadout.leftItemName = MakeItemName(item);
			}
		}
		loadout.rightHand = null;
		loadout.rightItemName = null;
		if (rightItemCriteria != null)
		{
			Item item2 = Inventory.Singleton.FindBestWeapon(rightItemCriteria, Weapon.HandType.LeftOrRight);
			if (item2 != null)
			{
				loadout.rightHand = item2.GetGroupId();
				loadout.rightItemName = MakeItemName(item2);
			}
		}
		loadout.faerie = null;
		loadout.faerieItemName = null;
		if (faerieItemCriteria != null)
		{
			Item item3 = Inventory.Singleton.FindBestWeapon(faerieItemCriteria, Weapon.HandType.LeftOrRight);
			if (item3 != null)
			{
				loadout.faerie = item3.GetGroupId();
				loadout.faerieItemName = MakeItemName(item3);
			}
		}
	}

	public void ClearProgress()
	{
		loadouts.Clear();
		loadoutsDict.Clear();
		selectedIndex = -1;
		if (UtilityBeltUI.singleton != null)
		{
			UtilityBeltUI.singleton.Hide();
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("loadouts", loadouts.ToArray());
		if (selectedIndex >= 0)
		{
			SlimJson.AddProperty("sel", selectedIndex);
		}
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			string[] array = SlimJson.ParseArray(sjson, "loadouts");
			for (int i = 0; i < array.Length; i++)
			{
				Loadout loadout = Loadout.FromString(array[i]);
				loadouts.Add(loadout);
				loadoutsDict.Add(loadout.index, loadout);
				if (Features.PREV_VERSION < new Version(1, 8, 0))
				{
					if (!string.IsNullOrEmpty(loadout.leftHand))
					{
						Weapon weapon = Inventory.Singleton.GetWeapon(loadout.leftHand);
						if (weapon != null)
						{
							loadout.leftHand = weapon.GetGroupId();
						}
					}
					if (!string.IsNullOrEmpty(loadout.rightHand))
					{
						Weapon weapon2 = Inventory.Singleton.GetWeapon(loadout.rightHand);
						if (weapon2 != null)
						{
							loadout.rightHand = weapon2.GetGroupId();
						}
					}
				}
				if (loadout.rightHand != null && ItemAbilityPatch.NeedsPatch("PATCH_ELEMENT_DAMAGE_v2100"))
				{
					if (loadout.rightHand.StartsWith("socketed_staff"))
					{
						loadout.rightHand = loadout.rightHand.Replace("element_damage_sword", "element_damage_staff");
					}
					if (loadout.rightHand.StartsWith("socketed_crossbow"))
					{
						loadout.rightHand = loadout.rightHand.Replace("element_damage_wand", "element_damage_crossbow");
					}
				}
				if (loadout.rightHand != null && ItemAbilityPatch.NeedsPatch("PATCH_HAMMERS_v2110") && loadout.rightHand.StartsWith("socketed_hammer"))
				{
					loadout.rightHand = loadout.rightHand.Replace("element_damage_sword", "element_damage_hammer");
				}
			}
			CheckForInvalidItems();
		}
		selectedIndex = SlimJson.ParseInt(sjson, "sel", -1);
	}

	private void Awake()
	{
		singleton = this;
		selectedIndex = -1;
	}
}
