using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class MainMenuCheats : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public WeaponType t;

		public MainMenuCheats _003C_003E4__this;

		internal void _003CPopulate_003Eb__0()
		{
			//IL_0051: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_00b8: Expected O, but got I
			MainMenuCheats mainMenuCheats = _003C_003E4__this;
			PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
			List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CUnlockedWeapons_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r9_v3+18]");
			if (num >= 0)
			{
				list.AddWithResize((System.Int32Enum)t);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = t;
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_1
	{
		public CharacterType t;

		public MainMenuCheats _003C_003E4__this;

		internal void _003CPopulate_003Eb__1()
		{
			//IL_0051: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_00bc: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_0185: Expected O, but got I
			MainMenuCheats mainMenuCheats = _003C_003E4__this;
			PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
			List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CBoughtCharacters_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r9_v3+18]");
			if (num >= 0)
			{
				list.AddWithResize((System.Int32Enum)t);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj3 = (nint)0 + (nint)1;
				_ = t;
			}
			MainMenuCheats mainMenuCheats2 = _003C_003E4__this;
			PlayerOptionsData config2 = mainMenuCheats2._playerOptions.Config;
			List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config2._003CUnlockedCharacters_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v4+18]");
			if (num2 >= 0)
			{
				list2.AddWithResize((System.Int32Enum)t);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = t;
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_2
	{
		public StageType t;

		public MainMenuCheats _003C_003E4__this;

		internal void _003CPopulate_003Eb__2()
		{
			//IL_0051: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_00bc: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_0185: Expected O, but got I
			MainMenuCheats mainMenuCheats = _003C_003E4__this;
			PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
			List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CUnlockedStages_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r9_v3+18]");
			if (num >= 0)
			{
				list.AddWithResize((System.Int32Enum)t);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj3 = (nint)0 + (nint)1;
				_ = t;
			}
			MainMenuCheats mainMenuCheats2 = _003C_003E4__this;
			PlayerOptionsData config2 = mainMenuCheats2._playerOptions.Config;
			List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config2._003CUnlockedHypers_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v4+18]");
			if (num2 >= 0)
			{
				list2.AddWithResize((System.Int32Enum)t);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = t;
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_3
	{
		public ItemType t;

		public MainMenuCheats _003C_003E4__this;

		internal void _003CPopulate_003Eb__3()
		{
			//IL_0051: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_00b8: Expected O, but got I
			MainMenuCheats mainMenuCheats = _003C_003E4__this;
			PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
			List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r9_v3+18]");
			if (num >= 0)
			{
				list.AddWithResize((System.Int32Enum)t);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = t;
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_4
	{
		public ArcanaType t;

		public MainMenuCheats _003C_003E4__this;

		internal void _003CPopulate_003Eb__4()
		{
			MainMenuCheats mainMenuCheats = _003C_003E4__this;
			mainMenuCheats._playerOptions.UnlockArcana(t);
		}
	}

	private GameObject _CheatButtonPrefab;

	private RectTransform _CharacterContainer;

	private RectTransform _StageContainer;

	private RectTransform _RelicContainer;

	private RectTransform _PowerUpContainer;

	private RectTransform _WeaponContainer;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private DataManager _dataManager;

	private void Construct(SignalBus signal, PlayerOptions player, DataManager data)
	{
		_playerOptions = player;
		_signalBus = signal;
		_dataManager = data;
	}

	private void Start()
	{
		Populate();
	}

	private unsafe void Populate()
	{
		//IL_0035: Expected O, but got I4
		//IL_00ab: Expected I4, but got O
		//IL_00d5: Expected O, but got I4
		//IL_00df: Expected O, but got I4
		//IL_02b8: Expected O, but got I4
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_032e: Expected I4, but got O
		//IL_0358: Expected O, but got I4
		//IL_0362: Expected O, but got I4
		//IL_020d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_0263: Expected I, but got O
		//IL_054f: Expected O, but got I4
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_05c5: Expected I4, but got O
		//IL_05ef: Expected O, but got I4
		//IL_05f8: Expected O, but got I4
		//IL_049c: Expected I, but got O
		//IL_04ed: Expected O, but got I4
		//IL_04f2: Expected I, but got O
		//IL_07bd: Expected O, but got I4
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Expected O, but got Unknown
		//IL_0833: Expected I4, but got O
		//IL_085d: Expected O, but got I4
		//IL_0866: Expected O, but got I4
		//IL_070a: Expected I, but got O
		//IL_075b: Expected O, but got I4
		//IL_0760: Expected I, but got O
		//IL_0a96: Expected O, but got I4
		//IL_0a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4c: Expected O, but got Unknown
		//IL_0924: Expected O, but got Ref
		//IL_0959: Expected I, but got O
		//IL_095e: Expected I, but got O
		//IL_0b0c: Expected I4, but got O
		//IL_0b29: Expected O, but got I4
		//IL_09d5: Expected I, but got O
		//IL_0a2b: Expected I, but got O
		//IL_0a34: Expected O, but got I4
		//IL_0a39: Expected I, but got O
		//IL_0ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca6: Expected O, but got Unknown
		//IL_0c43: Expected I, but got O
		//IL_0c93: Expected O, but got I4
		int num = ((Dictionary<WeaponType, List<WeaponData>>)(object)typeof(WeaponType)).FindEntry(WeaponType.MAGIC_MISSILE);
		object obj = num + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		object obj2 = obj3;
		if (obj2 != null)
		{
			object obj4 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ rdx_v5+8F8] (should have been resolved before IL gen)");
			Dictionary<WeaponType, List<WeaponData>> dictionary = default(Dictionary<WeaponType, List<WeaponData>>);
			if (dictionary.FindEntry((WeaponType)typeof(WeaponType[])) != 0)
			{
				object obj5 = 0;
				object obj6 = 0;
				nint num3 = default(nint);
				while (true)
				{
					object obj7 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v17 (System.Int32)+18]");
					if ((nint)obj7 >= 0)
					{
						break;
					}
					_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass11_0();
					CS_0024_003C_003E8__locals27._003C_003E4__this = this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v17 (System.Int32)+20+v353 @ rsi_v6*4]");
					CS_0024_003C_003E8__locals27.t = WeaponType.VOID;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v17 (System.Int32)+20+v353 @ rsi_v6*4]");
					if ((nint)0 != 0)
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)CS_0024_003C_003E8__locals27.t);
						bool flag = num2 < 0;
						num3 = 0;
						if (!flag)
						{
							GameObject gameObject = UnityEngine.Object.Instantiate(_CheatButtonPrefab, _WeaponContainer);
							GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, _WeaponContainer);
							Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
							object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals27.t);
							List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)obj8).get_Item(WeaponType.VOID);
							nint num4 = (nint)gameObject2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v265 @ r9_v31 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
							Button component = gameObject.GetComponent<Button>();
							UnityAction call = delegate
							{
								//IL_0051: Expected O, but got I
								//IL_0061: Expected O, but got I
								//IL_00b8: Expected O, but got I
								MainMenuCheats mainMenuCheats = CS_0024_003C_003E8__locals27._003C_003E4__this;
								PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
								List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)config._003CUnlockedWeapons_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
								object obj41 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
								object obj42 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
								nint num22 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r9_v3+18]");
								if (num22 >= 0)
								{
									list4.AddWithResize((System.Int32Enum)CS_0024_003C_003E8__locals27.t);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
									object obj43 = (nint)0 + (nint)1;
									_ = CS_0024_003C_003E8__locals27.t;
								}
							};
							component.m_OnClick.AddListener(call);
							object obj9 = 0;
							num3 = unchecked((nint)null);
						}
					}
					obj5++;
					obj6 = obj5;
				}
				int num5 = ((Dictionary<WeaponType, List<WeaponData>>)(object)typeof(CharacterType)).FindEntry(WeaponType.MAGIC_MISSILE);
				object obj10 = num5 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj12 = default(object);
				object obj11 = obj12;
				if (obj11 != null)
				{
					object obj13 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1622 @ rdx_v34+8F8] (should have been resolved before IL gen)");
					Dictionary<WeaponType, List<WeaponData>> dictionary2 = default(Dictionary<WeaponType, List<WeaponData>>);
					if (dictionary2.FindEntry((WeaponType)typeof(CharacterType[])) != 0)
					{
						object obj14 = 0;
						object obj15 = 0;
						while (true)
						{
							object obj16 = obj15;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rax_v65 (System.Int32)+18]");
							if ((nint)obj16 >= 0)
							{
								break;
							}
							_003C_003Ec__DisplayClass11_1 CS_0024_003C_003E8__locals33 = new _003C_003Ec__DisplayClass11_1();
							CS_0024_003C_003E8__locals33._003C_003E4__this = this;
							nint num6 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rax_v65 (System.Int32)+20+v355 @ rsi_v18*4]");
							CS_0024_003C_003E8__locals33.t = CharacterType.VOID;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rax_v65 (System.Int32)+20+v355 @ rsi_v18*4]");
							if ((nint)0 != 0)
							{
								Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
								int num7 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)CS_0024_003C_003E8__locals33.t);
								bool flag2 = num7 < 0;
								num6 = 0;
								if (!flag2)
								{
									GameObject gameObject3 = UnityEngine.Object.Instantiate(_CheatButtonPrefab, _CharacterContainer);
									GameObject gameObject4 = UnityEngine.Object.Instantiate(gameObject3, _CharacterContainer);
									Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = _dataManager.GetConvertedCharacterData();
									object obj17 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals33.t);
									List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)obj17).get_Item(CS_0024_003C_003E8__locals33.t);
									nint num8 = (nint)gameObject4;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v268 @ r9_v28 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
									Button component2 = gameObject3.GetComponent<Button>();
									UnityAction call2 = delegate
									{
										//IL_0051: Expected O, but got I
										//IL_0061: Expected O, but got I
										//IL_00bc: Expected O, but got I
										//IL_011e: Expected O, but got I
										//IL_012e: Expected O, but got I
										//IL_0185: Expected O, but got I
										MainMenuCheats mainMenuCheats = CS_0024_003C_003E8__locals33._003C_003E4__this;
										PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
										List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)config._003CBoughtCharacters_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
										object obj41 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
										object obj42 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
										nint num22 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r9_v3+18]");
										if (num22 >= 0)
										{
											list4.AddWithResize((System.Int32Enum)CS_0024_003C_003E8__locals33.t);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
											object obj43 = (nint)0 + (nint)1;
											_ = CS_0024_003C_003E8__locals33.t;
										}
										MainMenuCheats mainMenuCheats2 = CS_0024_003C_003E8__locals33._003C_003E4__this;
										PlayerOptionsData config2 = mainMenuCheats2._playerOptions.Config;
										List<System.Int32Enum> list5 = (List<System.Int32Enum>)(object)config2._003CUnlockedCharacters_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
										object obj44 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
										object obj45 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
										nint num23 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v4+18]");
										if (num23 >= 0)
										{
											list5.AddWithResize((System.Int32Enum)CS_0024_003C_003E8__locals33.t);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
											object obj46 = (nint)0 + (nint)1;
											_ = CS_0024_003C_003E8__locals33.t;
										}
									};
									component2.m_OnClick.AddListener(call2);
									object obj9 = 0;
									num6 = unchecked((nint)null);
								}
							}
							obj14++;
							num3 = num6;
							obj15 = obj14;
						}
						int num9 = ((Dictionary<WeaponType, List<WeaponData>>)(object)typeof(StageType)).FindEntry(WeaponType.MAGIC_MISSILE);
						object obj18 = num9 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
						object obj20 = default(object);
						object obj19 = obj20;
						if (obj19 != null)
						{
							object obj21 = obj19;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2127 @ rdx_v39+8F8] (should have been resolved before IL gen)");
							Dictionary<WeaponType, List<WeaponData>> dictionary3 = default(Dictionary<WeaponType, List<WeaponData>>);
							if (dictionary3.FindEntry((WeaponType)typeof(StageType[])) != 0)
							{
								object obj22 = 0;
								object obj23 = 0;
								while (true)
								{
									object obj24 = obj23;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2168 @ rax_v73 (System.Int32)+18]");
									if ((nint)obj24 >= 0)
									{
										break;
									}
									_003C_003Ec__DisplayClass11_2 CS_0024_003C_003E8__locals39 = new _003C_003Ec__DisplayClass11_2();
									CS_0024_003C_003E8__locals39._003C_003E4__this = this;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2168 @ rax_v73 (System.Int32)+20+v357 @ rsi_v21*4]");
									CS_0024_003C_003E8__locals39.t = StageType.FOREST;
									Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
									int num10 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry((System.Int32Enum)CS_0024_003C_003E8__locals39.t);
									bool flag3 = num10 < 0;
									nint num11 = 0;
									if (!flag3)
									{
										GameObject gameObject5 = UnityEngine.Object.Instantiate(_CheatButtonPrefab, _StageContainer);
										GameObject gameObject6 = UnityEngine.Object.Instantiate(gameObject5, _StageContainer);
										Dictionary<StageType, List<StageData>> convertedStages2 = _dataManager.GetConvertedStages();
										object obj25 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages2).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals39.t);
										List<StageData> list3 = ((Dictionary<StageType, List<StageData>>)obj25).get_Item(CS_0024_003C_003E8__locals39.t);
										nint num12 = (nint)gameObject6;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ r9_v25 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
										Button component3 = gameObject5.GetComponent<Button>();
										UnityAction call3 = delegate
										{
											//IL_0051: Expected O, but got I
											//IL_0061: Expected O, but got I
											//IL_00bc: Expected O, but got I
											//IL_011e: Expected O, but got I
											//IL_012e: Expected O, but got I
											//IL_0185: Expected O, but got I
											MainMenuCheats mainMenuCheats = CS_0024_003C_003E8__locals39._003C_003E4__this;
											PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
											List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)config._003CUnlockedStages_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
											object obj41 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
											object obj42 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
											nint num22 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r9_v3+18]");
											if (num22 >= 0)
											{
												list4.AddWithResize((System.Int32Enum)CS_0024_003C_003E8__locals39.t);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
												object obj43 = (nint)0 + (nint)1;
												_ = CS_0024_003C_003E8__locals39.t;
											}
											MainMenuCheats mainMenuCheats2 = CS_0024_003C_003E8__locals39._003C_003E4__this;
											PlayerOptionsData config2 = mainMenuCheats2._playerOptions.Config;
											List<System.Int32Enum> list5 = (List<System.Int32Enum>)(object)config2._003CUnlockedHypers_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
											object obj44 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
											object obj45 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
											nint num23 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v4+18]");
											if (num23 >= 0)
											{
												list5.AddWithResize((System.Int32Enum)CS_0024_003C_003E8__locals39.t);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
												object obj46 = (nint)0 + (nint)1;
												_ = CS_0024_003C_003E8__locals39.t;
											}
										};
										component3.m_OnClick.AddListener(call3);
										object obj9 = 0;
										num11 = unchecked((nint)null);
									}
									obj22++;
									num3 = num11;
									obj23 = obj22;
								}
								int num13 = ((Dictionary<WeaponType, List<WeaponData>>)(object)typeof(ItemType)).FindEntry(WeaponType.MAGIC_MISSILE);
								object obj26 = num13 + 32;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								object obj28 = default(object);
								object obj27 = obj28;
								if (obj27 != null)
								{
									object obj29 = obj27;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2444 @ rdx_v44+8F8] (should have been resolved before IL gen)");
									Dictionary<WeaponType, List<WeaponData>> dictionary4 = default(Dictionary<WeaponType, List<WeaponData>>);
									if (dictionary4.FindEntry((WeaponType)typeof(ItemType[])) != 0)
									{
										object obj30 = 0;
										object obj31 = 0;
										nint num16 = default(nint);
										while (true)
										{
											object obj32 = obj31;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1978 @ rax_v81 (System.Int32)+18]");
											if ((nint)obj32 >= 0)
											{
												break;
											}
											_003C_003Ec__DisplayClass11_3 CS_0024_003C_003E8__locals42 = new _003C_003Ec__DisplayClass11_3();
											CS_0024_003C_003E8__locals42._003C_003E4__this = this;
											nint num14 = num3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1978 @ rax_v81 (System.Int32)+20+v359 @ rsi_v24*4]");
											CS_0024_003C_003E8__locals42.t = ItemType.VOID;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1978 @ rax_v81 (System.Int32)+20+v359 @ rsi_v24*4]");
											if ((nint)0 != 0)
											{
												DataManager dataManager = _dataManager;
												Dictionary<ItemType, ItemData> dictionary5 = dataManager._003CAllItems_003Ek__BackingField;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1978 @ rax_v81 (System.Int32)+20+v359 @ rsi_v24*4]");
												int num15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary5).FindEntry((System.Int32Enum)0);
												bool flag4 = num15 < 0;
												num14 = 0;
												if (!flag4)
												{
													string text = ((Enum)(&num16)).ToString();
													bool flag5 = text.Contains("RELIC");
													bool flag6 = !flag5;
													num16 = (nint)typeof(ItemType);
													num14 = unchecked((nint)null);
													if (!flag6)
													{
														GameObject gameObject7 = UnityEngine.Object.Instantiate(_CheatButtonPrefab, _RelicContainer);
														GameObject gameObject8 = UnityEngine.Object.Instantiate(gameObject7, _RelicContainer);
														DataManager dataManager2 = _dataManager;
														object obj33 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals42.t);
														nint num17 = (nint)gameObject8;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v274 @ r9_v22 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
														Button component4 = gameObject7.GetComponent<Button>();
														UnityAction call4 = delegate
														{
															//IL_0051: Expected O, but got I
															//IL_0061: Expected O, but got I
															//IL_00b8: Expected O, but got I
															MainMenuCheats mainMenuCheats = CS_0024_003C_003E8__locals42._003C_003E4__this;
															PlayerOptionsData config = mainMenuCheats._playerOptions.Config;
															List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)config._003CCollectedItems_003Ek__BackingField;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
															object obj41 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
															object obj42 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
															nint num22 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r9_v3+18]");
															if (num22 >= 0)
															{
																list4.AddWithResize((System.Int32Enum)CS_0024_003C_003E8__locals42.t);
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
																object obj43 = (nint)0 + (nint)1;
																_ = CS_0024_003C_003E8__locals42.t;
															}
														};
														component4.m_OnClick.AddListener(call4);
														num16 = (nint)typeof(ItemType);
														object obj9 = 0;
														num14 = unchecked((nint)null);
													}
												}
											}
											obj30++;
											num3 = num14;
											obj31 = obj30;
										}
										int num18 = ((Dictionary<WeaponType, List<WeaponData>>)(object)typeof(ArcanaType)).FindEntry(WeaponType.MAGIC_MISSILE);
										object obj34 = num18 + 32;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
										object obj36 = default(object);
										object obj35 = obj36;
										if (obj35 != null)
										{
											object obj37 = obj35;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2723 @ rdx_v49+8F8] (should have been resolved before IL gen)");
											Dictionary<WeaponType, List<WeaponData>> dictionary6 = default(Dictionary<WeaponType, List<WeaponData>>);
											int num19 = dictionary6.FindEntry((WeaponType)typeof(ArcanaType[]));
											bool flag7 = num19 == 0;
											object obj38 = 0;
											if (!flag7)
											{
												while (true)
												{
													object obj39 = obj38;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1595 @ rax_v89 (System.Int32)+18]");
													if ((nint)obj39 >= 0)
													{
														break;
													}
													_003C_003Ec__DisplayClass11_4 CS_0024_003C_003E8__locals44 = new _003C_003Ec__DisplayClass11_4();
													CS_0024_003C_003E8__locals44._003C_003E4__this = this;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1595 @ rax_v89 (System.Int32)+20+v419 @ r12_v14*4]");
													CS_0024_003C_003E8__locals44.t = ArcanaType.T00_KILLER;
													DataManager dataManager3 = _dataManager;
													Dictionary<ArcanaType, ArcanaData> dictionary7 = dataManager3._003CAllArcanas_003Ek__BackingField;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1595 @ rax_v89 (System.Int32)+20+v419 @ r12_v14*4]");
													int num20 = ((Dictionary<System.Int32Enum, object>)(object)dictionary7).FindEntry((System.Int32Enum)0);
													if (num20 >= 0)
													{
														GameObject gameObject9 = UnityEngine.Object.Instantiate(_CheatButtonPrefab, _PowerUpContainer);
														GameObject gameObject10 = UnityEngine.Object.Instantiate(gameObject9, _PowerUpContainer);
														DataManager dataManager4 = _dataManager;
														object obj40 = ((Dictionary<System.Int32Enum, object>)(object)dataManager4._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals44.t);
														nint num21 = (nint)gameObject10;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v277 @ r9_v19 (Il2CppClass<UnityEngine.GameObject>)+558] (should have been resolved before IL gen)");
														Button component5 = gameObject9.GetComponent<Button>();
														UnityAction call5 = delegate
														{
															MainMenuCheats mainMenuCheats = CS_0024_003C_003E8__locals44._003C_003E4__this;
															mainMenuCheats._playerOptions.UnlockArcana(CS_0024_003C_003E8__locals44.t);
														};
														component5.m_OnClick.AddListener(call5);
														object obj9 = 0;
													}
													obj38++;
												}
												return;
											}
											throw new InvalidCastException();
										}
										ArgumentNullException ex = new ArgumentNullException("enumType");
										ex._002Ector("enumType");
										throw ex;
									}
									throw new InvalidCastException();
								}
								ArgumentNullException ex2 = new ArgumentNullException("enumType");
								ex2._002Ector("enumType");
								throw ex2;
							}
							throw new InvalidCastException();
						}
						ArgumentNullException ex3 = new ArgumentNullException("enumType");
						ex3._002Ector("enumType");
						throw ex3;
					}
					throw new InvalidCastException();
				}
				ArgumentNullException ex4 = new ArgumentNullException("enumType");
				ex4._002Ector("enumType");
				throw ex4;
			}
			throw new InvalidCastException();
		}
		ArgumentNullException ex5 = new ArgumentNullException("enumType");
		ex5._002Ector("enumType");
		throw ex5;
	}

	public void AddCoins()
	{
		float num = _playerOptions.AddCoins(999999f);
	}

	public MainMenuCheats()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
