using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Bwaka1_Projectile : Projectile
{
	private float _deltaTime;

	private const float _orbitPercentage = 0.125f;

	private const float _orbitModifier = 75f;

	private const float _rotationModifier = 360f;

	private Vector3 _centralPos;

	private Vector3 _velocity;

	private float _rotationInc;

	private float _flipSwitch;

	private bool _cachedFlipX;

	private Timer _durationTimer;

	private Timer _bodyTimer;

	private const float _bodyDisableDuration = 250f;

	protected virtual string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A41E3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_CurvedKnife";
		}
	}

	protected virtual bool InfiniteBounces => false;

	protected virtual float Radius => 12f;

	protected virtual float OrbitRadius => 12f;

	protected override void Awake()
	{
		base.Awake();
		string frameName = FrameName;
		Sprite sprite = SpriteManager.GetSprite(frameName, "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected O, but got I4
		//IL_007a: Expected I4, but got O
		//IL_02dd: Expected I4, but got O
		//IL_03a3: Expected I, but got O
		//IL_0191: Expected F4, but got I4
		//IL_01ac: Expected F4, but got I8
		//IL_0400: Expected O, but got F4
		//IL_028d: Expected F4, but got I4
		//IL_01db->IL0292: Incompatible stack heights: 4 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		if ((object)weapon != null)
		{
			float num = weapon.PArea();
			float xScale = default(float);
			ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setAlpha(1f);
			BaseBody baseBody = body;
			if (body != null)
			{
				baseBody._enable = true;
				int num2 = (int)body;
				float radius = Radius;
				if (body != null)
				{
					int value = ((int*)num2)->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v137 @ rdx_v18 (System.Int32)+218] (should have been resolved before IL gen)");
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						if (!weapon2.IsHoming)
						{
							Transform transform = base.AimForRandomEnemy();
						}
						else
						{
							Transform transform2 = base.AimForNearestEnemy();
						}
						int num3 = (int)_cachedTransform;
						_deltaTime = 0f;
						if ((object)_cachedTransform != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdi_v10 (System.Int32)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdi_v10 (System.Int32)+10]");
							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
							BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
							Vector3 centralPos = default(Vector3);
							_centralPos = centralPos;
							_ = 0;
							bool flag2 = (object)_cachedTransform == null;
							bool flag3 = ((EventEmitter)cachedTransform).callbacks == null;
							Vector3 value2 = default(Vector3);
							Transform.set_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, ref value2);
							VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
							bool flag4 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
							_cachedFlipX = characterController._isFlipped;
							ArcadeSprite arcadeSprite3 = setFlipX(characterController._isFlipped);
							_rotationInc = 0f;
							bool flag5 = _cachedFlipX;
							float num4 = 1f;
							if (!flag5)
							{
								num4 = 4.2949673E+09f;
							}
							_flipSwitch = num4;
							if (_durationTimer != null)
							{
								_durationTimer.Cancel();
							}
							if ((object)_weapon != null)
							{
								float num5 = _weapon.PDuration();
								Action onComplete = StartDespawn;
								float num6 = num4 * 0.001f;
								bool flag6 = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer durationTimer = Timers.Register(num6, onComplete, null, isLooped: false, flag6, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_durationTimer = durationTimer;
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
								{
									Rate = 1.5f
								};
								object obj = UnityEngine.Random.value;
								float num7 = num6 - 0.5f;
								_ = 1;
								float num8 = num7 * (float)_indexInWeapon;
								float num9 = num8 * 200f;
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_BwakaKnife2, soundConfig, 200f, 10, flag6 ? 1 : 0);
								return;
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
		//IL_0005: Expected I, but got O
		//IL_0169: Expected I, but got O
		//IL_017f: Invalid comparison between F4 and O
		//IL_01cf: Expected I, but got O
		//IL_01a7: Expected F4, but got O
		nint num = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		float deltaTime = PauseSystem.DeltaTime;
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm6\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float num2 = 0f * 75f;
		BaseBody baseBody = body;
		float num3 = num2 * deltaTime;
		float num4 = num3 * 0.125f;
		float num5 = num4 * _flipSwitch;
		float num6 = num5 * -1f;
		float deltaTime2 = num6 + _deltaTime;
		_deltaTime = deltaTime2;
		Vector3 vector = default(Vector3);
		_velocity = vector;
		_ = 0;
		float deltaTime3 = PauseSystem.DeltaTime;
		float num7 = 0f * deltaTime3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v5 (BaseBody)+74]");
		float num8 = 0f * deltaTime3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Bwaka1_Projectile)+DC]");
		float num9 = 0f + num7;
		float num10 = (float)vector + num8;
		Weapon weapon = _weapon;
		_centralPos = vector;
		nint num11 = (nint)weapon;
		float num12 = weapon.PArea();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)4.5f) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector);
		float num13 = 4.5f;
		if (!flag)
		{
			num13 = (float)vector;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		nint num14 = (nint)this;
		float orbitRadius = OrbitRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float orbitRadius2 = OrbitRadius;
		Transform cachedTransform = _cachedTransform;
		float num15 = _deltaTime * num13;
		float num16 = _deltaTime * num15;
		float num17 = num16 * 0.01f;
		bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		float projectileSpeed2 = base.ProjectileSpeed;
		float deltaTime4 = PauseSystem.DeltaTime;
		float num18 = num17 * 360f;
		float num19 = num18 * deltaTime4;
		float num20 = num19 * _flipSwitch;
		float rotationInc = num20 + _rotationInc;
		_rotationInc = rotationInc;
		Transform transform = base.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value2 = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
	}

	private void StartDespawn()
	{
		//IL_0056: Expected I, but got O
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_renderer, 0f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Bwaka1_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public override void Despawn()
	{
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			if (!InfiniteBounces)
			{
				int bounces = _bounces - 1;
				_bounces = bounces;
			}
			OnBounce();
		}
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit)
			{
				BaseBody baseBody = body;
				if (baseBody._enable && --_penetrating <= 0)
				{
					Despawn();
				}
			}
			return;
		}
		if (!InfiniteBounces)
		{
			int bounces = _bounces - 1;
			_bounces = bounces;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 151 Invalid \"Jump target not found in method: 0x18708C3B0\"");
		throw new NullReferenceException();
	}

	private void OnBounce()
	{
		//IL_00c9: Expected I, but got O
		nint num = (nint)this;
		Transform transform = base.AimForRandomEnemy();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		float num2 = _flipSwitch * -1f;
		BaseBody baseBody = body;
		_flipSwitch = num2;
		baseBody._enable = false;
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		float projectileSpeed = base.ProjectileSpeed;
		bool flag = num2 > 1f;
		float num3 = num2;
		if (!flag)
		{
			num3 = 1f;
		}
		Action onComplete = delegate
		{
			BaseBody baseBody2 = body;
			baseBody2._enable = true;
		};
		float num4 = 250f / num3;
		float duration = num4 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
	}

	private void _003COnBounce_003Eb__28_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
	}
}
