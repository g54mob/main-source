using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppTerminal : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateSelector_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppTerminal _003C_003E4__this;

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
		public _003CAnimateSelector_003Ed__27(int _003C_003E1__state)
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
	private sealed class _003CNewLine_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppTerminal _003C_003E4__this;

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
		public _003CNewLine_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003CRenderSelector_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppTerminal _003C_003E4__this;

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
		public _003CRenderSelector_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CScrollDown_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppTerminal _003C_003E4__this;

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
		public _003CScrollDown_003Ed__47(int _003C_003E1__state)
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

	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public DirectoryManager directoryManager;

	public ComputerVariables computerVariables;

	[Header("App Object")]
	public Transform applicationLayout;

	public GameObject iconBar;

	public GameObject iconBarHover;

	[Header("UI")]
	public ScrollRect scrollRect;

	public RectTransform content;

	public TMP_Text terminalView;

	public TMP_Text terminalViewSelector;

	public AppTerminalSelectable appTerminalSelectable;

	[Header("History")]
	public int nowSelectIdHistoryCommand;

	public List<string> HistoryCommand;

	[Header("Comand Bases")]
	public TerminalComandBase[] comandBases;

	[Header("Variable")]
	public Action<string> commandAnswer;

	public Action commandStop;

	private TerminalComandBase nowInCommane;

	public string textInTerminal;

	private Coroutine animCursor;

	public string terminalPrefix;

	[HideInInspector]
	public bool isOpen;

	[HideInInspector]
	public FileSystemObject currentDirectory;

	public int selectorPosition;

	private bool isSelectorVisible;

	private string lastTerminal;

	private int lastSelectorPosition;

	private Vector3 lastSelectorPositionV3;

	private void Update()
	{
	}

	public void Typing()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateSelector_003Ed__27))]
	private IEnumerator AnimateSelector()
	{
		return null;
	}

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void UnFocused()
	{
	}

	public void Focused()
	{
	}

	private void RunTerminal()
	{
	}

	public void CloseCommand()
	{
	}

	public void SetAnswer(Action<string> act, string answer)
	{
	}

	public void StopAnswer()
	{
	}

	public void SetActionStop(Action act)
	{
	}

	public void ClearActionStop()
	{
	}

	public void AddComandToHistory()
	{
	}

	private void TypingCommands()
	{
	}

	private void UpdateSelectorView(string editableText)
	{
	}

	[IteratorStateMachine(typeof(_003CRenderSelector_003Ed__44))]
	private IEnumerator RenderSelector()
	{
		return null;
	}

	private void UpdateTerminalText(string[] lines, string editableText)
	{
	}

	[IteratorStateMachine(typeof(_003CNewLine_003Ed__46))]
	private IEnumerator NewLine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CScrollDown_003Ed__47))]
	private IEnumerator ScrollDown()
	{
		return null;
	}

	private void ParseLastCommand()
	{
	}

	private void ParseAnswer()
	{
	}

	public void PrintInvalidParameter(string comm)
	{
	}

	public void PrintToManyParameters(string comm)
	{
	}

	public void PrintToUnknownError(string comm, string additionalDescription = "\n")
	{
	}

	private void PrintInvalidComand(string comm)
	{
	}

	public void PrintToConsole(string print, bool scrolldown = false)
	{
	}

	public void PrintNewLine()
	{
	}

	public static TerminalValidateComand ValidateComand(string comand, string[] variables, string[] param, TerminalComandBase terminalComandBase)
	{
		return null;
	}

	public bool ValidateComandRun(TerminalValidateComand terminalValidateComand)
	{
		return false;
	}
}
