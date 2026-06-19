using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Components.Writer;
using TMPEffects.Databases;
using TMPEffects.Databases.CommandDatabase;
using TMPEffects.EffectCategories;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPCommands;
using TMPEffects.TMPEvents;
using TMPEffects.Tags;
using TMPEffects.Tags.Collections;
using TMPEffects.TextProcessing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TMPEffects.Components
{
	[HelpURL("https://tmpeffects.luca3317.dev/manual/tmpwriter.html")]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TMP_Text))]
	public class TMPWriter : TMPEffectComponent
	{
		public enum DelayType
		{
			Percentage = 0,
			Raw = 1
		}

		[Serializable]
		public class Delays
		{
			public float delay = 0.035f;

			public float whitespaceDelay;

			public DelayType whitespaceDelayType;

			public float linebreakDelay;

			public DelayType linebreakDelayType;

			public float punctuationDelay;

			public DelayType punctuationDelayType;

			public float visibleDelay;

			public DelayType visibleDelayType;

			public float CalculatedWhiteSpaceDelay
			{
				get
				{
					if (whitespaceDelayType != DelayType.Raw)
					{
						return delay * whitespaceDelay;
					}
					return whitespaceDelay;
				}
			}

			public float CalculatedPunctuationDelay
			{
				get
				{
					if (punctuationDelayType != DelayType.Raw)
					{
						return delay * punctuationDelay;
					}
					return punctuationDelay;
				}
			}

			public float CalculatedVisibleDelay
			{
				get
				{
					if (visibleDelayType != DelayType.Raw)
					{
						return delay * visibleDelay;
					}
					return visibleDelay;
				}
			}

			public float CalculatedLinebreakDelay
			{
				get
				{
					if (linebreakDelayType != DelayType.Raw)
					{
						return delay * linebreakDelay;
					}
					return linebreakDelay;
				}
			}

			public void SetDelay(float delay)
			{
				this.delay = delay;
			}

			public void SetWhitespaceDelay(float delay, DelayType? type = null)
			{
				whitespaceDelay = delay;
				if (type.HasValue)
				{
					whitespaceDelayType = type.Value;
				}
			}

			public void SetLinebreakDelay(float delay, DelayType? type = null)
			{
				linebreakDelay = delay;
				if (type.HasValue)
				{
					linebreakDelayType = type.Value;
				}
			}

			public void SetVisibleDelay(float delay, DelayType? type = null)
			{
				visibleDelay = delay;
				if (type.HasValue)
				{
					visibleDelayType = type.Value;
				}
			}

			public void SetPunctuationDelay(float delay, DelayType? type = null)
			{
				punctuationDelay = delay;
				if (type.HasValue)
				{
					punctuationDelayType = type.Value;
				}
			}
		}

		public TMPEvent OnTextEvent;

		public UnityEvent<TMPWriter, CharData> OnCharacterShown;

		public UnityEvent<TMPWriter> OnStartWriter;

		public UnityEvent<TMPWriter> OnStopWriter;

		public UnityEvent<TMPWriter, float> OnWaitStarted;

		public UnityEvent<TMPWriter> OnWaitEnded;

		public UnityEvent<TMPWriter> OnFinishWriter;

		public UnityEvent<TMPWriter, int> OnSkipWriter;

		public UnityEvent<TMPWriter, int> OnResetWriter;

		public const char COMMAND_PREFIX = '!';

		public const char EVENT_PREFIX = '?';

		[SerializeField]
		private TMPKeywordDatabaseBase keywordDatabase;

		[SerializeField]
		private TMPSceneKeywordDatabaseBase sceneKeywordDatabase;

		[SerializeField]
		private TMPCommandDatabase database;

		[SerializeField]
		private bool maySkip = true;

		[SerializeField]
		private bool writeOnStart = true;

		[SerializeField]
		private bool writeOnNewText = true;

		[SerializeField]
		private bool useScaledTime = true;

		[SerializeField]
		private Delays delays = new Delays();

		[SerializeField]
		private SerializedDictionary<string, TMPSceneCommandWrapper> sceneCommands;

		[NonSerialized]
		private TagProcessorManager processors;

		[NonSerialized]
		private TagCollectionManager<TMPEffectCategory> tags;

		[NonSerialized]
		private TMPCommandCategory commandCategory;

		[NonSerialized]
		private TMPEventCategory eventCategory;

		[NonSerialized]
		private KeywordDatabaseWrapper keywordDatabaseWrapper;

		[NonSerialized]
		private CommandDatabase commandDatabase;

		[NonSerialized]
		private CachedCollection<CachedCommand> commands;

		[NonSerialized]
		private CachedCollection<CachedEvent> events;

		[NonSerialized]
		private Coroutine writerCoroutine;

		[NonSerialized]
		private bool currentMaySkip;

		[NonSerialized]
		private Delays currentDelays;

		[NonSerialized]
		private bool shouldWait;

		[NonSerialized]
		private float waitAmount;

		[NonSerialized]
		private Func<bool> continueConditions;

		[NonSerialized]
		private bool writing;

		[NonSerialized]
		private int currentIndex = -1;

		[NonSerialized]
		private bool tagsChanged;

		public bool IsWriting => writing;

		public bool MaySkip => currentMaySkip;

		public int CurrentIndex => currentIndex;

		public TMPCommandDatabase Database => database;

		public ITMPKeywordDatabase KeywordDatabase => keywordDatabaseWrapper?.Database;

		public IDictionary<string, TMPSceneCommandWrapper> SceneCommands => sceneCommands;

		public ITagCollection Tags => tags;

		public ITagCollection CommandTags
		{
			get
			{
				if (tags != null)
				{
					return tags[commandCategory];
				}
				return null;
			}
		}

		public ITagCollection EventTags
		{
			get
			{
				if (tags != null)
				{
					return tags[eventCategory];
				}
				return null;
			}
		}

		public bool WriteOnStart
		{
			get
			{
				return writeOnStart;
			}
			set
			{
				writeOnStart = value;
			}
		}

		public bool WriteOnNewText
		{
			get
			{
				return writeOnNewText;
			}
			set
			{
				writeOnNewText = value;
			}
		}

		public bool UseScaledTime
		{
			get
			{
				return useScaledTime;
			}
			set
			{
				useScaledTime = value;
			}
		}

		public Delays DefaultDelays => delays;

		public Delays CurrentDelays => currentDelays;

		public void StartWriter()
		{
			if (base.Mediator == null)
			{
				Debug.LogWarning("The TMPWriter component on " + base.gameObject.name + " is not enabled");
			}
			else if (!writing)
			{
				RaiseStartWriterEvent();
				StartWriterCoroutine();
			}
		}

		public void StopWriter()
		{
			if (base.Mediator == null)
			{
				Debug.LogWarning("The TMPWriter component on " + base.gameObject.name + " is not enabled");
			}
			else if (writing)
			{
				StopWriterCoroutine();
				RaiseStopWriterEvent();
			}
		}

		public void ResetWriter()
		{
			if (base.Mediator == null)
			{
				Debug.LogWarning("The TMPWriter component on " + base.gameObject.name + " is not enabled");
				return;
			}
			ResetInternalState();
			Hide(0, base.Mediator.CharData.Count, skipHideProcess: true);
			RaiseResetWriterEvent(0);
		}

		public void ResetWriter(int index)
		{
			if (base.Mediator == null)
			{
				Debug.LogWarning("The TMPWriter component on " + base.gameObject.name + " is not enabled");
				return;
			}
			if (index >= currentIndex)
			{
				Debug.LogWarning($"Can't reset the TMPWriter on {base.gameObject.name} to index {index}; current index is only {currentIndex}");
				return;
			}
			if (writing)
			{
				StopWriterCoroutine();
			}
			ResetData();
			Hide(0, base.Mediator.CharData.Count, skipHideProcess: true);
			Show(0, index, skipShowProcess: true);
			ResetInvokables(currentIndex);
			for (int i = -1; i < index; i++)
			{
				RaiseInvokables(i);
			}
			currentIndex = index;
			RaiseResetWriterEvent(index);
		}

		public void SkipWriter(bool skipShowAnimation = true)
		{
			if (base.Mediator == null)
			{
				Debug.LogWarning("The TMPWriter component on " + base.gameObject.name + " is not enabled");
				return;
			}
			if (!currentMaySkip)
			{
				Debug.LogWarning("The TMPWriter component on " + base.gameObject.name + " may not skip at the current index");
				return;
			}
			int num = commands.FirstOrDefault((CachedCommand x) => x.Indices.StartIndex >= currentIndex && x.Tag.Name == "skippable" && x.Tag.Parameters != null && x.Tag.Parameters[""] == "false")?.Indices.StartIndex ?? base.Mediator.CharData.Count;
			RaiseSkipWriterEvent(num);
			for (int num2 = currentIndex; num2 < num; num2++)
			{
				RaiseInvokables(num2, skipped: true);
			}
			currentIndex = num;
			Show(0, num, skipShowAnimation);
			if (num == base.Mediator.CharData.Count)
			{
				if (writing)
				{
					StopWriterCoroutine();
				}
				RaiseFinishWriterEvent();
			}
		}

		public void RestartWriter()
		{
			if (base.Mediator == null)
			{
				Debug.LogWarning("The TMPWriter component on " + base.gameObject.name + " is not enabled");
				return;
			}
			ResetWriter();
			StartWriter();
		}

		public void Wait(float seconds)
		{
			if (seconds < 0f)
			{
				throw new ArgumentOutOfRangeException("Seconds was negative");
			}
			if (shouldWait)
			{
				waitAmount = Mathf.Max(waitAmount, seconds);
				return;
			}
			shouldWait = true;
			waitAmount = seconds;
		}

		public void ResetWaitPeriod()
		{
			shouldWait = false;
			waitAmount = 0f;
		}

		public void WaitUntil(Func<bool> condition)
		{
			if (condition != null)
			{
				continueConditions = (Func<bool>)Delegate.Remove(continueConditions, condition);
				continueConditions = (Func<bool>)Delegate.Combine(continueConditions, condition);
			}
		}

		public void ResetWaitConditions()
		{
			continueConditions = null;
		}

		public void SetSkippable(bool skippable)
		{
			currentMaySkip = skippable;
		}

		public void SetDatabase(TMPCommandDatabase database)
		{
			this.database = database;
			OnDatabaseChanged();
		}

		public void SetSceneKeywordDatabase(TMPSceneKeywordDatabase database)
		{
			sceneKeywordDatabase = database;
			OnDatabaseChanged();
		}

		public void SetKeywordDatabase(TMPKeywordDatabase database)
		{
			keywordDatabase = database;
			OnDatabaseChanged();
		}

		private void OnEnable()
		{
			UpdateMediator();
			SubscribeToMediator();
			PrepareForProcessing();
			if (database != null)
			{
				database.ObjectChanged += ReprocessOnDatabaseChange;
			}
			base.Mediator.ForceReprocess();
		}

		private void Start()
		{
			if (writeOnStart)
			{
				StartWriter();
			}
		}

		private void OnDisable()
		{
			processors.UnregisterFrom(base.Mediator.Processor);
			commandDatabase?.Dispose();
			keywordDatabaseWrapper?.Dispose();
			UnsubscribeFromMediator();
			StopWriterCoroutine();
			currentIndex = -1;
			Show(0, base.Mediator.CharData.Count, skipShowProcess: true);
			writing = false;
			TMP_Text tMP_Text = base.Mediator.Text;
			FreeMediator();
			if (tMP_Text != null)
			{
				tMP_Text.ForceMeshUpdate(ignoreActiveState: false, forceTextReparsing: true);
			}
		}

		private void PrepareForProcessing()
		{
			commandDatabase?.Dispose();
			keywordDatabaseWrapper?.Dispose();
			commandDatabase = new CommandDatabase((database == null) ? null : database, sceneCommands);
			keywordDatabaseWrapper = new KeywordDatabaseWrapper(sceneKeywordDatabase, keywordDatabase, TMPEffectsSettings.GlobalKeywordDatabase);
			commandDatabase.ObjectChanged += ReprocessOnDatabaseChange;
			keywordDatabaseWrapper.ObjectChanged += ReprocessOnDatabaseChange;
			commandCategory = new TMPCommandCategory('!', commandDatabase, keywordDatabaseWrapper.Database);
			eventCategory = new TMPEventCategory('?');
			if (processors == null)
			{
				processors = new TagProcessorManager();
			}
			processors.UnregisterFrom(base.Mediator.Processor);
			processors.Clear();
			processors.AddProcessor(commandCategory.Prefix, new TagProcessor(commandCategory));
			processors.AddProcessor(eventCategory.Prefix, new TagProcessor(eventCategory));
			processors.RegisterTo(base.Mediator.Processor);
		}

		private void SubscribeToMediator()
		{
			base.Mediator.TextChanged_Late += OnTextChanged_Late;
			base.Mediator.TextChanged_Early += OnTextChanged_Early;
		}

		private void UnsubscribeFromMediator()
		{
			base.Mediator.TextChanged_Late -= OnTextChanged_Late;
			base.Mediator.TextChanged_Early -= OnTextChanged_Early;
		}

		private void OnDatabaseChanged()
		{
			PrepareForProcessing();
			base.Mediator.ForceReprocess();
		}

		private void ReprocessOnDatabaseChange(object sender)
		{
			PrepareForProcessing();
			base.Mediator.ForceReprocess();
		}

		private void OnTextChanged_Early(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData)
		{
			tagsChanged = tags == null;
			if (!textContentChanged && tags != null)
			{
				tagsChanged = true;
				IEnumerable<TMPEffectTagTuple> first;
				if (!tags.ContainsKey(commandCategory))
				{
					first = Enumerable.Empty<TMPEffectTagTuple>();
				}
				else
				{
					IEnumerable<TMPEffectTagTuple> commandTags = CommandTags;
					first = commandTags;
				}
				IEnumerable<TMPEffectTagTuple> second = from tag in processors.TagProcessors[commandCategory.Prefix].SelectMany((TagProcessor processed) => processed.ProcessedTags)
					select new TMPEffectTagTuple(tag.Value, tag.Key);
				if (first.SequenceEqual(second))
				{
					IEnumerable<TMPEffectTagTuple> first2;
					if (!tags.ContainsKey(eventCategory))
					{
						first2 = Enumerable.Empty<TMPEffectTagTuple>();
					}
					else
					{
						IEnumerable<TMPEffectTagTuple> commandTags = EventTags;
						first2 = commandTags;
					}
					second = from tag in processors.TagProcessors[eventCategory.Prefix].SelectMany((TagProcessor processed) => processed.ProcessedTags)
						select new TMPEffectTagTuple(tag.Value, tag.Key);
					if (first2.SequenceEqual(second))
					{
						tagsChanged = false;
					}
				}
			}
			PostProcessTags();
		}

		private void OnTextChanged_Late(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData, ReadOnlyCollection<VisibilityState> oldVisibilities)
		{
			if (textContentChanged || tagsChanged)
			{
				bool num = writing;
				ResetWriter();
				if (num || writeOnNewText)
				{
					StartWriter();
				}
			}
		}

		private void RaiseCharacterShownEvent(CharData cData)
		{
			OnCharacterShown?.Invoke(this, cData);
		}

		private void RaiseResetWriterEvent(int index)
		{
			OnResetWriter?.Invoke(this, index);
		}

		private void RaiseFinishWriterEvent()
		{
			OnFinishWriter?.Invoke(this);
		}

		private void RaiseStartWriterEvent()
		{
			OnStartWriter?.Invoke(this);
		}

		private void RaiseStopWriterEvent()
		{
			OnStopWriter?.Invoke(this);
		}

		private void RaiseWaitStartedEvent(float waitAmount)
		{
			OnWaitStarted?.Invoke(this, waitAmount);
		}

		private void RaiseWaitEndedEvent()
		{
			OnWaitEnded?.Invoke(this);
		}

		private void RaiseSkipWriterEvent(int index)
		{
			OnSkipWriter?.Invoke(this, index);
		}

		private void StartWriterCoroutine()
		{
			if (base.TextComponent.enabled)
			{
				StopWriterCoroutine();
				writerCoroutine = StartCoroutine(WriterCoroutine());
			}
		}

		private void StopWriterCoroutine()
		{
			if (writerCoroutine != null)
			{
				StopCoroutine(writerCoroutine);
				writerCoroutine = null;
			}
			OnStopWriting();
		}

		private IEnumerator WriterCoroutine()
		{
			OnStartWriting();
			float excessWaitedTime = 0f;
			bool prevScaled = useScaledTime;
			if (currentIndex >= base.Mediator.CharData.Count)
			{
				OnStopWriting();
				yield break;
			}
			if (currentIndex <= 0)
			{
				ResetData();
			}
			if (currentIndex == -1)
			{
				HideAllCharacters(skipAnimations: true);
			}
			IEnumerable<ICachedInvokable> invokables = GetInvokables(-1);
			float prevTime = default(float);
			foreach (ICachedInvokable item in invokables)
			{
				waitAmount = 0f;
				shouldWait = false;
				continueConditions = null;
				item.Trigger();
				prevTime = (useScaledTime ? Time.time : Time.unscaledTime);
				if (shouldWait && waitAmount > 0f)
				{
					RaiseWaitStartedEvent(waitAmount);
					yield return useScaledTime ? ((object)new WaitForSeconds(waitAmount)) : ((object)new WaitForSecondsRealtime(waitAmount));
					RaiseWaitEndedEvent();
				}
				FixTimePost(waitAmount);
				if (base.Mediator == null)
				{
					yield break;
				}
				if (continueConditions != null)
				{
					yield return HandleWaitConditions();
				}
				if (base.Mediator == null)
				{
					yield break;
				}
			}
			yield return null;
			int i = Mathf.Max(currentIndex, 0);
			float tempTime;
			while (true)
			{
				if (i < base.Mediator?.CharData.Count)
				{
					currentIndex = i;
					CharData cData = base.Mediator.CharData[i];
					invokables = GetInvokables(i);
					foreach (ICachedInvokable item2 in invokables)
					{
						waitAmount = 0f;
						shouldWait = false;
						continueConditions = null;
						item2.Trigger();
						prevTime = (useScaledTime ? Time.time : Time.unscaledTime);
						if (shouldWait && waitAmount > 0f)
						{
							RaiseWaitStartedEvent(waitAmount);
							yield return useScaledTime ? ((object)new WaitForSeconds(waitAmount)) : ((object)new WaitForSecondsRealtime(waitAmount));
							RaiseWaitEndedEvent();
						}
						FixTimePost(waitAmount);
						if (base.Mediator == null)
						{
							yield break;
						}
						if (continueConditions != null)
						{
							yield return HandleWaitConditions();
						}
						if (base.Mediator == null)
						{
							yield break;
						}
					}
					float delay = CalculateDelay(i);
					FixTimePre(ref delay);
					if (delay > 0f)
					{
						yield return useScaledTime ? ((object)new WaitForSeconds(delay)) : ((object)new WaitForSecondsRealtime(delay));
						if (base.Mediator == null)
						{
							break;
						}
					}
					FixTimePost(delay);
					VisibilityState visibilityState = base.Mediator.VisibilityStates[i];
					if (visibilityState == VisibilityState.Hidden || visibilityState == VisibilityState.Hiding)
					{
						RaiseCharacterShownEvent(cData);
						Show(i, 1);
					}
					i++;
					continue;
				}
				_ = base.Mediator;
				RaiseFinishWriterEvent();
				OnStopWriting();
				break;
			}
			void FixTimePost(float time)
			{
				excessWaitedTime += (prevScaled ? Time.time : Time.unscaledTime) - prevTime - time;
			}
			void FixTimePre(ref float time)
			{
				tempTime = time;
				time = Mathf.Max(0f, time - excessWaitedTime);
				excessWaitedTime = Mathf.Max(0f, excessWaitedTime - tempTime);
				prevScaled = useScaledTime;
				prevTime = (useScaledTime ? Time.time : Time.unscaledTime);
			}
		}

		private void ResetInternalState()
		{
			if (writing)
			{
				StopWriterCoroutine();
			}
			currentIndex = -1;
			ResetInvokables(base.Mediator.CharData.Count);
			ResetData();
		}

		private void ResetData()
		{
			currentDelays = new Delays();
			currentDelays.delay = delays.delay;
			currentDelays.whitespaceDelay = delays.whitespaceDelay;
			currentDelays.whitespaceDelayType = delays.whitespaceDelayType;
			currentDelays.linebreakDelay = delays.linebreakDelay;
			currentDelays.linebreakDelayType = delays.linebreakDelayType;
			currentDelays.punctuationDelay = delays.punctuationDelay;
			currentDelays.punctuationDelayType = delays.punctuationDelayType;
			currentDelays.visibleDelay = delays.visibleDelay;
			currentDelays.visibleDelayType = delays.visibleDelayType;
			currentMaySkip = maySkip;
		}

		private void ResetInvokables(int maxIndex)
		{
			foreach (CachedEvent @event in events)
			{
				if ((@event.Indices.StartIndex <= maxIndex || @event.ExecuteInstantly) && @event.ExecuteRepeatable)
				{
					@event.Reset();
				}
			}
			foreach (CachedCommand command in commands)
			{
				if ((command.Indices.StartIndex <= maxIndex || command.ExecuteInstantly) && command.ExecuteRepeatable)
				{
					command.Reset();
				}
			}
		}

		private float CalculateDelay(int index)
		{
			CharData charData = base.Mediator.CharData[index];
			if (!charData.info.isVisible)
			{
				if (charData.info.character == '\n')
				{
					return Mathf.Max(currentDelays.CalculatedLinebreakDelay, 0f);
				}
				return Mathf.Max(currentDelays.CalculatedWhiteSpaceDelay, 0f);
			}
			VisibilityState visibilityState = base.Mediator.GetVisibilityState(charData);
			if (visibilityState == VisibilityState.Shown || visibilityState == VisibilityState.Showing)
			{
				return Mathf.Max(currentDelays.CalculatedVisibleDelay, 0f);
			}
			if (char.IsPunctuation(charData.info.character) && (index == base.Mediator.CharData.Count - 1 || !char.IsPunctuation(base.Mediator.CharData[index + 1].info.character)))
			{
				return Mathf.Max(currentDelays.CalculatedPunctuationDelay, 0f);
			}
			return currentDelays.delay;
		}

		private IEnumerator HandleWaitConditions()
		{
			if (continueConditions == null)
			{
				yield break;
			}
			bool allMet;
			do
			{
				allMet = true;
				Delegate[] invocationList = continueConditions.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					if (!(invocationList[i] as Func<bool>)())
					{
						allMet = false;
					}
					else
					{
						continueConditions = (Func<bool>)Delegate.Remove(continueConditions, invocationList[i] as Func<bool>);
					}
				}
				if (!allMet)
				{
					yield return null;
				}
			}
			while (!allMet && continueConditions != null);
			continueConditions = null;
		}

		private IEnumerable<ICachedInvokable> GetInvokables(int index, bool skipped = false)
		{
			IEnumerable<ICachedInvokable> enumerable;
			if (skipped)
			{
				enumerable = commands;
				if (events.HasAny())
				{
					enumerable = enumerable.Concat(events);
					enumerable = from x in enumerable
						orderby x.Indices.StartIndex, x.Indices.OrderAtIndex
						select x;
				}
				enumerable = enumerable.Where((ICachedInvokable x) => x.Indices.StartIndex >= index && x.ExecuteOnSkip);
			}
			else if (index < 0)
			{
				enumerable = commands;
				enumerable = enumerable.Where((ICachedInvokable x) => x.ExecuteInstantly);
			}
			else
			{
				enumerable = commands.GetAt(index);
				if (events.HasAnyAt(index))
				{
					enumerable = enumerable.Concat(events.GetAt(index));
					enumerable = from x in enumerable
						orderby x.Indices.StartIndex, x.Indices.OrderAtIndex
						select x;
				}
			}
			return enumerable;
		}

		private void RaiseInvokables(int index, bool skipped = false)
		{
			foreach (ICachedInvokable invokable in GetInvokables(index, skipped))
			{
				invokable.Trigger();
				waitAmount = 0f;
				shouldWait = false;
				continueConditions = null;
			}
		}

		private IEnumerator RaiseInvokablesCoroutine(int index, bool skipped = false, bool block = true)
		{
			waitAmount = 0f;
			shouldWait = false;
			continueConditions = null;
			foreach (ICachedInvokable invokable in GetInvokables(index, skipped))
			{
				invokable.Trigger();
				if (block)
				{
					if (shouldWait && waitAmount > 0f)
					{
						RaiseWaitStartedEvent(waitAmount);
						yield return useScaledTime ? ((object)new WaitForSeconds(waitAmount)) : ((object)new WaitForSecondsRealtime(waitAmount));
						RaiseWaitEndedEvent();
					}
					if (continueConditions != null)
					{
						yield return HandleWaitConditions();
					}
				}
				waitAmount = 0f;
				shouldWait = false;
				continueConditions = null;
			}
		}

		private IEnumerator RaiseInvokablesCoroutine(IEnumerable<ICachedInvokable> invokables, bool block = true)
		{
			waitAmount = 0f;
			shouldWait = false;
			continueConditions = null;
			foreach (ICachedInvokable invokable in invokables)
			{
				invokable.Trigger();
				if (block)
				{
					if (shouldWait && waitAmount > 0f)
					{
						RaiseWaitStartedEvent(waitAmount);
						yield return useScaledTime ? ((object)new WaitForSeconds(waitAmount)) : ((object)new WaitForSecondsRealtime(waitAmount));
						RaiseWaitEndedEvent();
					}
					if (continueConditions != null)
					{
						yield return HandleWaitConditions();
					}
				}
				waitAmount = 0f;
				shouldWait = false;
				continueConditions = null;
			}
		}

		private void OnStopWriting()
		{
			writing = false;
		}

		private void OnStartWriting()
		{
			writing = true;
		}

		private void HideAllCharacters(bool skipAnimations = false)
		{
			Hide(0, base.Mediator.CharData.Count, skipAnimations);
		}

		private void PostProcessTags()
		{
			KeyValuePair<TMPEffectCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>> keyValuePair = new KeyValuePair<TMPEffectCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>(commandCategory, processors.TagProcessors[commandCategory.Prefix][0].ProcessedTags);
			KeyValuePair<TMPEffectCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>> keyValuePair2 = new KeyValuePair<TMPEffectCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>(eventCategory, processors.TagProcessors[eventCategory.Prefix][0].ProcessedTags);
			tags = new TagCollectionManager<TMPEffectCategory>(keyValuePair, keyValuePair2);
			CommandCacher cacher = new CommandCacher(base.Mediator.CharData, this, commandCategory, keywordDatabaseWrapper.Database);
			EventCacher cacher2 = new EventCacher(this, OnTextEvent);
			commands = new CachedCollection<CachedCommand>(cacher, tags[commandCategory]);
			events = new CachedCollection<CachedEvent>(cacher2, tags[eventCategory]);
		}
	}
}
