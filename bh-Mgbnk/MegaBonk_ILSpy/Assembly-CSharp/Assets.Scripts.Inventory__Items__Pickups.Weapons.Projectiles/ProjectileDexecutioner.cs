using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public class ProjectileDexecutioner : ProjectileBase
{
	private struct MeleeHit
	{
		public Vector3 pos;

		public Vector3 dir;

		public MeleeHit(Vector3 pos, Vector3 dir)
		{
			//IL_000f: Expected O, but got F4
			//IL_0028: Expected O, but got F4
			this.pos = (Vector3)pos.x;
			_ = pos.z;
			this.dir = (Vector3)dir.x;
			_ = dir.z;
		}
	}

	public Vector3 colliderOffset;

	public float testMultiplier;

	public float projectileDistance;

	private float forwardOffset;

	private float upOffset;

	public Vector3 attackDir;

	public float executionChance;

	private static readonly RaycastHit[] sphereHits;

	private DamageContainer dcExecute;

	private List<MeleeHit> effectHits;

	private bool useAudio;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_03a9: Expected I4, but got O
		//IL_012f: Expected O, but got Ref
		//IL_01a5: Expected O, but got F4
		//IL_0300: Expected O, but got Ref
		//IL_0318: Expected O, but got Ref
		//IL_0346: Expected O, but got Ref
		WeaponBase weaponBase = base.weaponBase;
		float num3 = default(float);
		if (base.weaponBase != null)
		{
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
				float num = attackSizeMultiplier;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v3 (WeaponData)+C8]");
				float num2 = (forwardOffset = num * 0f);
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Vector3 position = transform.position;
					WeaponBase weaponBase2 = base.weaponBase;
					if (base.weaponBase != null)
					{
						WeaponData weaponData2 = weaponBase2.weaponData;
						if ((object)weaponBase2.weaponData != null)
						{
							float range = projectileDistance + num2;
							GameObject exceptObject = default(GameObject);
							Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num3), range, projectileIndex, weaponData2.useVision, exceptObject);
							MyPlayer instance = MyPlayer.Instance;
							if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
							{
								Transform transform2 = instance.playerRenderer.transform;
								if ((object)transform2 != null)
								{
									Vector3 forward = transform2.forward;
									attackDir = (Vector3)forward.x;
									_ = forward.z;
									if (!(enemy != null))
									{
										goto IL_03f9;
									}
									if ((object)enemy != null)
									{
										Vector3 feetPosition = enemy.GetFeetPosition();
										if ((object)MyPlayer.Instance != null && (object)MyPlayer.Instance != null)
										{
											Transform transform3 = MyPlayer.Instance.transform;
											if ((object)transform3 != null)
											{
												Vector3 position2 = transform3.position;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
												object obj = default(object);
												attackDir = (Vector3)obj;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v39+8]");
												_ = 0;
												goto IL_03f9;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_039b;
		IL_039b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_03f9:
		Transform transform4 = base.transform;
		if ((object)MyPlayer.Instance != null)
		{
			Transform transform5 = MyPlayer.Instance.transform;
			if ((object)transform5 != null)
			{
				Vector3 position3 = transform5.position;
				WeaponBase weaponBase3 = base.weaponBase;
				if (base.weaponBase != null && (object)weaponBase3.weaponData != null && (object)transform4 != null)
				{
					transform4.position = (Vector3)(&num3);
					Transform transform6 = base.transform;
					Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num3));
					if ((object)transform6 != null)
					{
						object obj2 = default(object);
						transform6.rotation = (Quaternion)(&obj2);
						WeaponAttack weaponAttack = base.weaponAttack;
						if ((object)base.weaponAttack != null)
						{
							CheckZone(base.weaponBase, projectileRadius, weaponAttack.prefabHit);
							useAudio = true;
							return true;
						}
					}
				}
			}
		}
		goto IL_039b;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)attackDir;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileDexecutioner)+8C]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected override void MyFixedUpdate()
	{
	}

	protected unsafe override void MyUpdate()
	{
		//IL_0046: Expected O, but got Ref
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		float num = default(float);
		transform.position = (Vector3)(&num);
	}

	protected override void FindMovementDirection()
	{
	}

	public unsafe void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_01c1: Expected O, but got Ref
		//IL_01f8: Expected O, but got Ref
		//IL_0225: Expected F4, but got I4
		//IL_0236: Expected F4, but got I4
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Expected O, but got Unknown
		//IL_05f4: Invalid comparison between F4 and I4
		//IL_047c: Expected F4, but got I4
		//IL_0399: Expected O, but got Ref
		//IL_03e9: Expected F4, but got O
		//IL_03f9: Expected F4, but got I
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		//IL_0502: Expected O, but got Ref
		//IL_0539: Expected F4, but got I
		//IL_0547: Expected O, but got Ref
		//IL_0557: Expected F4, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Vector3 forward = transform2.forward;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileDexecutioner)+70]");
		object obj3 = 0 * forward.x;
		float num = (float)obj3 * attackSizeMultiplier;
		float num2 = num + position.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileDexecutioner)+70]");
		object obj4 = 0 * forward.z;
		float num3 = (float)obj4 * attackSizeMultiplier;
		float num4 = num3 + position.z;
		Transform transform3 = base.transform;
		Vector3 forward2 = transform3.forward;
		float num5 = radius + radius;
		float num6 = num5 * forward2.x;
		float num7 = num5 * forward2.z;
		float num8 = num2 - num6;
		float num9 = num4 - num7;
		List<MeleeHit> list = effectHits;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v12 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileDexecutioner+MeleeHit>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		bool flag = hitEffect == null;
		Transform transform4 = base.transform;
		Vector3 forward3 = transform4.forward;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		_ = forward3.x;
		_ = forward3.z;
		float num11 = default(float);
		float num12 = default(float);
		int layerMask = default(int);
		QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
		int num10 = Physics.SphereCastNonAlloc((Vector3)(&num11), radius, vector, sphereHits, num12, layerMask, queryTriggerInteraction);
		if (num10 <= 0)
		{
			return;
		}
		float num13 = 0f;
		num11 = num8;
		float num14 = 0f;
		float num15 = radius;
		float x = default(float);
		do
		{
			float num16 = num14 * 44f;
			float num17 = num16 + (float)sphereHits;
			RaycastHit raycastHit = (RaycastHit)(num17 + 32);
			Collider collider = ((RaycastHit*)raycastHit)->collider;
			if (EnemyManager.Instance.GetEnemy(collider, out var enemy))
			{
				Transform transform5 = base.transform;
				Vector3 forward4 = transform5.forward;
				num9 = forward4.x;
				num13 = forward4.z;
				double num18 = MyRandom.random.NextDouble();
				num15 = executionChance;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
				if ((nint)MyRandom.random <= 0)
				{
					Vector3 centerPosition = enemy.GetCenterPosition();
					Transform transform6 = MyPlayer.Instance.transform;
					Vector3 position2 = transform6.position;
					float num19 = centerPosition.x - position2.x;
					num8 = centerPosition.y - position2.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1022 @ rax_v65+8]");
					_ = 0;
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, this, enemy, vector2, num12);
					enemy.DamageFromPlayerWeapon(damageContainer);
					num9 = (float)damageContainer.direction;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v67 (Assets.Scripts.Actors.DamageContainer)+18]");
					num13 = 0f;
					num11 = num19;
				}
				else
				{
					WeaponData weaponData = weaponBase.weaponData;
					dcExecute.Reuse(0f, weaponData._003CdamageSourceName_003Ek__BackingField);
					DamageContainer damageContainer2 = dcExecute;
					damageContainer2.enemy = enemy;
					DamageUtility.ApplyExecute(dcExecute);
					enemy.DamageFromPlayerWeapon(dcExecute);
					num15 = 0f;
				}
				List<MeleeHit> list2 = effectHits;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v43 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileDexecutioner+MeleeHit>)+18]");
				if ((nint)0 < (nint)10)
				{
					RaycastHit raycastHit2 = (RaycastHit)(num17 + 32);
					Collider collider2 = ((RaycastHit*)raycastHit2)->collider;
					Transform transform7 = base.transform;
					Vector3 position3 = transform7.position;
					Vector3 vector3 = collider2.ClosestPoint((Vector3)(&x));
					_ = vector3.x;
					_ = vector3.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
					num6 = 0f;
					MeleeHit item = (MeleeHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
					num15 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
					_ = 0;
					list2.Add(item);
					x = position3.x;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
				if ((nint)0 == 0)
				{
					_ = 1;
					Invoke("SpawnEffect", 0.1f);
					num7 = 0.1f;
				}
			}
			num14++;
		}
		while (num14 < (float)num10);
	}

	private unsafe void SpawnEffect()
	{
		//IL_0038: Expected O, but got Ref
		//IL_00c8: Expected O, but got Ref
		//IL_00c8: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18113FB70");
		List<MeleeHit>.Enumerator enumerator = default(List<MeleeHit>.Enumerator);
		object obj = default(object);
		object obj2 = default(object);
		EWeapon eWeapon = default(EWeapon);
		GameObject weaponHitEffect = default(GameObject);
		bool useSfx = default(bool);
		object obj3 = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				WeaponAttack weaponAttack = base.weaponAttack;
				bool flag = (object)base.weaponAttack == null;
				List<MeleeHit>.Enumerator enumerator2 = (List<MeleeHit>.Enumerator)(&enumerator);
				if (!flag)
				{
					if (weaponAttack.prefabHit != null)
					{
						enumerator2 = (List<MeleeHit>.Enumerator)weaponAttack.weaponBase;
						if (weaponAttack.weaponBase == null)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v7 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileDexecutioner+MeleeHit>+Enumerator<Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileD…");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						EffectManager.Instance.EnemyHitEffect((Vector3)(&obj), (Vector3)(&obj2), hitEnemy: true, eWeapon, weaponHitEffect, useSfx);
						obj2 = obj3;
					}
					useAudio = false;
					continue;
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			return;
		}
		throw new NullReferenceException();
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

	public ProjectileDexecutioner()
	{
		//IL_0046: Expected O, but got I4
		//IL_006f: Expected I, but got O
		//IL_00b2: Expected O, but got I
		//IL_00c2: Expected O, but got I
		_ = 1056964608;
		colliderOffset = (Vector3)0;
		testMultiplier = 1f;
		projectileDistance = 5f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		attackDir = Vector3.forwardVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		_ = 0;
		executionChance = 0.1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6+B8]");
		object damageSource = 0;
		DamageContainer damageContainer = new DamageContainer(0f, (string)damageSource);
		dcExecute = damageContainer;
		effectHits = new List<MeleeHit>();
		useAudio = true;
		base._002Ector();
	}

	static ProjectileDexecutioner()
	{
		RaycastHit[] array = new RaycastHit[EnemyManager.maxNumEnemiesPooled];
		sphereHits = array;
	}
}
