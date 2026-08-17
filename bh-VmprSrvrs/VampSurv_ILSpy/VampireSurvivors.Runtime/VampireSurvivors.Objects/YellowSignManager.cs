using System;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.Objects;

public class YellowSignManager : GameMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public Action onComplete;

		internal void _003CDoClaps_003Eb__0()
		{
			if (onComplete != null)
			{
				Action action = onComplete;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private Canvas _Canvas;

	private GameObject _Clapper;

	private RectTransform _ZoomTarget;

	private UISpriteAnimation _InAnimation;

	private UISpriteAnimation _OutAnimation;

	private Image _Blackout;

	private RectTransform _Panel;

	private List<Vector3> _PanelPositions;

	private List<Vector3> _PanelScales;

	private int _zoomIndex;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private AchievementManager _achievementManager;

	private float _orthoCameraSize;

	private float _orthoCameraIteration;

	private float _orthoCameraZoomTarget;

	private Vector3 _cameraPos;

	private Vector3 _screenPos;

	private void Construct(SignalBus signalBus, PlayerOptions playerOptions, AchievementManager achievementManager)
	{
		_signalBus = signalBus;
		_playerOptions = playerOptions;
		_achievementManager = achievementManager;
	}

	protected override void OnEnable()
	{
		//IL_004e: Expected O, but got F4
		base.OnEnable();
		Camera main = Camera.main;
		bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
		float num = default(float);
		_orthoCameraSize = num;
		float num2 = num - _orthoCameraZoomTarget;
		float orthoCameraIteration = num2 / 5f;
		_orthoCameraIteration = orthoCameraIteration;
	}

	public void DoClaps(Action onComplete = null)
	{
		//IL_0231->IL01a1: Incompatible stack heights: 1 vs 0
		//IL_0098->IL01a1: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass20_0();
		if (CS_0024_003C_003E8__locals4 != null)
		{
			CS_0024_003C_003E8__locals4.onComplete = onComplete;
			Camera main = Camera.main;
			if ((object)main != null)
			{
				Transform transform = main.transform;
				if ((object)transform != null)
				{
					bool flag = ((Delegate)(object)transform).method_ptr == (IntPtr)0;
					Transform.get_position_Injected(((Delegate)(object)transform).method_ptr, out Vector3 ret);
					_cameraPos = ret;
					_ = 0;
					Camera main2 = Camera.main;
					if ((object)_ZoomTarget != null)
					{
						Vector2 anchoredPosition = _ZoomTarget.anchoredPosition;
						if ((object)main2 != null)
						{
							bool flag2 = ((Delegate)(object)main2).method_ptr == (IntPtr)0;
							Vector3 position = default(Vector3);
							Camera.ScreenToWorldPoint_Injected(((Delegate)(object)main2).method_ptr, ref position, Camera.MonoOrStereoscopicEye.Mono, out ret);
							_screenPos = ret;
							_ = 0;
							SoundManager.StopSound(SfxType.Wind);
							Tween tween = Clap(0f);
							Tween tween2 = Clap(1f);
							Tween tween3 = Clap(2f);
							Tween tween4 = Clap(3f);
							Tween tween5 = Clap(4f);
							Sequence sequence = DOTween.Sequence();
							Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 7f);
							TweenCallback onComplete2 = delegate
							{
								if (CS_0024_003C_003E8__locals4.onComplete != null)
								{
									Action onComplete3 = CS_0024_003C_003E8__locals4.onComplete;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								}
							};
							if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
							{
								sequence.onComplete = onComplete2;
							}
							UnlockWeapons();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private Tween Clap(float clapDelay)
	{
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, clapDelay);
		TweenCallback tweenCallback = delegate
		{
			int zeroPad = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("clap", 1, 6, "backgroundX", zeroPad);
			UISpriteAnimation inAnimation = _InAnimation;
			inAnimation.sprites = animationFrames;
			_Clapper.SetActive(value: true);
			_InAnimation.Play();
			UISpriteAnimation inAnimation2 = _InAnimation;
			Action onComplete = PlayClapSound;
			inAnimation2._onComplete = onComplete;
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					goto IL_0170;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message);
		goto IL_0170;
		IL_0170:
		return sequence;
	}

	private void PlayClapSound()
	{
		Zoom();
		UISpriteAnimation inAnimation = _InAnimation;
		inAnimation._onComplete = null;
	}

	private unsafe void Zoom()
	{
		//IL_0076: Expected O, but got I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0c18: Expected O, but got I
		//IL_0951: Expected O, but got I
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_0c8f: Expected O, but got I4
		//IL_0c98: Expected O, but got I4
		//IL_0c4b: Expected O, but got I
		//IL_0689: Expected O, but got I
		//IL_09ab: Expected O, but got I4
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Expected O, but got Unknown
		//IL_03c1: Expected O, but got I
		//IL_0d97: Expected O, but got I
		//IL_06e3: Expected O, but got I4
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected O, but got Unknown
		//IL_041b: Expected O, but got I4
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected O, but got Unknown
		//IL_015c: Expected O, but got I
		//IL_0df1: Expected O, but got I4
		//IL_0dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e00: Expected O, but got Unknown
		//IL_01b6: Expected O, but got I
		//IL_0a8e: Expected O, but got I
		//IL_07c6: Expected O, but got I
		//IL_12d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12da: Expected O, but got Unknown
		//IL_0ae8: Expected O, but got I4
		//IL_0af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Expected O, but got Unknown
		//IL_04fe: Expected O, but got I
		//IL_0820: Expected O, but got I4
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_082f: Expected O, but got Unknown
		//IL_1298: Unknown result type (might be due to invalid IL or missing references)
		//IL_129d: Expected O, but got Unknown
		//IL_1193: Unknown result type (might be due to invalid IL or missing references)
		//IL_1198: Expected O, but got Unknown
		//IL_11f9: Expected O, but got I
		//IL_0558: Expected O, but got I4
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Expected O, but got Unknown
		//IL_0b89: Expected O, but got I
		//IL_0bae: Expected F4, but got I4
		//IL_10fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1103: Expected O, but got Unknown
		//IL_1164: Expected O, but got I
		//IL_0e87: Expected O, but got I
		//IL_08c1: Expected O, but got I
		//IL_08e6: Expected F4, but got I4
		//IL_1045: Unknown result type (might be due to invalid IL or missing references)
		//IL_104a: Expected O, but got Unknown
		//IL_10ab: Expected O, but got I
		//IL_05f9: Expected O, but got I
		//IL_061e: Expected F4, but got I4
		//IL_0ee1: Expected O, but got I4
		//IL_0eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef0: Expected O, but got Unknown
		//IL_13ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b3: Expected O, but got Unknown
		//IL_1406: Expected O, but got I
		//IL_0f36: Expected F4, but got I4
		//IL_0fe6->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0034->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0bdd->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0c02->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0917->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_064f->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0971->IL0f5e: Incompatible stack heights: 2 vs 0
		//IL_0ca1->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0387->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0d5d->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_06a9->IL0f5e: Incompatible stack heights: 2 vs 0
		//IL_09ee->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_03e1->IL0f5e: Incompatible stack heights: 2 vs 0
		//IL_00f6->IL0f5e: Incompatible stack heights: 1 vs 0
		//IL_0db7->IL0f5e: Incompatible stack heights: 2 vs 0
		//IL_0a1c->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_0726->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_0d16->IL0f5e: Incompatible stack heights: 2 vs 0
		//IL_0a54->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_0754->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_045e->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_0e34->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_078c->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_048c->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_0aae->IL0f5e: Incompatible stack heights: 4 vs 0
		//IL_1259->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_04c4->IL0f5e: Incompatible stack heights: 3 vs 0
		//IL_07e6->IL0f5e: Incompatible stack heights: 4 vs 0
		//IL_1313->IL0f5e: Incompatible stack heights: 4 vs 0
		//IL_051e->IL0f5e: Incompatible stack heights: 4 vs 0
		//IL_12ab->IL0ca6: Incompatible stack heights: 4 vs 1
		//IL_137f->IL0f5e: Incompatible stack heights: 5 vs 0
		//IL_10d4->IL0f43: Incompatible stack heights: 7 vs 1
		//IL_0ea7->IL0f5e: Incompatible stack heights: 6 vs 0
		//IL_0f43->IL10b0: Incompatible stack heights: 9 vs 7
		object canvas = _Canvas;
		float time = default(float);
		object obj11 = default(object);
		float durationMillis;
		SoundManager.SoundConfig soundConfig5;
		if ((object)_Canvas != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (System.Object)+10]");
			Canvas.set_renderMode_Injected((IntPtr)0, RenderMode.WorldSpace);
			Camera main = Camera.main;
			if ((object)main != null)
			{
				ProCamera2D component = main.GetComponent<ProCamera2D>();
				if ((object)component != null)
				{
					component.RemoveAllCameraTargets();
					bool flag2 = _zoomIndex == 0;
					if (!flag2)
					{
						object obj = _zoomIndex - 1;
						bool num;
						bool num2;
						Vector2 anchoredPosition = default(Vector2);
						bool num3;
						bool num4;
						bool num5;
						bool num6;
						if (!flag2)
						{
							object obj2 = obj - 1;
							if (!flag2)
							{
								object obj3 = obj2 - 1;
								if (!flag2)
								{
									if ((nint)obj3 == 1)
									{
										if ((object)_Blackout == null)
										{
											goto IL_0f5e;
										}
										_Blackout.enabled = true;
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
										_ = 0;
										_ = 1073741824;
										soundConfig.Rate = 1f;
										soundConfig.Detune = -1300f;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
										soundConfig.Volume = (float?)(object)0;
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Clap, soundConfig, 0f, 10, time);
										SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
										_ = 0;
										_ = 1073741824;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
										soundConfig2.Volume = (float?)(object)0;
										soundConfig2.Rate = 1f;
										soundConfig2.Detune = -2100f;
										PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Clap, soundConfig2, 0f, 10, time);
										Sequence sequence = DOTween.Sequence();
										Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 7f);
										TweenCallback tweenCallback = delegate
										{
											//IL_004e: Expected F4, but got O
											PlayerOptionsData config = _playerOptions.Config;
											config._003CSelectedStage_003Ek__BackingField = StageType.FOREST;
											Color backgroundColor = default(Color);
											object obj37 = default(object);
											GL.GLClear_Injected(true, true, ref backgroundColor, (float)obj37);
											GM.Core.ResetGameToMenu();
										};
										if (sequence != null)
										{
											if (((Tween)sequence)._003Cactive_003Ek__BackingField)
											{
												if (((Tween)sequence).creationLocked)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
													if ((nint)0 == 0)
													{
														_ = 1;
													}
													Debugger.LogWarning("The Sequence has started and is now locked, you can only elements to a Sequence before it starts");
												}
												else if (tweenCallback != null)
												{
													Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
												}
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												Debugger.LogWarning("You can't add elements to an inactive/killed Sequence");
											}
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											Debugger.LogWarning("You can't add elements to a NULL Sequence");
										}
									}
									goto IL_0f43;
								}
								List<Vector3> panelPositions = _PanelPositions;
								if (_PanelPositions != null)
								{
									int zoomIndex = _zoomIndex;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v148 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
									bool flag3 = (nint)zoomIndex >= (nint)0;
									num = flag3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v148 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v148 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
									if ((nint)0 != 0)
									{
										int zoomIndex2 = _zoomIndex;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v149+18]");
										bool flag4 = (nint)zoomIndex2 >= (nint)0;
										num2 = flag4;
										object obj5 = _zoomIndex * 2;
										object obj6 = _zoomIndex + obj5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v149+28+v1549 @ rax_v163*4]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v149+20+v1549 @ rax_v163*4]");
										_ = 0;
										if ((object)_Panel != null)
										{
											_Panel.anchoredPosition = anchoredPosition;
											if ((object)_Panel != null)
											{
												Transform transform = _Panel.transform;
												List<Vector3> panelScales = _PanelScales;
												if (_PanelScales != null)
												{
													int zoomIndex3 = _zoomIndex;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v152 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
													bool flag5 = (nint)zoomIndex3 >= (nint)0;
													num3 = flag5;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v152 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
													object obj7 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v152 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
													if ((nint)0 != 0)
													{
														int zoomIndex4 = _zoomIndex;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v153+18]");
														bool flag6 = (nint)zoomIndex4 >= (nint)0;
														num4 = flag6;
														object obj8 = _zoomIndex * 2;
														object obj9 = _zoomIndex + obj8;
														bool flag7 = (object)transform == null;
														num5 = flag7;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v153+20+v959 @ rax_v168*4]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v153+28+v959 @ rax_v168*4]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1643 @ rax_v166 (UnityEngine.Transform)+10]");
														bool flag8 = (nint)0 == 0;
														num6 = flag8;
														object obj10 = obj11 - 48;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1643 @ rax_v166 (UnityEngine.Transform)+10]");
														Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj10);
														SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
														_ = 0;
														_ = 1073741824;
														soundConfig3.Rate = 1f;
														soundConfig3.Detune = -500f;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
														soundConfig3.Volume = (float?)(object)0;
														PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Clap, soundConfig3, 0f, 10, time);
														SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
														_ = 0;
														_ = 1073741824;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
														soundConfig4.Volume = (float?)(object)0;
														soundConfig4.Detune = -800f;
														soundConfig4.Rate = 0.9f;
														durationMillis = 0f;
														soundConfig5 = soundConfig4;
														goto IL_10b0;
													}
												}
											}
										}
									}
								}
							}
							else
							{
								List<Vector3> panelPositions2 = _PanelPositions;
								if (_PanelPositions != null)
								{
									int zoomIndex5 = _zoomIndex;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v130 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
									bool flag9 = (nint)zoomIndex5 >= (nint)0;
									num = flag9;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v130 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
									object obj12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v130 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
									if ((nint)0 != 0)
									{
										int zoomIndex6 = _zoomIndex;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v131+18]");
										bool flag10 = (nint)zoomIndex6 >= (nint)0;
										num2 = flag10;
										object obj13 = _zoomIndex * 2;
										object obj14 = _zoomIndex + obj13;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v131+28+v1461 @ rax_v144*4]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v131+20+v1461 @ rax_v144*4]");
										_ = 0;
										if ((object)_Panel != null)
										{
											_Panel.anchoredPosition = anchoredPosition;
											if ((object)_Panel != null)
											{
												Transform transform2 = _Panel.transform;
												List<Vector3> panelScales2 = _PanelScales;
												if (_PanelScales != null)
												{
													int zoomIndex7 = _zoomIndex;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v134 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
													bool flag11 = (nint)zoomIndex7 >= (nint)0;
													num3 = flag11;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v134 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
													object obj15 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v134 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
													if ((nint)0 != 0)
													{
														int zoomIndex8 = _zoomIndex;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v135+18]");
														bool flag12 = (nint)zoomIndex8 >= (nint)0;
														num4 = flag12;
														object obj16 = _zoomIndex * 2;
														object obj17 = _zoomIndex + obj16;
														bool flag13 = (object)transform2 == null;
														num5 = flag13;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v135+20+v1610 @ rax_v149*4]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v135+28+v1610 @ rax_v149*4]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1637 @ rax_v147 (UnityEngine.Transform)+10]");
														bool flag14 = (nint)0 == 0;
														num6 = flag14;
														object obj18 = obj11 - 48;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1637 @ rax_v147 (UnityEngine.Transform)+10]");
														Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj18);
														SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
														_ = 0;
														_ = 1073741824;
														soundConfig6.Rate = 1f;
														soundConfig6.Detune = -200f;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
														soundConfig6.Volume = (float?)(object)0;
														PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Clap, soundConfig6, 0f, 10, time);
														SoundManager.SoundConfig soundConfig7 = new SoundManager.SoundConfig();
														_ = 0;
														_ = 1073741824;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
														soundConfig7.Volume = (float?)(object)0;
														soundConfig7.Detune = -300f;
														soundConfig7.Rate = 0.9f;
														durationMillis = 0f;
														soundConfig5 = soundConfig7;
														goto IL_10b0;
													}
												}
											}
										}
									}
								}
							}
						}
						else
						{
							List<Vector3> panelPositions3 = _PanelPositions;
							if (_PanelPositions != null)
							{
								int zoomIndex9 = _zoomIndex;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v112 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								bool flag15 = (nint)zoomIndex9 >= (nint)0;
								num = flag15;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v112 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								object obj19 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v112 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
								if ((nint)0 != 0)
								{
									int zoomIndex10 = _zoomIndex;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v113+18]");
									bool flag16 = (nint)zoomIndex10 >= (nint)0;
									num2 = flag16;
									object obj20 = _zoomIndex * 2;
									object obj21 = _zoomIndex + obj20;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v113+28+v1344 @ rax_v125*4]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v113+20+v1344 @ rax_v125*4]");
									_ = 0;
									if ((object)_Panel != null)
									{
										_Panel.anchoredPosition = anchoredPosition;
										if ((object)_Panel != null)
										{
											Transform transform3 = _Panel.transform;
											List<Vector3> panelScales3 = _PanelScales;
											if (_PanelScales != null)
											{
												int zoomIndex11 = _zoomIndex;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v116 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
												bool flag17 = (nint)zoomIndex11 >= (nint)0;
												num3 = flag17;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v116 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
												object obj22 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v116 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
												if ((nint)0 != 0)
												{
													int zoomIndex12 = _zoomIndex;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v117+18]");
													bool flag18 = (nint)zoomIndex12 >= (nint)0;
													num4 = flag18;
													object obj23 = _zoomIndex * 2;
													object obj24 = _zoomIndex + obj23;
													bool flag19 = (object)transform3 == null;
													num5 = flag19;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v117+20+v1842 @ rax_v130*4]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v117+28+v1842 @ rax_v130*4]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1591 @ rax_v128 (UnityEngine.Transform)+10]");
													bool flag20 = (nint)0 == 0;
													num6 = flag20;
													object obj25 = obj11 - 48;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1591 @ rax_v128 (UnityEngine.Transform)+10]");
													Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj25);
													SoundManager.SoundConfig soundConfig8 = new SoundManager.SoundConfig();
													_ = 0;
													_ = 1073741824;
													soundConfig8.Rate = 1f;
													soundConfig8.Detune = -100f;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
													soundConfig8.Volume = (float?)(object)0;
													PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Clap, soundConfig8, 0f, 10, time);
													SoundManager.SoundConfig soundConfig9 = new SoundManager.SoundConfig();
													_ = 0;
													_ = 1073741824;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
													soundConfig9.Volume = (float?)(object)0;
													soundConfig9.Detune = -200f;
													soundConfig9.Rate = 0.9f;
													durationMillis = 0f;
													soundConfig5 = soundConfig9;
													goto IL_10b0;
												}
											}
										}
									}
								}
							}
						}
					}
					else
					{
						object core = GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdi_v30 (System.Object)+168]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdi_v30 (System.Object)+168]");
								int playerCount = ((MultiplayerManager)0).GetPlayerCount();
								if (playerCount <= 1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdi_v30 (System.Object)+168]");
									if (!((MultiplayerManager)0).IsOnlineMultiplayer)
									{
										goto IL_0d2f;
									}
								}
								MultiplayerCharacterBanner[] array = UnityEngine.Object.FindObjectsOfType<MultiplayerCharacterBanner>();
								bool flag21 = array == null;
								object obj26 = 0;
								object obj27 = 0;
								if (!flag21)
								{
									while ((nint)obj27 < array.Length)
									{
										bool flag22 = (nint)obj26 >= array.Length;
										object obj28 = array[obj26];
										if ((object)array[obj26] != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdi_v38 (System.Object)+10]");
											bool flag23 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdi_v38 (System.Object)+10]");
											IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
											GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
											if ((object)gameObject != null)
											{
												bool flag24 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
												GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
												obj26++;
												obj27 = obj26;
												continue;
											}
										}
										goto IL_0f5e;
									}
									goto IL_0d2f;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0f5e;
		IL_0f43:
		int zoomIndex13 = _zoomIndex + 1;
		_zoomIndex = zoomIndex13;
		return;
		IL_0f5e:
		throw new NullReferenceException();
		IL_10b0:
		PlaySoundResult playSoundResult6 = SoundManager.PlaySound(SfxType.Clap, soundConfig5, durationMillis, 10, time);
		goto IL_0f43;
		IL_0d2f:
		List<Vector3> panelPositions4 = _PanelPositions;
		object panel = _Panel;
		if (_PanelPositions != null)
		{
			int zoomIndex14 = _zoomIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v68 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			bool flag25 = (nint)zoomIndex14 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v68 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v68 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			if ((nint)0 != 0)
			{
				int zoomIndex15 = _zoomIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v69+18]");
				bool flag26 = (nint)zoomIndex15 >= (nint)0;
				object obj30 = _zoomIndex * 2;
				object obj31 = _zoomIndex + obj30;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v69+28+v1644 @ rax_v75*4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v69+20+v1644 @ rax_v75*4]");
				_ = 0;
				if ((object)_Panel != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v33 (System.Object)+10]");
					bool flag27 = (nint)0 == 0;
					object obj32 = obj11 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v33 (System.Object)+10]");
					RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref *(Vector2*)obj32);
					object panel2 = _Panel;
					if ((object)_Panel != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v34 (System.Object)+10]");
						bool flag28 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdi_v34 (System.Object)+10]");
						IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
						Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						List<Vector3> panelScales4 = _PanelScales;
						if (_PanelScales != null)
						{
							int zoomIndex16 = _zoomIndex;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v77 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							bool flag29 = (nint)zoomIndex16 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v77 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
							object obj33 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v77 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
							if ((nint)0 != 0)
							{
								int zoomIndex17 = _zoomIndex;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v78+18]");
								bool flag30 = (nint)zoomIndex17 >= (nint)0;
								object obj34 = _zoomIndex * 2;
								object obj35 = _zoomIndex + obj34;
								bool flag31 = (object)transform4 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v78+20+v2645 @ rax_v87*4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v78+28+v2645 @ rax_v87*4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2450 @ rax_v85 (UnityEngine.Transform)+10]");
								bool flag32 = (nint)0 == 0;
								object obj36 = obj11 - 48;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2450 @ rax_v85 (UnityEngine.Transform)+10]");
								Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj36);
								SoundManager.SoundConfig soundConfig10 = new SoundManager.SoundConfig();
								_ = 0;
								_ = 1073741824;
								_ = 1;
								soundConfig10.Rate = 1f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
								soundConfig10.Volume = (float?)(object)0;
								durationMillis = 0f;
								soundConfig5 = soundConfig10;
								goto IL_10b0;
							}
						}
					}
				}
			}
		}
		goto IL_0f5e;
	}

	private unsafe Vector3 GetCameraPosition(float delta)
	{
		//IL_0018: Invalid comparison between I4 and F4
		//IL_006b: Expected F4, but got I4
		//IL_00b6: Expected native int or pointer, but got O
		//IL_00c3: Expected native int or pointer, but got O
		Vector3 worldPositionFromUIElement = UIPositionHelper.GetWorldPositionFromUIElement(_ZoomTarget);
		float num;
		if (!(0f > delta))
		{
			bool flag = !(delta > 1f);
			num = delta;
			if (!flag)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = -10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Objects.YellowSignManager)+A4]");
		float num3 = num2 - 0f;
		float num4 = num3 * num;
		float num5 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Objects.YellowSignManager)+A4]");
		float z = num5 + 0f;
		Vector3 vector = default(Vector3);
		float x = default(float);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = z;
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		return vector;
	}

	private void UnlockWeapons()
	{
		//IL_00c3: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_01f0: Expected O, but got I
		//IL_024a: Expected O, but got I
		//IL_031d: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_044a: Expected O, but got I
		//IL_04a4: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<WeaponType> list = config._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_0132;
			}
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config2._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r9_v18+18]");
		if (num >= 0)
		{
			list2.AddWithResize((System.Int32Enum)68);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 68;
		}
		goto IL_0132;
		IL_025f:
		PlayerOptionsData config3 = _playerOptions.Config;
		List<WeaponType> list3 = config3._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				goto IL_038c;
			}
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)config4._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r9_v12+18]");
		if (num2 >= 0)
		{
			list4.AddWithResize((System.Int32Enum)71);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 71;
		}
		goto IL_038c;
		IL_0132:
		PlayerOptionsData config5 = _playerOptions.Config;
		List<WeaponType> list5 = config5._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj7 = default(object);
			if ((nint)obj7 != -1)
			{
				goto IL_025f;
			}
		}
		PlayerOptionsData config6 = _playerOptions.Config;
		List<System.Int32Enum> list6 = (List<System.Int32Enum>)(object)config6._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v15+18]");
		if (num3 >= 0)
		{
			list6.AddWithResize((System.Int32Enum)67);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 67;
		}
		goto IL_025f;
		IL_04b9:
		List<AchievementData> list7 = _achievementManager.CheckAllAchievements();
		List<SecretType> list8 = _achievementManager.CheckAllSecrets();
		GameManager core = GM.Core;
		if (core._003CStartedAsOnlineMultiplayerRun_003Ek__BackingField)
		{
			_playerOptions.ApplyClientConfigWithRunProgress();
			_achievementManager.UnlockAchievementsAndGiveRewards();
			_playerOptions.DestroyOnlineConfigs();
		}
		_playerOptions.Save(commitImmediately: true, createBackup: true);
		return;
		IL_038c:
		PlayerOptionsData config7 = _playerOptions.Config;
		List<WeaponType> list9 = config7._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj10 = default(object);
			if ((nint)obj10 != -1)
			{
				goto IL_04b9;
			}
		}
		PlayerOptionsData config8 = _playerOptions.Config;
		List<System.Int32Enum> list10 = (List<System.Int32Enum>)(object)config8._003CUnlockedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v9+18]");
		if (num4 >= 0)
		{
			list10.AddWithResize((System.Int32Enum)72);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 72;
		}
		goto IL_04b9;
	}

	public YellowSignManager()
	{
		List<Vector3> panelPositions = new List<Vector3>();
		_PanelPositions = panelPositions;
		List<Vector3> panelScales = new List<Vector3>();
		_PanelScales = panelScales;
		_orthoCameraZoomTarget = 0.22f;
		base._onResumeSent = true;
	}

	private void _003CClap_003Eb__21_0()
	{
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("clap", 1, 6, "backgroundX", zeroPad);
		UISpriteAnimation inAnimation = _InAnimation;
		inAnimation.sprites = animationFrames;
		_Clapper.SetActive(value: true);
		_InAnimation.Play();
		UISpriteAnimation inAnimation2 = _InAnimation;
		Action onComplete = PlayClapSound;
		inAnimation2._onComplete = onComplete;
	}

	private void _003CZoom_003Eb__23_0()
	{
		//IL_004e: Expected F4, but got O
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.FOREST;
		Color backgroundColor = default(Color);
		object obj = default(object);
		GL.GLClear_Injected(true, true, ref backgroundColor, (float)obj);
		GM.Core.ResetGameToMenu();
	}
}
