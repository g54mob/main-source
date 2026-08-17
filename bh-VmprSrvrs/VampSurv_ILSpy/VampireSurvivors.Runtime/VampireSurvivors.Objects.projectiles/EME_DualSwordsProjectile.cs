using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_DualSwordsProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0086: Expected O, but got I
		//IL_0086: Expected O, but got I
		//IL_06ee: Expected I, but got O
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Expected O, but got Unknown
		//IL_011b: Invalid comparison between O and F4
		//IL_0141: Expected F4, but got O
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected O, but got Unknown
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Expected O, but got Unknown
		//IL_0235: Expected O, but got I
		//IL_0235: Expected O, but got I
		//IL_02c9: Expected I, but got O
		//IL_0367: Expected O, but got I
		//IL_08c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c6: Expected O, but got Unknown
		//IL_092e: Expected O, but got I4
		//IL_098d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0992: Expected O, but got Unknown
		//IL_047c: Expected I4, but got I8
		//IL_09d0: Expected O, but got I4
		//IL_04ac: Expected O, but got I4
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected I4, but got Unknown
		//IL_05c5: Expected O, but got I4
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Expected I4, but got Unknown
		//IL_0632: Expected O, but got I
		//IL_07eb->IL0685: Incompatible stack heights: 2 vs 0
		//IL_01fe->IL0685: Incompatible stack heights: 2 vs 0
		//IL_0886->IL0685: Incompatible stack heights: 3 vs 0
		//IL_029d->IL0685: Incompatible stack heights: 3 vs 0
		//IL_030e->IL0685: Incompatible stack heights: 3 vs 0
		//IL_02ec->IL02ec: Incompatible stack heights: 4 vs 3
		//IL_03d4->IL0685: Incompatible stack heights: 3 vs 0
		//IL_0403->IL0685: Incompatible stack heights: 3 vs 0
		//IL_042c->IL0685: Incompatible stack heights: 3 vs 0
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F6A7]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-28]");
			Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
				Transform transform = base.transform;
				nint num2 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rcx_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ rax_v54 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 64;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj);
				float num4 = _weapon.PArea();
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f);
				float num5 = 5f;
				if (!flag2)
				{
					num5 = (float)Vector3.zeroVector;
				}
				bool flag3 = !(1f < num5);
				float alpha = 1f;
				if (!flag3)
				{
					if (num5 < 4f)
					{
						float num6 = num5 - 1f;
						float num7 = num6 * 0.5f;
						float num8 = num7 / 3f;
						alpha = 1f - num8;
					}
					else
					{
						alpha = 0.5f;
					}
				}
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_renderer, alpha);
				Sprite sprite2 = _renderer.sprite;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rax_v63 (UnityEngine.Sprite)+10]");
				bool flag4 = (nint)0 == 0;
				object obj3 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rax_v63 (UnityEngine.Sprite)+10]");
				Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj3);
				if ((object)_renderer != null)
				{
					Sprite sprite3 = _renderer.sprite;
					if ((object)sprite3 != null)
					{
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v68 (UnityEngine.Sprite)+10]");
						bool flag5 = (nint)0 == 0;
						object obj4 = obj2 - 64;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v68 (UnityEngine.Sprite)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj4);
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-28]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-34]");
						_ = 0;
						_ = 1;
						_ = 1;
						if (body != null)
						{
							BaseBody baseBody = body;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+38]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
							BaseBody baseBody2 = baseBody.setSize((float?)(object)num9, (float?)(object)0, center: false);
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
									nint num10 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj5 = default(object);
									bool flag6 = obj5 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array;
									_ = 0;
									tweenConfig.duration = 100f;
									tweenConfig.ease = Ease.Linear;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
									tweenConfig.scale = (float?)(object)0;
									TweenCallback onComplete = delegate
									{
										//IL_005e: Expected I, but got O
										//IL_00d0: Expected O, but got I4
										//IL_00eb: Expected I, but got O
										if (_alphaTween != null)
										{
											_alphaTween.Kill();
										}
										TweenConfig tweenConfig2 = new TweenConfig();
										object[] array2 = new object[1];
										if ((object)_renderer != null)
										{
											nint num15 = (nint)array2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj14 = default(object);
											if (obj14 == null)
											{
												ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
												throw ex;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										tweenConfig2.targets = array2;
										tweenConfig2.duration = 100f;
										tweenConfig2.ease = Ease.Linear;
										tweenConfig2.alpha = (float?)(object)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_DualSwordsProjectile>)+370]");
										TweenCallback onComplete2 = new TweenCallback(this, (IntPtr)0);
										nint num16 = (nint)this;
										tweenConfig2.onComplete = onComplete2;
										MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
										_alphaTween = alphaTween;
									};
									tweenConfig.onComplete = onComplete;
									MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
									_scaleTween = scaleTween;
									Weapon weapon2 = _weapon;
									if ((object)_weapon != null)
									{
										VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
										if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
										{
											object cachedTransform = _cachedTransform;
											if ((object)_cachedTransform != null)
											{
												_ = 0;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v23 (System.Object)+10]");
												bool flag7 = (nint)0 == 0;
												object obj6 = obj2 - 64;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v23 (System.Object)+10]");
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
												_ = 0;
												if (~(characterController._isFlipped ? 1u : 0u) == 0)
												{
												}
												int num11 = _indexInWeapon & 1;
												bool flag8 = num11 == 0;
												object obj7 = !flag8;
												if (obj7 == null)
												{
												}
												object cachedTransform2 = _cachedTransform;
												bool flag9 = (object)_cachedTransform == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-38]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1066 @ rbx_v24 (System.Object)+10]");
												bool flag10 = (nint)0 == 0;
												object obj8 = obj2 - 48;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1066 @ rbx_v24 (System.Object)+10]");
												Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj8);
												bool flag11 = (object)_renderer == null;
												int num12 = (int)(_indexInWeapon & 0x80000001L);
												if ((nint)_renderer < 0)
												{
													object obj9 = num12 - 1;
													object obj10 = obj9 | -2;
													num12 = obj10 + 1;
												}
												object obj11 = num12 - 1;
												bool flag12 = obj11 == null;
												_renderer.flipY = flag12;
												bool flag13 = (object)_renderer == null;
												_renderer.flipX = characterController._isFlipped;
												Weapon weapon3 = _weapon;
												bool flag14 = (object)_weapon == null;
												bool flag15 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
												int num13 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
												bool flag16 = (object)GM.Core == null;
												PhaserScene s_scene = ArcadePhysics.s_scene;
												bool flag17 = ArcadePhysics.s_scene == null;
												PhaserScene.Renderer renderer = s_scene._renderer;
												bool flag18 = s_scene._renderer == null;
												bool flag19 = (object)_renderer == null;
												int num14 = renderer.pixelHeight >> 31;
												object obj12 = renderer.pixelHeight - num14;
												object obj13 = obj12 >> 1;
												int sortingOrder = num13 + obj13;
												_renderer.sortingOrder = sortingOrder;
												SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
												_ = 0;
												_ = 1071225242;
												_ = 1;
												soundConfig.Rate = 1f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
												soundConfig.Volume = (float?)(object)0;
												soundConfig.Rate = 2f;
												float detune = (float)_indexInWeapon * -100f;
												soundConfig.Detune = detune;
												float time = default(float);
												PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Whip, soundConfig, 0f, 10, time);
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
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
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

	private void _003CInitProjectile_003Eb__2_0()
	{
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		//IL_00eb: Expected I, but got O
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_DualSwordsProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}
}
