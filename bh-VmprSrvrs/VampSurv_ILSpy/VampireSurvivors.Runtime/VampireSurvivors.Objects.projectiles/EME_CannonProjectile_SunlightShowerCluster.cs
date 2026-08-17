using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_CannonProjectile_SunlightShowerCluster : Projectile
{
	private SpriteRenderer _GroundFx;

	private TrailRenderer _orangeTrail;

	private TrailRenderer _blueTrail;

	private ParticleSystem _orangeExplosionVFX;

	private ParticleSystem _blueExplosionVFX;

	private Camera _camera;

	private Tween _angleTween;

	private Tween _positionTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private Circle _explosionCircle;

	private const float Radius = 16f;

	private bool _isBroken;

	protected override void Awake()
	{
		base.Awake();
		Camera camera = _camera;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		SetupMechanics();
		Renderer renderer;
		if ((_indexInWeapon & 1) != 0)
		{
			_blueTrail.enabled = true;
			renderer = _orangeTrail;
		}
		else
		{
			_orangeTrail.enabled = true;
			renderer = _blueTrail;
		}
		renderer.enabled = false;
	}

	private unsafe void SetupMechanics()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0036: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_004a: Expected O, but got I4
		//IL_0077: Expected O, but got I
		//IL_08c1: Expected O, but got I8
		//IL_01ef: Expected O, but got I
		//IL_01ef: Expected O, but got I
		//IL_0913: Expected O, but got Ref
		//IL_0935: Expected O, but got I
		//IL_0943: Expected O, but got F4
		//IL_0952: Expected I, but got O
		//IL_040e: Expected O, but got Ref
		//IL_09c9: Expected O, but got Ref
		//IL_09eb: Expected O, but got I
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_0ad9: Expected O, but got I4
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aee: Expected O, but got Unknown
		//IL_064d: Expected O, but got Ref
		//IL_09f8->IL098c: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 3238002688L;
		_ = 1;
		_ = 3238002688L;
		_ = 1;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			BaseBody baseBody2 = baseBody.setCircle(16f, (float?)(object)num, (float?)(object)0);
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			_ = 0;
			_ = 1056964608;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)0);
			ArcadeSprite arcadeSprite3 = setVisible(visible: true);
			BaseBody baseBody3 = body;
			_isCullable = false;
			_isBroken = false;
			if (body != null)
			{
				baseBody3._enable = false;
				if (_hitboxTimer != null)
				{
					_hitboxTimer.Cancel();
				}
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				if ((object)_GroundFx != null)
				{
					_GroundFx.enabled = false;
					SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
					if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F66D]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						object obj3 = 6603577472L;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
						Sprite sprite = SpriteManager.GetSprite((string)num2, (string)0);
						if ((object)_GroundFx != null)
						{
							_GroundFx.sprite = sprite;
							Weapon weapon = _weapon;
							if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
							{
								Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
								if ((object)transform != null)
								{
									_ = 0;
									_ = 0;
									if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
									{
										object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj4);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
										float2 float5 = (float2)0;
										Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v989 @ rax_v45 (UnityEngine.Bounds)+10]");
										_ = 0;
										object obj5 = UnityEngine.Random.value;
										float2 float6 = default(float2);
										base.position = float6;
										nint num3 = (nint)this;
										Transform transform2 = base.AimForRandomEnemyInScreen();
										bool flag = (object)transform2 == null;
										float2 float7 = float6;
										if (!flag)
										{
											bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											float7 = float6;
											if (!flag2)
											{
												Transform transform3 = transform2.transform;
												if ((object)transform3 == null)
												{
													goto IL_0886;
												}
												_ = 0;
												_ = 0;
												bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
												object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
												Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj6);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
												float7 = (float2)0;
												float5 = float6;
											}
										}
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene._renderer;
											if (s_scene._renderer != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
												if ((object)_renderer != null)
												{
													int sortingOrder = default(int);
													_renderer.sortingOrder = sortingOrder;
													Tween positionTween = _positionTween;
													if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
													{
														DG.Tweening.TweenExtensions.Kill(_positionTween);
													}
													Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
													_ = 0;
													tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, endValue, 0.75f);
													TweenCallback tweenCallback2;
													if (tweenerCore != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v64 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
														if ((nint)0 != 0)
														{
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
															bool flag4 = (nint)0 == 0;
															_ = 0;
															if (!flag4)
															{
																object obj7 = tweenerCore + 184;
																object obj8 = obj7 >> 12;
																object obj9 = obj8 & 0x1FFFFF;
																object obj10 = obj9 >> 6;
																object obj11 = obj9 & 0x3F;
																nint num5;
																do
																{
																	object obj12 = 1 << (int)obj11;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r12_v6+462E0+v1324 @ rdx_v54*8]");
																	object obj13 = 0 | obj12;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r12_v6+462E0+v1324 @ rdx_v54*8]");
																	nint num4 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r12_v6+462E0+v1324 @ rdx_v54*8]");
																	if (num4 == 0)
																	{
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r12_v6+462E0+v1324 @ rdx_v54*8]");
																	num5 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r12_v6+462E0+v1324 @ rdx_v54*8]");
																}
																while (num5 != 0);
																TweenCallback tweenCallback = Break;
																tweenCallback2 = tweenCallback;
																goto IL_0563;
															}
														}
													}
													TweenCallback tweenCallback3 = Break;
													bool flag5 = tweenerCore == null;
													tweenCallback2 = tweenCallback3;
													if (!flag5)
													{
														goto IL_0563;
													}
													goto IL_0592;
												}
											}
										}
									}
									else
									{
										UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0886;
		IL_0563:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v64 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0592;
		IL_0886:
		throw new NullReferenceException();
		IL_0592:
		_positionTween = tweenerCore;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_positionTween != null)
		{
			Tween angleTween = _angleTween;
			if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
			{
				DG.Tweening.TweenExtensions.Kill(_angleTween);
			}
			Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			_ = -360f;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_cachedTransform, endValue2, 0.6f, RotateMode.FastBeyond360);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1651 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			_angleTween = tweenerCore2;
			Tween angleTween2 = _angleTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_angleTween != null)
			{
				angleTween2.stringId = "DefaultGameTweenId";
				return;
			}
		}
		goto IL_0886;
	}

	private void SetupVisuals()
	{
		Renderer renderer;
		if ((_indexInWeapon & 1) != 0)
		{
			_blueTrail.enabled = true;
			renderer = _orangeTrail;
		}
		else
		{
			_orangeTrail.enabled = true;
			renderer = _blueTrail;
		}
		renderer.enabled = false;
	}

	private void Break()
	{
		//IL_052f: Expected I, but got O
		//IL_02b5: Expected O, but got I4
		//IL_02b5: Expected O, but got I4
		//IL_03f9: Expected I, but got O
		//IL_04a8: Expected O, but got I4
		//IL_05dd->IL04f8: Incompatible stack heights: 1 vs 0
		//IL_0302->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_03ca->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_064f->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_047e->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_04df->IL04f8: Incompatible stack heights: 6 vs 0
		//IL_04f8->IL0654: Incompatible stack heights: 6 vs 0
		if (_isBroken)
		{
			return;
		}
		_isBroken = true;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				if (_objectsHit != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._enable = true;
						if ((object)_orangeTrail != null)
						{
							_orangeTrail.enabled = false;
							if ((object)_blueTrail != null)
							{
								_blueTrail.enabled = false;
								(((_indexInWeapon & 1) == 0) ? _orangeExplosionVFX : _blueExplosionVFX)?.Play(withChildren: true);
								if ((object)_GroundFx != null)
								{
									Transform transform = _GroundFx.transform;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ rax_v30 (UnityEngine.Transform)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ rax_v30 (UnityEngine.Transform)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									Transform transform2 = _GroundFx.transform;
									if ((object)_weapon != null)
									{
										float num3 = _weapon.PArea();
										float num4 = (float)Vector3.zeroVector * 0.32f;
										float num5 = (float)Vector3.oneVector * num4;
										bool flag2 = (object)transform2 == null;
										bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Vector3 value2 = default(Vector3);
										Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
										bool flag4 = (object)_GroundFx == null;
										_GroundFx.enabled = true;
										bool flag5 = (object)_weapon == null;
										float num6 = _weapon.PArea();
										object obj = default(object);
										float radius = (float)obj * 16f;
										bool flag6 = body == null;
										BaseBody baseBody3 = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
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
											float num7 = hitBoxDelay * 0.001f;
											bool useRealTime = default(bool);
											MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
											int repeat = default(int);
											TimerType type = default(TimerType);
											Timer hitboxTimer = Timers.Register(num7, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
											_hitboxTimer = hitboxTimer;
											if (_expireTimer != null)
											{
												_expireTimer.Cancel();
											}
											if ((object)_weapon != null)
											{
												float num8 = _weapon.PDuration();
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_SunlightShowerCluster>)+370]");
												Action onComplete2 = new Action(this, (IntPtr)0);
												nint num9 = (nint)this;
												float duration = num7 * 0.001f;
												Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
												_expireTimer = expireTimer;
												PhaserScene s_scene = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null)
												{
													PhaserScene.Renderer renderer = s_scene._renderer;
													if (s_scene._renderer != null)
													{
														int num10 = renderer.pixelHeight >> 31;
														object obj2 = renderer.pixelHeight - num10;
														object obj3 = obj2 >> 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
														if ((object)_GroundFx != null)
														{
															int sortingOrder = default(int);
															_GroundFx.sortingOrder = sortingOrder;
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
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		_isCullable = true;
		_GroundFx.enabled = false;
		Tween angleTween = _angleTween;
		if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		Tween positionTween = _positionTween;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
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

	private void _003CBreak_003Eb__17_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
