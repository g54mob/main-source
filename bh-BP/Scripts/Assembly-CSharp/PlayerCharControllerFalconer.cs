using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class PlayerCharControllerFalconer : PlayerCharController
{
	[CompilerGenerated]
	private sealed class _003C_RunFalconPulse_003Ed__9 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public PlayerCharControllerFalconer _003C_003E4__this;

		private float _003CstartTime_003E5__2;

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
		public _003C_RunFalconPulse_003Ed__9(int _003C_003E1__state)
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

	public static PlayerCharControllerFalconer I;

	public Animator AnimFalconLeft;

	public Animator AnimFalconRight;

	public static readonly int kIsFlyingProp;

	private CoroutineHandle _pulseAnim;

	public override void Init()
	{
	}

	public override void InitEnding(Material mat)
	{
	}

	public override void SetAnimSpeed(float speed)
	{
	}

	public void RunFalconPulse()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunFalconPulse_003Ed__9))]
	private IEnumerator<float> _RunFalconPulse(float len)
	{
		return null;
	}

	public override void SetAimDir(Vector2 dir)
	{
	}
}
