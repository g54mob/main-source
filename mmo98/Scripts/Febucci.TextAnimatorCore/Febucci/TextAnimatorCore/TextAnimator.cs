using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.Parsing.Core;
using Febucci.Parsing.Regions;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Styles;
using Febucci.TextAnimatorCore.Text;
using Febucci.TextAnimatorCore.Time;

namespace Febucci.TextAnimatorCore
{
	public class TextAnimator
	{
		private struct DefaultRegion<TPlayerType> where TPlayerType : IEffectPlayer
		{
			public readonly RegionParameters parameters;

			public TextRegion<TPlayerType> region;

			public DefaultRegion(string tagID, TPlayerType player, RegionParameters parameters)
			{
				this.parameters = parameters;
				region = new TextRegion<TPlayerType>(tagID, player);
			}
		}

		private CharacterData[] characters;

		private int charactersCount;

		private WordInfo[] words;

		private int wordsCount;

		public bool RequiresMeshUpdate;

		private readonly char closingTagSymbol;

		private int firstVisibleCharacter;

		private int maxVisibleCharacters;

		private readonly IEngineProvider engineProvider;

		internal readonly ITextGenerator textGenerator;

		public IDatabaseProvider<IEffect> effectsDatabase;

		public IDatabaseProvider<Style> stylesDatabase;

		private TimeData time;

		private ISettingsProvider<GlobalSettingsBase> globalSettingsProvider;

		private ISettingsProvider<AnimatorSettings> animatorSettingsProvider;

		private AnimatorSettings animatorSettings;

		private GlobalSettingsBase globalSettings;

		private readonly TextParser textParser;

		private TextRegion<IEffectPlayer>[] behaviorRegions;

		private TextRegion<IEffectPlayer>[] appearanceRegions;

		private TextRegion<IEffectPlayer>[] disappearanceRegions;

		private readonly BehaviorsParser parserBehaviors;

		private readonly AppearancesParser parserAppearances;

		private readonly AppearancesParser parserDisappearances;

		private readonly StylesParser parserStyles;

		private TagParserBase[] parsers;

		private readonly object caller;

		internal static readonly Func<string, IEffect, RegionParameters, IEffectPlayer> BehaviorPlayerFactory = delegate(string tagId, IEffect effect, RegionParameters parameters)
		{
			if (effect is IEffectManaged preset)
			{
				return new BehaviorsPlayer(tagId, preset, parameters);
			}
			if (effect is IEffectStateSync state)
			{
				return new DirectEffectPlayer(tagId, state, StateCategory.Behavior);
			}
			Logger.LogWarning($"Failed to create effect for {effect.GetType()} with tag {tagId}." + $" Not recognized. Must be either {typeof(IEffectManaged)} or {typeof(IEffectStateSync)}");
			return (IEffectPlayer)null;
		};

		internal static readonly Func<string, IEffect, RegionParameters, IEffectPlayer> AppearancePlayerFactory = delegate(string tagId, IEffect effect, RegionParameters parameters)
		{
			if (effect is IEffectManaged preset)
			{
				return new AppearancePlayer(tagId, preset, isBackwards: false, parameters);
			}
			if (effect is IEffectStateSync state)
			{
				return new DirectEffectPlayer(tagId, state, StateCategory.Appearing);
			}
			Logger.LogWarning($"Failed to create effect for {effect.GetType()} with tag {tagId}." + $" Not recognized. Must be either {typeof(IEffectManaged)} or {typeof(IEffectStateSync)}");
			return (IEffectPlayer)null;
		};

		internal static readonly Func<string, IEffect, RegionParameters, IEffectPlayer> DisappearancePlayerFactory = delegate(string tagId, IEffect effect, RegionParameters parameters)
		{
			if (effect is IEffectManaged preset)
			{
				return new AppearancePlayer(tagId, preset, isBackwards: true, parameters);
			}
			if (effect is IEffectStateSync state)
			{
				return new DirectEffectPlayer(tagId, state, StateCategory.Disappearing);
			}
			Logger.LogWarning($"Failed to create effect for {effect.GetType()} with tag {tagId}." + $" Not recognized. Must be either {typeof(IEffectManaged)} or {typeof(IEffectStateSync)}");
			return (IEffectPlayer)null;
		};

