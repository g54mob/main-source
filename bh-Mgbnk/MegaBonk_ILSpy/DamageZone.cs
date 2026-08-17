using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
	private WeaponBase weaponBase;

	public float cooldown = 0.25f;

	public TrailRenderer trailRenderer;

	public float defaultRadius = 1f;

	private float radius;

	private float nextCheckDamageTime;

	public unsafe void Set(WeaponBase weaponBase)
	{
		//IL_005a: Expected O, but got Ref
		this.weaponBase = weaponBase;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(this.weaponBase);
		float num = attackSizeMultiplier * defaultRadius;
		radius = num;
		Transform transform = base.transform;
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
		if (trailRenderer != null)
		{
			trailRenderer.startWidth = attackSizeMultiplier;
		}
	}

	private unsafe void UpdateSize()
	{
		//IL_0050: Expected O, but got Ref
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num = attackSizeMultiplier * defaultRadius;
		radius = num;
		Transform transform = base.transform;
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
		if (trailRenderer != null)
		{
			trailRenderer.startWidth = attackSizeMultiplier;
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0047: Expected O, but got Ref
		//IL_02e1: Expected O, but got I
		//IL_00b1: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_013a: Expected O, but got Ref
		//IL_016e: Expected O, but got Ref
		//IL_016e: Expected O, but got I
		//IL_018c: Expected O, but got I
		//IL_02f6: Expected O, but got I
		//IL_01d5: Expected O, but got Ref
		//IL_01d5: Expected O, but got I
		//IL_01f1: Expected O, but got I
		//IL_0215: Expected O, but got Ref
		//IL_0245: Expected I4, but got F4
		//IL_0245: Expected O, but got Ref
		//IL_025b: Expected F4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + cooldown;
		nextCheckDamageTime = num;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), radius, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112)));
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		num2 = position.x;
		EWeapon eWeapon = EWeapon.FireStaff;
		float num4 = default(float);
		float num5 = default(float);
		float x = default(float);
		float num6 = default(float);
		GameObject weaponHitEffect = default(GameObject);
		bool useSfx = default(bool);
		object obj7 = default(object);
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
			object obj3 = 0;
			ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			EnemyManager instance = EnemyManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ r10_v6+20+v411 @ rbx_v8 (EWeapon)*8]");
			if (instance.GetEnemy((Collider)0, out enemy))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
				Transform transform2 = ((Component)0).transform;
				Vector3 position2 = transform2.position;
				Transform transform3 = base.transform;
				Vector3 position3 = transform3.position;
				float num3 = position2.x - position3.x;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				WeaponBase obj5 = weaponBase;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj5, null, (Enemy)0, (Vector3)(&num4), num5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
				((Enemy)0).DamageFromPlayerWeapon(damageContainer);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
				object obj6 = 0;
				Transform transform4 = base.transform;
				Vector3 position4 = transform4.position;
				num = position4.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rcx_v26+20+v411 @ rbx_v8 (EWeapon)*8]");
				Vector3 vector = ((Collider)0).ClosestPoint((Vector3)(&x));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
				bool hitEnemy = (Object)0;
				Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v26+8]");
				_ = 0;
				EffectManager.Instance.EnemyHitEffect((Vector3)(&num6), moveDir, hitEnemy, (EWeapon)num5, weaponHitEffect, useSfx);
				x = position4.x;
				num4 = (float)obj7;
				num2 = num3;
			}
			eWeapon++;
		}
		while ((int)eWeapon < enemiesInRadiusSafe);
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_002b: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		Gizmos.DrawWireSphere((Vector3)(&obj), defaultRadius);
	}
}
