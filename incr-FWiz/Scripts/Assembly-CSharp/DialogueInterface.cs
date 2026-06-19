using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class DialogueInterface : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoSkipTimer_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DialogueInterface _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private float _003Ctimer_003E5__3;

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
		public _003CDoSkipTimer_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003CWriteOutCurrentLine_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DialogueInterface _003C_003E4__this;

		private string _003CfullText_003E5__2;

		private int _003CvisibleCharCount_003E5__3;

		private bool _003CinsideTag_003E5__4;

		private string _003CcurrentTag_003E5__5;

		private int _003CwriteCount_003E5__6;

		private int _003Ci_003E5__7;

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
		public _003CWriteOutCurrentLine_003Ed__36(int _003C_003E1__state)
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

	private int _currentLineIndex;

	private bool _writingLine;

	private bool _lineWritten;

	private Coroutine _writingLineCoroutine;

	private Coroutine _skipTimerCoroutine;

	[SerializeField]
	private TextMeshProUGUI _dialogueTextMesh;

	[SerializeField]
	private float _writeDialogueSpeed;

	[SerializeField]
	private ClickListener _clickListener;

	[SerializeField]
	private DialogueInterfaceCharacter _interfaceCharacter;

	public Action AnnounceStoryComplete;

	public EventReference NextLineSound;

	public EventReference StartSound;

	public EventReference TalkSound;

	public int CharactersPerTalkSound;

	[SerializeField]
	private Image _timerProgressImage;

	[SerializeField]
	private RectTransform _content;

	[SerializeField]
	private RectTransform _topContainer;

	[SerializeField]
	private RectTransform _bottomContainer;

	[SerializeField]
	private HoverDefaultCursorProvider _clickableCursorProvider;

	[SerializeField]
	private HoverDefaultCursorProvider _lockedCursorProvider;

	public DialogueStory CurrentStory { get; private set; }

	public int CurrentLineIndex => 0;

	private DialogueLine _currentLine => null;

	public void Initiate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void StartStory(DialogueStory story, int startLine = 0)
	{
	}

	public void OnClick()
	{
	}

	public void SetLine(int lineIndex)
	{
	}

	public void HandleNextLine()
	{
	}

	public void CompleteStory()
	{
	}

	[IteratorStateMachine(typeof(_003CWriteOutCurrentLine_003Ed__36))]
	private IEnumerator WriteOutCurrentLine()
	{
		return null;
	}

	private void ShowFullLine()
	{
	}

	public void OnLineCompleted()
	{
	}

	[IteratorStateMachine(typeof(_003CDoSkipTimer_003Ed__39))]
	public IEnumerator DoSkipTimer()
	{
		return null;
	}

	public string GetCurrentLineText()
	{
		return null;
	}

	private void OnLocaleChanged(Locale newLocale)
	{
	}
}
