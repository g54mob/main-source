using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop.Rank;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoUI : MonoBehaviour
{
	public CharacterMenu characterMenu;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_weaponName;

	public TextMeshProUGUI t_weaponDesc;

	public TextMeshProUGUI t_passiveName;

	public TextMeshProUGUI t_passiveDesc;

	public RawImage i_weapon;

	public RawImage i_passive;

	public SkinSelection skinSelection;

	public RequirementsContainer reqContainer;

	public TextMeshProUGUI t_rank;

	public TextMeshProUGUI t_runs;

	public RawImage i_rankFrame;

	public RawImage i_rankIcon;

	public RawImage progressBar;

	public RawImage i_character;

	public RawImage i_runs;

	public GameObject star;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyButtonCharacter> b = OnCharacterSelected;
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
		Action<MyButtonCharacter> value = OnCharacterSelected;
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

	private unsafe void OnCharacterSelected(MyButtonCharacter btn)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0214: Expected O, but got I
		//IL_0242: Expected I, but got O
		//IL_025f: Expected O, but got I
		//IL_08a9: Expected O, but got Ref
		//IL_08d1: Expected O, but got Ref
		//IL_028d: Expected I, but got O
		//IL_02aa: Expected O, but got I
		//IL_0301: Expected O, but got I
		//IL_0347: Expected O, but got I
		//IL_036f: Expected O, but got I
		//IL_03e9: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_055c: Expected O, but got Ref
		//IL_058e: Expected I, but got O
		//IL_05a9: Expected O, but got Ref
		//IL_0625: Expected O, but got I
		//IL_0641: Expected O, but got I
		//IL_0654: Expected O, but got Ref
		//IL_0683: Expected O, but got Ref
		//IL_06e2: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		UnlockableBase characterData = btn.characterData;
		if (MyAchievements.IsUnlocked(btn.characterData, out System.Runtime.CompilerServices.Unsafe.As<object, string>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17))))
		{
			if (MyAchievements.IsUnlocked(btn.characterData, out System.Runtime.CompilerServices.Unsafe.As<object, string>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41))))
			{
				if (MyAchievements.IsPurchased(btn.characterData))
				{
					GameObject gameObject = reqContainer.gameObject;
					gameObject.SetActive(value: false);
					GameObject gameObject2 = t_description.gameObject;
					gameObject2.SetActive(value: true);
				}
				else
				{
					GameObject gameObject3 = reqContainer.gameObject;
					gameObject3.SetActive(value: true);
					GameObject gameObject4 = t_description.gameObject;
					gameObject4.SetActive(value: false);
					reqContainer.Set(btn.characterData);
				}
				string text = btn.characterData.GetName();
				t_name.text = text;
				TextMeshProUGUI textMeshProUGUI = t_description;
				string description = btn.characterData.GetDescription();
				t_description.text = description;
				Texture icon = ((UnlockableBase)btn.characterData).GetIcon();
				i_character.texture = icon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+80]");
				object obj3 = 0;
				object obj4 = obj3;
				TextMeshProUGUI textMeshProUGUI2 = t_weaponName;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1553 @ rax_v76+188] (should have been resolved before IL gen)");
				nint num = (nint)textMeshProUGUI2;
				string text2 = default(string);
				textMeshProUGUI2.text = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+80]");
				object obj5 = 0;
				object obj6 = obj5;
				TextMeshProUGUI textMeshProUGUI3 = t_weaponDesc;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1555 @ rax_v79+198] (should have been resolved before IL gen)");
				nint num2 = (nint)textMeshProUGUI3;
				string text3 = default(string);
				textMeshProUGUI3.text = text3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+80]");
				object obj7 = 0;
				object obj8 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1557 @ rax_v82+1B8] (should have been resolved before IL gen)");
				Texture texture = default(Texture);
				i_weapon.texture = texture;
				i_runs.enabled = true;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+88]");
				GameObject gameObject5;
				bool active;
				if ((UnityEngine.Object)0 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180381570");
					string text4 = default(string);
					t_passiveName.text = text4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+88]");
					string description2 = ((PassiveData)0).GetDescription();
					t_passiveDesc.text = description2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+88]");
					object obj9 = 0;
					RawImage rawImage = i_passive;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v91+30]");
					rawImage.texture = (Texture)0;
					gameObject5 = i_passive.gameObject;
					active = true;
				}
				else
				{
					t_passiveName.text = "None";
					TextMeshProUGUI textMeshProUGUI4 = t_passiveDesc;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
					textMeshProUGUI4.text = (string)0;
					gameObject5 = i_passive.gameObject;
					active = false;
				}
				gameObject5.SetActive(active);
				skinSelection.SetCharacter(btn);
				Transform transform = progressBar.transform;
				Transform parent = transform.parent;
				GameObject gameObject6 = parent.gameObject;
				gameObject6.SetActive(value: true);
				SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
				ProgressionSaveFile progression = saveManager.progression;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+50]");
				CharacterProgression characterProgression = progression.GetCharacterProgression(ECharacter.Fox);
				int displayRank = btn.characterData.GetDisplayRank();
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				ProgressionSaveFile progression2 = saveManager2.progression;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+50]");
				CharacterProgression characterProgression2 = progression2.GetCharacterProgression(ECharacter.Fox);
				ref Color frameColor = default(ref Color);
				Ranks.GetRankTextures(displayRank, out System.Runtime.CompilerServices.Unsafe.As<object, Texture>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33)), out System.Runtime.CompilerServices.Unsafe.As<object, Texture>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25)), out System.Runtime.CompilerServices.Unsafe.As<object, Color>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23)), out frameColor);
				TextMeshProUGUI textMeshProUGUI5 = t_rank;
				string localizedString = LocalizationUtility.GetLocalizedString("Other", "RANK", "Rank", useEnglishDefaultIfAvailable: false);
				object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text5 = $"{localizedString} {arg}";
				nint num3 = (nint)textMeshProUGUI5;
				textMeshProUGUI5.text = text5;
				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
				_ = characterProgression2.numRuns;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				string localizedString2 = LocalizationUtility.GetLocalizedString("Other", "RUNS", "Runs", useEnglishDefaultIfAvailable: false);
				object arg2 = default(object);
				string text6 = $"{arg2} {localizedString2}";
				t_runs.text = text6;
				RawImage rawImage2 = i_rankFrame;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
				rawImage2.texture = (Texture)0;
				RawImage rawImage3 = i_rankIcon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
				rawImage3.texture = (Texture)0;
				Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
				_ = 0;
				i_rankFrame.color = color;
				Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
				_ = 0;
				i_rankIcon.color = color2;
				Transform transform2 = progressBar.transform;
				float num4 = XpUtility.CurrentLevelProgress(characterProgression.xp);
				Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				_ = 1065353216;
				_ = 1065353216;
				transform2.localScale = localScale;
			}
		}
		else
		{
			GameObject gameObject7 = reqContainer.gameObject;
			gameObject7.SetActive(value: true);
			GameObject gameObject8 = t_description.gameObject;
			gameObject8.SetActive(value: false);
			i_runs.enabled = false;
			reqContainer.Set(btn.characterData);
			string text7 = btn.characterData.GetName();
			t_name.text = text7;
			t_weaponName.text = "???";
			t_weaponDesc.text = "???";
			t_passiveName.text = "???";
			t_passiveDesc.text = "???";
			IconManager instance = IconManager.Instance;
			i_weapon.texture = instance.questionMark;
			IconManager instance2 = IconManager.Instance;
			i_passive.texture = instance2.questionMark;
			skinSelection.SetNotUnlocked();
			IconManager instance3 = IconManager.Instance;
			i_character.texture = instance3.questionMark;
			t_rank.text = "";
			t_runs.text = "";
			Color color3 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = 0;
			i_rankFrame.color = color3;
			Color color4 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = 0;
			i_rankIcon.color = color4;
			Transform transform3 = progressBar.transform;
			Transform parent2 = transform3.parent;
			GameObject gameObject9 = parent2.gameObject;
			gameObject9.SetActive(value: false);
			if (btn.characterData.IsBlackedOutInCharacterSelectionScreen())
			{
				t_name.text = "??";
				GameObject gameObject10 = reqContainer.gameObject;
				gameObject10.SetActive(value: false);
			}
		}
		SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression3 = saveManager3.progression;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v3 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+50]");
		CharacterProgression characterProgression3 = progression3.GetCharacterProgression(ECharacter.Fox);
		bool active2 = characterProgression3.HasStar();
		star.SetActive(active2);
		characterMenu.FindAllButtonsInWindow();
	}
}
