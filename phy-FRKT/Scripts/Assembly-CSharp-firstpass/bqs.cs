using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bqs : bqq
{
	[Serializable]
	public enum MoveMode
	{
		Directional = 0,
		Strafe = 1
	}

	public struct AnimState
	{
		public Vector3 moveDirection;

		public bool jump;

		public bool crouch;

		public bool onGround;

		public bool isStrafing;

		public float yVelocity;

		public bool doubleJump;
	}

	private sealed class bqr : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int umf;

		private object umg;

		public bqs umh;

		public Vector3 umi;

		private int umj;

		private int umk;

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
		public bqr(int a)
		{
		}

		[DebuggerHidden]
		private void lhp()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lhp
			this.lhp();
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
		private void lhr()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lhr
			this.lhr();
		}
	}

	public bqo characterAnimation;

	public bqv userControl;

	public blf cam;

	public MoveMode moveMode;

	public bool smoothPhysics;

	public float smoothAccelerationTime;

	public float linearAccelerationSpeed;

	public float platformFriction;

	public float groundStickyEffect;

	public float maxVerticalVelocityOnGround;

	public float velocityToGroundTangentWeight;

	public bool lookInCameraDirection;

	public float turnSpeed;

	public float stationaryTurnSpeedMlp;

	public bool smoothJump;

	public float airSpeed;

	public float airControl;

	public float jumpPower;

	public float jumpRepeatDelayTime;

	public bool doubleJumpEnabled;

	public float doubleJumpPowerMlp;

	public LayerMask wallRunLayers;

	public float wallRunMaxLength;

	public float wallRunMinMoveMag;

	public float wallRunMinVelocityY;

	public float wallRunRotationSpeed;

	public float wallRunMaxRotationAngle;

	public float wallRunWeightSpeed;

	public float crouchCapsuleScaleMlp;

	public AnimState animState;

	protected Vector3 umn;

	private Animator umo;

	private Vector3 ump;

	private Vector3 umq;

	private Vector3 umr;

	private RaycastHit ums;

	private float umt;

	private float umu;

	private float umv;

	private float umw;

	private float umx;

	private float umy;

	private Vector3 umz;

	private Vector3 una;

	private float unb;

	private float unc;

	private float und;

	private Vector3 une;

	private Quaternion unf;

	private bool ung;

	private float unh;

	private Vector3 uni;

	private Vector3 unj;

	private float unk;

	private bool unl;

	private bool unm;

	public bool uml
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public bool umm
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	[IteratorStateMachine(typeof(bqr))]
	private IEnumerator lid(Vector3 a)
	{
		return null;
	}

	private void mkm()
	{
	}

	private void ecy()
	{
	}

	protected virtual void Update()
	{
	}

	private void ncm()
	{
	}

	private void lie()
	{
	}

	protected override void Start()
	{
	}

	private void jas()
	{
	}

	private void hlq(Vector3 a)
	{
	}

	protected virtual void LateUpdate()
	{
	}

	private void gra(Vector3 a)
	{
	}

	public override void Move(Vector3 deltaPosition, Quaternion deltaRotation)
	{
	}

	private Vector3 lic()
	{
		return default(Vector3);
	}

	private void fyr()
	{
	}

	private void lhx(Vector3 a)
	{
	}

	private void gks()
	{
	}

	private void mxt()
	{
	}

	private void era()
	{
	}

	private void lhy()
	{
	}

	private void haq()
	{
	}

	private void OnAnimatorMove()
	{
	}

	private Vector3 lia()
	{
		return default(Vector3);
	}

	private bool lhz()
	{
		return false;
	}

	private void FixedUpdate()
	{
	}

	protected virtual void lib()
	{
	}

	protected virtual bool Jump()
	{
		return false;
	}
}
