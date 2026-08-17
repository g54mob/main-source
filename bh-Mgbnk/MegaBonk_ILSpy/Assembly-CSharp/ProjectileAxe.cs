using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ProjectileAxe : ProjectileBase
{
	public float collisionCooldown = 0.25f;

	public TrailRenderer trailRenderer;

	private float forwardOffset;

	private float upOffset;

	public RandomSfx sfx;

	public GameObject sfxLoop;

	private Vector3 pushDir;

	private static readonly RaycastHit[] _raycastHitBuffer;

	private Vector3 desiredPosition;

	private Vector3 startPosition;

	private float moveTime = 0.3f;

	private float nextCheckDamageTime;

	private static Dictionary<Collider, int> numTimesEnemiesHitThisTick;

	private static bool hasDamage;

	private static float damageThisTick;

	private float moveTimer;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00fc: Expected O, but got I4
		//IL_055b: Expected O, but got Ref
		//IL_0605: Expected I, but got O
		//IL_0613: Expected O, but got Ref
		//IL_062b: Expected O, but got Ref
		//IL_0118: Expected O, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_058c: Expected O, but got I4
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Expected I4, but got Unknown
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_0159: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		//IL_0213: Expected O, but got Ref
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_0195: Invalid comparison between I4 and F4
		//IL_023d: Expected O, but got Ref
		//IL_01b5: Expected I4, but got F4
		//IL_02db: Expected O, but got Ref
		//IL_03a3: Expected O, but got F4
		//IL_0412: Expected O, but got Ref
		//IL_0420: Expected O, but got Ref
		//IL_06ab: Expected I4, but got O
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (trailRenderer != null)
		{
			trailRenderer.Clear();
			float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
			float startWidth = attackSizeMultiplier * 0.25f;
			trailRenderer.startWidth = startWidth;
		}
		if (projectileIndex == 0)
		{
			sfx.Play();
			sfxLoop.SetActive(value: true);
		}
		int attackQuantity = WeaponUtility.GetAttackQuantity(weaponBase);
		bool flag = attackQuantity <= 1;
		object obj3 = 0;
		if (!flag)
		{
			object obj4 = attackQuantity * 2;
			object obj5 = attackQuantity + obj4;
			object obj6 = obj5 << 2;
			if ((nint)obj6 >= 349)
			{
				obj6 = 348;
			}
			else if ((nint)obj6 < 0)
			{
				obj6 = 0;
			}
			object obj7 = attackQuantity - 1;
			int num = projectileIndex / obj7;
			object obj8 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			object obj9 = obj8 ^ 0;
			if (0 <= num)
			{
				if ((float)num > 1f)
				{
					num = 1;
				}
			}
			else
			{
				num = 0;
			}
			object obj10 = obj6 - obj9;
			object obj11 = obj10 * num;
			obj3 = obj11 + obj9;
		}
		float num2 = (float)obj3 * ((float)Math.PI / 180f);
		Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		nint num3 = (nint)typeof(Vector3);
		Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = quaternion.x;
		Quaternion quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rax_v15 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		_ = Vector3.forwardVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ rax_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		_ = 0;
		Vector3 vector2 = quaternion2 * vector;
		Transform transform = base.transform;
		MyPlayer instance = MyPlayer.Instance;
		Transform parentInternal = instance.playerRenderer.transform;
		transform.parentInternal = parentInternal;
		Transform transform2 = base.transform;
		_ = vector2.x;
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = vector2.z;
		Quaternion quaternion3 = Quaternion.LookRotation(forward);
		Quaternion localRotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = quaternion3.x;
		transform2.localRotation = localRotation;
		Transform transform3 = base.transform;
		transform3.parentInternal = null;
		float num5 = projectileRadius * 1.1f;
		float num6 = num5 + 3.4f;
		forwardOffset = num6;
		Transform transform4 = base.transform;
		Transform transform5 = MyPlayer.Instance.transform;
		Vector3 position = transform5.position;
		Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = position.x;
		_ = position.z;
		transform4.position = position2;
		Transform transform6 = base.transform;
		Vector3 position3 = transform6.position;
		Transform transform7 = base.transform;
		Vector3 forward2 = transform7.forward;
		float num7 = forwardOffset * forward2.z;
		moveTimer = 0f;
		float num8 = num7 + position3.z;
		Vector3 vector3 = default(Vector3);
		desiredPosition = vector3;
		Transform transform8 = base.transform;
		Vector3 position4 = transform8.position;
		startPosition = (Vector3)position4.x;
		_ = position4.z;
		nextCheckDamageTime = 0f;
		Transform transform9 = base.transform;
		Vector3 position5 = transform9.position;
		Transform transform10 = base.transform;
		Vector3 forward3 = transform10.forward;
		GameManager instance2 = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		Vector3 vector4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = forward3.x;
		_ = forward3.z;
		_ = position5.x;
		_ = position5.z;
		int layerMask = default(int);
		QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
		int num9 = Physics.RaycastNonAlloc(origin, vector4, _raycastHitBuffer, forwardOffset, layerMask, queryTriggerInteraction);
		if (num9 > 0)
		{
			RaycastHit[] raycastHitBuffer = _raycastHitBuffer;
			if (raycastHitBuffer.Length <= 0)
			{
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				return (byte)(int)ex != 0;
			}
			object obj12 = raycastHitBuffer + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			Transform transform11 = base.transform;
			Vector3 forward4 = transform11.forward;
			float num10 = projectileRadius * forward4.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rax_v60+8]");
			float num11 = 0f - num10;
			desiredPosition = vector3;
		}
		numTimesEnemiesHitThisTick.Clear();
		return true;
	}

	private float GetAngle(int projectileIndex, int maxIndex)
	{
		//IL_00e4: Expected F4, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_00f2: Expected O, but got I4
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected I4, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_006f: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_00ab: Invalid comparison between I4 and F4
		//IL_00cb: Expected I4, but got F4
		if (maxIndex > 1)
		{
			object obj = maxIndex * 2;
			object obj2 = maxIndex + obj;
			object obj3 = obj2 << 2;
			if ((nint)obj3 >= 349)
			{
				obj3 = 348;
			}
			else if ((nint)obj3 < 0)
			{
				obj3 = 0;
			}
			object obj4 = maxIndex - 1;
			int num = projectileIndex / obj4;
			object obj5 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			object obj6 = obj5 ^ 0;
			if (0 <= num)
			{
				if ((float)num > 1f)
				{
					num = 1;
				}
			}
			else
			{
				num = 0;
			}
			object obj7 = obj3 - obj6;
			object obj8 = obj7 * num;
			return (float)obj8 + (float)obj6;
		}
		return 0f;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_0041: Expected native int or pointer, but got O
		//IL_0053: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 forward = transform.forward;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = forward.x;
			((Vector3*)(nint)vector)->z = forward.z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	protected override void MyFixedUpdate()
	{
		CheckDamage();
	}

	private void LateUpdate()
	{
		TryPopDamage();
	}

	private unsafe void CheckDamage()
	{
		//IL_0051: Invalid comparison between I4 and F4
		//IL_00a4: Expected O, but got Ref
		//IL_00c3: Expected O, but got I4
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + collisionCooldown;
		nextCheckDamageTime = num;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		if (1f > moveTimer)
		{
			float num2 = Easing.InOutCirc(moveTimer);
			if (!(0f > num2) && !(num2 > 1f))
			{
			}
		}
		float num3 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num3), projectileRadius, out var buffer);
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
			int num4 = numTimesEnemiesHitThisTick.get_Item(buffer[obj]);
			int value = num4 + 1;
			((Dictionary<object, int>)(object)numTimesEnemiesHitThisTick).set_Item((object)buffer[obj], value);
			obj++;
			hasDamage = true;
		}
		while ((nint)obj < enemiesInRadiusSafe);
	}

	private unsafe void TryPopDamage()
	{
		//IL_03cb: Expected I, but got O
		//IL_0503: Expected I, but got O
		//IL_010d: Expected I, but got O
		//IL_0132: Expected O, but got Ref
		//IL_015c: Expected O, but got Ref
		//IL_017c: Expected I, but got O
		//IL_01c2: Expected I, but got O
		//IL_04c6: Expected I, but got O
		//IL_0227: Expected O, but got Ref
		//IL_024b: Expected I, but got O
		//IL_02d2: Expected I4, but got F4
		//IL_02d2: Expected O, but got Ref
		//IL_02d2: Expected O, but got Ref
		if (!hasDamage)
		{
			return;
		}
		hasDamage = false;
		nint num = (nint)typeof(ProjectileAxe);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v8 (Il2CppClass<ProjectileAxe>)+B8]");
		nint num2 = 0;
		if (numTimesEnemiesHitThisTick != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			bool flag = false;
			ProjectileAxe projectileAxe = this;
			Dictionary<Collider, int>.Enumerator enumerator = default(Dictionary<Collider, int>.Enumerator);
			Collider collider = default(Collider);
			float num3 = default(float);
			float num4 = default(float);
			float num5 = default(float);
			object obj = default(object);
			ProjectileAxe projectileAxe2 = default(ProjectileAxe);
			object obj2 = default(object);
			float num7 = default(float);
			float num8 = default(float);
			float num9 = default(float);
			GameObject weaponHitEffect = default(GameObject);
			bool useSfx = default(bool);
			while (enumerator.MoveNext())
			{
				if ((object)EnemyManager.Instance != null)
				{
					if (!EnemyManager.Instance.GetEnemy(collider, out var enemy))
					{
						continue;
					}
					bool flag2 = (object)enemy == null;
					EnemyManager enemyManager = (EnemyManager)(object)enemy;
					if (!flag2)
					{
						Transform transform = enemy.transform;
						bool flag3 = (object)transform == null;
						enemyManager = (EnemyManager)(object)enemy;
						if (!flag3)
						{
							Vector3 position = transform.position;
							bool flag4 = (object)MyPlayer.Instance == null;
							enemyManager = (EnemyManager)(object)MyPlayer.Instance;
							if (!flag4)
							{
								Transform transform2 = MyPlayer.Instance.transform;
								bool flag5 = (object)transform2 == null;
								num2 = (nint)MyPlayer.Instance;
								if (!flag5)
								{
									Vector3 position2 = transform2.position;
									Vector3 vector = VectorExtensions.XZVector((Vector3)(&num3));
									DamageContainer damageContainer = WeaponUtility.GetDamageContainer(projectileAxe.weaponBase, null, enemy, (Vector3)(&num4), num5);
									bool flag6 = damageContainer == null;
									num2 = (nint)projectileAxe.weaponBase;
									if (!flag6)
									{
										float damage = (float)obj * damageContainer.damage;
										damageContainer.damage = damage;
										bool flag7 = (object)enemy == null;
										num2 = (nint)enemy;
										if (!flag7)
										{
											enemy.DamageFromPlayerWeapon(damageContainer);
											float num6 = damageThisTick + damageContainer.damage;
											damageThisTick = num6;
											if ((flag ? 1 : 0) < 5)
											{
												Transform transform3 = projectileAxe2.transform;
												bool flag8 = (object)transform3 == null;
												num2 = (nint)projectileAxe2;
												if (flag8)
												{
													throw new NullReferenceException();
												}
												Vector3 position3 = transform3.position;
												bool flag9 = (object)collider == null;
												num2 = (nint)(&obj2);
												if (flag9)
												{
													throw new NullReferenceException();
												}
												Vector3 vector2 = collider.ClosestPoint((Vector3)(&num7));
												bool hitEnemy = enemy;
												num2 = (nint)projectileAxe2.weaponBase;
												if (projectileAxe2.weaponBase == null)
												{
													throw new NullReferenceException();
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ rcx_v13 (Il2CppStaticFields<ProjectileAxe>)+18]");
												if ((nint)0 == 0)
												{
													throw new NullReferenceException();
												}
												if ((object)EffectManager.Instance == null)
												{
													throw new NullReferenceException();
												}
												EffectManager.Instance.EnemyHitEffect((Vector3)(&num8), (Vector3)(&num9), hitEnemy, (EWeapon)num5, weaponHitEffect, useSfx);
												flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
												projectileAxe = projectileAxe2;
											}
											else
											{
												flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
												projectileAxe = projectileAxe2;
											}
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
			bool flag10 = numTimesEnemiesHitThisTick == null;
			num2 = (nint)numTimesEnemiesHitThisTick;
			if (!flag10)
			{
				numTimesEnemiesHitThisTick.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void MyUpdate()
	{
		//IL_0102: Invalid comparison between I4 and F4
		//IL_0051: Expected F4, but got I4
		//IL_0063: Expected O, but got Ref
		if (!(moveTimer < 1f))
		{
			return;
		}
		float num = MyTime.deltaTime / moveTime;
		if ((moveTimer = num + moveTimer) > 1f)
		{
			moveTimer = 1f;
		}
		Transform transform = base.transform;
		float num2 = Easing.InOutCirc(moveTimer);
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = default(float);
		transform.position = (Vector3)(&num3);
	}

	protected override void FindMovementDirection()
	{
	}

	private float GetRadius()
	{
		return projectileRadius;
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void StepMovement()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_002b: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		Gizmos.DrawWireSphere((Vector3)(&obj), projectileRadius);
	}

	static ProjectileAxe()
	{
		RaycastHit[] raycastHitBuffer = new RaycastHit[1];
		_raycastHitBuffer = raycastHitBuffer;
		Dictionary<Collider, int> dictionary = new Dictionary<Collider, int>();
		dictionary._002Ector();
		numTimesEnemiesHitThisTick = dictionary;
	}
}
