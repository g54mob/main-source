using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileExploding : ProjectileBasic
{
	public float explosionRadius = 5f;

	private float fxCooldown = 0.06f;

	public GameObject explosionEffect;

	private bool exploded;

	protected override bool TryInit(int projectileIndex)
	{
		//IL_0419: Expected I4, but got O
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_0460: Expected I, but got O
		//IL_04a1: Expected O, but got I
		//IL_04be: Expected O, but got I
		//IL_0508: Invalid comparison between F4 and O
		//IL_0527: Invalid comparison between F4 and I4
		//IL_0550: Expected O, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		currentTarget = null;
		exploded = false;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
			WeaponBase weaponBase = base.weaponBase;
			if (base.weaponBase != null)
			{
				WeaponData weaponData = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null)
				{
					object obj = default(object);
					Vector3 position2 = (Vector3)(obj - 80);
					_ = position.x;
					_ = position.z;
					GameObject exceptObject = default(GameObject);
					Enemy enemy = EnemyTargeting.GetEnemy(position2, weaponRange, projectileIndex, weaponData.useVision, exceptObject);
					if (!(enemy != null))
					{
						return false;
					}
					if ((object)enemy != null)
					{
						Vector3 centerPosition = enemy.GetCenterPosition();
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							Vector3 position3 = transform2.position;
							float num = centerPosition.x - position3.x;
							float num2 = centerPosition.y - position3.y;
							float num3 = centerPosition.z - position3.z;
							object obj2 = obj - 80;
							object obj3 = obj - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
							object obj4 = default(object);
							direction = (Vector3)obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v19+8]");
							_ = 0;
							nint num4 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num5 = 0;
							_ = Vector3.zeroVector;
							object obj5 = obj4 - (object)Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-4C]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-3C]");
							object obj6 = num6 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v19+8]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v18 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							object obj7 = num7 - 0;
							object obj8 = obj6 * obj6;
							object obj9 = obj5 * obj5;
							object obj10 = obj7 * obj7;
							object obj11 = obj8 + obj9;
							object obj12 = obj11 + obj10;
							bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12);
							float num8 = 9.9999994E-11f - (float)obj12;
							bool flag2 = num8 == 0f;
							bool flag3 = !flag;
							bool flag4 = !flag2;
							object obj13 = flag4 & flag3;
							if (obj13 == null)
							{
								Transform transform3 = base.transform;
								Vector3 forward = (Vector3)(obj - 80);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileExploding)+40]");
								_ = 0;
								_ = direction;
								Quaternion quaternion = Quaternion.LookRotation(forward);
								if ((object)transform3 == null)
								{
									goto IL_040b;
								}
								Quaternion rotation = (Quaternion)(obj - 64);
								_ = quaternion.x;
								transform3.rotation = rotation;
							}
							Transform transform4 = base.transform;
							if ((object)transform4 != null)
							{
								Vector3 position4 = transform4.position;
								Transform transform5 = base.transform;
								if ((object)transform5 != null)
								{
									Vector3 forward2 = transform5.forward;
									WeaponBase weaponBase2 = base.weaponBase;
									if (base.weaponBase != null)
									{
										WeaponData weaponData2 = weaponBase2.weaponData;
										if ((object)weaponBase2.weaponData != null)
										{
											Vector3 position5 = (Vector3)(obj - 80);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v25 (WeaponData)+C8]");
											object obj14 = 0 * forward2.x;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v25 (WeaponData)+C8]");
											object obj15 = 0 * forward2.y;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v25 (WeaponData)+C8]");
											object obj16 = 0 * forward2.z;
											float num9 = (float)obj14 + position4.x;
											float num10 = (float)obj15 + position4.y;
											float num11 = (float)obj16 + position4.z;
											transform4.position = position5;
											return true;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_040b;
		IL_040b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected unsafe override bool CheckCollision(Collider collider, Vector3 normal)
	{
		//IL_03d6: Expected I4, but got O
		//IL_03a7: Expected O, but got Ref
		if ((object)collider != null)
		{
			GameObject gameObject = collider.gameObject;
			if ((object)gameObject != null)
			{
				int layer = gameObject.layer;
				GameManager instance = GameManager.Instance;
				if ((object)GameManager.Instance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,esi\"");
					if ((nint)GameManager.Instance >= 0 || exploded)
					{
						return false;
					}
					exploded = true;
					Hitscan(collider);
					ProjectileDone();
					WeaponBase weaponBase = base.weaponBase;
					if (base.weaponBase != null)
					{
						WeaponData weaponData = weaponBase.weaponData;
						if ((object)weaponBase.weaponData != null && FxUtility.weaponCooldowns != null)
						{
							if (FxUtility.weaponCooldowns.ContainsKey(weaponData.eWeapon))
							{
								goto IL_04bf;
							}
							WeaponBase weaponBase2 = base.weaponBase;
							if (base.weaponBase != null)
							{
								WeaponData weaponData2 = weaponBase2.weaponData;
								if ((object)weaponBase2.weaponData != null && FxUtility.weaponCooldowns != null)
								{
									((Dictionary<System.Int32Enum, float>)(object)FxUtility.weaponCooldowns).Add((System.Int32Enum)weaponData2.eWeapon, 0f);
									goto IL_04bf;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03c8;
		IL_04bf:
		WeaponBase weaponBase3 = base.weaponBase;
		if (base.weaponBase != null)
		{
			WeaponData weaponData3 = weaponBase3.weaponData;
			if ((object)weaponBase3.weaponData != null && FxUtility.weaponCooldowns != null)
			{
				float num = ((Dictionary<System.Int32Enum, float>)(object)FxUtility.weaponCooldowns).get_Item((System.Int32Enum)weaponData3.eWeapon);
				if (!(MyTime.time > num))
				{
					goto IL_03ac;
				}
				WeaponBase weaponBase4 = base.weaponBase;
				if (base.weaponBase != null)
				{
					WeaponData weaponData4 = weaponBase4.weaponData;
					if ((object)weaponBase4.weaponData != null && FxUtility.weaponCooldowns != null)
					{
						float value = MyTime.time + fxCooldown;
						((Dictionary<System.Int32Enum, float>)(object)FxUtility.weaponCooldowns).set_Item((System.Int32Enum)weaponData4.eWeapon, value);
						WeaponBase weaponBase5 = base.weaponBase;
						if (base.weaponBase != null)
						{
							WeaponData weaponData5 = weaponBase5.weaponData;
							if ((object)weaponBase5.weaponData != null && (object)PoolManager.Instance != null)
							{
								GameObject projectileDoneFx = PoolManager.Instance.GetProjectileDoneFx(weaponData5.eWeapon, explosionEffect);
								if ((object)projectileDoneFx != null)
								{
									Transform transform = projectileDoneFx.transform;
									Transform transform2 = base.transform;
									if ((object)transform2 != null)
									{
										Vector3 position = transform2.position;
										if ((object)transform != null)
										{
											object obj = default(object);
											transform.position = (Vector3)(&obj);
											goto IL_03ac;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_03c8;
		IL_03ac:
		return true;
		IL_03c8:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Hitscan(Collider collider)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0130: Expected O, but got Ref
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_0259: Expected O, but got I
		//IL_02ab: Expected O, but got Ref
		//IL_0214: Expected O, but got I
		//IL_02e0: Expected O, but got Ref
		//IL_02e0: Expected O, but got I
		//IL_0324: Expected O, but got I
		//IL_035c: Expected O, but got Ref
		//IL_0373: Expected O, but got Ref
		//IL_03b8: Expected I4, but got F4
		//IL_03b8: Expected O, but got Ref
		//IL_03d3: Expected F4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		bool flag = collider != null;
		bool flag2 = !flag;
		UnityEngine.Object obj3 = null;
		if (!flag2)
		{
			GameObject gameObject = collider.gameObject;
			int layer = gameObject.layer;
			int num = LayerMask.NameToLayer("Enemy");
			bool flag3 = layer != num;
			obj3 = null;
			if (!flag3)
			{
				bool enemy = EnemyManager.Instance.GetEnemy(collider, out var enemy2);
				bool flag4 = !enemy;
				obj3 = null;
				if (!flag4)
				{
					obj3 = enemy2;
				}
			}
		}
		Transform transform = base.transform;
		float num2 = attackSizeMultiplier * explosionRadius;
		_ = 1;
		Vector3 position = transform.position;
		float num3 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num3), num2, out var buffer);
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		num3 = position.x;
		float num4 = num2;
		UnityEngine.Object obj4 = null;
		float num7 = default(float);
		float num8 = default(float);
		float x = default(float);
		float num9 = default(float);
		object obj8 = default(object);
		UnityEngine.Object obj9;
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[(object)obj4], out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168))))
			{
				bool flag5 = obj3 != null;
				bool flag6 = !flag5;
				float num5 = 1f;
				if (!flag6)
				{
					UnityEngine.Object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+A8]");
					bool flag7 = obj5 != (UnityEngine.Object)0;
					bool flag8 = !flag7;
					num5 = 1f;
					if (!flag8)
					{
						num5 = 0.75f;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+A8]");
				Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position2 = transform2.position;
				float num6 = centerPosition.x - position2.x;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				WeaponBase obj7 = weaponBase;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+A8]");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj7, null, (Enemy)0, (Vector3)(&num7), num8);
				num4 = num5 * damageContainer.damage;
				damageContainer.damage = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+A8]");
				((Enemy)0).DamageFromPlayerWeapon(damageContainer);
				Transform transform3 = base.transform;
				Vector3 position3 = transform3.position;
				Vector3 vector = buffer[(object)obj4].ClosestPoint((Vector3)(&x));
				Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rax_v32 (Assets.Scripts.Actors.DamageContainer)+10]");
				_ = 0;
				attackSizeMultiplier = vector.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rax_v32 (Assets.Scripts.Actors.DamageContainer)+18]");
				_ = 0;
				weaponAttack.ProjectileHit((Vector3)(&num9), moveDir, hitEnemy: true, (byte)(int)num8 != 0);
				_ = 0;
				x = position3.x;
				num7 = (float)obj8;
				num3 = num6;
			}
			obj4 = (UnityEngine.Object)(obj4 + 1);
			obj9 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+98]");
		}
		while ((nint)obj9 < 0);
	}
}
