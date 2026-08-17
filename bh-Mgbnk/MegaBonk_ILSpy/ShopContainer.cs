using System;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class ShopContainer : MonoBehaviour
{
	public RawImage icon;

	private ShopItemData _003Cdata_003Ek__BackingField;

	public Transform levelsParent;

	public GameObject backgroundLocked;

	public GameObject backgroundUnlocked;

	public GameObject alert;

	public ShopItemData data
	{
		get
		{
			return _003Cdata_003Ek__BackingField;
		}
		private set
		{
			_003Cdata_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<ShopContainer> b = OnShopItemLevelChanged;
		Delegate obj = Delegate.Combine(ShopWindow.A_LevelChanged, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ShopWindow.A_LevelChanged = (Action<ShopContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ShopContainer> action = default(Action<ShopContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<ShopContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			ShopWindow.A_LevelChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<ShopContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<ShopContainer> b2 = OnButtonSelect;
		Delegate obj6 = Delegate.Combine(MyButtonShop.A_Select, b2);
		if ((object)obj6 == null)
		{
			MyButtonShop.A_Select = (Action<ShopContainer>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ShopContainer> action2 = default(Action<ShopContainer>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<ShopContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		MyButtonShop.A_Select = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<ShopContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private void OnButtonSelect(ShopContainer shopBtn)
	{
		//IL_0105: Expected O, but got I
		//IL_0112: Expected I, but got O
		//IL_0136: Expected O, but got I
		//IL_017b: Expected O, but got I
		//IL_0188: Expected I, but got O
		//IL_01ac: Expected O, but got I
		if (!(shopBtn == this))
		{
			return;
		}
		UnityEngine.Object obj = shopBtn._003Cdata_003Ek__BackingField;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField == null)
		{
			return;
		}
		ProgressionSaveFile progression = saveManager.progression;
		if (saveManager.progression != null && progression.newShopItems != null && shopBtn._003Cdata_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v17+30]");
			object obj2 = 0;
			nint num = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v388 @ rax_v18 (Il2CppClass<UnityEngine.Object>)+1F8] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v15+60]");
			object item = default(object);
			if (((HashSet<object>)0).Contains(item))
			{
				bool flag = ((HashSet<string>)null).Contains((string)item);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v22 (System.Boolean)+30]");
				object obj3 = 0;
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v402 @ rax_v23 (Il2CppClass<UnityEngine.Object>)+1F8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v20+60]");
				object item2 = default(object);
				bool flag2 = ((HashSet<object>)0).Remove(item2);
				alert.SetActive(value: false);
			}
		}
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<ShopContainer> value = OnShopItemLevelChanged;
		Delegate obj = Delegate.Remove(ShopWindow.A_LevelChanged, value);
		if ((object)obj == null)
		{
			ShopWindow.A_LevelChanged = (Action<ShopContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ShopContainer> action = default(Action<ShopContainer>);
		if (action != null)
		{
			ShopWindow.A_LevelChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<ShopContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<ShopContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe void Set(ShopItemData shopItemData)
	{
		//IL_0067: Expected O, but got Ref
		//IL_0053: Expected O, but got Ref
		_003Cdata_003Ek__BackingField = shopItemData;
		icon.texture = shopItemData.icon;
		bool flag = MyAchievements.IsUnlocked(_003Cdata_003Ek__BackingField, out var _);
		object obj = default(object);
		if (!flag)
		{
			icon.color = (Color)(&obj);
		}
		else
		{
			icon.color = (Color)(&obj);
		}
		GameObject gameObject = backgroundLocked.gameObject;
		bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		gameObject.SetActive(active);
		GameObject gameObject2 = backgroundUnlocked.gameObject;
		gameObject2.SetActive(flag);
		GameObject gameObject3;
		bool active2;
		if (alert != null)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression = saveManager.progression;
			object internalName = _003Cdata_003Ek__BackingField.GetInternalName();
			if (((HashSet<object>)(object)progression.newShopItems).Contains(internalName))
			{
				gameObject3 = alert;
				active2 = true;
				goto IL_01e3;
			}
		}
		if (!(alert != null))
		{
			goto IL_01c4;
		}
		gameObject3 = alert;
		active2 = false;
		goto IL_01e3;
		IL_01c4:
		RefreshLevel(flag);
		return;
		IL_01e3:
		gameObject3.SetActive(active2);
		goto IL_01c4;
	}

	private void Update()
	{
	}

	private void RefreshLevel(bool isUnlocked)
	{
		if (!(levelsParent != null))
		{
			return;
		}
		Transform transform = levelsParent;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int childCount = transform.childCount;
			if (num < childCount)
			{
				int maxLevel = _003Cdata_003Ek__BackingField.GetMaxLevel();
				GameObject gameObject;
				bool active;
				if (num2 < maxLevel)
				{
					Transform child = levelsParent.GetChild(num2);
					gameObject = child.gameObject;
					active = true;
				}
				else
				{
					Transform child2 = levelsParent.GetChild(num2);
					gameObject = child2.gameObject;
					active = false;
				}
				gameObject.SetActive(active);
				int level = _003Cdata_003Ek__BackingField.GetLevel();
				GameObject gameObject2;
				bool active2;
				if (level <= num2)
				{
					Transform child3 = levelsParent.GetChild(num2);
					Transform child4 = child3.GetChild(0);
					gameObject2 = child4.gameObject;
					active2 = false;
				}
				else
				{
					Transform child5 = levelsParent.GetChild(num2);
					Transform child6 = child5.GetChild(0);
					gameObject2 = child6.gameObject;
					active2 = true;
				}
				gameObject2.SetActive(active2);
				if (!isUnlocked)
				{
					Transform child7 = levelsParent.GetChild(num2);
					GameObject gameObject3 = child7.gameObject;
					gameObject3.SetActive(value: false);
				}
				transform = levelsParent;
				num2++;
				num = num2;
				continue;
			}
			break;
		}
	}

	private void OnShopItemLevelChanged(ShopContainer shopContainer)
	{
		if (shopContainer._003Cdata_003Ek__BackingField == _003Cdata_003Ek__BackingField)
		{
			bool isUnlocked = MyAchievements.IsUnlocked(shopContainer._003Cdata_003Ek__BackingField, out var _);
			RefreshLevel(isUnlocked);
		}
	}
}
