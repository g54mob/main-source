using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PartSysGroup : PartSys
{
	[CompilerGenerated]
	private sealed class _003C_WaitAndRemove_003Ed__5 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PartSysGroup _003C_003E4__this;

		private bool _003CisAnyRunning_003E5__2;

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
		public _003C_WaitAndRemove_003Ed__5(int _003C_003E1__state)
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

	public PartSys[] Parts;

	protected override void Reset()
	{
	}

	public override void Run()
	{
	}

	public override void Stop()
	{
	}

	public override void SetStartColor(ParticleSystem.MinMaxGradient col)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndRemove_003Ed__5))]
	protected override IEnumerator<float> _WaitAndRemove()
	{
		return null;
	}

	public override void SetScale(float sc)
	{
	}

	public override void EmitFromMeshRenderer(MeshRenderer rend, bool force)
	{
	}

	public override void EmitFromSkinnedMeshRenderer(SkinnedMeshRenderer rend, bool force)
	{
	}

	public override void OnGameSpeedChanged(float speed)
	{
	}
}
