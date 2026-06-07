using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using CLanguage.Interpreter;
using CLanguage.Tests;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodeEditor : MonoBehaviour
{
	[Serializable]
	public struct UndoRedoMemento
	{
		public int pos;

		public string str;

		public UndoRedoMemento(int p, string s)
		{
			pos = 0;
			str = null;
		}
	}

	public enum ShiftState
	{
		Off = 0,
		Next = 1,
		Lock = 2
	}

	[CompilerGenerated]
	private sealed class _003CWaitOpenEditor_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScreenOrientation o;

		public CodeEditor _003C_003E4__this;

		private int _003Cwidth_003E5__2;

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
		public _003CWaitOpenEditor_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003C_DisplayKeyboard_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CodeEditor _003C_003E4__this;

		public bool display;

		private float _003Ct_003E5__2;

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
		public _003C_DisplayKeyboard_003Ed__67(int _003C_003E1__state)
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

	private static CodeEditor inst;

	public List<UndoRedoMemento> undoStack;

	public List<UndoRedoMemento> redoStack;

	public MicroController mc;

	[Header("Display")]
	public GameObject editorObject;

	public RectTransform editorTransform;

	public RectTransform canvasTransform;

	[Header("Orientation Change")]
	public GameObject waitCanvasObj;

	private List<string> undoStrings;

	private string copiedString;

	[Header("Save/Load")]
	public GameObject saveDialog;

	public TMP_InputField saveInput;

	public Text fileNameHeading;

	public string prevFileName;

	public GameObject cFileDisplay;

	private string[] cList;

	public Transform cListContentTransform;

	public GameObject cListTemplate;

	public GameObject noSavedC;

	public GameObject deleteDialogObject;

	public static int pendingId;

	private bool saveOpen;

	[Header("Keyboard")]
	public RectTransform codeViewport;

	public RectTransform keyboard;

	public Vector2 keyboardBasePosition;

	public Vector2 keyboardOpenPosition;

	public Vector2 baseOffsetMin;

	public Vector2 keyboardOpenOffsetMin;

	public AnimationCurve easingCurve;

	public float displaySpeed;

	private bool keyboardDisplayed;

	private bool transitioning;

	public float lostFocusDelay;

	public float lfT;

	public float lfTime;

	[Header("Keyboard Types")]
	public int keyboardType;

	public GameObject[] keyboards;

	public Image[] keyboardTabs;

	public TextMeshProUGUI[] keyboardHeadings;

	public Color keyboardTabOn;

	public Color keyboardTabOff;

	public Color keyboardHeadingOn;

	public Color keyboardHeadingOff;

	private string rawCode;

	public Color[] colors;

	public TMP_InputField input;

	public TextMeshProUGUI hiddenText;

	public TextMeshProUGUI displayText;

	public TextMeshProUGUI lineNumbersText;

	public RectTransform contentTr;

	private ArduinoMachine machine;

	private int indent;

	private StringBuilder sb;

	public Text keyText;

	[Header("UndoRedo")]
	public Button undoBtn;

	public Button redoBtn;

	[Header("Shift Function")]
	public Image shiftImage;

	public Sprite[] shiftImages;

	public TextMeshProUGUI[] alphabetKeyTexts;

	public ShiftState shiftState;

	public float shiftLockTap;

	private float shiftT;

	[Header("Compilation")]
	public GameObject successObj;

	public GameObject failObj;

	public TextMeshProUGUI errorText;

	private CompilePrinter printer;

	public RectTransform linePoint;

	public float lineHeight;

	public RectTransform debug;

	public Vector2 clickPos;

	public float angle;

	public Vector3 pivot;

	private CInterpreter i;

	public void Open(MicroController m)
	{
	}

	public void CopyClicked()
	{
	}

	public void PasteClicked()
	{
	}

	public void LoadFileList()
	{
	}

	private void PopulateCList()
	{
	}

	public static void DeleteClicked(int id)
	{
	}

	public static void LoadCData(int id, string name)
	{
	}

	public static void LoadCData(string path)
	{
	}

	public void CancelDelete()
	{
	}

	public void ConfirmDelete()
	{
	}

	public void CloseCFileList()
	{
	}

	public void ImportClicked()
	{
	}

	public void SaveClicked()
	{
	}

	public void CloseSave()
	{
	}

	public void SaveFile()
	{
	}

	public void RemoveIllegalNameCharacters()
	{
	}

	public void ReferenceClicked()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitOpenEditor_003Ed__40))]
	private IEnumerator WaitOpenEditor(ScreenOrientation o)
	{
		return null;
	}

	public void Close()
	{
	}

	public void UpdateKeyboards(int t)
	{
	}

	private void Awake()
	{
	}

	public void InputSelect()
	{
	}

	public void CloseKeyboard()
	{
	}

	[IteratorStateMachine(typeof(_003C_DisplayKeyboard_003Ed__67))]
	private IEnumerator _DisplayKeyboard(bool display)
	{
		return null;
	}

	public void OnValueChanged()
	{
	}

	public void OnEndEdit()
	{
	}

	private string FormatIndents(string code)
	{
		return null;
	}

	public void KeepSelected()
	{
	}

	private void UpdateLineNumbers()
	{
	}

	private void AddUndo(int p, string s, bool redo = false)
	{
	}

	public void Undo()
	{
	}

	public void Redo()
	{
	}

	public void ShiftClicked()
	{
	}

	public void SendKey(string key)
	{
	}

	public void CompileButton()
	{
	}

	public void ShowSuccess()
	{
	}

	public void CloseSuccess()
	{
	}

	public void ShowFail()
	{
	}

	public void CloseFail()
	{
	}

	public void MoveContentToSafeArea()
	{
	}

	public void ClickedText(BaseEventData data)
	{
	}

	public void RefreshLineNumbers()
	{
	}
}
