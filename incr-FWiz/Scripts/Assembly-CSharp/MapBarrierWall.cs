using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class MapBarrierWall : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public bool completePanning;

		internal void _003CAnimateObelisks_003Eb__0()
		{
		}

		internal void _003CAnimateObelisks_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAnimateObelisks_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapBarrierWall _003C_003E4__this;

		private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

		private List<MapBarrierObelisk>.Enumerator _003C_003E7__wrap1;

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
		public _003CAnimateObelisks_003Ed__15(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public MapBarrierBrazier Brazier;

	public float CameraPanSpeedOnComplete;

	public List<MapBarrierObelisk> Obelisks;

	public float ObeliskDisappearStartBuffer;

	public float ObeliskDisappearInterval;

	public float EndInterval;

	public PlayerBoundry PlayerBoundry;

	public EventReference StartLoweringSound;

	public EventReference CompleteLoweringSound;

	public bool Animating { get; private set; }

	public void SetOpen()
	{
	}

	public void DoOpenAnimation()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateObelisks_003Ed__15))]
	private IEnumerator AnimateObelisks()
	{
		return null;
	}
}
