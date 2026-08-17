using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

public class DetectPickups : MonoBehaviour
{
	public SphereCollider collider;

	private void Start()
	{
		//IL_01fc: Expected I, but got O
		//IL_020d: Expected O, but got I4
		//IL_0216: Expected O, but got I4
		//IL_008d: Expected I, but got O
		//IL_009e: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_0254: Expected I, but got O
		//IL_0265: Expected O, but got I4
		//IL_026e: Expected O, but got I4
		//IL_00e5: Expected I, but got O
		//IL_00f6: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			if (playerInventory == null)
			{
				Action<PlayerInventory> b = OnInventoryInit;
				Delegate obj = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b);
				if ((object)obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<PlayerInventory> action = default(Action<PlayerInventory>);
					bool flag = action == null;
					num = (nint)typeof(Action<PlayerInventory>);
					obj2 = obj;
					obj3 = 0;
					obj4 = 0;
					if (!flag)
					{
						MyPlayer.A_PlayerInventoryInitialized = action;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						object obj5 = default(object);
						bool flag2 = obj5 == null;
						num = (nint)typeof(Action<PlayerInventory>);
						SphereCollider sphereCollider = (SphereCollider)(object)obj;
						obj3 = 0;
						obj4 = 0;
						if (!flag2)
						{
							goto IL_017f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						obj2 = (Delegate)(object)sphereCollider;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					goto IL_0302;
				}
				MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj;
			}
			else if (PlayerStats.HasStats())
			{
				SphereCollider sphereCollider = collider;
				float stat = PlayerStats.GetStat(EStat.PickupRange);
				if ((object)collider == null)
				{
					goto IL_027d;
				}
				collider.radius = stat;
			}
			goto IL_017f;
		}
		goto IL_027d;
		IL_0302:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02f7;
		IL_017f:
		Action<EStat> b2 = OnStatUpdated;
		Delegate obj6 = Delegate.Combine(PlayerStatsNew.A_StatUpdate, b2);
		if ((object)obj6 == null)
		{
			PlayerStatsNew.A_StatUpdate = (Action<EStat>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat> action2 = default(Action<EStat>);
		bool flag3 = action2 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag3)
		{
			goto IL_02f7;
		}
		PlayerStatsNew.A_StatUpdate = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag4 = obj7 == null;
		num = (nint)typeof(Action<EStat>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag4)
		{
			return;
		}
		goto IL_0302;
		IL_02f7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_027d:
		throw new NullReferenceException();
	}

	private void OnInventoryInit(PlayerInventory obj)
	{
		if (PlayerStats.HasStats())
		{
			float stat = PlayerStats.GetStat(EStat.PickupRange);
			collider.radius = stat;
		}
	}

	private void OnDestroy()
	{
		//IL_01a6: Expected I, but got O
		//IL_01b7: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<EStat> value = OnStatUpdated;
		Delegate obj = Delegate.Remove(PlayerStatsNew.A_StatUpdate, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = (Action<EStat>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action = default(Action<EStat>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStat>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			PlayerStatsNew.A_StatUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStat>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ed;
			}
		}
		Action<PlayerInventory> value2 = OnInventoryInit;
		Delegate obj6 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value2);
		if ((object)obj6 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action2 = default(Action<PlayerInventory>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		MyPlayer.A_PlayerInventoryInitialized = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_01ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ed;
	}

	private void OnStatUpdated(EStat stat)
	{
		if (stat == EStat.PickupRange && PlayerStats.HasStats())
		{
			float stat2 = PlayerStats.GetStat(EStat.PickupRange);
			collider.radius = stat2;
		}
	}

	private void UpdateRadius()
	{
		if (PlayerStats.HasStats())
		{
			float stat = PlayerStats.GetStat(EStat.PickupRange);
			collider.radius = stat;
		}
	}
}
