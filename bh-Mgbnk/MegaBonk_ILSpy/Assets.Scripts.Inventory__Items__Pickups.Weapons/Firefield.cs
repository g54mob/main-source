using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Managers;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class Firefield : MonoBehaviour
{
	private float collisionCooldown = 0.4f;

	private float spawnTime;

	private float aliveTime;

	private float spawnRadius;

	private Vector3 normal;

	private WeaponBase weaponBase;

	private float damage;

	private string damageSource;

	private DamageContainer recycledDx;

	private float nextCheckDamageTime;

	private static Dictionary<Collider, int> numTimesEnemiesHitThisTick;

	private static bool hasDamage;

	private static float damageThisTick;

	private float visualRadius;

	private float desiredVisualRadius;

	public unsafe void Set(Vector3 pos, Vector3 fallbackPos, float radius, float duration, float damage, WeaponBase weaponBase, string damageSource)
	{
		//IL_0008: Expected O, but got Ref
		//IL_02f0: Expected O, but got I
		//IL_030e: Expected O, but got I
		//IL_0329: Invalid comparison between F4 and I
		//IL_005e: Expected O, but got Ref
		//IL_001e: Invalid comparison between I and F4
		//IL_004b: Expected F4, but got I
		//IL_00a4: Expected O, but got Ref
		//IL_0191: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_0379: Expected I, but got O
		//IL_03c3: Expected O, but got I
		//IL_03e0: Expected O, but got I
		//IL_040c: Invalid comparison between F4 and O
		//IL_02d9: Expected O, but got Ref
		//IL_0432: Expected F4, but got I
		//IL_0295: Expected O, but got Ref
		//IL_0295: Expected O, but got Ref
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_0206: Expected O, but got I
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_02ab: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
		this.damageSource = (string)0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
		this.weaponBase = (WeaponBase)0;
		spawnRadius = radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
		bool flag = 1f > 0f;
		float num = 1f;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
			bool flag2 = 0f > 3.4028235E+38f;
			num = 3.4028235E+38f;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
				num = 0f;
			}
		}
		this.damage = num;
		Transform transform = base.transform;
		float num2 = default(float);
		transform.position = (Vector3)(&num2);
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num3 = default(float);
		int layerMask = default(int);
		if (!Physics.Raycast((Ray)(&num3), out var _, 9999f, layerMask))
		{
			Transform transform3 = base.transform;
			transform3.position = (Vector3)(&num2);
			float num4 = default(float);
			num3 = num4;
		}
		else
		{
			Transform transform4 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			object obj3 = default(object);
			float num5 = (float)obj3 * 0.05f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v35+4]");
			float num6 = 0f * 0.05f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v35+8]");
			float num7 = 0f * 0.05f;
			object obj4 = default(object);
			float num8 = num5 + (float)obj4;
			float num9 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v34+4]");
			float num10 = num9 + 0f;
			float num11 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v34+8]");
			float num12 = num11 + 0f;
			Vector3 vector = default(Vector3);
			transform4.position = (Vector3)(&vector);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj5 = default(object);
			normal = (Vector3)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ rax_v39+8]");
			_ = 0;
			nint num13 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v41 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			object obj7 = default(object);
			object obj6 = obj7 * obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+4]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+4]");
			object obj8 = num15 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+8]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+8]");
			object obj9 = num16 * 0;
			object obj10 = obj8 + obj6;
			float epsilon = Mathf.Epsilon;
			object obj11 = obj10 + obj9;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+4]");
				object obj13 = default(object);
				object obj12 = obj13 * 0;
				object obj14 = (object)Vector3.forwardVector * obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rcx_v36 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+8]");
				object obj15 = num17 * 0;
				object obj16 = obj12 + obj14;
				object obj17 = obj16 + obj15;
				object obj18 = obj17 * obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+4]");
				object obj19 = obj17 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v42+8]");
				object obj20 = obj17 * 0;
				epsilon = (float)obj18 / (float)obj11;
				obj9 = obj19 / obj11;
				num10 = (float)obj20 / (float)obj11;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Transform transform5 = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			Vector3 vector2 = default(Vector3);
			Vector3 vector3 = default(Vector3);
			Quaternion quaternion = Quaternion.LookRotation((Vector3)(&vector2), (Vector3)(&vector3));
			transform5.rotation = (Quaternion)(&num3);
			num3 = quaternion.x;
		}
		Transform transform6 = base.transform;
		transform6.localScale = (Vector3)(&num3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		aliveTime = 0f;
		spawnTime = MyTime.time;
	}

	protected void FixedUpdate()
	{
		if ((nint)weaponBase <= 0)
		{
			float num = aliveTime + spawnTime;
			if (MyTime.time > num)
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
				PoolManager instance = PoolManager.Instance;
				ObjectPool<GameObject> firefieldPool = instance.firefieldPool;
				GameObject gameObject2 = base.gameObject;
				Action<GameObject> actionOnRelease = firefieldPool.m_ActionOnRelease;
				if (firefieldPool.m_ActionOnRelease != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v325 @ rax_v17 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				if ((object)firefieldPool.m_FreshlyReleased != null)
				{
					int countInactive = firefieldPool.CountInactive;
					if (countInactive >= firefieldPool.m_MaxSize)
					{
						int num2 = firefieldPool._003CCountAll_003Ek__BackingField - 1;
						firefieldPool._003CCountAll_003Ek__BackingField = num2;
						Action<GameObject> actionOnDestroy = firefieldPool.m_ActionOnDestroy;
						if (firefieldPool.m_ActionOnDestroy != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rax_v28 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
						}
					}
					else
					{
						List<object> list = (List<object>)(object)firefieldPool.m_List;
						object[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						if (list._size >= items.Length)
						{
							list.AddWithResize((object)gameObject2);
						}
						else
						{
							int size = list._size + 1;
							list._size = size;
							int num3 = default(int);
							items[num3] = gameObject2;
						}
					}
				}
				else
				{
					firefieldPool.m_FreshlyReleased = gameObject2;
				}
			}
		}
		CheckDamage();
	}

	private bool IsWeaponAttack()
	{
		bool flag = (nint)weaponBase < 0;
		bool flag2 = weaponBase == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private void LateUpdate()
	{
		//IL_001f: Invalid comparison between F4 and I4
		TryPopDamage();
		if (damageThisTick > 0f)
		{
			damageThisTick = 0f;
		}
	}

	private unsafe void CheckDamage()
	{
		//IL_003e: Expected O, but got Ref
		//IL_005d: Expected O, but got I4
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + collisionCooldown;
		nextCheckDamageTime = num;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float hitboxRadius = GetHitboxRadius();
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), hitboxRadius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = 0;
		if (flag)
		{
			return;
		}
		do
		{
			if (!numTimesEnemiesHitThisTick.ContainsKey(buffer[obj]))
			{
				((Dictionary<object, int>)(object)numTimesEnemiesHitThisTick).Add((object)buffer[obj], 0);
			}
			int num3 = numTimesEnemiesHitThisTick.get_Item(buffer[obj]);
			int value = num3 + 1;
			((Dictionary<object, int>)(object)numTimesEnemiesHitThisTick).set_Item((object)buffer[obj], value);
			obj++;
			hasDamage = true;
		}
		while ((nint)obj < enemiesInRadiusSafe);
	}

	private unsafe void TryPopDamage()
	{
		//IL_0055: Expected O, but got Ref
		//IL_0075: Expected O, but got F4
		//IL_01c4: Expected O, but got Ref
		//IL_03b1: Expected O, but got Ref
		//IL_043d: Expected I, but got O
		//IL_06a6: Expected O, but got I
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_04b9: Expected I4, but got F4
		//IL_04b9: Expected O, but got Ref
		//IL_04b9: Expected O, but got Ref
		//IL_038f: Expected I, but got O
		if (!hasDamage)
		{
			return;
		}
		hasDamage = false;
		if (numTimesEnemiesHitThisTick != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			Dictionary<Collider, int>.Enumerator enumerator = default(Dictionary<Collider, int>.Enumerator);
			float num = default(float);
			float num2 = default(float);
			object obj = default(object);
			float x = default(float);
			float num6 = default(float);
			float num8 = default(float);
			float num9 = default(float);
			GameObject weaponHitEffect = default(GameObject);
			bool useSfx = default(bool);
			while (enumerator.MoveNext())
			{
				Dictionary<Collider, int>.Enumerator enumerator2 = (Dictionary<Collider, int>.Enumerator)(&enumerator);
				EnemyManager instance = EnemyManager.Instance;
				if ((object)EnemyManager.Instance == null)
				{
					throw new NullReferenceException();
				}
				if (instance.collidersToEnemies != null)
				{
					bool flag = ((Dictionary<object, object>)(object)instance.collidersToEnemies).TryGetValue((object)num, out object value);
					if (!flag)
					{
						MyLogger.LogErrorInBuild("AAH COLLIDER TO ENEMY FAILED? WTF?");
					}
					if ((UnityEngine.Object)value != null)
					{
						bool flag2 = value == null;
						Enemy enemy = (Enemy)value;
						if (flag2)
						{
							throw new NullReferenceException();
						}
						if (((Enemy)value).IsDeadOrDyingNextFrame())
						{
							continue;
						}
					}
					if (!flag)
					{
						continue;
					}
					if (value != null)
					{
						Transform transform = ((Component)value).transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							if ((object)MyPlayer.Instance != null)
							{
								Transform transform2 = MyPlayer.Instance.transform;
								bool flag3 = (object)transform2 == null;
								Enemy enemy = (Enemy)(object)MyPlayer.Instance;
								if (!flag3)
								{
									Vector3 position2 = transform2.position;
									Vector3 vector = VectorExtensions.XZVector((Vector3)(&num2));
									float num4;
									nint num5;
									if (weaponBase == null)
									{
										bool flag4 = recycledDx == null;
										enemy = (Enemy)(object)recycledDx;
										if (flag4)
										{
											throw new NullReferenceException();
										}
										recycledDx.Reuse(0f, damageSource);
										enemy = (Enemy)(object)recycledDx;
										if (recycledDx == null)
										{
											throw new NullReferenceException();
										}
										_ = damage;
										DamageContainer damageContainer = recycledDx;
										if (recycledDx == null)
										{
											throw new NullReferenceException();
										}
										damageContainer.element = EElement.Fire;
										enemy = (Enemy)(object)recycledDx;
										if (recycledDx == null)
										{
											throw new NullReferenceException();
										}
										enemy.animatedMesh = (AnimatedMesh)value;
										enemy = (Enemy)(enemy + 40);
										DamageContainer damageContainer2 = recycledDx;
										if (recycledDx == null)
										{
											throw new NullReferenceException();
										}
										float num3 = (float)obj * damageContainer2.damage;
										damageContainer2.damage = num3;
										bool flag5 = value == null;
										enemy = (Enemy)value;
										if (flag5)
										{
											throw new NullReferenceException();
										}
										((Enemy)value).DamageFromPlayerWeapon(recycledDx);
										enemy = (Enemy)(object)typeof(Firefield);
										DamageContainer damageContainer3 = recycledDx;
										if (recycledDx == null)
										{
											throw new NullReferenceException();
										}
										num4 = damageThisTick + damageContainer3.damage;
										num5 = (nint)typeof(Firefield);
									}
									else
									{
										DamageContainer damageContainer4 = WeaponUtility.GetDamageContainer(weaponBase, null, (Enemy)value, (Vector3)(&x), num6);
										bool flag6 = damageContainer4 == null;
										enemy = (Enemy)(object)weaponBase;
										if (flag6)
										{
											throw new NullReferenceException();
										}
										float num7 = (float)obj * damageContainer4.damage;
										damageContainer4.damage = num7;
										bool flag7 = value == null;
										enemy = (Enemy)value;
										if (flag7)
										{
											throw new NullReferenceException();
										}
										((Enemy)value).DamageFromPlayerWeapon(damageContainer4);
										num5 = (nint)typeof(Firefield);
										num4 = damageThisTick + damageContainer4.damage;
										x = vector.x;
									}
									damageThisTick = num4;
									enemy = (Enemy)num5;
									if (value != null)
									{
										Vector3 centerPosition = ((Enemy)value).GetCenterPosition();
										Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
										bool hitEnemy = (UnityEngine.Object)value;
										bool flag8 = (object)EffectManager.Instance == null;
										enemy = (Enemy)value;
										if (!flag8)
										{
											EffectManager.Instance.EnemyHitEffect((Vector3)(&num8), (Vector3)(&num9), hitEnemy, (EWeapon)num6, weaponHitEffect, useSfx);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			if (numTimesEnemiesHitThisTick != null)
			{
				numTimesEnemiesHitThisTick.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private float GetEffectiveRadius()
	{
		float num = MyTime.time - spawnTime;
		float num2 = num / aliveTime;
		float num3 = 1f - num2;
		return num3 * spawnRadius;
	}

	private float GetHitboxRadius()
	{
		float num = MyTime.time - spawnTime;
		float num2 = num / aliveTime;
		float num3 = 1f - num2;
		float num4 = num3 * spawnRadius;
		return num4 + 0.5f;
	}

	protected unsafe void Update()
	{
		//IL_00b5: Invalid comparison between I4 and F4
		//IL_0076: Expected F4, but got I4
		//IL_0088: Expected O, but got Ref
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 18f;
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
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_00cd: Expected O, but got Ref
		//IL_00d7: Expected O, but got Ref
		//IL_0068: Expected O, but got Ref
		//IL_0072: Expected O, but got Ref
		//IL_00af: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float effectiveRadius = GetEffectiveRadius();
		Vector3 vector = default(Vector3);
		Gizmos.DrawWireSphere((Vector3)(&vector), effectiveRadius);
		Gizmos.color = (Color)(&vector);
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		float effectiveRadius2 = GetEffectiveRadius();
		Gizmos.DrawWireSphere((Vector3)(&vector), effectiveRadius2);
		Gizmos.color = (Color)(&vector);
		Transform transform3 = base.transform;
		Vector3 position3 = transform3.position;
		float hitboxRadius = GetHitboxRadius();
		Gizmos.DrawWireSphere((Vector3)(&vector), hitboxRadius);
	}

	public Firefield()
	{
		DamageContainer damageContainer = new DamageContainer(0f, "");
		recycledDx = damageContainer;
		base._002Ector();
	}

	static Firefield()
	{
		Dictionary<Collider, int> dictionary = new Dictionary<Collider, int>();
		numTimesEnemiesHitThisTick = dictionary;
	}
}
