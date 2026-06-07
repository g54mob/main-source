using System;
using System.Collections.Generic;
using Febucci.TextAnimatorCore;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Settings;
using Febucci.TextAnimatorCore.Text;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorForUnity.Actions;
using UnityEngine;
using UnityEngine.Events;

namespace Febucci.TextAnimatorForUnity
{
	[DisallowMultipleComponent]
	public class TypewriterComponent : MonoBehaviour, ITypewriterProvider, ISettingsProvider<TypewriterSettings>, IDatabaseProvider<ITypewriterAction>
	{
		internal ITextAnimatorProvider textAnimatorProvider;

		[SerializeField]
		public TypingsTimingsScriptableBase timingsScriptableBase;

		private TypewriterCore _wrapper;

		[SerializeField]
		private ActionDatabase actionsDatabase;

		[SerializeField]
		public UnityTypewriterSettings localSettings;

		[SerializeField]
		public TypewriterSettingsScriptable sharedSettings;

		private bool initialized;

		private TextAnimatorComponentBase _textAnimator;

		public UnityEvent onTextShowed = new UnityEvent();

		public UnityEvent onTypewriterStart = new UnityEvent();

		public UnityEvent onTextDisappeared = new UnityEvent();

		public CharacterEvent onCharacterVisible = new CharacterEvent();

		public CharacterWaitEvent onCharacterWaitStarted = new CharacterWaitEvent();

		public CharacterWaitEvent onCharacterWaitFinished = new CharacterWaitEvent();

		public MessageEvent onMessage = new MessageEvent();

		private Coroutine hideRoutine;

		private Coroutine nestedHideRoutine;

		private TypewriterCore Wrapper
		{
			get
			{
				InitializeOnce();
				return _wrapper;
			}
		}

		public Dictionary<string, ITypewriterAction> Database { get; private set; }

		TypewriterSettings ISettingsProvider<TypewriterSettings>.Settings
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

		public TextAnimatorComponentBase TextAnimator
		{
			get
			{
				if (_textAnimator != null)
				{
					return _textAnimator;
				}
				if (!TryGetComponent<TextAnimatorComponentBase>(out _textAnimator))
				{
					Debug.LogError("TextAnimator: Text Animator component is null on GameObject " + base.gameObject.name + ". Please add a component that inherits from TAnimCore");
				}
				_textAnimator.TryInitializingOnce();
				return _textAnimator;
			}
		}

		[Obsolete("Please access localSettings or the referenced scriptable instead")]
		public bool useTypeWriter => localSettings.useTypeWriter;

		[Obsolete("Please access localSettings or the referenced scriptable instead")]
		public StartTypewriterMode startTypewriterMode => localSettings.startTypewriterMode;

		[Obsolete("Please access localSettings or the referenced scriptable instead")]
		public bool hideAppearancesOnSkip => localSettings.hideAppearancesOnSkip;

		[Obsolete("Please access localSettings or the referenced scriptable instead")]
		public bool hideDisappearancesOnSkip => localSettings.hideDisappearancesOnSkip;

		[Obsolete("Please access localSettings or the referenced scriptable instead")]
		public DisappearanceOrientation disappearanceOrientation => localSettings.disappearanceOrientation;

		[Tooltip("True if you want to wait for every single character appearance to finish before triggering 'onTextShowed'. Default to false, as effects are usually fast enough and make the letters visible, and users are able to read them instantly.")]
		[Obsolete("Please access localSettings or the referenced scriptable instead")]
		public bool triggerShowedAfterEffectsEnd => localSettings.triggerDisappearedAfterEffectsEnd;

		[Tooltip("True if you want to wait for every single character disappearance to finish before triggering 'onTextDisappeared'. Default to false, as effects are usually fast enough")]
		[Obsolete("Please access localSettings or the referenced scriptable instead")]
		public bool triggerDisappearedAfterEffectsEnd => localSettings.triggerDisappearedAfterEffectsEnd;

		public bool IsShowingText => Wrapper.IsShowingText;

		public bool IsHidingText => Wrapper.IsHidingText;

		[Obsolete("Use IsHidingText instead")]
		public bool isHidingText => IsHidingText;

		[Obsolete("Please use IsShowingText")]
		public bool isShowingText => IsShowingText;

