using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameGridBoardObj : GridBoardObj
{
	[CompilerGenerated]
	private sealed class _003C_WaitAndPlaceTopBorder_003Ed__2 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameGridBoardObj _003C_003E4__this;

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
		public _003C_WaitAndPlaceTopBorder_003Ed__2(int _003C_003E1__state)
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

	public BoxCollider2D ColBorderBot;

	public override void InitBoard(float numCols, float numRows)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndPlaceTopBorder_003Ed__2))]
	private IEnumerator<float> _WaitAndPlaceTopBorder()
	{
		return null;
	}
}
