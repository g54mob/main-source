using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Cart2Projectile : Projectile
{
	private ParticleSystem _pfxEmitter;

	private SpriteAnimation _spriteAnimator;

	private float _defaultSpeed;

	private bool _makeSparks;

	private bool _enterTweenCompleted;

	private bool _isGoingRight;

	private float _save_vel_x;

	private float _save_vel_y;

	private Tween _enterTween;

	private Sequence _fadeOutTween;

	private Tween _scaleTween;

	private Tween _xTween;

	private bool _isFadingOut;

	protected override void Awake()
	{
		base.Awake();
		_defaultSpeed = _speed;
		GeneratePfx();
		GenerateAnims();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_076e: Expected O, but got I4
		//IL_0782: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_01b0: Expected I4, but got O
		//IL_0222: Expected F4, but got O
		//IL_02ea: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_031b: Expected I, but got O
		//IL_0401: Expected I, but got O
		//IL_0411: Expected O, but got I
		//IL_0449: Expected O, but got I
		//IL_034e: Expected I, but got O
		//IL_035e: Expected O, but got I
		//IL_0396: Expected O, but got I
		//IL_04a1: Expected O, but got I
		//IL_03ee: Expected O, but got I
		//IL_05a1: Expected I4, but got O
		//IL_0898: Expected O, but got I4
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Expected I4, but got Unknown
		//IL_066f: Expected F4, but got O
		//IL_094a: Expected O, but got I4
		//IL_08f7: Expected F4, but got O
		//IL_0916: Expected F4, but got O
		//IL_0617: Expected F4, but got I4
		//IL_0966: Expected O, but got F4
		//IL_01f9->IL073a: Incompatible stack heights: 1 vs 0
		//IL_07f8->IL073a: Incompatible stack heights: 1 vs 0
		//IL_030e->IL073a: Incompatible stack heights: 1 vs 0
		//IL_048c->IL073a: Incompatible stack heights: 3 vs 0
		//IL_03d9->IL073a: Incompatible stack heights: 3 vs 0
		//IL_0834->IL073a: Incompatible stack heights: 3 vs 0
		//IL_04cc->IL073a: Incompatible stack heights: 3 vs 0
		//IL_04ee->IL073a: Incompatible stack heights: 3 vs 0
		//IL_085d->IL073a: Incompatible stack heights: 3 vs 0
		//IL_053f->IL073a: Incompatible stack heights: 3 vs 0
		//IL_0575->IL073a: Incompatible stack heights: 3 vs 0
		//IL_05bb->IL073a: Incompatible stack heights: 3 vs 0
		//IL_08d9->IL073a: Incompatible stack heights: 4 vs 0
		//IL_065d->IL073a: Incompatible stack heights: 4 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(24f, (float?)(object)0, (float?)(object)0);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
			_speed = _defaultSpeed;
			_makeSparks = true;
			if ((object)_spriteAnimator != null)
			{
				_spriteAnimator.SetAnimation("idle");
				if ((object)_renderer != null)
				{
					_renderer.enabled = true;
					if (_objectsHit != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							if (core._003CIsHalloween_003Ek__BackingField)
							{
								if ((object)_spriteAnimator == null)
								{
									goto IL_073a;
								}
								_spriteAnimator.enabled = false;
								Sprite sprite = SpriteManager.GetSprite("hCartEnd_0", "vfx");
								ArcadeSprite arcadeSprite3 = setFrame(sprite);
							}
							int num = (int)_cachedTransform;
							_enterTweenCompleted = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rsi_v12 (System.Int32)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rsi_v12 (System.Int32)+10]");
							float value = default(float);
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
							if (_enterTween != null)
							{
								TweenExtensions.Kill(_enterTween);
							}
							if ((object)_weapon != null)
							{
								float num2 = _weapon.PArea();
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, (float)Vector3.zeroVector, 0.2f);
								TweenCallback tweenCallback = delegate
								{
									_enterTweenCompleted = true;
								};
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ rax_v48 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore != null)
								{
									_enterTween = tweenerCore;
									setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
									Weapon weapon2 = _weapon;
									if ((object)_weapon != null)
									{
										nint num3 = (nint)weapon2;
										bool num6;
										bool num7;
										ArcadeBodyBounds boundsRectangle;
										if (!weapon2.IsHoming)
										{
											nint num4 = (nint)typeof(Cart2Weapon);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2Weapon>)+130]");
											object obj = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v48 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2Weapon>)+130]");
											bool flag2 = num5 < 0;
											num6 = flag2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v100+FFFFFFF8+v528 @ rax_v99*8]");
											bool flag3 = 0 != (nint)typeof(Cart2Weapon);
											num7 = flag3;
											if (base.body == null)
											{
												goto IL_073a;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v57 (VampireSurvivors.Objects.Weapons.Weapon)+160]");
											boundsRectangle = (ArcadeBodyBounds)0;
										}
										else
										{
											nint num8 = (nint)typeof(Cart2Weapon);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v72 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2Weapon>)+130]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
											nint num9 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rcx_v72 (Il2CppClass<VampireSurvivors.Objects.Weapons.Cart2Weapon>)+130]");
											bool flag4 = num9 < 0;
											num6 = flag4;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v98+FFFFFFF8+v1070 @ rax_v97*8]");
											bool flag5 = 0 != (nint)typeof(Cart2Weapon);
											num7 = flag5;
											if (base.body == null)
											{
												goto IL_073a;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v57 (VampireSurvivors.Objects.Weapons.Weapon)+168]");
											boundsRectangle = (ArcadeBodyBounds)0;
										}
										Body body = base.body.setBoundsRectangle(boundsRectangle);
										BaseBody baseBody2 = base.body;
										if (base.body != null)
										{
											baseBody2._onWorldBounds = true;
											if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
											{
												bool flag6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
												bool isGoingRight = (byte)((flag6 ? 1u : 0u) ^ 1u) != 0;
												_isGoingRight = isGoingRight;
												Weapon weapon3 = _weapon;
												if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
												{
													int num10 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
													if ((object)_renderer != null)
													{
														int sortingOrder = num10 + 1;
														_renderer.sortingOrder = sortingOrder;
														int num11 = (int)_renderer;
														if ((object)_renderer != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v16 (System.Int32)+10]");
															bool flag7 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v16 (System.Int32)+10]");
															object obj5 = Renderer.get_sortingOrder_Injected((IntPtr)0);
															int num12 = obj5 - 1;
															RenderingExtensions.SetDepth(_pfxEmitter, num12);
															Weapon weapon4 = _weapon;
															if ((object)_weapon != null)
															{
																float num13;
																bool flag9;
																if (!weapon4.IsHoming)
																{
																	float rotation = ((!_isGoingRight) ? ((float)Math.PI) : 0f);
																	float projectileSpeed = base.ProjectileSpeed;
																	Vector2 vector = SetVelocityFromRotation(rotation, (float)Vector3.zeroVector);
																	bool flag8 = !_isGoingRight;
																	num13 = (float)Vector3.zeroVector;
																	flag9 = flag8;
																}
																else
																{
																	Transform transform = base.AimForNearestEnemy(rotate: false);
																	BaseBody baseBody3 = base.body;
																	if (base.body == null)
																	{
																		goto IL_073a;
																	}
																	num13 = (float)baseBody3._velocity;
																	bool flag10 = (nint)baseBody3._velocity < 0;
																	bool flag11 = (object)baseBody3._velocity == null;
																	bool flag12 = !flag10;
																	bool flag13 = !flag11;
																	flag9 = (byte)(((_isGoingRight = flag13 & flag12) ? 1u : 0u) ^ 1u) != 0;
																}
																ArcadeSprite arcadeSprite4 = setFlipX(flag9);
																SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																{
																	Volume = (float?)(object)1,
																	Rate = 1f
																};
																object obj6 = UnityEngine.Random.value;
																float num14 = num13 * 200f;
																float time = default(float);
																PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Brakes, soundConfig, 150f, 2, time);
																_isFadingOut = false;
																if (_fadeOutTween != null)
																{
																	TweenExtensions.Kill(_fadeOutTween);
																}
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
		goto IL_073a;
		IL_073a:
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_00e5: Invalid comparison between I4 and F4
		//IL_0209: Expected F4, but got O
		//IL_0257: Expected F4, but got I
		//IL_015e: Expected O, but got I4
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_03c0: Expected I, but got O
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		//IL_04a6->IL0298: Incompatible stack heights: 1 vs 0
		//IL_030a->IL0298: Incompatible stack heights: 1 vs 0
		//IL_036e->IL0298: Incompatible stack heights: 1 vs 0
		//IL_0453->IL0298: Incompatible stack heights: 1 vs 0
		//IL_0344->IL0463: Incompatible stack heights: 3 vs 1
		//IL_042f->IL0482: Incompatible stack heights: 6 vs 1
		object obj2 = default(object);
		object obj = obj2 - 344;
		float deltaTime = PauseSystem.DeltaTime;
		float speed = deltaTime + _speed;
		_speed = speed;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if (_enterTweenCompleted)
			{
				Transform cachedTransform = _cachedTransform;
				if ((object)_weapon == null)
				{
					goto IL_0298;
				}
				float num = _weapon.PArea();
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
			}
			if (_makeSparks)
			{
				if (0f > _save_vel_x)
				{
				}
				Transform pfxEmitter = (Transform)(object)_pfxEmitter;
				_ = 0;
				if ((object)_weapon == null)
				{
					goto IL_0298;
				}
				float num2 = _weapon.PArea();
				_ = 1;
				_ = 1;
				bool flag4 = (object)_pfxEmitter == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-40]");
				_ = 0;
				_ = 0;
				_ = 0;
				obj = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				bool flag5 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
				object obj3 = obj - 48;
				ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj3, 1);
				nint num3 = (nint)_pfxEmitter;
				_ = 0;
				bool flag6 = (object)_weapon == null;
				float num4 = _weapon.PArea();
				_ = 1;
				_ = 1;
				bool flag7 = (object)_pfxEmitter == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rbp_v1-40]");
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rsi_v18 (System.IntPtr)+10]");
				bool flag8 = (nint)0 == 0;
				object obj4 = obj + 96;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rsi_v18 (System.IntPtr)+10]");
				ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj4, 1);
			}
			BaseBody baseBody = body;
			if (body != null)
			{
				float save_vel_x = (float)baseBody._velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018700F8AFh\"");
				if ((object)baseBody._velocity == null)
				{
					save_vel_x = _save_vel_x;
				}
				_save_vel_x = save_vel_x;
				if (body != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v38 (BaseBody)+74]");
					float save_vel_y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018700F8D1h\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v38 (BaseBody)+74]");
					if ((nint)0 == 0)
					{
						save_vel_y = _save_vel_y;
					}
					_save_vel_y = save_vel_y;
					return;
				}
			}
		}
		goto IL_0298;
		IL_0298:
		throw new NullReferenceException();
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0183: Expected O, but got F4
		//IL_00e7: Expected O, but got I8
		//IL_0212: Expected O, but got I4
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		object obj5;
		if (_bounces > 0)
		{
			int num = tile._data & 8;
			bool flag = num == 0;
			bool flag2 = num < 0;
			bool flag3 = !flag2;
			object obj = !flag;
			object obj2 = flag3 & obj;
			if (obj2 == null)
			{
				int num2 = tile._data & 4;
				bool flag4 = num2 == 0;
				bool flag5 = num2 < 0;
				bool flag6 = !flag5;
				object obj3 = !flag6;
				object obj4 = obj3 | flag4;
				obj5 = 1;
				if (obj4 != null)
				{
					goto IL_01ac;
				}
			}
			obj5 = 4294967295L;
			goto IL_01ac;
		}
		goto IL_0252;
		IL_01ac:
		float save_vel_x = (float)obj5 * _save_vel_x;
		_save_vel_x = save_vel_x;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj6 = !flag7;
		object obj7 = flag9 & obj6;
		object obj10;
		if (obj7 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj8 = !flag12;
			object obj9 = obj8 | flag10;
			obj10 = 1;
			if (obj9 != null)
			{
				goto IL_022d;
			}
		}
		obj10 = 4294967295L;
		goto IL_022d;
		IL_022d:
		float save_vel_y = (float)obj10 * _save_vel_y;
		_save_vel_y = save_vel_y;
		goto IL_0252;
		IL_0252:
		BaseBody baseBody = body;
		_ = _save_vel_y;
		baseBody._velocity = (float2)_save_vel_x;
		OnBounce();
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_0058: Expected O, but got F4
		if (_bounces > 0)
		{
			float save_vel_x = _save_vel_x * -1f;
			_save_vel_x = save_vel_x;
			float save_vel_y = _save_vel_y * -1f;
			_save_vel_y = save_vel_y;
		}
		BaseBody baseBody = body;
		_ = _save_vel_y;
		baseBody._velocity = (float2)_save_vel_x;
		OnBounce();
	}

	protected void Bounce(Body body, bool up, bool down, bool left, bool right)
	{
		if (base.body == body)
		{
			Weapon weapon = _weapon;
			if (weapon.IsHoming || !weapon.IsHoming)
			{
				OnBounce();
			}
		}
	}

	private void FadeOut()
	{
		//IL_040f: Expected I, but got O
		//IL_0071: Expected O, but got I4
		//IL_028f: Expected O, but got F4
		//IL_017f->IL026f: Incompatible stack heights: 1 vs 0
		//IL_03fc->IL026f: Incompatible stack heights: 2 vs 0
		_isFadingOut = true;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				_makeSparks = false;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 2f;
				object obj = UnityEngine.Random.value;
				float detune = (float)Vector2.zeroVector * 200f;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Carrello, soundConfig, 150f, 2, time);
				if (_fadeOutTween != null)
				{
					TweenExtensions.Kill(_fadeOutTween);
				}
				Sequence fadeOutTween = DOTween.Sequence();
				_fadeOutTween = fadeOutTween;
				Sequence sequence = TweenSettingsExtensions.SetDelay(_fadeOutTween, 0.1f);
				object cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r14_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r14_v7 (System.Object)+10]");
					Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
					TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(endValue: (float)ret * 1.5f, target: _cachedTransform, duration: 0.5f);
					if (TweenSettingsExtensions.ValidateAddToSequence(_fadeOutTween, (Tween)t, false))
					{
						Sequence sequence2 = Sequence.DoInsert(_fadeOutTween, (Tween)t, 0f);
					}
					Transform cachedTransform2 = _cachedTransform;
					if ((object)_cachedTransform != null)
					{
						bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret);
						float num3 = _save_vel_x * -0.5f;
						TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveX(endValue: num3 + (float)ret, target: _cachedTransform, duration: 0.5f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_fadeOutTween, (Tween)t2, false))
						{
							Sequence sequence3 = Sequence.DoInsert(_fadeOutTween, (Tween)t2, 0f);
						}
						Sequence fadeOutTween2 = _fadeOutTween;
						TweenCallback onComplete = delegate
						{
							_renderer.enabled = false;
							base.Despawn();
						};
						if (_fadeOutTween != null && ((Tween)fadeOutTween2)._003Cactive_003Ek__BackingField)
						{
							fadeOutTween2.onComplete = onComplete;
						}
						Sequence fadeOutTween3 = _fadeOutTween;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (_fadeOutTween != null)
						{
							fadeOutTween3.stringId = "DefaultGameTweenId";
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnBounce()
	{
		//IL_005b: Expected O, but got I4
		//IL_012a: Expected O, but got F4
		if (--_bounces > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			bool flag = _renderer.flipX;
			bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			ArcadeSprite arcadeSprite = setFlipX(flag2);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			object obj = UnityEngine.Random.value;
			object obj2 = default(object);
			float detune = (float)obj2 * 200f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Brakes, soundConfig, 150f, 2, time);
		}
		else if (!_isFadingOut)
		{
			_spriteAnimator.enabled = true;
			_spriteAnimator.SetAnimation("end");
			FadeOut();
		}
	}

	private void GenerateAnims()
	{
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation spriteAnimator = gameObject.AddComponent<SpriteAnimation>();
		_spriteAnimator = spriteAnimator;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("CartEnd_", 0, 29, "vfx", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimator.AddAnimation("end", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("CartEnd_", 0, 0, "vfx", num);
		_spriteAnimator.AddAnimation("idle", animationFrames2, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	private void SetDepths()
	{
		//IL_010d: Expected O, but got I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected I4, but got Unknown
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			int num = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
			if ((object)_renderer != null)
			{
				int sortingOrder = num + 1;
				_renderer.sortingOrder = sortingOrder;
				Cart2Projectile renderer = (Cart2Projectile)(object)_renderer;
				if ((object)_renderer != null)
				{
					bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
					object obj = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)renderer).m_CachedPtr);
					int num2 = obj - 1;
					RenderingExtensions.SetDepth(_pfxEmitter, num2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GeneratePfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00ec: Expected native int or pointer, but got O
		//IL_0106: Expected O, but got I
		//IL_0126: Expected O, but got Ref
		//IL_0140: Expected native int or pointer, but got O
		//IL_0281: Expected O, but got I4
		//IL_0165: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01bb: Expected O, but got I
		//IL_01db: Expected O, but got Ref
		//IL_01f5: Expected native int or pointer, but got O
		//IL_02bb: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(50f, 100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-61]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		_enterTweenCompleted = true;
	}

	private void _003CFadeOut_003Eb__19_0()
	{
		_renderer.enabled = false;
		base.Despawn();
	}
}
