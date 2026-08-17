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

public class CombatAura : ConstantAttack
{
	private float defaultRadius;

	public ParticleSystem[] particles;

	private Color[] defaultColors;

	private float radius;

	private float cooldown;

	private float oldRadius;

	private float scaleTimer;

	private float scaleOverTime = 1f;

	private float fadeMultiplier = 0.25f;

	private float minSizeMultiplier = 1.5f;

	private float maxSizeMultiplier = 8f;

	private float minCooldown = 0.04f;

	private float nextCheckDamageTime;

	protected override void Init()
	{
		//IL_0036: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		ParticleSystem[] array = particles;
		Color[] array2 = new Color[array.Length];
		defaultColors = array2;
		ParticleSystem[] array3 = particles;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array3.Length)
		{
			ParticleSystem[] array4 = particles;
			Color[] array5 = defaultColors;
			Color startColor = array4[obj].startColor;
			object obj3 = obj + 1;
			object obj4 = obj + 2;
			object obj5 = obj4 + obj4;
			_ = startColor.r;
			array3 = particles;
			obj = obj3;
			obj2 = obj3;
		}
		Transform transform = base.transform;
		defaultRadius = transform.localScale.x;
		UpdateSize();
		float num = (cooldown = WeaponUtility.GetWeaponCooldown(weaponBase));
		if (minCooldown > num)
		{
			cooldown = minCooldown;
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
		switch (stat)
		{
		case EStat.AttackSpeed:
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 24 Invalid \"Jump target not found in method: 0x1803534A0\"");
			break;
		default:
			return;
		case EStat.SizeMultiplier:
			break;
		}
		UpdateSize();
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
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_00e6: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_0164: Expected O, but got Ref
		//IL_01a5: Expected O, but got Ref
		//IL_01a5: Expected O, but got I
		//IL_01c3: Expected O, but got I
		//IL_01dd: Expected F4, but got O
		//IL_0242: Expected O, but got Ref
		//IL_0287: Expected O, but got I
		//IL_02a5: Expected O, but got Ref
		//IL_02db: Expected I4, but got F4
		//IL_02db: Expected O, but got Ref
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_02f8: Expected F4, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		if (nextCheckDamageTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + cooldown;
		nextCheckDamageTime = num;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float x = position.x;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), radius, out var buffer);
		_ = 1;
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		WeaponBase weaponBase = null;
		num2 = position.x;
		WeaponBase weaponBase2 = null;
		float num3 = default(float);
		float num4 = default(float);
		object obj5 = default(object);
		float num5 = default(float);
		GameObject weaponHitEffect = default(GameObject);
		bool useSfx = default(bool);
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[(object)weaponBase2], out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
				if (!((Enemy)0).IsDeadOrDyingNextFrame())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
					Transform transform2 = ((Component)0).transform;
					Vector3 position2 = transform2.position;
					Transform transform3 = base.transform;
					Vector3 position3 = transform3.position;
					x = position2.x - position3.x;
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rax_v27+8]");
					_ = 0;
					WeaponBase obj4 = base.weaponBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj4, null, (Enemy)0, (Vector3)(&num3), num4);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
					((Enemy)0).DamageFromPlayerWeapon(damageContainer);
					bool flag = (nint)weaponBase >= 20;
					num3 = (float)obj5;
					num2 = x;
					if (!flag)
					{
						Transform transform4 = MyPlayer.Instance.transform;
						Vector3 position4 = transform4.position;
						num = position4.x;
						Vector3 position5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
						_ = position4.x;
						_ = position4.z;
						Vector3 vector = buffer[(object)weaponBase2].ClosestPointOnBounds(position5);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
						bool hitEnemy = (Object)0;
						Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
						_ = 0;
						EffectManager.Instance.EnemyHitEffect((Vector3)(&num5), moveDir, hitEnemy, (EWeapon)num4, weaponHitEffect, useSfx);
						weaponBase = (WeaponBase)(weaponBase + 1);
						_ = 0;
						num3 = (float)obj5;
						num2 = x;
						x = vector.x;
					}
				}
			}
			weaponBase2 = (WeaponBase)(weaponBase2 + 1);
		}
		while ((nint)weaponBase2 < enemiesInRadiusSafe);
	}
}
