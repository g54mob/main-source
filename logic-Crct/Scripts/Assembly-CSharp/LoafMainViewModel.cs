using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CLanguage;
using CLanguage.Syntax;
using Loaf;
using Noesis;
using UnityEngine;

public class LoafMainViewModel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_HexEditorWindowLoader_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Grid Container;

		public HexEntryLine[] hels;

		private int _003Ci_003E5__2;

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
		public _003C_HexEditorWindowLoader_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003C_003Ec__DisplayClass58_0
	{
		public string code;

		public MachineInfo machine;

		public bool done;

		internal void _003C_Colorize_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_Colorize_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string code;

		public MachineInfo machine;

		private _003C_003Ec__DisplayClass58_0 _003C_003E8__1;

		public Action callback;

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
		public _003C_Colorize_003Ed__58(int _003C_003E1__state)
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

	public static LoafMainViewModel inst;

	[Header("Scaling")]
	public NoesisView[] allViews;

	public static bool DPIAuto;

	public static float UIScale;

	[Header("Code Editor")]
	public UnityEngine.Color[] codeColors;

	public NoesisView mainView;

	[Header("Settings")]
	public NoesisView settingsView;

	public Light sceneLight;

	public float keyboardMoveSpeed;

	[Header("File Operations")]
	public NoesisView checkDialogView;

	public NoesisView openDesignWindow;

	public NoesisEventCommand _newDesignCommand;

	public NoesisEventCommand _openDesignCommand;

	public NoesisEventCommand _saveDesignCommand;

	public NoesisEventCommand _saveDesignAsCommand;

	public NoesisEventCommand _undoCommand;

	public NoesisEventCommand _redoCommand;

	public static ColorSpan[] Spans;

	public static UnityEngine.Color[] CodeColours => null;

	public static Light SceneLight => null;

	public NoesisEventCommand NewDesignCommand => null;

	public NoesisEventCommand OpenDesignCommand => null;

	public NoesisEventCommand SaveDesignCommand => null;

	public NoesisEventCommand SaveDesignAsCommand => null;

	public NoesisEventCommand UndoCommand => null;

	public NoesisEventCommand RedoCommand => null;

	public static void UpdateUIScale()
	{
	}

	private void Start()
	{
	}

	public static void OpenSettings()
	{
	}

	public static void CloseSettings()
	{
	}

	public void Update()
	{
	}

	public static void HexEditorWindowLoader(Grid Container, HexEntryLine[] hels)
	{
	}

	[IteratorStateMachine(typeof(_003C_HexEditorWindowLoader_003Ed__39))]
	private IEnumerator _HexEditorWindowLoader(Grid Container, HexEntryLine[] hels)
	{
		return null;
	}

	public void NewDesignedPressed()
	{
	}

	public static void ClosePressed()
	{
	}

	public static void CheckNewMainCode(Action confirmAction)
	{
	}

	private void checkNewMainCode(Action confirmAction)
	{
	}

	public static void CheckOpenMainCode(Action confirmAction)
	{
	}

	private void checkOpenMainCode(Action confirmAction)
	{
	}

	public static void CheckSaveSourceFile(Action confirmAction)
	{
	}

	private void checkSaveSourceFile(Action confirmAction)
	{
	}

	private void CloseCodeCheckDialog()
	{
	}

	private void ConfirmNewDesign()
	{
	}

	public void OpenDesignedPressed()
	{
	}

	public void SaveDesignPressed()
	{
	}

	public void SaveDesignAsPressed()
	{
	}

	private void ConfirmOpenDesign()
	{
	}

	public static void CloseOpenDesignWindow()
	{
	}

	private void CloseCheckDialog()
	{
	}

	public static void Colorize(string code, MachineInfo machine, Action callback)
	{
	}

	[IteratorStateMachine(typeof(_003C_Colorize_003Ed__58))]
	private IEnumerator _Colorize(string code, MachineInfo machine, Action callback)
	{
		return null;
	}
}
