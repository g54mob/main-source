using System;
using System.Collections.Generic;
using Febucci.Numbers;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.Typing
{
	public class TypewriterCore : IDisposable
	{
		private enum TypewriterState
		{
			Idle = 0,
			Showing = 1,
			Hiding = 2,
			WaitingForAction = 3,
			WaitingBeforeShowing = 4,
			WaitingForCharacters = 5,
			WaitingAfterCharacters = 6
		}

		public delegate void OnCharacterWait(CharacterData characterData, WaitMode stage);

		public delegate ActionStatus CharacterWaitMethod(CharacterData character);

		private object attachedEngineComponent;

		private TypewriterState currentState;

		private bool afterWaitEventFired;

		public readonly TextAnimator animator;

		private ISettingsProvider<TypewriterSettings> localTypewriterSettingsProvider;

		private TypewriterSettings localSettings;

		private ActionMarker[] actions = Array.Empty<ActionMarker>();

		private EventMarker[] events = Array.Empty<EventMarker>();

		private ISettingsProvider<GlobalSettingsBase> globalSettingsProvider;

		private IDatabaseProvider<ITypewriterAction>[] actionProviders;

		public ITypingTimingsProvider timingsProvider;

		private bool hasAnyAction;

		private Dictionary<string, ITypewriterAction> databaseActions;

		private int latestActionTriggered;

		private int latestEventTriggered;

		private TypingInfo typingInfo;

		private float internalSpeed = 1f;

		private float currentFrameDeltaTime = -1f;

		private int currentCharIndex;

		private int firstCharacter;

		private int lastCharacter;

		private int currentActionIndex;

		private IActionState currentActionState;

		private float currentWaitTime;

		private WaitMode currentWaitMode;

		private float timeCarryover;

		private bool shouldExitLoopAfterWait;

		private float lastCharacterOriginalWaitTime;

		private int[] hideIndexes = Array.Empty<int>();

		private int currentHideIndex;

		private float currentHideWaitTime;

		private float lastHideCharacterOriginalWaitTime;

		private readonly ActionParser actionParser;

		private readonly EventParser eventParser;

		internal CharacterWaitMethod OnBeforeShowingCharacter;

		internal CharacterWaitMethod OnAfterWaitingCharacter;

		private Vector2Int[] typewriterDisabledRange = Array.Empty<Vector2Int>();

		public ISettingsProvider<TypewriterSettings> LocalSettingsProvider
		{
			get
			{
				return localTypewriterSettingsProvider;
			}
			set
			{
				if (localTypewriterSettingsProvider != value)
				{
					localTypewriterSettingsProvider = value;
					RefreshSettings();
				}
			}
		}

		public ActionMarker[] Actions
		{
			get
			{
				return actions;
			}
			internal set
			{
				actions = value;
				Array.Sort(Actions, delegate(ActionMarker a, ActionMarker b)
				{
					int num = a.index.CompareTo(b.index);
					return (num == 0) ? a.internalOrder.CompareTo(b.internalOrder) : num;
				});
			}
		}

		public EventMarker[] Events
		{
			get
			{
				return events;
			}
			internal set
			{
				events = value;
				Array.Sort(Events, delegate(EventMarker a, EventMarker b)
				{
					int num = a.index.CompareTo(b.index);
					return (num == 0) ? a.internalOrder.CompareTo(b.internalOrder) : num;
				});
			}
		}

		public IDatabaseProvider<ITypewriterAction>[] ActionProviders
		{
			get
			{
				return actionProviders;
			}
			set
			{
				actionProviders = value;
				BuildActionsDatabase();
			}
		}

		public bool IsShowingText
		{
			get
			{
				if (currentState != TypewriterState.Showing && currentState != TypewriterState.WaitingForAction && (currentState != TypewriterState.WaitingBeforeShowing || currentWaitMode != WaitMode.Appearance) && (currentState != TypewriterState.WaitingForCharacters || currentWaitMode != WaitMode.Appearance))
				{
					if (currentState == TypewriterState.WaitingAfterCharacters)
					{
						return currentWaitMode == WaitMode.Appearance;
					}
					return false;
				}
				return true;
			}
		}

		public bool IsHidingText
		{
			get
			{
				if (currentState != TypewriterState.Hiding && (currentState != TypewriterState.WaitingBeforeShowing || currentWaitMode != WaitMode.Disappearance) && (currentState != TypewriterState.WaitingForCharacters || currentWaitMode != WaitMode.Disappearance))
				{
					if (currentState == TypewriterState.WaitingAfterCharacters)
					{
						return currentWaitMode == WaitMode.Disappearance;
					}
					return false;
				}
				return true;
			}
		}

		public Vector2Int[] TypewriterDisabledRange
		{
			get
			{
				return typewriterDisabledRange;
			}
			set
			{
				typewriterDisabledRange = value ?? Array.Empty<Vector2Int>();
			}
		}

		public event Action OnTextShowed;

		public event Action OnTypewriterStart;

		public event Action OnTextDisappeared;

		public event Action<CharacterData> OnCharacterVisible;

		public event OnCharacterWait OnCharacterWaitStarted;

		public event OnCharacterWait OnCharacterWaitFinished;

		public event Action<EventMarker> OnMessage;

		private void RefreshSettings()
		{
			if (localTypewriterSettingsProvider != null && localTypewriterSettingsProvider.Settings != null)
			{
				localSettings = localTypewriterSettingsProvider.Settings;
			}
			else
			{
				localSettings = new FallbackTypewriterSettings();
			}
		}

		private void BuildActionsDatabase()
		{
			if (databaseActions == null)
			{
				databaseActions = new Dictionary<string, ITypewriterAction>();
			}
			IDatabaseProvider<ITypewriterAction> databaseProvider = globalSettingsProvider?.Settings?.GlobalActionsDatabase;
			databaseActions.Clear();
			if ((actionProviders == null || actionProviders.Length == 0) && databaseProvider == null)
			{
				return;
			}
			bool flag = false;
			if (actionProviders != null)
			{
				IDatabaseProvider<ITypewriterAction>[] array = actionProviders;
				foreach (IDatabaseProvider<ITypewriterAction> databaseProvider2 in array)
				{
					if (databaseProvider2 == databaseProvider)
					{
						flag = true;
					}
					if (databaseProvider2 == null || databaseProvider2.Database == null)
					{
						continue;
					}
					foreach (KeyValuePair<string, ITypewriterAction> item in databaseProvider2.Database)
					{
						if (!databaseActions.ContainsKey(item.Key))
						{
							databaseActions.Add(item.Key, item.Value);
						}
					}
				}
			}
			if (!flag && databaseProvider != null && databaseProvider.Database != null)
			{
				foreach (KeyValuePair<string, ITypewriterAction> item2 in databaseProvider.Database)
				{
					databaseActions.TryAdd(item2.Key, item2.Value);
				}
			}
			hasAnyAction = databaseActions.Count > 0;
		}

		public TypewriterCore(TextAnimator animator, object attachedEngineComponent, ITypingTimingsProvider timingsProvider, ISettingsProvider<GlobalSettingsBase> globalSettingsProvider, ISettingsProvider<TypewriterSettings> localTypewriterSettingsProvider = null, IDatabaseProvider<ITypewriterAction>[] actionProviders = null, CharacterWaitMethod OnBeforeShowingCharacter = null, CharacterWaitMethod OnAfterWaitingCharacter = null)
		{
			if (animator == null)
			{
				throw new ArgumentNullException("animator", "Linked animator is null. Unable to initialize typewriter.");
			}
			this.attachedEngineComponent = attachedEngineComponent;
			this.animator = animator;
			this.timingsProvider = timingsProvider;
			this.globalSettingsProvider = globalSettingsProvider;
			this.localTypewriterSettingsProvider = localTypewriterSettingsProvider;
			RefreshSettings();
			animator.OnWantsToSetText += ShowText;
			animator.OnUpdate += UpdateTypewriter;
			this.OnBeforeShowingCharacter = OnBeforeShowingCharacter;
			this.OnAfterWaitingCharacter = OnAfterWaitingCharacter;
			actionParser = new ActionParser('<', '/', '>');
			eventParser = new EventParser('<', '/', '>');
			animator.AddParsers(actionParser, eventParser);
			animator.OnPrepareForParsing += OnPrepareForParsing;
			animator.OnTextParsedInternal += CopyParsingResults;
			animator.OnDisposed += Dispose;
			this.actionProviders = actionProviders;
			BuildActionsDatabase();
			typingInfo = new TypingInfo();
			currentCharIndex = 0;
			firstCharacter = 0;
			lastCharacter = 0;
			currentActionIndex = 0;
			currentActionState = null;
			currentWaitTime = 0f;
			currentHideWaitTime = 0f;
		}

		private void OnPrepareForParsing(AnimatorSettings settings)
		{
			BuildActionsDatabase();
			actionParser.database = databaseActions;
		}

		private void CopyParsingResults()
		{
			Actions = actionParser.results;
			Events = eventParser.results;
		}

		public void ShowText(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				animator.SetText(string.Empty);
				return;
			}
			animator.SetText(text, (!localSettings.useTypeWriter) ? ShowTextMode.Shown : ShowTextMode.Hidden);
			animator.FirstVisibleCharacter = 0;
			if (!localSettings.useTypeWriter)
			{
				this.OnTextShowed?.Invoke();
			}
			else if (localSettings.startTypewriterMode.HasFlag(StartTypewriterMode.OnShowText))
			{
				StartShowingText(restart: true);
			}
		}

		public void SkipTypewriter()
		{
			if (IsShowingText)
			{
				currentState = TypewriterState.Idle;
				SetVisibilityWithOverflow(visible: true);
				if (localSettings.triggerEventsOnSkip)
				{
					TriggerEventsUntil(int.MaxValue);
				}
				this.OnTextShowed?.Invoke();
			}
			if (IsHidingText)
			{
				currentState = TypewriterState.Idle;
				SetVisibilityWithOverflow(visible: false);
				this.OnTextDisappeared?.Invoke();
			}
			void SetVisibilityWithOverflow(bool visible)
			{
				int visibleCharactersInPage = GetVisibleCharactersInPage();
				if (visibleCharactersInPage > 0 && visibleCharactersInPage != animator.CharactersCount)
				{
					for (int i = firstCharacter; i < lastCharacter; i++)
					{
						animator.SetVisibilityChar(i, visible, !localSettings.hideAppearancesOnSkip);
					}
				}
				else
				{
					animator.SetVisibilityEntireText(visible, !localSettings.hideAppearancesOnSkip);
				}
			}
		}

		public void StartShowingText(bool restart = false)
		{
			if (animator.CharactersCount == 0)
			{
				return;
			}
			if (!localSettings.useTypeWriter)
			{
				Logger.LogWarning("TypewriterCore: couldn't start because 'useTypewriter' is disabled");
				return;
			}
			if (IsShowingText)
			{
				StopShowingText();
			}
			if (restart)
			{
				animator.SetVisibilityEntireText(isVisible: false, canPlayEffects: false);
			}
			if (animator.FirstVisibleCharacter == 0)
			{
				latestActionTriggered = 0;
				latestEventTriggered = 0;
			}
			if (localSettings.resetTypingSpeedAtStartup)
			{
				internalSpeed = 1f;
			}
			currentState = TypewriterState.Showing;
			int visibleCharactersInPage = GetVisibleCharactersInPage();
			firstCharacter = GetFirstCharacterInPage();
			lastCharacter = firstCharacter + visibleCharactersInPage;
			currentCharIndex = firstCharacter;
			currentActionIndex = latestActionTriggered;
			typingInfo = new TypingInfo();
			currentWaitTime = 0f;
			this.OnTypewriterStart?.Invoke();
		}

		private int GetVisibleCharactersInPage()
		{
			return animator.textGenerator.GetRenderedCharactersCountInsidePage(animator.CharactersCount);
		}

		private int GetFirstCharacterInPage()
		{
			return animator.textGenerator.GetFirstCharacterIndexInsidePage();
		}

		public void StopShowingText()
		{
			if (IsShowingText)
			{
				currentActionState?.Cancel();
				currentActionState = null;
				currentWaitTime = 0f;
				currentState = TypewriterState.Idle;
			}
		}

		public void StartDisappearingText()
		{
			if (IsShowingText)
			{
				StopShowingText();
			}
			if (IsHidingText)
			{
				return;
			}
			currentState = TypewriterState.Hiding;
			int visibleCharactersInPage = GetVisibleCharactersInPage();
			firstCharacter = GetFirstCharacterInPage();
			lastCharacter = firstCharacter + visibleCharactersInPage;
			typingInfo = new TypingInfo();
			if (hideIndexes.Length < animator.CharactersCount)
			{
				Array.Resize(ref hideIndexes, animator.CharactersCount);
			}
			switch (localSettings.disappearanceOrientation)
			{
			default:
			{
				for (int k = firstCharacter; k < lastCharacter; k++)
				{
					hideIndexes[k - firstCharacter] = k;
				}
				break;
			}
			case DisappearanceOrientation.Inverted:
			{
				for (int j = firstCharacter; j < lastCharacter; j++)
				{
					hideIndexes[j - firstCharacter] = lastCharacter - 1 - (j - firstCharacter);
				}
				break;
			}
			case DisappearanceOrientation.Random:
			{
				for (int i = firstCharacter; i < lastCharacter; i++)
				{
					hideIndexes[i - firstCharacter] = i;
				}
				ShuffleArray(hideIndexes, 0, lastCharacter - firstCharacter);
				break;
			}
			}
			currentHideIndex = 0;
			currentHideWaitTime = 0f;
		}

		public void StopDisappearingText()
		{
			if (IsHidingText)
			{
				currentState = TypewriterState.Idle;
			}
		}

		public void SetTypewriterSpeed(float value)
		{
			internalSpeed = Math.Max(0.001f, value);
		}

		protected void UpdateTypewriter(float deltaTime)
		{
			currentFrameDeltaTime = deltaTime;
			UpdateTypewriter();
		}

		public void UpdateTypewriter()
		{
			if (animator == null)
			{
				return;
			}
			if (currentFrameDeltaTime < 0f)
			{
				currentFrameDeltaTime = animator.Time.deltaTime;
			}
			shouldExitLoopAfterWait = false;
			TypewriterState typewriterState;
			do
			{
				typewriterState = currentState;
				switch (currentState)
				{
				case TypewriterState.Showing:
					UpdateShowing();
					break;
				case TypewriterState.Hiding:
					UpdateHiding();
					break;
				case TypewriterState.WaitingBeforeShowing:
					UpdateWaitingBeforeShowing();
					break;
				case TypewriterState.WaitingForAction:
					UpdateWaitingForAction();
					break;
				case TypewriterState.WaitingForCharacters:
					UpdateWaitingForCharacters();
					break;
				case TypewriterState.WaitingAfterCharacters:
					UpdateWaitingAfterCharacters();
					break;
				}
			}
			while (typewriterState != currentState && currentState != TypewriterState.WaitingForCharacters && !shouldExitLoopAfterWait);
			currentFrameDeltaTime = -1f;
			void UpdateHiding()
			{
				float num = ((timeCarryover > 0f) ? timeCarryover : GetDeltaTime(typingInfo));
				timeCarryover = 0f;
				int num2 = lastCharacter - firstCharacter;
				while (currentHideIndex < num2)
				{
					int num3 = hideIndexes[currentHideIndex];
					if (num3 >= animator.CharactersCount || num3 >= lastCharacter)
					{
						currentHideIndex++;
					}
					else
					{
						if (animator.Characters[num3].isVisible)
						{
							animator.SetVisibilityChar(num3, isVisible: false);
						}
						currentHideWaitTime = 0f;
						lastHideCharacterOriginalWaitTime = 0f;
						if (IsTypewriterEnabledAtIndex(num3) && timingsProvider != null)
						{
							currentHideWaitTime = timingsProvider.GetWaitDisappearanceTimeOf(animator.Characters[num3], animator);
							lastHideCharacterOriginalWaitTime = currentHideWaitTime;
							if (currentHideWaitTime < 0f)
							{
								currentHideWaitTime = 0f;
							}
						}
						if (currentHideWaitTime > 0f)
						{
							currentHideWaitTime -= num;
							currentWaitMode = WaitMode.Disappearance;
							this.OnCharacterWaitStarted?.Invoke(animator.Characters[num3], WaitMode.Disappearance);
							if (currentHideWaitTime <= 0f)
							{
								afterWaitEventFired = false;
								currentState = TypewriterState.WaitingAfterCharacters;
							}
							else
							{
								currentState = TypewriterState.WaitingForCharacters;
							}
							return;
						}
						currentHideIndex++;
					}
				}
				bool flag = false;
				for (int i = firstCharacter; i < lastCharacter && i < animator.CharactersCount; i++)
				{
					if (animator.Characters[i].isVisible)
					{
						flag = true;
						break;
					}
				}
				if (!flag && (!localSettings.triggerDisappearedAfterEffectsEnd || !animator.AnyLetterVisible))
				{
					currentState = TypewriterState.Idle;
					this.OnTextDisappeared?.Invoke();
				}
			}
			void UpdateShowing()
			{
				float num = ((timeCarryover > 0f) ? timeCarryover : GetDeltaTime(typingInfo));
				timeCarryover = 0f;
				while (currentCharIndex < animator.CharactersCount && currentCharIndex < lastCharacter)
				{
					if (hasAnyAction && currentActionIndex < Actions.Length)
					{
						ActionMarker actionMarker = Actions[currentActionIndex];
						if (actionMarker.index < currentCharIndex + 1)
						{
							TriggerEventsBeforeAction(currentCharIndex + 1, actionMarker);
							if (databaseActions.TryGetValue(actionMarker.name, out var value))
							{
								currentActionState?.Cancel();
								currentActionState = value.CreateActionFrom(actionMarker, attachedEngineComponent);
								if (currentActionState.Progress(currentFrameDeltaTime, ref typingInfo) == ActionStatus.Running)
								{
									currentState = TypewriterState.WaitingForAction;
									currentActionIndex++;
									return;
								}
							}
							currentActionIndex++;
							continue;
						}
					}
					TriggerEventsUntil(currentCharIndex + 1);
					if (OnBeforeShowingCharacter != null && !animator.Characters[currentCharIndex].isVisible)
					{
						currentWaitMode = WaitMode.Appearance;
						currentState = TypewriterState.WaitingBeforeShowing;
						return;
					}
					if (!animator.Characters[currentCharIndex].isVisible)
					{
						animator.SetVisibilityChar(currentCharIndex, isVisible: true);
						this.OnCharacterVisible?.Invoke(animator.Characters[currentCharIndex]);
					}
					currentWaitTime = 0f;
					lastCharacterOriginalWaitTime = 0f;
					if (IsTypewriterEnabledAtIndex(currentCharIndex) && timingsProvider != null)
					{
						currentWaitTime = timingsProvider.GetWaitAppearanceTimeOf(animator.Characters[currentCharIndex], animator);
						lastCharacterOriginalWaitTime = currentWaitTime;
						if (currentWaitTime < 0f)
						{
							currentWaitTime = 0f;
						}
					}
					if (currentWaitTime > 0f)
					{
						currentWaitTime -= num;
						currentWaitMode = WaitMode.Appearance;
						this.OnCharacterWaitStarted?.Invoke(animator.Characters[currentCharIndex], WaitMode.Appearance);
						if (currentWaitTime <= 0f)
						{
							afterWaitEventFired = false;
							currentState = TypewriterState.WaitingAfterCharacters;
						}
						else
						{
							currentState = TypewriterState.WaitingForCharacters;
						}
						return;
					}
					currentCharIndex++;
				}
				if (hasAnyAction)
				{
					while (currentActionIndex < Actions.Length)
					{
						ActionMarker actionMarker2 = Actions[currentActionIndex];
						TriggerEventsBeforeAction(int.MaxValue, actionMarker2);
						if (databaseActions.TryGetValue(actionMarker2.name, out var value2))
						{
							currentActionState?.Cancel();
							currentActionState = value2.CreateActionFrom(actionMarker2, attachedEngineComponent);
							ActionStatus actionStatus = currentActionState.Progress(currentFrameDeltaTime, ref typingInfo);
							if (actionStatus != ActionStatus.Finished)
							{
								currentState = TypewriterState.WaitingForAction;
								currentActionIndex++;
								return;
							}
						}
						currentActionIndex++;
					}
				}
				TriggerEventsUntil(int.MaxValue);
				if (!localSettings.triggerShowedAfterEffectsEnd || animator.AllLettersShown)
				{
					currentState = TypewriterState.Idle;
					this.OnTextShowed?.Invoke();
				}
			}
			void UpdateWaitingAfterCharacters()
			{
				if (OnAfterWaitingCharacter != null && currentWaitMode == WaitMode.Appearance)
				{
					CharacterData character = animator.Characters[currentCharIndex];
					ActionStatus actionStatus = OnAfterWaitingCharacter(character);
					if (actionStatus != ActionStatus.Finished)
					{
						return;
					}
				}
				if (!afterWaitEventFired)
				{
					if (currentWaitMode == WaitMode.Appearance)
					{
						this.OnCharacterWaitFinished?.Invoke(animator.Characters[currentCharIndex], WaitMode.Appearance);
					}
					else
					{
						int num = hideIndexes[currentHideIndex];
						this.OnCharacterWaitFinished?.Invoke(animator.Characters[num], WaitMode.Disappearance);
					}
					afterWaitEventFired = true;
				}
				if (currentWaitMode == WaitMode.Appearance)
				{
					currentCharIndex++;
					float num2 = 0f - currentWaitTime;
					if (lastCharacterOriginalWaitTime > 0f && num2 > lastCharacterOriginalWaitTime * 3f)
					{
						timeCarryover = 1E-05f;
					}
					else
					{
						timeCarryover = Math.Max(1E-05f, num2);
					}
					currentWaitTime = 0f;
					shouldExitLoopAfterWait = true;
					currentState = TypewriterState.Showing;
				}
				else
				{
					currentHideIndex++;
					float num3 = 0f - currentHideWaitTime;
					if (lastHideCharacterOriginalWaitTime > 0f && num3 > lastHideCharacterOriginalWaitTime * 3f)
					{
						timeCarryover = 1E-05f;
					}
					else
					{
						timeCarryover = Math.Max(1E-05f, num3);
					}
					currentHideWaitTime = 0f;
					shouldExitLoopAfterWait = true;
					currentState = TypewriterState.Hiding;
				}
			}
			void UpdateWaitingBeforeShowing()
			{
				CharacterData character = animator.Characters[currentCharIndex];
				ActionStatus actionStatus = OnBeforeShowingCharacter(character);
				if (actionStatus == ActionStatus.Finished)
				{
					animator.SetVisibilityChar(currentCharIndex, isVisible: true);
					this.OnCharacterVisible?.Invoke(animator.Characters[currentCharIndex]);
					currentState = TypewriterState.Showing;
				}
			}
			void UpdateWaitingForAction()
			{
				if (currentActionState.Progress(animator.Time.deltaTime, ref typingInfo) == ActionStatus.Finished)
				{
					currentActionState = null;
					currentState = TypewriterState.Showing;
				}
			}
			void UpdateWaitingForCharacters()
			{
				float deltaTime = GetDeltaTime(typingInfo);
				if (currentWaitMode == WaitMode.Appearance)
				{
					currentWaitTime -= deltaTime;
					if (currentWaitTime <= 0f)
					{
						afterWaitEventFired = false;
						currentState = TypewriterState.WaitingAfterCharacters;
					}
				}
				else
				{
					currentHideWaitTime -= deltaTime;
					if (currentHideWaitTime <= 0f)
					{
						afterWaitEventFired = false;
						currentState = TypewriterState.WaitingAfterCharacters;
					}
				}
			}
		}

		private float GetDeltaTime(TypingInfo info)
		{
			return currentFrameDeltaTime * internalSpeed * info.speed;
		}

		private bool IsTypewriterEnabledAtIndex(int index)
		{
			Vector2Int[] array = typewriterDisabledRange;
			for (int i = 0; i < array.Length; i++)
			{
				Vector2Int vector2Int = array[i];
				if (index >= vector2Int.X && index < vector2Int.Y)
				{
					return false;
				}
			}
			return true;
		}

		private void TriggerEventsBeforeAction(int maxIndex, ActionMarker action)
		{
			while (latestEventTriggered < Events.Length)
			{
				EventMarker eventMarker = Events[latestEventTriggered];
				if (eventMarker.index < maxIndex || (eventMarker.index == action.index && eventMarker.internalOrder < action.internalOrder))
				{
					this.OnMessage?.Invoke(Events[latestEventTriggered]);
					latestEventTriggered++;
					continue;
				}
				break;
			}
		}

		private void TriggerEventsUntil(int maxIndex)
		{
			while (latestEventTriggered < Events.Length && Events[latestEventTriggered].index < maxIndex)
			{
				this.OnMessage?.Invoke(Events[latestEventTriggered]);
				latestEventTriggered++;
			}
		}

		public void TriggerRemainingEvents()
		{
			TriggerEventsUntil(int.MaxValue);
		}

		public void TriggerVisibleEvents()
		{
			TriggerEventsUntil(animator.LatestCharacterShown.index);
		}

		private static void ShuffleArray(int[] array, int start, int end)
		{
			Random random = new Random();
			int num = end - start;
			while (num > 1)
			{
				int num2 = random.Next(num--) + start;
				ref int reference = ref array[num + start];
				ref int reference2 = ref array[num2];
				int num3 = array[num2];
				int num4 = array[num + start];
				reference = num3;
				reference2 = num4;
			}
		}

		public void Dispose()
		{
			if (animator != null)
			{
				animator.OnDisposed -= Dispose;
				animator.OnWantsToSetText -= ShowText;
				animator.OnUpdate -= UpdateTypewriter;
				animator.RemoveParsers(actionParser, eventParser);
				animator.OnPrepareForParsing -= OnPrepareForParsing;
				animator.OnTextParsedInternal -= CopyParsingResults;
			}
		}
	}
}
