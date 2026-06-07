using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceMarker : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_MyUpdate_003Ed__6 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceMarker _003C_003E4__this;

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
		public _003C_MyUpdate_003Ed__6(int _003C_003E1__state)
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

	public GridPieceObj TgtObj;

	public BoxCollider2D BoxCol;

	public PolygonCollider2D PolyCol;

	public CircleCollider2D CircleCol;

	private CoroutineHandle _update;

	public void Init(GridPieceObj p, bool shouldFollow)
	{
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__6))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}
}
