using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyCosmicEye : EnemyController
{
	protected Transform eyeModel;

	private bool _hasGeneratedSprites;

	private float _sineF = 1f;

	private PhaserSprite _wingL1;

	private PhaserSprite _wingR1;

	private PhaserSprite _wingL2;

	private PhaserSprite _wingR2;

	private PhaserSprite _wingL3;

	private PhaserSprite _wingR3;

	private PhaserSprite _wingSmL1;

	private PhaserSprite _wingSmR1;

	private PhaserSprite _wingSmL2;

	private PhaserSprite _wingSmR2;

	private PhaserSprite _wingSmL3;

	private PhaserSprite _wingSmR3;

	private MultiTargetTween _spritesDeathTween;

	private MultiTargetTween _wingsAngleTween;

	private bool _isFirstUpdate = true;

	private float _eyeRotationX;

	private float _eyeRotationY;

	private PhaserSprite[] AllWings;

	private PhaserSprite[] AllSmallWings;

	private PhaserSprite[] AllSprites;

	private TweenerCore<float, float, FloatOptions> SineTween;

	private MultiTargetTween _disappearTween;

	private TweenerCore<Vector3, Vector3, VectorOptions> _eyeScaleTween;

	private List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> rotationTweens;

	private const string FrameNameWing = "desWing_i01.png";

	private const string FrameNameWingL = "desWingL_i01.png";

	protected override void Awake()
	{
		base.Awake();
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		_eyeRotationY = 180f;
		_eyeRotationX = 180f;
	}

	protected void RandomEyeAngle()
	{
		//IL_0228: Expected O, but got F4
		//IL_0231: Invalid comparison between O and F4
		//IL_0240: Expected O, but got I4
		//IL_0257: Expected O, but got F4
		//IL_0013: Expected O, but got I4
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		object obj3 = 300;
		if (!flag)
		{
			obj3 = 200;
		}
		object obj4 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		double num = Math.Sin(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm8,xmm0\"");
		float num2 = 0f * 35f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((EnemyCosmicEye)(object)dOSetter)._003CRandomEyeAngle_003Eb__30_1(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		double num3 = Math.Cos(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm9,xmm0\"");
		float num4 = 0f * 35f;
		float endValue = num4 + 180f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, endValue, 0.2f);
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((EnemyCosmicEye)(object)dOSetter2)._003CRandomEyeAngle_003Eb__30_3(x);
		float endValue2 = num2 + 180f;
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, endValue2, 0.2f);
		TweenCallback tweenCallback = delegate
		{
			Transform transform = eyeModel.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		};
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v24 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Action onComplete = RandomEyeAngle;
		float duration = (float)obj3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected unsafe override void OnRecycleEnemy()
	{
		//IL_21ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f1: Expected O, but got Unknown
		//IL_0375: Expected O, but got Ref
		//IL_04b4: Expected O, but got I4
		//IL_052f: Expected O, but got I4
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected O, but got Unknown
		//IL_05aa: Expected O, but got I4
		//IL_0625: Expected O, but got I4
		//IL_06a0: Expected O, but got I4
		//IL_071b: Expected O, but got I4
		//IL_0796: Expected O, but got I4
		//IL_0811: Expected O, but got I4
		//IL_088c: Expected O, but got I4
		//IL_0907: Expected O, but got I4
		//IL_0982: Expected O, but got I4
		//IL_09fd: Expected O, but got I4
		//IL_0a93: Expected O, but got Ref
		//IL_0ab8: Expected O, but got I4
		//IL_0ac1: Expected O, but got I4
		//IL_0ac9: Expected O, but got Ref
		//IL_0b4b: Expected O, but got I4
		//IL_0b58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5d: Expected O, but got Unknown
		//IL_0b73: Expected O, but got I4
		//IL_0b7c: Expected O, but got I4
		//IL_0cf2: Expected O, but got I
		//IL_0c77: Expected O, but got I4
		//IL_0c84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c89: Expected O, but got Unknown
		//IL_0c92: Expected O, but got I4
		//IL_0c9b: Expected O, but got I4
		//IL_0dbe: Expected O, but got I
		//IL_0d54: Expected O, but got I
		//IL_0e1b: Expected O, but got Ref
		//IL_0e46: Expected O, but got Ref
		//IL_23be: Expected O, but got Ref
		//IL_2527: Expected O, but got Ref
		//IL_26ab: Expected O, but got Ref
		//IL_282f: Expected O, but got Ref
		//IL_29b3: Expected O, but got Ref
		//IL_16e5: Expected O, but got Ref
		//IL_18b8: Expected O, but got Ref
		//IL_1a68: Expected O, but got Ref
		//IL_1aa9: Expected O, but got Ref
		//IL_1c59: Expected O, but got Ref
		//IL_1c9a: Expected O, but got Ref
		//IL_1e4a: Expected O, but got Ref
		//IL_1e8b: Expected O, but got Ref
		//IL_203b: Expected O, but got Ref
		//IL_207c: Expected O, but got Ref
		base.OnRecycleEnemy();
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		Component component = (Component)(this + 136);
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
			base._003CIsCullable_003Ek__BackingField = false;
			base._003CIsTeleportOnCull_003Ek__BackingField = true;
			Tween sineTween = SineTween;
			if (SineTween != null && sineTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(SineTween);
			}
			_sineF = 1f;
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			float x = default(float);
			((EnemyCosmicEye)(object)dOSetter)._003COnRecycleEnemy_003Eb__31_1(x);
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, 2f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v136 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v136 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v136 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v136 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v136 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v136 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+98]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v136 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+99]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
							}
						}
					}
				}
			}
			SineTween = tweenerCore;
			GenerateSpritesAndAnimations();
			UpdateSprites();
			ArcadeSprite arcadeSprite = setVisible(visible: false);
			_isFirstUpdate = true;
			component = eyeModel;
			if ((object)eyeModel != null)
			{
				GameObject gameObject = eyeModel.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: true);
					Tween eyeScaleTween = _eyeScaleTween;
					if (_eyeScaleTween != null && eyeScaleTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_eyeScaleTween);
					}
					Transform transform = eyeModel.transform;
					Vector3 euler = default(Vector3);
					transform.localScale = (Vector3)(&euler);
					PhaserSprite[] allSprites = AllSprites;
					bool flag = AllSprites == null;
					component = transform;
					DOGetter<float> dOGetter = null;
					Component component2 = transform;
					DOGetter<float> dOGetter2 = null;
					if (!flag)
					{
						float ret = default(float);
						object obj2 = default(object);
						List<TweenerCore<Quaternion, Vector3, QuaternionOptions>>.Enumerator enumerator = default(List<TweenerCore<Quaternion, Vector3, QuaternionOptions>>.Enumerator);
						float value = default(float);
						float value2 = default(float);
						while (true)
						{
							if ((nint)dOGetter2 < allSprites.Length)
							{
								bool flag2 = (nint)dOGetter >= allSprites.Length;
								component = component2;
								if (!flag2)
								{
									bool flag3 = (object)allSprites[(object)dOGetter] == null;
									component = component2;
									if (flag3)
									{
										break;
									}
									PhaserSprite phaserSprite = allSprites[(object)dOGetter].setVisible(visible: true);
									PhaserSprite phaserSprite2 = allSprites[(object)dOGetter].setAlpha(1f);
									dOGetter = (DOGetter<float>)(dOGetter + 1);
									component2 = allSprites[(object)dOGetter];
									dOGetter2 = dOGetter;
									continue;
								}
							}
							else
							{
								bool flag4 = (object)_wingR1 == null;
								component = _wingR1;
								if (flag4)
								{
									break;
								}
								PhaserSprite phaserSprite3 = _wingR1.setOrigin(0f, (float?)(object)1);
								bool flag5 = (object)phaserSprite3 == null;
								component = _wingR1;
								if (flag5)
								{
									break;
								}
								PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0.85f);
								bool flag6 = (object)_wingL1 == null;
								component = _wingL1;
								if (flag6)
								{
									break;
								}
								PhaserSprite phaserSprite5 = _wingL1.setOrigin(1f, (float?)(object)1);
								bool flag7 = (object)phaserSprite5 == null;
								component = _wingL1;
								if (flag7)
								{
									break;
								}
								PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0.85f);
								bool flag8 = (object)_wingR2 == null;
								component = _wingR2;
								if (flag8)
								{
									break;
								}
								PhaserSprite phaserSprite7 = _wingR2.setOrigin(0f, (float?)(object)1);
								bool flag9 = (object)phaserSprite7 == null;
								component = _wingR2;
								if (flag9)
								{
									break;
								}
								PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(0.85f);
								bool flag10 = (object)_wingL2 == null;
								component = _wingL2;
								if (flag10)
								{
									break;
								}
								PhaserSprite phaserSprite9 = _wingL2.setOrigin(1f, (float?)(object)1);
								bool flag11 = (object)phaserSprite9 == null;
								component = _wingL2;
								if (flag11)
								{
									break;
								}
								PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(0.85f);
								bool flag12 = (object)_wingR3 == null;
								component = _wingR3;
								if (flag12)
								{
									break;
								}
								PhaserSprite phaserSprite11 = _wingR3.setOrigin(0f, (float?)(object)1);
								bool flag13 = (object)phaserSprite11 == null;
								component = _wingR3;
								if (flag13)
								{
									break;
								}
								PhaserSprite phaserSprite12 = phaserSprite11.setAlpha(0.85f);
								bool flag14 = (object)_wingL3 == null;
								component = _wingL3;
								if (flag14)
								{
									break;
								}
								PhaserSprite phaserSprite13 = _wingL3.setOrigin(1f, (float?)(object)1);
								bool flag15 = (object)phaserSprite13 == null;
								component = _wingL3;
								if (flag15)
								{
									break;
								}
								PhaserSprite phaserSprite14 = phaserSprite13.setAlpha(0.85f);
								bool flag16 = (object)_wingSmR1 == null;
								component = _wingSmR1;
								if (flag16)
								{
									break;
								}
								PhaserSprite phaserSprite15 = _wingSmR1.setOrigin(0f, (float?)(object)1);
								bool flag17 = (object)phaserSprite15 == null;
								component = _wingSmR1;
								if (flag17)
								{
									break;
								}
								PhaserSprite phaserSprite16 = phaserSprite15.setAlpha(0.85f);
								bool flag18 = (object)_wingSmL1 == null;
								component = _wingSmL1;
								if (flag18)
								{
									break;
								}
								PhaserSprite phaserSprite17 = _wingSmL1.setOrigin(1f, (float?)(object)1);
								bool flag19 = (object)phaserSprite17 == null;
								component = _wingSmL1;
								if (flag19)
								{
									break;
								}
								PhaserSprite phaserSprite18 = phaserSprite17.setAlpha(0.85f);
								bool flag20 = (object)_wingSmR2 == null;
								component = _wingSmR2;
								if (flag20)
								{
									break;
								}
								PhaserSprite phaserSprite19 = _wingSmR2.setOrigin(0f, (float?)(object)1);
								bool flag21 = (object)phaserSprite19 == null;
								component = _wingSmR2;
								if (flag21)
								{
									break;
								}
								PhaserSprite phaserSprite20 = phaserSprite19.setAlpha(0.85f);
								bool flag22 = (object)_wingSmL2 == null;
								component = _wingSmL2;
								if (flag22)
								{
									break;
								}
								PhaserSprite phaserSprite21 = _wingSmL2.setOrigin(1f, (float?)(object)1);
								bool flag23 = (object)phaserSprite21 == null;
								component = _wingSmL2;
								if (flag23)
								{
									break;
								}
								PhaserSprite phaserSprite22 = phaserSprite21.setAlpha(0.85f);
								bool flag24 = (object)_wingSmR3 == null;
								component = _wingSmR3;
								if (flag24)
								{
									break;
								}
								PhaserSprite phaserSprite23 = _wingSmR3.setOrigin(0f, (float?)(object)1);
								bool flag25 = (object)phaserSprite23 == null;
								component = _wingSmR3;
								if (flag25)
								{
									break;
								}
								PhaserSprite phaserSprite24 = phaserSprite23.setAlpha(0.85f);
								bool flag26 = (object)_wingSmL3 == null;
								component = _wingSmL3;
								if (flag26)
								{
									break;
								}
								PhaserSprite phaserSprite25 = _wingSmL3.setOrigin(1f, (float?)(object)1);
								bool flag27 = (object)phaserSprite25 == null;
								component = _wingSmL3;
								if (flag27)
								{
									break;
								}
								PhaserSprite phaserSprite26 = phaserSprite25.setAlpha(0.85f);
								bool flag28 = (object)_cachedTransform == null;
								component = phaserSprite25;
								if (flag28)
								{
									break;
								}
								Vector3 localScale = _cachedTransform.localScale;
								PhaserSprite[] allWings = AllWings;
								bool flag29 = AllWings == null;
								component = (Component)(&ret);
								if (flag29)
								{
									break;
								}
								float num = 0.85f;
								DOGetter<float> dOGetter3 = null;
								float? num2 = (float?)(object)0;
								object obj = 0;
								component = (Component)(&ret);
								DOGetter<float> dOGetter4 = null;
								while (true)
								{
									if ((nint)dOGetter4 < allWings.Length)
									{
										if ((nint)dOGetter3 >= allWings.Length)
										{
											break;
										}
										bool flag30 = (object)allWings[(object)dOGetter3] == null;
										component = allWings[(object)dOGetter3];
										if (flag30)
										{
											goto end_IL_2242;
										}
										PhaserSprite phaserSprite27 = allWings[(object)dOGetter3].setScale(localScale.x, (float?)(object)1);
										dOGetter3 = (DOGetter<float>)(dOGetter3 + 1);
										num = localScale.x;
										num2 = (float?)(object)1;
										obj = 0;
										component = allWings[(object)dOGetter3];
										dOGetter4 = dOGetter3;
										continue;
									}
									PhaserSprite[] allSmallWings = AllSmallWings;
									if (AllSmallWings == null)
									{
										goto end_IL_2242;
									}
									DOGetter<float> dOGetter5 = null;
									float x2 = localScale.x;
									DOGetter<float> dOGetter6 = null;
									while (true)
									{
										if ((nint)dOGetter6 < allSmallWings.Length)
										{
											if ((nint)dOGetter5 >= allSmallWings.Length)
											{
												break;
											}
											x2 = (float)obj2 * 0.75f;
											bool flag31 = (object)allSmallWings[(object)dOGetter5] == null;
											component = allSmallWings[(object)dOGetter5];
											if (flag31)
											{
												goto end_IL_2242;
											}
											num = localScale.x * 0.75f;
											PhaserSprite phaserSprite28 = allSmallWings[(object)dOGetter5].setScale(num, (float?)(object)1);
											dOGetter5 = (DOGetter<float>)(dOGetter5 + 1);
											num2 = (float?)(object)1;
											obj = 0;
											component = allSmallWings[(object)dOGetter5];
											dOGetter6 = dOGetter5;
											continue;
										}
										if (rotationTweens == null)
										{
											goto end_IL_2242;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3630 @ rax_v178+10]");
										Tween tween = (Tween)0;
										while (enumerator.MoveNext())
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3630 @ rax_v178+10]");
											if ((nint)0 != 0 && tween._003Cactive_003Ek__BackingField)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3630 @ rax_v178+10]");
												TweenExtensions.Kill((Tween)0);
											}
										}
										component = (Component)(object)rotationTweens;
										if (rotationTweens == null)
										{
											goto end_IL_2242;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v155 (UnityEngine.Component)+1C]");
										_ = (nint)0 + (nint)1;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v155 (UnityEngine.Component)+18]");
										if ((nint)0 > (nint)0)
										{
											IntPtr cachedPtr = ((UnityEngine.Object)component).m_CachedPtr;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v155 (UnityEngine.Component)+18]");
											Array.Clear((Array)(nint)cachedPtr, 0, 0);
										}
										if ((object)_wingR1 == null)
										{
											goto end_IL_2242;
										}
										Transform transform2 = _wingR1.transform;
										Quaternion quaternion2 = Quaternion.Euler(0f, -90f, 30f);
										transform2.rotation = (Quaternion)(&ret);
										Transform target = _wingR1.transform;
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target, (Vector3)(&euler), 2f, RotateMode.FastBeyond360);
										if (tweenerCore2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4282 @ rax_v187 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4282 @ rax_v187 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4282 @ rax_v187 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4282 @ rax_v187 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4282 @ rax_v187 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4282 @ rax_v187 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4282 @ rax_v187 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										Transform transform3 = _wingR2.transform;
										Quaternion quaternion3 = Quaternion.Euler(0f, -90f, 0f);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4693 @ rax_v189 (UnityEngine.Transform)+10]");
										bool flag32 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4693 @ rax_v189 (UnityEngine.Transform)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
										object wingR = _wingR2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1094 @ rdi_v61 (System.Object)+10]");
										bool flag33 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1094 @ rdi_v61 (System.Object)+10]");
										IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
										Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DORotate(target2, (Vector3)(&euler), 3f, RotateMode.FastBeyond360);
										if (tweenerCore3 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4870 @ rax_v200 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4870 @ rax_v200 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4870 @ rax_v200 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4870 @ rax_v200 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4870 @ rax_v200 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4870 @ rax_v200 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4870 @ rax_v200 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										object wingR2 = _wingR3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ rdi_v62 (System.Object)+10]");
										bool flag34 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ rdi_v62 (System.Object)+10]");
										IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
										Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
										Quaternion.Internal_FromEulerRad_Injected(ref euler, out *(Quaternion*)(&ret));
										bool flag35 = (object)transform4 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5637 @ rax_v206 (UnityEngine.Transform)+10]");
										bool flag36 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5637 @ rax_v206 (UnityEngine.Transform)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value2));
										object wingR3 = _wingR3;
										bool flag37 = (object)_wingR3 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1691 @ rdi_v64 (System.Object)+10]");
										bool flag38 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1691 @ rdi_v64 (System.Object)+10]");
										IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
										Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DORotate(target3, (Vector3)(&euler), 5f, RotateMode.FastBeyond360);
										if (tweenerCore4 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5471 @ rax_v219 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5471 @ rax_v219 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5471 @ rax_v219 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5471 @ rax_v219 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5471 @ rax_v219 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5471 @ rax_v219 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5471 @ rax_v219 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag39 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										object wingL = _wingL1;
										bool flag40 = (object)_wingL1 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1800 @ rdi_v65 (System.Object)+10]");
										bool flag41 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1800 @ rdi_v65 (System.Object)+10]");
										IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
										Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
										Quaternion.Internal_FromEulerRad_Injected(ref euler, out *(Quaternion*)(&ret));
										bool flag42 = (object)transform5 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5897 @ rax_v225 (UnityEngine.Transform)+10]");
										bool flag43 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5897 @ rax_v225 (UnityEngine.Transform)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
										object wingL2 = _wingL1;
										bool flag44 = (object)_wingL1 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2033 @ rdi_v67 (System.Object)+10]");
										bool flag45 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2033 @ rdi_v67 (System.Object)+10]");
										IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
										Transform target4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore5 = ShortcutExtensions.DORotate(target4, (Vector3)(&euler), 2f, RotateMode.FastBeyond360);
										if (tweenerCore5 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4970 @ rax_v238 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4970 @ rax_v238 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4970 @ rax_v238 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4970 @ rax_v238 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4970 @ rax_v238 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4970 @ rax_v238 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4970 @ rax_v238 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag46 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										object wingL3 = _wingL2;
										bool flag47 = (object)_wingL2 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rdi_v68 (System.Object)+10]");
										bool flag48 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rdi_v68 (System.Object)+10]");
										IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
										Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
										Quaternion.Internal_FromEulerRad_Injected(ref euler, out *(Quaternion*)(&ret));
										bool flag49 = (object)transform6 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6155 @ rax_v244 (UnityEngine.Transform)+10]");
										bool flag50 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6155 @ rax_v244 (UnityEngine.Transform)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value2));
										object wingL4 = _wingL2;
										bool flag51 = (object)_wingL2 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2347 @ rdi_v70 (System.Object)+10]");
										bool flag52 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2347 @ rdi_v70 (System.Object)+10]");
										IntPtr gcHandlePtr7 = Component.get_transform_Injected((IntPtr)0);
										Transform target5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DORotate(target5, (Vector3)(&euler), 3f, RotateMode.FastBeyond360);
										if (tweenerCore6 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4454 @ rax_v257 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4454 @ rax_v257 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4454 @ rax_v257 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4454 @ rax_v257 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4454 @ rax_v257 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4454 @ rax_v257 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4454 @ rax_v257 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag53 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										object wingL5 = _wingL3;
										bool flag54 = (object)_wingL3 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2431 @ rdi_v71 (System.Object)+10]");
										bool flag55 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2431 @ rdi_v71 (System.Object)+10]");
										IntPtr gcHandlePtr8 = Component.get_transform_Injected((IntPtr)0);
										Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
										Quaternion.Internal_FromEulerRad_Injected(ref euler, out *(Quaternion*)(&ret));
										bool flag56 = (object)transform7 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6411 @ rax_v263 (UnityEngine.Transform)+10]");
										bool flag57 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6411 @ rax_v263 (UnityEngine.Transform)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
										object wingL6 = _wingL3;
										bool flag58 = (object)_wingL3 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2660 @ rdi_v73 (System.Object)+10]");
										bool flag59 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2660 @ rdi_v73 (System.Object)+10]");
										IntPtr gcHandlePtr9 = Component.get_transform_Injected((IntPtr)0);
										Transform target6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr9);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore7 = ShortcutExtensions.DORotate(target6, (Vector3)(&euler), 5f, RotateMode.FastBeyond360);
										if (tweenerCore7 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4032 @ rax_v276 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4032 @ rax_v276 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4032 @ rax_v276 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4032 @ rax_v276 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4032 @ rax_v276 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4032 @ rax_v276 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4032 @ rax_v276 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag60 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										bool flag61 = (object)_wingSmR1 == null;
										Transform transform8 = _wingSmR1.transform;
										Quaternion quaternion4 = Quaternion.Euler(0f, -90f, 30f);
										bool flag62 = (object)transform8 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6625 @ rax_v278 (UnityEngine.Transform)+10]");
										bool flag63 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6625 @ rax_v278 (UnityEngine.Transform)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value2));
										bool flag64 = (object)_wingSmR1 == null;
										Transform target7 = _wingSmR1.transform;
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore8 = ShortcutExtensions.DORotate(target7, (Vector3)(&euler), 7f, RotateMode.FastBeyond360);
										if (tweenerCore8 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ rax_v285 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ rax_v285 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ rax_v285 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ rax_v285 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ rax_v285 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ rax_v285 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3735 @ rax_v285 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag65 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										bool flag66 = (object)_wingSmR2 == null;
										Transform transform9 = _wingSmR2.transform;
										Quaternion quaternion5 = Quaternion.Euler(0f, -90f, 0f);
										bool flag67 = (object)transform9 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6773 @ rax_v287 (UnityEngine.Transform)+10]");
										bool flag68 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6773 @ rax_v287 (UnityEngine.Transform)+10]");
										Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
										bool flag69 = (object)_wingSmR2 == null;
										Transform target8 = _wingSmR2.transform;
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore9 = ShortcutExtensions.DORotate(target8, (Vector3)(&euler), 5f, RotateMode.FastBeyond360);
										if (tweenerCore9 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3532 @ rax_v294 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3532 @ rax_v294 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3532 @ rax_v294 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3532 @ rax_v294 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3532 @ rax_v294 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3532 @ rax_v294 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3532 @ rax_v294 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag70 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										bool flag71 = (object)_wingSmR3 == null;
										Transform transform10 = _wingSmR3.transform;
										Quaternion quaternion6 = Quaternion.Euler(0f, -60f, 30f);
										bool flag72 = (object)transform10 == null;
										transform10.rotation = (Quaternion)(&value2);
										bool flag73 = (object)_wingSmR3 == null;
										Transform target9 = _wingSmR3.transform;
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore10 = ShortcutExtensions.DORotate(target9, (Vector3)(&euler), 3f, RotateMode.FastBeyond360);
										if (tweenerCore10 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3333 @ rax_v300 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3333 @ rax_v300 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3333 @ rax_v300 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3333 @ rax_v300 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3333 @ rax_v300 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3333 @ rax_v300 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3333 @ rax_v300 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag74 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										bool flag75 = (object)_wingSmL1 == null;
										Transform transform11 = _wingSmL1.transform;
										Quaternion quaternion7 = Quaternion.Euler(0f, -90f, -30f);
										bool flag76 = (object)transform11 == null;
										transform11.rotation = (Quaternion)(&value);
										bool flag77 = (object)_wingSmL1 == null;
										Transform target10 = _wingSmL1.transform;
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore11 = ShortcutExtensions.DORotate(target10, (Vector3)(&euler), 7f, RotateMode.FastBeyond360);
										if (tweenerCore11 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3212 @ rax_v306 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3212 @ rax_v306 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3212 @ rax_v306 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3212 @ rax_v306 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3212 @ rax_v306 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3212 @ rax_v306 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3212 @ rax_v306 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag78 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										bool flag79 = (object)_wingSmL2 == null;
										Transform transform12 = _wingSmL2.transform;
										Quaternion quaternion8 = Quaternion.Euler(0f, -90f, 0f);
										bool flag80 = (object)transform12 == null;
										transform12.rotation = (Quaternion)(&value2);
										bool flag81 = (object)_wingSmL2 == null;
										Transform target11 = _wingSmL2.transform;
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore12 = ShortcutExtensions.DORotate(target11, (Vector3)(&euler), 5f, RotateMode.FastBeyond360);
										if (tweenerCore12 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ rax_v312 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ rax_v312 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ rax_v312 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ rax_v312 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ rax_v312 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ rax_v312 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ rax_v312 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag82 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										bool flag83 = (object)_wingSmL3 == null;
										Transform transform13 = _wingSmL3.transform;
										Quaternion quaternion9 = Quaternion.Euler(0f, -60f, -30f);
										bool flag84 = (object)transform13 == null;
										transform13.rotation = (Quaternion)(&value);
										bool flag85 = (object)_wingSmL3 == null;
										Transform target12 = _wingSmL3.transform;
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore13 = ShortcutExtensions.DORotate(target12, (Vector3)(&euler), 3f, RotateMode.FastBeyond360);
										if (tweenerCore13 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2970 @ rax_v318 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2970 @ rax_v318 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
												if ((nint)0 == 0)
												{
													_ = 4294967295L;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2970 @ rax_v318 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
													if ((nint)0 == 0)
													{
														_ = 2139095040;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2970 @ rax_v318 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2970 @ rax_v318 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2970 @ rax_v318 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2970 @ rax_v318 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
														}
													}
												}
											}
										}
										bool flag86 = rotationTweens == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3140");
										return;
									}
									break;
								}
							}
							throw new IndexOutOfRangeException();
							continue;
							end_IL_2242:
							break;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void GenerateSpritesAndAnimations()
	{
		//IL_121f: Expected O, but got I4
		//IL_1228: Expected O, but got I4
		//IL_125f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1264: Expected O, but got Unknown
		//IL_09a0: Expected I, but got O
		//IL_09f8: Expected I, but got O
		//IL_0a50: Expected I, but got O
		//IL_0aa8: Expected I, but got O
		//IL_0b00: Expected I, but got O
		//IL_0b58: Expected I, but got O
		//IL_0bd2: Expected I, but got O
		//IL_0c2a: Expected I, but got O
		//IL_0c82: Expected I, but got O
		//IL_0cda: Expected I, but got O
		//IL_0d32: Expected I, but got O
		//IL_0d8a: Expected I, but got O
		//IL_0e04: Expected I, but got O
		//IL_0e5c: Expected I, but got O
		//IL_0eb4: Expected I, but got O
		//IL_0f0c: Expected I, but got O
		//IL_0f64: Expected I, but got O
		//IL_0fbc: Expected I, but got O
		//IL_1014: Expected I, but got O
		//IL_106c: Expected I, but got O
		//IL_10c4: Expected I, but got O
		//IL_111c: Expected I, but got O
		//IL_1174: Expected I, but got O
		//IL_11cc: Expected I, but got O
		if (!_hasGeneratedSprites)
		{
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "enemies2023", "desWingL_i01.png");
				GameObject gameObject = phaserSprite.gameObject;
				((UnityEngine.Object)gameObject).SetName("CosmicEye - WingL1");
				_wingL1 = phaserSprite;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					float2 float6 = base.position;
					PhaserSprite phaserSprite2 = RenderingExtensions.sprite(s_scene2.add, pos, "enemies2023", "desWing_i01.png");
					GameObject gameObject2 = phaserSprite2.gameObject;
					((UnityEngine.Object)gameObject2).SetName("CosmicEye - WingR1");
					_wingR1 = phaserSprite2;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						float2 float7 = base.position;
						PhaserSprite phaserSprite3 = RenderingExtensions.sprite(s_scene3.add, pos, "enemies2023", "desWingL_i01.png");
						GameObject gameObject3 = phaserSprite3.gameObject;
						((UnityEngine.Object)gameObject3).SetName("CosmicEye - WingL2");
						_wingL2 = phaserSprite3;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene4 = ArcadePhysics.s_scene;
							float2 float8 = base.position;
							PhaserSprite phaserSprite4 = RenderingExtensions.sprite(s_scene4.add, pos, "enemies2023", "desWing_i01.png");
							GameObject gameObject4 = phaserSprite4.gameObject;
							((UnityEngine.Object)gameObject4).SetName("CosmicEye - WingR2");
							_wingR2 = phaserSprite4;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene5 = ArcadePhysics.s_scene;
								float2 float9 = base.position;
								PhaserSprite phaserSprite5 = RenderingExtensions.sprite(s_scene5.add, pos, "enemies2023", "desWingL_i01.png");
								GameObject gameObject5 = phaserSprite5.gameObject;
								((UnityEngine.Object)gameObject5).SetName("CosmicEye - WingL3");
								_wingL3 = phaserSprite5;
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene6 = ArcadePhysics.s_scene;
									float2 float10 = base.position;
									PhaserSprite phaserSprite6 = RenderingExtensions.sprite(s_scene6.add, pos, "enemies2023", "desWing_i01.png");
									GameObject gameObject6 = phaserSprite6.gameObject;
									((UnityEngine.Object)gameObject6).SetName("CosmicEye - WingR3");
									_wingR3 = phaserSprite6;
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene7 = ArcadePhysics.s_scene;
										float2 float11 = base.position;
										PhaserSprite phaserSprite7 = RenderingExtensions.sprite(s_scene7.add, pos, "enemies2023", "desWingL_i01.png");
										GameObject gameObject7 = phaserSprite7.gameObject;
										((UnityEngine.Object)gameObject7).SetName("CosmicEye - WingSmL1");
										_wingSmL1 = phaserSprite7;
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene8 = ArcadePhysics.s_scene;
											float2 float12 = base.position;
											PhaserSprite phaserSprite8 = RenderingExtensions.sprite(s_scene8.add, pos, "enemies2023", "desWing_i01.png");
											GameObject gameObject8 = phaserSprite8.gameObject;
											((UnityEngine.Object)gameObject8).SetName("CosmicEye - WingSmR1");
											_wingSmR1 = phaserSprite8;
											if ((object)GM.Core != null)
											{
												PhaserScene s_scene9 = ArcadePhysics.s_scene;
												float2 float13 = base.position;
												PhaserSprite phaserSprite9 = RenderingExtensions.sprite(s_scene9.add, pos, "enemies2023", "desWingL_i01.png");
												GameObject gameObject9 = phaserSprite9.gameObject;
												((UnityEngine.Object)gameObject9).SetName("CosmicEye - WingSmL2");
												_wingSmL2 = phaserSprite9;
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene10 = ArcadePhysics.s_scene;
													float2 float14 = base.position;
													PhaserSprite phaserSprite10 = RenderingExtensions.sprite(s_scene10.add, pos, "enemies2023", "desWing_i01.png");
													GameObject gameObject10 = phaserSprite10.gameObject;
													((UnityEngine.Object)gameObject10).SetName("CosmicEye - WingSmR2");
													_wingSmR2 = phaserSprite10;
													if ((object)GM.Core != null)
													{
														PhaserScene s_scene11 = ArcadePhysics.s_scene;
														float2 float15 = base.position;
														PhaserSprite phaserSprite11 = RenderingExtensions.sprite(s_scene11.add, pos, "enemies2023", "desWingL_i01.png");
														GameObject gameObject11 = phaserSprite11.gameObject;
														((UnityEngine.Object)gameObject11).SetName("CosmicEye - WingSmL3");
														_wingSmL3 = phaserSprite11;
														if ((object)GM.Core != null)
														{
															PhaserScene s_scene12 = ArcadePhysics.s_scene;
															float2 float16 = base.position;
															PhaserSprite phaserSprite12 = RenderingExtensions.sprite(s_scene12.add, pos, "enemies2023", "desWing_i01.png");
															GameObject gameObject12 = phaserSprite12.gameObject;
															((UnityEngine.Object)gameObject12).SetName("CosmicEye - WingSmR3");
															_wingSmR3 = phaserSprite12;
															string animName = "desWingL_i01.png".Replace("1.png", "");
															int num = default(int);
															List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 5, "enemies2023", num);
															PhaserSprite wingL = _wingL1;
															bool startRandomFrame = default(bool);
															Action onComplete = default(Action);
															bool autoSetAnimation = default(bool);
															wingL._spriteAnimation.AddAnimation("idle", animationFrames, 11, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingL2 = _wingL2;
															wingL2._spriteAnimation.AddAnimation("idle", animationFrames, 13, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingL3 = _wingL3;
															wingL3._spriteAnimation.AddAnimation("idle", animationFrames, 17, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingSmL = _wingSmL1;
															wingSmL._spriteAnimation.AddAnimation("idle", animationFrames, 11, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingSmL2 = _wingSmL2;
															wingSmL2._spriteAnimation.AddAnimation("idle", animationFrames, 13, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingSmL3 = _wingSmL3;
															wingSmL3._spriteAnimation.AddAnimation("idle", animationFrames, 17, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															string animName2 = "desWing_i01.png".Replace("1.png", "");
															List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName2, 1, 5, "enemies2023", num);
															PhaserSprite wingR = _wingR1;
															wingR._spriteAnimation.AddAnimation("idle", animationFrames2, 11, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingR2 = _wingR2;
															wingR2._spriteAnimation.AddAnimation("idle", animationFrames2, 13, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingR3 = _wingR3;
															wingR3._spriteAnimation.AddAnimation("idle", animationFrames2, 17, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingSmR = _wingSmR1;
															wingSmR._spriteAnimation.AddAnimation("idle", animationFrames2, 11, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingSmR2 = _wingSmR2;
															wingSmR2._spriteAnimation.AddAnimation("idle", animationFrames2, 13, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															PhaserSprite wingSmR3 = _wingSmR3;
															wingSmR3._spriteAnimation.AddAnimation("idle", animationFrames2, 17, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
															_hasGeneratedSprites = true;
															PhaserSprite[] array = new PhaserSprite[6];
															if ((object)_wingL1 != null)
															{
																nint num2 = (nint)array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj = default(object);
																if (obj == null)
																{
																	ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																	throw ex;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingR1 != null)
															{
																nint num3 = (nint)array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj2 = default(object);
																if (obj2 == null)
																{
																	ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
																	throw ex2;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingL2 != null)
															{
																nint num4 = (nint)array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj3 = default(object);
																if (obj3 == null)
																{
																	ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
																	throw ex3;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingR2 != null)
															{
																nint num5 = (nint)array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj4 = default(object);
																if (obj4 == null)
																{
																	ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
																	throw ex4;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingL3 != null)
															{
																nint num6 = (nint)array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj5 = default(object);
																if (obj5 == null)
																{
																	ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
																	throw ex5;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingR3 != null)
															{
																nint num7 = (nint)array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj6 = default(object);
																if (obj6 == null)
																{
																	ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
																	throw ex6;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															AllWings = array;
															PhaserSprite[] array2 = new PhaserSprite[6];
															if ((object)_wingSmL1 != null)
															{
																nint num8 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj7 = default(object);
																if (obj7 == null)
																{
																	ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
																	throw ex7;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmR1 != null)
															{
																nint num9 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj8 = default(object);
																if (obj8 == null)
																{
																	ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
																	throw ex8;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmL2 != null)
															{
																nint num10 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj9 = default(object);
																if (obj9 == null)
																{
																	ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
																	throw ex9;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmR2 != null)
															{
																nint num11 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj10 = default(object);
																if (obj10 == null)
																{
																	ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
																	throw ex10;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmL3 != null)
															{
																nint num12 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj11 = default(object);
																if (obj11 == null)
																{
																	ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
																	throw ex11;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmR3 != null)
															{
																nint num13 = (nint)array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj12 = default(object);
																if (obj12 == null)
																{
																	ArrayTypeMismatchException ex12 = new ArrayTypeMismatchException();
																	throw ex12;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															AllSmallWings = array2;
															PhaserSprite[] array3 = new PhaserSprite[12];
															if ((object)_wingL1 != null)
															{
																nint num14 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj13 = default(object);
																if (obj13 == null)
																{
																	ArrayTypeMismatchException ex13 = new ArrayTypeMismatchException();
																	throw ex13;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingR1 != null)
															{
																nint num15 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj14 = default(object);
																if (obj14 == null)
																{
																	ArrayTypeMismatchException ex14 = new ArrayTypeMismatchException();
																	throw ex14;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingL2 != null)
															{
																nint num16 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj15 = default(object);
																if (obj15 == null)
																{
																	ArrayTypeMismatchException ex15 = new ArrayTypeMismatchException();
																	throw ex15;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingR2 != null)
															{
																nint num17 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj16 = default(object);
																if (obj16 == null)
																{
																	ArrayTypeMismatchException ex16 = new ArrayTypeMismatchException();
																	throw ex16;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingL3 != null)
															{
																nint num18 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj17 = default(object);
																if (obj17 == null)
																{
																	ArrayTypeMismatchException ex17 = new ArrayTypeMismatchException();
																	throw ex17;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingR3 != null)
															{
																nint num19 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj18 = default(object);
																if (obj18 == null)
																{
																	ArrayTypeMismatchException ex18 = new ArrayTypeMismatchException();
																	throw ex18;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmL1 != null)
															{
																nint num20 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj19 = default(object);
																if (obj19 == null)
																{
																	ArrayTypeMismatchException ex19 = new ArrayTypeMismatchException();
																	throw ex19;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmR1 != null)
															{
																nint num21 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj20 = default(object);
																if (obj20 == null)
																{
																	ArrayTypeMismatchException ex20 = new ArrayTypeMismatchException();
																	throw ex20;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmL2 != null)
															{
																nint num22 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj21 = default(object);
																if (obj21 == null)
																{
																	ArrayTypeMismatchException ex21 = new ArrayTypeMismatchException();
																	throw ex21;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmR2 != null)
															{
																nint num23 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj22 = default(object);
																if (obj22 == null)
																{
																	ArrayTypeMismatchException ex22 = new ArrayTypeMismatchException();
																	throw ex22;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmL3 != null)
															{
																nint num24 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj23 = default(object);
																if (obj23 == null)
																{
																	ArrayTypeMismatchException ex23 = new ArrayTypeMismatchException();
																	throw ex23;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_wingSmR3 != null)
															{
																nint num25 = (nint)array3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj24 = default(object);
																if (obj24 == null)
																{
																	ArrayTypeMismatchException ex24 = new ArrayTypeMismatchException();
																	throw ex24;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															AllSprites = array3;
															goto IL_120c;
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
		goto IL_120c;
		IL_120c:
		PhaserSprite[] allSprites = AllSprites;
		object obj25 = 0;
		object obj26 = 0;
		while ((nint)obj26 < allSprites.Length)
		{
			PhaserSprite phaserSprite13 = allSprites[obj25];
			phaserSprite13._spriteAnimation.SetAnimation("idle");
			obj25++;
			obj26 = obj25;
		}
	}

	private unsafe void UpdateSprites()
	{
		//IL_0024: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected O, but got Unknown
		//IL_05ed->IL04e2: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL04e2: Incompatible stack heights: 1 vs 0
		//IL_0105->IL04e2: Incompatible stack heights: 1 vs 0
		//IL_05cc->IL05f2: Incompatible stack heights: 4 vs 0
		PhaserSprite[] allSprites = AllSprites;
		bool flag = AllSprites == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			Vector3 value = default(Vector3);
			while (true)
			{
				if ((nint)obj < allSprites.Length)
				{
					Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
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
					if ((object)allSprites[obj2] == null)
					{
						break;
					}
					Transform transform = allSprites[obj2].transform;
					Transform transform2 = allSprites[obj2].transform;
					if ((object)transform2 == null)
					{
						break;
					}
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
					bool flag4 = (object)transform == null;
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					obj2++;
					obj = obj2;
					continue;
				}
				ArcadeSprite arcadeSprite = setDepth(2000);
				int num = base.depth;
				if ((object)_wingR1 == null)
				{
					break;
				}
				int num2 = num - 1;
				PhaserSprite phaserSprite = _wingR1.setDepth(num2);
				int num3 = base.depth;
				if ((object)_wingL1 == null)
				{
					break;
				}
				int num4 = num3 - 1;
				PhaserSprite phaserSprite2 = _wingL1.setDepth(num4);
				int num5 = base.depth;
				if ((object)_wingR2 == null)
				{
					break;
				}
				int num6 = num5 - 2;
				PhaserSprite phaserSprite3 = _wingR2.setDepth(num6);
				int num7 = base.depth;
				if ((object)_wingL2 == null)
				{
					break;
				}
				int num8 = num7 - 2;
				PhaserSprite phaserSprite4 = _wingL2.setDepth(num8);
				int num9 = base.depth;
				if ((object)_wingR3 == null)
				{
					break;
				}
				int num10 = num9 - 2;
				PhaserSprite phaserSprite5 = _wingR3.setDepth(num10);
				int num11 = base.depth;
				if ((object)_wingL3 == null)
				{
					break;
				}
				int num12 = num11 - 2;
				PhaserSprite phaserSprite6 = _wingL3.setDepth(num12);
				int num13 = base.depth;
				if ((object)_wingSmR1 == null)
				{
					break;
				}
				int num14 = num13 - 3;
				PhaserSprite phaserSprite7 = _wingSmR1.setDepth(num14);
				int num15 = base.depth;
				if ((object)_wingSmL1 == null)
				{
					break;
				}
				int num16 = num15 - 3;
				PhaserSprite phaserSprite8 = _wingSmL1.setDepth(num16);
				int num17 = base.depth;
				if ((object)_wingSmR2 == null)
				{
					break;
				}
				int num18 = num17 - 4;
				PhaserSprite phaserSprite9 = _wingSmR2.setDepth(num18);
				int num19 = base.depth;
				if ((object)_wingSmL2 == null)
				{
					break;
				}
				int num20 = num19 - 4;
				PhaserSprite phaserSprite10 = _wingSmL2.setDepth(num20);
				int num21 = base.depth;
				if ((object)_wingSmR3 == null)
				{
					break;
				}
				int num22 = num21 - 4;
				PhaserSprite phaserSprite11 = _wingSmR3.setDepth(num22);
				int num23 = base.depth;
				if ((object)_wingSmL3 == null)
				{
					break;
				}
				int num24 = num23 - 4;
				PhaserSprite phaserSprite12 = _wingSmL3.setDepth(num24);
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		base.OnUpdate();
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_isFirstUpdate)
			{
				_isFirstUpdate = false;
				RandomEyeAngle();
			}
			UpdateSprites();
		}
	}

	protected override void Die()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		GameObject gameObject = eyeModel.gameObject;
		gameObject.SetActive(value: false);
		base.Die();
	}

	protected override void OnDeathAnimationComplete()
	{
		//IL_0054: Expected O, but got I4
		if (_spritesDeathTween != null)
		{
			_spritesDeathTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.targets = AllSprites;
		tweenConfig.duration = 500f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween spritesDeathTween = Tweens.Add(tweenConfig);
		_spritesDeathTween = spritesDeathTween;
	}

	private void LateUpdate()
	{
		//IL_0088->IL0088: Incompatible stack heights: 1 vs 0
		if (PauseSystem._paused)
		{
			Transform transform = eyeModel.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	public unsafe override void Disappear()
	{
		//IL_0149: Expected O, but got Ref
		//IL_00be: Expected O, but got I4
		base.Disappear();
		Tween eyeScaleTween = _eyeScaleTween;
		if (_eyeScaleTween != null && eyeScaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_eyeScaleTween);
		}
		Transform target = eyeModel.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> eyeScaleTween2 = ShortcutExtensions.DOScale(target, (Vector3)(&obj), 0.4f);
		_eyeScaleTween = eyeScaleTween2;
		if (_disappearTween != null)
		{
			_disappearTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.targets = AllSprites;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_0035: Expected O, but got I4
			//IL_003e: Expected O, but got I4
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			GameObject gameObject = eyeModel.gameObject;
			gameObject.SetActive(value: false);
			PhaserSprite[] allSprites = AllSprites;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj3 < allSprites.Length)
			{
				PhaserSprite phaserSprite = allSprites[obj2].setVisible(visible: false);
				obj2++;
				obj3 = obj2;
			}
			if (!base._003CIsDead_003Ek__BackingField)
			{
				if (_selfDestruct)
				{
					_AlertSpriteRenderer.forceRenderingOff = true;
					Tween alertTween = _alertTween;
					if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_alertTween);
					}
				}
				base._003CIsDead_003Ek__BackingField = true;
				_deathStyle = EnemyDeathStyle.Disappear;
				PlayDeathAnimation();
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween disappearTween = Tweens.Add(tweenConfig);
		_disappearTween = disappearTween;
	}

	public override void Despawn()
	{
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		base.Despawn();
		GameObject gameObject = eyeModel.gameObject;
		gameObject.SetActive(value: false);
		PhaserSprite[] allSprites = AllSprites;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < allSprites.Length)
		{
			PhaserSprite phaserSprite = allSprites[obj].setVisible(visible: false);
			obj++;
			obj2 = obj;
		}
	}

	public EnemyCosmicEye()
	{
		List<TweenerCore<Quaternion, Vector3, QuaternionOptions>> list = new List<TweenerCore<Quaternion, Vector3, QuaternionOptions>>();
		rotationTweens = list;
		base._002Ector();
	}

	private float _003CRandomEyeAngle_003Eb__30_0()
	{
		return _eyeRotationX;
	}

	private void _003CRandomEyeAngle_003Eb__30_1(float x)
	{
		_eyeRotationX = x;
	}

	private float _003CRandomEyeAngle_003Eb__30_2()
	{
		return _eyeRotationY;
	}

	private void _003CRandomEyeAngle_003Eb__30_3(float x)
	{
		_eyeRotationY = x;
	}

	private void _003CRandomEyeAngle_003Eb__30_4()
	{
		Transform transform = eyeModel.transform;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private float _003COnRecycleEnemy_003Eb__31_0()
	{
		return _sineF;
	}

	private void _003COnRecycleEnemy_003Eb__31_1(float x)
	{
		_sineF = x;
	}

	private void _003COnDeathAnimationComplete_003Eb__36_0()
	{
		Despawn();
	}

	private void _003CDisappear_003Eb__38_0()
	{
		//IL_0035: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		GameObject gameObject = eyeModel.gameObject;
		gameObject.SetActive(value: false);
		PhaserSprite[] allSprites = AllSprites;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < allSprites.Length)
		{
			PhaserSprite phaserSprite = allSprites[obj].setVisible(visible: false);
			obj++;
			obj2 = obj;
		}
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if (_selfDestruct)
		{
			_AlertSpriteRenderer.forceRenderingOff = true;
			Tween alertTween = _alertTween;
			if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(_alertTween);
			}
		}
		base._003CIsDead_003Ek__BackingField = true;
		_deathStyle = EnemyDeathStyle.Disappear;
		PlayDeathAnimation();
	}
}
