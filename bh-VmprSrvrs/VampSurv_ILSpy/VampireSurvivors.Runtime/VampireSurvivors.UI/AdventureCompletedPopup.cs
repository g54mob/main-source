using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class AdventureCompletedPopup : BasePopup
{
	private sealed class _003CWaitAndShow_003Ed__38(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AdventureCompletedPopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00c2: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.DoShow();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private CanvasGroup _BackgroundFader;

	private GameObject _Ray;

	private RectTransform _RayContainer;

	private RectTransform _IconContainer;

	private List<ParticleSystem> _particles;

	private RectTransform _TitleGroup;

	private TextMeshProUGUI _MainTitle;

	private TextMeshProUGUI _TitleFade1;

	private TextMeshProUGUI _TitleFade2;

	private CanvasGroup _IconCG;

	private Image _DarkOverlay;

	private CanvasGroup _Panel;

	private TextMeshProUGUI _AdventureNameText;

	private TextMeshProUGUI _RewardsText;

	private RectTransform _RewardsPanel;

	private CanvasGroup _RewardContent;

	private CanvasGroup _CoinRewardGroup;

	private CanvasGroup _StarRewardGroup;

	private CanvasGroup _SkinRewardGroup;

	private TextMeshProUGUI _CoinRewardText;

	private TextMeshProUGUI _StarRewardText;

	private Button _DoneButton;

	private ParticleEmitterManager _ParticleEmitter;

	private Image _SubtitleImage;

	private RectTransform _SkinCarousel;

	private MainMenuBackgroundFactory _mainMenuFactory;

	private AdventureManager _adventureManager;

	private ParticleSystem _colorParticles;

	private List<GameObject> _rays;

	private List<Tween> _tweens;

	private GameObject _spawnedBackground;

	private AdventureType _currentAdventure;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private List<SkinToUnlock> _skinsToUnlock;

	private void Construct(MainMenuBackgroundFactory menu, AdventureManager adventure, DataManager dataManager, PlayerOptions playerOptions)
	{
		_mainMenuFactory = menu;
		_adventureManager = adventure;
		_dataManager = dataManager;
		PlayerOptions playerOptions2 = default(PlayerOptions);
		_playerOptions = playerOptions2;
	}

	private unsafe void DoShow()
	{
		//IL_014a: Expected I, but got O
		//IL_01b3: Expected I, but got O
		//IL_021c: Expected I, but got O
		//IL_0411: Expected O, but got I4
		//IL_0440: Expected F4, but got I4
		//IL_0f5a->IL0d48: Incompatible stack heights: 1 vs 0
		//IL_0cc4->IL0f5f: Incompatible stack heights: 1 vs 0
		//IL_0d00->IL0d48: Incompatible stack heights: 1 vs 0
		//IL_0d1f->IL0d48: Incompatible stack heights: 1 vs 0
		//IL_0d3d->IL0f5f: Incompatible stack heights: 1 vs 0
		EventSystem current = EventSystem.current;
		bool flag = default(bool);
		Sprite sprite;
		if ((object)current != null)
		{
			_previouslySelected = current.m_CurrentSelected;
			string text = (((object)_previouslySelected == null) ? null : _previouslySelected.ToString());
			string message = "Previously selected : " + text;
			Debug.Log(message);
			AdventureType currentAdventure;
			if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
			{
				AdventureManager adventureManager = _adventureManager;
				if (_adventureManager == null)
				{
					goto IL_0d48;
				}
				currentAdventure = adventureManager.CurrentAdventure;
			}
			else
			{
				currentAdventure = AdventureType.ADV_LMS_001;
			}
			_currentAdventure = currentAdventure;
			string mainTitle = (string)(object)_MainTitle;
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("adventureLang/adv_adventureSelect_complete", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if ((object)_MainTitle != null)
			{
				nint num = (nint)mainTitle;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v120 @ r9_v5 (Il2CppClass<System.String>)+558] (should have been resolved before IL gen)");
				string titleFade = (string)(object)_TitleFade1;
				if ((object)_MainTitle != null)
				{
					string text2 = _MainTitle.text;
					if ((object)_TitleFade1 != null)
					{
						nint num2 = (nint)titleFade;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v121 @ r9_v6 (Il2CppClass<System.String>)+558] (should have been resolved before IL gen)");
						string titleFade2 = (string)(object)_TitleFade2;
						if ((object)_MainTitle != null)
						{
							string text3 = _MainTitle.text;
							if ((object)_TitleFade2 != null)
							{
								nint num3 = (nint)titleFade2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v122 @ r9_v7 (Il2CppClass<System.String>)+558] (should have been resolved before IL gen)");
								if (_adventureManager != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
									object obj = default(object);
									if (obj != null)
									{
										AdventureManager adventureManager2 = _adventureManager;
										if (_adventureManager != null)
										{
											if (adventureManager2._003CAdventureData_003Ek__BackingField == null)
											{
												goto IL_0d3d;
											}
											AdventureData adventureData = adventureManager2._003CAdventureData_003Ek__BackingField;
											CoreAdventureData coreAdventureData = adventureData._003CCoreAdventureData_003Ek__BackingField;
											if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
											{
												sprite = SpriteManager.GetSprite(coreAdventureData._003CSubtitleImage_003Ek__BackingField);
												Behaviour subtitleImage;
												if ((object)sprite != null)
												{
													bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
													subtitleImage = _SubtitleImage;
													if (!flag2)
													{
														if ((object)_SubtitleImage != null)
														{
															_SubtitleImage.sprite = sprite;
															goto IL_03a9;
														}
														goto IL_0d48;
													}
												}
												else
												{
													subtitleImage = _SubtitleImage;
												}
												if ((object)subtitleImage != null)
												{
													subtitleImage.enabled = false;
													goto IL_03a9;
												}
											}
										}
										goto IL_0d48;
									}
								}
								goto IL_0d3d;
							}
						}
					}
				}
			}
		}
		goto IL_0d48;
		IL_0f70:
		object message2;
		Debugger.LogWarning(message2);
		goto IL_06c2;
		IL_03a9:
		if ((object)_SubtitleImage == null)
		{
			goto IL_0d48;
		}
		_SubtitleImage.sprite = sprite;
		PlayParticles(b: false);
		Sequence sequence = DOTween.Sequence();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.WinnerSFX, soundConfig, 0f, 10, flag ? 1 : 0);
		TweenCallback tweenCallback = delegate
		{
			_DoneButton.Select();
		};
		if (sequence != null)
		{
			object message3;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence2 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					goto IL_055f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "You can't add elements to an inactive/killed Sequence";
			}
			Debugger.LogWarning(message3);
			goto IL_055f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Debugger.LogWarning("You can't add elements to a NULL Sequence");
		TweenCallback tweenCallback2 = delegate
		{
			Transform target = _Panel.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.125f);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Panel, 1f, 0.125f);
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		message2 = "You can't add elements to a NULL Sequence";
		goto IL_0f70;
		IL_06c2:
		Sequence sequence3 = TweenSettingsExtensions.AppendInterval(sequence, 0.125f);
		TweenCallback tweenCallback3 = delegate
		{
			CanvasGroup component = _TitleGroup.GetComponent<CanvasGroup>();
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 1f, 0.125f);
		};
		object message4;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback3 != null)
					{
						Sequence sequence4 = Sequence.DoInsertCallback(sequence, tweenCallback3, ((Tween)sequence).duration);
					}
					goto IL_0821;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message4 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message4);
		goto IL_0821;
		IL_055f:
		TweenCallback tweenCallback4 = delegate
		{
			Transform target = _Panel.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.125f);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Panel, 1f, 0.125f);
		};
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback4 != null)
				{
					Sequence sequence5 = Sequence.DoInsertCallback(sequence, tweenCallback4, ((Tween)sequence).duration);
				}
				goto IL_06c2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_0f70;
		IL_0eeb:
		if ((object)_mainMenuFactory != null)
		{
			GameObject backgroundForAdventureType = _mainMenuFactory.GetBackgroundForAdventureType(_currentAdventure);
			GameObject spawnedBackground = UnityEngine.Object.Instantiate(backgroundForAdventureType, _IconContainer);
			_spawnedBackground = spawnedBackground;
			if ((object)_spawnedBackground != null)
			{
				Transform transform = _spawnedBackground.transform;
				if ((object)transform != null)
				{
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.SetAsFirstSibling_Injected(((UnityEngine.Object)transform).m_CachedPtr);
					AdventureManager adventureManager3 = _adventureManager;
					if (_adventureManager != null)
					{
						if (adventureManager3._003CAdventureData_003Ek__BackingField == null)
						{
							return;
						}
						AdventureData adventureData2 = adventureManager3._003CAdventureData_003Ek__BackingField;
						CoreAdventureData coreAdventureData2 = adventureData2._003CCoreAdventureData_003Ek__BackingField;
						if (adventureData2._003CCoreAdventureData_003Ek__BackingField != null && (object)_AdventureNameText != null)
						{
							_AdventureNameText.text = coreAdventureData2._003CAdventureName_003Ek__BackingField;
							return;
						}
					}
				}
			}
		}
		goto IL_0d48;
		IL_0d3d:
		Hide();
		return;
		IL_094d:
		TweenCallback tweenCallback5 = delegate
		{
			//IL_00fc: Expected O, but got Ref
			AdventureManager adventureManager4 = _adventureManager;
			AdventureData adventureData3 = adventureManager4._003CAdventureData_003Ek__BackingField;
			CoreAdventureData coreAdventureData3 = adventureData3._003CCoreAdventureData_003Ek__BackingField;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CAdventureCompletionCount_003Ek__BackingField > 0)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm1\"");
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot2 = default(GameObject);
			string overrideLanguage2 = default(string);
			bool allowLocalizedParameters2 = default(bool);
			string translation2 = LocalizationManager.GetTranslation("adventureLang/adv_adventureSelect_completePopup", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot2, overrideLanguage2, allowLocalizedParameters2);
			if ("N0" != null)
			{
			}
			object obj2 = default(object);
			string newValue = System.Number.FormatInt32(coreAdventureData3._003CCompletionCoinReward_003Ek__BackingField, (ReadOnlySpan<char>)(&obj2), LocalizationManager.mCurrentCulture);
			string text4 = translation2.Replace("%0", newValue);
			_CoinRewardText.text = text4;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_RewardContent, 1f, 0.3f);
			SetSkins();
		};
		object message5;
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback5 != null)
				{
					Sequence sequence6 = Sequence.DoInsertCallback(sequence, tweenCallback5, ((Tween)sequence).duration);
				}
				goto IL_0ab0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message5 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message5 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_0f9d;
		IL_0ab0:
		Sequence sequence7 = TweenSettingsExtensions.AppendInterval(sequence, 1f);
		TweenCallback tweenCallback6 = delegate
		{
			//IL_0092: Expected O, but got Ref
			//IL_00ad: Expected O, but got Ref
			Transform target = _DoneButton.transform;
			Vector3 vector = default(Vector3);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&vector), 0.125f, RotateMode.FastBeyond360);
			Transform target2 = _DoneButton.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, (Vector3)(&vector), 0.125f);
			TweenCallback tweenCallback9 = delegate
			{
				_DoneButton.interactable = true;
			};
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		};
		object message6;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback6 != null)
					{
						Sequence sequence8 = Sequence.DoInsertCallback(sequence, tweenCallback6, ((Tween)sequence).duration);
					}
					goto IL_0eeb;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message6 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message6 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message6 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message6);
		goto IL_0eeb;
		IL_0821:
		Sequence sequence9 = TweenSettingsExtensions.AppendInterval(sequence, 0.125f);
		TweenCallback tweenCallback7 = delegate
		{
			//IL_0175: Expected O, but got Ref
			RectTransform rectTransform = _TitleFade1.rectTransform;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPosX(rectTransform, -1225f, 0.2f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 18;
					_ = 0;
				}
			}
			RectTransform rectTransform2 = _TitleFade2.rectTransform;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPosX(rectTransform2, 1225f, 0.2f);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 18;
					_ = 0;
				}
			}
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_TitleFade1, 0f, 0.2f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(_TitleFade2, 0f, 0.2f);
			AddRays();
			MakeColorParticles();
			Image component = _Panel.GetComponent<Image>();
			object obj2 = default(object);
			TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleUI.DOColor(component, (Color)(&obj2), 0.2f);
			TweenerCore<float, float, FloatOptions> tweenerCore6 = DOTweenModuleUI.DOFade(_IconCG, 1f, 0.2f);
			Vector2 sizeDelta = _RewardsPanel.sizeDelta;
			Vector2 endValue = default(Vector2);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore7 = DOTweenModuleUI.DOSizeDelta(_RewardsPanel, endValue, 0.3f);
			if (tweenerCore7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 27;
					_ = 0;
				}
			}
		};
		if (sequence != null)
		{
			object message7;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback7 != null)
					{
						Sequence sequence10 = Sequence.DoInsertCallback(sequence, tweenCallback7, ((Tween)sequence).duration);
					}
					goto IL_094d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message7 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message7 = "You can't add elements to an inactive/killed Sequence";
			}
			Debugger.LogWarning(message7);
			goto IL_094d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Debugger.LogWarning("You can't add elements to a NULL Sequence");
		TweenCallback tweenCallback8 = delegate
		{
			//IL_00fc: Expected O, but got Ref
			AdventureManager adventureManager4 = _adventureManager;
			AdventureData adventureData3 = adventureManager4._003CAdventureData_003Ek__BackingField;
			CoreAdventureData coreAdventureData3 = adventureData3._003CCoreAdventureData_003Ek__BackingField;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CAdventureCompletionCount_003Ek__BackingField > 0)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm1\"");
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot2 = default(GameObject);
			string overrideLanguage2 = default(string);
			bool allowLocalizedParameters2 = default(bool);
			string translation2 = LocalizationManager.GetTranslation("adventureLang/adv_adventureSelect_completePopup", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot2, overrideLanguage2, allowLocalizedParameters2);
			if ("N0" != null)
			{
			}
			object obj2 = default(object);
			string newValue = System.Number.FormatInt32(coreAdventureData3._003CCompletionCoinReward_003Ek__BackingField, (ReadOnlySpan<char>)(&obj2), LocalizationManager.mCurrentCulture);
			string text4 = translation2.Replace("%0", newValue);
			_CoinRewardText.text = text4;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_RewardContent, 1f, 0.3f);
			SetSkins();
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		message5 = "You can't add elements to a NULL Sequence";
		goto IL_0f9d;
		IL_0f9d:
		Debugger.LogWarning(message5);
		goto IL_0ab0;
		IL_0d48:
		throw new NullReferenceException();
	}

	private unsafe void MakeColorParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f4: Expected O, but got Ref
		//IL_0409: Expected native int or pointer, but got O
		//IL_0423: Expected O, but got I
		//IL_046e: Expected O, but got Ref
		//IL_0487: Expected native int or pointer, but got O
		//IL_04a6: Expected O, but got I
		//IL_04d4: Expected O, but got I4
		//IL_04ed: Expected O, but got Ref
		//IL_0507: Expected native int or pointer, but got O
		//IL_07bf: Expected O, but got I4
		//IL_0539: Expected O, but got Ref
		//IL_0553: Expected native int or pointer, but got O
		//IL_07f9: Expected O, but got I
		//IL_058b: Expected O, but got Ref
		//IL_05b2: Expected O, but got I
		//IL_05d9: Expected O, but got I
		//IL_05f3: Expected native int or pointer, but got O
		//IL_060d: Expected O, but got I
		//IL_0646: Expected O, but got I
		//IL_0847: Expected O, but got I
		//IL_089a: Expected O, but got I
		//IL_0979: Expected O, but got Ref
		//IL_0991: Expected O, but got Ref
		//IL_09ab: Expected native int or pointer, but got O
		//IL_09be: Expected O, but got Ref
		//IL_09cb: Expected O, but got Ref
		//IL_09db: Expected O, but got I
		//IL_08e4: Expected O, but got Ref
		//IL_0941: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"PfxYellow.png");
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
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxRed.png");
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
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxPink.png");
						}
						else
						{
							int size3 = list._size + 1;
							list._size = size3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxColor1.png");
							}
							else
							{
								int size4 = list._size + 1;
								list._size = size4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version5 = list._version + 1;
							list._version = version5;
							string[] items5 = list._items;
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"PfxColor2.png");
								}
								else
								{
									int size5 = list._size + 1;
									list._size = size5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
									particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
									_ = 0;
									Camera main = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBounds(main);
									object obj3 = default(object);
									float max = (float)obj3 * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(1000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(-195f, -390f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
									_ = 0;
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2.6f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
									_ = 0;
									_ = 24;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 0;
									_ = 16777215;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
									particleSystemConfig._tint = (uint?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
									particleSystemConfig._blendMode = (BlendMode?)(object)0;
									particleSystemConfig._on = true;
									if ((object)_ParticleEmitter != null)
									{
										Transform transform = _ParticleEmitter.transform;
										Transform parent = default(Transform);
										string psName = default(string);
										bool isAdditive = default(bool);
										bool requiresMasking = default(bool);
										ParticleSystem colorParticles = _ParticleEmitter.CreateUIEmitter(particleSystemConfig, "UI", 11001, parent, psName, isAdditive, requiresMasking);
										_colorParticles = colorParticles;
										if ((object)_colorParticles != null)
										{
											_ = _colorParticles;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												if (obj4 == null)
												{
													MissingMethodException ex = new MissingMethodException();
													throw ex;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1635 @ rax_v59 (should have been resolved before IL gen)");
											if ((object)_colorParticles != null)
											{
												_colorParticles.Play(withChildren: true);
												_ = _colorParticles;
												_ = _colorParticles;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													if (obj5 == null)
													{
														MissingMethodException ex2 = new MissingMethodException();
														throw ex2;
													}
												}
												object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1725 @ rax_v65 (should have been resolved before IL gen)");
												ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
												ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
												((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve3);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													if (obj7 == null)
													{
														MissingMethodException ex3 = new MissingMethodException();
														throw ex3;
													}
												}
												object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1756 @ rax_v70 (should have been resolved before IL gen)");
												Transform transform2 = _colorParticles.transform;
												bool flag = ((List<string>)(object)transform2)._items == null;
												Vector3 value = default(Vector3);
												Transform.set_localPosition_Injected((IntPtr)((List<string>)(object)transform2)._items, ref value);
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

	private IEnumerator WaitAndShow()
	{
		_003CWaitAndShow_003Ed__38 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe override void Show()
	{
		//IL_0119: Expected O, but got Ref
		Reset();
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		Component component = this;
		if (!flag)
		{
			gameObject.SetActive(value: true);
			GameObject gameObject2 = base.gameObject;
			bool flag2 = (object)gameObject2 == null;
			component = this;
			if (!flag2)
			{
				gameObject2.SetActive(value: true);
				AdventureManager adventureManager = _adventureManager;
				bool flag3 = _adventureManager == null;
				component = (Component)(object)gameObject2;
				if (!flag3)
				{
					AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
					bool flag4 = adventureManager._003CAdventureData_003Ek__BackingField == null;
					component = (Component)(object)gameObject2;
					if (!flag4)
					{
						component = (Component)(object)adventureData._003CCoreAdventureData_003Ek__BackingField;
						if (adventureData._003CCoreAdventureData_003Ek__BackingField != null)
						{
							List<SkinToUnlock> skinsToUnlock = new List<SkinToUnlock>();
							_skinsToUnlock = skinsToUnlock;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v12 (UnityEngine.Component)+50]");
							List<SkinToUnlock>.Enumerator enumerator = default(List<SkinToUnlock>.Enumerator);
							if ((nint)0 != 0 && enumerator.MoveNext())
							{
								object obj = null;
								Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator);
								throw new NullReferenceException();
							}
							_003CWaitAndShow_003Ed__38 obj2 = null;
							obj2._003C_003E1__state = 0;
							obj2._003C_003E4__this = this;
							Coroutine coroutine = StartCoroutine(obj2);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Reset()
	{
		//IL_0008: Expected O, but got Ref
		//IL_054e: Expected I, but got O
		//IL_05ae: Expected O, but got Ref
		//IL_0279: Expected O, but got Ref
		//IL_05d3: Expected I, but got O
		//IL_0628: Expected O, but got Ref
		//IL_0325: Expected O, but got Ref
		//IL_0663: Expected I, but got O
		//IL_06b8: Expected O, but got Ref
		//IL_03bf: Expected O, but got Ref
		//IL_04d3: Expected O, but got Ref
		//IL_00f2->IL051a: Incompatible stack heights: 1 vs 0
		//IL_011e->IL051a: Incompatible stack heights: 1 vs 0
		//IL_014c->IL051a: Incompatible stack heights: 1 vs 0
		//IL_0178->IL051a: Incompatible stack heights: 1 vs 0
		//IL_01a7->IL051a: Incompatible stack heights: 1 vs 0
		//IL_020a->IL051a: Incompatible stack heights: 1 vs 0
		//IL_0239->IL051a: Incompatible stack heights: 1 vs 0
		//IL_0265->IL051a: Incompatible stack heights: 1 vs 0
		//IL_02b3->IL051a: Incompatible stack heights: 1 vs 0
		//IL_042e->IL051a: Incompatible stack heights: 11 vs 0
		//IL_045d->IL051a: Incompatible stack heights: 11 vs 0
		//IL_0487->IL051a: Incompatible stack heights: 11 vs 0
		//IL_04c0->IL051a: Incompatible stack heights: 11 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)_Panel != null)
		{
			_Panel.alpha = 0f;
			if ((object)_Panel != null)
			{
				Transform transform = _Panel.transform;
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rcx_v24 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_ = Vector3.oneVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rdx_v18 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num3 = 0f * 3f;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
				_BackgroundFader.alpha = 0f;
				CanvasGroup component = _TitleGroup.GetComponent<CanvasGroup>();
				component.alpha = 0f;
				RectTransform rectTransform = _TitleFade1.rectTransform;
				RectTransform rectTransform2 = _TitleFade1.rectTransform;
				Vector2 anchoredPosition = rectTransform2.anchoredPosition;
				if ((object)rectTransform != null)
				{
					Vector2 vector = default(Vector2);
					rectTransform.anchoredPosition = vector;
					if ((object)_TitleFade2 != null)
					{
						RectTransform rectTransform3 = _TitleFade2.rectTransform;
						if ((object)_TitleFade2 != null)
						{
							RectTransform rectTransform4 = _TitleFade2.rectTransform;
							if ((object)rectTransform4 != null)
							{
								Vector2 anchoredPosition2 = rectTransform4.anchoredPosition;
								if ((object)rectTransform3 != null)
								{
									rectTransform3.anchoredPosition = vector;
									TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_TitleFade1, 0.3f, 0.001f);
									TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_TitleFade1, 0.3f, 0.001f);
									if ((object)_IconCG != null)
									{
										_IconCG.alpha = 0f;
										if ((object)_Panel != null)
										{
											Image component2 = _Panel.GetComponent<Image>();
											if ((object)component2 != null)
											{
												Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
												_ = 0;
												component2.color = color;
												ClearRays();
												if ((object)_RewardsText != null)
												{
													Transform transform2 = _RewardsText.transform;
													nint num4 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v985 @ rcx_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num5 = 0;
													bool flag2 = (object)transform2 == null;
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v51 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
													Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj4);
													bool flag4 = (object)_RewardsText == null;
													Transform transform3 = _RewardsText.transform;
													bool flag5 = (object)transform3 == null;
													_ = -180f;
													Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
													transform3.localEulerAngles = localEulerAngles;
													bool flag6 = (object)_DoneButton == null;
													Transform transform4 = _DoneButton.transform;
													nint num6 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v755 @ rdx_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num7 = 0;
													bool flag7 = (object)transform4 == null;
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rax_v61 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
													object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
													Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj5);
													bool flag9 = (object)_DoneButton == null;
													Transform transform5 = _DoneButton.transform;
													bool flag10 = (object)transform5 == null;
													_ = -180f;
													Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
													transform5.localEulerAngles = localEulerAngles2;
													bool flag11 = (object)_RewardsPanel == null;
													Vector2 sizeDelta = _RewardsPanel.sizeDelta;
													_RewardsPanel.sizeDelta = vector;
													if ((object)_RewardContent != null)
													{
														_RewardContent.alpha = 0f;
														if ((object)_DoneButton != null)
														{
															_DoneButton.Select();
															if ((object)_DoneButton != null)
															{
																_DoneButton.interactable = false;
																Selectable doneButton = _DoneButton;
																if ((object)_DoneButton != null)
																{
																	Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
																	_ = doneButton.m_Navigation;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v65 (UnityEngine.UI.Selectable)+38]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v65 (UnityEngine.UI.Selectable)+48]");
																	_ = 0;
																	_DoneButton.navigation = navigation;
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

	public override void Hide()
	{
		if (_tweens != null)
		{
			List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
			while (enumerator.MoveNext())
			{
				Tween tween = null;
			}
			base.Hide();
			PopupManager.ClosePopup(_ID);
			GameObject previouslySelected = _previouslySelected;
			if ((object)_previouslySelected == null || ((UnityEngine.Object)previouslySelected).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if ((object)_previouslySelected != null)
			{
				Selectable component = _previouslySelected.GetComponent<Selectable>();
				if ((object)component != null)
				{
					component.Select();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Initialize(string id)
	{
		_ID = id;
	}

	private void SetAdventureBackground()
	{
		if ((object)_mainMenuFactory != null)
		{
			GameObject backgroundForAdventureType = _mainMenuFactory.GetBackgroundForAdventureType(_currentAdventure);
			GameObject spawnedBackground = UnityEngine.Object.Instantiate(backgroundForAdventureType, _IconContainer);
			_spawnedBackground = spawnedBackground;
			if ((object)_spawnedBackground != null)
			{
				Transform transform = _spawnedBackground.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 160 ConditionalJump @-1, v241 @ ZF_v12 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PlayParticles(bool b)
	{
		//IL_01be: Expected O, but got I4
		//IL_01d6->IL01db: Incompatible stack heights: 6 vs 0
		//IL_0094->IL01db: Incompatible stack heights: 7 vs 0
		//IL_0083->IL01db: Incompatible stack heights: 7 vs 0
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v4 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
			bool flag3 = (object)transform2 == null;
			bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
			GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
			bool flag5 = (object)gameObject == null;
			bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj2 = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj2 != null)
			{
				Renderer component = ((Component)null).GetComponent<Renderer>();
				bool flag7 = (object)component == null;
				component.enabled = b;
				if (!b)
				{
					((ParticleSystem)null).Stop();
				}
				else
				{
					((ParticleSystem)null).Play(true);
				}
			}
		}
	}

	private unsafe void AddRays()
	{
		//IL_00cb: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_019a: Expected O, but got Ref
		//IL_0373: Expected O, but got Ref
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_0649->IL04cb: Incompatible stack heights: 8 vs 0
		//IL_022f->IL04cb: Incompatible stack heights: 8 vs 0
		//IL_0672->IL04cb: Incompatible stack heights: 8 vs 0
		//IL_069b->IL04cb: Incompatible stack heights: 8 vs 0
		//IL_0460->IL06a0: Incompatible stack heights: 8 vs 0
		List<GameObject> list = new List<GameObject>();
		GameObject gameObject = CreateRay("0xff0000");
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject2 = CreateRay("0x00ff00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject3 = CreateRay("0x0000ff");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject4 = CreateRay("0xffff00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject5 = CreateRay("0xff00ff");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			GameObject gameObject6 = CreateRay("0x00ffff");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			Vector3 value2 = default(Vector3);
			object obj4 = default(object);
			object obj5 = default(object);
			object obj6 = default(object);
			while (true)
			{
				if ((nint)obj2 < list._size)
				{
					if ((nint)obj < list._size)
					{
						GameObject[] items = list._items;
						if (list._items == null)
						{
							break;
						}
						object obj3 = items[obj];
						if ((object)items[obj] == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rbx_v14 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rbx_v14 (System.Object)+10]");
						IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						bool flag2 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v53 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v53 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v53 (UnityEngine.Transform)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v53 (UnityEngine.Transform)+10]");
						IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
						Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						bool flag5 = (object)transform2 == null;
						bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v53 (UnityEngine.Transform)+10]");
						bool flag7 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1227 @ rax_v53 (UnityEngine.Transform)+10]");
						IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
						Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
						bool flag8 = (object)transform3 == null;
						transform3.localEulerAngles = (Vector3)(&obj4);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187767F91h\"");
						float endValue = ((obj != null) ? (-3f) : 3f);
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(transform, endValue, 1f);
						if (_tweens == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleY(transform, 3.5f, 1f);
						if (_tweens == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
						Image component = transform.GetComponent<Image>();
						float num = (float)obj * 0.075f;
						float duration = num + 0.5f;
						TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(component, 0.25f, duration);
						if (tweenerCore3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1479 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1479 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1479 @ rax_v82 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
						if (_tweens == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
						float num2 = (float)obj * 0.15f;
						float duration2 = num2 + 3f;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(transform, (Vector3)(&obj5), duration2);
						if (tweenerCore4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1542 @ rax_v85 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1542 @ rax_v85 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1542 @ rax_v85 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
						if (_tweens == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
						obj++;
						obj5 = obj6;
						obj4 = obj6;
						obj2 = obj;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					break;
				}
				List<object> rays = (List<object>)(object)_rays;
				if (_rays == null)
				{
					break;
				}
				((List<object>)(object)_rays).InsertRange(rays._size, (IEnumerable<object>)list);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ClearRays()
	{
		//IL_01b0: Expected O, but got Ref
		//IL_002c: Expected O, but got Ref
		//IL_00ae: Expected I4, but got O
		//IL_00ae: Expected O, but got I
		//IL_013a: Expected I4, but got O
		//IL_013a: Expected O, but got I
		bool flag = _tweens == null;
		AdventureCompletedPopup adventureCompletedPopup = this;
		if (!flag)
		{
			List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
			while (enumerator.MoveNext())
			{
				DG.Tweening.TweenExtensions.Kill(null);
			}
			bool flag2 = _rays == null;
			adventureCompletedPopup = (AdventureCompletedPopup)(&enumerator);
			if (!flag2)
			{
				List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
				if (enumerator2.MoveNext())
				{
					List<GameObject>.Enumerator enumerator3 = (List<GameObject>.Enumerator)(&enumerator2);
					throw new NullReferenceException();
				}
				adventureCompletedPopup = (AdventureCompletedPopup)(object)_tweens;
				if (_tweens != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v3 (VampireSurvivors.UI.AdventureCompletedPopup)+1C]");
					_ = (nint)0 + (nint)1;
					((MonoBehaviour)adventureCompletedPopup).m_CancellationTokenSource = null;
					if ((nint)((MonoBehaviour)adventureCompletedPopup).m_CancellationTokenSource > 0)
					{
						Array.Clear((Array)(nint)((UnityEngine.Object)adventureCompletedPopup).m_CachedPtr, 0, (int)((MonoBehaviour)adventureCompletedPopup).m_CancellationTokenSource);
					}
					adventureCompletedPopup = (AdventureCompletedPopup)(object)_rays;
					if (_rays != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v3 (VampireSurvivors.UI.AdventureCompletedPopup)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)adventureCompletedPopup).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)adventureCompletedPopup).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)adventureCompletedPopup).m_CachedPtr, 0, (int)((MonoBehaviour)adventureCompletedPopup).m_CancellationTokenSource);
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe GameObject CreateRay(string color)
	{
		//IL_006e: Expected O, but got Ref
		Color color2 = hexToColor(color);
		GameObject gameObject = UnityEngine.Object.Instantiate(_Ray, _RayContainer);
		if ((object)gameObject != null)
		{
			Image component = gameObject.GetComponent<Image>();
			if ((object)component != null)
			{
				object obj = default(object);
				component.color = (Color)(&obj);
				gameObject.SetActive(value: true);
				if (_rays != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
					return gameObject;
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public static string colorToHex(Color32 color)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A63D9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		byte b = default(byte);
		string text = b.ToString("X2");
		byte b2 = default(byte);
		string text2 = b2.ToString("X2");
		byte b3 = default(byte);
		string text3 = b3.ToString("X2");
		return text + text2 + text3;
	}

	private unsafe static Color hexToColor(string hex)
	{
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Expected O, but got Unknown
		//IL_0132: Expected O, but got I4
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_019b: Expected O, but got I4
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_0542: Expected native int or pointer, but got O
		//IL_0204: Expected O, but got I4
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected O, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A63DA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = hex.Replace("0x", "");
		string text2 = text.Replace("#", "");
		if (text2._stringLength >= 0)
		{
			bool flag = text2._stringLength < 2;
			bool flag2 = text2._stringLength == 2;
			if (!flag)
			{
				string text4;
				if (!flag2)
				{
					string text3 = text2.InternalSubString(0, 2);
					if (text3 == null)
					{
						goto IL_03a1;
					}
					text4 = text3;
				}
				else
				{
					text4 = text2;
				}
				object obj = text4 + 20;
				_ = text4._stringLength;
				_ = 0;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj2 = default(object);
				ReadOnlySpan<char> s = (ReadOnlySpan<char>)(obj2 - 32);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
				_ = 0;
				byte b = byte.Parse(s, NumberStyles.HexNumber, currentInfo);
				if (text2._stringLength >= 2)
				{
					object obj3 = text2._stringLength - 2;
					if ((nint)obj3 >= 2)
					{
						string text5 = text2.InternalSubString(2, 2);
						if (text5 != null)
						{
							object obj4 = text5 + 20;
							_ = 0;
							_ = text5._stringLength;
							NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
							ReadOnlySpan<char> s2 = (ReadOnlySpan<char>)(obj2 - 32);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
							_ = 0;
							byte b2 = byte.Parse(s2, NumberStyles.HexNumber, currentInfo2);
							if (text2._stringLength < 4)
							{
								ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
								ex._002Ector("startIndex", "startIndex cannot be larger than length of string.");
								throw ex;
							}
							object obj5 = text2._stringLength - 2;
							if ((nint)obj5 < 4)
							{
								ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
								ex2._002Ector("length", "Index and length must refer to a location within the string.");
								throw ex2;
							}
							string text6 = text2.InternalSubString(4, 2);
							if (text6 != null)
							{
								object obj6 = text6 + 20;
								_ = 0;
								_ = text6._stringLength;
								NumberFormatInfo currentInfo3 = NumberFormatInfo.CurrentInfo;
								ReadOnlySpan<char> s3 = (ReadOnlySpan<char>)(obj2 - 32);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
								_ = 0;
								byte b3 = byte.Parse(s3, NumberStyles.HexNumber, currentInfo3);
								bool flag3 = text2._stringLength != 8;
								byte b4 = 255;
								if (!flag3)
								{
									object obj7 = text2._stringLength - 2;
									if ((nint)obj7 < 6)
									{
										goto IL_054c;
									}
									string text7 = text2.InternalSubString(6, 2);
									if (text7 == null)
									{
										goto IL_03a1;
									}
									object obj8 = text7 + 20;
									_ = 0;
									_ = text7._stringLength;
									NumberFormatInfo currentInfo4 = NumberFormatInfo.CurrentInfo;
									ReadOnlySpan<char> s4 = (ReadOnlySpan<char>)(obj2 - 32);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
									_ = 0;
									byte b5 = byte.Parse(s4, NumberStyles.HexNumber, currentInfo4);
									b4 = b5;
								}
								_ = 0;
								Color color = default(Color);
								float r = default(float);
								((Color*)(nint)color)->r = r;
								return color;
							}
						}
						goto IL_03a1;
					}
					ArgumentOutOfRangeException ex3 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
					ex3._002Ector("length", "Index and length must refer to a location within the string.");
					throw ex3;
				}
				ArgumentOutOfRangeException ex4 = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
				ex4._002Ector("startIndex", "startIndex cannot be larger than length of string.");
				throw ex4;
			}
			ArgumentOutOfRangeException ex5 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
			ex5._002Ector("length", "Index and length must refer to a location within the string.");
			throw ex5;
		}
		ArgumentOutOfRangeException ex6 = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
		ex6._002Ector("startIndex", "startIndex cannot be larger than length of string.");
		throw ex6;
		IL_03a1:
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.s);
		goto IL_054c;
		IL_054c:
		ArgumentOutOfRangeException ex7 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
		ex7._002Ector("length", "Index and length must refer to a location within the string.");
		throw ex7;
	}

	private unsafe Texture2D DuplicateTexture(Texture2D source)
	{
		//IL_006c: Expected O, but got Ref
		//IL_011c: Expected O, but got Ref
		int width = source.width;
		int height = source.height;
		GraphicsFormat compatibleFormat = RenderTexture.GetCompatibleFormat(RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
		GraphicsFormat depthStencilFormatLegacy = RenderTexture.GetDepthStencilFormatLegacy(0, false);
		GraphicsFormat depthStencilFormat = default(GraphicsFormat);
		RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(width, height, compatibleFormat, depthStencilFormat);
		object obj = default(object);
		RenderTexture temporary = RenderTexture.GetTemporary((RenderTextureDescriptor)(&obj));
		UnityEngine.Graphics.Blit(source, temporary);
		RenderTexture active = RenderTexture.GetActive();
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v23 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		IntPtr active_Injected = ((UnityEngine.Object)temporary)?.m_CachedPtr ?? ((IntPtr)0);
		RenderTexture.SetActive_Injected(active_Injected);
		int width2 = source.width;
		int height2 = source.height;
		Texture2D texture2D = new Texture2D(width2, height2);
		int width3 = temporary.width;
		int height3 = temporary.height;
		object obj2 = default(object);
		texture2D.ReadPixels((Rect)(&obj2), 0, 0);
		texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ rcx_v35 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag = (object)active == null;
		nint active_Injected2 = 0;
		if (!flag)
		{
			active_Injected2 = ((UnityEngine.Object)active).m_CachedPtr;
		}
		RenderTexture.SetActive_Injected((IntPtr)active_Injected2);
		RenderTexture.ReleaseTemporary_Injected(((UnityEngine.Object)temporary).m_CachedPtr);
		return texture2D;
	}

	public unsafe void SetSkins()
	{
		//IL_013c: Expected O, but got Ref
		//IL_0217: Expected I, but got O
		//IL_022e: Expected O, but got I4
		//IL_0239: Expected I, but got O
		//IL_0241: Expected O, but got Ref
		//IL_0917: Expected F8, but got I4
		//IL_0920: Expected F8, but got I4
		//IL_093b: Invalid comparison between F8 and I4
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected I4, but got Unknown
		//IL_0592: Expected F8, but got I4
		//IL_059b: Expected F8, but got I4
		//IL_05aa: Invalid comparison between F8 and I4
		//IL_062b: Expected F8, but got I4
		//IL_063c: Expected F8, but got I4
		//IL_099d: Invalid comparison between F8 and I4
		//IL_0dd8: Invalid comparison between F8 and I4
		//IL_05ff: Expected O, but got I4
		//IL_09b9: Expected O, but got Ref
		//IL_064e: Invalid comparison between F8 and I4
		//IL_09f5: Invalid comparison between F8 and I4
		//IL_0a11: Expected O, but got Ref
		//IL_0710: Expected I4, but got O
		//IL_0788: Expected I4, but got O
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Expected O, but got Unknown
		//IL_07f1: Invalid comparison between F8 and I4
		//IL_0dc6: Expected O, but got I4
		//IL_0dc6: Expected I4, but got F8
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Expected I4, but got Unknown
		//IL_0854: Expected O, but got F8
		//IL_0819: Expected F8, but got I4
		//IL_0a80->IL092e: Incompatible stack heights: 2 vs 0
		//IL_0e36->IL0b64: Incompatible stack heights: 1 vs 0
		//IL_0871->IL0dcb: Incompatible stack heights: 8 vs 0
		bool flag;
		if (_skinsToUnlock == null)
		{
			flag = false;
		}
		else
		{
			List<SkinToUnlock> skinsToUnlock = _skinsToUnlock;
			int num = skinsToUnlock._size ^ skinsToUnlock._size;
			int num2 = skinsToUnlock._size & num;
			bool flag2 = num2 < 0;
			bool flag3 = skinsToUnlock._size < 0;
			bool flag4 = skinsToUnlock._size == 0;
			bool flag5 = flag3 == flag2;
			bool flag6 = !flag4;
			flag = flag6 & flag5;
		}
		GameObject gameObject = _SkinRewardGroup.gameObject;
		gameObject.SetActive(flag);
		if (!flag)
		{
			return;
		}
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		GameObject gameObject2 = _SkinCarousel.gameObject;
		gameObject2.SetActive(value: true);
		List<SkinToUnlock>.Enumerator enumerator = default(List<SkinToUnlock>.Enumerator);
		if (enumerator.MoveNext())
		{
			AdventureCompletedPopup adventureCompletedPopup = null;
			List<SkinToUnlock>.Enumerator enumerator2 = (List<SkinToUnlock>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		List<Sprite> list = new List<Sprite>();
		AdventureCompletedPopup value = default(AdventureCompletedPopup);
		List<SkinToUnlock> skinsToUnlock2 = value._skinsToUnlock;
		nint num3 = unchecked((nint)null);
		List<SkinToUnlock>.Enumerator skinsToUnlock3 = (List<SkinToUnlock>.Enumerator)value._skinsToUnlock;
		List<SkinToUnlock>.Enumerator enumerator3 = (List<SkinToUnlock>.Enumerator)24;
		List<SkinToUnlock>.Enumerator enumerator4 = default(List<SkinToUnlock>.Enumerator);
		if (enumerator4.MoveNext())
		{
			nint num4 = unchecked((nint)null);
			List<SkinToUnlock>.Enumerator enumerator5 = (List<SkinToUnlock>.Enumerator)(&enumerator4);
			throw new NullReferenceException();
		}
		if (list._size != 0)
		{
			bool flag7 = default(bool);
			int width = default(int);
			Texture2D texture2D = new Texture2D(width, 64, TextureFormat.ARGB4444, flag7);
			width = list._size * enumerator3;
			texture2D.wrapMode = TextureWrapMode.Repeat;
			Color[] pixels = texture2D.GetPixels();
			double num5 = 0.0;
			for (double num6 = 0.0; num6 < (double)pixels.Length; num6 = num5)
			{
				double num7 = num5 + 2.0;
				double num8 = num7 + num7;
				_ = 0;
				num5++;
				skinsToUnlock3 = (List<SkinToUnlock>.Enumerator)0;
			}
			texture2D.SetPixels(pixels);
			int num9 = 0;
			double num10 = 0.0;
			Texture2D texture2D2 = texture2D;
			int num13 = default(int);
			object obj4 = default(object);
			int miplevel = default(int);
			for (double num11 = 0.0; num11 < (double)list._size; num11 = num10)
			{
				bool flag8 = !(num10 < (double)list._size);
				Sprite[] items = list._items;
				AdventureCompletedPopup adventureCompletedPopup2 = (AdventureCompletedPopup)(object)items[num10];
				Texture2D texture = items[num10].texture;
				Texture2D texture2D3 = value.DuplicateTexture(texture);
				Texture2D texture2 = items[num10].texture;
				int width2 = texture2.width;
				bool flag9 = ((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr == (IntPtr)0;
				object obj = Sprite.get_uv_Injected(((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr);
				Texture2D texture3 = items[num10].texture;
				int num12 = (int)texture3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v337 @ r8_v52 (System.Int32)+1A8] (should have been resolved before IL gen)");
				bool flag10 = ((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr == (IntPtr)0;
				object obj2 = Sprite.get_uv_Injected(((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr);
				bool flag11 = ((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr, out Rect _);
				bool flag12 = ((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr, out Rect _);
				bool flag13 = ((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr, out Rect _);
				bool flag14 = ((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr, out Rect ret4);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rsp+94h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,dword ptr [rsp+60h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rsp+7Ch]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+0E0h]\"");
				Color[] pixels2 = texture2D3.GetPixels((int)(&ret4), (int)texture3, 2, flag7 ? 1 : 0, num13);
				bool flag15 = ((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)adventureCompletedPopup2).m_CachedPtr, out Rect _);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rsp+0FCh]\"");
				object obj3 = 64 - obj4;
				float num14 = (float)obj3 * 0.5f;
				double num15 = Math.Ceiling(num14);
				Rect rect = items[num10].rect;
				Rect rect2 = items[num10].rect;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0Ch]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm6\"");
				bool flag16 = !(num15 < 0.0);
				double num16 = num15;
				if (!flag16)
				{
					num16 = 0.0;
				}
				texture2D.SetPixels(num9, (int)num16, 2, flag7 ? 1 : 0, (Color[])num13, miplevel);
				UnityEngine.Object.Destroy(texture2D3);
				num10++;
				int num17 = num9 + enumerator3;
				num9 = num17;
				skinsToUnlock3 = (List<SkinToUnlock>.Enumerator)num15;
				flag7 = flag7;
				texture2D2 = texture2D;
			}
			texture2D2.filterMode = FilterMode.Point;
			texture2D2.Apply(updateMipmaps: true, makeNoLongerReadable: false);
			RawImage component = value._SkinCarousel.GetComponent<RawImage>();
			component.texture = texture2D2;
			GameObject gameObject3 = value._SkinCarousel.gameObject;
			RectTransform component2 = gameObject3.GetComponent<RectTransform>();
			int height = texture2D2.height;
			int width3 = texture2D2.width;
			bool flag17 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
			RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)(&value));
		}
		else
		{
			List<SkinToUnlock> skinsToUnlock4 = value._skinsToUnlock;
			double num18 = 0.0;
			double num19 = 0.0;
			string text = "";
			IntPtr intPtr = default(IntPtr);
			IntPtr intPtr2 = default(IntPtr);
			while (num19 < (double)skinsToUnlock4._size)
			{
				string[] array = new string[6];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				List<SkinToUnlock> skinsToUnlock5 = value._skinsToUnlock;
				bool flag18 = !(num18 < (double)skinsToUnlock5._size);
				string text2 = ((Enum)(&intPtr)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				List<SkinToUnlock> skinsToUnlock6 = value._skinsToUnlock;
				bool flag19 = !(num18 < (double)skinsToUnlock6._size);
				string text3 = ((Enum)(&intPtr2)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int num20 = ((Dictionary<CharacterType, List<CharacterData>>)(object)array).FindEntry(CharacterType.CRISTINA);
				string text4 = string.Concat(array);
				num18++;
				skinsToUnlock4 = value._skinsToUnlock;
				num19 = num18;
				text = text4;
			}
			string message = "Adventure Completed Popup couldn't show skin rewards because no skins were found for: " + text;
			Debug.LogError(message);
			GameObject gameObject4 = value._SkinCarousel.gameObject;
			gameObject4.SetActive(value: true);
		}
	}

	private void LateUpdate()
	{
		//IL_02d6: Expected O, but got I4
		//IL_0072: Invalid comparison between O and F4
		//IL_0276: Expected O, but got I
		//IL_0223: Invalid comparison between O and F4
		//IL_0243: Invalid comparison between O and F4
		//IL_02fc: Expected O, but got F4
		//IL_0337: Invalid comparison between O and F4
		//IL_015e: Expected O, but got F4
		//IL_0113: Invalid comparison between O and F4
		//IL_0133: Invalid comparison between O and F4
		//IL_0186->IL0280: Incompatible stack heights: 1 vs 0
		//IL_0055->IL0280: Incompatible stack heights: 1 vs 0
		//IL_01b2->IL0280: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL0280: Incompatible stack heights: 1 vs 0
		//IL_00cc->IL0280: Incompatible stack heights: 1 vs 0
		Rect rect = default(Rect);
		if ((object)_SkinCarousel != null)
		{
			GameObject gameObject = _SkinCarousel.gameObject;
			if ((object)gameObject != null)
			{
				bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				if (obj == null)
				{
					goto IL_016c;
				}
				if ((object)_SkinCarousel != null)
				{
					Vector2 sizeDelta = _SkinCarousel.sizeDelta;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref sizeDelta) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)658f))
					{
						goto IL_016c;
					}
					if ((object)_SkinCarousel != null)
					{
						RawImage component = _SkinCarousel.GetComponent<RawImage>();
						if ((object)component != null)
						{
							object obj2 = Time.deltaTime;
							float num = (float)sizeDelta * 0.15f;
							float num2 = num + (float)component.m_UVRect;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A951h\"");
							if ((object)component.m_UVRect == (object)num2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A951h\"");
								if ((object)rect == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A951h\"");
									if ((object)rect == (object)1f)
									{
										bool flag2 = (object)rect == (object)1f;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A951h\"");
										if (flag2)
										{
											return;
										}
									}
								}
							}
							component.m_UVRect = (Rect)num2;
							component.SetVerticesDirty();
							return;
						}
					}
				}
			}
		}
		goto IL_0280;
		IL_016c:
		if ((object)_SkinCarousel != null)
		{
			RawImage component2 = _SkinCarousel.GetComponent<RawImage>();
			if ((object)component2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A9F1h\"");
				if ((object)component2.m_UVRect == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A9F1h\"");
					if ((object)rect == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A9F1h\"");
						if ((object)rect == (object)1f)
						{
							bool flag3 = (object)rect == (object)1f;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018776A9F1h\"");
							if (flag3)
							{
								return;
							}
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
				component2.m_UVRect = (Rect)0;
				component2.SetVerticesDirty();
				return;
			}
		}
		goto IL_0280;
		IL_0280:
		throw new NullReferenceException();
	}

	public AdventureCompletedPopup()
	{
		List<ParticleSystem> particles = new List<ParticleSystem>();
		_particles = particles;
		_rays = new List<GameObject>();
		_tweens = new List<Tween>();
		base._002Ector();
	}

	private void _003CDoShow_003Eb__36_0()
	{
		_DoneButton.Select();
	}

	private void _003CDoShow_003Eb__36_1()
	{
		Transform target = _Panel.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.125f);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Panel, 1f, 0.125f);
	}

	private void _003CDoShow_003Eb__36_2()
	{
		CanvasGroup component = _TitleGroup.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 1f, 0.125f);
	}

	private unsafe void _003CDoShow_003Eb__36_3()
	{
		//IL_0175: Expected O, but got Ref
		RectTransform rectTransform = _TitleFade1.rectTransform;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPosX(rectTransform, -1225f, 0.2f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 18;
				_ = 0;
			}
		}
		RectTransform rectTransform2 = _TitleFade2.rectTransform;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPosX(rectTransform2, 1225f, 0.2f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 18;
				_ = 0;
			}
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_TitleFade1, 0f, 0.2f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(_TitleFade2, 0f, 0.2f);
		AddRays();
		MakeColorParticles();
		Image component = _Panel.GetComponent<Image>();
		object obj = default(object);
		TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleUI.DOColor(component, (Color)(&obj), 0.2f);
		TweenerCore<float, float, FloatOptions> tweenerCore6 = DOTweenModuleUI.DOFade(_IconCG, 1f, 0.2f);
		Vector2 sizeDelta = _RewardsPanel.sizeDelta;
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore7 = DOTweenModuleUI.DOSizeDelta(_RewardsPanel, endValue, 0.3f);
		if (tweenerCore7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 27;
				_ = 0;
			}
		}
	}

	private unsafe void _003CDoShow_003Eb__36_4()
	{
		//IL_00fc: Expected O, but got Ref
		AdventureManager adventureManager = _adventureManager;
		AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
		CoreAdventureData coreAdventureData = adventureData._003CCoreAdventureData_003Ek__BackingField;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CAdventureCompletionCount_003Ek__BackingField > 0)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm1\"");
		}
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("adventureLang/adv_adventureSelect_completePopup", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if ("N0" != null)
		{
		}
		object obj = default(object);
		string newValue = System.Number.FormatInt32(coreAdventureData._003CCompletionCoinReward_003Ek__BackingField, (ReadOnlySpan<char>)(&obj), LocalizationManager.mCurrentCulture);
		string text = translation.Replace("%0", newValue);
		_CoinRewardText.text = text;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_RewardContent, 1f, 0.3f);
		SetSkins();
	}

	private unsafe void _003CDoShow_003Eb__36_5()
	{
		//IL_0092: Expected O, but got Ref
		//IL_00ad: Expected O, but got Ref
		Transform target = _DoneButton.transform;
		Vector3 vector = default(Vector3);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&vector), 0.125f, RotateMode.FastBeyond360);
		Transform target2 = _DoneButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, (Vector3)(&vector), 0.125f);
		TweenCallback tweenCallback = delegate
		{
			_DoneButton.interactable = true;
		};
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void _003CDoShow_003Eb__36_6()
	{
		_DoneButton.interactable = true;
	}
}
