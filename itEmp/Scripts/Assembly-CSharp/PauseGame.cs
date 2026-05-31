using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimEnterPause_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PauseGame _003C_003E4__this;

		public string mode;

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
		public _003CAnimEnterPause_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CAnimExitPause_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PauseGame _003C_003E4__this;

		public bool stepAwayDevice;

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
		public _003CAnimExitPause_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CChangeBlurIntensity_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PauseGame _003C_003E4__this;

		public bool stepAwayDevice;

		public float target;

		public float time;

		private float _003CstartValue_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CChangeBlurIntensity_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003CChangeCanvasAlpha_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PauseGame _003C_003E4__this;

		public bool stepAwayDevice;

		public float target;

		public float time;

		private float _003CstartValue_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CChangeCanvasAlpha_003Ed__21(int _003C_003E1__state)
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

	public static PauseGame Instance;

	[Header("Components")]
	public UIBlur blur;

	public TaskManager taskManager;

	[Header("UI")]
	public RectTransform rectPause;

	public CanvasGroup canvasGroup;

	[Header("Variable")]
	public float timeAnimation;

	public bool isPaused;

	[Header("Animation")]
	public bool isAnimate;

	private Coroutine animationCoroutine;

	[Header("Menu")]
	public string nowOpen;

	public PauseGameSubMenuData[] menu;

	private DefaultInterfaceSettings lastBlockPlayerData;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public bool IsOpen()
	{
		return false;
	}

	public void Interact(string mode = "")
	{
	}

	public void TogglePause(string mode = "")
	{
	}

	[IteratorStateMachine(typeof(_003CAnimEnterPause_003Ed__17))]
	public IEnumerator AnimEnterPause(string mode = "")
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimExitPause_003Ed__18))]
	public IEnumerator AnimExitPause(bool stepAwayDevice = false)
	{
		return null;
	}

	public void StepAwayDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CChangeBlurIntensity_003Ed__20))]
	public IEnumerator ChangeBlurIntensity(float target, float time, bool stepAwayDevice = false)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CChangeCanvasAlpha_003Ed__21))]
	public IEnumerator ChangeCanvasAlpha(float target, float time, bool stepAwayDevice = false)
	{
		return null;
	}

	public void ButtonResume()
	{
	}

	public void ButtonExitGame()
	{
	}

	public void ButtonMainMenu()
	{
	}

	public void LoadScene(string sceneName)
	{
	}

	public void OpenMenu(string _menu)
	{
	}

	public void MinimalizeMenu(string _menu)
	{
	}
}
