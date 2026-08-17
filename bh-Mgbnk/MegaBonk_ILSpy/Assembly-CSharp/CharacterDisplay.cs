using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
	public PlayerRenderer playerRenderer;

	public LayerMask layerMask;

	private CharacterData currentCharacter;

	public Material lockedMaterial;

	private bool usingNonOwnedSkin;

	private void Start()
	{
		//IL_0634: Expected I, but got O
		//IL_0645: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_0221: Expected I, but got O
		//IL_0232: Expected O, but got I4
		//IL_0275: Expected I, but got O
		//IL_0286: Expected O, but got I4
		//IL_0318: Expected I, but got O
		//IL_0329: Expected O, but got I4
		//IL_036c: Expected I, but got O
		//IL_037d: Expected O, but got I4
		//IL_0399: Expected I, but got O
		//IL_070a: Expected O, but got I4
		//IL_0720: Expected I, but got O
		//IL_077b: Expected I, but got O
		//IL_074e: Expected O, but got I4
		//IL_0764: Expected I, but got O
		//IL_07c3: Expected O, but got I4
		//IL_07d9: Expected I, but got O
		//IL_0807: Expected O, but got I4
		//IL_081d: Expected I, but got O
		//IL_05a2: Expected I, but got O
		//IL_05b3: Expected O, but got I4
		//IL_05f6: Expected I, but got O
		//IL_0607: Expected O, but got I4
		Action<MyButtonCharacter> b = OnCharacterSelected;
		Delegate obj = Delegate.Combine(MyButtonCharacter.A_Select, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonCharacter.A_Select = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButtonCharacter> action = default(Action<MyButtonCharacter>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<MyButtonCharacter>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_083b;
			}
			MyButtonCharacter.A_Select = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<MyButtonCharacter>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0677;
			}
		}
		Action<SkinContainer> b2 = OnSkinSelected;
		Delegate obj6 = Delegate.Combine(SkinContainer.A_Hover, b2);
		if ((object)obj6 == null)
		{
			SkinContainer.A_Hover = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action2 = default(Action<SkinContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_0682;
			}
			SkinContainer.A_Hover = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_0692;
			}
		}
		Action<SkinContainer> b3 = OnSkinSelected;
		Delegate obj8 = Delegate.Combine(SkinContainer.A_HoverMouse, b3);
		if ((object)obj8 == null)
		{
			SkinContainer.A_HoverMouse = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action3 = default(Action<SkinContainer>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_06a2;
			}
			SkinContainer.A_HoverMouse = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_06b2;
			}
		}
		Action<SkinContainer> b4 = OnSkinSelected;
		Delegate obj10 = Delegate.Combine(SkinSelection.A_ForceSkinDisplay, b4);
		if ((object)obj10 == null)
		{
			SkinSelection.A_ForceSkinDisplay = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action4 = default(Action<SkinContainer>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<SkinContainer>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_06c2;
			}
			SkinSelection.A_ForceSkinDisplay = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<SkinContainer>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_06da;
			}
		}
		num = (nint)MapSelectionUi.A_MapSelectionEnabled;
		Action action5 = OnMapSelectionEnabled;
		Delegate obj12 = Delegate.Combine(MapSelectionUi.A_MapSelectionEnabled, action5);
		if ((object)obj12 == null)
		{
			MapSelectionUi.A_MapSelectionEnabled = null;
		}
		else
		{
			bool flag8 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag8)
			{
				obj13 = obj12;
			}
			bool flag9 = (object)obj13 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_084b;
			}
			MapSelectionUi.A_MapSelectionEnabled = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_085b;
			}
		}
		num = (nint)HatSelection.A_HatChanged;
		Action action6 = OnHatChanged;
		Delegate obj15 = Delegate.Combine(HatSelection.A_HatChanged, action6);
		if ((object)obj15 == null)
		{
			HatSelection.A_HatChanged = null;
		}
		else
		{
			bool flag12 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag12)
			{
				obj16 = obj15;
			}
			bool flag13 = (object)obj16 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num5 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_086b;
			}
			HatSelection.A_HatChanged = (Action)obj16;
			bool flag14 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj15;
			}
			bool flag15 = (object)obj17 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num6 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_087b;
			}
		}
		Action<HatData> b5 = OnHatHover;
		Delegate obj18 = Delegate.Combine(HatSelection.A_HatHover, b5);
		if ((object)obj18 == null)
		{
			HatSelection.A_HatHover = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<HatData> action7 = default(Action<HatData>);
		bool flag16 = action7 == null;
		num = (nint)typeof(Action<HatData>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (flag16)
		{
			goto IL_082b;
		}
		HatSelection.A_HatHover = action7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj19 = default(object);
		bool flag17 = obj19 == null;
		num = (nint)typeof(Action<HatData>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (!flag17)
		{
			return;
		}
		goto IL_083b;
		IL_06da:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06c2;
		IL_086b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_085b;
		IL_06c2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_06b2;
		IL_0692:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0682;
		IL_06b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06a2;
		IL_083b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_082b;
		IL_087b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_086b;
		IL_0677:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0682:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0677;
		IL_06a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0692;
		IL_084b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06da;
		IL_085b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_084b;
		IL_082b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_087b;
	}

	private unsafe void OnCharacterSelected(CharacterData characterData)
	{
		//IL_00b2: Expected O, but got Ref
		//IL_00df: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		//IL_014c: Expected O, but got I4
		//IL_0155: Expected O, but got I4
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		if (!(characterData != null) || !(currentCharacter != characterData))
		{
			return;
		}
		bool flag = characterData == null;
		CharacterData characterData2;
		if (!flag)
		{
			bool flag2 = characterData.isEnabled != flag;
			characterData2 = characterData;
			if (flag2)
			{
				goto IL_017b;
			}
		}
		characterData2 = null;
		goto IL_017b;
		IL_017b:
		currentCharacter = characterData2;
		object obj = default(object);
		playerRenderer.SetCharacter(characterData2, null, (Vector3)(&obj));
		playerRenderer.SetIdle();
		Transform transform = playerRenderer.transform;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj));
		transform.localRotation = (Quaternion)(&obj);
		if (!MyAchievements.IsUnlocked(characterData2, out var _))
		{
			playerRenderer.SetMaterial(lockedMaterial);
		}
		Transform[] componentsInChildren = playerRenderer.GetComponentsInChildren<Transform>();
		object obj2 = 0;
		object obj3 = 0;
		while ((nint)obj2 < componentsInChildren.Length)
		{
			obj3++;
			obj2 = obj3;
		}
	}

	private void OnCharacterSelected(MyButtonCharacter btn)
	{
		OnCharacterSelected(btn.characterData);
	}

	private void OnSkinSelected(SkinContainer skinContainer)
	{
		if (MyAchievements.IsUnlocked(skinContainer.skin, out var _))
		{
			bool flag = MyAchievements.IsPurchased(skinContainer.skin);
			bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			usingNonOwnedSkin = flag2;
			playerRenderer.SetSkin(skinContainer.skin);
		}
	}

	private unsafe void OnMapSelectionEnabled()
	{
		//IL_0057: Expected O, but got Ref
		if (!usingNonOwnedSkin)
		{
			return;
		}
		CharacterData characterData = currentCharacter;
		List<SkinData> skins = DataManager.Instance.GetSkins(characterData.eCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		SkinData skinData = default(SkinData);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = (object)skinData == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				if (skinData.skinType == ESkinType.Default)
				{
					playerRenderer.SetSkin(skinData);
				}
				continue;
			}
			((List<SkinData>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private void OnHatChanged()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CharacterData characterData = currentCharacter;
		EHat characterHat = config.preferences.GetCharacterHat(characterData.eCharacter);
		HatData hat = DataManager.Instance.GetHat(characterHat);
		playerRenderer.SetHat(hat);
	}

	private void OnHatHover(HatData hatData)
	{
		playerRenderer.SetHat(hatData);
	}

	private void OnDestroy()
	{
		//IL_0634: Expected I, but got O
		//IL_0645: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_0221: Expected I, but got O
		//IL_0232: Expected O, but got I4
		//IL_0275: Expected I, but got O
		//IL_0286: Expected O, but got I4
		//IL_0318: Expected I, but got O
		//IL_0329: Expected O, but got I4
		//IL_036c: Expected I, but got O
		//IL_037d: Expected O, but got I4
		//IL_0399: Expected I, but got O
		//IL_070a: Expected O, but got I4
		//IL_0720: Expected I, but got O
		//IL_077b: Expected I, but got O
		//IL_074e: Expected O, but got I4
		//IL_0764: Expected I, but got O
		//IL_07c3: Expected O, but got I4
		//IL_07d9: Expected I, but got O
		//IL_0807: Expected O, but got I4
		//IL_081d: Expected I, but got O
		//IL_05a2: Expected I, but got O
		//IL_05b3: Expected O, but got I4
		//IL_05f6: Expected I, but got O
		//IL_0607: Expected O, but got I4
		Action<MyButtonCharacter> value = OnCharacterSelected;
		Delegate obj = Delegate.Remove(MyButtonCharacter.A_Select, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonCharacter.A_Select = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButtonCharacter> action = default(Action<MyButtonCharacter>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<MyButtonCharacter>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_083b;
			}
			MyButtonCharacter.A_Select = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<MyButtonCharacter>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0677;
			}
		}
		Action<SkinContainer> value2 = OnSkinSelected;
		Delegate obj6 = Delegate.Remove(SkinContainer.A_Hover, value2);
		if ((object)obj6 == null)
		{
			SkinContainer.A_Hover = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action2 = default(Action<SkinContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_0682;
			}
			SkinContainer.A_Hover = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_0692;
			}
		}
		Action<SkinContainer> value3 = OnSkinSelected;
		Delegate obj8 = Delegate.Remove(SkinContainer.A_HoverMouse, value3);
		if ((object)obj8 == null)
		{
			SkinContainer.A_HoverMouse = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action3 = default(Action<SkinContainer>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_06a2;
			}
			SkinContainer.A_HoverMouse = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_06b2;
			}
		}
		Action<SkinContainer> value4 = OnSkinSelected;
		Delegate obj10 = Delegate.Remove(SkinSelection.A_ForceSkinDisplay, value4);
		if ((object)obj10 == null)
		{
			SkinSelection.A_ForceSkinDisplay = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action4 = default(Action<SkinContainer>);
			bool flag6 = action4 == null;
			num = (nint)typeof(Action<SkinContainer>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_06c2;
			}
			SkinSelection.A_ForceSkinDisplay = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<SkinContainer>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_06da;
			}
		}
		num = (nint)MapSelectionUi.A_MapSelectionEnabled;
		Action action5 = OnMapSelectionEnabled;
		Delegate obj12 = Delegate.Remove(MapSelectionUi.A_MapSelectionEnabled, action5);
		if ((object)obj12 == null)
		{
			MapSelectionUi.A_MapSelectionEnabled = null;
		}
		else
		{
			bool flag8 = (object)obj12.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag8)
			{
				obj13 = obj12;
			}
			bool flag9 = (object)obj13 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num3 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_084b;
			}
			MapSelectionUi.A_MapSelectionEnabled = (Action)obj13;
			bool flag10 = (object)obj12.GetType() != typeof(Action);
			Delegate obj14 = null;
			if (!flag10)
			{
				obj14 = obj12;
			}
			bool flag11 = (object)obj14 == null;
			obj2 = action5;
			obj3 = 0;
			obj4 = obj12;
			nint num4 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_085b;
			}
		}
		num = (nint)HatSelection.A_HatChanged;
		Action action6 = OnHatChanged;
		Delegate obj15 = Delegate.Remove(HatSelection.A_HatChanged, action6);
		if ((object)obj15 == null)
		{
			HatSelection.A_HatChanged = null;
		}
		else
		{
			bool flag12 = (object)obj15.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag12)
			{
				obj16 = obj15;
			}
			bool flag13 = (object)obj16 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num5 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_086b;
			}
			HatSelection.A_HatChanged = (Action)obj16;
			bool flag14 = (object)obj15.GetType() != typeof(Action);
			Delegate obj17 = null;
			if (!flag14)
			{
				obj17 = obj15;
			}
			bool flag15 = (object)obj17 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj15;
			nint num6 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_087b;
			}
		}
		Action<HatData> value5 = OnHatHover;
		Delegate obj18 = Delegate.Remove(HatSelection.A_HatHover, value5);
		if ((object)obj18 == null)
		{
			HatSelection.A_HatHover = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<HatData> action7 = default(Action<HatData>);
		bool flag16 = action7 == null;
		num = (nint)typeof(Action<HatData>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (flag16)
		{
			goto IL_082b;
		}
		HatSelection.A_HatHover = action7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj19 = default(object);
		bool flag17 = obj19 == null;
		num = (nint)typeof(Action<HatData>);
		obj2 = obj18;
		obj3 = 0;
		obj4 = null;
		if (!flag17)
		{
			return;
		}
		goto IL_083b;
		IL_06da:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06c2;
		IL_086b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_085b;
		IL_06c2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_06b2;
		IL_0692:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0682;
		IL_06b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06a2;
		IL_083b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_082b;
		IL_087b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_086b;
		IL_0677:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0682:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0677;
		IL_06a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0692;
		IL_084b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06da;
		IL_085b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_084b;
		IL_082b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_087b;
	}
}
