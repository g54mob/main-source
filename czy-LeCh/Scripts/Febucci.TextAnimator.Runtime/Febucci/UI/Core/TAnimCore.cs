using System;
using System.Collections.Generic;
using System.Text;
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
				this.tagWords = tagWords;
				region = new AnimationRegion(tagID, visibilityMode, scriptable);
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

		[SerializeField]
		[TextArea(4, 10)]
		[HideInInspector]
		private string _text = string.Empty;

		private int charactersCount;

		private CharacterData[] characters;

		private int wordsCount;

		private WordInfo[] words;

		[Tooltip("True if you want the animations to be uniform/consistent across different font sizes. Default/Suggested to leave this as true, and change the 'Reference Font Size'.\nOtherwise, effects will move more when the text is smaller (requires less space on screen)")]
		public bool useDynamicScaling = true;

		[Tooltip("Font size that will be used as reference to keep animations consistent/uniform at different scales.")]
		public float referenceFontSize = 10f;

		[Tooltip("True if you want the animator's time to be reset on new text.")]
		[FormerlySerializedAs("isResettingEffectsOnNewText")]
		public bool isResettingTimeOnNewText = true;

		private bool isAnimatingBehaviors = true;

		private bool isAnimatingAppearances = true;

		[Tooltip("Lets you use the databases referenced in the 'TextAnimatorSettings' asset.\nSet to false if you'd like to specify which databases to use in this component.")]
		public bool useDefaultDatabases = true;

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
		private string[] defaultAppearancesTags = new string[1] { "size" };

		[SerializeField]
		private string[] defaultDisappearancesTags = new string[1] { "fade" };

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

		private TypewriterCore typewriter
		{
			get
			{
				if (_typewriterCache != null)
				{
					return _typewriterCache;
				}
				if (!TryGetComponent<TypewriterCore>(out _typewriterCache))
				{
					Debug.LogError("Typewriter component is null on GameObject " + base.gameObject.name + ". Please add a typewriter on the same GameObject or set 'Typewriter Starts Automatically' to false.", base.gameObject);
				}
				return _typewriterCache;
			}
		}

		public string textFull
		{
			get
			{
				return _text;
			}
			set
			{
				if (typewriterStartsAutomatically && (bool)typewriter)
				{
					SetTypewriterText(value);
				}
				else
				{
					SetText(value);
				}
			}
		}

		public string textWithoutTextAnimTags { get; private set; } = string.Empty;

		public string textWithoutAnyTag { get; private set; } = string.Empty;

		private bool hasText => charactersCount > 0;

		public CharacterData latestCharacterShown { get; private set; }

		public bool allLettersShown
		{
			get
			{
				if (_maxVisibleCharacters < charactersCount)
				{
					return false;
				}
				if (_firstVisibleCharacter == _maxVisibleCharacters)
				{
					return false;
				}
				for (int i = 0; i < charactersCount; i++)
				{
					if (!characters[i].isVisible)
					{
						if (characters[i].passedTime <= 0f)
						{
							return false;
						}
					}
					else if (characters[i].info.isRendered && characters[i].passedTime < characters[i].info.appearancesMaxDuration)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool anyLetterVisible
		{
			get
			{
				if (characters.Length == 0)
				{
					return true;
				}
				if (IsCharacterVisible(0) || IsCharacterVisible(charactersCount - 1))
				{
					return true;
				}
				for (int i = 1; i < charactersCount - 1; i++)
				{
					if (IsCharacterVisible(i))
					{
						return true;
					}
				}
				return false;
				bool IsCharacterVisible(int index)
				{
					return characters[index].passedTime > 0f;
				}
			}
		}

		public int CharactersCount => charactersCount;

		public CharacterData[] Characters => characters;

		public int WordsCount => wordsCount;

		public WordInfo[] Words => words;

		public AnimationsDatabase DatabaseBehaviors
		{
			get
			{
				if (!useDefaultDatabases)
				{
					return databaseBehaviors;
				}
				return TextAnimatorSettings.Instance.behaviors.defaultDatabase;
			}
			set
			{
				useDefaultDatabases = false;
				databaseBehaviors = value;
				requiresTagRefresh = true;
			}
		}

		public AnimationsDatabase DatabaseAppearances
		{
			get
			{
				if (!useDefaultDatabases)
				{
					return databaseAppearances;
				}
				return TextAnimatorSettings.Instance.appearances.defaultDatabase;
			}
			set
			{
				useDefaultDatabases = false;
				databaseAppearances = value;
				requiresTagRefresh = true;
			}
		}

		public AnimationRegion[] Behaviors
		{
			get
			{
				return behaviors;
			}
			set
			{
				behaviors = value;
			}
		}

		public AnimationRegion[] Appearances
		{
			get
			{
				return appearances;
			}
			set
			{
				appearances = value;
			}
		}

		public AnimationRegion[] Disappearances
		{
			get
			{
				return disappearances;
			}
			set
			{
				disappearances = value;
			}
		}

		public ActionMarker[] Actions
		{
			get
			{
				return actions;
			}
			set
			{
				actions = value;
			}
		}

		public ActionDatabase DatabaseActions
		{
			get
			{
				if (!useDefaultDatabases)
				{
					return databaseActions;
				}
				return TextAnimatorSettings.Instance.actions.defaultDatabase;
			}
			set
			{
				databaseActions = value;
				requiresTagRefresh = true;
			}
		}

		public EventMarker[] Events
		{
			get
			{
				return events;
			}
			set
			{
				events = value;
			}
		}

		public string[] DefaultAppearancesTags
		{
			get
			{
				return defaultAppearancesTags;
			}
			set
			{
				defaultAppearancesTags = value;
				requiresTagRefresh = true;
			}
		}

		public string[] DefaultDisappearancesTags
		{
			get
			{
				return defaultDisappearancesTags;
			}
			set
			{
				defaultDisappearancesTags = value;
				requiresTagRefresh = true;
			}
		}

		public string[] DefaultBehaviorsTags
		{
			get
			{
				return defaultBehaviorsTags;
			}
			set
			{
				defaultBehaviorsTags = value;
				requiresTagRefresh = true;
			}
		}

		public int firstVisibleCharacter
		{
			get
			{
				return _firstVisibleCharacter;
			}
			set
			{
				_firstVisibleCharacter = value;
			}
		}

		public int maxVisibleCharacters
		{
			get
			{
				return _maxVisibleCharacters;
			}
			set
			{
				if (_maxVisibleCharacters != value)
				{
					_maxVisibleCharacters = value;
					if (_maxVisibleCharacters < 0)
					{
						_maxVisibleCharacters = 0;
					}
				}
			}
		}

		[Obsolete("Please use 'isResettingTimeOnNewText' instead")]
		public bool isResettingEffectsOnNewText => isResettingTimeOnNewText;

		[Obsolete("Please use 'animationLoop' instead")]
		public AnimationLoop updateMode => animationLoop;

		[Obsolete("Events are now handled/stored by Typewriters instead.")]
		public MessageEvent onEvent => typewriter.onMessage;

		[Obsolete("Please use TextAnimatorSettings.Instance.appearances.enabled instead")]
		public static bool effectsAppearancesEnabled => TextAnimatorSettings.Instance.appearances.enabled;

		[Obsolete("Please use TextAnimatorSettings.Instance.behaviors.enabled instead")]
		public static bool effectsBehaviorsEnabled => TextAnimatorSettings.Instance.behaviors.enabled;

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
				referenceFontSize = value;
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
			requiresMeshUpdate = false;
			OnForceMeshUpdate();
		}

		private void Awake()
		{
			requiresTagRefresh = true;
			TryInitializing();
		}

		private void TryInitializing()
		{
			if (!initialized)
			{
				initialized = true;
				TextUtilities.Initialize();
				charactersCount = 0;
				characters = new CharacterData[0];
				wordsCount = 0;
				words = new WordInfo[0];
				behaviors = new AnimationRegion[0];
				appearances = new AnimationRegion[0];
				disappearances = new AnimationRegion[0];
				actions = new ActionMarker[0];
				events = new EventMarker[0];
				if ((bool)DatabaseActions)
				{
					DatabaseActions.ForceBuildRefresh();
				}
				if ((bool)DatabaseAppearances)
				{
					DatabaseAppearances.ForceBuildRefresh();
				}
				if ((bool)DatabaseBehaviors)
				{
					DatabaseBehaviors.ForceBuildRefresh();
				}
				OnInitialized();
			}
		}

		private void UpdateUniformIntensity()
		{
			if (useDynamicScaling)
			{
				for (int i = 0; i < characters.Length; i++)
				{
					characters[i].UpdateIntensity(referenceFontSize);
				}
			}
			else
			{
				for (int j = 0; j < characters.Length; j++)
				{
					characters[j].uniformIntensity = 1f;
				}
			}
		}

		protected virtual TagParserBase[] GetExtraParsers()
		{
			return Array.Empty<TagParserBase>();
		}

		private void ConvertText(string textToParse, ShowTextMode showTextMode)
		{
			TryInitializing();
			requiresTagRefresh = false;
			_text = textToParse;
			settings = TextAnimatorSettings.Instance;
			if (!settings)
			{
				charactersCount = 0;
				Debug.LogError("Text Animator Settings not found. Skipping setting the text to Text Animator.");
				return;
			}
			if (useDefaultDatabases)
			{
				databaseBehaviors = settings.behaviors.defaultDatabase;
				databaseAppearances = settings.appearances.defaultDatabase;
				databaseActions = settings.actions.defaultDatabase;
			}
			AnimationParser<AnimationScriptableBase> animationParser = new AnimationParser<AnimationScriptableBase>(settings.behaviors.openingSymbol, '/', settings.behaviors.closingSymbol, VisibilityMode.Persistent, databaseBehaviors);
			AnimationParser<AnimationScriptableBase> animationParser2 = new AnimationParser<AnimationScriptableBase>(settings.appearances.openingSymbol, '/', settings.appearances.closingSymbol, VisibilityMode.OnVisible, databaseAppearances);
			AnimationParser<AnimationScriptableBase> animationParser3 = new AnimationParser<AnimationScriptableBase>(settings.appearances.openingSymbol, '/', '#', settings.appearances.closingSymbol, VisibilityMode.OnHiding, databaseAppearances);
			ActionParser actionParser = new ActionParser(settings.actions.openingSymbol, '/', settings.actions.closingSymbol, databaseActions);
			EventParser eventParser = new EventParser('<', '/', '>');
			List<TagParserBase> list = new List<TagParserBase> { animationParser, animationParser2, animationParser3, actionParser, eventParser };
			TagParserBase[] extraParsers = GetExtraParsers();
			foreach (TagParserBase item in extraParsers)
			{
				list.Add(item);
			}
			textWithoutTextAnimTags = TextParser.ParseText(_text, list.ToArray());
			SetTextToSource(textWithoutTextAnimTags);
			textWithoutAnyTag = GetStrippedTextFromSource();
			charactersCount = GetCharactersCount();
			behaviors = animationParser.results;
			appearances = animationParser2.results;
			disappearances = animationParser3.results;
			actions = actionParser.results;
			events = eventParser.results;
			AddFallbackEffectsFor<AnimationScriptableBase>(ref behaviors, VisibilityMode.Persistent, databaseBehaviors, defaultBehaviorsTags);
			AddFallbackEffectsFor<AnimationScriptableBase>(ref appearances, VisibilityMode.OnVisible, databaseAppearances, defaultAppearancesTags);
			AddFallbackEffectsFor<AnimationScriptableBase>(ref disappearances, VisibilityMode.OnHiding, databaseAppearances, defaultDisappearancesTags);
			AnimationRegion[] array = behaviors;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].animation.InitializeOnce();
			}
			array = appearances;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].animation.InitializeOnce();
			}
			array = disappearances;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].animation.InitializeOnce();
			}
			PopulateCharacters();
			CopyMeshFromSource(ref characters);
			CalculateWords();
			switch (showTextMode)
			{
			case ShowTextMode.Hidden:
				HideAllCharactersTime();
				break;
			case ShowTextMode.Shown:
				ShowCharacterTimes();
				break;
			case ShowTextMode.UserTyping:
				ShowCharacterTimes();
				if (charactersCount > 1)
				{
					HideCharacterTime(charactersCount - 1);
					characters[charactersCount - 1].isVisible = true;
				}
				break;
			}
			_maxVisibleCharacters = charactersCount;
			time.UpdateDeltaTime((timeScale == TimeScale.Unscaled) ? Time.unscaledDeltaTime : Time.deltaTime);
			if (isResettingTimeOnNewText && showTextMode != ShowTextMode.Refresh)
			{
				time.RestartTime();
			}
			void AddFallbackEffectsFor<T>(ref AnimationRegion[] currentEffects, VisibilityMode visibilityMode, Database<T> database, string[] defaultEffectsTags) where T : AnimationScriptableBase
			{
				if ((bool)database && defaultEffectsTags != null && defaultEffectsTags.Length != 0)
				{
					List<DefaultRegion> list2 = new List<DefaultRegion>();
					foreach (string text in defaultEffectsTags)
					{
						if (string.IsNullOrEmpty(text))
						{
							if (Application.isPlaying)
							{
								Debug.LogError("Empty tag as default effect in database " + database.name + ". Skipping.", base.gameObject);
							}
						}
						else
						{
							string[] array2 = text.Split(' ');
							string text2 = array2[0];
							if (!database.ContainsKey(text2))
							{
								if (Application.isPlaying)
								{
									Debug.LogError("Fallback effect with tag '" + text2 + "' not found in database " + database.name + ". Skipping.", base.gameObject);
								}
							}
							else
							{
								list2.Add(new DefaultRegion(text2, visibilityMode, database[text2], array2));
							}
						}
					}
					if (currentEffects.Length == 0 || defaultTagsMode == DefaultTagsMode.Constant)
					{
						foreach (DefaultRegion item2 in list2)
						{
							item2.region.OpenNewRange(0, item2.tagWords);
						}
					}
					else
					{
						for (int k = 0; k < charactersCount; k++)
						{
							if (!IsCharacterInsideAnyEffect(k, currentEffects))
							{
								foreach (DefaultRegion item3 in list2)
								{
									item3.region.OpenNewRange(k, item3.tagWords);
								}
								int l;
								for (l = k + 1; l < charactersCount && !IsCharacterInsideAnyEffect(l, currentEffects); l++)
								{
								}
								foreach (DefaultRegion item4 in list2)
								{
									item4.region.TryClosingRange(l);
								}
								k = l;
							}
						}
					}
					int num = currentEffects.Length;
					Array.Resize(ref currentEffects, currentEffects.Length + list2.Count);
					for (int m = 0; m < list2.Count; m++)
					{
						currentEffects[num + m] = list2[m].region;
					}
				}
			}
			void CalculateWords()
			{
				StringBuilder stringBuilder = new StringBuilder();
				wordsCount = charactersCount;
				if (words.Length < wordsCount)
				{
					Array.Resize(ref words, wordsCount);
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int j = 0; j < charactersCount; j++)
				{
					if (!char.IsWhiteSpace(characters[j].info.character))
					{
						characters[j].wordIndex = num2;
						stringBuilder.Append(characters[j].info.character);
						num++;
					}
					else
					{
						characters[j].wordIndex = -1;
						if (num > 0)
						{
							words[num2] = new WordInfo(num3, num3 + num - 1, stringBuilder.ToString());
							num3 += num + 1;
							num2++;
						}
						else
						{
							num3++;
						}
						stringBuilder.Clear();
						num = 0;
					}
				}
				if (num > 0)
				{
					words[num2] = new WordInfo(num3, num3 + num - 1, stringBuilder.ToString());
					num2++;
				}
				wordsCount = num2;
			}
			void HideAllCharactersTime()
			{
				for (int j = 0; j < charactersCount; j++)
				{
					HideCharacterTime(j);
				}
			}
			void HideCharacterTime(int charIndex)
			{
				CharacterData characterData = characters[charIndex];
				characterData.isVisible = false;
				characterData.passedTime = 0f;
				characterData.Hide();
				characters[charIndex] = characterData;
			}
			static bool IsCharacterInsideAnyEffect(int charIndex, AnimationRegion[] regions)
			{
				for (int j = 0; j < regions.Length; j++)
				{
					TagRange[] ranges = regions[j].ranges;
					for (int k = 0; k < ranges.Length; k++)
					{
						TagRange tagRange = ranges[k];
						Vector2Int indexes = tagRange.indexes;
						if (charIndex >= indexes.x)
						{
							indexes = tagRange.indexes;
							if (indexes.y != int.MaxValue)
							{
								indexes = tagRange.indexes;
								if (charIndex >= indexes.y)
								{
									continue;
								}
							}
							return true;
						}
					}
				}
				return false;
			}
			void PopulateCharacters()
			{
				if (characters.Length < charactersCount)
				{
					Array.Resize(ref characters, charactersCount);
				}
				int j;
				for (j = 0; j < charactersCount; j++)
				{
					characters[j].ResetInfo(j);
					characters[j].info.disappearancesMaxDuration = CalculateRegionMaxDuration(disappearances);
					characters[j].info.appearancesMaxDuration = CalculateRegionMaxDuration(appearances);
				}
				float CalculateRegionMaxDuration(AnimationRegion[] tags)
				{
					float num = 0f;
					foreach (AnimationRegion animationRegion in tags)
					{
						TagRange[] ranges = animationRegion.ranges;
						for (int l = 0; l < ranges.Length; l++)
						{
							TagRange tagRange = ranges[l];
							int num2 = j;
							Vector2Int indexes = tagRange.indexes;
							if (num2 >= indexes.x)
							{
								int num3 = j;
								indexes = tagRange.indexes;
								if (num3 < indexes.y)
								{
									animationRegion.SetupContextFor(this, tagRange.modifiers);
									float maxDuration = animationRegion.animation.GetMaxDuration();
									if (maxDuration > num)
									{
										num = maxDuration;
									}
								}
							}
						}
					}
					return num;
				}
			}
			void ShowCharacterTimes()
			{
				for (int j = 0; j < charactersCount; j++)
				{
					CharacterData characterData = characters[j];
					characterData.isVisible = true;
					characterData.passedTime = characterData.info.appearancesMaxDuration;
					characters[j] = characterData;
				}
			}
		}

		public void SetText(string text)
		{
			ConvertText(text, ShowTextMode.Shown);
		}

		public void SetText(string text, bool hideText)
		{
			ConvertText(text, (!hideText) ? ShowTextMode.Shown : ShowTextMode.Hidden);
		}

		public void AppendText(string appendedText, bool hideText = false)
		{
			if (string.IsNullOrEmpty(appendedText))
			{
				return;
			}
			if (!hasText)
			{
				SetText(appendedText, hideText);
				return;
			}
			bool flag = isResettingTimeOnNewText;
			isResettingTimeOnNewText = false;
			int num = maxVisibleCharacters;
			int num2 = firstVisibleCharacter;
			SetText(textFull + appendedText, hideText);
			isResettingTimeOnNewText = flag;
			maxVisibleCharacters = num;
			firstVisibleCharacter = num2;
			for (int i = firstVisibleCharacter; i < maxVisibleCharacters; i++)
			{
				characters[i].isVisible = true;
				characters[i].passedTime = characters[i].info.appearancesMaxDuration;
			}
		}

		private void SetTypewriterText(string text)
		{
			if (text.Length <= 0)
			{
				typewriter.ShowText("");
			}
			else
			{
				typewriter.ShowText("<noparse></noparse>" + text);
			}
		}

		public void SetVisibilityChar(int index, bool isVisible)
		{
			if (index >= 0 && index < charactersCount)
			{
				characters[index].isVisible = isVisible;
				if (isVisible)
				{
					latestCharacterShown = characters[index];
				}
			}
		}

		public void SetVisibilityWord(int index, bool isVisible)
		{
			if (index >= 0 && index < wordsCount)
			{
				WordInfo wordInfo = words[index];
				for (int i = Mathf.Max(wordInfo.firstCharacterIndex, 0); i <= wordInfo.lastCharacterIndex && i < charactersCount; i++)
				{
					SetVisibilityChar(i, isVisible);
				}
			}
		}

		public void SetVisibilityEntireText(bool isVisible, bool canPlayEffects = true)
		{
			for (int i = 0; i < charactersCount; i++)
			{
				SetVisibilityChar(i, isVisible);
			}
			if (canPlayEffects)
			{
				return;
			}
			if (isVisible)
			{
				for (int j = 0; j < charactersCount; j++)
				{
					characters[j].passedTime = characters[j].info.appearancesMaxDuration;
				}
			}
			else
			{
				for (int k = 0; k < charactersCount; k++)
				{
					characters[k].passedTime = 0f;
				}
			}
		}

		private void Update()
		{
			if (!IsReady())
			{
				return;
			}
			if (HasChangedText(textWithoutTextAnimTags))
			{
				if (typewriterStartsAutomatically && (bool)typewriter)
				{
					SetTypewriterText(GetOriginalTextFromSource());
				}
				else
				{
					ConvertText(GetOriginalTextFromSource(), ShowTextMode.UserTyping);
				}
			}
			else if (animationLoop == AnimationLoop.Update)
			{
				Animate((timeScale == TimeScale.Unscaled) ? Time.unscaledDeltaTime : Time.deltaTime);
			}
		}

		private void LateUpdate()
		{
			if (animationLoop == AnimationLoop.LateUpdate)
			{
				Animate((timeScale == TimeScale.Unscaled) ? Time.unscaledDeltaTime : Time.deltaTime);
			}
		}

		protected abstract bool IsReady();

		public void Animate(float deltaTime)
		{
			if (IsReady())
			{
				if (requiresTagRefresh)
				{
					ConvertText(_text, ShowTextMode.Refresh);
				}
				time.UpdateDeltaTime(deltaTime);
				time.IncreaseTime();
				AnimateText();
			}
		}

		private bool IsCharacterAppearing(int i)
		{
			if (i >= _firstVisibleCharacter && i < _maxVisibleCharacters)
			{
				return characters[i].isVisible;
			}
			return false;
		}

		private void ProcessAnimationRegions(AnimationRegion[] regions)
		{
			foreach (AnimationRegion animationRegion in regions)
			{
				TagRange[] ranges = animationRegion.ranges;
				for (int j = 0; j < ranges.Length; j++)
				{
					TagRange tagRange = ranges[j];
					animationRegion.SetupContextFor(this, tagRange.modifiers);
					Vector2Int indexes = tagRange.indexes;
					int num = indexes.x;
					while (true)
					{
						int num2 = num;
						indexes = tagRange.indexes;
						if (num2 >= indexes.y || num >= charactersCount)
						{
							break;
						}
						if (!(characters[num].passedTime <= 0f) && animationRegion.IsVisibilityPolicySatisfied(IsCharacterAppearing(num)) && animationRegion.animation.CanApplyEffectTo(characters[num], this))
						{
							animationRegion.animation.ApplyEffectTo(ref characters[num], this);
						}
						num++;
					}
				}
			}
		}

		private void AnimateText()
		{
			if (!hasText)
			{
				return;
			}
			TryInitializing();
			for (int i = 0; i < charactersCount && i < characters.Length; i++)
			{
				if (!characters[i].info.isRendered)
				{
					characters[i].passedTime = 0f;
					characters[i].Hide();
					continue;
				}
				characters[i].ResetAnimation();
				if (IsCharacterAppearing(i))
				{
					characters[i].passedTime += time.deltaTime;
					continue;
				}
				if (characters[i].passedTime > characters[i].info.disappearancesMaxDuration)
				{
					characters[i].passedTime = characters[i].info.disappearancesMaxDuration;
				}
				else
				{
					characters[i].passedTime -= time.deltaTime;
				}
				if (characters[i].passedTime <= 0f)
				{
					characters[i].passedTime = 0f;
					characters[i].Hide();
				}
			}
			UpdateUniformIntensity();
			if (isAnimatingBehaviors && settings.behaviors.enabled)
			{
				ProcessAnimationRegions(behaviors);
			}
			if (isAnimatingAppearances && settings.appearances.enabled)
			{
				ProcessAnimationRegions(appearances);
				ProcessAnimationRegions(disappearances);
			}
			PasteMeshToSource(characters);
			if (requiresMeshUpdate || HasChangedRenderingSettings())
			{
				ForceMeshUpdate();
				CopyMeshFromSource(ref characters);
			}
		}

		public void ScheduleMeshRefresh()
		{
			requiresMeshUpdate = true;
		}

		public void ForceDatabaseRefresh()
		{
			if ((bool)DatabaseActions)
			{
				DatabaseActions.ForceBuildRefresh();
			}
			if ((bool)DatabaseAppearances)
			{
				DatabaseAppearances.ForceBuildRefresh();
			}
			if ((bool)DatabaseBehaviors)
			{
				DatabaseBehaviors.ForceBuildRefresh();
			}
			ConvertText(GetOriginalTextFromSource(), ShowTextMode.Refresh);
		}

		public void SetBehaviorsActive(bool isCategoryEnabled)
		{
			isAnimatingBehaviors = isCategoryEnabled;
		}

		public void SetAppearancesActive(bool isCategoryEnabled)
		{
			isAnimatingAppearances = isCategoryEnabled;
		}

		protected virtual void OnEnable()
		{
			requiresMeshUpdate = true;
			AnimateText();
		}

		public void ResetState()
		{
			_text = string.Empty;
			textWithoutTextAnimTags = string.Empty;
			textWithoutAnyTag = string.Empty;
			charactersCount = 0;
			wordsCount = 0;
			initialized = false;
			TryInitializing();
		}

		[Obsolete("Use TextAnimatorSettings.SetAllEffectsActive instead")]
		public static void EnableAllEffects(bool enabled)
		{
			TextAnimatorSettings.SetAllEffectsActive(enabled);
		}

		[Obsolete("Use TextAnimatorSettings.SetAppearancesActive instead")]
		public static void EnableAppearances(bool enabled)
		{
			TextAnimatorSettings.SetAppearancesActive(enabled);
		}

		[Obsolete("Use TextAnimatorSettings.SetBehaviorsActive instead")]
		public static void EnableBehaviors(bool enabled)
		{
			TextAnimatorSettings.SetBehaviorsActive(enabled);
		}

		[Obsolete("Use SetAppearancesActive instead")]
		public void EnableAppearancesLocally(bool value)
		{
			SetAppearancesActive(value);
		}

		[Obsolete("Use SetBehaviorsActive instead")]
		public void EnableBehaviorsLocally(bool value)
		{
			SetBehaviorsActive(value);
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

		[Obsolete("Events are not tied to TextAnimators anymore, but to their Typewriters. Please invoke 'TriggerRemainingEvents' on the Typewriter component instead.")]
		public void TriggerRemainingEvents()
		{
			if ((bool)typewriter)
			{
				typewriter.TriggerRemainingEvents();
			}
		}

		[Obsolete("Events are not tied to TextAnimators anymore, but to their related typewriters. Please invoke 'TriggerVisibleEvents' on the Typewriter component instead.")]
		public void TriggerVisibleEvents()
		{
			if ((bool)typewriter)
			{
				typewriter.TriggerVisibleEvents();
			}
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
