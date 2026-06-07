using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AppPixelCraft : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMainMenuDelay_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppPixelCraft _003C_003E4__this;

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
		public _003CMainMenuDelay_003Ed__9(int _003C_003E1__state)
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

	[Header("App Object")]
	public Transform applicationLayout;

	[Header("Components")]
	public MiniGameMapUIController miniGameMapUIController;

	public bool isOpen;

	public RectTransform DesktopRight;

	public RectTransform DesktopLeft;

	public RectTransform MianMenu;

	public void OpenApp()
	{
	}

	[IteratorStateMachine(typeof(_003CMainMenuDelay_003Ed__9))]
	private IEnumerator MainMenuDelay()
	{
		return null;
	}

	public void CloseApp()
	{
	}
}
