using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuSettingsListAnimView
{
	[CompilerGenerated]
	private sealed class _003CAnimRun_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuSettingsListAnimView _003C_003E4__this;

		public bool active;

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
		public _003CAnimRun_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003CAnimateAlpha_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuSettingsListAnimView _003C_003E4__this;

		public float targetAlpha;

		private float _003CstartAlpha_003E5__2;

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
		public _003CAnimateAlpha_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003CAnimateSize_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuSettingsListAnimView _003C_003E4__this;

		public float targetSizeY;

		private float _003CstartSizeY_003E5__2;

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
		public _003CAnimateSize_003Ed__17(int _003C_003E1__state)
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

	private MenuSettingsDisplay menuSettingsDisplay;

	private CanvasGroup[] canvasGroup;

	private RectTransform[] rectTransform;

	private Coroutine nowAnim;

	public float delay;

	public bool animType;

	private float timeAnim;

	private float minAlpha;

	private float maxAlpha;

	private float minSizeY;

	private float maxSizeY;

	public MenuSettingsListAnimView(MenuSettingsDisplay menuSettingsDisplay, CanvasGroup[] canvasGroup, RectTransform[] rectTransform)
	{
	}

	public void SetAnimOption(float timeAnim = float.MinValue, float minAlpha = float.MinValue, float maxAlpha = float.MinValue, float minSizeY = float.MinValue, float maxSizeY = float.MinValue)
	{
	}

	public void AnimShow(bool active)
	{
	}

	public void AnimDelay(float delay)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimRun_003Ed__15))]
	private IEnumerator AnimRun(bool active)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimateAlpha_003Ed__16))]
	private IEnumerator AnimateAlpha(float targetAlpha)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimateSize_003Ed__17))]
	private IEnumerator AnimateSize(float targetSizeY)
	{
		return null;
	}

	private void Raycast(bool mode)
	{
	}
}
