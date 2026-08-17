using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Confodere0_Projectile : Projectile
{
	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Confodere01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0024: Expected O, but got I4
		//IL_024b: Expected O, but got I4
		//IL_02bd: Expected I4, but got O
		//IL_0322: Expected O, but got I
		//IL_0358: Expected O, but got I
		//IL_03bf: Expected I4, but got O
		//IL_0668: Expected I4, but got O
		//IL_0410: Expected I4, but got O
		//IL_05b4: Expected I4, but got I8
		//IL_05d9: Expected O, but got F4
		//IL_0612: Expected O, but got F4
		//IL_03ed->IL0528: Incompatible stack heights: 2 vs 1
		base.InitProjectile(pool, weapon, index);
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)1);
			ArcadeSprite arcadeSprite2 = setAlpha(1f);
			if (_tween != null)
			{
				_tween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				object obj = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					object obj4 = default(object);
					object obj3 = obj4 + obj4;
					_ = 1;
					_ = 1;
					_ = 1120403456;
					_ = 1;
					MultiTargetTween tween = Tweens.Add(tweenConfig);
					_tween = tween;
					if (_tween2 != null)
					{
						_tween2.Kill();
					}
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					if (array2 != null)
					{
						int value = ((int*)(&array2))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj5 = default(object);
						if (obj5 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							tweenConfig2.targets = array2;
							tweenConfig2.delay = 100f;
							tweenConfig2.duration = 100f;
							tweenConfig2.alpha = (float?)(object)1;
							TweenCallback onComplete = delegate
							{
								Despawn();
							};
							tweenConfig2.onComplete = onComplete;
							MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
							_tween2 = tween2;
							if (body != null)
							{
								int num2 = (int)_weapon;
								if ((object)_weapon != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rbx_v17 (System.Int32)+58]");
									int num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rbx_v17 (System.Int32)+58]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rbx_v17 (System.Int32)+58]");
										((ArcadeSprite)0).CheckRenderer();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v18 (System.Int32)+48]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v18 (System.Int32)+48]");
											Vector2 vector = ((SpriteRenderer)0).size;
											Weapon weapon2 = _weapon;
											if ((object)_weapon != null)
											{
												VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
												{
													int num4 = (int)_cachedTransform;
													if ((object)_cachedTransform != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v19 (System.Int32)+10]");
														bool flag = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v19 (System.Int32)+10]");
														Transform.get_position_Injected((IntPtr)0, out Vector3 _);
														if (~(characterController._isFlipped ? 1u : 0u) != 0)
														{
															int num5 = (int)_cachedTransform;
															bool flag2 = (object)_cachedTransform == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rbx_v20 (System.Int32)+10]");
														bool flag3 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rbx_v20 (System.Int32)+10]");
														Vector3 value2 = default(Vector3);
														Transform.set_position_Injected((IntPtr)0, ref value2);
														bool flag4 = (object)_renderer == null;
														_renderer.flipX = characterController._isFlipped;
														int num6 = (int)_renderer;
														bool flag5 = (object)_renderer == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ rbx_v21 (System.Int32)+10]");
														bool flag6 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ rbx_v21 (System.Int32)+10]");
														Renderer.set_sortingOrder_Injected((IntPtr)0, -1);
														SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
														{
															Rate = 1.2f
														};
														object obj6 = UnityEngine.Random.value;
														object obj7 = default(object);
														float num7 = (float)obj7 - 0.5f;
														_ = 1;
														float num8 = num7 * 200f;
														float time = default(float);
														PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hasta, soundConfig, 200f, 5, time);
														SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig
														{
															Rate = 0.8f
														};
														object obj8 = UnityEngine.Random.value;
														float num9 = num8 - 0.5f;
														float num10 = num9 * 200f;
														_ = 1;
														PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Shuriken2, soundConfig2, 200f, 5, time);
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
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
	}

	public override void Despawn()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__3_0()
	{
		Despawn();
	}
}
