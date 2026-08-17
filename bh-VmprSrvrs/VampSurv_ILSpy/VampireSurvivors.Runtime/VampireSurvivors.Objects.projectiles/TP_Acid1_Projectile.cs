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
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Acid1_Projectile : Projectile
{
	private float _radius = 16f;

	private PhaserSprite _animatedSprite;

	private PhaserSprite _animatedSprite2;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	private float __force;

	private Tween _forceTween;

	private float _saveVelX;

	private float _saveVelY;

	private bool _isDespawning;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		//IL_0140: Expected O, but got I4
		//IL_0140: Expected I4, but got O
		//IL_01f4: Expected O, but got I4
		//IL_01f4: Expected I4, but got O
		//IL_033b: Expected O, but got F4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Acid01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Acid", 1, 4, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Acid", 10, 14, vector, text, num, flag);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.AddAnimation("burst", animationFrames2, 12, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite4 = _animatedSprite;
		animatedSprite4._spriteAnimation.SetAnimation("idle");
		GameObject gameObject2 = base.gameObject;
		PhaserSprite animatedSprite5 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", "TP_VFX_Acid05");
		_animatedSprite2 = animatedSprite5;
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_Acid", 5, 7, vector, text, num, flag);
		PhaserSprite animatedSprite6 = _animatedSprite2;
		animatedSprite6._spriteAnimation.AddAnimation("idle", animationFrames3, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite7 = _animatedSprite2;
		animatedSprite7._spriteAnimation.SetAnimation("idle");
		__force = -1f;
		object obj = UnityEngine.Random.value;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((TP_Acid1_Projectile)(object)dOSetter)._003CAwake_003Eb__10_1(x);
		float duration = (float)vector + 2.5f;
		TweenerCore<float, float, FloatOptions> forceTween = DOTween.To(getter, dOSetter, 1f, duration);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			_ = 4;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		_forceTween = forceTween;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0847: Expected O, but got I4
		//IL_0036: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_010d: Expected O, but got I
		//IL_010d: Expected O, but got I
		//IL_0121: Expected O, but got I4
		//IL_089f: Expected O, but got F4
		//IL_08c5: Expected O, but got F4
		//IL_01f4: Expected I, but got O
		//IL_0284: Expected O, but got I
		//IL_092b: Expected O, but got F4
		//IL_0953: Invalid comparison between F4 and I4
		//IL_0318: Expected O, but got I4
		//IL_0993: Expected I, but got O
		//IL_09d4: Expected O, but got Ref
		//IL_045c: Expected O, but got I4
		//IL_09f9: Expected I, but got O
		//IL_0a4e: Expected O, but got Ref
		//IL_0a90: Expected O, but got I
		//IL_0afa: Expected O, but got Ref
		//IL_0b6d: Expected O, but got Ref
		//IL_0b9c: Expected O, but got I
		//IL_0bb9: Expected O, but got I
		//IL_0bd6: Expected O, but got I
		//IL_0be9: Expected O, but got Ref
		//IL_0c01: Invalid comparison between O and F4
		//IL_0c23: Expected I, but got O
		//IL_05ee: Expected O, but got F4
		//IL_0802: Expected O, but got I
		//IL_0802: Expected O, but got I
		//IL_06eb: Expected O, but got I
		//IL_06eb: Expected O, but got I
		//IL_0239->IL0808: Incompatible stack heights: 1 vs 0
		//IL_0980->IL0808: Incompatible stack heights: 1 vs 0
		//IL_02ff->IL0808: Incompatible stack heights: 1 vs 0
		//IL_0336->IL0808: Incompatible stack heights: 1 vs 0
		//IL_0369->IL0808: Incompatible stack heights: 1 vs 0
		//IL_03a6->IL0808: Incompatible stack heights: 1 vs 0
		//IL_03c8->IL0808: Incompatible stack heights: 1 vs 0
		//IL_03fa->IL0808: Incompatible stack heights: 1 vs 0
		//IL_0b30->IL0808: Incompatible stack heights: 8 vs 0
		//IL_0d3b->IL0808: Incompatible stack heights: 9 vs 0
		//IL_05da->IL0808: Incompatible stack heights: 9 vs 0
		//IL_060d->IL0808: Incompatible stack heights: 9 vs 0
		//IL_0c9d->IL0808: Incompatible stack heights: 9 vs 0
		//IL_0690->IL0808: Incompatible stack heights: 9 vs 0
		//IL_0ccc->IL0808: Incompatible stack heights: 9 vs 0
		//IL_0714->IL0808: Incompatible stack heights: 9 vs 0
		//IL_0743->IL0808: Incompatible stack heights: 9 vs 0
		//IL_0762->IL0808: Incompatible stack heights: 9 vs 0
		//IL_07a3->IL0808: Incompatible stack heights: 9 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		_isDespawning = false;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_ = 0;
		_ = 0;
		_ = 3204448256L;
		_ = 1;
		_ = 3204448256L;
		_ = 1;
		if (base.body != null)
		{
			BaseBody baseBody = base.body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
			BaseBody baseBody2 = baseBody.setCircle(1f, (float?)(object)num, (float?)(object)0);
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				float num4 = default(float);
				float num3 = num4 * _radius;
				_ = 0;
				_ = 0;
				_ = 1;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj3 = num3 ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj4 = num3 ^ 0;
				if (base.body != null)
				{
					BaseBody baseBody3 = base.body;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
					BaseBody baseBody4 = baseBody3.setCircle(num3, (float?)(object)num5, (float?)(object)0);
					ArcadeSprite arcadeSprite2 = setScale(0.35f, (float?)(object)0);
					object obj5 = UnityEngine.Random.value;
					if ((object)weapon != null)
					{
						float num6 = weapon.PSpeed();
						float num7 = weapon.PSpeed();
						float num8 = num4 * 0.25f;
						float num9 = num4 * 0.75f;
						float num10 = num9 * num4;
						float num11 = num8 + num10;
						float num12 = (_speed = num11 * 0.35f);
						object obj6 = UnityEngine.Random.value;
						float num13 = num12 * 0.5f;
						float num14 = num4 * 0.5f;
						float num15 = num13 * num4;
						float num16 = num15 + num14;
						if (_scaleTween != null)
						{
							_scaleTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							nint num17 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj7 = default(object);
							bool flag = obj7 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								_ = 0;
								tweenConfig.duration = 200f;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
								tweenConfig.scale = (float?)(object)0;
								TweenCallback onComplete = StartDespawn;
								tweenConfig.onComplete = onComplete;
								MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
								_scaleTween = scaleTween;
								object obj8 = UnityEngine.Random.value;
								bool flag2 = num12 < 0.5f;
								float num18 = num12 - 0.5f;
								bool flag3 = num18 == 0f;
								BlendMode blendMode = ((flag2 | flag3) ? BlendMode.Add : BlendMode.Normal);
								if ((object)_animatedSprite != null)
								{
									PhaserSprite phaserSprite = _animatedSprite.setBlendMode(blendMode);
									if ((object)_animatedSprite != null)
									{
										PhaserSprite phaserSprite2 = _animatedSprite.setScale(num4, (float?)(object)0);
										if ((object)_animatedSprite != null)
										{
											PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(0.65f);
											if ((object)_animatedSprite != null)
											{
												PhaserSprite phaserSprite4 = _animatedSprite.setVisible(visible: true);
												PhaserSprite animatedSprite = _animatedSprite;
												if ((object)_animatedSprite != null && (object)animatedSprite._spriteAnimation != null)
												{
													animatedSprite._spriteAnimation.SetAnimation("idle");
													if ((object)_animatedSprite != null)
													{
														Transform transform = _animatedSprite.transform;
														nint num19 = (nint)typeof(Vector3);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1601 @ rcx_v69 (Il2CppClass<UnityEngine.Vector3>)+B8]");
														nint num20 = 0;
														_ = Vector3.zeroVector;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1592 @ rax_v83 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
														_ = 0;
														bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
														object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
														Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj9);
														PhaserSprite phaserSprite5 = _animatedSprite2.setBlendMode(blendMode);
														PhaserSprite phaserSprite6 = _animatedSprite2.setScale(num4, (float?)(object)0);
														PhaserSprite phaserSprite7 = _animatedSprite2.setAlpha(0.45f);
														PhaserSprite phaserSprite8 = _animatedSprite2.setVisible(visible: true);
														PhaserSprite animatedSprite2 = _animatedSprite2;
														animatedSprite2._spriteAnimation.SetAnimation("idle");
														Transform transform2 = _animatedSprite2.transform;
														nint num21 = (nint)typeof(Vector3);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1439 @ rcx_v81 (Il2CppClass<UnityEngine.Vector3>)+B8]");
														nint num22 = 0;
														bool flag5 = (object)transform2 == null;
														_ = Vector3.zeroVector;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1435 @ rax_v96 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
														_ = 0;
														bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
														object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
														Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj10);
														SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
														_ = 0;
														_ = 1051931443;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
														soundConfig.Volume = (float?)(object)0;
														soundConfig.Rate = 1f;
														float detune = (float)_indexInWeapon * 100f;
														soundConfig.Detune = detune;
														float time = default(float);
														PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_AcidicBubbles1, soundConfig, 200f, 5, time);
														Weapon weapon2 = _weapon;
														bool flag7 = (object)_weapon == null;
														bool flag8 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
														Transform transform3 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.transform;
														bool flag9 = (object)transform3 == null;
														_ = 0;
														_ = 0;
														bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
														object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
														Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj11);
														Weapon cachedTransform = (Weapon)(object)_cachedTransform;
														if ((object)_cachedTransform != null)
														{
															_ = 0;
															_ = 0;
															bool flag11 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
															object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
															Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj12);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
															nint num23 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
															object obj13 = num23 - 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
															nint num24 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
															object obj14 = num24 - 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-2D]");
															nint num25 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-1D]");
															object obj15 = num25 - 0;
															object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
															object obj17 = default(object);
															Vector3 vector;
															object obj18;
															if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
															{
																vector = (Vector3)(obj14 / obj17);
																obj18 = obj15 / obj17;
															}
															else
															{
																nint num26 = (nint)typeof(Vector3);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2009 @ rax_v144 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																nint num27 = 0;
																vector = Vector3.zeroVector;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2010 @ rax_v145 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
																_ = 0;
																_ = Vector3.zeroVector;
																obj18 = obj17;
															}
															float projectileSpeed = base.ProjectileSpeed;
															float num28 = (_saveVelX = (float)obj17 * (float)vector);
															float projectileSpeed2 = base.ProjectileSpeed;
															ArcadeSprite sprite = _sprite;
															float saveVelY = num28 * (float)obj18;
															_saveVelY = saveVelY;
															if ((object)_sprite != null)
															{
																BaseBody baseBody5 = sprite.body;
																if (sprite.body != null)
																{
																	baseBody5._velocity = (float2)_saveVelX;
																	if ((object)_weapon != null)
																	{
																		int num29 = _weapon.PBounces();
																		if (num29 <= 0)
																		{
																			goto IL_0c5c;
																		}
																		if (_bounceActivated)
																		{
																			goto IL_07bb;
																		}
																		_bounceActivated = true;
																		PhaserScene s_scene = ArcadePhysics.s_scene;
																		if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null)
																		{
																			WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
																			if (ArcadePhysics.s_world != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
																				_ = 0;
																				_ = 0;
																				_ = 1065353216;
																				_ = 1;
																				_ = 1065353216;
																				_ = 1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
																				nint num30 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																				setCollideWorldBounds(value: true, (float?)(object)num30, (float?)(object)0);
																				Weapon weapon3 = _weapon;
																				if ((object)_weapon != null)
																				{
																					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
																					if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null && base.body != null)
																					{
																						Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
																						BaseBody baseBody6 = base.body;
																						if (base.body != null)
																						{
																							baseBody6._onWorldBounds = true;
																							goto IL_0c5c;
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_07bb:
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
		setCollideWorldBounds(value: true, (float?)(object)num31, (float?)(object)0);
		return;
		IL_0c5c:
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_07bb;
	}

	private void StartDespawn()
	{
		//IL_0069: Expected I, but got O
		//IL_00bf: Expected O, but got I4
		//IL_0131: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		_isDespawning = true;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
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
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.duration = 200f;
			float num2 = _weapon.PDuration();
			float delay = default(float);
			tweenConfig.delay = delay;
			TweenCallback onStart = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4190]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				PhaserSprite animatedSprite = _animatedSprite;
				animatedSprite._spriteAnimation.SetAnimation("burst");
			};
			tweenConfig.onStart = onStart;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Acid1_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (body == b)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			float saveVelX = _saveVelX * -1f;
			int bounces = _bounces - 1;
			_bounces = bounces;
			_saveVelX = saveVelX;
			float saveVelY = _saveVelY * -1f;
			_saveVelY = saveVelY;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void LateUpdate()
	{
		//IL_0183: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected I4, but got Unknown
		//IL_0146: Expected O, but got F4
		//IL_019d->IL014c: Incompatible stack heights: 1 vs 0
		//IL_0105->IL014c: Incompatible stack heights: 1 vs 0
		//IL_0134->IL014c: Incompatible stack heights: 1 vs 0
		if ((object)_animatedSprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
			PhaserSprite animatedSprite = _animatedSprite;
			if ((object)_animatedSprite != null)
			{
				PhaserSprite spriteRenderer = (PhaserSprite)(object)animatedSprite._spriteRenderer;
				if ((object)animatedSprite._spriteRenderer != null)
				{
					bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					object obj = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
					if ((object)_animatedSprite2 != null)
					{
						int num = obj + 1;
						PhaserSprite phaserSprite = _animatedSprite2.setDepth(num);
						float num2 = __force * 0.5f;
						ArcadeSprite sprite = _sprite;
						float num3 = _saveVelY + 0.5f;
						float num4 = num2 + _saveVelX;
						if ((object)_sprite != null)
						{
							BaseBody baseBody = sprite.body;
							if (sprite.body != null)
							{
								baseBody._velocity = (float2)num4;
								return;
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
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private float _003CAwake_003Eb__10_0()
	{
		return __force;
	}

	private void _003CAwake_003Eb__10_1(float x)
	{
		__force = x;
	}

	private void _003CStartDespawn_003Eb__12_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4190]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("burst");
	}
}
