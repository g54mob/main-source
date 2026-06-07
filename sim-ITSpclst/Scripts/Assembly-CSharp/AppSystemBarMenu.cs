using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AppSystemBarMenu : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateMenu_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppSystemBarMenu _003C_003E4__this;

		public bool opening;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPosition_003E5__3;

		private Vector2 _003CendPosition_003E5__4;

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
		public _003CAnimateMenu_003Ed__11(int _003C_003E1__state)
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

	public RectTransform menuObject;

	public Transform appsList;

	public RectTransform menuArea;

	private bool isMenuOpen;

	private Vector2 hiddenPosition;

	private Vector2 visiblePosition;

	public float animationDuration;

	public AnimationCurve easeOutCurve;

	private void Start()
	{
	}

	public void OpenMenu()
	{
	}

	public void CloseMenu()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateMenu_003Ed__11))]
	private IEnumerator AnimateMenu(bool opening)
	{
		return null;
	}
}
