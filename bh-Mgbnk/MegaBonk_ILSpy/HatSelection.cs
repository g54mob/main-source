using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class HatSelection : MonoBehaviour
{
	public HatSelectionPopupWindow hatSelectionPopupWindow;

	public Texture noHatTexture;

	public LocalizedString localizedNoHat;

	public ButtonTextWrapper textWrapper;

	public TextSizer textSizer;

	private static int index;

	public TextMeshProUGUI t_hatName;

	public RawImage i_hatIcon;

	private List<HatData> availableHats;

	private ECharacter character;

	public HatData selectedHatData;

	public static Action A_HatChanged;

	public static Action<HatData> A_HatHover;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyButtonCharacter> b = OnSelectCharacter;
		Delegate obj = Delegate.Combine(MyButtonCharacter.A_Select, b);
		if ((object)obj == null)
		{
			MyButtonCharacter.A_Select = (Action<MyButtonCharacter>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyButtonCharacter> action = default(Action<MyButtonCharacter>);
		if (action != null)
		{
			MyButtonCharacter.A_Select = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyButtonCharacter>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyButtonCharacter>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyButtonCharacter> value = OnSelectCharacter;
		Delegate obj = Delegate.Remove(MyButtonCharacter.A_Select, value);
		if ((object)obj == null)
		{
			MyButtonCharacter.A_Select = (Action<MyButtonCharacter>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyButtonCharacter> action = default(Action<MyButtonCharacter>);
		if (action != null)
		{
			MyButtonCharacter.A_Select = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyButtonCharacter>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyButtonCharacter>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnable()
	{
		CheckInit(force: true);
		hatSelectionPopupWindow.RefreshHatButtons(availableHats, selectedHatData);
	}

	private void CheckInit(bool force)
	{
		if (availableHats != null && !force)
		{
			return;
		}
		List<HatData> list = new List<HatData>();
		availableHats = list;
		List<object> list2 = (List<object>)(object)availableHats;
		if (availableHats != null)
		{
			int version = list2._version + 1;
			list2._version = version;
			object[] items = list2._items;
			if (list2._items != null)
			{
				if (list2._size >= items.Length)
				{
					((List<object>)(object)availableHats).AddWithResize((object)null);
				}
				else
				{
					int size = list2._size + 1;
					list2._size = size;
					if (list2._size >= items.Length)
					{
						throw new IndexOutOfRangeException();
					}
					int num = default(int);
					items[num] = null;
				}
				DataManager instance = DataManager.Instance;
				if ((object)DataManager.Instance != null && instance.unsortedHats != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					nint num2 = 0;
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					UnlockableBase unlockableBase = default(UnlockableBase);
					while (enumerator.MoveNext())
					{
						if (MyAchievements.IsPurchased(unlockableBase))
						{
							if (availableHats == null)
							{
								throw new NullReferenceException();
							}
							availableHats.Add((HatData)unlockableBase);
							num2 = 0;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					if (availableHats != null)
					{
						((List<object>)(object)availableHats).Sort();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void HoverHat(HatData hatData)
	{
		Action<HatData> a_HatHover = A_HatHover;
		if (A_HatHover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v45 @ r9_v1 (System.Action`1<HatData>)+18] (should have been resolved before IL gen)");
		}
	}

	public void SelectHat(HatData hatData)
	{
		CheckInit(force: false);
		selectedHatData = hatData;
		EHat hat;
		if (selectedHatData != null)
		{
			HatData hatData2 = selectedHatData;
			hat = hatData2.eHat;
		}
		else
		{
			hat = EHat.None;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		config.preferences.SetCharacterHat(character, hat);
		hatSelectionPopupWindow.FindStartButton(selectedHatData);
		UpdateHatText();
		Action a_HatChanged = A_HatChanged;
		if (A_HatChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v189.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void UpdateHatText()
	{
		CheckInit(force: false);
		RawImage rawImage;
		Texture icon;
		if (!(selectedHatData != null))
		{
			string localizedString = localizedNoHat.GetLocalizedString();
			bool flag = localizedString == null;
			string text = "";
			if (!flag)
			{
				text = localizedString;
			}
			t_hatName.text = text;
			rawImage = i_hatIcon;
			icon = noHatTexture;
		}
		else
		{
			string text2 = selectedHatData.GetName();
			bool flag2 = text2 == null;
			string text3 = "";
			if (!flag2)
			{
				text3 = text2;
			}
			t_hatName.text = text3;
			HatData hatData = selectedHatData;
			rawImage = i_hatIcon;
			icon = hatData.icon;
		}
		rawImage.texture = icon;
		textSizer.Recalculate();
		textSizer.Refresh();
		textWrapper.Refresh();
	}

	private void OnSelectCharacter(MyButtonCharacter characterButton)
	{
		CheckInit(force: false);
		CharacterData characterData = characterButton.characterData;
		character = characterData.eCharacter;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		EHat characterHat = config.preferences.GetCharacterHat(character);
		HatData hat = DataManager.Instance.GetHat(characterHat);
		selectedHatData = hat;
		hatSelectionPopupWindow.FindStartButton(selectedHatData);
		UpdateHatText();
	}

	private int NumSongs()
	{
		//IL_001d: Expected I4, but got O
		List<HatData> list = availableHats;
		if (availableHats != null)
		{
			return list._size;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	static HatSelection()
	{
		//IL_0013: Expected I4, but got I8
		index = -1;
	}
}
