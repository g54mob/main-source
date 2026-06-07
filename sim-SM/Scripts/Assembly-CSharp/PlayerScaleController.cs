using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class PlayerScaleController : ScaleController
{
	[CompilerGenerated]
	private sealed class _003CFocusDelayed_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerScaleController _003C_003E4__this;

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
		public _003CFocusDelayed_003Ed__14(int _003C_003E1__state)
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

	private PlayerInstance m_InteractedPlayer;

	public PlayerInstance InteractedPlayer => null;

	public PlayerScaleController(Scale scale, PlayerInstance player)
		: base(null)
	{
	}

	public override void OnAdded()
	{
	}

	public override void OnRemoved()
	{
	}

	private void OnGamepadConnected(bool obj)
	{
	}

	public override void OnStateIdle()
	{
	}

	public override void OnStatePlacement()
	{
	}

	public override void OnStateChanged()
	{
	}

	public override void OnStateControl()
	{
	}

	private void AddKeyboardControlHint()
	{
	}

	private void AddGamepadControlHint()
	{
	}

	private void AddGamepadBarcodeHint()
	{
	}

	[IteratorStateMachine(typeof(_003CFocusDelayed_003Ed__14))]
	private IEnumerator FocusDelayed()
	{
		return null;
	}

	public override void OnStateBarcode()
	{
	}

	private void ActivateControlCamera()
	{
	}

	private void SetCursor(bool isOpen)
	{
	}
}
