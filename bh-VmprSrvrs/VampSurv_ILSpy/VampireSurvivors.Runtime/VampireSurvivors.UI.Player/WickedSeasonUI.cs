using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI.Player;

public class WickedSeasonUI : GameMonoBehaviour
{
	private SpriteRenderer _SeasonFan;

	private SpriteRenderer _SeasonSprite;

	private Transform _SeasonSpriteParent;

	private SignalBus _signalBus;

	private Tween _seasonTween;

	private float _tweenValue;

	private static readonly int FillAmount;

	private void Construct(SignalBus signalBus)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00f9: Expected O, but got I
		_signalBus = signalBus;
		Action<GameplaySignals.OpenSeasonFanSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1F90");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OpenSeasonFanSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OpenSeasonFanSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v13 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
	}

	private void Awake()
	{
		GameObject gameObject = _SeasonFan.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _SeasonSprite.gameObject;
		gameObject2.SetActive(value: false);
	}

	protected override void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<GameplaySignals.OpenSeasonFanSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1F90");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	private unsafe void OpenSeasonFan(GameplaySignals.OpenSeasonFanSignal signal)
	{
		//IL_01f9->IL0340: Incompatible stack heights: 1 vs 0
		//IL_0228->IL0340: Incompatible stack heights: 1 vs 0
		//IL_0257->IL0340: Incompatible stack heights: 1 vs 0
		//IL_03b3->IL0340: Incompatible stack heights: 1 vs 0
		if ((object)_SeasonFan != null)
		{
			GameObject gameObject = _SeasonFan.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				if ((object)_SeasonSprite != null)
				{
					GameObject gameObject2 = _SeasonSprite.gameObject;
					if ((object)gameObject2 != null)
					{
						gameObject2.SetActive(value: true);
						Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UnityCircle");
						if ((object)_SeasonFan != null)
						{
							_SeasonFan.sprite = unpackedSprite;
							Sprite sprite = SpriteManager.GetSprite(signal.FrameName, "items");
							if ((object)_SeasonSprite != null)
							{
								_SeasonSprite.sprite = sprite;
								SpriteRenderer seasonFan = _SeasonFan;
								Color color = ColourHelper.HexToColor(signal.Color);
								bool flag = ((UnityEngine.Object)seasonFan).m_CachedPtr == (IntPtr)0;
								float value = default(float);
								SpriteRenderer.set_color_Injected(((UnityEngine.Object)seasonFan).m_CachedPtr, ref *(Color*)(&value));
								SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_SeasonFan, 0.8f);
								_tweenValue = 0.5f;
								if (_seasonTween != null)
								{
									TweenExtensions.Kill(_seasonTween);
								}
								DOGetter<float> getter = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
								DOSetter<float> dOSetter = null;
								((WickedSeasonUI)(object)dOSetter)._003COpenSeasonFan_003Eb__10_1(0.8f);
								GameManager core = GM.Core;
								if ((object)GM.Core != null)
								{
									ArcanaManager arcanaManager = core._arcanaManager;
									if (core._arcanaManager != null)
									{
										WickedSeason wickedSeason = arcanaManager._wickedSeason;
										if (arcanaManager._wickedSeason != null)
										{
											float duration = wickedSeason._seasonDuration * 0.001f;
											TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, duration);
											TweenCallback tweenCallback = delegate
											{
												if ((object)_SeasonFan != null)
												{
													Material material = ((Renderer)_SeasonFan).GetMaterial();
													if ((object)material != null)
													{
														material.SetFloatImpl(FillAmount, _tweenValue);
														Material seasonSpriteParent = (Material)(object)_SeasonSpriteParent;
														bool flag2 = ((UnityEngine.Object)seasonSpriteParent).m_CachedPtr == (IntPtr)0;
														Vector3 value2 = default(Vector3);
														Transform.set_localScale_Injected(((UnityEngine.Object)seasonSpriteParent).m_CachedPtr, ref value2);
														return;
													}
												}
												throw new NullReferenceException();
											};
											if (tweenerCore != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
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
												_seasonTween = tweenerCore;
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

	public WickedSeasonUI()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static WickedSeasonUI()
	{
		int fillAmount = Shader.PropertyToID("_FillAmount");
		FillAmount = fillAmount;
	}

	private float _003COpenSeasonFan_003Eb__10_0()
	{
		return _tweenValue;
	}

	private void _003COpenSeasonFan_003Eb__10_1(float x)
	{
		_tweenValue = x;
	}

	private void _003COpenSeasonFan_003Eb__10_2()
	{
		if ((object)_SeasonFan != null)
		{
			Material material = ((Renderer)_SeasonFan).GetMaterial();
			if ((object)material != null)
			{
				material.SetFloatImpl(FillAmount, _tweenValue);
				Material seasonSpriteParent = (Material)(object)_SeasonSpriteParent;
				bool flag = ((UnityEngine.Object)seasonSpriteParent).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)seasonSpriteParent).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}
}
