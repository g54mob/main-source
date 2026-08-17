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
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_LongswordProjectile_Base : Projectile
{
	protected float Radius = 38f;

	private PhaserSprite _animatedSprite;

	private Timer _hitboxTimer;

	private MultiTargetTween _fadeOutTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "Emeralds_VFX", "EME_LONGSWORD_vfx_1");
				_animatedSprite = animatedSprite;
				int num = default(int);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("EME_LONGSWORD_vfx_", 1, 4, "Emeralds_VFX", num);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
				{
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					animatedSprite2._spriteAnimation.AddAnimation("slash", animationFrames, 4, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
					if ((object)_animatedSprite != null)
					{
						PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
						if ((object)_animatedSprite != null)
						{
							Transform transform = _animatedSprite.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							Transform transform2 = _animatedSprite.transform;
							bool flag2 = (object)transform2 == null;
							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value2 = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00f5: Expected O, but got F4
		//IL_0123: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		SetupMechanics();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4998]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UpdatePositionAndScale();
		PhaserSprite phaserSprite = _animatedSprite.setAlpha(1f);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("slash");
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 500f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_standardattack, soundConfig, 100f, 1, time);
	}

	private void SetupMechanics()
	{
		//IL_008b: Expected I, but got O
		//IL_00ef: Expected O, but got I4
		//IL_010a: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = true;
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
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
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_Base>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeOutTween = Tweens.Add(tweenConfig);
		_fadeOutTween = fadeOutTween;
	}

	private void SetupVisuals()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4998]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UpdatePositionAndScale();
		PhaserSprite phaserSprite = _animatedSprite.setAlpha(1f);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("slash");
	}

	public override void InternalUpdate()
	{
		UpdatePositionAndScale();
	}

	private unsafe void UpdatePositionAndScale()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04b9: Expected I, but got O
		//IL_04fa: Expected O, but got Ref
		//IL_092f: Expected O, but got F4
		//IL_00bd: Expected O, but got I
		//IL_00f3: Expected O, but got I
		//IL_0543: Expected O, but got Ref
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_05b6: Expected O, but got Ref
		//IL_060e: Expected O, but got Ref
		//IL_093d: Expected O, but got F4
		//IL_062e: Expected O, but got F4
		//IL_065f: Expected I, but got O
		//IL_0950: Expected O, but got Ref
		//IL_095e: Expected O, but got Ref
		//IL_096f: Expected F4, but got O
		//IL_06ba: Expected O, but got Ref
		//IL_0713: Expected O, but got Ref
		//IL_0764: Expected O, but got F4
		//IL_077d: Expected O, but got F4
		//IL_0480: Expected O, but got I
		//IL_0480: Expected O, but got I
		//IL_07df: Expected O, but got Ref
		//IL_0848: Expected O, but got Ref
		//IL_08b1: Expected O, but got Ref
		//IL_090c: Expected O, but got Ref
		//IL_00a8->IL0485: Incompatible stack heights: 1 vs 0
		//IL_00dd->IL0485: Incompatible stack heights: 1 vs 0
		//IL_0110->IL0485: Incompatible stack heights: 1 vs 0
		//IL_013f->IL0485: Incompatible stack heights: 1 vs 0
		//IL_0579->IL0485: Incompatible stack heights: 2 vs 0
		//IL_0178->IL0485: Incompatible stack heights: 2 vs 0
		//IL_022c->IL0485: Incompatible stack heights: 2 vs 0
		//IL_07a2->IL0485: Incompatible stack heights: 14 vs 0
		//IL_0367->IL0485: Incompatible stack heights: 14 vs 0
		//IL_0395->IL0485: Incompatible stack heights: 14 vs 0
		//IL_03c1->IL0485: Incompatible stack heights: 14 vs 0
		//IL_080b->IL0485: Incompatible stack heights: 15 vs 0
		//IL_03f7->IL0485: Incompatible stack heights: 15 vs 0
		//IL_0874->IL0485: Incompatible stack heights: 16 vs 0
		//IL_042d->IL0485: Incompatible stack heights: 16 vs 0
		//IL_0926->IL074a: Incompatible stack heights: 19 vs 14
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float num5;
		if ((object)_animatedSprite != null)
		{
			Transform transform = _animatedSprite.transform;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rcx_v72 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			_ = Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v78 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
			object obj4 = UnityEngine.Random.value;
			float num3 = (float)Vector3.oneVector * 360f;
			_animatedSprite.angle = num3;
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Transform weapon2 = (Transform)(object)_weapon;
			if ((object)_weapon != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v33 (UnityEngine.Transform)+58]");
				ArcadeSprite arcadeSprite = (ArcadeSprite)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v33 (UnityEngine.Transform)+58]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v33 (UnityEngine.Transform)+58]");
					((ArcadeSprite)0).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							_ = 0;
							bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj5);
							Weapon weapon3 = _weapon;
							if ((object)_weapon != null)
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
								if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v85 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
									object obj6 = 0 ^ -0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
									float num4 = _weapon.PArea();
									num5 = (float)obj6 * Radius;
									float num6 = num5 * 0.01f;
									Transform transform2 = base.transform;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
									float num7 = num6 * 1.25f;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
									Transform transform3 = base.transform;
									if ((object)transform3 != null)
									{
										_ = 0;
										_ = 0;
										bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
										object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
										Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj7);
										bool flag4 = (object)transform2 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-61]");
										_ = 0;
										bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
										Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj8);
										object obj9 = UnityEngine.Random.value;
										object obj10 = UnityEngine.Random.value;
										Transform transform4 = base.transform;
										bool flag6 = (object)transform4 == null;
										Transform transform5 = transform4.transform;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
										nint num8 = (nint)typeof(Vector3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ rax_v122 (Il2CppClass<UnityEngine.Vector3>)+B8]");
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1828 @ rax_v123 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
										_ = 0;
										_ = Vector3.forwardVector;
										_ = 0;
										object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
										object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
										Quaternion.AngleAxis_Injected((float)transform4, ref *(Vector3*)obj12, out *(Quaternion*)obj11);
										bool flag7 = (object)transform5 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
										_ = 0;
										bool flag8 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
										object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
										Transform.set_rotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Quaternion*)obj13);
										bool flag9 = (object)_animatedSprite == null;
										Transform transform6 = _animatedSprite.transform;
										bool flag10 = (object)_weapon == null;
										float num10 = _weapon.PArea();
										bool flag11 = (object)transform6 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-69]");
										_ = 0;
										bool flag12 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
										object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
										Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj14);
										Weapon weapon4 = _weapon;
										bool flag13 = (object)_weapon == null;
										VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon4)._003COwner_003Ek__BackingField;
										bool flag14 = (object)((Equipment)weapon4)._003COwner_003Ek__BackingField == null;
										if (!characterController2._isFlipped)
										{
											goto IL_074a;
										}
										if ((object)_animatedSprite != null)
										{
											Transform transform7 = _animatedSprite.transform;
											if ((object)_animatedSprite != null)
											{
												Transform transform8 = _animatedSprite.transform;
												if ((object)transform8 != null)
												{
													_ = 0;
													_ = 0;
													bool flag15 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
													object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
													Transform.get_localScale_Injected(((UnityEngine.Object)transform8).m_CachedPtr, out *(Vector3*)obj15);
													if ((object)_animatedSprite != null)
													{
														Transform transform9 = _animatedSprite.transform;
														if ((object)transform9 != null)
														{
															_ = 0;
															_ = 0;
															bool flag16 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
															object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
															Transform.get_localScale_Injected(((UnityEngine.Object)transform9).m_CachedPtr, out *(Vector3*)obj16);
															if ((object)_animatedSprite != null)
															{
																Transform transform10 = _animatedSprite.transform;
																if ((object)transform10 != null)
																{
																	_ = 0;
																	_ = 0;
																	bool flag17 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
																	object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
																	Transform.get_localScale_Injected(((UnityEngine.Object)transform10).m_CachedPtr, out *(Vector3*)obj17);
																	bool flag18 = (object)transform7 == null;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-51]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v144 (UnityEngine.Transform)+10]");
																	bool flag19 = (nint)0 == 0;
																	object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v144 (UnityEngine.Transform)+10]");
																	Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj18);
																	goto IL_074a;
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
		goto IL_0485;
		IL_074a:
		_ = 0;
		_ = 0;
		object obj19 = num5 ^ -0f;
		_ = 1;
		object obj20 = num5 ^ -0f;
		_ = 1;
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
			BaseBody baseBody2 = baseBody.setCircle(num5, (float?)(object)num11, (float?)(object)0);
			return;
		}
		goto IL_0485;
		IL_0485:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		_renderer.enabled = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_fadeOutTween != null)
		{
			_fadeOutTween.Kill();
		}
		base.Despawn();
	}
}
