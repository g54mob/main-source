using System;
using Febucci.Parsing.Core;
using Febucci.Parsing.Regions;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Text;
using Febucci.TextAnimatorCore.Time;
using Febucci.TextAnimatorForUnity.Styles;
using UnityEngine;
using UnityEngine.Serialization;

namespace Febucci.TextAnimatorForUnity
{
	[DisallowMultipleComponent]
	[HelpURL("https://www.febucci.com/text-animator-unity/docs/how-to-add-effects-to-your-texts/")]
	public abstract class TextAnimatorComponentBase : MonoBehaviour, ISettingsProvider<AnimatorSettings>, ITextAnimatorProvider
	{
		[SerializeField]
		public AnimatorSettings localSettings = new AnimatorSettings();

		[SerializeField]
		public AnimatorSettingsScriptable sharedSettings;

		private TextAnimator _wrapper;

		private TagParserBase[] extraParsers;

		private ITextGenerator generator;

		private bool initialized;

		[Tooltip("Controls when this TextAnimator component should update its effects. Defaults in the 'Update' Loop.\nSet it to 'Manual' if you want to control the animations from your own loop instead.")]
		public AnimationLoop animationLoop;

		[FormerlySerializedAs("databaseBehaviors")]
		[SerializeField]
		private AnimationsDatabase databaseEffects;

		[SerializeField]
		private StyleSheetScriptable styleSheet;

		private TextAnimatorSettings globalSettings;

		public AnimatorSettings Settings
		{
			get
			{
				if (!(sharedSettings != null))
				{
					return localSettings;
				}
				return sharedSettings.Settings;
			}
		}

		private TextAnimator Wrapper
		{
			get
			{
				if (initialized)
				{
					return _wrapper;
				}
				TryInitializingOnce();
				return _wrapper;
			}
		}

		TextAnimator ITextAnimatorProvider.TextAnimator => _wrapper;

		[Tooltip("Chooses which Time Scale to use when animating effects.\nSet it to 'Unscaled' if you want to animate effects even when the game is paused.")]
		public TimeScale timeScale => localSettings.timeScale;

		public string textFull => Wrapper.TextFull;

		public string textWithoutTextAnimTags => Wrapper.TextWithoutTextAnimatorTags;

		public string textWithoutAnyTag => Wrapper.TextWithoutAnyTag;

		public CharacterData latestCharacterShown => Wrapper.LatestCharacterShown;

		public bool allLettersShown => Wrapper.AllLettersShown;

		public bool anyLetterVisible => Wrapper.AnyLetterVisible;

		public int CharactersCount => Wrapper.CharactersCount;

		public CharacterData[] Characters => Wrapper.Characters;

		public int WordsCount => Wrapper.WordsCount;

		public WordInfo[] Words => Wrapper.Words;

		[Tooltip("True if you want the animations to be uniform/consistent across different font sizes. Default/Suggested to leave this as true, and change the 'Reference Font Size'.\nOtherwise, effects will move more when the text is smaller (requires less space on screen)")]
		public bool useDynamicScaling => localSettings.useDynamicScaling;

		[Tooltip("Font size that will be used as reference to keep animations consistent/uniform at different scales.")]
		public float referenceFontSize => localSettings.referenceFontSize;

		[Tooltip("True if you want the animator's time to be reset on new text.")]
		public bool isResettingTimeOnNewText => localSettings.isResettingTimeOnNewText;

		public AnimationsDatabase DatabaseEffects
		{
			get
			{
				return databaseEffects;
			}
			set
			{
				databaseEffects = value;
				if (_wrapper != null)
				{
					_wrapper.RequiresMeshUpdate = true;
				}
			}
		}

		public StyleSheetScriptable StyleSheet
		{
			get
			{
				return styleSheet;
			}
			set
			{
				styleSheet = value;
				if (Wrapper != null)
				{
					_wrapper.stylesDatabase = styleSheet;
					_wrapper.RequiresMeshUpdate = true;
				}
			}
		}

		public TextRegion<IEffectPlayer>[] Behaviors => Wrapper.BehaviorRegions;

		public TextRegion<IEffectPlayer>[] Appearances => Wrapper.AppearanceRegions;

		public TextRegion<IEffectPlayer>[] Disappearances => Wrapper.DisappearanceRegions;

		[HideInInspector]
		public TimeData time => _wrapper.Time;

		[Tooltip("Controls how default tags should be applied.\n\"Fallback\" will apply the effects only to characters that don't have any.\n\"Constant\" will apply the default effects to all the characters, even if they already have other tags via text.")]
		public DefaultEffectsMode defaultTagsMode
		{
			get
			{
				return localSettings.defaultEffectsMode;
			}
			set
			{
				localSettings.defaultEffectsMode = value;
			}
		}

		public int FirstVisibleCharacter
		{
			get
			{
				return Wrapper.FirstVisibleCharacter;
			}
			set
			{
				Wrapper.FirstVisibleCharacter = value;
			}
		}

		public int MaxVisibleCharacters
		{
			get
			{
				return Wrapper.MaxVisibleCharacters;
			}
			set
			{
				Wrapper.MaxVisibleCharacters = value;
			}
		}

		[Obsolete("Please use 'isResettingTimeOnNewText' instead")]
		public bool isResettingEffectsOnNewText => isResettingTimeOnNewText;

		[Obsolete("Please use 'animationLoop' instead")]
		public AnimationLoop updateMode => animationLoop;

		[Obsolete("Please use 'textFull' instead")]
		public string text => textFull;

