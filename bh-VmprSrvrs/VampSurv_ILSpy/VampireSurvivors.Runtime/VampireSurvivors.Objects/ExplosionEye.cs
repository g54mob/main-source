using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects;

public class ExplosionEye : PoolableMonoBehaviour
{
	private SpriteRenderer _GroundFx;

	private SpriteRenderer _WarningSprite;

	private SpriteRenderer _StarSprite;

	private SpriteRenderer _GroundWarning;

	private TrailRenderer _Trail;

	private GameSessionData _gameSessionData;

	private PlayerOptions _playerOptions;

	private SpriteAnimation _starsSpriteAnim;

	private Camera _camera;

	private Circle _circleArea;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _starsPfx;

	private ParticleSystem _cloudPfx;

	private GravityWell _gravityWell;

	private Sequence _warningTween;

	private Sequence _groundWarningTween;

	private Tween _arcAngleTween;

	private Tween _scaleTween;

	private Timer _despawnTimer;

	private Color _color;

	private bool _hasHit;

	private bool _exploding;

	private float _arcAngle;

	private float _arcRadius;

	private float _003CDamage_003Ek__BackingField;

	private float _003CRadius_003Ek__BackingField;

	private float Damage
	{
		get
		{
			return _003CDamage_003Ek__BackingField;
		}
		set
		{
			_003CDamage_003Ek__BackingField = value;
		}
	}

	private float Radius
	{
		get
		{
			return _003CRadius_003Ek__BackingField;
		}
		set
		{
			_003CRadius_003Ek__BackingField = value;
		}
	}

	private void Construct(GameSessionData gameSessionData, PlayerOptions playerOptions)
	{
		_gameSessionData = gameSessionData;
		_playerOptions = playerOptions;
	}

	private void Awake()
	{
		Camera main = Camera.main;
		_camera = main;
		SpriteAnimation component = _StarSprite.GetComponent<SpriteAnimation>();
		_starsSpriteAnim = component;
		_Trail.enabled = false;
		Material material = ((Renderer)_Trail).GetMaterial();
		Material material2 = new Material(material);
		((Renderer)_Trail).SetMaterial(material2);
		GenerateParticleSystems();
	}

	private void OnDrawGizmosSelected()
	{
		//IL_0046: Expected F4, but got I
		if (_circleArea != null)
		{
			Color value = default(Color);
			Gizmos.set_color_Injected(ref value);
			Vector3 center = default(Vector3);
			IntPtr intPtr = default(IntPtr);
			Gizmos.DrawWireSphere_Injected(ref center, (float)(nint)intPtr);
		}
	}

