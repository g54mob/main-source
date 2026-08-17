using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
	public Transform healthBar;

	public Transform shieldBar;

	public Transform overhealBar;

	public CanvasGroup canvasGroup;

	private Vector3 defaultPosition;

	public TextMeshProUGUI t_hp;

	public TextMeshProUGUI t_shield;

	public bool followPlayer = true;

	private void Awake()
	{
		//IL_0021: Expected O, but got F4
		//IL_0187: Expected I, but got O
		//IL_0198: Expected O, but got I4
		//IL_01db: Expected I, but got O
		//IL_01ec: Expected O, but got I4
		//IL_027e: Expected I, but got O
		//IL_028f: Expected O, but got I4
		//IL_02d2: Expected I, but got O
		//IL_02e3: Expected O, but got I4
		//IL_0375: Expected I, but got O
		//IL_0386: Expected O, but got I4
		//IL_03c9: Expected I, but got O
		//IL_03da: Expected O, but got I4
		//IL_046c: Expected I, but got O
		//IL_047d: Expected O, but got I4
		//IL_04c0: Expected I, but got O
		//IL_04d1: Expected O, but got I4
		//IL_053b: Expected I, but got O
		//IL_054c: Expected O, but got I4
		//IL_058f: Expected I, but got O
		//IL_05a0: Expected O, but got I4
		//IL_05bc: Expected I, but got O
		//IL_0997: Expected O, but got I4
		//IL_09ad: Expected I, but got O
		//IL_069e: Expected I, but got O
		//IL_09db: Expected O, but got I4
		//IL_09f1: Expected I, but got O
		//IL_0a1f: Expected O, but got I4
		//IL_0a35: Expected I, but got O
		//IL_0a63: Expected O, but got I4
		//IL_0a79: Expected I, but got O
		//IL_07ce: Expected I, but got O
		//IL_07df: Expected O, but got I4
		//IL_0822: Expected I, but got O
		//IL_0833: Expected O, but got I4
		Transform transform = base.transform;
		Delegate obj;
		if ((object)transform != null)
		{
			Vector3 localPosition = transform.localPosition;
			defaultPosition = (Vector3)localPosition.x;
			_ = localPosition.z;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if ((object)SaveManager._003CInstance_003Ek__BackingField == null || saveManager.config == null)
			{
				goto IL_0884;
			}
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			bool flag = (object)SaveManager._003CInstance_003Ek__BackingField == null;
			obj = null;
			if (!flag)
			{
				ConfigSaveFile config = saveManager2.config;
				bool flag2 = saveManager2.config == null;
				obj = null;
				if (!flag2)
				{
					CFGameSettings cfGameSettings = config.cfGameSettings;
					bool flag3 = config.cfGameSettings == null;
					obj = null;
					if (!flag3)
					{
						SetHealthBarColor((EHpBarColor)cfGameSettings.hp_bar_color);
						goto IL_0884;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0aef:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0adf;
		IL_0aff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0aef;
		IL_08b7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08ac;
		IL_08ac:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0967:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0957;
		IL_090f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08ff;
		IL_091f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_090f;
		IL_0884:
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamageTaken);
		Delegate obj2 = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		Delegate obj3;
		object obj4;
		nint num;
		if ((object)obj2 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag4 = action == null;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj3 = obj2;
			obj4 = 0;
			obj = null;
			if (flag4)
			{
				goto IL_08ac;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag5 = obj5 == null;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj3 = obj2;
			obj4 = 0;
			obj = null;
			if (flag5)
			{
				goto IL_08b7;
			}
		}
		Action<PlayerHealth> b2 = OnMaxValuesChanged;
		Delegate obj6 = Delegate.Combine(PlayerHealth.A_MaxValuesChanged, b2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_MaxValuesChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth> action2 = default(Action<PlayerHealth>);
			bool flag6 = action2 == null;
			num = (nint)typeof(Action<PlayerHealth>);
			obj3 = obj6;
			obj4 = 0;
			obj = null;
			if (flag6)
			{
				goto IL_08c7;
			}
			PlayerHealth.A_MaxValuesChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag7 = obj7 == null;
			num = (nint)typeof(Action<PlayerHealth>);
			obj3 = obj6;
			obj4 = 0;
			obj = null;
			if (flag7)
			{
				goto IL_08d7;
			}
		}
		Action<PlayerHealth, float, bool> b3 = new Action<object, float, bool>(OnHeal);
		Delegate obj8 = Delegate.Combine(PlayerHealth.A_Heal, b3);
		nint num2;
		if ((object)obj8 == null)
		{
			PlayerHealth.A_Heal = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, float, bool> action3 = default(Action<PlayerHealth, float, bool>);
			bool flag8 = action3 == null;
			num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj3 = obj8;
			obj4 = 0;
			obj = null;
			if (flag8)
			{
				goto IL_08e7;
			}
			PlayerHealth.A_Heal = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag9 = obj9 == null;
			num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj3 = obj8;
			obj4 = 0;
			obj = null;
			if (flag9)
			{
				goto IL_08ff;
			}
		}
		Action<PlayerHealth> b4 = OnOverhealChanged;
		Delegate obj10 = Delegate.Combine(PlayerHealth.A_OverhealUpdate, b4);
		if ((object)obj10 == null)
		{
			PlayerHealth.A_OverhealUpdate = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth> action4 = default(Action<PlayerHealth>);
			bool flag10 = action4 == null;
			num2 = (nint)typeof(Action<PlayerHealth>);
			obj3 = obj10;
			obj4 = 0;
			obj = null;
			if (flag10)
			{
				goto IL_090f;
			}
			PlayerHealth.A_OverhealUpdate = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag11 = obj11 == null;
			num2 = (nint)typeof(Action<PlayerHealth>);
			obj3 = obj10;
			obj4 = 0;
			obj = null;
			if (flag11)
			{
				goto IL_091f;
			}
		}
		Action<PlayerInventory> b5 = OnPlayerInventoryInit;
		Delegate obj12 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b5);
		if ((object)obj12 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action5 = default(Action<PlayerInventory>);
			bool flag12 = action5 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj3 = obj12;
			obj4 = 0;
			obj = null;
			if (flag12)
			{
				goto IL_0957;
			}
			MyPlayer.A_PlayerInventoryInitialized = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj13 = default(object);
			bool flag13 = obj13 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj3 = obj12;
			obj4 = 0;
			obj = null;
			if (flag13)
			{
				goto IL_0967;
			}
		}
		num2 = (nint)SpawnPlayerPortal.A_PortalOpen;
		Action action6 = OnPortalOpen;
		Delegate obj14 = Delegate.Combine(SpawnPlayerPortal.A_PortalOpen, action6);
		if ((object)obj14 == null)
		{
			SpawnPlayerPortal.A_PortalOpen = null;
		}
		else
		{
			bool flag14 = (object)obj14.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag14)
			{
				obj15 = obj14;
			}
			bool flag15 = (object)obj15 == null;
			obj3 = action6;
			obj4 = 0;
			obj = obj14;
			nint num3 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0acf;
			}
			SpawnPlayerPortal.A_PortalOpen = (Action)obj15;
			bool flag16 = (object)obj14.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag16)
			{
				obj16 = obj14;
			}
			bool flag17 = (object)obj16 == null;
			obj3 = action6;
			obj4 = 0;
			obj = obj14;
			nint num4 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_0adf;
			}
		}
		num2 = (nint)SpawnPlayerPortal.A_PortalClosed;
		Action action7 = OnPortalClose;
		Delegate obj17 = Delegate.Combine(SpawnPlayerPortal.A_PortalClosed, action7);
		if ((object)obj17 == null)
		{
			SpawnPlayerPortal.A_PortalClosed = null;
		}
		else
		{
			bool flag18 = (object)obj17.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag18)
			{
				obj18 = obj17;
			}
			bool flag19 = (object)obj18 == null;
			obj3 = action7;
			obj4 = 0;
			obj = obj17;
			nint num5 = (nint)typeof(Action);
			if (flag19)
			{
				goto IL_0aef;
			}
			SpawnPlayerPortal.A_PortalClosed = (Action)obj18;
			bool flag20 = (object)obj17.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag20)
			{
				obj19 = obj17;
			}
			bool flag21 = (object)obj19 == null;
			obj3 = action7;
			obj4 = 0;
			obj = obj17;
			nint num6 = (nint)typeof(Action);
			if (flag21)
			{
				goto IL_0aff;
			}
		}
		Action<string, object, object> b6 = OnSettingUpdated;
		Delegate obj20 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b6);
		if ((object)obj20 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action8 = default(Action<string, object, object>);
		bool flag22 = action8 == null;
		num2 = (nint)typeof(Action<string, object, object>);
		obj3 = obj20;
		obj4 = 0;
		obj = null;
		if (!flag22)
		{
			CurrentSettings.A_SettingUpdated = action8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj21 = default(object);
			bool flag23 = obj21 == null;
			num2 = (nint)typeof(Action<string, object, object>);
			obj3 = obj20;
			obj4 = 0;
			obj = null;
			if (!flag23)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0aff;
		IL_08e7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		goto IL_08d7;
		IL_08ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08e7;
		IL_0adf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0acf;
		IL_0acf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0967;
		IL_08c7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08b7;
		IL_08d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08c7;
		IL_0957:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_091f;
	}

	private void OnDestroy()
	{
		//IL_070c: Expected I, but got O
		//IL_071d: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_02f0: Expected I, but got O
		//IL_0301: Expected O, but got I4
		//IL_0344: Expected I, but got O
		//IL_0355: Expected O, but got I4
		//IL_03e7: Expected I, but got O
		//IL_03f8: Expected O, but got I4
		//IL_043b: Expected I, but got O
		//IL_044c: Expected O, but got I4
		//IL_0468: Expected I, but got O
		//IL_0807: Expected O, but got I4
		//IL_081d: Expected I, but got O
		//IL_054a: Expected I, but got O
		//IL_084b: Expected O, but got I4
		//IL_0861: Expected I, but got O
		//IL_088f: Expected O, but got I4
		//IL_08a5: Expected I, but got O
		//IL_08d3: Expected O, but got I4
		//IL_08e9: Expected I, but got O
		//IL_067a: Expected I, but got O
		//IL_068b: Expected O, but got I4
		//IL_06ce: Expected I, but got O
		//IL_06df: Expected O, but got I4
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnDamageTaken);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_092f;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_072c;
			}
		}
		Action<PlayerHealth> value2 = OnMaxValuesChanged;
		Delegate obj6 = Delegate.Remove(PlayerHealth.A_MaxValuesChanged, value2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_MaxValuesChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth> action2 = default(Action<PlayerHealth>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<PlayerHealth>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_0737;
			}
			PlayerHealth.A_MaxValuesChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<PlayerHealth>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_0747;
			}
		}
		Action<PlayerInventory> value3 = OnPlayerInventoryInit;
		Delegate obj8 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value3);
		if ((object)obj8 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_077f;
			}
			MyPlayer.A_PlayerInventoryInitialized = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_078f;
			}
		}
		Action<PlayerHealth, float, bool> value4 = new Action<object, float, bool>(OnHeal);
		Delegate obj10 = Delegate.Remove(PlayerHealth.A_Heal, value4);
		if ((object)obj10 == null)
		{
			PlayerHealth.A_Heal = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, float, bool> action4 = default(Action<PlayerHealth, float, bool>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag6)
			{
				goto IL_079f;
			}
			PlayerHealth.A_Heal = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			num = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj2 = obj10;
			obj3 = 0;
			obj4 = null;
			if (flag7)
			{
				goto IL_07af;
			}
		}
		Action<PlayerHealth> value5 = OnOverhealChanged;
		Delegate obj12 = Delegate.Remove(PlayerHealth.A_OverhealUpdate, value5);
		if ((object)obj12 == null)
		{
			PlayerHealth.A_OverhealUpdate = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth> action5 = default(Action<PlayerHealth>);
			bool flag8 = action5 == null;
			num = (nint)typeof(Action<PlayerHealth>);
			obj2 = obj12;
			obj3 = 0;
			obj4 = null;
			if (flag8)
			{
				goto IL_07c7;
			}
			PlayerHealth.A_OverhealUpdate = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj13 = default(object);
			bool flag9 = obj13 == null;
			num = (nint)typeof(Action<PlayerHealth>);
			obj2 = obj12;
			obj3 = 0;
			obj4 = null;
			if (flag9)
			{
				goto IL_07d7;
			}
		}
		num = (nint)SpawnPlayerPortal.A_PortalOpen;
		Action action6 = OnPortalOpen;
		Delegate obj14 = Delegate.Remove(SpawnPlayerPortal.A_PortalOpen, action6);
		if ((object)obj14 == null)
		{
			SpawnPlayerPortal.A_PortalOpen = null;
		}
		else
		{
			bool flag10 = (object)obj14.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag10)
			{
				obj15 = obj14;
			}
			bool flag11 = (object)obj15 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj14;
			nint num3 = (nint)typeof(Action);
			if (flag11)
			{
				goto IL_0967;
			}
			SpawnPlayerPortal.A_PortalOpen = (Action)obj15;
			bool flag12 = (object)obj14.GetType() != typeof(Action);
			Delegate obj16 = null;
			if (!flag12)
			{
				obj16 = obj14;
			}
			bool flag13 = (object)obj16 == null;
			obj2 = action6;
			obj3 = 0;
			obj4 = obj14;
			nint num4 = (nint)typeof(Action);
			if (flag13)
			{
				goto IL_0977;
			}
		}
		num = (nint)SpawnPlayerPortal.A_PortalClosed;
		Action action7 = OnPortalClose;
		Delegate obj17 = Delegate.Remove(SpawnPlayerPortal.A_PortalClosed, action7);
		if ((object)obj17 == null)
		{
			SpawnPlayerPortal.A_PortalClosed = null;
		}
		else
		{
			bool flag14 = (object)obj17.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag14)
			{
				obj18 = obj17;
			}
			bool flag15 = (object)obj18 == null;
			obj2 = action7;
			obj3 = 0;
			obj4 = obj17;
			nint num5 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0987;
			}
			SpawnPlayerPortal.A_PortalClosed = (Action)obj18;
			bool flag16 = (object)obj17.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag16)
			{
				obj19 = obj17;
			}
			bool flag17 = (object)obj19 == null;
			obj2 = action7;
			obj3 = 0;
			obj4 = obj17;
			nint num6 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_0997;
			}
		}
		Action<string, object, object> value6 = OnSettingUpdated;
		Delegate obj20 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value6);
		if ((object)obj20 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action8 = default(Action<string, object, object>);
		bool flag18 = action8 == null;
		num = (nint)typeof(Action<string, object, object>);
		obj2 = obj20;
		obj3 = 0;
		obj4 = null;
		if (flag18)
		{
			goto IL_091f;
		}
		CurrentSettings.A_SettingUpdated = action8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj21 = default(object);
		bool flag19 = obj21 == null;
		num = (nint)typeof(Action<string, object, object>);
		obj2 = obj20;
		obj3 = 0;
		obj4 = null;
		if (!flag19)
		{
			return;
		}
		goto IL_092f;
		IL_077f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0747;
		IL_0747:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0737;
		IL_07d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07c7;
		IL_0967:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07d7;
		IL_07c7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07af;
		IL_091f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0997;
		IL_092f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_091f;
		IL_0737:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_072c;
		IL_078f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_077f;
		IL_0987:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0977;
		IL_072c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0977:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0967;
		IL_0997:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0987;
		IL_079f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_078f;
		IL_07af:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_079f;
	}

	private void OnPlayerInventoryInit(PlayerInventory inventory)
	{
		UpdateBars(inventory.playerHealth);
	}

	private void Start()
	{
		PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
		if (playerInventory != null)
		{
			PlayerInventory playerInventory2 = GameManager.Instance.GetPlayerInventory();
			UpdateBars(playerInventory2.playerHealth);
		}
		RefreshHud();
	}

	private unsafe void Update()
	{
		//IL_01c6: Invalid comparison between I4 and F4
		//IL_007b: Expected O, but got Ref
		//IL_01eb: Expected I, but got O
		//IL_0134: Expected F8, but got I4
		//IL_018a: Expected O, but got Ref
		if (!followPlayer)
		{
			return;
		}
		MyPlayer player = GameManager.Instance.GetPlayer();
		Transform transform = player.transform;
		Transform transform2 = PlayerCamera.Instance.transform;
		Vector3 forward = transform2.forward;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		if (0f > forward.y)
		{
			Vector3 position = transform2.position;
			Vector3 position2 = transform.position;
			float num = default(float);
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
			nint num2 = (nint)typeof(Math);
			float num3 = vector.y * vector.y;
			float num4 = vector.x * vector.x;
			float num5 = vector.z * vector.z;
			float num6 = num3 + num4;
			float num7 = num6 + num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm3\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rcx_v17 (Il2CppClass<System.Math>)+E4]");
			double num8;
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm3\"");
				num8 = 0.0;
			}
			else
			{
				num8 = Math.Sqrt(num7);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			if (!(num8 > 9.999999747378752E-06))
			{
			}
			Transform transform3 = base.transform;
			transform3.localPosition = (Vector3)(&num);
		}
	}

	private unsafe void UpdateBars(PlayerHealth ph)
	{
		//IL_002c: Expected O, but got Ref
		//IL_00e9: Invalid comparison between I4 and F4
		//IL_0278: Expected O, but got Ref
		//IL_01a1: Expected O, but got Ref
		Transform transform = healthBar.transform;
		int num = default(int);
		transform.localScale = (Vector3)(&num);
		if (t_hp != null)
		{
			TextMeshProUGUI textMeshProUGUI = t_hp;
			int combinedHp = ph.GetCombinedHp();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			int combinedMaxHp = ph.GetCombinedMaxHp();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			object arg2 = default(object);
			string text = $"{arg:N0}/{arg2:N0}";
			t_hp.text = text;
			int num2 = combinedMaxHp;
			int num3 = combinedHp;
		}
		if (0f < ph.maxShield)
		{
			Transform parent = shieldBar.parent;
			GameObject gameObject = parent.gameObject;
			if (!gameObject.activeInHierarchy)
			{
				Transform parent2 = shieldBar.parent;
				GameObject gameObject2 = parent2.gameObject;
				gameObject2.SetActive(value: true);
			}
			Transform transform2 = shieldBar.transform;
			float num4 = default(float);
			transform2.localScale = (Vector3)(&num4);
			if (t_shield != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg3 = default(object);
				object arg4 = default(object);
				string text2 = $"{arg3:N0}/{arg4:N0}";
				t_shield.text = text2;
			}
		}
		else
		{
			Transform parent3 = shieldBar.parent;
			GameObject gameObject3 = parent3.gameObject;
			gameObject3.SetActive(value: false);
		}
		Transform transform3 = overhealBar.transform;
		float num5 = default(float);
		transform3.localScale = (Vector3)(&num5);
	}

	private unsafe void UpdateHealthBar(Transform bar, float value, float max)
	{
		//IL_0020: Expected O, but got Ref
		Transform transform = bar.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
	}

	private void OnPortalOpen()
	{
		if (followPlayer)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private void OnPortalClose()
	{
		if (followPlayer)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: true);
		}
	}

	private void OnHeal(PlayerHealth ph, float amount, bool isShield)
	{
		UpdateBars(ph);
	}

	private void OnDamageTaken(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		UpdateBars(ph);
	}

	private void OnMaxValuesChanged(PlayerHealth ph)
	{
		UpdateBars(ph);
	}

	private void OnOverhealChanged(PlayerHealth ph)
	{
		UpdateBars(ph);
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
		//IL_000d: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_005e: Expected I4, but got O
		if (settingName == "hp_bar_color")
		{
			nint num = (nint)newValue;
			nint num2 = (nint)typeof(EHpBarColor);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v8 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7 (Il2CppClass<EHpBarColor>)+40]");
			if (num3 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			object obj = default(object);
			SetHealthBarColor((EHpBarColor)obj);
		}
		if (settingName == "show_hud")
		{
			RefreshHud();
		}
	}

	private void RefreshHud()
	{
		//IL_0128: Expected F4, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null && config.cfGameSettings != null && canvasGroup != null)
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config2 = saveManager2.config;
				CFGameSettings cfGameSettings = config2.cfGameSettings;
				float alpha = ((cfGameSettings.show_hud != 1) ? 0f : 1f);
				canvasGroup.alpha = alpha;
			}
		}
	}

	private unsafe void SetHealthBarColor(EHpBarColor color)
	{
		//IL_0038: Expected O, but got Ref
		Color healthBarColor = MyColorUtility.GetHealthBarColor(color);
		RawImage component = healthBar.GetComponent<RawImage>();
		object obj = default(object);
		component.color = (Color)(&obj);
	}
}
