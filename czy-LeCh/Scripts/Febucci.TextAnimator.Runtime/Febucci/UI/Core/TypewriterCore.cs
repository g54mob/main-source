using System;
using System.Collections;
using Febucci.UI.Core.Parsing;
using UnityEngine;
using UnityEngine.Events;

namespace Febucci.UI.Core
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TAnimCore))]
	public abstract class TypewriterCore : MonoBehaviour
	{
		[Flags]
		public enum StartTypewriterMode
		{
			FromScriptOnly = 0,
			OnEnable = 1,
			OnShowText = 2,
			AutomaticallyFromAllEvents = 3
		}

		public enum DisappearanceOrientation
		{
			SameAsTypewriter = 0,
			Inverted = 1,
			Random = 2
		}

		private TAnimCore _textAnimator;

		[Tooltip("True if you want to shows the text dynamically")]
		[SerializeField]
		public bool useTypeWriter = true;

		[SerializeField]
		[Tooltip("Controls from which method(s) the typewriter will automatically start/resume. Default is 'Automatic'")]
		public StartTypewriterMode startTypewriterMode = StartTypewriterMode.AutomaticallyFromAllEvents;

		[SerializeField]
		private bool hideAppearancesOnSkip;

		[SerializeField]
		[Tooltip("True = plays all remaining events once the typewriter has been skipped")]
		private bool triggerEventsOnSkip;

		[SerializeField]
		[Tooltip("True = resets the typewriter speed every time a new text is set/shown")]
		public bool resetTypingSpeedAtStartup = true;

		[SerializeField]
		public DisappearanceOrientation disappearanceOrientation;

		public UnityEvent onTextShowed = new UnityEvent();

		public UnityEvent onTypewriterStart = new UnityEvent();

		public UnityEvent onTextDisappeared = new UnityEvent();

		public CharacterEvent onCharacterVisible = new CharacterEvent();

		public MessageEvent onMessage = new MessageEvent();

		private Coroutine showRoutine;

		private Coroutine nestedActionRoutine;

		private Coroutine hideRoutine;

		private Coroutine nestedHideRoutine;

		private float internalSpeed = 1f;

		private int latestActionTriggered;

		private int latestEventTriggered;

		public TAnimCore TextAnimator
		{
			get
			{
				if (_textAnimator != null)
				{
					return _textAnimator;
				}
				if (!TryGetComponent<TAnimCore>(out _textAnimator))
				{
					Debug.LogError("TextAnimator: Text Animator component is null on GameObject " + base.gameObject.name + ". Please add a component that inherits from TAnimCore");
				}
				return _textAnimator;
			}
		}

		public bool isShowingText { get; private set; }

		public bool isHidingText { get; private set; }

		[Obsolete("Please set the speed through 'SetTypewriterSpeed' method instead")]
		protected float typewriterPlayerSpeed
		{
			get
			{
				return internalSpeed;
			}
			set
			{
				SetTypewriterSpeed(value);
			}
		}

		[Obsolete("Please skip the typewriter via the 'SkipTypewriter' method instead")]
		protected bool wantsToSkip
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				if (value)
				{
					SkipTypewriter();
				}
			}
		}

		[Obsolete("Please use 'isShowingText' instead")]
		protected bool isBaseInsideRoutine => isShowingText;

		[Obsolete("Please use 'TextAnimator' instead")]
		public TAnimCore textAnimator => TextAnimator;

		public void ShowText(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				TextAnimator.SetText(string.Empty, hideText: true);
				return;
			}
			TextAnimator.SetText(text, useTypeWriter);
			TextAnimator.firstVisibleCharacter = 0;
			if (!useTypeWriter)
			{
				onTextShowed?.Invoke();
			}
			else if (startTypewriterMode.HasFlag(StartTypewriterMode.OnShowText))
			{
				StartShowingText(restart: true);
			}
		}

		public void SkipTypewriter()
		{
			if (isShowingText)
			{
				StopAllCoroutines();
				isShowingText = false;
				TextAnimator.SetVisibilityEntireText(isVisible: true, !hideAppearancesOnSkip);
				if (triggerEventsOnSkip)
				{
					TriggerEventsUntil(int.MaxValue);
				}
				onTextShowed?.Invoke();
			}
		}

		public void StartShowingText(bool restart = false)
		{
			if (TextAnimator.CharactersCount == 0)
			{
				return;
			}
			if (!useTypeWriter)
			{
				Debug.LogWarning("TextAnimator: couldn't start coroutine because 'useTypewriter' is disabled");
				return;
			}
			if (isShowingText)
			{
				StopShowingText();
			}
			if (restart)
			{
				TextAnimator.SetVisibilityEntireText(isVisible: false, canPlayEffects: false);
				latestActionTriggered = 0;
				latestEventTriggered = 0;
			}
			if (resetTypingSpeedAtStartup)
			{
				internalSpeed = 1f;
			}
			isShowingText = true;
			showRoutine = StartCoroutine(ShowTextRoutine());
		}

		protected abstract float GetWaitAppearanceTimeOf(int charIndex);

		private float GetDeltaTime(TypingInfo typingInfo)
		{
			return TextAnimator.time.deltaTime * internalSpeed * typingInfo.speed;
		}

		private IEnumerator ShowTextRoutine()
		{
			isShowingText = true;
			TypingInfo typingInfo = new TypingInfo();
			onTypewriterStart?.Invoke();
			TextAnimatorSettings instance = TextAnimatorSettings.Instance;
			bool actionsEnabled = (bool)instance && instance.actions.enabled;
			for (int i = 0; i < TextAnimator.CharactersCount; i++)
			{
				if (actionsEnabled)
				{
					int maxIndex = i + 1;
					for (int a = latestActionTriggered; a < TextAnimator.Actions.Length && TextAnimator.Actions[a].index < maxIndex; a++)
					{
						ActionMarker actionMarker = TextAnimator.Actions[a];
						TriggerEventsBeforeAction(maxIndex, actionMarker);
						yield return nestedActionRoutine = StartCoroutine(TextAnimator.DatabaseActions[actionMarker.name]?.DoAction(actionMarker, this, typingInfo));
						latestActionTriggered = a + 1;
					}
				}
				TriggerEventsUntil(i + 1);
				if (TextAnimator.Characters[i].isVisible)
				{
					continue;
				}
				TextAnimator.SetVisibilityChar(i, isVisible: true);
				onCharacterVisible?.Invoke(TextAnimator.latestCharacterShown.info.character);
				float timeToWait = GetWaitAppearanceTimeOf(i);
				float deltaTime = GetDeltaTime(typingInfo);
				if (timeToWait < 0f)
				{
					timeToWait = 0f;
				}
				if (timeToWait < deltaTime)
				{
					typingInfo.timePassed += timeToWait;
					if (typingInfo.timePassed >= deltaTime)
					{
						yield return null;
						typingInfo.timePassed %= deltaTime;
					}
				}
				else
				{
					while (typingInfo.timePassed < timeToWait)
					{
						typingInfo.timePassed += deltaTime;
						yield return null;
						deltaTime = GetDeltaTime(typingInfo);
					}
					typingInfo.timePassed %= timeToWait;
				}
			}
			if (actionsEnabled)
			{
				for (int i = latestActionTriggered; i < TextAnimator.Actions.Length && TextAnimator.Actions[i].index < int.MaxValue; i++)
				{
					ActionMarker actionMarker2 = TextAnimator.Actions[i];
					TriggerEventsBeforeAction(int.MaxValue, actionMarker2);
					yield return nestedActionRoutine = StartCoroutine(TextAnimator.DatabaseActions[actionMarker2.name]?.DoAction(actionMarker2, this, typingInfo));
					latestActionTriggered = i + 1;
				}
			}
			TriggerEventsUntil(int.MaxValue);
			onTextShowed?.Invoke();
			isShowingText = false;
		}

		public void StopShowingText()
		{
			if (isShowingText)
			{
				isShowingText = false;
				if (showRoutine != null)
				{
					StopCoroutine(showRoutine);
				}
				if (nestedActionRoutine != null)
				{
					StopCoroutine(nestedActionRoutine);
				}
			}
		}

		[ContextMenu("Start Disappearing Text")]
		public void StartDisappearingText()
		{
			if (disappearanceOrientation == DisappearanceOrientation.Inverted && isShowingText)
			{
				Debug.LogWarning("TextAnimatorPlayer: Can't start disappearance routine in the opposite direction of the typewriter, because you're still showing the text! (the typewriter might get stuck trying to show and override letters that keep disappearing)");
			}
			else if (!isHidingText)
			{
				hideRoutine = StartCoroutine(HideTextRoutine());
			}
		}

		[ContextMenu("Stop Disappearing Text")]
		public void StopDisappearingText()
		{
			if (isHidingText)
			{
				isHidingText = false;
				if (hideRoutine != null)
				{
					StopCoroutine(hideRoutine);
				}
				if (nestedHideRoutine != null)
				{
					StopCoroutine(nestedHideRoutine);
				}
			}
		}

		protected virtual float GetWaitDisappearanceTimeOf(int charIndex)
		{
			return GetWaitAppearanceTimeOf(charIndex);
		}

		private static int[] ShuffleArray(int[] array)
		{
			System.Random random = new System.Random();
			int num = array.Length;
			while (num > 1)
			{
				int num2 = random.Next(num--);
				ref int reference = ref array[num];
				ref int reference2 = ref array[num2];
				int num3 = array[num2];
				int num4 = array[num];
				reference = num3;
				reference2 = num4;
			}
			return array;
		}

		private IEnumerator HideTextRoutine()
		{
			isHidingText = true;
			TypingInfo typingInfo = new TypingInfo();
			int[] indexes = new int[TextAnimator.CharactersCount];
			switch (disappearanceOrientation)
			{
			default:
			{
				for (int k = 0; k < TextAnimator.CharactersCount; k++)
				{
					indexes[k] = k;
				}
				break;
			}
			case DisappearanceOrientation.Inverted:
			{
				for (int j = 0; j < TextAnimator.CharactersCount; j++)
				{
					indexes[j] = TextAnimator.CharactersCount - j - 1;
				}
				break;
			}
			case DisappearanceOrientation.Random:
			{
				for (int i = 0; i < TextAnimator.CharactersCount; i++)
				{
					indexes[i] = i;
				}
				indexes = ShuffleArray(indexes);
				break;
			}
			}
			for (int l = 0; l < TextAnimator.CharactersCount; l++)
			{
				int num = indexes[l];
				if (!TextAnimator.Characters[num].isVisible)
				{
					continue;
				}
				TextAnimator.SetVisibilityChar(num, isVisible: false);
				float timeToWait = GetWaitDisappearanceTimeOf(num);
				float deltaTime = GetDeltaTime(typingInfo);
				if (timeToWait < 0f)
				{
					timeToWait = 0f;
				}
				if (timeToWait < deltaTime)
				{
					typingInfo.timePassed += timeToWait;
					if (typingInfo.timePassed >= deltaTime)
					{
						yield return null;
						typingInfo.timePassed %= deltaTime;
					}
				}
				else
				{
					while (typingInfo.timePassed < timeToWait)
					{
						typingInfo.timePassed += deltaTime;
						yield return null;
						deltaTime = GetDeltaTime(typingInfo);
					}
					typingInfo.timePassed %= timeToWait;
				}
			}
			onTextDisappeared?.Invoke();
			isHidingText = false;
		}

		public void SetTypewriterSpeed(float value)
		{
			internalSpeed = Mathf.Clamp(value, 0.001f, value);
		}

		private void TriggerEventsBeforeAction(int maxIndex, ActionMarker action)
		{
			for (int i = latestEventTriggered; i < TextAnimator.Events.Length && TextAnimator.Events[i].index < maxIndex && TextAnimator.Events[i].internalOrder < action.internalOrder; i++)
			{
				onMessage?.Invoke(TextAnimator.Events[i]);
				latestEventTriggered = i + 1;
			}
		}

		private void TriggerEventsUntil(int maxIndex)
		{
			for (int i = latestEventTriggered; i < TextAnimator.Events.Length && TextAnimator.Events[i].index < maxIndex; i++)
			{
				onMessage?.Invoke(TextAnimator.Events[i]);
				latestEventTriggered = i + 1;
			}
		}

		public void TriggerRemainingEvents()
		{
			TriggerEventsUntil(int.MaxValue);
		}

		public void TriggerVisibleEvents()
		{
			TriggerEventsUntil(TextAnimator.latestCharacterShown.index);
		}

		protected virtual void OnEnable()
		{
			if (useTypeWriter && startTypewriterMode.HasFlag(StartTypewriterMode.OnEnable))
			{
				StartShowingText();
			}
		}

		protected virtual void OnDisable()
		{
		}
	}
}
