using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Icicle2_Projectile : Projectile
{
	private const float BodyRadius = 24f;

	private const float Percentage = 0.0625f;

	private const float Radius = 0.5f;

	private const float SpeedModifier = 35f;

	private float _deltaTime;

	private readonly List<SpriteTextureData> _icicleSprites;

	private TP_Icicle2_Weapon _trueWeapon;

	private PhaserSprite _crystalSprite;

	private PhaserSprite _icicleSprite;

	private readonly float[] _requiemRandomOffsets;

	private int _requiemRandomIndex;

	private float _crystalAngle1;

	private float _crystalAngle2;

	private float _crystalAngle3;

	private float _crystalRotSpeedMod;

	private Tween _scaleTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	protected override void Awake()
	{
		//IL_0188: Expected O, but got I4
		//IL_0529: Expected O, but got I4
		//IL_055f: Expected O, but got F4
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Expected O, but got Unknown
		//IL_03f9: Expected O, but got F4
		//IL_02c6->IL0408: Incompatible stack heights: 1 vs 0
		//IL_02f5->IL0408: Incompatible stack heights: 1 vs 0
		//IL_031f->IL0408: Incompatible stack heights: 1 vs 0
		//IL_035b->IL0408: Incompatible stack heights: 1 vs 0
		//IL_0579->IL0408: Incompatible stack heights: 3 vs 0
		//IL_0402->IL052e: Incompatible stack heights: 4 vs 3
		base.Awake();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
					if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1625]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						GameObject gameObject = base.gameObject;
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Icicle01");
						if ((object)phaserSprite != null)
						{
							PhaserSprite phaserSprite2 = phaserSprite.setScale(0.65f, (float?)(object)0);
							if ((object)phaserSprite2 != null)
							{
								PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.65f);
								if ((object)phaserSprite3 != null)
								{
									PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
									if ((object)phaserSprite4 != null)
									{
										GameObject gameObject2 = phaserSprite4.gameObject;
										if ((object)gameObject2 != null)
										{
											((UnityEngine.Object)gameObject2).SetName("_crystalSprite");
											_crystalSprite = phaserSprite4;
											if ((object)_crystalSprite != null)
											{
												Transform transform = _crystalSprite.transform;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1357 @ rax_v58 (UnityEngine.Transform)+10]");
												bool flag = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1357 @ rax_v58 (UnityEngine.Transform)+10]");
												Vector3 value = default(Vector3);
												Transform.set_localPosition_Injected((IntPtr)0, ref value);
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AABCC0");
												GameObject gameObject3 = base.gameObject;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
												object obj = default(object);
												PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, (string)obj, (string)obj);
												if ((object)phaserSprite5 != null)
												{
													PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(1f);
													if ((object)phaserSprite6 != null)
													{
														GameObject gameObject4 = phaserSprite6.gameObject;
														if ((object)gameObject4 != null)
														{
															((UnityEngine.Object)gameObject4).SetName("_icicleSprite");
															_icicleSprite = phaserSprite6;
															if ((object)_icicleSprite != null)
															{
																Transform transform2 = _icicleSprite.transform;
																bool flag2 = (object)transform2 == null;
																Vector3 vector = Vector3.zeroVector;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1536 @ rax_v77 (UnityEngine.Transform)+10]");
																bool flag3 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1536 @ rax_v77 (UnityEngine.Transform)+10]");
																Vector3 value2 = default(Vector3);
																Transform.set_localPosition_Injected((IntPtr)0, ref value2);
																float? num = (float?)(object)0;
																while (true)
																{
																	SpriteRenderer requiemRandomOffsets = (SpriteRenderer)(object)_requiemRandomOffsets;
																	object obj2 = UnityEngine.Random.value;
																	if (_requiemRandomOffsets == null)
																	{
																		break;
																	}
																	float? num2 = num;
																	UnityEvent<SpriteRenderer> spriteChangeEvent = requiemRandomOffsets.m_SpriteChangeEvent;
																	bool flag4 = System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num2) >= System.Runtime.CompilerServices.Unsafe.As<UnityEvent<SpriteRenderer>, UIntPtr>(ref spriteChangeEvent);
																	float? num3 = (float?)(object)((_003F?)num + 1);
																	float num4 = (float)vector * 0.5f;
																	float num5 = num4 * 32f;
																	bool flag5 = (nint)num3 < 500;
																	num = num3;
																	vector = (Vector3)num5;
																	if (!flag5)
																	{
																		return;
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_02b4: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_028d;
		}
		nint num = (nint)typeof(TP_Icicle2_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v8 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v8 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v46+FFFFFFF8+v65 @ rax_v41*8]");
			if (0 == (nint)typeof(TP_Icicle2_Weapon))
			{
				obj3 = 1;
				goto IL_029c;
			}
		}
		obj3 = 0;
		goto IL_029c;
		IL_029c:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_028d;
		IL_028d:
		_trueWeapon = (TP_Icicle2_Weapon)trueWeapon;
		_isCullable = false;
		float num4 = _weapon.PAmount();
		object obj4 = default(object);
		float num5 = (float)Math.PI * 2f / (float)obj4;
		float deltaTime = num5 * (float)_indexInWeapon;
		_deltaTime = deltaTime;
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		InitSprites();
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		float num6 = _trueWeapon.PArea();
		float num7 = (float)_indexInWeapon * 0.3f;
		float endValue = num7 + 1f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
		StartTimers();
	}

	private void InitSprites()
	{
		//IL_005c: Expected O, but got F4
		//IL_00c8: Expected O, but got F4
		//IL_0091: Expected O, but got F4
		//IL_00ff: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AABCC0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		object obj = default(object);
		PhaserSprite phaserSprite = _icicleSprite.setFrame((string)obj, (string)obj);
		PhaserSprite phaserSprite2 = _icicleSprite.setVisible(visible: true);
		object obj2 = UnityEngine.Random.value;
		object obj3 = obj + obj;
		float num = (_crystalAngle1 = (float)obj3 * (float)Math.PI);
		object obj4 = UnityEngine.Random.value;
		float num2 = num + num;
		float num3 = (_crystalAngle2 = num2 * (float)Math.PI);
		object obj5 = UnityEngine.Random.value;
		float num4 = num3 + num3;
		float num5 = (_crystalAngle3 = num4 * (float)Math.PI);
		object obj6 = UnityEngine.Random.value;
		float crystalRotSpeedMod = num5 + 1f;
		_crystalRotSpeedMod = crystalRotSpeedMod;
	}

	private void ScaleIn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		float num = _trueWeapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * 0.3f;
		float endValue = num2 + 1f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
	}

	private void StartTimers()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			if (_objectsHit != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			}
		};
		float num = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num2 = _weapon.PDuration();
		Action onComplete2 = Expire;
		float duration = num * 0.001f;
		Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00bc: Expected O, but got I4
		//IL_0191: Expected O, but got Ref
		UpdatePosition();
		UpdateRotation();
		if (_scaleTween == null)
		{
			goto IL_007e;
		}
		Tween scaleTween = _scaleTween;
		if (scaleTween._003Cactive_003Ek__BackingField)
		{
			if (scaleTween.isComplete)
			{
				goto IL_007e;
			}
		}
		else if (Debugger._logPriority > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DAF]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Debugger.LogWarning("This Tween has been killed and is now invalid");
		}
		goto IL_00c5;
		IL_00c5:
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * 2.1618f;
		float num3 = num * 1.6181f;
		float crystalAngle = num2 + _crystalAngle2;
		float crystalAngle2 = num + _crystalAngle1;
		float crystalAngle3 = num3 + _crystalAngle3;
		_crystalAngle2 = crystalAngle;
		_crystalAngle1 = crystalAngle2;
		_crystalAngle3 = crystalAngle3;
		Transform transform = _crystalSprite.transform;
		float num4 = _crystalRotSpeedMod + _crystalRotSpeedMod;
		object obj = default(object);
		transform.Rotate((Vector3)(&obj), num4, Space.Self);
		return;
		IL_007e:
		float num5 = _trueWeapon.PArea();
		object obj2 = default(object);
		float num6 = (float)obj2 * 0.3f;
		float xScale = num6 + 1f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		goto IL_00c5;
	}

	private void UpdatePosition()
	{
		//IL_010d: Expected I, but got O
		if ((object)_weapon != null)
		{
			float num = _weapon.PSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float num2 = (float)obj * 35f;
			Weapon weapon = _weapon;
			float num3 = deltaTime * num2;
			float num4 = num3 * 0.0625f;
			float deltaTime2 = num4 + _deltaTime;
			_deltaTime = deltaTime2;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Weapon weapon2 = _weapon;
					bool flag2 = (object)_weapon == null;
					nint num5 = (nint)weapon2;
					float num6 = _weapon.PArea();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					object cachedTransform = _cachedTransform;
					bool flag3 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v8 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v8 (System.Object)+10]");
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)0, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateRotation()
	{
		//IL_0099: Invalid comparison between O and F4
		//IL_022d: Expected F4, but got O
		//IL_017b: Expected O, but got Ref
		//IL_01f6->IL017c: Incompatible stack heights: 1 vs 0
		//IL_0164->IL017c: Incompatible stack heights: 1 vs 0
		float2 float5 = base.position;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			object obj = float5 - float6;
			object obj3 = default(object);
			object obj4 = default(object);
			object obj2 = obj3 - obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			object obj5 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
			{
				object obj6 = obj / obj5;
				object obj7 = obj2 / obj5;
			}
			else
			{
				object obj7 = obj5;
				object obj6 = obj5;
			}
			if ((object)_icicleSprite != null)
			{
				Transform transform = _icicleSprite.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Vector3 axis = default(Vector3);
				Quaternion.AngleAxis_Injected((float)_icicleSprite, ref axis, out Quaternion _);
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Timer expireTimer = _expireTimer;
				float timeRemaining = _expireTimer.GetTimeRemaining();
				float num = timeRemaining / expireTimer._003CDuration_003Ek__BackingField;
				if (0.5f > num || (object)_icicleSprite != null)
				{
					Transform transform2 = _icicleSprite.transform;
					if ((object)transform2 != null)
					{
						transform2.Rotate((Vector3)(&axis), Space.Self);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateScale()
	{
		//IL_00ab: Expected O, but got I4
		if (_scaleTween != null)
		{
			Tween scaleTween = _scaleTween;
			if (!scaleTween._003Cactive_003Ek__BackingField)
			{
				if (Debugger._logPriority > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DAF]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Debugger.LogWarning("This Tween has been killed and is now invalid");
				}
				return;
			}
			if (!scaleTween.isComplete)
			{
				return;
			}
		}
		float num = _trueWeapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * 0.3f;
		float xScale = num2 + 1f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
	}

	private unsafe void UpdateCrystal()
	{
		//IL_00cc: Expected O, but got Ref
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * 2.1618f;
		float num3 = num * 1.6181f;
		float crystalAngle = num2 + _crystalAngle2;
		float crystalAngle2 = num + _crystalAngle1;
		float crystalAngle3 = num3 + _crystalAngle3;
		_crystalAngle2 = crystalAngle;
		_crystalAngle1 = crystalAngle2;
		_crystalAngle3 = crystalAngle3;
		Transform transform = _crystalSprite.transform;
		float num4 = _crystalRotSpeedMod + _crystalRotSpeedMod;
		object obj = default(object);
		transform.Rotate((Vector3)(&obj), num4, Space.Self);
	}

	private void Expire()
	{
		//IL_00b1: Expected I, but got O
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 0f, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Icicle2_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
		PhaserSprite phaserSprite = _icicleSprite.setVisible(visible: false);
		LaunchIcicle();
		ExplodeOnExpire();
	}

	private void LaunchIcicle()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_0119: Expected O, but got I
		//IL_0147: Expected I, but got O
		//IL_0155: Expected I, but got O
		//IL_0165: Expected O, but got I
		//IL_01e5: Expected O, but got I4
		//IL_01a1: Expected O, but got I
		//IL_01d7: Expected O, but got I4
		//IL_0259: Expected O, but got I
		//IL_0273: Expected O, but got I
		//IL_028e: Expected O, but got I
		Weapon weapon = _weapon;
		nint num = (nint)typeof(TP_Icicle2_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+130]");
		Projectile projectile;
		Projectile projectile2;
		object obj7;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v5+FFFFFFF8+v52 @ rax_v4*8]");
			if (0 == (nint)typeof(TP_Icicle2_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle2_Weapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v5+FFFFFFF8+v231 @ rcx_v4*8]");
				object obj4 = 0 - typeof(TP_Icicle2_Weapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				Weapon weapon2 = null;
				if (!flag2)
				{
					weapon2 = weapon;
				}
				float2 float5 = base.position;
				float2 float6 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v6 (VampireSurvivors.Objects.Weapons.Weapon)+178]");
				float2 pos = default(float2);
				projectile = ((BulletPool)0).SpawnAt(pos, _weapon);
				bool flag3 = (object)projectile == null;
				projectile2 = null;
				if (!flag3)
				{
					nint num4 = (nint)projectile;
					nint num5 = (nint)typeof(TP_Icicle2_LaunchProjectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Icicle2_LaunchProjectile>)+130]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Icicle2_LaunchProjectile>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v35+FFFFFFF8+v334 @ rax_v31*8]");
						if (0 == (nint)typeof(TP_Icicle2_LaunchProjectile))
						{
							obj7 = 1;
							goto IL_0338;
						}
					}
					obj7 = 0;
					goto IL_0338;
				}
				goto IL_035f;
			}
		}
		throw new NullReferenceException();
		IL_0338:
		bool flag4 = obj7 == null;
		projectile2 = null;
		if (!flag4)
		{
			projectile2 = projectile;
		}
		goto IL_035f;
		IL_035f:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite icicleSprite = _icicleSprite;
			Sprite sprite = icicleSprite._spriteRenderer.sprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v3 (VampireSurvivors.Objects.Projectiles.Projectile)+D0]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v18+28]");
			((SpriteRenderer)0).sprite = sprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdi_v3 (VampireSurvivors.Objects.Projectiles.Projectile)+D0]");
			PhaserSprite phaserSprite = ((PhaserSprite)0).setVisible(visible: true);
			float2 float7 = base.position;
			Weapon weapon3 = _weapon;
			float2 float8 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
			object obj9 = float7 - float8;
			object obj10 = default(object);
			object obj11 = default(object);
			float angleAim = (float)obj10 - (float)obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			projectile2.ApplyAngleVelocity(angleAim);
		}
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private unsafe void ExplodeOnExpire()
	{
		//IL_00b1: Expected O, but got I4
		//IL_012a: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0247: Expected O, but got I
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0444->IL033a: Incompatible stack heights: 1 vs 0
		//IL_00f5->IL033a: Incompatible stack heights: 1 vs 0
		//IL_0199->IL033a: Incompatible stack heights: 2 vs 0
		//IL_01cf->IL033a: Incompatible stack heights: 2 vs 0
		//IL_0487->IL033a: Incompatible stack heights: 3 vs 0
		//IL_0212->IL033a: Incompatible stack heights: 3 vs 0
		//IL_02b6->IL033a: Incompatible stack heights: 4 vs 0
		//IL_02e7->IL033a: Incompatible stack heights: 4 vs 0
		//IL_0334->IL03df: Incompatible stack heights: 4 vs 0
		//IL_0339->IL0339: Incompatible stack heights: 4 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			if (!weapon._explodeOnExpire)
			{
				return;
			}
			float num = _weapon.SecondaryPAmount();
			float2 float5 = default(float2);
			if ((nint)float5 <= 0)
			{
				return;
			}
			float2 float6 = (float2)0;
			float2 pos = default(float2);
			while (true)
			{
				Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
				if ((object)cachedTrans == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (body != null)
				{
					BaseBody baseBody = body;
					ArcadeTransform arcadeTransform = baseBody._transform;
					if (baseBody._transform == null)
					{
						break;
					}
					arcadeTransform.position = ret;
				}
				float[] requiemRandomOffsets = _requiemRandomOffsets;
				int requiemRandomIndex = _requiemRandomIndex + 1;
				_requiemRandomIndex = requiemRandomIndex;
				if (_requiemRandomOffsets == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
				object obj = (nint)(&ret) >> 5;
				object obj2 = obj >> 31;
				object obj3 = obj + obj2;
				object obj4 = obj3 * 500;
				object obj5 = _requiemRandomIndex - obj4;
				bool flag2 = (nint)obj5 >= requiemRandomOffsets.Length;
				if ((object)_weapon == null)
				{
					break;
				}
				float num2 = _weapon.PArea();
				Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
				if ((object)cachedTrans2 == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
				float2 ret2;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
				if (body != null)
				{
					BaseBody baseBody2 = body;
					ArcadeTransform arcadeTransform2 = baseBody2._transform;
					if (baseBody2._transform == null)
					{
						break;
					}
					arcadeTransform2.position = ret2;
				}
				float[] requiemRandomOffsets2 = _requiemRandomOffsets;
				int requiemRandomIndex2 = _requiemRandomIndex + 1;
				_requiemRandomIndex = requiemRandomIndex2;
				if (_requiemRandomOffsets == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
				object obj6 = (nint)(&ret2) >> 5;
				object obj7 = obj6 >> 31;
				object obj8 = obj6 + obj7;
				object obj9 = obj8 * 500;
				object obj10 = _requiemRandomIndex - obj9;
				bool flag4 = (nint)obj10 >= requiemRandomOffsets2.Length;
				if ((object)_weapon == null)
				{
					break;
				}
				float num3 = _weapon.PArea();
				if ((object)_weapon == null)
				{
					break;
				}
				Projectile projectile = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
				float6++;
				if (float5 <= float6 != 0)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			bool flag = TryFreeze(other);
		}
	}

	public unsafe TP_Icicle2_Projectile()
	{
		//IL_0045: Expected O, but got Ref
		//IL_008a: Expected O, but got Ref
		List<SpriteTextureData> list = new List<SpriteTextureData>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A161B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = "TP_VFX_Ice21";
		list.Add((SpriteTextureData)(&obj));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A161C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		obj = "TP_VFX_Ice22";
		list.Add((SpriteTextureData)(&obj));
		_icicleSprites = list;
		_requiemRandomOffsets = new float[500];
		base._002Ector();
	}

	private void _003CStartTimers_003Eb__22_0()
	{
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
