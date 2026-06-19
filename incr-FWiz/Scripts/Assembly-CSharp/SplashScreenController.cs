using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public bool showingSplash;

		internal void _003CDoSplashScreen_003Eb__0()
		{
		}

		internal void _003CDoSplashScreen_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDoSplashScreen_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SplashScreenController _003C_003E4__this;

		private _003C_003Ec__DisplayClass10_0 _003C_003E8__1;

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
		public _003CDoSplashScreen_003Ed__10(int _003C_003E1__state)
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

	public string MainMenuScene;

	public EventReference ShowSplashImageSound;

	public EventReference HideSplashImageSound;

	[SerializeField]
	private CanvasGroup _splashImageCanvasGroup;

	public float StartWaitTime;

	public float FadeInTime;

	public float ShowSplashImageTime;

	public float FadeOutTime;

	public float EndWaitTime;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CDoSplashScreen_003Ed__10))]
	public IEnumerator DoSplashScreen()
	{
		return null;
	}
}
