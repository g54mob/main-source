using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public bool complete;

		internal void _003CShowMenuEnumerator_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowMenuEnumerator_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuController _003C_003E4__this;

		private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

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
		public _003CShowMenuEnumerator_003Ed__7(int _003C_003E1__state)
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

	public float FadeInStartBuffer;

	public float FadeInTime;

	public float FadeToLoadTime;

	public List<GameObject> DestroyOnStartLoad;

	public SaveVersionPopupHandler SaveVersionPopupHandler;

	public SaveVersionPopupHandler SaveVersionQuitPopupHandler;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CShowMenuEnumerator_003Ed__7))]
	public IEnumerator ShowMenuEnumerator()
	{
		return null;
	}

	public void Quit()
	{
	}

	public void InstantQuit()
	{
	}

	public void LoadGame()
	{
	}
}
