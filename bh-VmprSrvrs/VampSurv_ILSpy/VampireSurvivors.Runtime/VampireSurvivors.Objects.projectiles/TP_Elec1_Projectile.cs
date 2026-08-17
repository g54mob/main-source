using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Elec1_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private float _radius = 10f;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private TweenerCore<Vector3, Vector3, VectorOptions> moveTween;

	private Vector3 targetPosition;

	protected override void Awake()
	{
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected I4, but got O
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0352: Expected O, but got I
		//IL_04c9->IL0449: Incompatible stack heights: 1 vs 0
		//IL_0519->IL0449: Incompatible stack heights: 2 vs 0
		//IL_0412->IL0449: Incompatible stack heights: 2 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Lightning_01");
				_animatedSprite = animatedSprite;
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Elec_", 1, 19, vector, text, num, flag);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
				{
					bool autoSetAnimation = default(bool);
					animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
					List<string> list = new List<string>();
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v30 (System.Collections.Generic.List`1<System.String>)+1C]");
						_ = (nint)0 + (nint)1;
						IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
						if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
						{
							UnityEvent<SpriteRenderer> spriteChangeEvent = ((SpriteRenderer)(object)list).m_SpriteChangeEvent;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v30 (System.IntPtr)+18]");
							if ((nint)spriteChangeEvent >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Lightning_01");
							}
							else
							{
								UnityEvent<SpriteRenderer> spriteChangeEvent2 = (UnityEvent<SpriteRenderer>)(((SpriteRenderer)(object)list).m_SpriteChangeEvent + 1);
								((SpriteRenderer)(object)list).m_SpriteChangeEvent = spriteChangeEvent2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v30 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							IntPtr cachedPtr2 = ((UnityEngine.Object)(object)list).m_CachedPtr;
							if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
							{
								UnityEvent<SpriteRenderer> spriteChangeEvent3 = ((SpriteRenderer)(object)list).m_SpriteChangeEvent;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rcx_v32 (System.IntPtr)+18]");
								if ((nint)spriteChangeEvent3 >= 0)
								{
									((List<object>)(object)list).AddWithResize((object)"TP_VFX_Lightning_02");
								}
								else
								{
									UnityEvent<SpriteRenderer> spriteChangeEvent4 = (UnityEvent<SpriteRenderer>)(((SpriteRenderer)(object)list).m_SpriteChangeEvent + 1);
									((SpriteRenderer)(object)list).m_SpriteChangeEvent = spriteChangeEvent4;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v30 (System.Collections.Generic.List`1<System.String>)+1C]");
								_ = (nint)0 + (nint)1;
								IntPtr cachedPtr3 = ((UnityEngine.Object)(object)list).m_CachedPtr;
								if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
								{
									UnityEvent<SpriteRenderer> spriteChangeEvent5 = ((SpriteRenderer)(object)list).m_SpriteChangeEvent;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v34 (System.IntPtr)+18]");
									if ((nint)spriteChangeEvent5 >= 0)
									{
										((List<object>)(object)list).AddWithResize((object)"TP_VFX_Lightning_03");
										object obj = 0;
									}
									else
									{
										UnityEvent<SpriteRenderer> spriteChangeEvent6 = (UnityEvent<SpriteRenderer>)(((SpriteRenderer)(object)list).m_SpriteChangeEvent + 1);
										((SpriteRenderer)(object)list).m_SpriteChangeEvent = spriteChangeEvent6;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										object obj = "TP_VFX_Lightning_03";
									}
									string text2 = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
									SpriteRenderer trail = (SpriteRenderer)(object)_Trail;
									if ((object)_Trail != null)
									{
										bool flag2 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
										TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
										Sprite sprite2 = default(Sprite);
										RenderingExtensions.SetMaterialToPackedSprite(_Trail, sprite2);
										SpriteRenderer trail2 = (SpriteRenderer)(object)_Trail;
										if ((object)_Trail != null)
										{
											bool flag3 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
											TrailRenderer.set_textureMode_Injected(((UnityEngine.Object)trail2).m_CachedPtr, LineTextureMode.RepeatPerSegment);
											if ((object)_Trail != null)
											{
												_Trail.time = 1f;
												if ((object)_Trail != null)
												{
													Material material = ((Renderer)_Trail).GetMaterial();
													RenderingExtensions.SetAlpha(material, 1f);
													TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
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
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0520: Expected O, but got I4
		//IL_021f: Expected O, but got I
		//IL_0555: Expected I, but got O
		//IL_05af: Expected I, but got O
		//IL_032e: Expected O, but got I4
		//IL_032e: Expected O, but got I4
		//IL_05d7: Expected O, but got F4
		//IL_044b: Invalid comparison between F4 and I4
		//IL_04a5: Expected O, but got I4
		//IL_0579->IL04dd: Incompatible stack heights: 1 vs 0
		//IL_05c9->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_030f->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_0356->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_0383->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_03c1->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_03f0->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_05f1->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_048b->IL04dd: Incompatible stack heights: 2 vs 0
		//IL_04c3->IL04dd: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		List<string> list = new List<string>();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"TP_VFX_Lightning_01");
				}
				else
				{
					int num = list._size + 1;
					list._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"TP_VFX_Lightning_02");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Lightning_03");
							object obj = 0;
						}
						else
						{
							int num3 = list._size + 1;
							list._size = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							object obj = "TP_VFX_Lightning_03";
						}
						string text = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
						Sprite sprite = default(Sprite);
						RenderingExtensions.SetMaterialToPackedSprite(_Trail, sprite);
						List<string> trail = (List<string>)(object)_Trail;
						if ((object)_Trail != null)
						{
							bool flag = trail._items == null;
							TrailRenderer.Clear_Injected((IntPtr)trail._items);
							List<string> trail2 = (List<string>)(object)_Trail;
							if ((object)_Trail != null)
							{
								bool flag2 = trail2._items == null;
								TrailRenderer.set_textureMode_Injected((IntPtr)trail2._items, LineTextureMode.Tile);
								if ((object)_weapon != null)
								{
									float num4 = _weapon.PArea();
									object obj2 = default(object);
									float num5 = (float)obj2 * _radius;
									if (body != null)
									{
										BaseBody baseBody = body.setCircle(num5, (float?)(object)1, (float?)(object)1);
										BaseBody baseBody2 = body;
										if (body != null)
										{
											baseBody2._enable = false;
											if ((object)_Trail != null)
											{
												float startWidth = (float)obj2 * 0.12f;
												_Trail.startWidth = startWidth;
												if ((object)_Trail != null)
												{
													_Trail.endWidth = 0f;
													if ((object)_Trail != null)
													{
														_Trail.time = 0.12f;
														TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_Trail, 0.65f);
														object obj3 = UnityEngine.Random.value;
														if ((object)_animatedSprite != null)
														{
															bool flag3 = num5 < 0.5f;
															float num6 = num5 - 0.5f;
															bool flag4 = num6 == 0f;
															BlendMode blendMode = ((flag3 | flag4) ? BlendMode.Add : BlendMode.Normal);
															PhaserSprite phaserSprite = _animatedSprite.setBlendMode(blendMode);
															if ((object)_animatedSprite != null)
															{
																PhaserSprite phaserSprite2 = _animatedSprite.setScale(0.65f, (float?)(object)0);
																if ((object)_animatedSprite != null)
																{
																	PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(0.65f);
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
		throw new NullReferenceException();
	}

	private unsafe void Strike()
	{
		//IL_0070: Expected O, but got I4
		//IL_00da: Expected O, but got Ref
		//IL_00fe: Expected I, but got O
		_Trail.emitting = true;
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_VolFulgur2, soundConfig, 50f, 1, time);
		Transform target = base.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(target, (Vector3)(&obj), 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elec1_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		moveTween = tweenerCore;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = moveTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public void SetTargetPosition(Vector3 target)
	{
		//IL_009e: Expected O, but got F4
		Tween tween = moveTween;
		targetPosition = (Vector3)target.x;
		_ = target.z;
		if (moveTween != null && tween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(moveTween);
		}
		Action onComplete = Strike;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void Despawn()
	{
		Tween tween = moveTween;
		if (moveTween != null && tween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(moveTween);
		}
		object trail = _Trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v1 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		_Trail.emitting = false;
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		base.Despawn();
	}
}
