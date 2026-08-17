using System;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_CrossbowCrashProjectile : Projectile
{
	private FB_CrossbowCrashWeapon _crossbowCrash;

	private MultiTargetTween _fadeOutTween;

	private Tween _damageOnlyTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _fadeOutTimer;

	private MultiTargetTween _scaleTween;

	private VampireSurvivors.Framework.TimerSystem.Timer _hitboxTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0035: Expected I, but got O
		//IL_003d: Expected I, but got O
		//IL_004d: Expected O, but got I
		//IL_00cd: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_0543: Expected O, but got I4
		//IL_0089: Expected O, but got I
		//IL_00ef: Expected O, but got I4
		//IL_00bf: Expected O, but got I4
		//IL_0153: Expected I4, but got I8
		//IL_02e5: Expected I, but got O
		//IL_0345: Expected O, but got I4
		//IL_0369: Expected O, but got I4
		//IL_03a2: Expected I4, but got O
		//IL_05ef: Expected O, but got F4
		//IL_060c: Expected I4, but got F4
		//IL_04d9: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		float? crossbowCrash;
		if ((object)weapon == null)
		{
			crossbowCrash = (float?)(object)0;
			goto IL_051c;
		}
		nint num = (nint)typeof(FB_CrossbowCrashWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_CrossbowCrashWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_CrossbowCrashWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v116+FFFFFFF8+v70 @ rax_v111*8]");
			if (0 == (nint)typeof(FB_CrossbowCrashWeapon))
			{
				obj3 = 1;
				goto IL_052b;
			}
		}
		obj3 = 0;
		goto IL_052b;
		IL_052b:
		bool flag = obj3 == null;
		crossbowCrash = (float?)(object)0;
		if (!flag)
		{
			crossbowCrash = (float?)weapon;
		}
		goto IL_051c;
		IL_051c:
		_crossbowCrash = (FB_CrossbowCrashWeapon)crossbowCrash;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = true;
			_isCullable = false;
			ArcadeSprite arcadeSprite2 = setAlpha(0.55f);
			ArcadeSprite arcadeSprite3 = setDepth(-1);
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			if ((object)_weapon != null)
			{
				float hitBoxDelay = _weapon.HitBoxDelay;
				Action onComplete = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				};
				float duration = hitBoxDelay * 0.001f;
				bool flag2 = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				VampireSurvivors.Framework.TimerSystem.Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_hitboxTimer = hitboxTimer;
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if (array != null)
				{
					if ((object)_cachedTransform != null)
					{
						void* value = ((IntPtr*)(&array))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj4 = default(object);
						if (obj4 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
						if ((object)_weapon != null)
						{
							float num4 = _weapon.PArea();
							if ((object)_crossbowCrash != null)
							{
								((Weapon)(object)tweenConfig)._currentWeaponData = (WeaponData)1;
								Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
								((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1140457472;
								((Weapon)(object)tweenConfig)._skipAddingEvolution = true;
								MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
								_scaleTween = scaleTween;
								int num5 = (int)_cachedTransform;
								if ((object)_weapon != null)
								{
									Transform transform = _weapon.transform;
									if ((object)transform != null)
									{
										bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
										bool flag4 = (object)_cachedTransform == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rbp_v12 (System.Int32)+10]");
										bool flag5 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rbp_v12 (System.Int32)+10]");
										Vector3 value2 = default(Vector3);
										Transform.set_position_Injected((IntPtr)0, ref value2);
										if (_fadeOutTimer != null)
										{
											_fadeOutTimer.Cancel();
										}
										bool flag6 = (object)_weapon == null;
										float num6 = _weapon.PDuration();
										Action onComplete2 = delegate
										{
											//IL_006c: Expected I, but got O
											//IL_00d0: Expected O, but got I4
											//IL_00eb: Expected I, but got O
											BaseBody baseBody2 = body;
											baseBody2._enable = false;
											if (_fadeOutTween != null)
											{
												_fadeOutTween.Kill();
											}
											TweenConfig tweenConfig2 = new TweenConfig();
											object[] array2 = new object[1];
											nint num9 = (nint)array2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj6 = default(object);
											if (obj6 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												tweenConfig2.targets = array2;
												tweenConfig2.duration = 1000f;
												tweenConfig2.alpha = (float?)(object)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_CrossbowCrashProjectile>)+370]");
												TweenCallback onComplete3 = new TweenCallback(this, (IntPtr)0);
												nint num10 = (nint)this;
												tweenConfig2.onComplete = onComplete3;
												MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig2);
												_fadeOutTween = fadeOutTween;
												return;
											}
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										};
										float num7 = (float)ret * 0.001f;
										VampireSurvivors.Framework.TimerSystem.Timer fadeOutTimer = Timers.Register(num7, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
										_fadeOutTimer = fadeOutTimer;
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
										{
											Rate = 1f
										};
										object obj5 = UnityEngine.Random.value;
										float num8 = num7 * 500f;
										((GameMonoBehaviour)(object)soundConfig)._onPauseSent = (byte)(int)num8 != 0;
										_ = 1;
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Song, soundConfig, 150f, 3, flag2 ? 1 : 0);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		Transform cachedTransform = _cachedTransform;
		if ((object)_weapon != null)
		{
			Transform transform = _weapon.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		bool flag = _hitboxTimer == null;
		_isCullable = true;
		if (!flag)
		{
			_hitboxTimer.Cancel();
		}
		if (_fadeOutTimer != null)
		{
			_fadeOutTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		base.Despawn();
	}

	private void Shoot()
	{
		if (_fadeOutTimer != null)
		{
			_fadeOutTimer.Cancel();
		}
		float num = _weapon.PDuration();
		Action onComplete = delegate
		{
			//IL_006c: Expected I, but got O
			//IL_00d0: Expected O, but got I4
			//IL_00eb: Expected I, but got O
			BaseBody baseBody = body;
			baseBody._enable = false;
			if (_fadeOutTween != null)
			{
				_fadeOutTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = array;
				tweenConfig.duration = 1000f;
				tweenConfig.alpha = (float?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_CrossbowCrashProjectile>)+370]");
				TweenCallback onComplete2 = new TweenCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				tweenConfig.onComplete = onComplete2;
				MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
				_fadeOutTween = fadeOutTween;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		};
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer fadeOutTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_fadeOutTimer = fadeOutTimer;
	}

	private void _003CInitProjectile_003Eb__7_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CShoot_003Eb__10_0()
	{
		//IL_006c: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		//IL_00eb: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_CrossbowCrashProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
			_fadeOutTween = fadeOutTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}
}
