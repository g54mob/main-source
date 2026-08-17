using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathStatsUi : MonoBehaviour
{
	public TextMeshProUGUI t_stats;

	public TextMeshProUGUI t_gold;

	public TextMeshProUGUI t_unlocks;

	public TextMeshProUGUI t_silver;

	public TextMeshProUGUI t_characterName;

	public RawImage i_character;

	public Transform weaponsParent;

	public Transform tomesParent;

	public Transform itemsParent;

	public GameObject inventoryItemPrefab;

	private void Start()
	{
		//IL_002f: Expected I, but got O
		//IL_0206: Expected I, but got O
		//IL_0270: Expected I, but got O
		//IL_02da: Expected I, but got O
		float num = MyTime.runTimer / 60f;
		double num2 = Math.Floor(num);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		nint num3 = (nint)typeof(MyTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FFEE0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num4 = Math.Floor(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg}:{arg2:00}";
		TextMeshProUGUI textMeshProUGUI = t_stats;
		string localizedString = LocalizationUtility.GetLocalizedString("Game_RoundOver", "SUMMARY_KILLS");
		int stat = RunStats.GetStat(EMyStat.kills);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg3 = default(object);
		string text2 = $"{localizedString}: {arg3:N0}\n";
		string localizedString2 = LocalizationUtility.GetLocalizedString("Game_RoundOver", "SUMMARY_TIME");
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		MyPlayer instance = MyPlayer.Instance;
		int characterLevel = instance.inventory.GetCharacterLevel();
		int num5 = default(int);
		string value = num5.ToString();
		((Dictionary<object, object>)(object)dictionary).Add((object)"level", (object)value);
		string localizedString3 = LocalizationUtility.GetLocalizedString("Game_HUD", "LEVEL", dictionary);
		string text3 = text2 + localizedString2 + ": " + text + "\n" + localizedString3 + "\n";
		nint num6 = (nint)textMeshProUGUI;
		textMeshProUGUI.text = text3;
		TextMeshProUGUI textMeshProUGUI2 = t_silver;
		int stat2 = RunStats.GetStat(EMyStat.silverEarned);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		string localizedString4 = LocalizationUtility.GetLocalizedString("Other", "SILVER");
		object arg4 = default(object);
		string text4 = $"<sprite name=\"silver\"> +{arg4} {localizedString4}!";
		nint num7 = (nint)textMeshProUGUI2;
		textMeshProUGUI2.text = text4;
		TextMeshProUGUI textMeshProUGUI3 = t_gold;
		int stat3 = RunStats.GetStat(EMyStat.goldEarned);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		string localizedString5 = LocalizationUtility.GetLocalizedString("Other", "GOLD");
		object arg5 = default(object);
		string text5 = $"<sprite name=\"gold\"> +{arg5} {localizedString5}!";
		nint num8 = (nint)textMeshProUGUI3;
		textMeshProUGUI3.text = text5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		string localizedString6 = LocalizationUtility.GetLocalizedString("Main Menu", "UNLOCKS");
		object arg6 = default(object);
		string text6 = $"<sprite name=\"unlock\" tint> {arg6} {localizedString6}!";
		t_unlocks.text = text6;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory = instance2.inventory;
		Texture icon = inventory.characterData.GetIcon();
		i_character.texture = icon;
		string text7 = inventory.characterData.GetName();
		t_characterName.text = text7;
		ShowInventory();
		List<MyAchievement> achievements = RunStats.achievements;
		if (achievements._size <= 0)
		{
			t_unlocks.text = "";
		}
	}

	private void ShowInventory()
	{
		//IL_0172: Expected O, but got I
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		WeaponInventory weaponInventory = inventory.weaponInventory;
		Dictionary<EWeapon, WeaponBase>.ValueCollection values = weaponInventory.weapons.Values;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		TomeInventory tomeInventory = inventory2.tomeInventory;
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerInventory inventory3 = instance3.inventory;
		ItemInventory itemInventory = inventory3.itemInventory;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
		Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator);
		Dictionary<ETome, int>.Enumerator enumerator2 = default(Dictionary<ETome, int>.Enumerator);
		ETome eTome = default(ETome);
		Dictionary<EItem, ItemBase>.Enumerator enumerator3 = default(Dictionary<EItem, ItemBase>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(inventoryItemPrefab, weaponsParent);
				bool flag = (object)gameObject == null;
				GameObject gameObject2 = inventoryItemPrefab;
				if (!flag)
				{
					InventoryItemPrefabUI component = gameObject.GetComponent<InventoryItemPrefabUI>();
					bool flag2 = (object)component == null;
					gameObject2 = gameObject;
					if (!flag2)
					{
						GameObject gameObject3 = component.gameObject;
						bool flag3 = (object)gameObject3 == null;
						gameObject2 = (GameObject)(object)component;
						if (flag3)
						{
							break;
						}
						gameObject3.SetActive(value: true);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ stack_-C8 (Assets.Scripts._Data.Tomes.ETome)+18]");
						component.SetItem((UnlockableBase)0);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D878F0");
			while (true)
			{
				if (enumerator2.MoveNext())
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate(inventoryItemPrefab, tomesParent);
					bool flag4 = (object)gameObject4 == null;
					DataManager dataManager = (DataManager)(object)inventoryItemPrefab;
					if (!flag4)
					{
						InventoryItemPrefabUI component2 = gameObject4.GetComponent<InventoryItemPrefabUI>();
						bool flag5 = (object)component2 == null;
						dataManager = (DataManager)(object)gameObject4;
						if (!flag5)
						{
							GameObject gameObject5 = component2.gameObject;
							bool flag6 = (object)gameObject5 == null;
							dataManager = (DataManager)(object)component2;
							if (!flag6)
							{
								gameObject5.SetActive(value: true);
								dataManager = DataManager.Instance;
								if ((object)DataManager.Instance == null)
								{
									break;
								}
								TomeData tome = DataManager.Instance.GetTome(eTome);
								component2.SetItem(tome);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				enumerator2.Dispose();
				int count = tomeInventory.tomeLevels.Count;
				if (count <= 0)
				{
					GameObject gameObject6 = tomesParent.gameObject;
					gameObject6.SetActive(value: false);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
				while (true)
				{
					if (enumerator3.MoveNext())
					{
						GameObject gameObject7 = UnityEngine.Object.Instantiate(inventoryItemPrefab, itemsParent);
						if ((object)gameObject7 != null)
						{
							InventoryItemPrefabUI component3 = gameObject7.GetComponent<InventoryItemPrefabUI>();
							if ((object)component3 != null)
							{
								GameObject gameObject8 = component3.gameObject;
								if ((object)gameObject8 == null)
								{
									break;
								}
								gameObject8.SetActive(value: true);
								component3.SetItem((EItem)eTome);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					enumerator3.Dispose();
					return;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}
}
