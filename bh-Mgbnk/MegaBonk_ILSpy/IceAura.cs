using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class IceAura : ConstantAttack
{
	private float defaultRadius;

	public AttackMuzzle attackMuzzle;

	private float radius;

	private float cooldown;

	private float oldRadius;

	private float scaleTimer;

	private float scaleOverTime = 1f;

	private float minCooldown = 0.06f;

	public ParticleSystem psRing;

	public ParticleSystem psSmoke;

	public ParticleSystem psSnow;

	private ParticleSystem.EmissionModule emissionSmoke;

	private ParticleSystem.EmissionModule emissionSnow;

	private bool inited;

	private float nextCheckDamageTime;

	protected override void Init()
	{
		Transform transform = base.transform;
		defaultRadius = transform.localScale.x;
		UpdateSize();
		UpdateCooldown();
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
		switch (stat)
		{
		case EStat.AttackSpeed:
			UpdateCooldown();
			break;
		case EStat.SizeMultiplier:
			UpdateSize();
			break;
		}
	}

	public override float GetAuraRotationSpeed()
	{
		return 2f;
	}

	private unsafe void UpdateSize()
	{
		//IL_004b: Expected O, but got Ref
		oldRadius = radius;
		scaleTimer = 0f;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num = attackSizeMultiplier * defaultRadius;
		radius = num;
		Transform transform = base.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
	}

	private unsafe void Update()
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

	private void UpdateCooldown()
	{
		float num = (cooldown = WeaponUtility.GetWeaponCooldown(weaponBase));
		if (minCooldown > num)
		{
			cooldown = minCooldown;
		}
		attackMuzzle.Set(1, cooldown);
		RefreshParticles();
	}

	private unsafe void RefreshParticles()
	{
		//IL_0062: Invalid comparison between I4 and F4
		//IL_00ad: Expected F4, but got I4
		//IL_01fe: Invalid comparison between I4 and F4
		//IL_00f3: Expected F4, but got I4
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0144: Invalid comparison between I4 and F4
		//IL_018f: Expected F4, but got I4
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		if (!inited)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
			emissionSmoke = emissionModule;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.EmissionModule emissionModule2 = default(ParticleSystem.EmissionModule);
			emissionSnow = emissionModule2;
		}
		float num = 0.4f - cooldown;
		float num2 = num / 0.34f;
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
		ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[1];
		float num3 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
		float num4 = num3 * -9f;
		float num5 = num4 + 11f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		short count = default(short);
		ParticleSystem.Burst burst = new ParticleSystem.Burst(0f, count);
		ParticleSystem.EmissionModule emissionModule3 = (ParticleSystem.EmissionModule)(this + 104);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		((ParticleSystem.EmissionModule*)emissionModule3)->SetBursts(bursts);
		ParticleSystem.Burst[] bursts2 = new ParticleSystem.Burst[1];
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
		float num6 = num2 * -13f;
		float num7 = num6 + 15f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		short count2 = default(short);
		ParticleSystem.Burst burst2 = new ParticleSystem.Burst(0f, count2);
		ParticleSystem.EmissionModule emissionModule4 = (ParticleSystem.EmissionModule)(this + 112);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		((ParticleSystem.EmissionModule*)emissionModule4)->SetBursts(bursts2);
	}

	private void InitParticles()
	{
		if (!inited)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
			emissionSmoke = emissionModule;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.EmissionModule emissionModule2 = default(ParticleSystem.EmissionModule);
			emissionSnow = emissionModule2;
		}
	}

	private float GetFreezeTime()
	{
		return weaponBase.GetValue(EStat.DurationMultiplier);
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0061: Expected O, but got Ref
		//IL_033f: Expected O, but got I
		//IL_00d1: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_017d: Expected O, but got Ref
		//IL_01b1: Expected O, but got Ref
		//IL_01b1: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_020f: Expected I4, but got F4
		//IL_020f: Expected O, but got I
		//IL_037e: Expected O, but got I
		//IL_0261: Expected O, but got Ref
		//IL_0261: Expected O, but got I
		//IL_027d: Expected O, but got I
		//IL_029c: Expected O, but got Ref
		//IL_02d1: Expected I4, but got F4
		//IL_02d1: Expected O, but got Ref
		//IL_02ee: Expected F4, but got O
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
		attackMuzzle.Play();
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), radius, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120)));
		_ = 1;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
			object obj3 = 0;
			ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			EnemyManager instance = EnemyManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v6+20+v418 @ rbx_v8 (EWeapon)*8]");
			if (instance.GetEnemy((Collider)0, out enemy))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
				if (!((Enemy)0).IsDeadOrDyingNextFrame())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					Transform transform2 = ((Component)0).transform;
					Vector3 position2 = transform2.position;
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					float num3 = position2.x - position3.x;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					WeaponBase obj5 = weaponBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj5, null, (Enemy)0, (Vector3)(&num4), num5);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					((Enemy)0).DamageFromPlayerWeapon(damageContainer);
					float value = weaponBase.GetValue(EStat.DurationMultiplier);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					((Enemy)0).AddDebuff(EDebuff.Freeze, damageContainer, value, (int)num5);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
					object obj6 = 0;
					Transform transform4 = MyPlayer.Instance.transform;
					Vector3 position4 = transform4.position;
					num = position4.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rcx_v30+20+v418 @ rbx_v8 (EWeapon)*8]");
					Vector3 vector = ((Collider)0).ClosestPoint((Vector3)(&x));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
					bool hitEnemy = (Object)0;
					Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rax_v28+8]");
					_ = 0;
					EffectManager.Instance.EnemyHitEffect((Vector3)(&num6), moveDir, hitEnemy, (EWeapon)num5, weaponHitEffect, useSfx);
					_ = 0;
					x = position4.x;
					num4 = (float)obj7;
					num2 = num3;
				}
			}
			eWeapon++;
		}
		while ((int)eWeapon < enemiesInRadiusSafe);
	}
}
