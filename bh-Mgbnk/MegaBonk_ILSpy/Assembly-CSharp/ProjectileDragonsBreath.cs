using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using Utility;

public class ProjectileDragonsBreath : ConstantAttack
{
	public ParticleSystem ps;

	public AudioSource sfx;

	public AudioClip sfxStart;

	public AudioClip sfxLoop;

	private float defaultVolume;

	private ParticleSystem.VelocityOverLifetimeModule[] velocities;

	private ParticleSystem[] particles;

	private float startTime;

	private float stopTime;

	private float previousStopTime;

	private float stopHitboxTime;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float enemyHitCooldown;

	private float hitboxCooldown;

	private float nextHitboxTime;

	private bool isActive;

	private float range;

	private float duration;

	private float rotationSpeed;

	private float cooldown;

	private float minCooldown;

	private Vector3 attackDir;

	private float nextFindTargetTime;

	private float findTargetInterval;

	private Enemy enemyTarget;

	private float lingerTime;

	private float scaleTimer;

	private float scaleOverTime;

	private float oldRange;

	private float scale;

	private float oldScale;

	protected override void Init()
	{
		//IL_0063: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		ParticleSystem[] componentsInChildren = ps.GetComponentsInChildren<ParticleSystem>();
		particles = componentsInChildren;
		ParticleSystem[] array = particles;
		ParticleSystem.VelocityOverLifetimeModule[] array2 = new ParticleSystem.VelocityOverLifetimeModule[array.Length];
		velocities = array2;
		ParticleSystem[] array3 = particles;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array3.Length)
		{
			ParticleSystem[] array4 = particles;
			ParticleSystem.VelocityOverLifetimeModule[] array5 = velocities;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			array3 = particles;
			obj++;
			obj2 = obj;
		}
		OnStatUpdate(EStat.SizeMultiplier);
		OnStatUpdate(EStat.AttackSpeed);
		OnStatUpdate(EStat.DurationMultiplier);
		OnStatUpdate(EStat.ProjectileSpeedMultiplier);
		float num = (startTime = MyTime.time + cooldown) + duration;
		stopTime = num;
		float volume = sfx.volume;
		defaultVolume = volume;
	}

	private unsafe void Update()
	{
		//IL_0047: Expected O, but got Ref
		//IL_0160: Invalid comparison between I4 and F4
		//IL_0093: Expected O, but got Ref
		if (MyTime.paused)
		{
			return;
		}
		Transform transform = base.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		float num = default(float);
		transform.position = (Vector3)(&num);
		if (scaleTimer < 1f)
		{
			float num2 = MyTime.deltaTime / scaleOverTime;
			if ((scaleTimer = num2 + scaleTimer) > 1f)
			{
				scaleTimer = 1f;
			}
			float num3 = Easing.InOutCirc(scaleTimer);
			if (0f > num3 || num3 > 1f)
			{
			}
			Transform transform3 = base.transform;
			transform3.localScale = (Vector3)(&num);
		}
		UpdateSfx();
	}

	private unsafe void FindClosestTarget()
	{
		//IL_003c: Expected O, but got Ref
		//IL_006a: Expected O, but got I4
		//IL_021b: Expected I, but got O
		//IL_0165: Invalid comparison between F4 and I4
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01cd: Expected F4, but got I4
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = range + 5f;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), num, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		Enemy enemy = null;
		float num3 = 3.4028235E+38f;
		object obj = 0;
		if (flag)
		{
			return;
		}
		do
		{
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			Transform transform3 = buffer[obj].transform;
			Vector3 position3 = transform3.position;
			nint num4 = (nint)typeof(Math);
			float num5 = position2.x - position3.x;
			float num6 = position2.y - position3.y;
			float num7 = position2.z - position3.z;
			float num8 = num6 * num6;
			float num9 = num5 * num5;
			float num10 = num7 * num7;
			float num11 = num8 + num9;
			float num12 = num11 + num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num13 = Math.Sqrt(num12);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
			if (num3 > 0f && EnemyManager.Instance.GetEnemy(buffer[obj], out enemy))
			{
				enemyTarget = enemy;
				num3 = 0f;
			}
			obj++;
		}
		while ((nint)obj < enemiesInRadiusSafe);
	}

	private unsafe void FixedUpdate()
	{
		//IL_010e: Expected O, but got Ref
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected F4, but got Unknown
		//IL_02f5: Expected O, but got Ref
		//IL_05ca: Expected I, but got O
		//IL_05eb: Expected F4, but got I
		//IL_0320: Expected O, but got F4
		//IL_0288: Invalid comparison between F4 and I4
		//IL_0515: Expected O, but got Ref
		//IL_0515: Expected O, but got Ref
		//IL_0471: Expected O, but got Ref
		//IL_0471: Expected O, but got Ref
		if (!(MyTime.time < nextFindTargetTime))
		{
			FindClosestTarget();
		}
		StepActive();
		if (!isActive)
		{
			if (!(MyTime.time < stopHitboxTime))
			{
				return;
			}
			if (!isActive)
			{
				goto IL_0687;
			}
		}
		MyPlayer instance = MyPlayer.Instance;
		Transform transform = instance.playerRenderer.transform;
		float x = transform.rotation.x;
		float num = default(float);
		if (enemyTarget != null)
		{
			Vector3 feetPosition = enemyTarget.GetFeetPosition();
			Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
			x = Quaternion.LookRotation((Vector3)(&num)).x;
			if (enemyTarget.IsDeadOrDyingNextFrame())
			{
				enemyTarget = null;
			}
		}
		else
		{
			FindClosestTarget();
		}
		Transform transform2 = base.transform;
		Transform transform3 = base.transform;
		Quaternion rotation = transform3.rotation;
		float fixedDeltaTime = Time.fixedDeltaTime;
		float num2 = rotationSpeed * fixedDeltaTime;
		float num4 = default(float);
		float num3 = num4 * num4;
		float num5 = num4 * num4;
		float num6 = num4 * num4;
		float num7 = rotation.x * x;
		float num8 = num7 + num6;
		float num9 = num8 + num5;
		float num10 = num9 + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		float num11 = num10 & 0;
		if (!(1f > num11))
		{
			num11 = 1f;
		}
		float num16 = default(float);
		if (!(num11 > 0.999999f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301200");
			float num12 = num11 + num11;
			float num13 = num12 * 57.29578f;
			bool flag = num13 == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804E96E2h\"");
			if (!flag)
			{
				float num14 = num2 / num13;
				bool flag2 = num14 > 1f;
				float num15 = 1f;
				if (!flag2)
				{
					num15 = num14;
				}
				Quaternion quaternion = Quaternion.SlerpUnclamped((Quaternion)(&num), (Quaternion)(&num16), num15);
				num11 = num15;
			}
		}
		transform2.rotation = (Quaternion)(&num16);
		Transform transform4 = base.transform;
		Vector3 forward = transform4.forward;
		attackDir = (Vector3)forward.x;
		_ = forward.z;
		goto IL_0687;
		IL_0687:
		MyPlayer instance2 = MyPlayer.Instance;
		Vector3 velocity = instance2.playerMovement.GetVelocity();
		MyPlayer instance3 = MyPlayer.Instance;
		Vector3 wishDir = instance3.playerMovement.GetWishDir();
		float num17 = wishDir.z * wishDir.z;
		float num18 = wishDir.y * wishDir.y;
		float num19 = wishDir.x * wishDir.x;
		float num20 = num19 + num18;
		float num21 = num17 + num20;
		float num30;
		if (!(Mathf.Epsilon > num21))
		{
			float num22 = velocity.z * wishDir.z;
			float num23 = num4 * wishDir.y;
			float num24 = velocity.x * wishDir.x;
			float num25 = num24 + num23;
			float num26 = num25 + num22;
			float num27 = num26 * wishDir.z;
			float num28 = num27 / num21;
			float num29 = num26 * wishDir.y;
			num30 = num29 / num21;
		}
		else
		{
			nint num31 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rax_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ rcx_v33 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float num28 = 0f;
			num30 = num4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float startSpeed = num30 + 15f;
		ps.startSpeed = startSpeed;
		if (!(nextHitboxTime > MyTime.time))
		{
			float num33 = MyTime.time + hitboxCooldown;
			nextHitboxTime = num33;
			Transform transform5 = base.transform;
			Vector3 position = transform5.position;
			Vector3 vector = default(Vector3);
			HashSet<Collider> hashSet = RaycastUtility.ConeCastNew((Vector3)(&num16), (Vector3)(&vector), range, 30f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			Collider collider = default(Collider);
			while (enumerator.MoveNext())
			{
				bool flag3 = HitEnemy(collider);
			}
			((HashSet<Collider>.Enumerator*)(&enumerator))->Dispose();
		}
	}

	private unsafe bool HitEnemy(Collider collider)
	{
		//IL_0008: Expected O, but got Ref
		//IL_03e5: Expected I4, but got O
		//IL_00c8: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_01aa: Expected O, but got Ref
		//IL_01b8: Expected O, but got Ref
		//IL_01e9: Expected O, but got Ref
		//IL_021b: Expected O, but got I
		//IL_0259: Expected O, but got I
		//IL_0296: Expected O, but got Ref
		//IL_02d1: Expected O, but got I
		//IL_034c: Expected O, but got Ref
		//IL_035a: Expected O, but got Ref
		//IL_03a2: Expected I4, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (enemyHitCooldowns != null)
		{
			if (enemyHitCooldowns.TryGetValue(collider, out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
			{
				float num = MyTime.time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
				float num2 = num - 0f;
				if (enemyHitCooldown > num2)
				{
					goto IL_03c9;
				}
			}
			if ((object)EnemyManager.Instance != null)
			{
				if (!EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111))))
				{
					goto IL_03c9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
					if (((Enemy)0).IsDead())
					{
						goto IL_03c9;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
						Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
						if ((object)MyPlayer.Instance != null)
						{
							Transform transform = MyPlayer.Instance.transform;
							if ((object)transform != null)
							{
								Vector3 position = transform.position;
								float num3 = centerPosition.x - position.x;
								float num4 = centerPosition.y - position.y;
								float num5 = centerPosition.z - position.z;
								object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
								Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v20+8]");
								_ = 0;
								WeaponBase obj5 = base.weaponBase;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
								float num6 = default(float);
								DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj5, null, (Enemy)0, direction, num6);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
									((Enemy)0).DamageFromPlayerWeapon(damageContainer);
									Transform transform2 = base.transform;
									if ((object)transform2 != null)
									{
										Vector3 position2 = transform2.position;
										if ((object)collider != null)
										{
											Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											_ = position2.x;
											_ = position2.z;
											Vector3 vector = collider.ClosestPoint(position3);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
											bool hitEnemy = (UnityEngine.Object)0;
											WeaponBase weaponBase = base.weaponBase;
											if (base.weaponBase != null && (object)weaponBase.weaponData != null && (object)EffectManager.Instance != null)
											{
												Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Vector3 hitPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v20+8]");
												_ = 0;
												_ = vector.x;
												_ = vector.z;
												GameObject weaponHitEffect = default(GameObject);
												bool useSfx = default(bool);
												EffectManager.Instance.EnemyHitEffect(hitPos, moveDir, hitEnemy, (EWeapon)num6, weaponHitEffect, useSfx);
												if (enemyHitCooldowns != null)
												{
													((Dictionary<object, float>)(object)enemyHitCooldowns).set_Item((object)collider, MyTime.time);
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
		IL_03c9:
		return false;
	}

	private unsafe void StepActive()
	{
		//IL_00b2: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0172: Expected O, but got Ref
		if (isActive)
		{
			if (!(MyTime.time < stopTime))
			{
				ParticleSystem[] array = particles;
				isActive = false;
				object obj = 0;
				while ((nint)obj < array.Length)
				{
					array[obj].Stop();
					obj++;
				}
				previousStopTime = stopTime;
				float num = (startTime = MyTime.time + cooldown) + duration;
				stopTime = num;
				float num2 = MyTime.time + lingerTime;
				stopHitboxTime = num2;
				return;
			}
			if (isActive)
			{
				return;
			}
		}
		if (MyTime.time > startTime)
		{
			ParticleSystem[] array2 = particles;
			isActive = true;
			object obj2 = 0;
			while ((nint)obj2 < array2.Length)
			{
				array2[obj2].Play();
				obj2++;
			}
			sfx.clip = sfxStart;
			sfx.loop = false;
			sfx.volume = defaultVolume;
			sfx.Play();
			Transform transform = base.transform;
			MyPlayer instance = MyPlayer.Instance;
			Transform transform2 = instance.playerRenderer.transform;
			Quaternion rotation = transform2.rotation;
			object obj3 = default(object);
			transform.rotation = (Quaternion)(&obj3);
		}
	}

	private bool IsAttacking()
	{
		return isActive;
	}

	private unsafe void SizeUpdate()
	{
		//IL_00e8: Invalid comparison between I4 and F4
		//IL_004c: Expected O, but got Ref
		if (scaleTimer < 1f)
		{
			float num = MyTime.deltaTime / scaleOverTime;
			if ((scaleTimer = num + scaleTimer) > 1f)
			{
				scaleTimer = 1f;
			}
			float num2 = Easing.InOutCirc(scaleTimer);
			if (0f > num2 || num2 > 1f)
			{
			}
			Transform transform = base.transform;
			object obj = default(object);
			transform.localScale = (Vector3)(&obj);
		}
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		if (weaponData.eWeapon == weapon)
		{
			OnStatUpdate(stat);
		}
	}

	protected override void OnStatUpdate(EStat stat)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 35 Invalid \"Jump target not found in method: 0x1804EA26D\"");
	}

	private void UpdateSize()
	{
		scaleTimer = 0f;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num = attackSizeMultiplier * 8f;
		oldScale = scale;
		range = num;
		float attackSizeMultiplier2 = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num2 = attackSizeMultiplier2 + attackSizeMultiplier2;
		scale = num2;
	}

	private void UpdateCooldown()
	{
		float weaponCooldown = WeaponUtility.GetWeaponCooldown(base.weaponBase);
		WeaponBase weaponBase = base.weaponBase;
		cooldown = weaponCooldown;
		WeaponData weaponData = weaponBase.weaponData;
		float num = (minCooldown = weaponData.endCooldown * 0.5f);
		if (num > weaponCooldown)
		{
			cooldown = num;
		}
	}

	public override bool IsManualRotation()
	{
		return true;
	}

	public override float GetAuraRotationSpeed()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	private void UpdateSfx()
	{
		//IL_0200: Invalid comparison between I4 and F4
		//IL_00e4: Expected F4, but got I4
		//IL_021d: Invalid comparison between I4 and F4
		//IL_0120: Expected F4, but got I4
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0181: Invalid comparison between I4 and F4
		if (isActive)
		{
			if (!sfx.isPlaying)
			{
				sfx.clip = sfxLoop;
				sfx.loop = true;
				sfx.Play();
				return;
			}
			if (isActive)
			{
				return;
			}
		}
		if (!sfx.isPlaying)
		{
			return;
		}
		float num = MyTime.time - previousStopTime;
		float num2 = num / 0.6f;
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
		object obj = 0 - defaultVolume;
		float num3 = (float)obj * num2;
		float volume = num3 + defaultVolume;
		sfx.volume = volume;
		float volume2 = sfx.volume;
		if (!(0f < volume2))
		{
			sfx.Stop();
			sfx.volume = 1f;
		}
	}

	private void OnDrawGizmosSelected()
	{
	}

	public ProjectileDragonsBreath()
	{
		Dictionary<Collider, float> dictionary = new Dictionary<Collider, float>();
		enemyHitCooldowns = dictionary;
		enemyHitCooldown = 0.25f;
		hitboxCooldown = 0.06f;
		minCooldown = 1f;
		findTargetInterval = 0.25f;
		lingerTime = 0.2f;
		scaleOverTime = 0.8f;
		scale = 2f;
		oldScale = 2f;
		base._002Ector();
	}
}
