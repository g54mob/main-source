using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
	private float healInterval = 0.5f;

	private float nextHealTime;

	private float radius;

	private float healPerInterval;

	private float defaultHealingPerInterval = 1f;

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
		Action<EItem> b = OnItemChanged;
		Delegate obj = Delegate.Combine(ItemInventory.A_ItemAdded, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = (Action<EItem>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action = default(Action<EItem>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EItem>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			ItemInventory.A_ItemAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<EItem, bool> b2 = OnItemChanged;
		Delegate obj6 = Delegate.Combine(ItemInventory.A_ItemRemoved, b2);
		if ((object)obj6 == null)
		{
			ItemInventory.A_ItemRemoved = (Action<EItem, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem, bool> action2 = default(Action<EItem, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<EItem, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		ItemInventory.A_ItemRemoved = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<EItem, bool>);
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

	private void OnDestroy()
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
		Action<EItem> value = OnItemChanged;
		Delegate obj = Delegate.Remove(ItemInventory.A_ItemAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = (Action<EItem>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action = default(Action<EItem>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EItem>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			ItemInventory.A_ItemAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<EItem, bool> value2 = OnItemChanged;
		Delegate obj6 = Delegate.Remove(ItemInventory.A_ItemRemoved, value2);
		if ((object)obj6 == null)
		{
			ItemInventory.A_ItemRemoved = (Action<EItem, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem, bool> action2 = default(Action<EItem, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<EItem, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		ItemInventory.A_ItemRemoved = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<EItem, bool>);
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

	private unsafe void Start()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0426: Expected I, but got O
		//IL_0491: Expected I, but got O
		//IL_005a: Expected O, but got Ref
		//IL_0068: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		//IL_0112: Expected O, but got Ref
		//IL_0120: Expected O, but got Ref
		//IL_03cf: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		RefreshStats();
		Transform transform = base.transform;
		Vector3 position = transform.position;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = position.x + (float)Vector3.upVector;
		float num4 = position.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num5 = num4 + 0f;
		float num6 = position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num7 = num6 + 0f;
		nint num8 = (nint)typeof(Vector3);
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = Vector3.downVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
		_ = 0;
		int layerMask = default(int);
		if (Physics.Raycast(origin, direction, out hitInfo, 2f, layerMask))
		{
			Transform transform2 = base.transform;
			Transform transform3 = base.transform;
			Vector3 up = transform3.up;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			Vector3 toDirection = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			Vector3 fromDirection = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v19+8]");
			_ = 0;
			_ = up.x;
			_ = up.z;
			Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection);
			Transform transform4 = base.transform;
			Quaternion rotation = transform4.rotation;
			float num10 = rotation.w * quaternion.x;
			float num11 = rotation.z * quaternion.y;
			float num12 = rotation.x * quaternion.w;
			float num13 = rotation.y * quaternion.w;
			float num14 = num12 + num10;
			float num15 = rotation.z * quaternion.w;
			float num16 = rotation.y * quaternion.z;
			float num17 = num14 + num11;
			float num18 = rotation.x * quaternion.z;
			float num19 = num17 - num16;
			float num20 = rotation.w * quaternion.y;
			float num21 = num13 + num20;
			float num22 = rotation.z * quaternion.x;
			float num23 = rotation.z * quaternion.z;
			float num24 = num21 + num18;
			float num25 = rotation.y * quaternion.x;
			float num26 = rotation.y * quaternion.y;
			float num27 = num24 - num22;
			float num28 = rotation.w * quaternion.z;
			float num29 = rotation.w * quaternion.w;
			float num30 = num15 + num28;
			float num31 = rotation.x * quaternion.x;
			float num32 = rotation.x * quaternion.y;
			float num33 = num29 - num31;
			float num34 = num30 + num25;
			float num35 = num33 - num26;
			float num36 = num34 - num32;
			float num37 = num35 - num23;
			Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			transform2.rotation = rotation2;
		}
	}

	private void FixedUpdate()
	{
		//IL_017d: Expected I, but got O
		//IL_00fb: Invalid comparison between F4 and I4
		if (!(nextHealTime > MyTime.time))
		{
			float num = MyTime.time + healInterval;
			nextHealTime = num;
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			nint num2 = (nint)typeof(Math);
			float num3 = position.x - position2.x;
			float num4 = position.y - position2.y;
			float num5 = position.z - position2.z;
			float num6 = num4 * num4;
			float num7 = num3 * num3;
			float num8 = num5 * num5;
			float num9 = num6 + num7;
			float num10 = num9 + num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v13 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num11 = Math.Sqrt(num10);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			if (!(radius < 0f))
			{
				MyPlayer instance = MyPlayer.Instance;
				PlayerInventory inventory = instance.inventory;
				int num12 = inventory.playerHealth.Heal(healPerInterval);
			}
		}
	}

	private void OnItemChanged(EItem item)
	{
		if (item == EItem.Beacon)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x180497DB0\"");
		}
	}

	private void OnItemChanged(EItem arg1, bool arg2)
	{
		if (arg1 == EItem.Beacon)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x180497DB0\"");
		}
	}

	private unsafe void RefreshStats()
	{
		//IL_00b7: Expected I, but got O
		//IL_00c5: Expected I, but got O
		//IL_00d5: Expected O, but got I
		//IL_0183: Expected O, but got Ref
		//IL_0111: Expected O, but got I
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int amount = inventory.itemInventory.GetAmount(EItem.Beacon);
		if (amount > 0)
		{
			radius = 5f;
			healPerInterval = 1f;
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			ItemBase item = inventory2.itemInventory.GetItem(EItem.Beacon);
			if (item != null)
			{
				nint num = (nint)item;
				nint num2 = (nint)typeof(ItemBeacon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v23 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ r8_v7 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v23 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ r8_v7 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rcx_v16+FFFFFFF8+v267 @ rcx_v15*8]");
					if (0 == (nint)typeof(ItemBeacon))
					{
						float num4 = ((ItemBeacon)item).GetRadius();
						radius = num4;
						float healingPerInterval = ((ItemBeacon)item).GetHealingPerInterval();
						healPerInterval = healingPerInterval;
					}
				}
			}
			Transform transform = base.transform;
			float num5 = default(float);
			transform.localScale = (Vector3)(&num5);
		}
		else
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private float GetRadius()
	{
		return radius;
	}

	private float GetHealAmount()
	{
		return healPerInterval;
	}
}
