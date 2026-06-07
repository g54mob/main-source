using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class TouchableTrailObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_MyUpdate_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TouchableTrailObj _003C_003E4__this;

		private float _003CstopTime_003E5__2;

		private int _003Clifetime_003E5__3;

		private int _003CnumParts_003E5__4;

		private float _003CstartTime_003E5__5;

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
		public _003C_MyUpdate_003Ed__11(int _003C_003E1__state)
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
	private sealed class _003C_Run_003Ed__12 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TouchableTrailObj _003C_003E4__this;

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
		public _003C_Run_003Ed__12(int _003C_003E1__state)
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

	public TouchableTrailType Type;

	public PartSys PS;

	private BallObj _owner;

	private HeroInst _tgtInst;

	private CoroutineHandle _updateAnim;

	private CoroutineHandle _secondaryAnim;

	private ParticleSystem.Particle[] _particles;

	private List<Vector3> _bounceSpots;

	public void Init(BallObj b)
	{
	}

	private void OnBounce()
	{
	}

	public void OnAboutToRemove()
	{
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__11))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__12))]
	private IEnumerator<float> _Run()
	{
		return null;
	}
}
