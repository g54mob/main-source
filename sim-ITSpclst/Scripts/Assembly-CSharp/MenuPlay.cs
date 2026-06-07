using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimToSubmenu_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuPlay _003C_003E4__this;

		public Button button;

		public bool anim;

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
		public _003CAnimToSubmenu_003Ed__11(int _003C_003E1__state)
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

	public MenuPlayNewGame MenuPlayNewGame;

	public Animation animationComponent;

	public Animation animationComponentUI;

	public AnimationClip animationClip_toPlay;

	public AnimationClip animationClipUI_toPlay;

	public MenuSettingsSubMenu[] SubMenuCanvas;

	public Coroutine AnimSubMenu;

	private void Start()
	{
	}

	public void ButtonToPlay()
	{
	}

	public void ButtonToMenuFromPlay()
	{
	}

	public void ButtonToSubMenu(Button button)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimToSubmenu_003Ed__11))]
	public IEnumerator AnimToSubmenu(Button button, bool anim)
	{
		return null;
	}
}
