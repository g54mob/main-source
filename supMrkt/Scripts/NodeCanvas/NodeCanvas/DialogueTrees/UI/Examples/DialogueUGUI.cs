using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.DialogueTrees.UI.Examples
{
	public class DialogueUGUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[Serializable]
		public class SubtitleDelays
		{
			public float characterDelay;

			public float sentenceDelay;

			public float commaDelay;

			public float finalDelay;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass32_0
		{
			public bool inputDown;

			internal void _003CInternal_OnSubtitlesRequestInfo_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CCheckInput_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DialogueUGUI _003C_003E4__this;

			public Action Do;

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
			public _003CCheckInput_003Ed__34(int _003C_003E1__state)
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
		private sealed class _003CCountDown_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DialogueUGUI _003C_003E4__this;

			public MultipleChoiceRequestInfo info;

			private float _003Ctimer_003E5__2;

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
			public _003CCountDown_003Ed__37(int _003C_003E1__state)
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
		private sealed class _003CDelayPrint_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			private float _003Ctimer_003E5__2;

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
			public _003CDelayPrint_003Ed__35(int _003C_003E1__state)
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
		private sealed class _003CInternal_OnSubtitlesRequestInfo_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SubtitlesRequestInfo info;

			public DialogueUGUI _003C_003E4__this;

			private _003C_003Ec__DisplayClass32_0 _003C_003E8__1;

			private string _003Ctext_003E5__2;

			private AudioClip _003Caudio_003E5__3;

			private float _003Ctimer_003E5__4;

			private string _003CtempText_003E5__5;

			private int _003Ci_003E5__6;

			private char _003Cc_003E5__7;

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
			public _003CInternal_OnSubtitlesRequestInfo_003Ed__32(int _003C_003E1__state)
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

		[Header("Input Options")]
		public bool skipOnInput;

		public bool waitForInput;

		[Header("Subtitles")]
		public RectTransform subtitlesGroup;

		public Text actorSpeech;

		public Text actorName;

		public Image actorPortrait;

		public RectTransform waitInputIndicator;

		public SubtitleDelays subtitleDelays;

		public List<AudioClip> typingSounds;

		private AudioSource playSource;

		[Header("Multiple Choice")]
		public RectTransform optionsGroup;

		public Button optionButton;

		private Dictionary<Button, int> cachedButtons;

		private Vector2 originalSubsPosition;

		private bool isWaitingChoice;

		private AudioSource _localSource;

		private bool anyKeyDown;

		private AudioSource localSource => null;

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		private void LateUpdate()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Subscribe()
		{
		}

		private void UnSubscribe()
		{
		}

		private void Hide()
		{
		}

		private void OnDialogueStarted(DialogueTree dlg)
		{
		}

		private void OnDialoguePaused(DialogueTree dlg)
		{
		}

		private void OnDialogueFinished(DialogueTree dlg)
		{
		}

		private void OnSubtitlesRequest(SubtitlesRequestInfo info)
		{
		}

		[IteratorStateMachine(typeof(_003CInternal_OnSubtitlesRequestInfo_003Ed__32))]
		private IEnumerator Internal_OnSubtitlesRequestInfo(SubtitlesRequestInfo info)
		{
			return null;
		}

		private void PlayTypeSound()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckInput_003Ed__34))]
		private IEnumerator CheckInput(Action Do)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayPrint_003Ed__35))]
		private IEnumerator DelayPrint(float time)
		{
			return null;
		}

		private void OnMultipleChoiceRequest(MultipleChoiceRequestInfo info)
		{
		}

		[IteratorStateMachine(typeof(_003CCountDown_003Ed__37))]
		private IEnumerator CountDown(MultipleChoiceRequestInfo info)
		{
			return null;
		}

		private void Finalize(MultipleChoiceRequestInfo info, int index)
		{
		}

		private void SetMassAlpha(RectTransform root, float alpha)
		{
		}
	}
}
