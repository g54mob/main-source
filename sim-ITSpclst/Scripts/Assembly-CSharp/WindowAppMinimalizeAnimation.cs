using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WindowAppMinimalizeAnimation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateIconWidthCoroutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WindowAppMinimalizeAnimation _003C_003E4__this;

		private Vector2 _003CtargetSize_003E5__2;

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
		public _003CAnimateIconWidthCoroutine_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003CAnimateWindow_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WindowAppMinimalizeAnimation _003C_003E4__this;

		public string newState;

		public Vector3 targetScale;

		public Vector2 targetPosition;

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
		public _003CAnimateWindow_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CEnumBlockScroll_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<ScrollRect> scrollRects;

		public WindowAppMinimalizeAnimation minimalizeAnimation;

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
		public _003CEnumBlockScroll_003Ed__32(int _003C_003E1__state)
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

	[Header("Components")]
	public AppBarMenuAnimation appBarMenuAnimation;

	[Header("Object")]
	public RectTransform windowApplication;

	public RectTransform iconExplorerBarActive;

	[Header("Animation settings")]
	public float animationSpeed;

	public Vector3 minimizedScale;

	public Vector2 minimizedPosition;

	public Vector3 hiddenScale;

	public Vector2 hiddenPosition;

	public Vector3 originalScale;

	public Vector2 originalPosition;

	[Header("Variables")]
	public string currentState;

	public bool alwaysOnBelt;

	public bool disableBarAnim;

	public bool isAnimation;

	private bool firstRun;

	private float targetWidth;

	public void _Start()
	{
	}

	public void MinimizeWindow()
	{
	}

	public void MaximizeWindow()
	{
	}

	public void OpenWindow()
	{
	}

	public void CloseWindow()
	{
	}

	public void AnimateIconWidth(float sizeIcon)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateIconWidthCoroutine_003Ed__22))]
	private IEnumerator AnimateIconWidthCoroutine()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimateWindow_003Ed__23))]
	private IEnumerator AnimateWindow(Vector3 targetScale, Vector2 targetPosition, string newState)
	{
		return null;
	}

	private void BarAnimation(string mode)
	{
	}

	private void MoveIconToRight()
	{
	}

	public static void BlockScrollDuringAnimation(ScrollRect scrollRect, WindowAppMinimalizeAnimation minimalizeAnimation)
	{
	}

	public static void BlockScrollDuringAnimation(List<ScrollRect> scrollRects, WindowAppMinimalizeAnimation minimalizeAnimation)
	{
	}

	public static void BlockScrollDuringAnimation(ScrollRect[] scrollRects, WindowAppMinimalizeAnimation minimalizeAnimation)
	{
	}

	public void BlockScrollDuringAnimation(ScrollRect scrollRect)
	{
	}

	public void BlockScrollDuringAnimation(List<ScrollRect> scrollRects)
	{
	}

	public void BlockScrollDuringAnimation(ScrollRect[] scrollRects)
	{
	}

	[IteratorStateMachine(typeof(_003CEnumBlockScroll_003Ed__32))]
	private static IEnumerator EnumBlockScroll(List<ScrollRect> scrollRects, WindowAppMinimalizeAnimation minimalizeAnimation)
	{
		return null;
	}
}
