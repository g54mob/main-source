using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Level1EndDay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCanvasGroupFadeAnimation_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public CanvasGroup canvasGroup;

		public float time;

		public TypeAnim animationType;

		public float targetAlpha;

		private float _003CstartAlpha_003E5__2;

		private float _003Celapsed_003E5__3;

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
		public _003CCanvasGroupFadeAnimation_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003CDoneAnim_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tutorial_Level1EndDay _003C_003E4__this;

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
		public _003CDoneAnim_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003CStopTut_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tutorial_Level1EndDay _003C_003E4__this;

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
		public _003CStopTut_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003CWaitForLoad_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tutorial_Level1EndDay _003C_003E4__this;

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
		public _003CWaitForLoad_003Ed__17(int _003C_003E1__state)
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

	[Header("UI")]
	public CanvasGroup tutorialBG;

	public CanvasGroup tutorialTX;

	public RectTransform tutorialArea;

	public DropShadow tutorialDropShadown;

	[Header("Component")]
	public TutorialManager tutorialManager;

	public PauseGame pauseGame;

	public EndingDay endingDay;

	public PlayerInventory playerInventory;

	[Header("Steps")]
	public int nowStep;

	public TutorialStepData[] tutorialStepData;

	private bool doneAnim;

	public bool updateTutorial;

	private bool isViewTutorial;

	public bool isCloseTutorial;

	public string lastText;

	private void OnValidate()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForLoad_003Ed__17))]
	private IEnumerator WaitForLoad()
	{
		return null;
	}

	private void Update()
	{
	}

	public string PrefixTimeInfo()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CStopTut_003Ed__20))]
	private IEnumerator StopTut()
	{
		return null;
	}

	private string TextDown(string text, bool value)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDoneAnim_003Ed__22))]
	private IEnumerator DoneAnim()
	{
		return null;
	}

	public void Step_FireYet_Update()
	{
	}

	private void Step_FireYet_InfoView()
	{
	}

	public void Step_Inventory_Update()
	{
	}

	private void Step_Inventory_InfoView()
	{
	}

	public void Step_locker_Update()
	{
	}

	private bool EmptyInventroy()
	{
		return false;
	}

	private void Step_locker_InfoView()
	{
	}

	public void Step_GoToAntiTheftGates_Update()
	{
	}

	private void Step_GoToAntiTheftGates_InfoView()
	{
	}

	public void Step_EndDay_Update()
	{
	}

	private void Step_EndDay_InfoView()
	{
	}

	[IteratorStateMachine(typeof(_003CCanvasGroupFadeAnimation_003Ed__34))]
	public IEnumerator CanvasGroupFadeAnimation(CanvasGroup canvasGroup, float targetAlpha, float time, float delay, TypeAnim animationType)
	{
		return null;
	}
}
