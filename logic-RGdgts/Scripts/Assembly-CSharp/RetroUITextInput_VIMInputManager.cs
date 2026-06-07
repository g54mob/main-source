using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RetroUITextInput_VIMInputManager : RetroUITextInput_InputManager
{
	public enum Mode
	{
		Normal = 0,
		Insert = 1,
		Replace = 2,
		Command = 3
	}

	public class Context
	{
		public RetroUITextInput textInput;

		public RetroUITextInput_VIMInputManager inputManager;

		public int desiredColumn;

		public Mode mode;

		public string numericPrefix;

		public List<KeyPression> keyPressions;

		public InsertModeAction insertModeAction;

		private int insertModeActionCount;

		public List<KeyPression> insertModeKeyPressions;

		public ReplaceModeAction replaceModeAction;

		private int replaceModeActionCount;

		public List<KeyPression> replaceModeKeyPressions;

		public bool replaceModeIsSingle;

		public Tuple<Action, int> repeatAction;

		public string yankText;

		public Motion.Granularity yankGranularity;

		public string searchArgument;

		public int searchDirection;

		public Type lastActionType;

		public RetroUIText.TextCoord? lastCaretPosition;

		public bool clampLastChar => false;

		public void SetNormalMode()
		{
		}

		public void SetInsertMode()
		{
		}

		public void SetInsertMode(InsertModeAction action, int count)
		{
		}

		public void SetReplaceMode(bool isSingleReplace)
		{
		}

		public void SetReplaceMode(ReplaceModeAction action, int count)
		{
		}

		public void SetCommandMode()
		{
		}

		public void AddKeyPression(KeyPression keyPression)
		{
		}

		public void AppendNumericPrefix(char c)
		{
		}

		private void RefreshCommandBar()
		{
		}

		public void ClearKeyPressions()
		{
		}
	}

	public struct KeyPression
	{
		public KeyCode keyCode;

		public char c;

		public bool ctrl;

		public bool shift;

		public bool alt;

		public KeyPression(KeyCode keyCode)
		{
			this.keyCode = default(KeyCode);
			c = '\0';
			ctrl = false;
			shift = false;
			alt = false;
		}

		public KeyPression(char c)
		{
			keyCode = default(KeyCode);
			this.c = '\0';
			ctrl = false;
			shift = false;
			alt = false;
		}

		public KeyPression(Event evt)
		{
			keyCode = default(KeyCode);
			c = '\0';
			ctrl = false;
			shift = false;
			alt = false;
		}

		public static bool operator ==(KeyPression a, KeyCode keyCode)
		{
			return false;
		}

		public static bool operator !=(KeyPression a, KeyCode keyCode)
		{
			return false;
		}

		public static bool operator ==(KeyPression a, char c)
		{
			return false;
		}

		public static bool operator !=(KeyPression a, char c)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}

	private enum ParseResult
	{
		Ok = 0,
		Error = 1,
		Incomplete = 2
	}

	public abstract class Action
	{
		public abstract bool Execute(Context context, int count);
	}

	public abstract class InsertModeAction : Action
	{
		private List<KeyPression> pressedKeys;

		public abstract bool IsEditAction();

		public void OnInsertComplete(List<KeyPression> pressedKeys)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}

		protected abstract void Init(Context context);
	}

	public abstract class ReplaceModeAction : Action
	{
		private List<KeyPression> pressedKeys;

		public void OnReplaceComplete(List<KeyPression> pressedKeys)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}

		protected abstract void Init(Context context);

		public abstract void OnBeforeRepeat(Context context);

		public abstract bool IsSingleReplace();
	}

	public abstract class Motion : Action
	{
		public class Exception : System.Exception
		{
			public Exception()
			{
			}

			public Exception(string message)
			{
			}

			public Exception(string message, System.Exception inner)
			{
			}
		}

		public struct Result
		{
			public RetroUIText.TextCoord position;

			public int? desiredColumn;

			public Result(RetroUIText.TextCoord position, int? desiredColum = null)
			{
				this.position = default(RetroUIText.TextCoord);
				desiredColumn = null;
			}
		}

		public enum Granularity
		{
			Character = 0,
			Line = 1
		}

		public Granularity granularity;

		public abstract Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false);

		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private class Motion_Word : Motion
	{
		private int direction;

		public Motion_Word(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_WORD : Motion
	{
		private int direction;

		public Motion_WORD(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_EndWord : Motion
	{
		private int direction;

		public Motion_EndWord(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_EndWORD : Motion
	{
		private int direction;

		public Motion_EndWORD(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_ToChar : Motion
	{
		private char ch;

		private int direction;

		public Motion_ToChar(char ch, int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_ToLine : Motion
	{
		private int line;

		public Motion_ToLine(int line)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_LastNonWhiteOnLine : Motion
	{
		private int direction;

		public Motion_LastNonWhiteOnLine(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_LastOnScreenLine : Motion
	{
		private int direction;

		public Motion_LastOnScreenLine(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_LastNonWhiteOnScreenLine : Motion
	{
		private int direction;

		public Motion_LastNonWhiteOnScreenLine(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_FirstOnLine : Motion
	{
		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_LastOnLine : Motion
	{
		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_Left : Motion
	{
		private bool canOverflow;

		public Motion_Left(bool canOverflow = false)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_Right : Motion
	{
		private bool canOverflow;

		public Motion_Right(bool canOverflow = false)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_Up : Motion
	{
		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_Down : Motion
	{
		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Motion_Search : Motion
	{
		private int direction;

		public Motion_Search(int direction)
		{
		}

		public override Result GetInputFieldPosition(Context context, RetroUIText.TextCoord originPosition, bool isSelection = false)
		{
			return default(Result);
		}
	}

	private class Action_Insert : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_INSERT : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_Append : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_APPEND : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_NewLine : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_NEWLINE : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_Substitute : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_SubstituteLine : InsertModeAction
	{
		public override bool IsEditAction()
		{
			return false;
		}

		protected override void Init(Context context)
		{
		}
	}

	private class Action_ReplaceSingle : ReplaceModeAction
	{
		protected override void Init(Context context)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}

		public override void OnBeforeRepeat(Context context)
		{
		}

		public override bool IsSingleReplace()
		{
			return false;
		}
	}

	private class Action_ReplaceMultiple : ReplaceModeAction
	{
		protected override void Init(Context context)
		{
		}

		public override void OnBeforeRepeat(Context context)
		{
		}

		public override bool IsSingleReplace()
		{
			return false;
		}
	}

	private class Action_DeleteKey : Action
	{
		private bool canOverflow;

		private bool yank;

		public Action_DeleteKey(bool canOverflow, bool yank)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private class Action_BackspaceKey : Action
	{
		private bool canOverflow;

		private bool yank;

		public Action_BackspaceKey(bool canOverflow, bool yank)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private class Action_Delete : Action
	{
		private Motion motion;

		private int motionCount;

		public Action_Delete(Motion motion, int motionCount)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private class Action_DeleteLine : Action
	{
		public override bool Execute(Context context, int count)
		{
			return false;
		}

		private bool Execute(Context context)
		{
			return false;
		}
	}

	private class Action_Yank : Action
	{
		private Motion motion;

		private int motionCount;

		public Action_Yank(Motion motion, int motionCount)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private class Action_YankLine : Action
	{
		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private class Action_Paste : Action
	{
		private int direction;

		public Action_Paste(int direction)
		{
		}

		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private abstract class Command
	{
		public abstract bool Execute(Context context);
	}

	private class Command_Substitute : Command
	{
		private int startLine;

		private int endLine;

		private string searchPattern;

		private string replaceWith;

		private string mode;

		public Command_Substitute(int startLine, int endLine, string searchPattern, string replaceWith, string mode)
		{
		}

		public override bool Execute(Context context)
		{
			return false;
		}
	}

	private class Action_Undo : Action
	{
		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private class Action_Redo : Action
	{
		public override bool Execute(Context context, int count)
		{
			return false;
		}
	}

	private Context context;

	private HashSet<KeyCode> wantedKeycodes;

	public RetroUITextInput_VIMInputManager(RetroUITextInput textInput, IListener listener)
	{
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}

	public override void OnUpdateSelected(BaseEventData eventData)
	{
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
	}

	public override void OnDrag(PointerEventData eventData)
	{
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	public override bool CommandEvent(Event m_ProcessingEvent)
	{
		return false;
	}

	public override void OnSetReadOnly(bool readOnly)
	{
	}

	public override void OnEndEditCommandBar()
	{
	}

	public override void OnSubmitCommandBar(string text)
	{
	}

	public override RetroUITextInput.EditState KeyPressed(Event evt)
	{
		return default(RetroUITextInput.EditState);
	}

	public RetroUITextInput.EditState KeyPressed_NormalMode(Event evt)
	{
		return default(RetroUITextInput.EditState);
	}

	public RetroUITextInput.EditState KeyPressed_InsertMode(KeyPression keyPression, bool automaticInput)
	{
		return default(RetroUITextInput.EditState);
	}

	public RetroUITextInput.EditState KeyPressed_ReplaceMode(KeyPression keyPression, bool singleReplace, bool automaticInput)
	{
		return default(RetroUITextInput.EditState);
	}

	public RetroUITextInput.EditState KeyPressed_CommandMode(Event evt)
	{
		return default(RetroUITextInput.EditState);
	}

	private ParseResult ParseAction(IEnumerable<KeyPression> keyPressions, out Action action, out int count)
	{
		action = null;
		count = default(int);
		return default(ParseResult);
	}
}
