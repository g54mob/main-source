using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Components.Writer;
using TMPEffects.Databases;
using TMPEffects.Databases.CommandDatabase;
using TMPEffects.EffectCategories;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPCommands;
using TMPEffects.TMPEvents;
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
			public float delay;

			public float whitespaceDelay;

			public DelayType whitespaceDelayType;

			public float linebreakDelay;

			public DelayType linebreakDelayType;

			public float punctuationDelay;

			public DelayType punctuationDelayType;

			public float visibleDelay;

			public DelayType visibleDelayType;

			public float CalculatedWhiteSpaceDelay => 0f;

			public float CalculatedPunctuationDelay => 0f;

			public float CalculatedVisibleDelay => 0f;

			public float CalculatedLinebreakDelay => 0f;

			public void SetDelay(float delay)
			{
			}

			public void SetWhitespaceDelay(float delay, DelayType? type = null)
			{
			}

			public void SetLinebreakDelay(float delay, DelayType? type = null)
			{
			}

			public void SetVisibleDelay(float delay, DelayType? type = null)
			{
			}

			public void SetPunctuationDelay(float delay, DelayType? type = null)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass102_0
		{
			public float tempTime;

			public float excessWaitedTime;

			public bool prevScaled;

			public TMPWriter _003C_003E4__this;

			public float prevTime;
		}

		[CompilerGenerated]
		private sealed class _003CHandleWaitConditions_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TMPWriter _003C_003E4__this;

			private bool _003CallMet_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CHandleWaitConditions_003Ed__107(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRaiseInvokablesCoroutine_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TMPWriter _003C_003E4__this;

			public int index;

			public bool skipped;

			public bool block;

			private IEnumerator<ICachedInvokable> _003C_003E7__wrap1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRaiseInvokablesCoroutine_003Ed__110(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRaiseInvokablesCoroutine_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TMPWriter _003C_003E4__this;

			public IEnumerable<ICachedInvokable> invokables;

			public bool block;

			private IEnumerator<ICachedInvokable> _003C_003E7__wrap1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRaiseInvokablesCoroutine_003Ed__111(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWriterCoroutine_003Ed__102 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TMPWriter _003C_003E4__this;

			private _003C_003Ec__DisplayClass102_0 _003C_003E8__1;

			private CharData _003CcData_003E5__2;

			private IEnumerator<ICachedInvokable> _003C_003E7__wrap2;

			private int _003Ci_003E5__4;

			private float _003Cdelay_003E5__5;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWriterCoroutine_003Ed__102(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
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
		private bool maySkip;

		[SerializeField]
		private bool writeOnStart;

		[SerializeField]
		private bool writeOnNewText;

		[SerializeField]
		private bool useScaledTime;

		[SerializeField]
		private Delays delays;

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
		private int currentIndex;

		[NonSerialized]
		private bool tagsChanged;

		public bool IsWriting => false;

		public bool MaySkip => false;

		public int CurrentIndex => 0;

		public TMPCommandDatabase Database => null;

		public ITMPKeywordDatabase KeywordDatabase => null;

		public IDictionary<string, TMPSceneCommandWrapper> SceneCommands => null;

		public ITagCollection Tags => null;

		public ITagCollection CommandTags => null;

		public ITagCollection EventTags => null;

		public bool WriteOnStart
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool WriteOnNewText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseScaledTime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Delays DefaultDelays => null;

		public Delays CurrentDelays => null;

		public void StartWriter()
		{
		}

		public void StopWriter()
		{
		}

		public void ResetWriter()
		{
		}

		public void ResetWriter(int index)
		{
		}

		public void SkipWriter(bool skipShowAnimation = true)
		{
		}

		public void RestartWriter()
		{
		}

		public void Wait(float seconds)
		{
		}

		public void ResetWaitPeriod()
		{
		}

		public void WaitUntil(Func<bool> condition)
		{
		}

		public void ResetWaitConditions()
		{
		}

		public void SetSkippable(bool skippable)
		{
		}

		public void SetDatabase(TMPCommandDatabase database)
		{
		}

		public void SetSceneKeywordDatabase(TMPSceneKeywordDatabase database)
		{
		}

		public void SetKeywordDatabase(TMPKeywordDatabase database)
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void PrepareForProcessing()
		{
		}

		private void SubscribeToMediator()
		{
		}

		private void UnsubscribeFromMediator()
		{
		}

		private void OnDatabaseChanged()
		{
		}

		private void ReprocessOnDatabaseChange(object sender)
		{
		}

		private void OnTextChanged_Early(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData)
		{
		}

		private void OnTextChanged_Late(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData, ReadOnlyCollection<VisibilityState> oldVisibilities)
		{
		}

		private void RaiseCharacterShownEvent(CharData cData)
		{
		}

		private void RaiseResetWriterEvent(int index)
		{
		}

		private void RaiseFinishWriterEvent()
		{
		}

		private void RaiseStartWriterEvent()
		{
		}

		private void RaiseStopWriterEvent()
		{
		}

		private void RaiseWaitStartedEvent(float waitAmount)
		{
		}

		private void RaiseWaitEndedEvent()
		{
		}

		private void RaiseSkipWriterEvent(int index)
		{
		}

		private void StartWriterCoroutine()
		{
		}

		private void StopWriterCoroutine()
		{
		}

		[IteratorStateMachine(typeof(_003CWriterCoroutine_003Ed__102))]
		private IEnumerator WriterCoroutine()
		{
			return null;
		}

		private void ResetInternalState()
		{
		}

		private void ResetData()
		{
		}

		private void ResetInvokables(int maxIndex)
		{
		}

		private float CalculateDelay(int index)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CHandleWaitConditions_003Ed__107))]
		private IEnumerator HandleWaitConditions()
		{
			return null;
		}

		private IEnumerable<ICachedInvokable> GetInvokables(int index, bool skipped = false)
		{
			return null;
		}

		private void RaiseInvokables(int index, bool skipped = false)
		{
		}

		[IteratorStateMachine(typeof(_003CRaiseInvokablesCoroutine_003Ed__110))]
		private IEnumerator RaiseInvokablesCoroutine(int index, bool skipped = false, bool block = true)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRaiseInvokablesCoroutine_003Ed__111))]
		private IEnumerator RaiseInvokablesCoroutine(IEnumerable<ICachedInvokable> invokables, bool block = true)
		{
			return null;
		}

		private void OnStopWriting()
		{
		}

		private void OnStartWriting()
		{
		}

		private void HideAllCharacters(bool skipAnimations = false)
		{
		}

		private void PostProcessTags()
		{
		}
	}
}
