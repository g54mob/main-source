using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
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

public class Ex_Ammo1Projectile : Projectile
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

	private bool _isMirrored;

	public override float ProjectileSpeed
	{
		get
		{
			//IL_0048: Expected O, but got F4
			float num = _weapon.PSpeed();
			float num3 = default(float);
			float num2 = GameManager.ProjectileSpeed * num3;
			float num4 = num2 * _speed;
			object obj = Time.timeScale;
			return num4 / num3;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mainVisuals.enabled = false;
		trail.enabled = false;
		_speed = 2f;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_01ee: Expected O, but got Ref
		//IL_012c: Expected I, but got O
		//IL_013c: Expected O, but got I
		BulletPool pool2 = default(BulletPool);
		base.InitProjectile(pool2, weapon, index);
		Weapon weapon2;
		if ((object)weapon == null)
		{
			weapon2 = null;
			goto IL_028a;
		}
		nint num = (nint)typeof(Ex_Ammo1Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v63+FFFFFFF8+v61 @ rax_v58*8]");
			if (0 == (nint)typeof(Ex_Ammo1Weapon))
			{
				obj3 = 1;
				goto IL_0299;
			}
		}
		obj3 = 0;
		goto IL_0299;
		IL_0299:
		bool flag = obj3 == null;
		pool2 = (BulletPool)(object)typeof(Ex_Ammo1Weapon);
		weapon2 = null;
		if (!flag)
		{
			pool2 = (BulletPool)(object)typeof(Ex_Ammo1Weapon);
			weapon2 = weapon;
		}
		goto IL_028a;
		IL_028a:
		trueWeapon = (Ex_Ammo1Weapon)weapon2;
		Ex_Ammo1Weapon ex_Ammo1Weapon = trueWeapon;
		if ((object)trueWeapon != null && ((UnityEngine.Object)ex_Ammo1Weapon).m_CachedPtr != (IntPtr)0)
		{
			Ex_Ammo1Weapon ex_Ammo1Weapon2 = trueWeapon;
			nint num4 = (nint)ex_Ammo1Weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon>)+5C0]");
			pool2 = (BulletPool)0;
			if (!ex_Ammo1Weapon2.FireInTheFacedDirection)
			{
				_isMirrored = true;
			}
		}
		Weapon weapon3 = _weapon;
		GameManager core = GM.Core;
		float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
		float num5 = _weapon.PArea();
		if (_isMirrored)
		{
		}
		object obj4 = default(object);
		float maxRange = (float)obj4 * 1.6f;
		object obj5 = default(object);
		bool checkLeft = default(bool);
		EnemyController targetEnemyController = core._stage.FindClosestLateralEnemy((Vector3)(&obj5), excludeDead: true, maxRange, checkLeft);
		_targetEnemyController = targetEnemyController;
		EnemyController targetEnemyController2 = _targetEnemyController;
		if ((object)_targetEnemyController != null && ((UnityEngine.Object)targetEnemyController2).m_CachedPtr != (IntPtr)0)
		{
			SetupMechanics();
		}
		else
		{
			Despawn();
		}
	}

	private unsafe EnemyController FindTargetEnemy()
	{
		//IL_00e1: Expected O, but got Ref
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				if ((object)_weapon != null)
				{
					float num = _weapon.PArea();
					if (_isMirrored)
					{
					}
					if ((object)core._stage != null)
					{
						object obj = default(object);
						float maxRange = (float)obj * 1.6f;
						object obj2 = default(object);
						bool checkLeft = default(bool);
						return core._stage.FindClosestLateralEnemy((Vector3)(&obj2), excludeDead: true, maxRange, checkLeft);
					}
				}
			}
		}
		return (EnemyController)(object)new NullReferenceException();
	}

	private void SetupMechanics()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0082: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_009d: Expected I, but got O
		//IL_0128: Expected O, but got I4
		//IL_0188: Expected O, but got F4
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(mainVisuals, 2f);
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
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float num8 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.EX_AMMO_SINGLESHOT, soundConfig, 200f, 12, num8);
		Vector2 vector = default(Vector2);
		ApplyInitialVelocity(vector, vector, rotate: true, (Vector3?)(object)num8);
		mainVisuals.enabled = true;
		trail.enabled = true;
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
	}

	private unsafe void ApplyInitialVelocity(Vector2 targetPosition, Vector2 firePosition, bool rotate = true, Vector3? customFromPosition = null)
	{
		//IL_006e: Expected O, but got I
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector2 value = default(Vector2);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		object obj = default(object);
		if (obj != null)
		{
		}
		EnemyController targetEnemyController = _targetEnemyController;
		BaseBody baseBody = targetEnemyController.body;
		object obj2 = baseBody._velocity * baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rcx_v13 (BaseBody)+74]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rcx_v13 (BaseBody)+74]");
		object obj3 = num * 0;
		object obj4 = obj2 + obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj5 = default(object);
		Vector2 vector = default(Vector2);
		if (obj5 == null)
		{
			Vector2 leadAimPosition = GetLeadAimPosition(firePosition, targetPosition, vector);
		}
		SetProjectileVelocity(vector, rotate);
	}

	public override void Despawn()
	{
		mainVisuals.enabled = false;
		trail.enabled = false;
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	private Vector2 GetLeadAimPosition(Vector2 firePosition, Vector2 targetPosition, Vector2 targetVelocity)
	{
		//IL_004c: Expected I, but got O
		//IL_0136: Invalid comparison between I4 and F4
		//IL_0153: Invalid comparison between I4 and F4
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_017a: Expected F4, but got I4
		//IL_0227: Invalid comparison between F4 and I4
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		object obj4 = targetPosition - firePosition;
		float projectileSpeed = ProjectileSpeed;
		nint num = (nint)this;
		object obj6 = default(object);
		object obj5 = obj6 * obj6;
		object obj8 = default(object);
		object obj7 = obj8 * obj8;
		object obj9 = obj5 + obj7;
		float projectileSpeed2 = ProjectileSpeed;
		object obj11 = default(object);
		object obj10 = obj11 * obj11;
		object obj12 = obj9 - obj10;
		object obj13 = obj6 * obj;
		object obj14 = obj8 * obj4;
		object obj15 = obj13 + obj14;
		object obj16 = obj15 + obj15;
		object obj17 = obj * obj;
		float num2 = (float)obj12 * 4f;
		object obj18 = obj4 * obj4;
		object obj19 = obj16 * obj16;
		object obj20 = obj17 + obj18;
		float num3 = (float)obj20 * num2;
		float num4 = (float)obj19 - num3;
		Vector2 result = default(Vector2);
		if (!(0f > num4))
		{
			float num5;
			if (!(0f > num4))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
				num5 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				num5 = num4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj21 = obj16 ^ 0;
			object obj22 = obj12 + obj12;
			object obj23 = obj12 + obj12;
			float num6 = num5 / (float)obj22;
			object obj24 = obj21 / obj23;
			float num7 = (float)obj24 + num6;
			float num8 = (float)obj24 - num6;
			if (!(num8 > num7) || num7 > 0f)
			{
				return result;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		float projectileSpeed3 = ProjectileSpeed;
		return result;
	}

	private void SetProjectileVelocity(Vector2 projectileDirection, bool rotate)
	{
		//IL_00eb: Expected F4, but got O
		//IL_00dd->IL00a2: Incompatible stack heights: 1 vs 0
		Vector2 vector = default(Vector2);
		vector.Normalize();
		float projectileSpeed = ProjectileSpeed;
		object obj = default(object);
		float2 velocity = (object)projectileDirection * obj;
		object obj3 = default(object);
		object obj2 = obj3 * obj;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = velocity;
		if (rotate)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Vector3 axis = default(Vector3);
			Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02bb: Expected O, but got Ref
		//IL_032e: Expected O, but got Ref
		//IL_0356: Expected O, but got I
		//IL_0369: Expected O, but got Ref
		//IL_0381: Invalid comparison between O and F4
		//IL_0453: Expected O, but got Ref
		//IL_0479: Expected O, but got Ref
		//IL_021d: Expected O, but got Ref
		//IL_022b: Expected O, but got Ref
		//IL_0239: Expected O, but got Ref
		//IL_03a3: Expected I, but got O
		//IL_03c3: Expected O, but got I
		//IL_03dc: Expected I, but got O
		//IL_03ea: Expected O, but got Ref
		//IL_03fd: Expected O, but got Ref
		//IL_02f1->IL0248: Incompatible stack heights: 1 vs 0
		//IL_00fc->IL0248: Incompatible stack heights: 1 vs 0
		//IL_0125->IL0248: Incompatible stack heights: 1 vs 0
		//IL_0147->IL0248: Incompatible stack heights: 1 vs 0
		//IL_018b->IL0248: Incompatible stack heights: 1 vs 0
		//IL_01cc->IL0248: Incompatible stack heights: 1 vs 0
		//IL_0445->IL0282: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		EnemyController targetEnemyController = _targetEnemyController;
		if ((object)_targetEnemyController == null || ((UnityEngine.Object)targetEnemyController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EnemyController targetEnemyController2 = _targetEnemyController;
		if ((object)_targetEnemyController != null)
		{
			if (targetEnemyController2._003CIsDead_003Ek__BackingField || targetEnemyController2.body == null)
			{
				return;
			}
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				EnemyController targetEnemyController3 = _targetEnemyController;
				if ((object)_targetEnemyController != null && targetEnemyController3.body != null)
				{
					EnemyController targetEnemyController4 = _targetEnemyController;
					if ((object)_targetEnemyController != null && targetEnemyController4.body != null)
					{
						Vector2 vector = default(Vector2);
						Vector2 leadAimPosition = GetLeadAimPosition(vector, vector, vector);
						BaseBody baseBody = body;
						if (body != null)
						{
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
							Transform transform2 = base.transform;
							if ((object)transform2 != null)
							{
								_ = 0;
								_ = 0;
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj4);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
								object obj5 = -0;
								object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
								if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
								{
									object obj7 = obj5 / (object)vector;
									object obj8 = obj7;
								}
								else
								{
									nint num = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rax_v53 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rcx_v44 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
									object obj8 = 0;
									_ = Vector3.zeroVector;
								}
								Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								_ = 0;
								Quaternion quaternion2 = Quaternion.LookRotation(forward);
								Vector3 forward2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Quaternion quaternion3 = Quaternion.LookRotation(forward2);
								_ = quaternion2.x;
								_ = quaternion3.x;
								float deltaTime = PauseSystem.DeltaTime;
								float num3 = deltaTime * 360f;
								object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
								object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1870D8E20");
								nint num4 = (nint)typeof(Vector3);
								Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Quaternion quaternion4 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rax_v45 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num5 = 0;
								_ = Vector3.forwardVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v46 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
								_ = 0;
								Vector3 vector3 = quaternion4 * vector2;
								SetProjectileVelocity(vector, rotate: true);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe static void FireDirectlyAtTarget(Vector2 targetPosition, Vector2 playerPosition, ref Vector2 projectileDirection)
	{
		object obj = targetPosition - playerPosition;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		ref Vector2 reference = ref *(Vector2*)obj;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0042: Expected I, but got O
		//IL_004a: Expected I, but got O
		//IL_005a: Expected O, but got I
		//IL_00da: Expected O, but got I4
		//IL_0096: Expected O, but got I
		//IL_00cc: Expected O, but got I4
		//IL_0126: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)other;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v3 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v3 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v21+FFFFFFF8+v164 @ rax_v6*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj4 = 1;
				goto IL_0166;
			}
		}
		obj4 = 0;
		goto IL_0166;
		IL_0166:
		bool flag = obj4 == null;
		IDamageable damageable = null;
		if (!flag)
		{
			damageable = other;
		}
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdi_v3 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0 && penetrationAmount > 0f)
			{
				float num4 = penetrationAmount - 1f;
				penetrationAmount = num4;
				return;
			}
		}
		Despawn();
	}
}
