using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MechProjectile : Projectile
{
	private ParticleSystem _MissileVFX;

	private TrailRenderer _Trail;

	private const float Radius = 12f;

	private const float DecelRate = 2f;

	private const float AccelRate = 5f;

	private const float ArmingDuration = 500f;

	private const float VFXScale = 1f;

	private Vector2 _velocity;

	private Vector2 _cachedVelocity;

	private float _cachedWeaponSpeed;

	private bool _isDecelerating;

	private bool _isAccelerating;

	private bool _canExplode;

	private bool _explosionIsOnCooldown;

	private const float ExplosionCooldownDuration = 100f;

	private Timer _movementTimer;

	private Timer _explosionCooldownTimer;

	private EME_Mech1Weapon _trueWeapon;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_040a: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected I4, but got Unknown
		//IL_01f0: Expected O, but got I4
		//IL_0242: Expected O, but got I4
		//IL_0242: Expected O, but got I4
		//IL_027d: Expected O, but got I4
		//IL_02ec: Invalid comparison between I4 and F4
		//IL_02fb: Expected F4, but got I4
		//IL_039d->IL039d: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_03e3;
		}
		nint num = (nint)typeof(EME_Mech1Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v12 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v12 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v80+FFFFFFF8+v68 @ rax_v75*8]");
			if (0 == (nint)typeof(EME_Mech1Weapon))
			{
				obj3 = 1;
				goto IL_03f2;
			}
		}
		obj3 = 0;
		goto IL_03f2;
		IL_03f2:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_03e3;
		IL_03e3:
		_trueWeapon = (EME_Mech1Weapon)trueWeapon;
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
		}
		EnableTrail(enable: false);
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		_speed = 2f;
		if ((object)_weapon != null)
		{
			float num4 = _weapon.PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			_isCullable = true;
			_explosionIsOnCooldown = false;
			int penetrating = (int)(num4 + _penetrating);
			_penetrating = penetrating;
			if ((object)_weapon != null)
			{
				float num5 = _weapon.PArea();
				ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
				ArcadeSprite arcadeSprite2 = setAlpha(1f);
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._checkCollision = (ArcadeBodyCollision)0;
						BaseBody baseBody3 = body;
						if (body != null)
						{
							baseBody3._enable = true;
							if ((object)_weapon != null)
							{
								float num6 = _weapon.PSpeed();
								bool flag2 = 0f > 0.01f;
								float cachedWeaponSpeed = 0f;
								if (!flag2)
								{
									cachedWeaponSpeed = 0.01f;
								}
								_cachedWeaponSpeed = cachedWeaponSpeed;
								SetupMovementPattern();
								float? missileVFX = (float?)_MissileVFX;
								if ((object)_MissileVFX == null)
								{
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rbx_v6 (System.Nullable`1<System.Single>)+10]");
								if ((nint)0 == 0)
								{
									return;
								}
								if ((object)_MissileVFX != null)
								{
									Transform transform = _MissileVFX.transform;
									bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									float2 value = default(float2);
									Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
									_MissileVFX.Play(withChildren: true);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_003e: Invalid comparison between F4 and I
		//IL_0091: Invalid comparison between F4 and I
		//IL_017d: Expected O, but got F4
		//IL_01f1: Expected O, but got F4
		//IL_006d: Expected F4, but got I
		//IL_00c0: Expected F4, but got I
		float num3 = default(float);
		if (_isDecelerating)
		{
			float num = _weapon.PSpeed();
			float num2 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
			bool flag = !(num2 < 0f);
			float num4 = num3;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
				num4 = 0f;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num5 = 2f / num4;
			num3 = deltaTime * num5;
			float num6 = 1f - num3;
			float num7 = (float)_velocity * num6;
			float num8 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
			float num9 = num8 * 0f;
			_velocity = (Vector2)num7;
		}
		if (_isAccelerating)
		{
			float num10 = _weapon.PSpeed();
			float num11 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
			bool flag2 = !(num11 < 0f);
			float num12 = num3;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
				num12 = 0f;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num13 = num12 * 5f;
			float num14 = deltaTime2 * num13;
			float num15 = num14 + 1f;
			float num16 = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
			float num17 = num16 * 0f;
			float num18 = num15 * (float)_velocity;
			_velocity = (Vector2)num18;
		}
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
		_ = 0;
	}

	protected unsafe virtual void SetupMovementPattern()
	{
		//IL_003f: Expected O, but got Ref
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0172: Expected O, but got I8
		//IL_01a6: Invalid comparison between O and F4
		//IL_01b4: Expected F4, but got O
		//IL_0189: Expected O, but got I4
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Vector2 velocity = default(Vector2);
		_velocity = velocity;
		object obj = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj));
		_isDecelerating = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
		_ = 0;
		_cachedVelocity = _velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872230FBh\"");
		if ((object)_velocity == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872230FBh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
			if ((nint)0 == 0)
			{
				Weapon weapon2 = _weapon;
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
				_cachedVelocity = characterController2._lastFacingDirection;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v24 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
				_ = 0;
			}
		}
		Weapon weapon3 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+EC]");
		object obj2 = 0 ^ -0f;
		object obj3 = obj2 ^ -0f;
		object obj4 = _cachedVelocity ^ -0f;
		bool flag = characterController3._isFlipped;
		object obj5 = 4294967295L;
		if (!flag)
		{
			obj5 = 1;
		}
		object obj6 = obj5 * obj4;
		Vector2 vector = (_velocity = (Vector2)(obj5 * obj3));
		_canExplode = false;
		float num = _weapon.PSpeed();
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num2 = (float)vector;
		if (!flag2)
		{
			num2 = 1f;
		}
		Action onComplete = delegate
		{
			//IL_0041: Expected O, but got I4
			//IL_0094: Expected O, but got I4
			BaseBody baseBody = body;
			_velocity = _cachedVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+EC]");
			_ = 0;
			_isDecelerating = false;
			baseBody._checkCollision = (ArcadeBodyCollision)15;
			_canExplode = true;
			EnableTrail(enable: true);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 1, time);
		};
		float num3 = 500f / num2;
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer movementTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_movementTimer = movementTimer;
	}

	private void CaluclateInitialVelocity()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_010a: Expected O, but got I8
		//IL_0121: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872232DFh\"");
		if ((object)_cachedVelocity == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872232DFh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+EC]");
			if ((nint)0 == 0)
			{
				Weapon weapon = _weapon;
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				_cachedVelocity = characterController._lastFacingDirection;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v9 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
				_ = 0;
			}
		}
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+EC]");
		object obj = 0 ^ -0f;
		object obj2 = obj ^ -0f;
		object obj3 = _cachedVelocity ^ -0f;
		bool flag = characterController2._isFlipped;
		object obj4 = 4294967295L;
		if (!flag)
		{
			obj4 = 1;
		}
		Vector2 velocity = (Vector2)(obj2 * obj4);
		object obj5 = obj3 * obj4;
		_velocity = velocity;
	}

	public void InvertVelocity()
	{
		//IL_0034: Expected O, but got F4
		float num = (float)_velocity * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
		float num2 = 0f * -1f;
		_velocity = (Vector2)num;
	}

	public void MultiplyVelocity(float multiplier)
	{
		//IL_0032: Expected O, but got F4
		float num = (float)_velocity * multiplier;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
		float num2 = 0f * multiplier;
		_velocity = (Vector2)num;
	}

	protected void UpdateVelocity()
	{
		//IL_003e: Invalid comparison between F4 and I
		//IL_0091: Invalid comparison between F4 and I
		//IL_017d: Expected O, but got F4
		//IL_01f1: Expected O, but got F4
		//IL_006d: Expected F4, but got I
		//IL_00c0: Expected F4, but got I
		float num3 = default(float);
		if (_isDecelerating)
		{
			float num = _weapon.PSpeed();
			float num2 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
			bool flag = !(num2 < 0f);
			float num4 = num3;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
				num4 = 0f;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num5 = 2f / num4;
			num3 = deltaTime * num5;
			float num6 = 1f - num3;
			float num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
			float num8 = num7 * 0f;
			float num9 = num6 * (float)_velocity;
			_velocity = (Vector2)num9;
		}
		if (_isAccelerating)
		{
			float num10 = _weapon.PSpeed();
			float num11 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
			bool flag2 = !(num11 < 0f);
			float num12 = num3;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10024]");
				num12 = 0f;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num13 = num12 * 5f;
			float num14 = deltaTime2 * num13;
			float num15 = num14 + 1f;
			float num16 = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
			float num17 = num16 * 0f;
			float num18 = num15 * (float)_velocity;
			_velocity = (Vector2)num18;
		}
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+E4]");
		_ = 0;
	}

	protected void SetupTrail()
	{
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
		}
	}

	protected void EnableTrail(bool enable)
	{
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Trail.gameObject;
			gameObject.SetActive(enable);
			_Trail.Clear();
			_Trail.emitting = enable;
		}
	}

	private void PlaySfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 1, time);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null || (_canExplode ? 1 : 0) == (nint)obj || !triggerHit)
		{
			return;
		}
		if ((_explosionIsOnCooldown ? 1 : 0) == (nint)obj)
		{
			EME_Mech1Weapon trueWeapon = _trueWeapon;
			_explosionIsOnCooldown = true;
			float2 float5 = base.position;
			float2 float6 = base.position;
			float2 pos = default(float2);
			Projectile projectile = trueWeapon._basicExplosionPool.SpawnAt(pos, _weapon);
			float num = 100f / _cachedWeaponSpeed;
			if (_explosionCooldownTimer != null)
			{
				_explosionCooldownTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_explosionIsOnCooldown = false;
			};
			float duration = num * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer explosionCooldownTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_explosionCooldownTimer = explosionCooldownTimer;
		}
		if (--_penetrating <= 0)
		{
			Despawn();
		}
	}

	public override void Despawn()
	{
		ParticleSystem missileVFX = _MissileVFX;
		if ((object)_MissileVFX != null && ((UnityEngine.Object)missileVFX).m_CachedPtr != (IntPtr)0)
		{
			_MissileVFX.Clear(withChildren: true);
		}
		EnableTrail(enable: false);
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_explosionCooldownTimer != null)
		{
			_explosionCooldownTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CSetupMovementPattern_003Eb__20_0()
	{
		//IL_0041: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		BaseBody baseBody = body;
		_velocity = _cachedVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_MechProjectile)+EC]");
		_ = 0;
		_isDecelerating = false;
		baseBody._checkCollision = (ArcadeBodyCollision)15;
		_canExplode = true;
		EnableTrail(enable: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 200f, 1, time);
	}

	private void _003COnHasHitAnObjectLogic_003Eb__30_0()
	{
		_explosionIsOnCooldown = false;
	}
}