	public unsafe void Init(float damage, float radius)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf2: Expected O, but got Unknown
		//IL_0c64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c69: Expected O, but got Unknown
		//IL_0ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce9: Expected O, but got Unknown
		//IL_0d0e: Expected I, but got O
		//IL_0d5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d63: Expected O, but got Unknown
		//IL_0e10: Expected I, but got O
		//IL_0e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e88: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0359: Expected O, but got I
		//IL_0f1d: Expected O, but got F4
		//IL_0388: Expected F4, but got I4
		//IL_03db: Expected O, but got I8
		//IL_0f5b: Expected I, but got O
		//IL_0f64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f69: Expected O, but got Unknown
		//IL_0fe1: Expected I, but got O
		//IL_0fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fef: Expected O, but got Unknown
		//IL_0459: Expected F4, but got I
		//IL_04e5: Expected F4, but got I
		//IL_0665: Expected O, but got I4
		//IL_0694: Expected F4, but got I4
		//IL_069d: Expected O, but got I4
		//IL_0724: Expected I4, but got I8
		//IL_08ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Expected O, but got Unknown
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08eb: Expected O, but got Unknown
		//IL_130a: Expected O, but got I4
		//IL_131a: Unknown result type (might be due to invalid IL or missing references)
		//IL_131f: Expected O, but got Unknown
		//IL_110e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1113: Expected O, but got Unknown
		//IL_11d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d8: Expected O, but got Unknown
		//IL_123c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1241: Expected O, but got Unknown
		//IL_0cac->IL0bb8: Incompatible stack heights: 1 vs 0
		//IL_0114->IL0bb8: Incompatible stack heights: 1 vs 0
		//IL_0462->IL0462: Incompatible stack heights: 21 vs 20
		//IL_04ee->IL04ee: Incompatible stack heights: 22 vs 21
		object obj2 = default(object);
		object obj = obj2 - 95;
		_003CDamage_003Ek__BackingField = damage;
		_003CRadius_003Ek__BackingField = radius;
		_hasHit = false;
		Vector2 vector = default(Vector2);
		TweenerCore<float, float, FloatOptions> tweenerCore;
		if ((object)_particlesManager != null)
		{
			_particlesManager.AddGravityWellParticleSystems(_gravityWell);
			AssignRandomColor();
			RenderingExtensions.ForceClear(_starsPfx);
			RenderingExtensions.ForceClear(_cloudPfx);
			object groundFx = _GroundFx;
			if ((object)_GroundFx != null)
			{
				_ = _color;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v31 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_GroundFx);
				}
				else
				{
					object obj3 = obj - 25;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v31 (System.Object)+10]");
					SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)obj3);
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.4f);
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = false;
						object groundWarning = _GroundWarning;
						if ((object)_GroundWarning != null)
						{
							_ = _color;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdi_v32 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							object obj4 = obj - 41;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdi_v32 (System.Object)+10]");
							SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)obj4);
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_GroundWarning, 0f);
							if ((object)_GroundWarning != null)
							{
								_GroundWarning.enabled = true;
								Transform transform = base.transform;
								if ((object)transform != null)
								{
									_ = 0;
									_ = 0;
									bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									object obj5 = obj - 57;
									Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj5);
									Sprite sprite = SpriteManager.GetSprite("ExclamationMark", vector, "UI");
									bool flag3 = (object)_WarningSprite == null;
									_WarningSprite.sprite = sprite;
									bool flag4 = (object)_WarningSprite == null;
									Transform transform2 = _WarningSprite.transform;
									nint num = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1492 @ rcx_v93 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num2 = 0;
									bool flag5 = (object)transform2 == null;
									_ = Vector3.zeroVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1493 @ rax_v103 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
									_ = 0;
									bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									object obj6 = obj - 41;
									Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj6);
									Transform warningSprite = (Transform)(object)_WarningSprite;
									bool flag7 = (object)_WarningSprite == null;
									bool flag8 = ((UnityEngine.Object)warningSprite).m_CachedPtr == (IntPtr)0;
									Renderer.set_sortingOrder_Injected(((UnityEngine.Object)warningSprite).m_CachedPtr, 9000);
									Sprite sprite2 = SpriteManager.GetSprite("eye_0", vector, "enemies2");
									bool flag9 = (object)_StarSprite == null;
									_StarSprite.sprite = sprite2;
									bool flag10 = (object)_StarSprite == null;
									Transform transform3 = _StarSprite.transform;
									nint num3 = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2105 @ rcx_v104 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num4 = 0;
									_ = Vector3.oneVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rdx_v73 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
									float num5 = 0f * 2f;
									bool flag11 = (object)transform3 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2030 @ rax_v115 (UnityEngine.Transform)+10]");
									bool flag12 = (nint)0 == 0;
									object obj7 = obj - 25;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2030 @ rax_v115 (UnityEngine.Transform)+10]");
									Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj7);
									object starSprite = _StarSprite;
									bool flag13 = (object)_StarSprite == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ rdi_v39 (System.Object)+10]");
									bool flag14 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ rdi_v39 (System.Object)+10]");
									Renderer.set_sortingOrder_Injected((IntPtr)0, 9000);
									bool flag15 = (object)_StarSprite == null;
									Transform transform4 = _StarSprite.transform;
									bool flag16 = (object)transform4 == null;
									_ = 15f;
									Vector3 eulerAngles = (Vector3)(obj - 41);
									transform4.eulerAngles = eulerAngles;
									bool flag17 = (object)_StarSprite == null;
									_StarSprite.enabled = false;
									bool flag18 = (object)_starsSpriteAnim == null;
									_starsSpriteAnim.CleanAnimations();
									int num6 = default(int);
									List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("eye_", 5, 21, "enemies2", num6);
									bool flag19 = (object)_starsSpriteAnim == null;
									bool startRandomFrame = default(bool);
									Action onComplete = default(Action);
									bool autoSetAnimation = default(bool);
									_starsSpriteAnim.AddAnimation("explode", animationFrames, 30, (byte)num6 != 0, startRandomFrame, onComplete, autoSetAnimation);
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									_ = 0;
									_ = 1063675494;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
									soundConfig.Volume = (float?)(object)0;
									soundConfig.Rate = 1f;
									object obj8 = UnityEngine.Random.value;
									float detune = (float)vector * 500f;
									soundConfig.Rate = 1f;
									soundConfig.Detune = detune;
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, num6);
									if (_warningTween != null)
									{
										DG.Tweening.TweenExtensions.Kill(_warningTween);
									}
									Sequence warningTween = DOTween.Sequence();
									object obj9 = 6603577472L;
									_warningTween = warningTween;
									Transform warningTween2 = (Transform)(object)_warningTween;
									bool flag20 = (object)_WarningSprite == null;
									Transform target = _WarningSprite.transform;
									nint num7 = (nint)typeof(Vector3);
									Vector3 endValue = (Vector3)(obj - 25);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2874 @ rcx_v128 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num8 = 0;
									_ = Vector3.oneVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2877 @ rax_v143 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
									_ = 0;
									TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, endValue, 0.2f);
									if (TweenSettingsExtensions.ValidateAddToSequence(_warningTween, (Tween)t, false))
									{
										bool flag21 = _warningTween == null;
										Sequence warningTween3 = _warningTween;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1232 @ rdi_v41 (UnityEngine.Transform)+A0]");
										Sequence sequence = Sequence.DoInsert(warningTween3, (Tween)t, 0f);
									}
									Sequence sequence2 = TweenSettingsExtensions.AppendInterval(_warningTween, 0.2f);
									Transform warningTween4 = (Transform)(object)_warningTween;
									bool flag22 = (object)_WarningSprite == null;
									Transform target2 = _WarningSprite.transform;
									nint num9 = (nint)typeof(Vector3);
									Vector3 endValue2 = (Vector3)(obj - 25);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2927 @ rcx_v135 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num10 = 0;
									_ = Vector3.zeroVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2930 @ rax_v151 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
									_ = 0;
									TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target2, endValue2, 0.2f);
									if (TweenSettingsExtensions.ValidateAddToSequence(_warningTween, (Tween)t2, false))
									{
										bool flag23 = _warningTween == null;
										Sequence warningTween5 = _warningTween;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rdi_v42 (UnityEngine.Transform)+A0]");
										Sequence sequence3 = Sequence.DoInsert(warningTween5, (Tween)t2, 0f);
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									bool flag24 = _warningTween == null;
									if (_groundWarningTween != null)
									{
										DG.Tweening.TweenExtensions.Kill(_groundWarningTween);
									}
									Sequence groundWarningTween = DOTween.Sequence();
									_groundWarningTween = groundWarningTween;
									TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleSprite.DOFade(_GroundWarning, 0.2f, 0.5f);
									if (TweenSettingsExtensions.ValidateAddToSequence(_groundWarningTween, (Tween)t3, false))
									{
										Sequence sequence4 = Sequence.DoInsert(_groundWarningTween, (Tween)t3, 0f);
									}
									bool flag25 = (object)_GroundWarning == null;
									Transform target3 = _GroundWarning.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> t4 = ShortcutExtensions.DOScale(target3, _003CRadius_003Ek__BackingField, 0.5f);
									bool flag26 = TweenSettingsExtensions.ValidateAddToSequence(_groundWarningTween, (Tween)t4, false);
									bool flag27 = !flag26;
									float num11 = 0.5f;
									object obj10 = 0;
									if (!flag27)
									{
										Sequence sequence5 = Sequence.DoInsert(_groundWarningTween, (Tween)t4, 0f);
										num11 = 0f;
										obj10 = 0;
									}
									Sequence groundWarningTween2 = _groundWarningTween;
									if (_groundWarningTween != null && ((Tween)groundWarningTween2)._003Cactive_003Ek__BackingField && !((Tween)groundWarningTween2).creationLocked)
									{
										((Tween)groundWarningTween2).loops = -1;
										((Tween)groundWarningTween2).loopType = LoopType.Yoyo;
										if (((ABSSequentiable)groundWarningTween2).tweenType == TweenType.Tweener)
										{
											((Tween)groundWarningTween2).fullDuration = 1f / 0f;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									bool flag28 = _groundWarningTween == null;
									_arcAngle = 180f;
									if (_arcAngleTween != null)
									{
										DG.Tweening.TweenExtensions.Kill(_arcAngleTween);
									}
									DOGetter<float> getter = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
									DOSetter<float> dOSetter = null;
									((ExplosionEye)(object)dOSetter)._003CInit_003Eb__35_1(_003CRadius_003Ek__BackingField);
									TweenerCore<float, float, FloatOptions> t5 = DOTween.To(getter, dOSetter, 360f, 0.5f);
									tweenerCore = TweenSettingsExtensions.SetDelay(t5, 1.5000001f);
									TweenCallback tweenCallback = delegate
									{
										//IL_018c: Unknown result type (might be due to invalid IL or missing references)
										//IL_0191: Expected O, but got Unknown
										//IL_0131->IL00bb: Incompatible stack heights: 1 vs 0
										//IL_003e->IL00bb: Incompatible stack heights: 1 vs 0
										//IL_007a->IL00bb: Incompatible stack heights: 1 vs 0
										//IL_01c8->IL00bb: Incompatible stack heights: 2 vs 0
										TrailRenderer trail5 = _Trail;
										if ((object)_Trail != null)
										{
											bool flag45 = ((UnityEngine.Object)trail5).m_CachedPtr == (IntPtr)0;
											TrailRenderer.Clear_Injected(((UnityEngine.Object)trail5).m_CachedPtr);
											if ((object)_Trail != null)
											{
												_Trail.enabled = true;
												if ((object)_StarSprite != null)
												{
													_StarSprite.enabled = true;
													Transform transform6 = base.transform;
													if ((object)transform6 != null)
													{
														bool flag46 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
														Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out Vector3 ret);
														float num15 = _arcAngle * ((float)Math.PI / 180f);
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
														object obj21 = ret - _arcRadius;
														float num16 = _arcAngle * ((float)Math.PI / 180f);
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
														if ((object)_StarSprite != null)
														{
															Transform transform7 = _StarSprite.transform;
															bool flag47 = (object)transform7 == null;
															bool flag48 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
															Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref ret);
															return;
														}
													}
												}
											}
										}
										throw new NullReferenceException();
									};
									TweenCallback tweenCallback3;
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3369 @ rax_v181 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
											if ((nint)0 != 0)
											{
												object obj11 = tweenerCore + 32;
												object obj12 = obj11 >> 12;
												object obj13 = obj12 & 0x1FFFFF;
												object obj14 = obj13 >> 6;
												object obj15 = obj13 & 0x3F;
												nint num13;
												do
												{
													object obj16 = 1 << (int)obj15;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1114 @ r14_v21+462E0+v3428 @ rdx_v132*8]");
													object obj17 = 0 | obj16;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1114 @ r14_v21+462E0+v3428 @ rdx_v132*8]");
													nint num12 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1114 @ r14_v21+462E0+v3428 @ rdx_v132*8]");
													if (num12 == 0)
													{
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1114 @ r14_v21+462E0+v3428 @ rdx_v132*8]");
													num13 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1114 @ r14_v21+462E0+v3428 @ rdx_v132*8]");
												}
												while (num13 != 0);
												TweenCallback tweenCallback2 = Explode;
												tweenCallback3 = tweenCallback2;
												goto IL_095b;
											}
										}
									}
									TweenCallback tweenCallback4 = Explode;
									bool flag29 = tweenerCore == null;
									tweenCallback3 = tweenCallback4;
									if (!flag29)
									{
										goto IL_095b;
									}
									goto IL_098c;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_095b:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3369 @ rax_v181 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_098c;
		IL_098c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag30 = tweenerCore == null;
		_arcAngleTween = tweenerCore;
		Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
		float num14 = (float)vector * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1405 @ rax_v190 (UnityEngine.Bounds)+10]");
		_ = 0;
		float arcRadius = num14 * 0.5f;
		_arcRadius = arcRadius;
		bool flag31 = (object)_Trail == null;
		Transform transform5 = _Trail.transform;
		bool flag32 = (object)transform5 == null;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2676 @ rax_v191 (UnityEngine.Transform)+10]");
		bool flag33 = (nint)0 == 0;
		object obj18 = obj - 25;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2676 @ rax_v191 (UnityEngine.Transform)+10]");
		Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj18);
		object trail = _Trail;
		bool flag34 = (object)_Trail == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1436 @ rdi_v51 (System.Object)+10]");
		bool flag35 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1436 @ rdi_v51 (System.Object)+10]");
		Renderer.set_sortingOrder_Injected((IntPtr)0, 3000);
		object trail2 = _Trail;
		bool flag36 = (object)_Trail == null;
		_ = _color;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1628 @ rdi_v52 (System.Object)+10]");
		bool flag37 = (nint)0 == 0;
		object obj19 = obj - 41;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1628 @ rdi_v52 (System.Object)+10]");
		TrailRenderer.set_startColor_Injected((IntPtr)0, ref *(Color*)obj19);
		object trail3 = _Trail;
		bool flag38 = (object)_Trail == null;
		_ = _color;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1773 @ rdi_v53 (System.Object)+10]");
		bool flag39 = (nint)0 == 0;
		object obj20 = obj - 57;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1773 @ rdi_v53 (System.Object)+10]");
		TrailRenderer.set_endColor_Injected((IntPtr)0, ref *(Color*)obj20);
		object trail4 = _Trail;
		bool flag40 = (object)_Trail == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1917 @ rdi_v54 (System.Object)+10]");
		bool flag41 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1917 @ rdi_v54 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		bool flag42 = (object)_Trail == null;
		_Trail.enabled = false;
		bool flag43 = (object)_Trail == null;
		Material material = ((Renderer)_Trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = ShortcutExtensions.DOFade(material, 1f, 0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag44 = tweenerCore2 == null;
		DG.Tweening.TweenExtensions.Complete(tweenerCore2, withCallbacks: false);
		TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
	}

	public void InternalUpdate()
	{
		//IL_003b: Expected O, but got I
		//IL_0220: Invalid comparison between F4 and I4
		//IL_0232: Expected O, but got I4
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d8: Invalid comparison between F4 and O
		//IL_00fc: Expected O, but got I4
		//IL_017d: Expected I, but got O
		//IL_0197: Expected O, but got I
		//IL_028a->IL01ec: Incompatible stack heights: 1 vs 0
		//IL_010d->IL01f4: Incompatible stack heights: 1 vs 0
		//IL_0141->IL01ec: Incompatible stack heights: 1 vs 0
		//IL_0170->IL01ec: Incompatible stack heights: 1 vs 0
		//IL_01bc->IL01f4: Incompatible stack heights: 1 vs 0
		if (_hasHit)
		{
			return;
		}
		bool flag = !_exploding;
		IntPtr intPtr = default(IntPtr);
		Vector2 vector = (Vector2)(nint)intPtr;
		if (!flag)
		{
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if (_circleArea != null)
					{
						Vector2 vector2 = default(Vector2);
						bool flag3 = _circleArea.Contains(vector2);
						bool flag4 = !flag3;
						float num2 = default(float);
						float num = num2;
						object obj = 0;
						vector = vector2;
						if (flag4)
						{
							goto IL_01f4;
						}
						GameSessionData gameSessionData2 = _gameSessionData;
						_hasHit = true;
						if (_gameSessionData != null)
						{
							VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData2._activeCharacter;
							if ((object)gameSessionData2._activeCharacter != null)
							{
								nint num3 = (nint)activeCharacter;
								num = _003CDamage_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rax_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+600]");
								obj = 0;
								bool damaged = gameSessionData2._activeCharacter.GetDamaged(_003CDamage_003Ek__BackingField);
								vector = vector2;
								goto IL_01f4;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_01f4;
		IL_01f4:
		float deltaTime = PauseSystem.DeltaTime;
		float num4 = deltaTime * 0.0625f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		bool flag5 = !(num4 > 0f);
		object obj2 = 0;
		if (!flag5)
		{
			do
			{
				TrailUpdate();
				obj2++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
		}
	}

	public void SetDepthPlease(float depth)
	{
		float num = depth * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		_GroundFx.sortingOrder = sortingOrder;
		_particlesManager.SetDepthMultiplied(depth);
	}

	public void Despawn()
	{
		_starsPfx.Clear(withChildren: true);
		_cloudPfx.Clear(withChildren: true);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		GravityWell gravityWell = _gravityWell;
		if ((object)_gravityWell != null && ((UnityEngine.Object)gravityWell).m_CachedPtr != (IntPtr)0)
		{
			_gravityWell.Clear();
		}
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
	}

	private unsafe void Explode()
	{
		//IL_045b: Expected O, but got Ref
		//IL_0304: Expected O, but got I4
		//IL_04b8: Expected O, but got F4
		//IL_00c2->IL0338: Incompatible stack heights: 1 vs 0
		//IL_00ee->IL0338: Incompatible stack heights: 1 vs 0
		//IL_01b0->IL0338: Incompatible stack heights: 1 vs 0
		//IL_012f->IL0338: Incompatible stack heights: 1 vs 0
		//IL_015e->IL0338: Incompatible stack heights: 1 vs 0
		//IL_048d->IL0338: Incompatible stack heights: 1 vs 0
		//IL_0449->IL03da: Incompatible stack heights: 3 vs 1
		//IL_027f->IL0338: Incompatible stack heights: 1 vs 0
		//IL_04aa->IL0338: Incompatible stack heights: 1 vs 0
		_exploding = true;
		if ((object)_starsSpriteAnim != null)
		{
			_starsSpriteAnim.SetAnimation("explode");
			SpriteAnimation starsSpriteAnim = _starsSpriteAnim;
			if ((object)_starsSpriteAnim != null)
			{
				((BaseSpriteAnimation)starsSpriteAnim)._003CIsPaused_003Ek__BackingField = false;
				_hasHit = false;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					float y = default(float);
					_circleArea = new Circle
					{
						_x = ret,
						_y = y,
						_radius = _003CRadius_003Ek__BackingField
					};
					RenderingExtensions.Start(_starsPfx);
					RenderingExtensions.Start(_cloudPfx);
					if (_playerOptions != null)
					{
						PlayerOptionsData config = _playerOptions.Config;
						if (config != null)
						{
							if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
							{
								goto IL_03da;
							}
							if ((object)_GroundFx != null)
							{
								_GroundFx.enabled = true;
								if ((object)_GroundFx != null)
								{
									Transform transform2 = _GroundFx.transform;
									bool flag2 = (object)transform2 == null;
									bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&ret));
									goto IL_03da;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0338;
		IL_03da:
		if (_scaleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
		if ((object)_GroundFx != null)
		{
			Transform target = _GroundFx.transform;
			Vector3 vector = default(Vector3);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&vector), 0.15f);
			TweenCallback tweenCallback = TriggerDespawnTimer;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
				_scaleTween = tweenerCore;
				if ((object)_Trail != null)
				{
					Material material = ((Renderer)_Trail).GetMaterial();
					TweenerCore<Color, Color, ColorOptions> tweenerCore2 = ShortcutExtensions.DOFade(material, 0f, 0.25f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore2 != null)
					{
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
						{
							Volume = (float?)(object)1,
							Rate = 1f
						};
						object obj = UnityEngine.Random.value;
						float num = (float)Vector3.oneVector - 0.5f;
						float detune = num * 500f;
						soundConfig.Detune = detune;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Explosion, soundConfig, 150f, 3, time);
						return;
					}
				}
			}
		}
		goto IL_0338;
		IL_0338:
		throw new NullReferenceException();
	}

	private void TriggerDespawnTimer()
	{
		//IL_0208->IL017e: Incompatible stack heights: 1 vs 0
		//IL_00b0->IL017e: Incompatible stack heights: 2 vs 0
		//IL_010e->IL017e: Incompatible stack heights: 2 vs 0
		ParticleSystem starsPfx = _starsPfx;
		if ((object)_starsPfx != null)
		{
			bool flag = ((UnityEngine.Object)starsPfx).m_CachedPtr == (IntPtr)0;
			ParticleSystem.Stop_Injected(((UnityEngine.Object)starsPfx).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
			ParticleSystem cloudPfx = _cloudPfx;
			if ((object)_cloudPfx != null)
			{
				bool flag2 = ((UnityEngine.Object)cloudPfx).m_CachedPtr == (IntPtr)0;
				ParticleSystem.Stop_Injected(((UnityEngine.Object)cloudPfx).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
				_exploding = false;
				if (_warningTween != null)
				{
					DG.Tweening.TweenExtensions.Kill(_warningTween);
				}
				if (_groundWarningTween != null)
				{
					DG.Tweening.TweenExtensions.Kill(_groundWarningTween);
				}
				if (_arcAngleTween != null)
				{
					DG.Tweening.TweenExtensions.Kill(_arcAngleTween);
				}
				if ((object)_GroundFx != null)
				{
					_GroundFx.enabled = false;
					if (_despawnTimer != null)
					{
						_despawnTimer.Cancel();
					}
					if ((object)_particlesManager != null)
					{
						float remainingLifetime = _particlesManager.GetRemainingLifetime();
						Action onComplete = Despawn;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer despawnTimer = Timers.Register(remainingLifetime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_despawnTimer = despawnTimer;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void AssignRandomColor()
	{
		//IL_00a7: Expected O, but got I4
		//IL_007b: Expected O, but got F4
		string[] array = new string[3];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		bool flag = ColorUtility.DoTryParseHtmlColor(array[obj], out Color32 _);
		float num = 0f / 255f;
		if (flag)
		{
			_color = (Color)num;
		}
	}

	private void TrailUpdate()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		float num = _arcAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		object obj = ret - _arcRadius;
		float num2 = _arcAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Transform transform2 = _Trail.transform;
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
		bool flag4 = (object)_StarSprite == null;
		Transform transform3 = _StarSprite.transform;
		bool flag5 = (object)transform3 == null;
		bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_029c: Expected O, but got I4
		//IL_02b5: Expected O, but got Ref
		//IL_02cf: Expected native int or pointer, but got O
		//IL_02e9: Expected O, but got I
		//IL_0309: Expected O, but got Ref
		//IL_0323: Expected native int or pointer, but got O
		//IL_033d: Expected O, but got I
		//IL_035d: Expected O, but got Ref
		//IL_0377: Expected native int or pointer, but got O
		//IL_098b: Expected O, but got I4
		//IL_039c: Expected O, but got Ref
		//IL_03c3: Expected O, but got I
		//IL_03dd: Expected native int or pointer, but got O
		//IL_09c5: Expected O, but got I
		//IL_0415: Expected O, but got Ref
		//IL_043c: Expected O, but got I
		//IL_0456: Expected native int or pointer, but got O
		//IL_09ff: Expected O, but got I
		//IL_06d1: Expected O, but got I4
		//IL_06ea: Expected O, but got Ref
		//IL_0704: Expected native int or pointer, but got O
		//IL_071e: Expected O, but got I
		//IL_073e: Expected O, but got Ref
		//IL_0758: Expected native int or pointer, but got O
		//IL_0772: Expected O, but got I
		//IL_0792: Expected O, but got Ref
		//IL_07ac: Expected native int or pointer, but got O
		//IL_07d4: Expected O, but got I
		//IL_0a39: Expected O, but got I
		//IL_07e7: Expected O, but got Ref
		//IL_080e: Expected O, but got I
		//IL_0828: Expected native int or pointer, but got O
		//IL_0a73: Expected O, but got I
		//IL_087f: Expected O, but got I
		//IL_08a0: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Blood1");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Blood2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Blood3");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		_ = 0;
		_ = 1073741824;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem starsPfx = _particlesManager.CreateEmitter(particleSystemConfig, null, "StarsPfx");
		_starsPfx = starsPfx;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Blood1");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list2._version + 1;
		list2._version = version5;
		string[] items5 = list2._items;
		if (list2._size >= items5.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Blood2");
		}
		else
		{
			int size5 = list2._size + 1;
			list2._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list2._version + 1;
		list2._version = version6;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Blood3");
		}
		else
		{
			int size6 = list2._size + 1;
			list2._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(80f, 120f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		_ = 0;
		_ = 1073741824;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._on = false;
		ParticleSystem cloudPfx = _particlesManager.CreateEmitter(particleSystemConfig2, null, "CloudPfx");
		_cloudPfx = cloudPfx;
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		gravityWellConfig._power = 1f;
		gravityWellConfig._epsilon = 50f;
		gravityWellConfig._gravity = 20f;
		gravityWellConfig.preCacheParticles = false;
		GravityWell gravityWell = _particlesManager.CreateGravityWell(gravityWellConfig);
		_gravityWell = gravityWell;
		Transform transform = _gravityWell.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void InitGravityWell()
	{
		_particlesManager.AddGravityWellParticleSystems(_gravityWell);
	}

	private void ReleaseGravityWell()
	{
		GravityWell gravityWell = _gravityWell;
		if ((object)_gravityWell != null && ((UnityEngine.Object)gravityWell).m_CachedPtr != (IntPtr)0)
		{
			_gravityWell.Clear();
		}
	}

	public ExplosionEye()
	{
		//IL_0012: Expected O, but got I
		//IL_0048: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124D0]");
		_color = (Color)0;
		_arcAngle = 180f;
		_arcRadius = 2.5f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private float _003CInit_003Eb__35_0()
	{
		return _arcAngle;
	}

	private void _003CInit_003Eb__35_1(float x)
	{
		_arcAngle = x;
	}

	private void _003CInit_003Eb__35_2()
	{
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_0131->IL00bb: Incompatible stack heights: 1 vs 0
		//IL_003e->IL00bb: Incompatible stack heights: 1 vs 0
		//IL_007a->IL00bb: Incompatible stack heights: 1 vs 0
		//IL_01c8->IL00bb: Incompatible stack heights: 2 vs 0
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null)
		{
			bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
			TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
			if ((object)_Trail != null)
			{
				_Trail.enabled = true;
				if ((object)_StarSprite != null)
				{
					_StarSprite.enabled = true;
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						float num = _arcAngle * ((float)Math.PI / 180f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						object obj = ret - _arcRadius;
						float num2 = _arcAngle * ((float)Math.PI / 180f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						if ((object)_StarSprite != null)
						{
							Transform transform2 = _StarSprite.transform;
							bool flag3 = (object)transform2 == null;
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
