using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileScythe : ProjectileBase
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

	private float upOffset;

	private float bigHitMultiplierSize;

	private float bigHitMultiplierDamage;

	private bool isThisHitBig;

	public ParticleSystem ps;

	private ParticleSystem.MainModule main;

	public Color defaultColor;

	public Color bigHitColor;

	public static bool nextHitIsBig;

	private static float nextBigHitReadyTime;

	private float bigHitCooldown;

	private List<MeleeHit> effectHits;

	private bool useAudio;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0390: Expected I4, but got O
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_010c: Expected O, but got Ref
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_03be: Expected O, but got Ref
		//IL_03d0: Expected O, but got Ref
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_026f: Expected O, but got Ref
		//IL_032d: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		if ((object)ps != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
			main = mainModule;
			isThisHitBig = false;
			float num2 = default(float);
			if (!nextHitIsBig)
			{
				ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)(this + 144);
				ParticleSystem.MinMaxGradient startColor = ((ParticleSystem.MainModule*)mainModule2)->startColor;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v34 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231E790");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v35+C]");
				_ = 0;
			}
			else
			{
				nextHitIsBig = false;
				float num = bigHitMultiplierSize * projectileRadius;
				isThisHitBig = true;
				projectileRadius = num;
				Transform transform = base.transform;
				if ((object)transform == null)
				{
					goto IL_0382;
				}
				Vector3 localScale = transform.localScale;
				transform.localScale = (Vector3)(&num2);
				ParticleSystem.MainModule mainModule3 = (ParticleSystem.MainModule)(this + 144);
				ParticleSystem.MinMaxGradient startColor2 = ((ParticleSystem.MainModule*)mainModule3)->startColor;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rax_v32 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231E790");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v33+C]");
				_ = 0;
			}
			Color color = default(Color);
			ParticleSystem.MinMaxGradient minMaxGradient = (Color)(&color);
			ParticleSystem.MinMaxGradient startColor3 = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			ParticleSystem.MainModule mainModule4 = (ParticleSystem.MainModule)(this + 144);
			_ = minMaxGradient.m_Mode;
			_ = minMaxGradient.m_GradientMax;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v9 (UnityEngine.ParticleSystem+MinMaxGradient)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v9 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
			_ = 0;
			((ParticleSystem.MainModule*)mainModule4)->startColor = startColor3;
			Transform transform2 = base.transform;
			if ((object)MyPlayer.Instance != null)
			{
				Transform transform3 = MyPlayer.Instance.transform;
				if ((object)transform3 != null)
				{
					Vector3 position = transform3.position;
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
					{
						Transform transform4 = instance.playerRenderer.transform;
						if ((object)transform4 != null)
						{
							Vector3 forward = transform4.forward;
							WeaponBase weaponBase = base.weaponBase;
							if (base.weaponBase != null && (object)weaponBase.weaponData != null && (object)transform2 != null)
							{
								transform2.position = (Vector3)(&num2);
								Transform transform5 = base.transform;
								MyPlayer instance2 = MyPlayer.Instance;
								if ((object)MyPlayer.Instance != null && (object)instance2.playerRenderer != null)
								{
									Transform transform6 = instance2.playerRenderer.transform;
									if ((object)transform6 != null)
									{
										Quaternion rotation = transform6.rotation;
										if ((object)transform5 != null)
										{
											transform5.rotation = (Quaternion)(&color);
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
		goto IL_0382;
		IL_0382:
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
		//IL_0077: Expected O, but got Ref
		//IL_00ca: Expected O, but got Ref
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
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_01ba: Expected O, but got Ref
		//IL_01e5: Expected O, but got Ref
		//IL_027a: Expected O, but got Ref
		//IL_0291: Expected O, but got Ref
		//IL_0291: Expected O, but got I4
		//IL_02ad: Expected O, but got F4
		//IL_0410: Expected O, but got I
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
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
		float x = default(float);
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
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase2, this, enemy, (Vector3)(&obj5), forceDamage);
				if (isThisHitBig)
				{
					float damage = bigHitMultiplierDamage * damageContainer.damage;
					damageContainer.damage = damage;
				}
				enemy.DamageFromPlayerWeapon(damageContainer);
				Transform transform6 = base.transform;
				Vector3 position3 = transform6.position;
				Vector3 vector = buffer[obj3].ClosestPoint((Vector3)(&x));
				MeleeHit meleeHit = new MeleeHit((Vector3)0, (Vector3)(&x));
				meleeHit.pos = (Vector3)vector.x;
				meleeHit.dir = damageContainer.direction;
				_ = vector.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v37 (Assets.Scripts.Actors.DamageContainer)+18]");
				_ = 0;
				effectHits.Add(meleeHit);
				if (!flag2)
				{
					Invoke("SpawnEffect", 0.1f);
					flag2 = true;
				}
				bool flag3 = nextHitIsBig;
				attackSizeMultiplier = position3.x;
				if (!flag3)
				{
					bool flag4 = enemy.IsDead();
					bool flag5 = !flag4;
					attackSizeMultiplier = position3.x;
					if (!flag5)
					{
						bool flag6 = enemy.IsElite();
						bool flag7 = !flag6;
						attackSizeMultiplier = position3.x;
						if (!flag7)
						{
							attackSizeMultiplier = MyTime.time;
							if (!(MyTime.time < nextBigHitReadyTime))
							{
								nextHitIsBig = true;
								attackSizeMultiplier = MyTime.time + bigHitCooldown;
								nextBigHitReadyTime = attackSizeMultiplier;
							}
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
				weaponBase2 = (WeaponBase)0;
				x = position3.x;
				obj5 = obj6;
				num = num2;
			}
			obj3++;
			obj7 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
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

	public ProjectileScythe()
	{
		//IL_002d: Expected O, but got I4
		_ = 1056964608;
		colliderOffset = (Vector3)0;
		testMultiplier = 1f;
		bigHitMultiplierSize = 1.5f;
		bigHitMultiplierDamage = 2f;
		bigHitCooldown = 2f;
		List<MeleeHit> list = new List<MeleeHit>();
		effectHits = list;
		useAudio = true;
		base._002Ector();
	}
}
