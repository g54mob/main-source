using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileMelee : ProjectileBase
{
	public class MeleeHit
	{
		public Vector3 pos;

		public Vector3 dir;

		public MeleeHit(Vector3 pos, Vector3 dir)
		{
			//IL_0015: Expected O, but got F4
			//IL_002e: Expected O, but got F4
			base._002Ector();
			this.pos = (Vector3)pos.x;
			_ = pos.z;
			this.dir = (Vector3)dir.x;
			_ = dir.z;
		}
	}

	public Vector3 colliderOffset;

	public float testMultiplier;

	private float forwardOffset;

	private float upOffset;

	private List<MeleeHit> effectHits;

	private bool useAudio;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_02b1: Expected I4, but got O
		//IL_0190: Expected O, but got Ref
		//IL_024e: Expected O, but got Ref
		WeaponBase weaponBase = base.weaponBase;
		if (base.weaponBase != null)
		{
			WeaponData weaponData = weaponBase.weaponData;
			if ((object)weaponBase.weaponData != null)
			{
				float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(base.weaponBase);
				float num = attackSizeMultiplier;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v3 (WeaponData)+C8]");
				float num2 = num * 0f;
				forwardOffset = num2;
				Transform transform = base.transform;
				if ((object)MyPlayer.Instance != null)
				{
					Transform transform2 = MyPlayer.Instance.transform;
					if ((object)transform2 != null)
					{
						Vector3 position = transform2.position;
						MyPlayer instance = MyPlayer.Instance;
						if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
						{
							Transform transform3 = instance.playerRenderer.transform;
							if ((object)transform3 != null)
							{
								Vector3 forward = transform3.forward;
								WeaponBase weaponBase2 = base.weaponBase;
								if (base.weaponBase != null && (object)weaponBase2.weaponData != null && (object)transform != null)
								{
									float num3 = default(float);
									transform.position = (Vector3)(&num3);
									Transform transform4 = base.transform;
									MyPlayer instance2 = MyPlayer.Instance;
									if ((object)MyPlayer.Instance != null && (object)instance2.playerRenderer != null)
									{
										Transform transform5 = instance2.playerRenderer.transform;
										if ((object)transform5 != null)
										{
											Quaternion rotation = transform5.rotation;
											if ((object)transform4 != null)
											{
												transform4.rotation = (Quaternion)(&num3);
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
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
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
	}

	protected unsafe override void MyUpdate()
	{
		//IL_0078: Expected O, but got Ref
		//IL_00cb: Expected O, but got Ref
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		MyPlayer instance = MyPlayer.Instance;
		Transform transform3 = instance.playerRenderer.transform;
		Vector3 forward = transform3.forward;
		float num = default(float);
		transform.position = (Vector3)(&num);
		Transform transform4 = base.transform;
		MyPlayer instance2 = MyPlayer.Instance;
		Transform transform5 = instance2.playerRenderer.transform;
		Quaternion rotation = transform5.rotation;
		transform4.rotation = (Quaternion)(&num);
	}

	protected override void FindMovementDirection()
	{
	}

	public unsafe void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0099: Expected O, but got Ref
		//IL_0104: Expected O, but got I4
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_01ba: Expected O, but got Ref
		//IL_01e5: Expected O, but got Ref
		//IL_0245: Expected O, but got Ref
		//IL_025c: Expected O, but got Ref
		//IL_025c: Expected O, but got I4
		//IL_0278: Expected O, but got F4
		//IL_02f1: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = base.transform;
		Vector3 right = transform.right;
		Transform transform2 = base.transform;
		Vector3 up = transform2.up;
		Transform transform3 = base.transform;
		Vector3 forward = transform3.forward;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		Transform transform4 = base.transform;
		Vector3 position = transform4.position;
		float num = default(float);
		float range = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), range, out var buffer);
		bool flag = hitEffect == null;
		List<MeleeHit> list = new List<MeleeHit>();
		effectHits = list;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		object obj3 = 0;
		bool flag2 = flag;
		num = position.x;
		WeaponBase weaponBase2 = weaponBase;
		object obj5 = default(object);
		float forceDamage = default(float);
		float num3 = default(float);
		object obj6 = default(object);
		object obj7;
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[obj3], out var enemy))
			{
				Vector3 centerPosition = enemy.GetCenterPosition();
				Transform transform5 = MyPlayer.Instance.transform;
				Vector3 position2 = transform5.position;
				float num2 = centerPosition.x - position2.x;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase2, this, enemy, (Vector3)(&obj5), forceDamage);
				enemy.DamageFromPlayerWeapon(damageContainer);
				Transform transform6 = base.transform;
				attackSizeMultiplier = transform6.position.x;
				Vector3 vector = buffer[obj3].ClosestPoint((Vector3)(&num3));
				MeleeHit meleeHit = new MeleeHit((Vector3)0, (Vector3)(&num3));
				meleeHit.pos = (Vector3)vector.x;
				meleeHit.dir = damageContainer.direction;
				_ = vector.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v37 (Assets.Scripts.Actors.DamageContainer)+18]");
				_ = 0;
				effectHits.Add(meleeHit);
				if (!flag2)
				{
					Invoke("SpawnEffect", 0.1f);
					flag2 = true;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
				weaponBase2 = (WeaponBase)0;
				num3 = attackSizeMultiplier;
				obj5 = obj6;
				num = num2;
			}
			obj3++;
			obj7 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		}
		while ((nint)obj7 < 0);
	}

	private unsafe void SpawnEffect()
	{
		//IL_002c: Expected O, but got Ref
		//IL_0058: Expected O, but got Ref
		//IL_0058: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		bool useSfx = default(bool);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				weaponAttack.ProjectileHit((Vector3)(&obj2), (Vector3)(&obj3), hitEnemy: true, useSfx);
				useAudio = false;
				continue;
			}
			((List<MeleeHit>.Enumerator*)(&enumerator))->Dispose();
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

	public ProjectileMelee()
	{
		//IL_002d: Expected O, but got I4
		_ = 1056964608;
		colliderOffset = (Vector3)0;
		testMultiplier = 1f;
		List<MeleeHit> list = new List<MeleeHit>();
		effectHits = list;
		useAudio = true;
		base._002Ector();
	}
}
