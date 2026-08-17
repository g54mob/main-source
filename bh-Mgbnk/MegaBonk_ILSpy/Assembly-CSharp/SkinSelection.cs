using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelection : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<SkinData> _003C_003E9__19_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CSetCharacter_003Eb__19_0(SkinData a, SkinData b)
		{
			//IL_0041: Expected I4, but got O
			if ((object)a != null)
			{
				return a.CompareTo(b);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public GameObject skinContainerPrefab;

	private List<SkinContainer> containers;

	public MyButton b_confirm;

	private List<SkinData> skins;

	private int currentlySelected;

	private SkinContainer previousSelected;

	public static Action<SkinContainer> A_ForceSkinDisplay;

	private SkinContainer lastSelectedSkinContainer;

	private void Awake()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<SkinContainer> b = OnSkinHover;
		Delegate obj = Delegate.Combine(SkinContainer.A_Hover, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			SkinContainer.A_Hover = (Action<SkinContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action = default(Action<SkinContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<SkinContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			SkinContainer.A_Hover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0317;
			}
		}
		Action<SkinContainer> b2 = OnSkinHoverMouse;
		Delegate obj6 = Delegate.Combine(SkinContainer.A_HoverMouse, b2);
		if ((object)obj6 == null)
		{
			SkinContainer.A_HoverMouse = (Action<SkinContainer>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action2 = default(Action<SkinContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_0322;
			}
			SkinContainer.A_HoverMouse = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0332;
			}
		}
		Action<SkinContainer> b3 = OnSkinHoverMouseExit;
		Delegate obj8 = Delegate.Combine(SkinContainer.A_HoverMouseExit, b3);
		if ((object)obj8 == null)
		{
			SkinContainer.A_HoverMouseExit = (Action<SkinContainer>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SkinContainer> action3 = default(Action<SkinContainer>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<SkinContainer>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_034a;
		}
		SkinContainer.A_HoverMouseExit = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<SkinContainer>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_035a;
		IL_035a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034a;
		IL_0317:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0322:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0317;
		IL_0332:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0322;
		IL_034a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0332;
	}

	private void OnDestroy()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<SkinContainer> value = OnSkinHover;
		Delegate obj = Delegate.Remove(SkinContainer.A_Hover, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			SkinContainer.A_Hover = (Action<SkinContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action = default(Action<SkinContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<SkinContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			SkinContainer.A_Hover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0317;
			}
		}
		Action<SkinContainer> value2 = OnSkinHoverMouse;
		Delegate obj6 = Delegate.Remove(SkinContainer.A_HoverMouse, value2);
		if ((object)obj6 == null)
		{
			SkinContainer.A_HoverMouse = (Action<SkinContainer>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<SkinContainer> action2 = default(Action<SkinContainer>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_0322;
			}
			SkinContainer.A_HoverMouse = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<SkinContainer>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0332;
			}
		}
		Action<SkinContainer> value3 = OnSkinHoverMouseExit;
		Delegate obj8 = Delegate.Remove(SkinContainer.A_HoverMouseExit, value3);
		if ((object)obj8 == null)
		{
			SkinContainer.A_HoverMouseExit = (Action<SkinContainer>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SkinContainer> action3 = default(Action<SkinContainer>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<SkinContainer>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_034a;
		}
		SkinContainer.A_HoverMouseExit = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<SkinContainer>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_035a;
		IL_035a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034a;
		IL_0317:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0322:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0317;
		IL_0332:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0322;
		IL_034a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0332;
	}

	private void Start()
	{
	}

	private void OnSkinHover(SkinContainer skinContainer)
	{
		lastSelectedSkinContainer = skinContainer;
		List<SkinContainer> list = containers;
		int num = 0;
		int num2 = 0;
		while (num2 < list._size)
		{
			SkinContainer skinContainer2 = containers.get_Item(num);
			if (skinContainer2 != skinContainer)
			{
				list = containers;
				num++;
				num2 = num;
				continue;
			}
			SkinData skin = skinContainer.skin;
			SetCurrentlySelected(num, skin.character);
			break;
		}
		SetConfirmButtonNav();
	}

	private void OnSkinHoverMouse(SkinContainer skinContainer)
	{
	}

	private void OnSkinHoverMouseExit(SkinContainer skinContainer)
	{
		SkinContainer skinContainer2 = lastSelectedSkinContainer;
		lastSelectedSkinContainer = lastSelectedSkinContainer;
		List<SkinContainer> list = containers;
		int num = 0;
		int num2 = 0;
		while (num2 < list._size)
		{
			SkinContainer skinContainer3 = containers.get_Item(num);
			if (skinContainer3 != lastSelectedSkinContainer)
			{
				list = containers;
				num++;
				num2 = num;
				continue;
			}
			SkinData skin = skinContainer2.skin;
			SetCurrentlySelected(num, skin.character);
			break;
		}
		SetConfirmButtonNav();
	}

	private void SetCurrentlySelected(int index, ECharacter character)
	{
		SkinContainer skinContainer = containers.get_Item(index);
		bool flag = MyAchievements.IsPurchased(skinContainer.skin);
		currentlySelected = index;
		bool flag2 = !flag;
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		if (!flag2)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			Preferences preferences = config.preferences;
			((Dictionary<System.Int32Enum, int>)(object)preferences.characterSkins).set_Item((System.Int32Enum)character, currentlySelected);
			num = 0;
		}
		SkinContainer skinContainer2 = previousSelected;
		if ((object)previousSelected != null)
		{
			GameObject gameObject = skinContainer2.notSelectedOverlay.gameObject;
			gameObject.SetActive(value: true);
		}
		SkinContainer skinContainer3 = containers.get_Item(index);
		GameObject gameObject2 = skinContainer3.notSelectedOverlay.gameObject;
		gameObject2.SetActive(value: false);
		SkinContainer skinContainer4 = containers.get_Item(index);
		previousSelected = skinContainer4;
		SkinContainer skinContainer5 = containers.get_Item(index);
		lastSelectedSkinContainer = skinContainer5;
		Action<SkinContainer> a_ForceSkinDisplay = A_ForceSkinDisplay;
		if (A_ForceSkinDisplay != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v401 @ rax_v18 (System.Action`1<SkinContainer>)+18] (should have been resolved before IL gen)");
		}
	}

	public void DisableNavigation()
	{
	}

	public unsafe void CreateNavigation(Button backButton)
	{
		//IL_00f9: Expected O, but got I4
		//IL_0176: Expected O, but got Ref
		//IL_019c: Expected O, but got I4
		List<SkinData> list = skins;
		int num = 0;
		object obj2 = default(object);
		for (int num2 = 0; num2 < list._size; num2 = num)
		{
			SkinContainer skinContainer = containers.get_Item(num);
			if (((MyButton)skinContainer).button == null)
			{
				Button component = skinContainer.GetComponent<Button>();
				((MyButton)skinContainer).button = component;
			}
			if (num != 0)
			{
				int index = num - 1;
				SkinContainer skinContainer2 = containers.get_Item(index);
				Button button = skinContainer2.GetButton();
			}
			List<SkinContainer> list2 = containers;
			object obj = list2._size - 1;
			if (num < (nint)obj)
			{
				int index2 = num + 1;
				SkinContainer skinContainer3 = containers.get_Item(index2);
				Button button2 = skinContainer3.GetButton();
			}
			Button button3 = b_confirm.GetButton();
			((MyButton)skinContainer).button.navigation = (Navigation)(&obj2);
			list = skins;
			num++;
			obj2 = 4;
		}
		SetConfirmButtonNav();
	}

	public unsafe void EnableNavigation(Button backButton)
	{
		//IL_00f9: Expected O, but got I4
		//IL_0176: Expected O, but got Ref
		//IL_019c: Expected O, but got I4
		List<SkinData> list = skins;
		int num = 0;
		object obj2 = default(object);
		for (int num2 = 0; num2 < list._size; num2 = num)
		{
			SkinContainer skinContainer = containers.get_Item(num);
			if (((MyButton)skinContainer).button == null)
			{
				Button component = skinContainer.GetComponent<Button>();
				((MyButton)skinContainer).button = component;
			}
			if (num != 0)
			{
				int index = num - 1;
				SkinContainer skinContainer2 = containers.get_Item(index);
				Button button = skinContainer2.GetButton();
			}
			List<SkinContainer> list2 = containers;
			object obj = list2._size - 1;
			if (num < (nint)obj)
			{
				int index2 = num + 1;
				SkinContainer skinContainer3 = containers.get_Item(index2);
				Button button2 = skinContainer3.GetButton();
			}
			Button button3 = b_confirm.GetButton();
			((MyButton)skinContainer).button.navigation = (Navigation)(&obj2);
			list = skins;
			num++;
			obj2 = 4;
		}
		SetConfirmButtonNav();
	}

	private unsafe void SetConfirmButtonNav()
	{
		//IL_0066: Expected O, but got Ref
		Button button = b_confirm.GetButton();
		SkinContainer skinContainer = containers.get_Item(currentlySelected);
		Button button2 = skinContainer.GetButton();
		Button button3 = b_confirm.GetButton();
		object obj = default(object);
		button3.navigation = (Navigation)(&obj);
	}

	public void SetCharacter(MyButtonCharacter charButton)
	{
		//IL_0126: Expected O, but got I4
		//IL_0256: Expected O, but got I4
		CharacterData characterData = charButton.characterData;
		List<SkinData> list = DataManager.Instance.GetSkins(characterData.eCharacter);
		skins = list;
		Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__19_0;
		if (_003C_003Ec._003C_003E9__19_0 == null)
		{
			comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__19_0 = delegate(SkinData a, SkinData b)
			{
				//IL_0041: Expected I4, but got O
				if ((object)a == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				return a.CompareTo(b);
			});
		}
		((List<object>)(object)skins).Sort(comparison);
		if (containers == null)
		{
			List<SkinContainer> list2 = new List<SkinContainer>();
			containers = list2;
			SkinContainer component = skinContainerPrefab.GetComponent<SkinContainer>();
			containers.Add(component);
		}
		List<SkinData> list3 = skins;
		List<SkinContainer> list4 = containers;
		if (list3._size > list4._size)
		{
			List<SkinContainer> list5 = containers;
			object obj = list3._size - list5._size;
			bool flag = (nint)obj <= 0;
			comparison = null;
			if (!flag)
			{
				int num = default(int);
				do
				{
					Transform transform = skinContainerPrefab.transform;
					Transform parent = transform.parent;
					GameObject gameObject = UnityEngine.Object.Instantiate(skinContainerPrefab, parent);
					List<object> list6 = (List<object>)(object)containers;
					SkinContainer component2 = gameObject.GetComponent<SkinContainer>();
					int version = list6._version + 1;
					list6._version = version;
					object[] items = list6._items;
					if (list6._size >= items.Length)
					{
						list6.AddWithResize((object)component2);
					}
					else
					{
						int size = list6._size + 1;
						list6._size = size;
						items[num] = component2;
					}
					comparison = (Comparison<object>)(0 + 1);
				}
				while (System.Runtime.CompilerServices.Unsafe.As<Comparison<object>, UIntPtr>(ref comparison) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
			}
		}
		List<SkinContainer> list7 = containers;
		int num2 = 0;
		for (int num3 = 0; num3 < list7._size; num3 = num2)
		{
			List<SkinData> list8 = skins;
			if (num2 >= list8._size)
			{
				SkinContainer skinContainer = containers.get_Item(num2);
				GameObject gameObject2 = skinContainer.gameObject;
				gameObject2.SetActive(value: false);
			}
			else
			{
				SkinContainer skinContainer2 = containers.get_Item(num2);
				GameObject gameObject3 = skinContainer2.gameObject;
				gameObject3.SetActive(value: true);
				SkinContainer skinContainer3 = containers.get_Item(num2);
				GameObject gameObject4 = skinContainer3.notSelectedOverlay.gameObject;
				gameObject4.SetActive(value: true);
				SkinContainer skinContainer4 = containers.get_Item(num2);
				SkinData skin = skins.get_Item(num2);
				skinContainer4.SetSkin(skin);
			}
			list7 = containers;
			num2++;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		Preferences preferences = config.preferences;
		int num4 = preferences.characterSkins.get_Item(characterData.eCharacter);
		SkinContainer skinContainer5 = containers.get_Item(num4);
		bool flag2 = MyAchievements.IsPurchased(skinContainer5.skin);
		bool flag3 = !flag2;
		int index = 0;
		if (!flag3)
		{
			index = num4;
		}
		SetCurrentlySelected(index, characterData.eCharacter);
		if (((MyButton)charButton).button == null)
		{
			Button component3 = charButton.GetComponent<Button>();
			((MyButton)charButton).button = component3;
		}
		CreateNavigation(((MyButton)charButton).button);
	}

	public unsafe void SetNotUnlocked()
	{
		if (containers == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Component component = default(Component);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component == null)
				{
					break;
				}
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				continue;
			}
			((List<SkinContainer>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}
}
