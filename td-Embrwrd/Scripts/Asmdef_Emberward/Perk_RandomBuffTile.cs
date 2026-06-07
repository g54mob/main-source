using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Perk_RandomBuffTile : APerkBase
{
	[CompilerGenerated]
	private sealed class _003CCR_CreateTiles_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Perk_RandomBuffTile _003C_003E4__this;

		private Vector3 _003CplayerFireSourcePos_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CCR_CreateTiles_003Ed__2(int _003C_003E1__state)
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

	private List<string> list_PrefabNames;

	protected override void OnEnableProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CreateTiles_003Ed__2))]
	private IEnumerator CR_CreateTiles()
	{
		return null;
	}
}