		private void Awake()
		{
			InitializeOnce();
		}

		private void InitializeOnce()
		{
			if (!initialized && (textAnimatorProvider != null || TryGetComponent<ITextAnimatorProvider>(out textAnimatorProvider)))
			{
				Database = new Dictionary<string, ITypewriterAction>();
				ITypewriterAction[] components = GetComponents<ITypewriterAction>();
				foreach (ITypewriterAction typewriterAction in components)
				{
					Database.TryAdd(typewriterAction.TagID, typewriterAction);
				}
				textAnimatorProvider.TryInitializingOnce();
				TextAnimator textAnimator = textAnimatorProvider.TextAnimator;
				_wrapper = new TypewriterCore(textAnimator, this, timingsScriptableBase, TextAnimatorSettings.Instance, this, new IDatabaseProvider<ITypewriterAction>[3]
				{
					this,
					GlobalActionComponentsDatabase.Instance,
					actionsDatabase
				}, OnBeforeShowingCharacter, OnAfterWaitingCharacter);
				_wrapper.OnTextShowed += delegate
				{
					onTextShowed?.Invoke();
				};
				_wrapper.OnTextDisappeared += delegate
				{
					onTextDisappeared?.Invoke();
				};
				_wrapper.OnTypewriterStart += delegate
				{
					onTypewriterStart?.Invoke();
				};
				_wrapper.OnMessage += delegate(EventMarker x)
				{
					onMessage?.Invoke(x);
				};
				_wrapper.OnCharacterWaitStarted += delegate(CharacterData character, WaitMode mode)
				{
					onCharacterWaitStarted?.Invoke(character, mode);
				};
				_wrapper.OnCharacterWaitFinished += delegate(CharacterData character, WaitMode mode)
				{
					onCharacterWaitFinished?.Invoke(character, mode);
				};
				_wrapper.OnCharacterVisible += delegate(CharacterData x)
				{
					onCharacterVisible?.Invoke(x);
				};
				_wrapper.ShowText(textAnimator.TextFull);
				initialized = true;
			}
		}

		internal void AssignAnimator(ITextAnimatorProvider animator, ActionDatabase actionsDatabase, TypingsTimingsScriptableBase timingsScriptableBase)
		{
			if (textAnimatorProvider != animator)
			{
				this.actionsDatabase = actionsDatabase;
				textAnimatorProvider = animator;
				_wrapper?.Dispose();
				initialized = false;
				InitializeOnce();
			}
		}

		public void ShowText(string text)
		{
			Wrapper.ShowText(text);
		}

		public void SkipTypewriter()
		{
			Wrapper.SkipTypewriter();
		}

		[ContextMenu("Start Showing Text")]
		public void StartShowingText()
		{
			StartShowingText(restart: false);
		}

		public void StartShowingText(bool restart)
		{
			Wrapper.StartShowingText(restart);
		}

		[ContextMenu("Stop Showing Text")]
		public void StopShowingText()
		{
			Wrapper?.StopShowingText();
		}

		[ContextMenu("Start Disappearing Text")]
		public void StartDisappearingText()
		{
			Wrapper?.StartDisappearingText();
		}

		[ContextMenu("Stop Disappearing Text")]
		public void StopDisappearingText()
		{
			Wrapper?.StopDisappearingText();
		}

		public void SetTypewriterSpeed(float value)
		{
			Wrapper.SetTypewriterSpeed(value);
		}

		public void TriggerRemainingEvents()
		{
			Wrapper.TriggerRemainingEvents();
		}

		public void TriggerVisibleEvents()
		{
			Wrapper.TriggerVisibleEvents();
		}

		protected virtual ActionStatus OnBeforeShowingCharacter(CharacterData character)
		{
			return ActionStatus.Finished;
		}

		protected virtual ActionStatus OnAfterWaitingCharacter(CharacterData character)
		{
			return ActionStatus.Finished;
		}

		protected virtual void OnEnable()
		{
			if (initialized && localSettings.useTypeWriter && localSettings.startTypewriterMode.HasFlag(StartTypewriterMode.OnEnable))
			{
				StartShowingText();
			}
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
			_wrapper?.Dispose();
			initialized = false;
		}
	}
}
