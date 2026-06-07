using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using MEC;
using UnityEngine;

public class ArrowObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateGrow_003Ed__52 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ArrowObj _003C_003E4__this;

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
		public _003C_AnimateGrow_003Ed__52(int _003C_003E1__state)
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
	private sealed class _003C_RunDamage_003Ed__46 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ArrowObj _003C_003E4__this;

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
		public _003C_RunDamage_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndRemove_003Ed__50 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ArrowObj _003C_003E4__this;

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
		public _003C_WaitAndRemove_003Ed__50(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndRunFixedUpdate_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ArrowObj _003C_003E4__this;

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
		public _003C_WaitAndRunFixedUpdate_003Ed__33(int _003C_003E1__state)
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

	public ArrowType Type;

	public Collider2D Col;

	public Collider DmgCol;

	public GridSpriteObj SpriteObj;

	public Renderer Rend;

	public Renderer[] ExtraRend;

	public GridPieceInst Shooter;

	public BabyParticleEmitter[] PartEmitter;

	public Vector3 DefaultVizLocalPos;

	public Transform VizWrapper;

	public GameObject ShadowWrapper;

	public EventReference SFXOnHit;

	public Vector3 AimDir;

	public bool IsReflected;

	private CoroutineHandle _fixedUpdateAnim;

	private CoroutineHandle _updateAnim;

	public PartSys[] Particles;

	public TrailRenderer[] Trails;

	private Material _matAlive;

	private Material _matDead;

	public int Health;

	private CoroutineHandle _curAnim;

	private bool _isFriendlyShot;

	private PassiveInst _passiveSrc;

	private int _minFriendlyDmg;

	private int _maxFriendlyDmg;

	private bool _isRemoving;

	private float _spinDir;

	private float _frozenTimeLeft;

	public Vector3 DefaultScale;

	private const float kTargetZ = -0.5f;

	public const float kHitDist = 0.25f;

	public const float kHitDistSqr = 0.0625f;

	public const float kArrowSpeed = 2f;

	private const float kExpireLen = 1f;

	public virtual void Run(GridPieceInst shooter, Vector2 aimDir, Vector3 pos)
	{
	}

	public void Run(GridPieceInst shooter, Vector2 aimDir)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndRunFixedUpdate_003Ed__33))]
	private IEnumerator<float> _WaitAndRunFixedUpdate()
	{
		return null;
	}

	public void SetAimDir(Vector2 aimDir)
	{
	}

	private void MyUpdate()
	{
	}

	private PartSysType GetImpactPartType()
	{
		return default(PartSysType);
	}

	private void OnValidate()
	{
	}

	private void MyFixedUpdate()
	{
	}

	public void OnHitPlayer()
	{
	}

	public void Reset()
	{
	}

	public void Damage(BallObj b)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDamage_003Ed__46))]
	private IEnumerator<float> _RunDamage(Vector2 dir)
	{
		return null;
	}

	public void PlayerReflect()
	{
	}

	public void PetReflect(int minDmg, int maxDmg)
	{
	}

	public void Remove()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndRemove_003Ed__50))]
	private IEnumerator<float> _WaitAndRemove()
	{
		return null;
	}

	public void AnimateGrow()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateGrow_003Ed__52))]
	private IEnumerator<float> _AnimateGrow()
	{
		return null;
	}

	public void Freeze(float len)
	{
	}

	public bool IsFriendly()
	{
		return false;
	}
}
