using System;
using System.Collections.Generic;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

public class CoolGhostsAttack : ConstantAttack
{
	public GameObject projectilePrefab;

	private List<GameObject> projectiles;

	private int maxProjectiles = 50;

	private List<float> angles;

	private float radius;

	protected override void Init()
	{
		RefreshProjectiles();
	}

	private void RefreshProjectiles()
	{
		if (projectiles == null)
		{
			List<GameObject> list = new List<GameObject>();
			projectiles = list;
		}
		int attackQuantity = WeaponUtility.GetAttackQuantity(weaponBase);
		int num;
		if (attackQuantity >= 1)
		{
			bool flag = attackQuantity <= maxProjectiles;
			num = attackQuantity;
			if (!flag)
			{
				num = maxProjectiles;
			}
		}
		else
		{
			num = 1;
		}
		List<GameObject> list2 = projectiles;
		int num2 = list2._size;
		if (list2._size <= num)
		{
			if (list2._size >= num)
			{
				return;
			}
			int num3 = default(int);
			do
			{
				Transform transform = projectilePrefab.transform;
				Transform parent = transform.parent;
				GameObject gameObject = UnityEngine.Object.Instantiate(projectilePrefab, parent);
				List<object> list3 = (List<object>)(object)projectiles;
				int version = list3._version + 1;
				list3._version = version;
				object[] items = list3._items;
				if (list3._size >= items.Length)
				{
					list3.AddWithResize((object)gameObject);
				}
				else
				{
					int size = list3._size + 1;
					list3._size = size;
					items[num3] = gameObject;
				}
				num2++;
			}
			while (num2 < num);
		}
		else
		{
			do
			{
				GameObject obj = projectiles.get_Item(num2);
				UnityEngine.Object.Destroy(obj);
				num2++;
			}
			while (num2 > num);
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_00ba: Expected O, but got Ref
		//IL_01a1: Expected O, but got Ref
		//IL_01a1: Expected O, but got Ref
		//IL_0121: Expected O, but got Ref
		//IL_0142: Expected O, but got I4
		if (projectiles == null)
		{
			return;
		}
		List<GameObject> list = projectiles;
		if (list._size <= 0)
		{
			return;
		}
		EnsureAngles(list._size);
		List<GameObject> list2 = projectiles;
		int num = 0;
		object obj = default(object);
		float x = default(float);
		Vector3 forwardVector = default(Vector3);
		float num4 = default(float);
		for (int num2 = 0; num2 < list2._size; num2 = num)
		{
			GameObject gameObject = projectiles.get_Item(num);
			if (gameObject != null)
			{
				float num3 = angles.get_Item(num);
				Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj));
				Vector3 vector = (Quaternion)(&x) * (Vector3)(&forwardVector);
				GameObject gameObject2 = projectiles.get_Item(num);
				Transform transform = gameObject2.transform;
				Transform transform2 = base.transform;
				Vector3 position = transform2.position;
				transform.position = (Vector3)(&num4);
				forwardVector = Vector3.forwardVector;
				x = quaternion.x;
				obj = 0;
			}
			list2 = projectiles;
			num++;
		}
	}

	private void EnsureAngles(int count)
	{
		//IL_00dd: Expected I4, but got I8
		//IL_0203: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		List<float> list = angles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)count <= (nint)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)0 == 0)
		{
			if (count >= 1)
			{
				list.Add(0f);
			}
			if (count >= 2)
			{
				angles.Add(180f);
			}
		}
		List<float> list2 = angles;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)0 >= (nint)count)
			{
				break;
			}
			angles.Sort();
			int num = -1;
			float num2 = -1f;
			int num3 = 0;
			List<float> list3;
			while (true)
			{
				list3 = angles;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				float num5 = list3.get_Item(num3);
				List<float> list4 = angles;
				object obj = num3 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
				float num6;
				if ((nint)obj < 0)
				{
					int index = num3 + 1;
					num6 = list4.get_Item(index);
				}
				else
				{
					float num7 = list4.get_Item(0);
					num6 = num7 + 360f;
				}
				float num8 = num6 - num5;
				bool flag = !(num8 > num2);
				float num9 = num2;
				if (!flag)
				{
					num9 = num8;
				}
				bool flag2 = num8 > num2;
				int num10 = num3;
				if (!flag2)
				{
					num10 = num;
				}
				num3++;
				num = num10;
				num2 = num9;
			}
			float num11 = list3.get_Item(num);
			List<float> list5 = angles;
			object obj2 = num + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			float num12;
			if ((nint)obj2 < 0)
			{
				int index2 = num + 1;
				num12 = list5.get_Item(index2);
			}
			else
			{
				float num13 = list5.get_Item(0);
				num12 = num13 + 360f;
			}
			float num14 = num12 - num11;
			float num15 = num14 * 0.5f;
			float t = num15 + num11;
			float item = Mathf.Repeat(t, 360f);
			angles.Add(item);
			angles.Sort();
			list2 = angles;
		}
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		if (weapon == weaponData.eWeapon && stat == EStat.Projectiles)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 51 Invalid \"Jump target not found in method: 0x180354690\"");
		}
	}

	protected override void OnStatUpdate(EStat stat)
	{
		if (stat == EStat.Projectiles)
		{
			RefreshProjectiles();
		}
	}

	public override float GetAuraRotationSpeed()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public GameObject GetNewProjectile()
	{
		if ((object)projectilePrefab != null)
		{
			Transform transform = projectilePrefab.transform;
			if ((object)transform != null)
			{
				Transform parent = transform.parent;
				return UnityEngine.Object.Instantiate(projectilePrefab, parent);
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public void RemoveProjectile(GameObject projectile)
	{
		UnityEngine.Object.Destroy(projectile);
	}

	public CoolGhostsAttack()
	{
		List<float> list = new List<float>();
		angles = list;
		radius = 5f;
		base._002Ector();
	}
}
