using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RatCharacterController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CJumpCooldown_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RatCharacterController _003C_003E4__this;

		public float delay;

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
		public _003CJumpCooldown_003Ed__42(int _003C_003E1__state)
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

	public CharacterController charController;

	public float slopeLimitForAddedJumpCooldown;

	public float maxGroundedDistance;

	public float maxWallRunDistance;

	public float _ratJumpHeight;

	public float ratMoveSpeed;

	public float mouseSensitivity;

	public float wallJumpDelay;

	public float slopeGroundJumpDelay;

	public float groundJumpDelay;

	public float minCamAngle;

	public float maxCamAngle;

	public LayerMask _ratGroundMask;

	private Vector2 _ratMoveDir;

	private RaycastHit _groundHitInfo;

	private RaycastHit _wallHitInfo;

	private bool _isRatGrounded;

	private bool _ratGroundedPossible;

	private bool _isWallRunning;

	private bool _ratJumpCooldownActive;

	private Vector3 _ratVelocity;

	private Vector3 _groundHitPoint;

	private Vector3 _groundHitNormal;

	private Vector3 _groundForwardVector;

	private Vector3 _moveVector;

	private Vector3 _wallRunHitPoint;

	private Vector3 _wallRunHitNormal;

	private Vector3 _wallRunHitForwardVector;

	private Vector3 _inputVector;

	private Vector2 _mouseInput;

	private float _currentSlopeAngle;

	private float _camRotX;

	private float _camRotY;

	private Camera _camera;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void CheckWallCeilingCollision()
	{
	}

	private void EvaluateGround()
	{
	}

	private void EvaluateMouseMovement()
	{
	}

	private void ApplyMovement()
	{
	}

	private void HandleJumping()
	{
	}

	[IteratorStateMachine(typeof(_003CJumpCooldown_003Ed__42))]
	private IEnumerator JumpCooldown(float delay)
	{
		return null;
	}
}
