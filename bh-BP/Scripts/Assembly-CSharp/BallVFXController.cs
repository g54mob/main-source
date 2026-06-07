using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallVFXController : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_DetachAndRemove_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BallVFXController _003C_003E4__this;

		public bool doRemove;

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
		public _003C_DetachAndRemove_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003C_RunEarthquakePulse_003Ed__21 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BallVFXController _003C_003E4__this;

		private Material _003Cm_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003CbreachExitTime_003E5__4;

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
		public _003C_RunEarthquakePulse_003Ed__21(int _003C_003E1__state)
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

	public HeroType Type;

	public bool IsBaby;

	[NonSerialized]
	public BallObj TgtBall;

	[Header("Manual")]
	public MeshRenderer[] TexturedMeshes;

	public ParticleSystemRenderer[] ColorizedParticles;

	public TrailRenderer[] TexturedTrails;

	public Vector3 DefaultRotation;

	public BabyParticleEmitter PartEmitter;

	[Header("Auto")]
	public ParticleSystem[] Particles;

	public TrailRenderer[] Trails;

	public MeshRenderer[] BallMeshes;

	private CoroutineHandle _bounceAnim;

	private void InitInternal()
	{
	}

	public void RunBaby(BallObj b, HeroInst h)
	{
	}

	public void Run(BallObj b, HeroInst h)
	{
	}

	public void DetachAndRemove(bool doRemove)
	{
	}

	[IteratorStateMachine(typeof(_003C_DetachAndRemove_003Ed__16))]
	public IEnumerator<float> _DetachAndRemove(bool doRemove)
	{
		return null;
	}

	public void SetNonTrailActive(bool isActive)
	{
	}

	public void OnGameSpeedChanged()
	{
	}

	private void OnBounce()
	{
	}

	private void ResetEarthquake()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunEarthquakePulse_003Ed__21))]
	private IEnumerator<float> _RunEarthquakePulse()
	{
		return null;
	}

	public HeroInfo GetInfo()
	{
		return null;
	}

	public void PauseParticles()
	{
	}

	public void PlayParticles()
	{
	}

	public void ClearTrails()
	{
	}
}
