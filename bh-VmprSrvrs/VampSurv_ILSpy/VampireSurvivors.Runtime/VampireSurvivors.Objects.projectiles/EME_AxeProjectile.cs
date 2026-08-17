using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_AxeProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _scaleTween2;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0053: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_026c: Expected O, but got I4
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected I4, but got Unknown
		//IL_02a6: Expected O, but got I4
		//IL_039b: Expected I, but got O
		//IL_03e8: Expected O, but got I4
		//IL_04a5: Expected I, but got O
		//IL_0539: Expected O, but got I4
		//IL_05b5: Expected O, but got I4
		//IL_0718->IL060a: Incompatible stack heights: 8 vs 0
		//IL_01ba->IL060a: Incompatible stack heights: 8 vs 0
		//IL_01ea->IL060a: Incompatible stack heights: 8 vs 0
		//IL_073f->IL060a: Incompatible stack heights: 8 vs 0
		//IL_021e->IL060a: Incompatible stack heights: 8 vs 0
		//IL_0242->IL060a: Incompatible stack heights: 8 vs 0
		//IL_0313->IL060a: Incompatible stack heights: 8 vs 0
		//IL_0389->IL060a: Incompatible stack heights: 8 vs 0
		//IL_0367->IL0367: Incompatible stack heights: 9 vs 8
		//IL_03c6->IL060a: Incompatible stack heights: 8 vs 0
		//IL_0479->IL060a: Incompatible stack heights: 8 vs 0
		//IL_04ea->IL060a: Incompatible stack heights: 8 vs 0
		//IL_04c8->IL04c8: Incompatible stack heights: 9 vs 8
		base.InitProjectile(pool, weapon, index);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(32f, (float?)(object)0, (float?)(object)0);
			BaseBody baseBody2 = body;
			if (body != null)
			{
				baseBody2._enable = true;
				SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
				if (_indexInWeapon >= 10)
				{
				}
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					SpriteRenderer cachedTransform2 = (SpriteRenderer)(object)_cachedTransform;
					bool flag2 = (object)_cachedTransform == null;
					bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
					Weapon weapon2 = _weapon;
					bool flag4 = (object)_weapon == null;
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					bool flag5 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
					bool flag6 = (object)_renderer == null;
					_renderer.flipX = characterController._isFlipped;
					bool flag7 = (object)weapon == null;
					bool flag8 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
					float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					Weapon weapon3 = default(Weapon);
					if (!base.flipX)
					{
						weapon3 = _weapon;
						if ((object)_weapon == null)
						{
							goto IL_060a;
						}
					}
					if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
					{
						int num = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer = s_scene._renderer;
								if (s_scene._renderer != null && (object)_renderer != null)
								{
									int num2 = renderer.pixelHeight >> 31;
									object obj = renderer.pixelHeight - num2;
									object obj2 = obj >> 1;
									int sortingOrder = num + obj2;
									_renderer.sortingOrder = sortingOrder;
									ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)1);
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
											void* value2 = ((IntPtr*)(&array))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj3 = default(object);
											bool flag9 = obj3 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
											_ = 1;
											_ = 1;
											if ((object)_weapon != null)
											{
												float num3 = _weapon.PArea();
												((SpriteRenderer)(object)tweenConfig).m_SpriteChangeEvent = (UnityEvent<SpriteRenderer>)1120403456;
												_ = 1;
												_ = 1;
												MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
												_scaleTween = scaleTween;
												if (_alphaTween != null)
												{
													_alphaTween.Kill();
												}
												TweenConfig tweenConfig2 = new TweenConfig();
												object[] array2 = new object[1];
												if (array2 != null)
												{
													if ((object)_renderer != null)
													{
														nint num4 = (nint)array2;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj4 = default(object);
														bool flag10 = obj4 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig2 != null)
													{
														tweenConfig2.targets = array2;
														tweenConfig2.duration = 300f;
														tweenConfig2.ease = Ease.OutCubic;
														tweenConfig2.delay = 100f;
														tweenConfig2.alpha = (float?)(object)1;
														TweenCallback onComplete = StartDespawn;
														tweenConfig2.onComplete = onComplete;
														MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
														_alphaTween = alphaTween;
														SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
														soundConfig.Rate = 1f;
														soundConfig.Rate = 1.5f;
														soundConfig.Volume = (float?)(object)1;
														float num5 = (float)_indexInWeapon * -150f;
														float detune = -800f - num5;
														soundConfig.Detune = detune;
														float time = default(float);
														PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Whip, soundConfig, 100f, 4, time);
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
		goto IL_060a;
		IL_060a:
		throw new NullReferenceException();
	}

	public void StartDespawn()
	{
		//IL_008b: Expected I, but got O
		//IL_00ef: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0126: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_scaleTween2 != null)
		{
			_scaleTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.scaleY = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_AxeProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween2 = scaleTween;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_scaleTween2 != null)
		{
			_scaleTween2.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}
}
