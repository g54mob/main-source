using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using Inventory__Items__Pickups.Xp_and_Levels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpBarUI : MonoBehaviour
{
	public TextMeshProUGUI t_levelText;

	public RawImage xpBar;

	private Color defaultColor;

	public Material rainbow;

	private Material defaultMaterial;

	private float desiredRatio;

	private void Awake()
	{
		//IL_0021: Expected O, but got F4
		//IL_0030: Expected O, but got F4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_00db: Expected I, but got O
		//IL_00ec: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01d2: Expected I, but got O
		//IL_01e3: Expected O, but got I4
		//IL_04e4: Expected I, but got O
		//IL_04f5: Expected O, but got I4
		//IL_050b: Expected I, but got O
		//IL_0531: Expected I, but got O
		//IL_0542: Expected O, but got I4
		//IL_0558: Expected I, but got O
		//IL_057e: Expected I, but got O
		//IL_058f: Expected O, but got I4
		//IL_05a5: Expected I, but got O
		//IL_05cb: Expected I, but got O
		//IL_05dc: Expected O, but got I4
		//IL_05f2: Expected I, but got O
		//IL_03ff: Expected I, but got O
		//IL_0410: Expected O, but got I4
		SetLevelText(0);
		Color color = xpBar.color;
		Color color2 = (Color)color.r;
		defaultColor = (Color)color.r;
		Action<PlayerXp, int> b = OnXpIncrease;
		Delegate obj = Delegate.Combine(PlayerXp.A_XpAdded, b);
		Delegate obj4;
		nint num;
		Delegate obj2;
		object obj3;
		if ((object)obj == null)
		{
			PlayerXp.A_XpAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerXp, int> action = default(Action<PlayerXp, int>);
			bool flag = action == null;
			num = (nint)typeof(Action<PlayerXp, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0491;
			}
			PlayerXp.A_XpAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
			num = (nint)typeof(Action<PlayerXp, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_049c;
			}
		}
		Action<int> b2 = OnLevelUp;
		Delegate obj6 = Delegate.Combine(PlayerXp.A_LevelUp, b2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag3 = action2 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_04ac;
			}
			PlayerXp.A_LevelUp = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag4 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_04bc;
			}
		}
		Action action3 = OnLevelupShow;
		Delegate obj8 = Delegate.Combine(LevelupScreen.A_LevelupEnabled, action3);
		if ((object)obj8 == null)
		{
			LevelupScreen.A_LevelupEnabled = null;
		}
		else
		{
			bool flag5 = (object)obj8.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag5)
			{
				obj9 = obj8;
			}
			bool flag6 = (object)obj9 == null;
			num = (nint)LevelupScreen.A_LevelupEnabled;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num2 = (nint)typeof(Action);
			if (flag6)
			{
				goto IL_0668;
			}
			LevelupScreen.A_LevelupEnabled = (Action)obj9;
			bool flag7 = (object)obj8.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag7)
			{
				obj10 = obj8;
			}
			bool flag8 = (object)obj10 == null;
			num = (nint)LevelupScreen.A_LevelupEnabled;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num3 = (nint)typeof(Action);
			if (flag8)
			{
				goto IL_0678;
			}
		}
		Action action4 = OnLevelupHide;
		Delegate obj11 = Delegate.Combine(LevelupScreen.A_LevelUpClose, action4);
		if ((object)obj11 == null)
		{
			LevelupScreen.A_LevelUpClose = null;
		}
		else
		{
			bool flag9 = (object)obj11.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag9)
			{
				obj12 = obj11;
			}
			bool flag10 = (object)obj12 == null;
			num = (nint)LevelupScreen.A_LevelUpClose;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj11;
			nint num4 = (nint)typeof(Action);
			if (flag10)
			{
				goto IL_0688;
			}
			LevelupScreen.A_LevelUpClose = (Action)obj12;
			bool flag11 = (object)obj11.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag11)
			{
				obj13 = obj11;
			}
			bool flag12 = (object)obj13 == null;
			num = (nint)LevelupScreen.A_LevelUpClose;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj11;
			nint num5 = (nint)typeof(Action);
			if (flag12)
			{
				goto IL_0698;
			}
		}
		Action<PlayerInventory> b3 = OnInventoryInitialized;
		Delegate obj14 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b3);
		if ((object)obj14 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action5 = default(Action<PlayerInventory>);
		bool flag13 = action5 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj14;
		obj3 = 0;
		obj4 = null;
		if (!flag13)
		{
			MyPlayer.A_PlayerInventoryInitialized = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj15 = default(object);
			bool flag14 = obj15 == null;
			obj4 = null;
			if (!flag14)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			Delegate obj16 = default(Delegate);
			obj2 = obj16;
			object obj17 = default(object);
			obj3 = obj17;
			Color color3 = default(Color);
			color2 = color3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0698;
		IL_0688:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0678;
		IL_0678:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0668;
		IL_0668:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04bc;
		IL_049c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0491;
		IL_0698:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0688;
		IL_04bc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ac;
		IL_0491:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04ac:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049c;
	}

	private void OnDestroy()
	{
		//IL_0446: Expected I, but got O
		//IL_0457: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_04a9: Expected I, but got O
		//IL_04ba: Expected O, but got I4
		//IL_04d0: Expected I, but got O
		//IL_0284: Expected I, but got O
		//IL_04f6: Expected I, but got O
		//IL_0507: Expected O, but got I4
		//IL_051d: Expected I, but got O
		//IL_054b: Expected O, but got I4
		//IL_0561: Expected I, but got O
		//IL_058f: Expected O, but got I4
		//IL_05a5: Expected I, but got O
		//IL_03b4: Expected I, but got O
		//IL_03c5: Expected O, but got I4
		//IL_0408: Expected I, but got O
		//IL_0419: Expected O, but got I4
		Action<PlayerXp, int> value = OnXpIncrease;
		Delegate obj = Delegate.Remove(PlayerXp.A_XpAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerXp.A_XpAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerXp, int> action = default(Action<PlayerXp, int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerXp, int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_05eb;
			}
			PlayerXp.A_XpAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerXp, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0466;
			}
		}
		Action<int> value2 = OnLevelUp;
		Delegate obj6 = Delegate.Remove(PlayerXp.A_LevelUp, value2);
		if ((object)obj6 == null)
		{
			PlayerXp.A_LevelUp = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_0471;
			}
			PlayerXp.A_LevelUp = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_0481;
			}
		}
		Action action3 = OnLevelupShow;
		Delegate obj8 = Delegate.Remove(LevelupScreen.A_LevelupEnabled, action3);
		if ((object)obj8 == null)
		{
			LevelupScreen.A_LevelupEnabled = null;
		}
		else
		{
			bool flag4 = (object)obj8.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag4)
			{
				obj9 = obj8;
			}
			bool flag5 = (object)obj9 == null;
			num2 = (nint)LevelupScreen.A_LevelupEnabled;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0623;
			}
			LevelupScreen.A_LevelupEnabled = (Action)obj9;
			bool flag6 = (object)obj8.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag6)
			{
				obj10 = obj8;
			}
			bool flag7 = (object)obj10 == null;
			num = (nint)LevelupScreen.A_LevelupEnabled;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0633;
			}
		}
		num = (nint)LevelupScreen.A_LevelUpClose;
		Action action4 = OnLevelupHide;
		Delegate obj11 = Delegate.Remove(LevelupScreen.A_LevelUpClose, action4);
		if ((object)obj11 == null)
		{
			LevelupScreen.A_LevelUpClose = null;
		}
		else
		{
			bool flag8 = (object)obj11.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag8)
			{
				obj12 = obj11;
			}
			bool flag9 = (object)obj12 == null;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj11;
			nint num5 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_064b;
			}
			LevelupScreen.A_LevelUpClose = (Action)obj12;
			bool flag10 = (object)obj11.GetType() != typeof(Action);
			Delegate obj13 = null;
			if (!flag10)
			{
				obj13 = obj11;
			}
			bool flag11 = (object)obj13 == null;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj11;
			nint num6 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_065b;
			}
		}
		Action<PlayerInventory> value3 = OnInventoryInitialized;
		Delegate obj14 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value3);
		if ((object)obj14 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action5 = default(Action<PlayerInventory>);
		bool flag12 = action5 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj14;
		obj3 = 0;
		obj4 = null;
		if (flag12)
		{
			goto IL_05db;
		}
		MyPlayer.A_PlayerInventoryInitialized = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj15 = default(object);
		bool flag13 = obj15 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj14;
		obj3 = 0;
		obj4 = null;
		if (!flag13)
		{
			return;
		}
		goto IL_05eb;
		IL_0481:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0471;
		IL_0466:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_05eb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05db;
		IL_0623:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0481;
		IL_0633:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0623;
		IL_064b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0633;
		IL_05db:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_065b;
		IL_065b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_064b;
		IL_0471:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0466;
	}

	private void Start()
	{
		if (MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.inventory != null)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory = instance2.inventory;
				Refresh(inventory.playerXp);
			}
		}
	}

	private void Refresh(PlayerXp playerXp)
	{
		//IL_005a: Expected F4, but got I4
		int xpInt = playerXp.GetXpInt();
		int num = XpUtility.XpOnCurrentLevel(xpInt);
		int xpInt2 = playerXp.GetXpInt();
		int num2 = XpUtility.XpToNextLevelTotal(xpInt2);
		int num3 = num / num2;
		desiredRatio = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 76 Invalid \"Jump target not found in method: 0x180548320\"");
		throw new NullReferenceException();
	}

	private void SetLevelText(int level)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		int num = default(int);
		string value = num.ToString();
		((Dictionary<object, object>)(object)dictionary).Add((object)"level", (object)value);
		string localizedString = LocalizationUtility.GetLocalizedString("Game_HUD", "LEVEL", dictionary);
		t_levelText.text = localizedString;
	}

	private void OnInventoryInitialized(PlayerInventory pInventory)
	{
		Refresh(pInventory.playerXp);
	}

	private void OnXpIncrease(PlayerXp pXp, int amount)
	{
		//IL_005a: Expected F4, but got I4
		int xpInt = pXp.GetXpInt();
		int num = XpUtility.XpOnCurrentLevel(xpInt);
		int xpInt2 = pXp.GetXpInt();
		int num2 = XpUtility.XpToNextLevelTotal(xpInt2);
		int num3 = num / num2;
		desiredRatio = num3;
	}

	private unsafe void Update()
	{
		//IL_0143: Invalid comparison between I4 and F4
		//IL_018e: Expected F4, but got I4
		//IL_0082: Invalid comparison between I4 and F4
		//IL_00cd: Expected F4, but got I4
		//IL_01f3: Expected O, but got Ref
		float num5;
		Transform transform3;
		if (!LevelupScreen.isLevelingUp)
		{
			Transform transform = xpBar.transform;
			Transform transform2 = xpBar.transform;
			Vector3 localScale = transform2.localScale;
			float deltaTime = Time.deltaTime;
			float num = deltaTime * 8f;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			float num2 = desiredRatio - localScale.x;
			float num3 = num2 * num;
			float num4 = num3 + localScale.x;
			num5 = num4;
			transform3 = transform;
		}
		else
		{
			Transform transform4 = xpBar.transform;
			Transform transform5 = xpBar.transform;
			Vector3 localScale2 = transform5.localScale;
			float deltaTime2 = Time.deltaTime;
			float num6 = deltaTime2 * 8f;
			if (!(0f > num6))
			{
				if (num6 > 1f)
				{
					num6 = 1f;
				}
			}
			else
			{
				num6 = 0f;
			}
			float num7 = 1f - localScale2.x;
			float num8 = num7 * num6;
			float num9 = num8 + localScale2.x;
			num5 = num9;
			transform3 = transform4;
		}
		transform3.localScale = (Vector3)(&num5);
	}

	private void OnLevelUp(int level)
	{
		SetLevelText(level);
	}

	private void OnLevelupShow()
	{
		xpBar.material = rainbow;
	}

	private unsafe void OnLevelupHide()
	{
		//IL_0037: Expected O, but got Ref
		xpBar.material = defaultMaterial;
		Transform transform = xpBar.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
	}
}
