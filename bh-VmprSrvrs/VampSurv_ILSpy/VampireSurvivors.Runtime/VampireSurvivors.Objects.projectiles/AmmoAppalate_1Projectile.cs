using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class AmmoAppalate_1Projectile : Projectile
{
	private SpriteRenderer mainVisuals;

	private SpriteTrail trail;

	private float _hitboxSize = 8f;

	private const float MAX_HOMING_ANGLE_CHANGE_PER_SECOND = 360f;

	private float penetrationAmount;

	protected EnemyController _targetEnemyController;

	private SpriteAnimation _anims;

	private Timer _prefireTimer;

	private Bounds _camBounds;

	private Ex_Ammo1Weapon trueWeapon;

	private float _IndexOffsetScaleFactor = 0.1f;

	public override float ProjectileSpeed
	{
		get
		{
			//IL_0079: Expected O, but got F4
			float num = _weapon.PSpeed();
			float num3 = default(float);
			float num2 = num3 * GameManager.ProjectileSpeed;
			float num4 = num2 * _speed;
			bool flag = !(7f > num4);
			float num5 = 7f;
			if (!flag)
			{
				num5 = num4;
			}
			object obj = Time.timeScale;
			return num5 / num3;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mainVisuals.enabled = false;
		trail.enabled = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_039e: Expected O, but got I
		//IL_0071: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0433: Expected I, but got O
		//IL_0443: Expected O, but got I
		//IL_0541: Expected O, but got F4
		//IL_0498: Expected O, but got F4
		//IL_0533->IL031a: Incompatible stack heights: 1 vs 0
		//IL_03f8->IL050f: Incompatible stack heights: 2 vs 1
		int index2 = default(int);
		BulletPool pool2 = default(BulletPool);
		base.InitProjectile(pool2, weapon, index2);
		_speed = 2f;
		_IndexOffsetScaleFactor = 0.05f;
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		Weapon weapon3 = weapon;
		if (flag)
		{
			goto IL_0373;
		}
		nint num = (nint)typeof(Ex_Ammo1Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v44 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v105+FFFFFFF8+v62 @ rax_v101*8]");
			if (0 == (nint)typeof(Ex_Ammo1Weapon))
			{
				obj3 = 1;
				goto IL_0382;
			}
		}
		obj3 = 0;
		goto IL_0382;
		IL_0382:
		bool flag2 = obj3 == null;
		weapon2 = null;
		weapon3 = (Weapon)num2;
		pool2 = (BulletPool)(object)typeof(Ex_Ammo1Weapon);
		if (!flag2)
		{
			weapon2 = weapon;
			weapon3 = (Weapon)num2;
			pool2 = (BulletPool)(object)typeof(Ex_Ammo1Weapon);
		}
		goto IL_0373;
		IL_0373:
		trueWeapon = (Ex_Ammo1Weapon)weapon2;
		BaseBody baseBody = body;
		Vector3 value = default(Vector3);
		if (body != null)
		{
			baseBody._enable = false;
			Weapon weapon4 = _weapon;
			if ((object)_weapon != null)
			{
				if (!weapon4.IsHoming)
				{
					float2 float5 = base.position;
					if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
					{
						float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
						object obj5 = default(object);
						object obj6 = default(object);
						object obj4 = obj5 - obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
						Weapon weapon5 = (Weapon)(object)body;
						float projectileSpeed = ProjectileSpeed;
						object obj7 = default(object);
						object obj8 = default(object);
						GameManager gameMan = (GameManager)(obj7 * obj8);
						object obj9 = obj5 * obj8;
						if (body != null)
						{
							weapon5._gameMan = gameMan;
							object cachedTransform = _cachedTransform;
							if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
							{
								float2 float7 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
								bool flag3 = (object)_cachedTransform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rsi_v23 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rsi_v23 (System.Object)+10]");
								Transform.set_position_Injected((IntPtr)0, ref value);
								goto IL_050f;
							}
						}
					}
				}
				else
				{
					object cachedTransform2 = _cachedTransform;
					if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
					{
						float2 float8 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rsi_v21 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rsi_v21 (System.Object)+10]");
						Transform.set_position_Injected((IntPtr)0, ref value);
						nint num4 = (nint)this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ rax_v80 (Il2CppClass<VampireSurvivors.Objects.Projectiles.AmmoAppalate_1Projectile>)+3B0]");
						weapon3 = (Weapon)0;
						Transform transform = base.AimForNearestEnemy(rotate: false);
						goto IL_050f;
					}
				}
			}
		}
		goto IL_031a;
		IL_050f:
		Weapon cachedTransform3 = (Weapon)(object)_cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag6 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, out Vector3 _);
			object obj10 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj11 = UnityEngine.Random.value;
			object cachedTransform4 = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			bool flag7 = (object)_cachedTransform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1182 @ rsi_v19 (System.Object)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1182 @ rsi_v19 (System.Object)+10]");
			Transform.set_position_Injected((IntPtr)0, ref value);
			SetupMechanics();
			return;
		}
		goto IL_031a;
		IL_031a:
		throw new NullReferenceException();
	}

	private void SetupMechanics()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0087: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_00a2: Expected I, but got O
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(mainVisuals, 2f, 2f);
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * _hitboxSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = num2 ^ 0;
		float num3 = (float)obj2 * 0.5f;
		BaseBody baseBody = body.setCircle(num2, (float?)(object)1, (float?)(object)1);
		Weapon weapon = _weapon;
		nint num4 = (nint)weapon;
		float num5 = weapon.PSpeed();
		float num6 = num3 - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		Weapon weapon2 = _weapon;
		WeaponData currentWeaponData = weapon2._currentWeaponData;
		object obj3 = default(object);
		float num7 = (float)currentWeaponData._003Cpenetrating_003Ek__BackingField + (float)obj3;
		penetrationAmount = num7;
		mainVisuals.enabled = true;
		trail.enabled = true;
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
	}

	public override void Despawn()
	{
		mainVisuals.enabled = false;
		trail.enabled = false;
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0042: Expected I, but got O
		//IL_004a: Expected I, but got O
		//IL_005a: Expected O, but got I
		//IL_00da: Expected O, but got I4
		//IL_0096: Expected O, but got I
		//IL_00cc: Expected O, but got I4
		//IL_01ce: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)other;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r8_v4 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r8_v4 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v28+FFFFFFF8+v277 @ rax_v7*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj4 = 1;
				goto IL_020e;
			}
		}
		obj4 = 0;
		goto IL_020e;
		IL_020e:
		bool flag = obj4 == null;
		IDamageable damageable = null;
		if (!flag)
		{
			damageable = other;
		}
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdi_v5 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				HashSet<IDamageable> objectsHit = _objectsHit;
				if (objectsHit._count == 1 && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
				{
					Weapon weapon = _weapon;
					GameManager gameMan = weapon._gameMan;
					float2 float5 = base.position;
					Vector2 pos = default(Vector2);
					gameMan._arcanaManager.TriggerFireExplosion(pos);
				}
				if (penetrationAmount > 0f)
				{
					float num4 = penetrationAmount - 1f;
					penetrationAmount = num4;
					return;
				}
			}
		}
		Despawn();
	}
}
