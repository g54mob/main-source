using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class StatusEffIndPartSys : StatusEffInd
{
	[CompilerGenerated]
	private sealed class _003C_DetachAndRemove_003Ed__5 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public StatusEffIndPartSys _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_DetachAndRemove_003Ed__5(int _003C_003E1__state)
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

	public PartSys Sys;

	public PartSys[] ExtraParts;

	public bool IsOnLightLayer;

	public bool WaitForPartSysToRemove;

	public override void Init(GridPieceObj p, StatusEffect ef)
	{
	}

	[IteratorStateMachine(typeof(_003C_DetachAndRemove_003Ed__5))]
	protected override IEnumerator<float> _DetachAndRemove()
	{
		return null;
	}

	public override void OnGameSpeedChanged()
	{
	}
}
