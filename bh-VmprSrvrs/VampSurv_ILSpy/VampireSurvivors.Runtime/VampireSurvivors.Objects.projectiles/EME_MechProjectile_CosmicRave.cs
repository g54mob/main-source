using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MechProjectile_CosmicRave : Projectile
{
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public EME_MechProjectile_CosmicRave _003C_003E4__this;

		public float duration;

		public Action _003C_003E9__1;

		internal void _003CSetMovementPattern_003Eb__0()
		{
			//IL_0023: Expected O, but got I
			//IL_0093: Expected O, but got I8
			//IL_0112: Expected O, but got I
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave = _003C_003E4__this;
			eME_MechProjectile_CosmicRave._isDecelerating = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave2 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			_003C_003Ec__DisplayClass30_0 obj2 = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				obj2 = (_003C_003Ec__DisplayClass30_0)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v215 @ rax_v9 (should have been resolved before IL gen)");
			eME_MechProjectile_CosmicRave2._turnSpeed = 300f;
			object obj3 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			float num = 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rsi_v3 (System.Object)+E8]");
			float num2 = num / 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rsi_v3 (System.Object)+108]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rsi_v3 (System.Object)+108]");
				((Timer)0).Cancel();
			}
			Action onComplete = ((EME_MechProjectile_CosmicRave)obj3).StartHitboxTimer;
			float num3 = num2 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(num3, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave3 = _003C_003E4__this;
			float num4 = eME_MechProjectile_CosmicRave3._weapon.PDuration();
			Action onComplete2 = _003C_003E9__1;
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave4 = _003C_003E4__this;
			duration = num3;
			if (_003C_003E9__1 == null)
			{
				onComplete2 = (_003C_003E9__1 = delegate
				{
					//IL_0023: Expected O, but got I
					//IL_0093: Expected O, but got I8
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave5 = _003C_003E4__this;
					eME_MechProjectile_CosmicRave5._isAccelerating = true;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj4 = 0;
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave6 = _003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					bool flag2 = (nint)0 != 0;
					_003C_003Ec__DisplayClass30_0 obj5 = this;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj4 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
						obj5 = (_003C_003Ec__DisplayClass30_0)6573110936L;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v174 @ rax_v9 (should have been resolved before IL gen)");
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave7 = _003C_003E4__this;
					eME_MechProjectile_CosmicRave6._turnSpeed = 1f;
					if (eME_MechProjectile_CosmicRave7._hitboxTimer != null)
					{
						eME_MechProjectile_CosmicRave7._hitboxTimer.Cancel();
					}
					_003C_003E4__this.DoScaleOutTween();
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave8 = _003C_003E4__this;
					if (eME_MechProjectile_CosmicRave8._expireTimer != null)
					{
						eME_MechProjectile_CosmicRave8._expireTimer.Cancel();
					}
					Action onComplete3 = _003C_003E4__this.StartDespawn;
					bool useRealTime2 = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					Timer timer2 = Timers.Register(1f, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				});
			}
			float num5 = num3 * 0.001f;
			Timer movementTimer = Timers.Register(num5, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			eME_MechProjectile_CosmicRave4._movementTimer = movementTimer;
		}

		internal void _003CSetMovementPattern_003Eb__1()
		{
			//IL_0023: Expected O, but got I
			//IL_0093: Expected O, but got I8
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave = _003C_003E4__this;
			eME_MechProjectile_CosmicRave._isAccelerating = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave2 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			_003C_003Ec__DisplayClass30_0 obj2 = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				obj2 = (_003C_003Ec__DisplayClass30_0)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v174 @ rax_v9 (should have been resolved before IL gen)");
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave3 = _003C_003E4__this;
			eME_MechProjectile_CosmicRave2._turnSpeed = 1f;
			if (eME_MechProjectile_CosmicRave3._hitboxTimer != null)
			{
				eME_MechProjectile_CosmicRave3._hitboxTimer.Cancel();
			}
			_003C_003E4__this.DoScaleOutTween();
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave4 = _003C_003E4__this;
			if (eME_MechProjectile_CosmicRave4._expireTimer != null)
			{
				eME_MechProjectile_CosmicRave4._expireTimer.Cancel();
			}
			Action onComplete = _003C_003E4__this.StartDespawn;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private SpriteRenderer _CloneSprite;

	private SpriteRenderer _BackgroundSprite;

	private TrailRenderer _Trail;

	private const float Radius = 16f;

	private const float DecelRate = 2f;

	private const float AccelRate = 5f;

	private const float TrailWidth = 0.05f;

	private float _cachedWeaponSpeed;

	private float _currentSpeed;

	private float _turnSpeed;

	private float _scaledTurnSpeed;

	private float _currentAngle;

	private bool _isDecelerating;

	private bool _isTurning;

	private bool _isAccelerating;

	private Timer _movementTimer;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private SpriteAnimation _cloneAnim;

	private EME_Mech1Weapon _trueWeapon;

	private MaterialPropertyBlock _propBlock;

	private MultiTargetTween _tintTween;

	private MultiTargetTween _scaleTween;

	private List<uint> _tints;

	private Timer _vfxTimer;

	private bool _canVFX;

	protected override void Awake()
	{
		base.Awake();
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		IntPtr ptr = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock.m_Ptr = ptr;
		_propBlock = materialPropertyBlock;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00df: Expected I, but got O
		//IL_00e7: Expected I, but got O
		//IL_00f7: Expected O, but got I
		//IL_0177: Expected O, but got I4
		//IL_0133: Expected O, but got I
		//IL_0169: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_029d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		EME_Mech1Weapon trueWeapon;
		object obj3;
		if (spriteTexturesBase.Unitycircle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5AB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("UnityCircle", "UnityCircle");
			_BackgroundSprite.sprite = sprite;
			Weapon weapon2 = _weapon;
			_canVFX = true;
			if ((object)_weapon == null)
			{
				trueWeapon = null;
				goto IL_0318;
			}
			nint num = (nint)typeof(EME_Mech1Weapon);
			nint num2 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rax_v46+FFFFFFF8+v484 @ rax_v41*8]");
				if (0 == (nint)typeof(EME_Mech1Weapon))
				{
					obj3 = 1;
					goto IL_0327;
				}
			}
			obj3 = 0;
			goto IL_0327;
		}
		throw new NullReferenceException();
		IL_0327:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (EME_Mech1Weapon)_weapon;
		}
		goto IL_0318;
		IL_0318:
		_trueWeapon = trueWeapon;
		_speed = 8f;
		float projectileSpeed = base.ProjectileSpeed;
		float num4 = default(float);
		_currentSpeed = num4;
		float num5 = _weapon.PSpeed();
		if (num4 > 0.01f)
		{
			_cachedWeaponSpeed = 0.01f;
			SetScaleToArea(2f);
			_isCullable = false;
		}
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		float scaledTurnSpeed = _turnSpeed * _cachedWeaponSpeed;
		_isDecelerating = false;
		_isAccelerating = false;
		_scaledTurnSpeed = scaledTurnSpeed;
		SetMovementPattern();
		ApplyVelocityTowardsScreenCentre();
		SetupCloneSprite();
		SetCloneTintFill();
		DoBackgroundTintTween();
		SetupTrail();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -50f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_mechmissile, soundConfig, 50f, 1, time);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_02f8: Expected O, but got F4
		//IL_0300: Invalid comparison between O and F4
		//IL_0210: Expected O, but got Ref
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0093->IL02c1: Incompatible stack heights: 1 vs 0
		//IL_0361->IL02c1: Incompatible stack heights: 1 vs 0
		//IL_01fe->IL02c1: Incompatible stack heights: 1 vs 0
		//IL_0234->IL02c1: Incompatible stack heights: 1 vs 0
		//IL_0153->IL02c1: Incompatible stack heights: 1 vs 0
		//IL_0253->IL02c1: Incompatible stack heights: 1 vs 0
		//IL_0194->IL02c1: Incompatible stack heights: 1 vs 0
		//IL_01c0->IL02c1: Incompatible stack heights: 1 vs 0
		UpdateVelocity();
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			TrailRenderer trail = _Trail;
			object obj = default(object);
			float num2 = (float)obj * 0.25f;
			if ((object)_Trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				object obj2 = TrailRenderer.get_startWidth_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
				{
					if ((object)_Trail == null)
					{
						goto IL_02c1;
					}
					float startWidth = _Trail.startWidth;
					float deltaTime = PauseSystem.DeltaTime;
					float num3 = _cachedWeaponSpeed * 0.15f;
					float num4 = num3 * deltaTime;
					float startWidth2 = num4 + startWidth;
					_Trail.startWidth = startWidth2;
				}
				TrailRenderer trueWeapon = (TrailRenderer)(object)_trueWeapon;
				if ((object)_trueWeapon == null || ((UnityEngine.Object)trueWeapon).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0347;
				}
				EME_Mech1Weapon trueWeapon2 = _trueWeapon;
				if ((object)_trueWeapon != null)
				{
					if (!trueWeapon2.UprightCosmicWaveSilhouette)
					{
						goto IL_0347;
					}
					if ((object)_cachedTransform != null)
					{
						Transform transform = _cachedTransform.transform;
						if ((object)transform != null)
						{
							Vector3 eulerAngles = transform.eulerAngles;
							goto IL_0347;
						}
					}
				}
			}
		}
		goto IL_02c1;
		IL_0347:
		if ((object)_CloneSprite != null)
		{
			Transform transform2 = _CloneSprite.transform;
			if ((object)transform2 != null)
			{
				object obj3 = default(object);
				transform2.localEulerAngles = (Vector3)(&obj3);
				BaseBody baseBody = body;
				if (body != null && (object)_CloneSprite != null)
				{
					bool flag2 = 0 < (nint)baseBody._velocity;
					object obj4 = 0 - baseBody._velocity;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					bool flag5 = !flag3;
					bool flag6 = flag5 & flag4;
					_CloneSprite.flipX = flag6;
					return;
				}
			}
		}
		goto IL_02c1;
		IL_02c1:
		throw new NullReferenceException();
	}

	private void ApplyVelocityTowardsScreenCentre()
	{
		//IL_00e0: Expected I, but got O
		//IL_0177: Invalid comparison between O and F4
		//IL_0199: Expected I, but got O
		//IL_01c2: Expected O, but got I
		//IL_0288: Expected F4, but got O
		//IL_0275->IL00cb: Incompatible stack heights: 1 vs 0
		//IL_008b->IL00cb: Incompatible stack heights: 1 vs 0
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float2 float5 = base.position;
				object obj = (object)ret - (object)float5;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
				Vector2 vector;
				object obj5;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
				{
					vector = (Vector2)(obj / (object)Vector2.zeroVector);
					obj5 = obj2 / (object)Vector2.zeroVector;
				}
				else
				{
					nint num3 = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v54 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num4 = 0;
					vector = Vector2.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rcx_v37 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
					obj5 = 0;
				}
				float projectileSpeed = base.ProjectileSpeed;
				float2 velocity = Vector2.zeroVector * vector;
				float projectileSpeed2 = base.ProjectileSpeed;
				ArcadeSprite sprite = _sprite;
				object obj6 = (object)Vector2.zeroVector * obj5;
				if ((object)_sprite != null)
				{
					BaseBody baseBody = sprite.body;
					if (sprite.body != null)
					{
						baseBody._velocity = velocity;
						Transform transform2 = base.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						Quaternion.AngleAxis_Injected((float)this, ref ret, out Quaternion _);
						bool flag2 = (object)transform2 == null;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Quaternion value = default(Quaternion);
						Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						float currentAngle = (float)obj5 * 57.29578f;
						_currentAngle = currentAngle;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetMovementPattern()
	{
		//IL_001d: Expected I, but got O
		//IL_0032: Expected O, but got I
		//IL_0188: Expected O, but got I
		//IL_009e: Expected I, but got I8
		//IL_00dc: Expected I, but got I8
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass30_0();
		CS_0024_003C_003E8__locals20._003C_003E4__this = this;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass30_0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		_isDecelerating = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v132 @ rax_v12 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		_turnSpeed = 15f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			num = unchecked((nint)6573110936L);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v192 @ rax_v15 (should have been resolved before IL gen)");
		DoScaleInTween(CS_0024_003C_003E8__locals20.duration = 325f / _cachedWeaponSpeed);
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		Action onComplete = delegate
		{
			//IL_0023: Expected O, but got I
			//IL_0093: Expected O, but got I8
			//IL_0112: Expected O, but got I
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave = CS_0024_003C_003E8__locals20._003C_003E4__this;
			eME_MechProjectile_CosmicRave._isDecelerating = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave2 = CS_0024_003C_003E8__locals20._003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			_003C_003Ec__DisplayClass30_0 obj4 = CS_0024_003C_003E8__locals20;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex3 = new MissingMethodException();
					throw ex3;
				}
				obj4 = (_003C_003Ec__DisplayClass30_0)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v215 @ rax_v9 (should have been resolved before IL gen)");
			eME_MechProjectile_CosmicRave2._turnSpeed = 300f;
			object obj5 = CS_0024_003C_003E8__locals20._003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			float num2 = 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rsi_v3 (System.Object)+E8]");
			float num3 = num2 / 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rsi_v3 (System.Object)+108]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rsi_v3 (System.Object)+108]");
				((Timer)0).Cancel();
			}
			Action onComplete2 = ((EME_MechProjectile_CosmicRave)obj5).StartHitboxTimer;
			float num4 = num3 * 0.001f;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer timer = Timers.Register(num4, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave3 = CS_0024_003C_003E8__locals20._003C_003E4__this;
			float num5 = eME_MechProjectile_CosmicRave3._weapon.PDuration();
			Action onComplete3 = CS_0024_003C_003E8__locals20._003C_003E9__1;
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave4 = CS_0024_003C_003E8__locals20._003C_003E4__this;
			CS_0024_003C_003E8__locals20.duration = num4;
			if (CS_0024_003C_003E8__locals20._003C_003E9__1 == null)
			{
				onComplete3 = (CS_0024_003C_003E8__locals20._003C_003E9__1 = delegate
				{
					//IL_0023: Expected O, but got I
					//IL_0093: Expected O, but got I8
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave5 = CS_0024_003C_003E8__locals20._003C_003E4__this;
					eME_MechProjectile_CosmicRave5._isAccelerating = true;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj6 = 0;
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave6 = CS_0024_003C_003E8__locals20._003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					bool flag2 = (nint)0 != 0;
					_003C_003Ec__DisplayClass30_0 obj7 = CS_0024_003C_003E8__locals20;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj6 == null)
						{
							MissingMethodException ex4 = new MissingMethodException();
							throw ex4;
						}
						obj7 = (_003C_003Ec__DisplayClass30_0)6573110936L;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v174 @ rax_v9 (should have been resolved before IL gen)");
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave7 = CS_0024_003C_003E8__locals20._003C_003E4__this;
					eME_MechProjectile_CosmicRave6._turnSpeed = 1f;
					if (eME_MechProjectile_CosmicRave7._hitboxTimer != null)
					{
						eME_MechProjectile_CosmicRave7._hitboxTimer.Cancel();
					}
					CS_0024_003C_003E8__locals20._003C_003E4__this.DoScaleOutTween();
					EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave8 = CS_0024_003C_003E8__locals20._003C_003E4__this;
					if (eME_MechProjectile_CosmicRave8._expireTimer != null)
					{
						eME_MechProjectile_CosmicRave8._expireTimer.Cancel();
					}
					Action onComplete4 = CS_0024_003C_003E8__locals20._003C_003E4__this.StartDespawn;
					bool useRealTime3 = default(bool);
					MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
					int repeat3 = default(int);
					TimerType type3 = default(TimerType);
					Timer timer2 = Timers.Register(1f, onComplete4, null, isLooped: false, useRealTime3, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
				});
			}
			float duration2 = num4 * 0.001f;
			Timer movementTimer2 = Timers.Register(duration2, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			eME_MechProjectile_CosmicRave4._movementTimer = movementTimer2;
		};
		float duration = CS_0024_003C_003E8__locals20.duration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer movementTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_movementTimer = movementTimer;
	}

	private void UpdateVelocity()
	{
		//IL_00b6: Expected I4, but got I8
		//IL_003b: Expected I, but got O
		//IL_0211: Expected O, but got I8
		//IL_0182: Expected O, but got F4
		//IL_0261: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected I4, but got Unknown
		//IL_0110: Expected O, but got I4
		//IL_02c9: Expected F4, but got O
		bool flag = !_isDecelerating;
		EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave = this;
		if (!flag)
		{
			Weapon weapon = _weapon;
			nint num = (nint)weapon;
			float num2 = weapon.PSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			object obj2 = default(object);
			object obj = obj2 + obj2;
			float num3 = deltaTime * (float)obj;
			float num4 = 1f - num3;
			float currentSpeed = num4 * _currentSpeed;
			_currentSpeed = currentSpeed;
			eME_MechProjectile_CosmicRave = null;
		}
		if (_isTurning)
		{
			int num5 = (int)(_indexInWeapon & 0x80000001L);
			if ((_isTurning ? 1 : 0) < (false ? 1 : 0))
			{
				object obj3 = num5 - 1;
				object obj4 = obj3 | -2;
				num5 = obj4 + 1;
			}
			float num6 = (_scaledTurnSpeed = _turnSpeed * _cachedWeaponSpeed);
			float deltaTime2 = PauseSystem.DeltaTime;
			bool flag2 = num5 == 1;
			EME_MechProjectile_CosmicRave eME_MechProjectile_CosmicRave2 = (EME_MechProjectile_CosmicRave)4294967295L;
			if (!flag2)
			{
				eME_MechProjectile_CosmicRave2 = (EME_MechProjectile_CosmicRave)1;
			}
			float currentSpeed = (float)eME_MechProjectile_CosmicRave2 * num6;
			float num7 = deltaTime2 * currentSpeed;
			float currentAngle = _currentAngle - num7;
			_currentAngle = currentAngle;
			eME_MechProjectile_CosmicRave = (EME_MechProjectile_CosmicRave)1;
		}
		if (_isAccelerating)
		{
			float deltaTime3 = PauseSystem.DeltaTime;
			float num8 = deltaTime3 * 5f;
			float num9 = num8 + 1f;
			float currentSpeed2 = num9 * _currentSpeed;
			_currentSpeed = currentSpeed2;
			eME_MechProjectile_CosmicRave = null;
		}
		float num10 = _currentAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num11 = num10 * _currentSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		ArcadeSprite sprite = _sprite;
		float num12 = num10 * _currentSpeed;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num11;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void StartHitboxTimer()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		float num = 1000f / _cachedWeaponSpeed;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		Action onComplete = StartHitboxTimer;
		float duration = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
	}

	private void StopHitboxTimer()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
	}

	private void SetupCloneSprite()
	{
		//IL_0121: Expected O, but got I
		//IL_0136: Expected O, but got I
		//IL_01de: Expected I4, but got O
		SpriteRenderer cloneSprite = _CloneSprite;
		if ((object)_CloneSprite == null || ((UnityEngine.Object)cloneSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
		if (obj == null)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = core2._dataManager.GetConvertedCharacterData();
			obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)1);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v20 (System.Object)+18]");
		string textureName;
		string text;
		int end;
		int fps;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v20 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rcx_v19+20]");
			CharacterData characterData = (CharacterData)0;
			if (characterData._003Cskins_003Ek__BackingField == null)
			{
				bool flag = (object)characterData._003CwalkFrameRate_003Ek__BackingField == null;
				textureName = characterData._003CtextureName_003Ek__BackingField;
				text = characterData._003CspriteName_003Ek__BackingField;
				end = characterData._003CwalkingFrames_003Ek__BackingField;
				if (!flag)
				{
					if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
					{
						fps = (object?)characterData._003CwalkFrameRate_003Ek__BackingField >> 32;
						goto IL_0221;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					goto IL_0344;
				}
			}
			else
			{
				Skin currentSkinData = characterData.GetCurrentSkinData();
				textureName = currentSkinData._003CtextureName_003Ek__BackingField;
				text = currentSkinData._003CspriteName_003Ek__BackingField;
				end = currentSkinData._003CwalkingFrames_003Ek__BackingField;
			}
			fps = 8;
			goto IL_0221;
		}
		goto IL_0344;
		IL_0221:
		string animName = text.Replace("01.png", "");
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, textureName, num);
		SpriteAnimation cloneAnim = _cloneAnim;
		if ((object)_cloneAnim == null || ((UnityEngine.Object)cloneAnim).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = _CloneSprite.gameObject;
			SpriteAnimation cloneAnim2 = gameObject.AddComponent<SpriteAnimation>();
			_cloneAnim = cloneAnim2;
		}
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_cloneAnim.AddAnimation("walk", animationFrames, fps, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_cloneAnim.SetAnimation("walk");
		return;
		IL_0344:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void UpdateCloneSprite()
	{
		//IL_00ae: Expected O, but got Ref
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		EME_Mech1Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null && ((UnityEngine.Object)trueWeapon).m_CachedPtr != (IntPtr)0)
		{
			EME_Mech1Weapon trueWeapon2 = _trueWeapon;
			if (trueWeapon2.UprightCosmicWaveSilhouette)
			{
				Transform transform = _cachedTransform.transform;
				Vector3 eulerAngles = transform.eulerAngles;
			}
		}
		Transform transform2 = _CloneSprite.transform;
		object obj = default(object);
		transform2.localEulerAngles = (Vector3)(&obj);
		BaseBody baseBody = body;
		bool flag = 0 < (nint)baseBody._velocity;
		object obj2 = 0 - baseBody._velocity;
		bool flag2 = obj2 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		_CloneSprite.flipX = flag5;
	}

	private void SetupTrail()
	{
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			float saturationMax = default(float);
			float valueMin = default(float);
			float valueMax = default(float);
			float alphaMin = default(float);
			Color color = UnityEngine.Random.ColorHSV(0.6f, 0.7f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
			Color color2 = UnityEngine.Random.ColorHSV(0.8f, 0.9f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			float num = _weapon.PArea();
			_Trail.time = 0.8f;
			object obj = default(object);
			float startWidth = (float)obj * 0.05f;
			_Trail.startWidth = startWidth;
			_Trail.endWidth = 0.025f;
			Sprite sprite = default(Sprite);
			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
			Material material = ((Renderer)_Trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 1f);
			_Trail.Clear();
			_Trail.emitting = true;
			Gradient gradient = new Gradient();
			IntPtr ptr = Gradient.Init();
			gradient.m_Ptr = ptr;
			gradient.m_RequiresNativeCleanup = true;
			GradientColorKey[] colorKeys = new GradientColorKey[2];
			_ = color.r;
			_ = 0;
			_ = color2.r;
			_ = 1f;
			GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
			_ = 1061997773;
			_ = 0;
			_ = 1065353216;
			gradient.SetKeys(colorKeys, alphaKeys);
			_Trail.colorGradient = gradient;
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
		}
	}

	private void UpdateTrail()
	{
		//IL_012a: Expected O, but got F4
		//IL_0132: Invalid comparison between O and F4
		//IL_008d->IL00f3: Incompatible stack heights: 1 vs 0
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			TrailRenderer trail = _Trail;
			object obj = default(object);
			float num2 = (float)obj * 0.25f;
			if ((object)_Trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				object obj2 = TrailRenderer.get_startWidth_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
				{
					return;
				}
				if ((object)_Trail != null)
				{
					float startWidth = _Trail.startWidth;
					float deltaTime = PauseSystem.DeltaTime;
					float num3 = _cachedWeaponSpeed * 0.15f;
					float num4 = num3 * deltaTime;
					float startWidth2 = num4 + startWidth;
					_Trail.startWidth = startWidth2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SetCloneTintFill()
	{
		//IL_007f: Expected O, but got Ref
		SpriteRenderer cloneSprite = _CloneSprite;
		if ((object)_CloneSprite != null && ((UnityEngine.Object)cloneSprite).m_CachedPtr != (IntPtr)0)
		{
			if (ColorUtility.DoTryParseHtmlColor("#555555", out Color32 _))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
				object obj = default(object);
				RenderingExtensions.SetTint(_CloneSprite, (Color?)(object)(&obj));
			}
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_CloneSprite, 0.75f);
		}
	}

	private void DoBackgroundTintTween()
	{
		//IL_00c7: Expected I, but got O
		//IL_0135: Expected O, but got I4
		SpriteRenderer backgroundSprite = _BackgroundSprite;
		if ((object)_BackgroundSprite == null || ((UnityEngine.Object)backgroundSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_BackgroundSprite, 0.25f);
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_BackgroundSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A570");
		tweenConfig.duration = 250f;
		tweenConfig.tint = (uint?)(object)1;
		TweenCallback onComplete = DoBackgroundTintTween;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tintTween = Tweens.Add(tweenConfig);
		_tintTween = tintTween;
	}

	private void DoScaleInTween(float duration)
	{
		//IL_0080: Expected I, but got O
		//IL_00f7: Expected O, but got I4
		//IL_0054->IL0119: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0119: Incompatible stack heights: 1 vs 0
		//IL_00a3->IL00a3: Incompatible stack heights: 2 vs 1
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_cachedTransform != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj = default(object);
					bool flag2 = obj == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.duration = duration;
					tweenConfig.scale = (float?)(object)1;
					MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
					_scaleTween = scaleTween;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void DoScaleOutTween()
	{
		//IL_0080: Expected I, but got O
		//IL_00f8: Expected O, but got I4
		//IL_0054->IL011a: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL011a: Incompatible stack heights: 1 vs 0
		//IL_00a3->IL00a3: Incompatible stack heights: 2 vs 1
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_cachedTransform != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj = default(object);
					bool flag2 = obj == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.duration = 500f;
					tweenConfig.scale = (float?)(object)1;
					MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
					_scaleTween = scaleTween;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_0119: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		SpriteRenderer cloneSprite = _CloneSprite;
		if ((object)_CloneSprite != null && ((UnityEngine.Object)cloneSprite).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_CloneSprite, 0f);
		}
		SpriteRenderer backgroundSprite = _BackgroundSprite;
		if ((object)_BackgroundSprite != null && ((UnityEngine.Object)backgroundSprite).m_CachedPtr != (IntPtr)0)
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_BackgroundSprite, 0f);
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile_CosmicRave>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public override void Despawn()
	{
		if (_movementTimer != null)
		{
			_movementTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0054: Expected O, but got I4
		//IL_0116: Expected I4, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_cosmicrave, soundConfig, 500f, 1, num);
		if (_canVFX)
		{
			_canVFX = false;
			if (_vfxTimer != null)
			{
				_vfxTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canVFX = true;
			};
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer vfxTimer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_vfxTimer = vfxTimer;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			EME_iCosmicRaveVFX eME_iCosmicRaveVFX = default(EME_iCosmicRaveVFX);
			if (eME_iCosmicRaveVFX != null)
			{
				float2 float5 = base.position;
				eME_iCosmicRaveVFX.DisplayCosmicRaveVFX(float5);
			}
		}
	}

	public EME_MechProjectile_CosmicRave()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0563: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_058b: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_05b3: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_05db: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0603: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_062b: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0653: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_067b: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_06a3: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_06cb: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_06f3: Expected O, but got I
		//IL_0510: Expected O, but got I
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16711680u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16711680;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(16744192u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 16744192;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16776960u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 16776960;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(8388352u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 8388352;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(65280u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 65280;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(65407u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 65407;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(65535u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 65535;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(32767u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 32767;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(255u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 255;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(8323327u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 8323327;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(16711935u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 16711935;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			list.AddWithResize(16711807u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 16711807;
		}
		_tints = list;
		base._002Ector();
	}

	private void _003COnHasHitAnObject_003Eb__44_0()
	{
		_canVFX = true;
	}
}
