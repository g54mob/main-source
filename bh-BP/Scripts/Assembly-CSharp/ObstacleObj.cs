using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using Sirenix.OdinInspector;
using UnityEngine;

public class ObstacleObj : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ObstacleObj _003C_003E4__this;

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
		public _003C_AnimateEntry_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_AnimateExit_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ObstacleObj _003C_003E4__this;

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
		public _003C_AnimateExit_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003C_AnimatePulse_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ObstacleObj _003C_003E4__this;

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
		public _003C_AnimatePulse_003Ed__33(int _003C_003E1__state)
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

	public ObstacleType Type;

	public Collider2D Col;

	private CoroutineHandle _curAnim;

	public List<BallObj> TouchingBalls;

	public List<BallObj> TouchedBallsThisFrame;

	private bool _isTouchingPlayer;

	private bool _touchedPlayerThisFrame;

	private bool _isAnimating;

	public float CreationTime;

	public HeroInst BallSrc;

	private float _lastDamagePlayerTime;

	private CoroutineHandle _updateAnim;

	private float _size;

	private const float kIceSpeedMult = 2f;

	private const float kQuicksandSpeedMult = 0.3f;

	public const float kEntryLen = 0.25f;

	public const float kExitLen = 0.25f;

	private void InitInternal()
	{
	}

	public virtual void Init(float x, float y, float size)
	{
	}

	public virtual void Init(BallObj b)
	{
	}

	public void Reset()
	{
	}

	public void MyUpdate()
	{
	}

	public void OnFrameEnd()
	{
	}

	public virtual void OnHit(BallObj b)
	{
	}

	public virtual void OnEnemyTouch(GridPieceObj p)
	{
	}

	public virtual void OnPlayerTouch()
	{
	}

	private void ActivateBallObstacle(GridPieceObj p)
	{
	}

	public virtual bool ShouldScrollWithBoard()
	{
		return false;
	}

	public void AnimateEntry()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__28))]
	private IEnumerator<float> _AnimateEntry()
	{
		return null;
	}

	public void AnimateExit()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateExit_003Ed__31))]
	private IEnumerator<float> _AnimateExit()
	{
		return null;
	}

	public void AnimatePulse()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimatePulse_003Ed__33))]
	private IEnumerator<float> _AnimatePulse()
	{
		return null;
	}
}
