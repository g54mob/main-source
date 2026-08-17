using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_BloodProjectile : Projectile
{
	private List<Color> _tints;

	private List<BlendMode> _blendModes;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _scaleTween;

	private ParticleSystem _damageVfx;

	private ParticleEmitterManager _particlesManager;

	private GravityWell _well;

	private Timer bloodTimer;

	private Timer expireTimer;

	private PhaserSprite _displaySprite;

	private EnemyController _myTarget;

	private bool _targetFound;

	private Vector2 targetPosition;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_020e: Expected O, but got Ref
		//IL_0228: Expected native int or pointer, but got O
		//IL_024d: Expected O, but got Ref
		//IL_0267: Expected native int or pointer, but got O
		//IL_0299: Expected O, but got Ref
		//IL_02b3: Expected native int or pointer, but got O
		//IL_02eb: Expected O, but got Ref
		//IL_0305: Expected native int or pointer, but got O
		//IL_0421: Expected O, but got I
		//IL_0461->IL0579: Incompatible stack heights: 2 vs 0
		//IL_04a8->IL0579: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		PhaserWorld instance = PhaserWorld.Instance;
		if ((object)instance != null)
		{
			Vector2 pos = default(Vector2);
			PhaserSprite displaySprite = instance.AddPhaserSprite(pos, "Emeralds_VFX", "eme_fx_sanguine");
			_displaySprite = displaySprite;
			if ((object)_displaySprite != null)
			{
				PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
				Transform parent = base.transform;
				if ((object)_displaySprite != null)
				{
					Transform transform = _displaySprite.transform;
					if ((object)transform != null)
					{
						transform.SetParent(parent, worldPositionStays: true);
						if ((object)_displaySprite != null)
						{
							Transform transform2 = _displaySprite.transform;
							bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
							ParticleSystemConfig config = new ParticleSystemConfig("vfx");
							List<string> list = new List<string>();
							list._002Ector();
							int version = list._version + 1;
							list._version = version;
							string[] items = list._items;
							if (list._size >= items.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"WhiteDot");
							}
							else
							{
								int num = list._size + 1;
								list._size = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							_ = 0;
							_ = 10;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
							_ = 0;
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(300f, 350f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
							_ = 0;
							minMaxCurve = new ParticleSystem.MinMaxCurve(200f);
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 16711680;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
							_ = 0;
							_ = 0;
							GameObject gameObject = base.gameObject;
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdi_v14 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							_ = 0;
							bool flag2 = (object)gameObject == null;
							ParticleEmitterManager particlesManager;
							if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192))))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
								particlesManager = (ParticleEmitterManager)0;
							}
							else
							{
								particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
							}
							_particlesManager = particlesManager;
							if ((object)_particlesManager != null)
							{
								ParticleSystem damageVfx = _particlesManager.CreateEmitter(config, null, "EMEBloodEmitter");
								_damageVfx = damageVfx;
								if ((object)_damageVfx != null)
								{
									Transform transform3 = _damageVfx.transform;
									bool flag3 = (object)transform3 == null;
									bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
									GravityWellConfig gravityWellConfig = new GravityWellConfig();
									bool flag5 = gravityWellConfig == null;
									((GameMonoBehaviour)(object)gravityWellConfig)._onPauseSent = false;
									_ = 1114636288;
									((PhaserWorld)(object)gravityWellConfig)._EnableHideFlags = false;
									bool flag6 = (object)_particlesManager == null;
									GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
									_well = well;
									bool flag7 = (object)_well == null;
									Transform transform4 = _well.transform;
									bool flag8 = (object)transform4 == null;
									bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Vector2 value2 = default(Vector2);
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&value2));
									ArcadeSprite arcadeSprite = setVisible(visible: false);
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

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = false;
		_targetFound = false;
		_damageVfx.Stop();
		_damageVfx.Clear(withChildren: true);
		if (bloodTimer != null)
		{
			bloodTimer.Cancel();
		}
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
	}

	private unsafe void LateUpdate()
	{
		//IL_007b: Expected O, but got Ref
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Ref, but got Unknown
		//IL_01b7: Expected O, but got I
		//IL_03ff->IL037e: Incompatible stack heights: 1 vs 0
		if (_targetFound)
		{
			return;
		}
		GameManager core = GM.Core;
		Vector2 ret;
		Vector2 vector;
		if ((object)GM.Core != null)
		{
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdi_v6 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdi_v6 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
					if ((object)core._stage != null)
					{
						object obj = default(object);
						EnemyController myTarget = core._stage.FindClosestEnemy((Vector3)(&obj));
						_myTarget = myTarget;
						object myTarget2 = _myTarget;
						if ((object)_myTarget != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdi_v7 (System.Object)+10]");
							if ((nint)0 != 0)
							{
								EnemyController myTarget3 = _myTarget;
								if ((object)_myTarget != null)
								{
									if (myTarget3._003CIsDead_003Ek__BackingField || myTarget3.body == null)
									{
										goto IL_01bc;
									}
									_targetFound = true;
									if ((object)_myTarget != null)
									{
										BaseBody baseBody = myTarget3.body;
										if (myTarget3.body != null)
										{
											vector = baseBody._position;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v55 (BaseBody)+54]");
											object obj2 = 0;
											goto IL_037e;
										}
									}
								}
								goto IL_02f7;
							}
						}
						goto IL_01bc;
					}
				}
			}
		}
		goto IL_02f7;
		IL_01bc:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)core2._stage != null)
			{
				ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)weapon)._003COwner_003Ek__BackingField + 176);
				Transform transform = core2._stage.PickRandomEnemy(ref rng);
				if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
				{
					_targetFound = true;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					object obj3 = default(object);
					object obj2 = obj3;
					vector = ret;
					goto IL_037e;
				}
				return;
			}
		}
		goto IL_02f7;
		IL_02f7:
		throw new NullReferenceException();
		IL_037e:
		targetPosition = vector;
		Activate();
	}

	public void Activate()
	{
		//IL_0023: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_0153: Expected O, but got I
		//IL_025e: Expected I, but got O
		//IL_02e4: Expected O, but got I4
		//IL_0251->IL0450: Incompatible stack heights: 1 vs 0
		//IL_02a3->IL0450: Incompatible stack heights: 2 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = true;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			ArcadeSprite sprite = _sprite;
			if ((object)_sprite != null)
			{
				BaseBody baseBody2 = sprite.body;
				if (sprite.body != null)
				{
					List<Color> list = (List<Color>)(object)baseBody2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v98 @ rdx_v9 (System.Collections.Generic.List`1<UnityEngine.Color>)+218] (should have been resolved before IL gen)");
					ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
					PhaserSprite displaySprite = _displaySprite;
					if ((object)_displaySprite != null)
					{
						List<Color> tints = _tints;
						object spriteRenderer = displaySprite._spriteRenderer;
						if (_tints != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v19 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
							object obj;
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BD30");
								object obj2 = default(object);
								obj = obj2;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
								obj = 0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v7 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v7 (System.Object)+10]");
							Color value = default(Color);
							SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
							PhaserSprite phaserSprite = _displaySprite.setAlpha(0.9f);
							BlendMode blendMode = Extensions.PickRnd(_blendModes);
							PhaserSprite phaserSprite2 = _displaySprite.setBlendMode(blendMode);
							float num = _weapon.PArea();
							float num2 = (float)obj * 0.16f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_BloodProjectile)+130]");
							float num3 = 0f + num2;
							float2 float5 = default(float2);
							base.position = float5;
							_isCullable = false;
							if (_scaleTween != null)
							{
								_scaleTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							if (array != null)
							{
								nint num4 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj3 = default(object);
								bool flag2 = obj3 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array;
									tweenConfig.duration = 100f;
									tweenConfig.ease = Ease.InOutSine;
									tweenConfig.scale = (float?)(object)1;
									TweenCallback onComplete = FadeOut;
									tweenConfig.onComplete = onComplete;
									MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
									_scaleTween = scaleTween;
									RenderingExtensions.Start(_damageVfx);
									if (bloodTimer != null)
									{
										bloodTimer.Cancel();
									}
									Action onComplete2 = delegate
									{
										_damageVfx.Stop();
									};
									bool useRealTime = default(bool);
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType type = default(TimerType);
									Timer timer = Timers.Register(0.25f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									bloodTimer = timer;
									if (expireTimer != null)
									{
										expireTimer.Cancel();
									}
									Action onComplete3 = delegate
									{
										Despawn();
									};
									Timer timer2 = Timers.Register(1f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									expireTimer = timer2;
									OnTargetHit();
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

	public virtual void OnTargetHit()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		Weapon weapon = _weapon;
		if ((object)_weapon == null)
		{
			return;
		}
		nint num = (nint)typeof(EME_Blood1Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v10+FFFFFFF8+v45 @ rax_v3*8]");
			if (0 == (nint)typeof(EME_Blood1Weapon))
			{
				obj3 = 1;
				goto IL_0116;
			}
		}
		obj3 = 0;
		goto IL_0116;
		IL_0116:
		bool flag = obj3 == null;
		EME_Blood1Weapon eME_Blood1Weapon = null;
		if (!flag)
		{
			eME_Blood1Weapon = (EME_Blood1Weapon)_weapon;
		}
		if ((object)eME_Blood1Weapon != null)
		{
			float2 float5 = base.position;
			float areaMul = default(float);
			eME_Blood1Weapon.SpawnSpecialProjectiles(float5, eME_Blood1Weapon._basicBloodPool, 1f, areaMul);
		}
	}

	public override void Despawn()
	{
		_damageVfx.Clear(withChildren: true);
		if (bloodTimer != null)
		{
			bloodTimer.Cancel();
		}
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	private void FadeOut()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
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
		tweenConfig.duration = 50f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	public EME_BloodProjectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0213: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_023b: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0263: Expected O, but got I
		//IL_01c0: Expected O, but got I
		List<BlendMode> list = new List<BlendMode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Particles.BlendMode>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 0;
		}
		_blendModes = list;
		base._002Ector();
	}

	private void _003CActivate_003Eb__16_0()
	{
		_damageVfx.Stop();
	}

	private void _003CActivate_003Eb__16_1()
	{
		Despawn();
	}

	private void _003CFadeOut_003Eb__19_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