		[Obsolete("Please change 'referenceFontSize' instead")]
		public float effectIntensityMultiplier
		{
			get
			{
				return referenceFontSize;
			}
			set
			{
				localSettings.referenceFontSize = value;
			}
		}

		protected abstract ITextGenerator GetTextGenerator();

		protected virtual void OnInitialized()
		{
		}

		private void Awake()
		{
			TryInitializingOnce();
		}

		protected abstract bool IsUpPositive();

		public void TryInitializingOnce()
		{
			if (!initialized)
			{
				initialized = true;
				AnimUtils.Initialize();
				generator = GetTextGenerator();
				TagParserBase[] array = GetExtraParsers();
				databaseEffects?.ForceBuildRefresh();
				styleSheet?.ForceBuildRefresh();
				UnityEngineProvider instance = UnityEngineProvider.Instance;
				ITextGenerator textGenerator = generator;
				TextAnimatorSettings instance2 = TextAnimatorSettings.Instance;
				TagParserBase[] array2 = array;
				_wrapper = new TextAnimator(pasteNoParseTag: true, '<', '/', '>', instance, textGenerator, this, instance2, IsUpPositive(), array2, this);
				OnInitialized();
				_wrapper.effectsDatabase = databaseEffects;
				_wrapper.stylesDatabase = styleSheet;
				_wrapper.OnDisposed += delegate
				{
					initialized = false;
				};
				generator.SetTextToSource(generator.GetFullText());
			}
		}

		protected virtual TagParserBase[] GetExtraParsers()
		{
			return Array.Empty<TagParserBase>();
		}

		public void SetText(string text)
		{
			Wrapper.SetText(text);
		}

		public void SwapText(string text)
		{
			Wrapper.SwapText(text);
		}

		public void SetText(string text, bool hideText)
		{
			Wrapper.SetText(text, (!hideText) ? ShowTextMode.Shown : ShowTextMode.Hidden);
		}

		public void AppendText(string appendedText, bool hideText = false)
		{
			Wrapper.AppendText(appendedText, hideText);
		}

		public void SetVisibilityChar(int index, bool isVisible, bool canPlayEffects = true)
		{
			Wrapper.SetVisibilityChar(index, isVisible, canPlayEffects);
		}

		public void SetVisibilityWord(int index, bool isVisible, bool canPlayEffects = true)
		{
			Wrapper.SetVisibilityWord(index, isVisible, canPlayEffects);
		}

		public void SetVisibilityEntireText(bool isVisible, bool canPlayEffects = true)
		{
			Wrapper.SetVisibilityEntireText(isVisible, canPlayEffects);
		}

		private void Update()
		{
			if (IsReady() && animationLoop == AnimationLoop.Update)
			{
				Animate((timeScale == TimeScale.Unscaled) ? Time.unscaledDeltaTime : Time.deltaTime);
			}
		}

		private void LateUpdate()
		{
			if (animationLoop == AnimationLoop.LateUpdate)
			{
				Animate(UnityEngineProvider.Instance.GetCurrentDeltaTime(timeScale));
			}
		}

		protected abstract bool IsReady();

		public void Animate(float deltaTime)
		{
			if (initialized && IsReady())
			{
				TryInitializingOnce();
				_wrapper.Animate(deltaTime);
			}
		}

		public void ScheduleMeshRefresh()
		{
			Wrapper.RequiresMeshUpdate = true;
		}

		public void ForceDatabaseRefresh()
		{
			if ((bool)DatabaseEffects)
			{
				DatabaseEffects.ForceBuildRefresh();
			}
			if ((bool)StyleSheet)
			{
				StyleSheet.ForceBuildRefresh();
			}
			_wrapper?.SetText(_wrapper.TextFull, ShowTextMode.Refresh);
		}

		public void SetBehaviorsActive(bool isCategoryEnabled)
		{
			localSettings.isAnimatingBehaviors = isCategoryEnabled;
		}

		public void SetAppearancesActive(bool isCategoryEnabled)
		{
			localSettings.isAnimatingAppearances = isCategoryEnabled;
		}

		protected virtual void OnEnable()
		{
			Wrapper.RequiresMeshUpdate = true;
			Animate(0f);
		}

		protected void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
			_wrapper?.Dispose();
		}

		public void ResetState()
		{
			initialized = false;
			TryInitializingOnce();
		}

		[ContextMenu("Refresh All Effect States")]
		public void RefreshAllEffectStates()
		{
			_wrapper?.RefreshAllEffectStates();
		}

		[Obsolete("Use SetVisibilityEntireText instead")]
		public void ShowAllCharacters(bool skipAppearanceEffects)
		{
			SetVisibilityEntireText(isVisible: true, skipAppearanceEffects);
		}

		[Obsolete("Use 'Animate' instead.")]
		public void UpdateEffects()
		{
			Animate((timeScale == TimeScale.Unscaled) ? Time.unscaledDeltaTime : Time.deltaTime);
		}

		[Obsolete("Use 'ScheduleMeshRefresh' instead")]
		public void ForceMeshRefresh()
		{
			ScheduleMeshRefresh();
		}

		[Obsolete("To restart TextAnimator's time, please use 'time.RestartTime()'. To skip appearances effects please set 'SetVisibilityEntireText(true, false)' instead")]
		public void ResetEffectsTime(bool skipAppearances)
		{
			time.RestartTime();
			if (skipAppearances)
			{
				SetVisibilityEntireText(isVisible: true, canPlayEffects: false);
			}
		}
	}
}
