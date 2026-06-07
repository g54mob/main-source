using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rune_Scrap : ARune
{
	[CompilerGenerated]
	private sealed class _003CCR_DelaySpawn_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Rune_Scrap _003C_003E4__this;

		private int _003CscrapTowerCount_003E5__2;

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
		public _003CCR_DelaySpawn_003Ed__3(int _003C_003E1__state)
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

	private List<Vector3> list_SpawnLocalPositions;

	private List<Vector3> list_SpawnWorldPositions;

	protected override void SpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelaySpawn_003Ed__3))]
	private IEnumerator CR_DelaySpawn()
	{
		return null;
	}

	private void SpawnScrapTower(int indexOffset, bool doActivate, bool doRegisterToGrid, Vector3 localPos, bool isPreview)
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void PlacementPreviewProc()
	{
	}
}
