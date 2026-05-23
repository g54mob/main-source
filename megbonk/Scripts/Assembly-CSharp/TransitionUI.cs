using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoTransition_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TransitionUI _003C_003E4__this;

		public float newTransitionTime;

		public float delay;

		public Action action;

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
		public _003CDoTransition_003Ed__13(int _003C_003E1__state)
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
	private sealed class _003CEndTransition_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TransitionUI _003C_003E4__this;

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
		public _003CEndTransition_003Ed__15(int _003C_003E1__state)
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

	public RawImage overlay;

	private float transitionTime;

	public static TransitionUI Instance;

	public bool isTransitioning;

	public static Action A_transitionEnd;

	public static Action A_transitionStart;

	public static Action A_MapTransitionStart;

	private string sceneMainMenuName;

	private float fadeInTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void LoadMenu()
	{
	}

	public void StartLoadingMap(string mapName)
	{
	}

	public void StartTransition(Action action, float transitionTime = 0.5f, float delay = 0.5f)
	{
	}

	[IteratorStateMachine(typeof(_003CDoTransition_003Ed__13))]
	private IEnumerator DoTransition(Action action, float newTransitionTime, float delay = 0.5f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CEndTransition_003Ed__15))]
	private IEnumerator EndTransition()
	{
		return null;
	}

	public void StopTransition()
	{
	}

	public bool IsTransitioning()
	{
		return false;
	}

	private void OnNewSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
	}

	public float GetTransitionTime()
	{
		return 0f;
	}
}