		private readonly bool isUpPositive;

		private AnimationContext animationContext;

		public TimeData Time => time;

		public CharacterData LatestCharacterShown { get; private set; }

		public CharacterData[] Characters => characters;

		public int CharactersCount
		{
			get
			{
				return charactersCount;
			}
			private set
			{
				charactersCount = value;
			}
		}

		public WordInfo[] Words => words;

		public int WordsCount => wordsCount;

		public string TextWithoutTextAnimatorTags { get; private set; }

		public string TextWithoutAnyTag { get; private set; }

		public string TextFull { get; private set; }

		public int FirstVisibleCharacter
		{
			get
			{
				return firstVisibleCharacter;
			}
			set
			{
				firstVisibleCharacter = value;
			}
		}

		public int MaxVisibleCharacters
		{
			get
			{
				return maxVisibleCharacters;
			}
			set
			{
				if (maxVisibleCharacters != value)
				{
					maxVisibleCharacters = value;
					if (maxVisibleCharacters < 0)
					{
						maxVisibleCharacters = 0;
					}
				}
			}
		}

		public bool AllLettersShown
		{
			get
			{
				if (maxVisibleCharacters < charactersCount)
				{
					return false;
				}
				if (firstVisibleCharacter == maxVisibleCharacters)
				{
					return false;
				}
				for (int i = 0; i < charactersCount; i++)
				{
					if (characters[i].isVisible)
					{
						if (characters[i].info.isRendered && characters[i].appearTime < characters[i].info.appearancesMaxDuration)
						{
							return false;
						}
					}
					else if (characters[i].disappearTime <= 0f)
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool AnyLetterVisible
		{
			get
			{
				if (charactersCount == 0)
				{
					return true;
				}
				if (IsCharacterAnyVisible(0) || IsCharacterAnyVisible(charactersCount - 1))
				{
					return true;
				}
				for (int i = 1; i < charactersCount - 1; i++)
				{
					if (IsCharacterAnyVisible(i))
					{
						return true;
					}
				}
				return false;
				bool IsCharacterAnyVisible(int index)
				{
					return characters[index].appearTime > 0f;
				}
			}
		}

		public ISettingsProvider<AnimatorSettings> LocalSettingsProvider
		{
			get
			{
				return animatorSettingsProvider;
			}
			set
			{
				if (animatorSettingsProvider != value)
				{
					animatorSettingsProvider = value;
					RefreshSettings();
				}
			}
		}

		public ISettingsProvider<GlobalSettingsBase> GlobalSettingsProvider
		{
			get
			{
				return globalSettingsProvider;
			}
			set
			{
				if (globalSettingsProvider != value)
				{
					globalSettingsProvider = value;
					RefreshSettings();
				}
			}
		}

		public TextRegion<IEffectPlayer>[] BehaviorRegions => behaviorRegions;

		public TextRegion<IEffectPlayer>[] AppearanceRegions => appearanceRegions;

		public TextRegion<IEffectPlayer>[] DisappearanceRegions => disappearanceRegions;

		public event Action OnTextParsed;

		public event Action<string> OnStartedParsing;

		public event Action OnDisposed;

		internal event Action<AnimatorSettings> OnPrepareForParsing;

		internal event Action OnTextParsedInternal;

		internal event Action<string> OnWantsToSetText;

		internal event Action<float> OnUpdate;

		private void RefreshSettings()
		{
			if (animatorSettingsProvider != null && animatorSettingsProvider.Settings != null)
			{
				animatorSettings = animatorSettingsProvider.Settings;
			}
			else
			{
				animatorSettings = new AnimatorSettings();
			}
			if (globalSettingsProvider != null && globalSettingsProvider.Settings != null)
			{
				globalSettings = globalSettingsProvider.Settings;
			}
			else
			{
				globalSettings = new FallbackGlobalSettings();
			}
			TextRegion<IEffectPlayer>[] array = behaviorRegions;
			foreach (TextRegion<IEffectPlayer> textRegion in array)
			{
				textRegion.data.InitializeOnce(isUpPositive, globalSettings);
			}
			TextRegion<IEffectPlayer>[] array2 = disappearanceRegions;
			foreach (TextRegion<IEffectPlayer> textRegion2 in array2)
			{
				textRegion2.data.InitializeOnce(isUpPositive, globalSettings);
			}
			TextRegion<IEffectPlayer>[] array3 = appearanceRegions;
			foreach (TextRegion<IEffectPlayer> textRegion3 in array3)
			{
				textRegion3.data.InitializeOnce(isUpPositive, globalSettings);
			}
		}

		internal void AddParsers(params TagParserBase[] extra)
		{
			HashSet<TagParserBase> hashSet = parsers.ToHashSet();
			foreach (TagParserBase item in extra)
			{
				hashSet.Add(item);
			}
			parsers = hashSet.ToArray();
		}

		internal void RemoveParsers(params TagParserBase[] extra)
		{
			HashSet<TagParserBase> hashSet = parsers.ToHashSet();
			foreach (TagParserBase item in extra)
			{
				hashSet.Remove(item);
			}
			parsers = hashSet.ToArray();
		}

		public TextAnimator(bool pasteNoParseTag, char openingBracket, char closingTagSymbol, char closingBracket, IEngineProvider engineProvider, ITextGenerator textGenerator, ISettingsProvider<AnimatorSettings> animatorSettingsProvider, ISettingsProvider<GlobalSettingsBase> globalSettingsProvider, bool isUpPositive, TagParserBase[] extraParsers = null, object caller = null)
		{
			time = default(TimeData);
			this.isUpPositive = isUpPositive;
			this.closingTagSymbol = closingTagSymbol;
			this.engineProvider = engineProvider;
			this.textGenerator = textGenerator;
			this.caller = caller;
			this.animatorSettingsProvider = animatorSettingsProvider;
			this.globalSettingsProvider = globalSettingsProvider;
			characters = new CharacterData[150];
			words = new WordInfo[150];
			charactersCount = 0;
			behaviorRegions = Array.Empty<TextRegion<IEffectPlayer>>();
			appearanceRegions = Array.Empty<TextRegion<IEffectPlayer>>();
			disappearanceRegions = Array.Empty<TextRegion<IEffectPlayer>>();
			textParser = new TextParser(pasteNoParseTag, openingBracket, closingBracket);
			parserBehaviors = new BehaviorsParser('<', '>', '\n', closingTagSymbol, null, isCaseSensitive: false);
			parserAppearances = new AppearancesParser(isBackwards: false, '{', '}', '\n', closingTagSymbol, null, isCaseSensitive: false);
			parserDisappearances = new AppearancesParser(isBackwards: true, '{', '}', '#', closingTagSymbol, null, isCaseSensitive: false);
			parserStyles = new StylesParser('<', '/', '>');
			if (extraParsers != null && extraParsers.Length != 0)
			{
				int num = extraParsers.Length;
				parsers = new TagParserBase[num + 3];
				for (int i = 0; i < num; i++)
				{
					parsers[i] = extraParsers[i];
				}
				parsers[num] = parserBehaviors;
				parsers[num + 1] = parserAppearances;
				parsers[num + 2] = parserDisappearances;
			}
			else
			{
				parsers = new TagParserBase[3] { parserBehaviors, parserAppearances, parserDisappearances };
			}
			TextFull = textGenerator.GetFullText();
		}

		private bool IsCharacterVisible(int i)
		{
			if (i >= firstVisibleCharacter && i < maxVisibleCharacters)
			{
				return characters[i].isVisible;
			}
			return false;
		}

		public void Dispose()
		{
			ClearRegionCallbacks();
			this.OnDisposed?.Invoke();
		}

		private void ClearRegionCallbacks()
		{
			if (behaviorRegions != null)
			{
				TextRegion<IEffectPlayer>[] array = behaviorRegions;
				foreach (TextRegion<IEffectPlayer> textRegion in array)
				{
					textRegion.data.Dispose();
				}
			}
			if (appearanceRegions != null)
			{
				TextRegion<IEffectPlayer>[] array2 = appearanceRegions;
				foreach (TextRegion<IEffectPlayer> textRegion2 in array2)
				{
					textRegion2.data.Dispose();
				}
			}
			if (disappearanceRegions != null)
			{
				TextRegion<IEffectPlayer>[] array3 = disappearanceRegions;
				foreach (TextRegion<IEffectPlayer> textRegion3 in array3)
				{
					textRegion3.data.Dispose();
				}
			}
		}

		public void SetText(string fullTextToParse, ShowTextMode showMode = ShowTextMode.Shown, bool? overrideResetTime = null)
		{
			if (textParser == null)
			{
				Logger.LogError("Text parser is null. Make sure Text Animator has been correctly initialized");
				return;
			}
			if (textGenerator == null)
			{
				Logger.LogError("Text generator is null. Make sure Text Animator has been correctly initialized");
				return;
			}
			ClearRegionCallbacks();
			RefreshSettings();
			TextFull = fullTextToParse;
			this.OnStartedParsing?.Invoke(fullTextToParse);
			AnimUtils.Initialize();
			if (string.IsNullOrEmpty(fullTextToParse))
			{
				fullTextToParse = string.Empty;
			}
			Dictionary<string, IEffect> totalEffects = new Dictionary<string, IEffect>();
			Dictionary<string, IEffect> dictionary = globalSettingsProvider?.Settings?.GlobalEffectsDatabase?.Database;
			Dictionary<string, IEffect> dictionary2 = effectsDatabase?.Database;
			if (dictionary2 != null)
			{
				foreach (KeyValuePair<string, IEffect> item in dictionary2)
				{
					item.Value?.Initialize();
					totalEffects.TryAdd(item.Key, item.Value);
				}
			}
			if (dictionary != null)
			{
				foreach (KeyValuePair<string, IEffect> item2 in dictionary)
				{
					item2.Value?.Initialize();
					totalEffects.TryAdd(item2.Key, item2.Value);
				}
			}
			UpdateParser<IEffectPlayer>(parserBehaviors, globalSettings.parsingBehaviors);
			UpdateParser<IEffectPlayer>(parserAppearances, globalSettings.parsingAppearances);
			UpdateParser<IEffectPlayer>(parserDisappearances, globalSettings.parsingDisappearances);
			this.OnPrepareForParsing?.Invoke(animatorSettings);
			TextWithoutTextAnimatorTags = fullTextToParse;
			parserStyles.OpeningBracket = globalSettings.parsingBehaviors.openingBracket;
			parserStyles.ClosingBracket = globalSettings.parsingBehaviors.closingBracket;
			if (stylesDatabase != null)
			{
				parserStyles.AssignLookup(stylesDatabase.Database);
				TextWithoutTextAnimatorTags = textParser.ParseText(TextWithoutTextAnimatorTags, parserStyles);
			}
			if (globalSettings.GlobalStyleSheet != null)
			{
				parserStyles.AssignLookup(globalSettings.GlobalStyleSheet.Database);
				TextWithoutTextAnimatorTags = textParser.ParseText(TextWithoutTextAnimatorTags, parserStyles);
			}
			TextWithoutTextAnimatorTags = textParser.ParseText(TextWithoutTextAnimatorTags, parsers);
			behaviorRegions = parserBehaviors.Results;
			appearanceRegions = parserAppearances.Results;
			disappearanceRegions = parserDisappearances.Results;
			textGenerator.SetTextToSource(TextWithoutTextAnimatorTags);
			TextWithoutAnyTag = textGenerator.GetStrippedTextWithoutAnyTags(TextWithoutTextAnimatorTags);
			CharactersCount = textGenerator.GetCharactersCount();
			if (totalEffects.Count > 0)
			{
				AddFallbackEffectsFor<IEffectPlayer>(ref behaviorRegions, animatorSettings.defaultEffectsMode, totalEffects, animatorSettings.defaultBehaviorTags, BehaviorPlayerFactory);
				AddFallbackEffectsFor<IEffectPlayer>(ref disappearanceRegions, animatorSettings.defaultEffectsMode, totalEffects, animatorSettings.defaultDisappearanceTags, DisappearancePlayerFactory);
				AddFallbackEffectsFor<IEffectPlayer>(ref appearanceRegions, animatorSettings.defaultEffectsMode, totalEffects, animatorSettings.defaultAppearanceTags, AppearancePlayerFactory);
			}
			TextRegion<IEffectPlayer>[] array = behaviorRegions;
			foreach (TextRegion<IEffectPlayer> textRegion in array)
			{
				textRegion.data.InitializeOnce(isUpPositive, globalSettings);
			}
			TextRegion<IEffectPlayer>[] array2 = disappearanceRegions;
			foreach (TextRegion<IEffectPlayer> textRegion2 in array2)
			{
				textRegion2.data.InitializeOnce(isUpPositive, globalSettings);
			}
			TextRegion<IEffectPlayer>[] array3 = appearanceRegions;
			foreach (TextRegion<IEffectPlayer> textRegion3 in array3)
			{
				textRegion3.data.InitializeOnce(isUpPositive, globalSettings);
			}
			PopulateCharacters(showMode != ShowTextMode.Refresh);
			textGenerator.CopyMeshFromSource(ref characters, charactersCount);
			CalculateWords();
			switch (showMode)
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
			maxVisibleCharacters = charactersCount;
			time.UpdateDeltaTime(engineProvider.GetCurrentDeltaTime(animatorSettings.timeScale));
			if ((overrideResetTime ?? animatorSettings.isResettingTimeOnNewText) && showMode != ShowTextMode.Refresh)
			{
				time.RestartTime();
			}
			this.OnTextParsedInternal?.Invoke();
			this.OnTextParsed?.Invoke();
			void AddFallbackEffectsFor<TPlayerType>(ref TextRegion<TPlayerType>[] currentEffects, DefaultEffectsMode defaultEffectsMode, Dictionary<string, IEffect> lookupMap, string[] defaultEffectsTags, Func<string, IEffect, RegionParameters, TPlayerType> playerFactory) where TPlayerType : IEffectPlayer
			{
				if (defaultEffectsTags != null && defaultEffectsTags.Length != 0)
				{
					List<DefaultRegion<TPlayerType>> list = new List<DefaultRegion<TPlayerType>>();
					foreach (string text in defaultEffectsTags)
					{
						if (!string.IsNullOrEmpty(text))
						{
							string[] array4 = text.Split(' ');
							string text2 = array4[0];
							if (lookupMap.TryGetValue(text2, out var value))
							{
								RegionParameters regionParameters = new RegionParameters(array4);
								TPlayerType val = playerFactory(text2, value, regionParameters);
								if (val == null)
								{
									Logger.LogWarning($"Effect of tag id {text} and type {value.GetType()} was not recognized. Skipping factory creation.");
								}
								else
								{
									list.Add(new DefaultRegion<TPlayerType>(text2, val, regionParameters));
								}
							}
						}
					}
					if (currentEffects.Length == 0 || defaultEffectsMode == DefaultEffectsMode.Constant)
					{
						foreach (DefaultRegion<TPlayerType> item3 in list)
						{
							item3.region.OpenNewRange(0, item3.parameters);
							item3.region.TryClosingRange(charactersCount);
						}
					}
					else
					{
						for (int m = 0; m < charactersCount; m++)
						{
							if (!currentEffects.DoesAnyRegionContainCharacter(m))
							{
								foreach (DefaultRegion<TPlayerType> item4 in list)
								{
									item4.region.OpenNewRange(m, item4.parameters);
								}
								int n;
								for (n = m + 1; n < charactersCount && !currentEffects.DoesAnyRegionContainCharacter(n); n++)
								{
								}
								foreach (DefaultRegion<TPlayerType> item5 in list)
								{
									item5.region.TryClosingRange(n);
								}
								m = n;
							}
						}
					}
					int num = currentEffects.Length;
					Array.Resize(ref currentEffects, currentEffects.Length + list.Count);
					for (int num2 = 0; num2 < list.Count; num2++)
					{
						currentEffects[num + num2] = list[num2].region;
					}
				}
			}
			void CalculateWords()
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (words.Length < CharactersCount)
				{
					Array.Resize(ref words, CharactersCount);
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int l = 0; l < CharactersCount; l++)
				{
					if (!char.IsWhiteSpace(characters[l].info.character))
					{
						characters[l].wordIndex = num2;
						stringBuilder.Append(characters[l].info.character);
						num++;
					}
					else
					{
						characters[l].wordIndex = -1;
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
				for (int l = 0; l < CharactersCount; l++)
				{
					HideCharacterTime(l);
				}
			}
			void HideCharacterTime(int charIndex)
			{
				CharacterData characterData = characters[charIndex];
				characterData.isVisible = false;
				characterData.Hide();
				characterData.appearTime = 0f;
				characterData.visibleTime = 0f;
				characterData.disappearTime = 0f;
				characters[charIndex] = characterData;
			}
			void PopulateCharacters(bool resetVisibility)
			{
				if (characters.Length < CharactersCount)
				{
					Array.Resize(ref characters, CharactersCount);
				}
				int l;
				for (l = 0; l < CharactersCount; l++)
				{
					characters[l].ResetInfo(l, resetVisibility);
					characters[l].info.disappearancesMaxDuration = CalculateRegionMaxDuration<IEffectPlayer>(disappearanceRegions);
					characters[l].info.appearancesMaxDuration = CalculateRegionMaxDuration<IEffectPlayer>(appearanceRegions);
				}
				float CalculateRegionMaxDuration<TPlayer>(TextRegion<TPlayer>[] tags) where TPlayer : IEffectPlayer
				{
					float num = 0f;
					foreach (TextRegion<TPlayer> textRegion4 in tags)
					{
						TagRange[] ranges = textRegion4.ranges;
						for (int n = 0; n < ranges.Length; n++)
						{
							TagRange tagRange = ranges[n];
							if (l >= tagRange.indexes.X && l < tagRange.indexes.Y)
							{
								float totalDuration = textRegion4.data.GetTotalDuration();
								if (totalDuration > num)
								{
									num = totalDuration;
								}
							}
						}
					}
					return num;
				}
			}
			void ShowCharacterTimes()
			{
				for (int l = 0; l < CharactersCount; l++)
				{
					CharacterData characterData = characters[l];
					characterData.isVisible = true;
					characterData.appearTime = characterData.info.appearancesMaxDuration;
					characterData.visibleTime = characterData.appearTime;
					characterData.disappearTime = 0f;
					characters[l] = characterData;
				}
			}
			void UpdateParser<TPlayerType>(EffectsParser<TPlayerType> parser, ParsingInfo parsingInfo) where TPlayerType : IEffectPlayer
			{
				if (parser != null)
				{
					parser.OpeningBracket = parsingInfo.openingBracket;
					parser.ClosingBracket = parsingInfo.closingBracket;
					parser.MiddleSymbol = parsingInfo.middleSymbol;
					parser.ClearLookup();
					parser.AssignLookup(totalEffects, additive: true);
				}
			}
		}

		[Conditional("DEBUG_TEXT_ANIMATOR")]
		private void DebugRegions<TPlayer>(TextRegion<TPlayer>[] regions, string title) where TPlayer : IEffectPlayer
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(title);
			stringBuilder.Append(" -> ");
			if (regions == null || regions.Length == 0)
			{
				stringBuilder.Append("EMPTY");
				return;
			}
			stringBuilder.Append("Count: ");
			stringBuilder.Append(regions.Length);
			for (int i = 0; i < regions.Length; i++)
			{
				stringBuilder.Append("\n- ");
				stringBuilder.Append(regions[i].ToString());
			}
		}

		public void AppendText(string appendedText, bool hideText = false)
		{
			if (string.IsNullOrEmpty(appendedText))
			{
				return;
			}
			if (charactersCount == 0)
			{
				SetText(appendedText, (!hideText) ? ShowTextMode.Shown : ShowTextMode.Hidden);
				return;
			}
			int num = maxVisibleCharacters;
			int num2 = firstVisibleCharacter;
			SetText(TextFull + appendedText, (!hideText) ? ShowTextMode.Shown : ShowTextMode.Hidden, false);
			firstVisibleCharacter = num2;
			for (int i = firstVisibleCharacter; i < num; i++)
			{
				characters[i].isVisible = true;
				characters[i].appearTime = characters[i].info.appearancesMaxDuration;
				characters[i].visibleTime = characters[i].appearTime;
				characters[i].disappearTime = 0f;
			}
			maxVisibleCharacters = charactersCount;
		}

		public void SwapText(string text)
		{
			int num = maxVisibleCharacters;
			SetText(text, ShowTextMode.Refresh);
			maxVisibleCharacters = num;
		}

		public void Animate()
		{
			if (engineProvider == null)
			{
				Logger.LogError("Engine provider is null. Skipping animation with automatic delta time.");
			}
			else
			{
				Animate(engineProvider.GetCurrentDeltaTime(animatorSettings.timeScale));
			}
		}

		public void Animate(float deltaTime)
		{
			if (textGenerator == null)
			{
				Logger.LogError("Text Generator is null. Unable to animate text.");
				return;
			}
			string fullText = textGenerator.GetFullText();
			if (string.IsNullOrEmpty(TextWithoutTextAnimatorTags) != string.IsNullOrEmpty(fullText) || (!string.IsNullOrEmpty(TextWithoutTextAnimatorTags) && !TextWithoutTextAnimatorTags.Equals(fullText)))
			{
				if (this.OnWantsToSetText == null)
				{
					SetText(fullText, ShowTextMode.UserTyping);
				}
				else
				{
					this.OnWantsToSetText(fullText);
				}
				return;
			}
			time.UpdateDeltaTime(deltaTime);
			time.IncreaseTime();
			animationContext = new AnimationContext(time.timeSinceStart, deltaTime);
			if (charactersCount == 0)
			{
				return;
			}
			for (int i = 0; i < charactersCount && i < characters.Length; i++)
			{
				ref CharacterData reference = ref characters[i];
				if (!reference.info.isRendered)
				{
					reference.appearTime = 0f;
					reference.disappearTime = 0f;
					reference.Hide();
					continue;
				}
				reference.ResetAnimation();
				if (IsCharacterVisible(i))
				{
					reference.visibleTime += deltaTime;
					reference.appearTime += deltaTime;
					if (reference.appearTime >= reference.info.appearancesMaxDuration)
					{
						reference.appearTime = reference.info.appearancesMaxDuration;
					}
					reference.disappearTime = reference.info.disappearancesMaxDuration;
				}
				else
				{
					reference.disappearTime -= deltaTime;
					reference.visibleTime += deltaTime;
					reference.appearTime = 0f;
					if (reference.disappearTime > reference.info.disappearancesMaxDuration)
					{
						reference.disappearTime = reference.info.disappearancesMaxDuration;
					}
					else if (reference.disappearTime <= 0f)
					{
						reference.disappearTime = 0f;
						reference.Hide();
						continue;
					}
				}
				if (animatorSettings.useDynamicScaling)
				{
					reference.UpdateIntensity(animatorSettings.referenceFontSize);
				}
				else
				{
					reference.uniformIntensity = 1f;
				}
			}
			if (globalSettings.isAnimatingBehaviors && animatorSettings.isAnimatingBehaviors)
			{
				ProcessAnimations<IEffectPlayer>(behaviorRegions);
			}
			if (globalSettings.isAnimatingAppearances && animatorSettings.isAnimatingAppearances)
			{
				ProcessAnimations<IEffectPlayer>(appearanceRegions);
			}
			if (globalSettings.isAnimatingDisappearances && animatorSettings.isAnimatingDisappearances)
			{
				ProcessAnimations<IEffectPlayer>(disappearanceRegions);
			}
			textGenerator.PasteMeshToSource(characters, charactersCount);
			if (RequiresMeshUpdate || textGenerator.HasChangedMeshRenderingSettings())
			{
				RequiresMeshUpdate = false;
				textGenerator.ForceMeshUpdate();
				textGenerator.CopyMeshFromSource(ref characters, charactersCount);
			}
			this.OnUpdate?.Invoke(deltaTime);
			void ProcessAnimations<TPlayer>(TextRegion<TPlayer>[] regions) where TPlayer : IEffectPlayer
			{
				foreach (TextRegion<TPlayer> textRegion in regions)
				{
					DirectEffectPlayer directEffectPlayer = textRegion.data as DirectEffectPlayer;
					bool flag = directEffectPlayer != null;
					for (int k = 0; k < textRegion.ranges.Length; k++)
					{
						TagRange tagRange = textRegion.ranges[k];
						if (flag)
						{
							directEffectPlayer.UpdateParameters(tagRange.parameters);
						}
						for (int l = tagRange.indexes.X; l < tagRange.indexes.Y && l < charactersCount; l++)
						{
							textRegion.data.Animate(ref characters[l], in animationContext);
						}
					}
				}
			}
		}

		public void SetVisibilityChar(int index, bool isVisible, bool canPlayEffects = true)
		{
			if (index < 0 || index >= charactersCount)
			{
				return;
			}
			characters[index].isVisible = isVisible;
			if (isVisible)
			{
				LatestCharacterShown = characters[index];
			}
			if (!canPlayEffects)
			{
				if (isVisible)
				{
					characters[index].disappearTime = 0f;
					characters[index].appearTime = characters[index].info.appearancesMaxDuration;
					characters[index].visibleTime = characters[index].info.appearancesMaxDuration;
				}
				else
				{
					characters[index].disappearTime = 0f;
					characters[index].appearTime = 0f;
					characters[index].visibleTime = 0f;
				}
			}
		}

		public void SetVisibilityWord(int index, bool isVisible, bool canPlayEffects = true)
		{
			if (index >= 0 && index < wordsCount)
			{
				WordInfo wordInfo = words[index];
				for (int i = Mathf.Max(wordInfo.firstCharacterIndex, 0); i <= wordInfo.lastCharacterIndex && i < charactersCount; i++)
				{
					SetVisibilityChar(i, isVisible, canPlayEffects);
				}
			}
		}

		public void SetVisibilityEntireText(bool isVisible, bool canPlayEffects = true)
		{
			for (int i = 0; i < charactersCount; i++)
			{
				SetVisibilityChar(i, isVisible, canPlayEffects);
			}
		}

		private void RefreshEffectState<TPlayer>(TextRegion<TPlayer> region) where TPlayer : IEffectPlayer
		{
			region.data.Refresh();
		}

		public void RefreshEffectState(string tagId)
		{
			if (!string.IsNullOrEmpty(tagId))
			{
				RefreshRegions<IEffectPlayer>(appearanceRegions);
				RefreshRegions<IEffectPlayer>(behaviorRegions);
				RefreshRegions<IEffectPlayer>(disappearanceRegions);
			}
			void RefreshRegions<TPlayer>(TextRegion<TPlayer>[] regions) where TPlayer : IEffectPlayer
			{
				if (regions != null)
				{
					foreach (TextRegion<TPlayer> textRegion in regions)
					{
						if (tagId.Equals(textRegion.tagId, StringComparison.InvariantCultureIgnoreCase))
						{
							RefreshEffectState(textRegion);
						}
					}
				}
			}
		}

		public void RefreshAllEffectStates()
		{
			TextRegion<IEffectPlayer>[] array = appearanceRegions;
			foreach (TextRegion<IEffectPlayer> region in array)
			{
				RefreshEffectState(region);
			}
			TextRegion<IEffectPlayer>[] array2 = behaviorRegions;
			foreach (TextRegion<IEffectPlayer> region2 in array2)
			{
				RefreshEffectState(region2);
			}
			TextRegion<IEffectPlayer>[] array3 = disappearanceRegions;
			foreach (TextRegion<IEffectPlayer> region3 in array3)
			{
				RefreshEffectState(region3);
			}
		}
	}
}
