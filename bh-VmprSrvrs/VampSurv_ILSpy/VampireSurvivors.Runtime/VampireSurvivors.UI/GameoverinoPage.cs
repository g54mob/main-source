using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class GameoverinoPage : BaseUIPage
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public float startSize;

		public GameoverinoPage _003C_003E4__this;

		internal float _003COnShowStart_003Eb__0()
		{
			return startSize;
		}

		internal void _003COnShowStart_003Eb__1(float x)
		{
			startSize = x;
		}

		internal void _003COnShowStart_003Eb__2()
		{
			GameoverinoPage gameoverinoPage = _003C_003E4__this;
			gameoverinoPage._BackgroundPixelMat.SetFloatImpl(CellSizeX, startSize);
			GameoverinoPage gameoverinoPage2 = _003C_003E4__this;
			gameoverinoPage2._BackgroundPixelMat.SetFloatImpl(CellSizeY, startSize);
			GameoverinoPage gameoverinoPage3 = _003C_003E4__this;
			gameoverinoPage3._TitlePixelMat.SetFloatImpl(CellSizeX, startSize);
			GameoverinoPage gameoverinoPage4 = _003C_003E4__this;
			gameoverinoPage4._TitlePixelMat.SetFloatImpl(CellSizeY, startSize);
		}

		internal void _003COnShowStart_003Eb__3()
		{
			_003C_003E4__this.PlayAutoRevive();
		}
	}

	private PixelationTool _Pixeler;

	private Button _ReviveButton;

	private UISpriteAnimation _ReviveAnimation;

	private Material _GameOverPixelise;

	private Image _WhiteFlash;

	private Image _Background;

	private Image _Title;

	private Image _LeftHand;

	private Image _RightHand;

	private Material _BackgroundPixelMat;

	private Material _TitlePixelMat;

	private PlayerOptions _playerOptions;

	private static readonly int CellSizeX;

	private static readonly int CellSizeY;

	private void Construct(PlayerOptions player)
	{
		_playerOptions = player;
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0012: Expected O, but got I8
		//IL_04d1: Expected O, but got I4
		//IL_01c6: Expected O, but got Ref
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_0513: Expected O, but got I4
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass15_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals16._003C_003E4__this = this;
		Camera main = Camera.main;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			CameraExtensions.ResetOrthographicAndRenderTextureSize(main);
		}
		base.OnShowStart(g);
		GameObject gameObject = _LeftHand.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _RightHand.gameObject;
		gameObject2.SetActive(value: false);
		Material material = _Background.material;
		_BackgroundPixelMat = material;
		Material material2 = _Title.material;
		_TitlePixelMat = material2;
		PlayerOptionsData config = _playerOptions.Config;
		bool flag = config._003CClassicMusic_003Ek__BackingField;
		SfxType sfxType = SfxType.BGM_GameOver;
		if (!flag)
		{
			sfxType = SfxType.BGM_GameOverB;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 0f, 10, time);
		Color color = _Background.color;
		Color color2 = _Background.color;
		Color color3 = _Background.color;
		object obj2 = default(object);
		_Background.color = (Color)(&obj2);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Background, 0.4f, 0.8f);
		GameObject gameObject3 = _Title.gameObject;
		gameObject3.SetActive(value: true);
		CS_0024_003C_003E8__locals16.startSize = 50f;
		_BackgroundPixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals16.startSize);
		_BackgroundPixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals16.startSize);
		_TitlePixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals16.startSize);
		_TitlePixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals16.startSize);
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass15_0)(object)dOSetter)._003COnShowStart_003Eb__1(0.4f);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 2f, 1f);
		TweenCallback tweenCallback = delegate
		{
			GameoverinoPage gameoverinoPage = CS_0024_003C_003E8__locals16._003C_003E4__this;
			gameoverinoPage._BackgroundPixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals16.startSize);
			GameoverinoPage gameoverinoPage2 = CS_0024_003C_003E8__locals16._003C_003E4__this;
			gameoverinoPage2._BackgroundPixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals16.startSize);
			GameoverinoPage gameoverinoPage3 = CS_0024_003C_003E8__locals16._003C_003E4__this;
			gameoverinoPage3._TitlePixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals16.startSize);
			GameoverinoPage gameoverinoPage4 = CS_0024_003C_003E8__locals16._003C_003E4__this;
			gameoverinoPage4._TitlePixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals16.startSize);
		};
		TweenCallback tweenCallback3;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag2 = (nint)0 == 0;
					_ = 0;
					if (!flag2)
					{
						object obj3 = tweenerCore2 + 184;
						object obj4 = obj3 >> 12;
						object obj5 = obj4 & 0x1FFFFF;
						object obj6 = obj5 >> 6;
						object obj7 = obj5 & 0x3F;
						nint num2;
						do
						{
							object obj8 = 1 << (int)obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v2+462E0+v1164 @ rdx_v45*8]");
							object obj9 = 0 | obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v2+462E0+v1164 @ rdx_v45*8]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v2+462E0+v1164 @ rdx_v45*8]");
							if (num == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v2+462E0+v1164 @ rdx_v45*8]");
							num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r14_v2+462E0+v1164 @ rdx_v45*8]");
						}
						while (num2 != 0);
						TweenCallback tweenCallback2 = delegate
						{
							CS_0024_003C_003E8__locals16._003C_003E4__this.PlayAutoRevive();
						};
						tweenCallback3 = tweenCallback2;
						goto IL_044c;
					}
				}
			}
		}
		TweenCallback tweenCallback4 = delegate
		{
			CS_0024_003C_003E8__locals16._003C_003E4__this.PlayAutoRevive();
		};
		bool flag3 = tweenerCore2 == null;
		tweenCallback3 = tweenCallback4;
		if (!flag3)
		{
			goto IL_044c;
		}
		return;
		IL_044c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rax_v51 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
	}

	private void OnIntroEnded()
	{
		PlayAutoRevive();
	}

	private unsafe void PlayAutoRevive()
	{
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(_WhiteFlash, 1f, 0.1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.425f);
		TweenCallback tweenCallback = delegate
		{
			GM.Core.EraseEnemies();
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_WhiteFlash, 0f, 0.1f);
			TweenCallback tweenCallback2 = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E900");
			};
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		};
		tweenCallback._002Ector(this, (nint)__ldftn(GameoverinoPage._003CPlayAutoRevive_003Eb__17_0));
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Background, 0f, 0.625f);
		GameObject gameObject = _LeftHand.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = _RightHand.gameObject;
		gameObject2.SetActive(value: true);
		UISpriteAnimation component = _RightHand.GetComponent<UISpriteAnimation>();
		component.Play(hideWhenDone: true);
		UISpriteAnimation component2 = _LeftHand.GetComponent<UISpriteAnimation>();
		component2.Play(hideWhenDone: true);
	}

	static GameoverinoPage()
	{
		int cellSizeX = Shader.PropertyToID("_CellSizeX");
		CellSizeX = cellSizeX;
		int cellSizeY = Shader.PropertyToID("_CellSizeY");
		CellSizeY = cellSizeY;
	}

	private void _003CPlayAutoRevive_003Eb__17_0()
	{
		GM.Core.EraseEnemies();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_WhiteFlash, 0f, 0.1f);
		TweenCallback tweenCallback = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E900");
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void _003CPlayAutoRevive_003Eb__17_1()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E900");
	}
}
