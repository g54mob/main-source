using System;
using Febucci.UI.Actions;
using Febucci.UI.Core.Parsing;
using Febucci.UI.Effects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Febucci.UI.Core
{
	[DisallowMultipleComponent]
	[HelpURL("https://www.febucci.com/text-animator-unity/docs/how-to-add-effects-to-your-texts/")]
	public abstract class TAnimCore : MonoBehaviour
	{
		private enum ShowTextMode : byte
		{
			Hidden = 0,
			Shown = 1,
			UserTyping = 2,
			Refresh = 3
		}

		private struct DefaultRegion
		{
			public string[] tagWords;

			public AnimationRegion region;

			public DefaultRegion(string tagID, VisibilityMode visibilityMode, AnimationScriptableBase scriptable, string[] tagWords)
			{
				this.tagWords = null;
				region = null;
			}
		}

		public enum DefaultTagsMode
		{
			Fallback = 0,
			Constant = 1
		}

		private bool initialized;

		private bool requiresTagRefresh;

		[Tooltip("If the source text changes, should the typewriter start automatically? Requires a Typewriter component if true.\nP.s. Previously, this option was called 'Use Easy Integration'.")]
		public bool typewriterStartsAutomatically;

		private TypewriterCore _typewriterCache;

		[Tooltip("Controls when this TextAnimator component should update its effects. Defaults in the 'Update' Loop.\nSet it to 'Manual' if you want to control the animations from your own loop instead.")]
		public AnimationLoop animationLoop;

		[Tooltip("Chooses which Time Scale to use when animating effects.\nSet it to 'Unscaled' if you want to animate effects even when the game is paused.")]
		public TimeScale timeScale;

		[TextArea(4, 10)]
		[SerializeField]
		[HideInInspector]
		private string _text;

		private int charactersCount;

		private CharacterData[] characters;

		private int wordsCount;

		private WordInfo[] words;

		[Tooltip("True if you want the animations to be uniform/consistent across different font sizes. Default/Suggested to leave this as true, and change the 'Reference Font Size'.\nOtherwise, effects will move more when the text is smaller (requires less space on screen)")]
		public bool useDynamicScaling;

		[Tooltip("Font size that will be used as reference to keep animations consistent/uniform at different scales.")]
		public float referenceFontSize;

		[FormerlySerializedAs("isResettingEffectsOnNewText")]
		[Tooltip("True if you want the animator's time to be reset on new text.")]
		public bool isResettingTimeOnNewText;

		private bool isAnimatingBehaviors;

		private bool isAnimatingAppearances;

		[Tooltip("Lets you use the databases referenced in the 'TextAnimatorSettings' asset.\nSet to false if you'd like to specify which databases to use in this component.")]
		public bool useDefaultDatabases;

		[SerializeField]
		private AnimationsDatabase databaseBehaviors;

		[SerializeField]
		private AnimationsDatabase databaseAppearances;

		private AnimationRegion[] behaviors;

		private AnimationRegion[] appearances;

		private AnimationRegion[] disappearances;

		private ActionMarker[] actions;

		[SerializeField]
		private ActionDatabase databaseActions;

		private EventMarker[] events;

		[SerializeField]
		private string[] defaultAppearancesTags;

		[SerializeField]
		private string[] defaultDisappearancesTags;

		[SerializeField]
		private string[] defaultBehaviorsTags;

		private bool requiresMeshUpdate;

		[HideInInspector]
		public TimeData time;

		[Tooltip("Controls how default tags should be applied.\n\"Fallback\" will apply the effects only to characters that don't have any.\n\"Constant\" will apply the default effects to all the characters, even if they already have other tags via text.")]
		public DefaultTagsMode defaultTagsMode;

		private TextAnimatorSettings settings;

		private int _firstVisibleCharacter;

		private int _maxVisibleCharacters;

		private TypewriterCore typewriter => null;

		public string textFull
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string textWithoutTextAnimTags { get; private set; }

		public string textWithoutAnyTag { get; private set; }

		private bool hasText => false;

		public CharacterData latestCharacterShown { get; private set; }

		public bool allLettersShown => false;

		public bool anyLetterVisible => false;

		public int CharactersCount => 0;

		public CharacterData[] Characters => null;

		public int WordsCount => 0;

		public WordInfo[] Words => null;

		public AnimationsDatabase DatabaseBehaviors
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationsDatabase DatabaseAppearances
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationRegion[] Behaviors
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationRegion[] Appearances
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationRegion[] Disappearances
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ActionMarker[] Actions
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ActionDatabase DatabaseActions
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EventMarker[] Events
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] DefaultAppearancesTags
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] DefaultDisappearancesTags
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] DefaultBehaviorsTags
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int firstVisibleCharacter
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int maxVisibleCharacters
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Obsolete("Please use 'isResettingTimeOnNewText' instead")]
		public bool isResettingEffectsOnNewText => false;

		[Obsolete("Please use 'animationLoop' instead")]
		public AnimationLoop updateMode => default(AnimationLoop);

		[Obsolete("Events are now handled/stored by Typewriters instead.")]
		public MessageEvent onEvent => null;

		[Obsolete("Please use TextAnimatorSettings.Instance.appearances.enabled instead")]
		public static bool effectsAppearancesEnabled => false;

		[Obsolete("Please use TextAnimatorSettings.Instance.behaviors.enabled instead")]
		public static bool effectsBehaviorsEnabled => false;

		[Obsolete("Please use 'textFull' instead")]
		public string text => null;

		[Obsolete("Please change 'referenceFontSize' instead")]
		public float effectIntensityMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected virtual void OnInitialized()
		{
		}

		public abstract string GetOriginalTextFromSource();

		public abstract string GetStrippedTextFromSource();

		public abstract void SetTextToSource(string text);

		protected abstract bool HasChangedText(string strippedText);

		protected abstract bool HasChangedRenderingSettings();

		protected abstract int GetCharactersCount();

		protected abstract void OnForceMeshUpdate();

		protected abstract void CopyMeshFromSource(ref CharacterData[] characters);

		protected abstract void PasteMeshToSource(CharacterData[] characters);

		private void ForceMeshUpdate()
		{
		}

		private void Awake()
		{
		}

		private void TryInitializing()
		{
		}

		private void UpdateUniformIntensity()
		{
		}

		protected virtual TagParserBase[] GetExtraParsers()
		{
			return null;
		}

		private void ConvertText(string textToParse, ShowTextMode showTextMode)
		{
		}

		public void SetText(string text)
		{
		}

		public void SetText(string text, bool hideText)
		{
		}

		public void AppendText(string appendedText, bool hideText = false)
		{
		}

		private void SetTypewriterText(string text)
		{
		}

		public void SetVisibilityChar(int index, bool isVisible)
		{
		}

		public void SetVisibilityWord(int index, bool isVisible)
		{
		}

		public void SetVisibilityEntireText(bool isVisible, bool canPlayEffects = true)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void Animate(float deltaTime)
		{
		}

		private bool IsCharacterAppearing(int i)
		{
			return false;
		}

		private void ProcessAnimationRegions(AnimationRegion[] regions)
		{
		}

		private void AnimateText()
		{
		}

		public void ScheduleMeshRefresh()
		{
		}

		public void ForceDatabaseRefresh()
		{
		}

		public void SetBehaviorsActive(bool isCategoryEnabled)
		{
		}

		public void SetAppearancesActive(bool isCategoryEnabled)
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}

		public void ResetState()
		{
		}

		[Obsolete("Use TextAnimatorSettings.SetAllEffectsActive instead")]
		public static void EnableAllEffects(bool enabled)
		{
		}

		[Obsolete("Use TextAnimatorSettings.SetAppearancesActive instead")]
		public static void EnableAppearances(bool enabled)
		{
		}

		[Obsolete("Use TextAnimatorSettings.SetBehaviorsActive instead")]
		public static void EnableBehaviors(bool enabled)
		{
		}

		[Obsolete("Use SetAppearancesActive instead")]
		public void EnableAppearancesLocally(bool value)
		{
		}

		[Obsolete("Use SetBehaviorsActive instead")]
		public void EnableBehaviorsLocally(bool value)
		{
		}

		[Obsolete("Use SetVisibilityEntireText instead")]
		public void ShowAllCharacters(bool skipAppearanceEffects)
		{
		}

		[Obsolete("Use 'Animate' instead.")]
		public void UpdateEffects()
		{
		}

		[Obsolete("Events are not tied to TextAnimators anymore, but to their Typewriters. Please invoke 'TriggerRemainingEvents' on the Typewriter component instead.")]
		public void TriggerRemainingEvents()
		{
		}

		[Obsolete("Events are not tied to TextAnimators anymore, but to their related typewriters. Please invoke 'TriggerVisibleEvents' on the Typewriter component instead.")]
		public void TriggerVisibleEvents()
		{
		}

		[Obsolete("Use 'ScheduleMeshRefresh' instead")]
		public void ForceMeshRefresh()
		{
		}

		[Obsolete("To restart TextAnimator's time, please use 'time.RestartTime()'. To skip appearances effects please set 'SetVisibilityEntireText(true, false)' instead")]
		public void ResetEffectsTime(bool skipAppearances)
		{
		}
	}
}
