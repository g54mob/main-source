using System;
using DV.Interaction.Inputs;
using UnityEngine;

public class LocomotionInputNonVr : ILocomotionInputInterpreter, IDisposable
{
	private const float MAX_SPEED = 1f;

	private const float SMOOTH_TIME = 0.05f;

	private const float STOP_THRESHOLD = 0.01f;

	private const float LEAN_TOGGLE_THRESHOLD = 0.2f;

	private const float CROUCH_TOGGLE_THRESHOLD = 0.2f;

	private const float RUN_TOGGLE_THRESHOLD = 0.2f;

	private bool leanToggleAllowed = true;

	private LocomotionInputWrapper.LeanDirection leanLatch;

	private bool crouchToggleAllowed;

	private float crouchToggleStartTime;

	private bool runToggleAllowed;

	private float runToggleStartTime;

	private bool hasMovementInput;

	private float smoothingVelX;

	private float smoothingVelY;

	private float horizontal;

	private float vertical;

	public Vector2 LocomotionAxis
	{
		get
		{
			Vector2 axis2D = InputManager.NewPlayer.GetAxis2D(InputManager.Actions.MoveHorizontal, InputManager.Actions.MoveVertical);
			axis2D *= 1f;
			hasMovementInput = axis2D.x != 0f || axis2D.y != 0f;
			horizontal = AxisSmoothing(horizontal, ref smoothingVelX, axis2D.x);
			vertical = AxisSmoothing(vertical, ref smoothingVelY, axis2D.y);
			return new Vector2(horizontal, vertical);
		}
	}

	public bool SwimRequested => InputManager.NewPlayer.GetButton(InputManager.Actions.Jump);

	public bool JumpRequested => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Jump);

	public bool CrouchRequested { get; private set; }

	public bool SittingRequested => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Sit);

	public bool RunRequested { get; private set; }

	public bool ClimbLadderRequested => LocomotionAxis.sqrMagnitude > 0f;

	public Transform LadderClimbDirectionTransform => PlayerManager.ActiveCamera?.transform;

	public LocomotionInputWrapper.LeanDirection LeanValue { get; private set; }

	public bool IsLeanPressed => InputManager.NewPlayer.GetButton(InputManager.Actions.Lean);

	private float AxisSmoothing(float currentValue, ref float smoothingVel, float targetSpeed)
	{
		if (targetSpeed != 0f)
		{
			return Mathf.SmoothDamp(currentValue, targetSpeed, ref smoothingVel, 0.05f);
		}
		if (Mathf.Abs(currentValue) < 0.01f)
		{
			return 0f;
		}
		return Mathf.SmoothDamp(currentValue, targetSpeed, ref smoothingVel, 0.05f);
	}

	public void UpdateFrame()
	{
		UpdateLean();
		UpdateCrouch();
		UpdateRun();
	}

	private void UpdateCrouch()
	{
		if (!crouchToggleAllowed)
		{
			CrouchRequested = InputManager.NewPlayer.GetButton(InputManager.Actions.Crouch);
		}
		else if (CrouchRequested)
		{
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Crouch) || JumpRequested)
			{
				CrouchRequested = false;
			}
			else if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Crouch))
			{
				CrouchRequested = Time.timeSinceLevelLoad - crouchToggleStartTime < 0.2f;
			}
			else if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Sit))
			{
				CrouchRequested = false;
			}
		}
		else if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Crouch))
		{
			CrouchRequested = true;
			crouchToggleStartTime = Time.timeSinceLevelLoad;
		}
	}

	private void UpdateLean()
	{
		float axis = InputManager.NewPlayer.GetAxis(InputManager.Actions.Lean);
		LocomotionInputWrapper.LeanDirection leanDirection = ((axis != 0f) ? ((axis > 0f) ? LocomotionInputWrapper.LeanDirection.LeaningRight : LocomotionInputWrapper.LeanDirection.LeaningLeft) : LocomotionInputWrapper.LeanDirection.NotLeaning);
		if (!leanToggleAllowed)
		{
			LeanValue = leanDirection;
		}
		else if (leanDirection == LocomotionInputWrapper.LeanDirection.NotLeaning)
		{
			if (leanLatch == LocomotionInputWrapper.LeanDirection.NotLeaning)
			{
				LeanValue = LocomotionInputWrapper.LeanDirection.NotLeaning;
			}
		}
		else if (InputManager.NewPlayer.GetAnyDirButtonDown(InputManager.Actions.Lean))
		{
			if (LeanValue != leanDirection)
			{
				leanLatch = leanDirection;
				LeanValue = leanDirection;
			}
			else
			{
				leanLatch = LocomotionInputWrapper.LeanDirection.NotLeaning;
			}
		}
		else if (InputManager.NewPlayer.GetAxisTimeActive(InputManager.Actions.Lean) > 0.20000000298023224)
		{
			leanLatch = LocomotionInputWrapper.LeanDirection.NotLeaning;
		}
	}

	private void UpdateRun()
	{
		if (!runToggleAllowed)
		{
			RunRequested = hasMovementInput && InputManager.NewPlayer.GetButton(InputManager.Actions.Run);
		}
		else if (RunRequested)
		{
			if (!hasMovementInput)
			{
				RunRequested = false;
			}
			else if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Run))
			{
				RunRequested = false;
			}
			else if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Run))
			{
				RunRequested = Time.timeSinceLevelLoad - runToggleStartTime < 0.2f;
			}
		}
		else if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Run))
		{
			RunRequested = hasMovementInput;
			runToggleStartTime = Time.timeSinceLevelLoad;
		}
		else
		{
			RunRequested = hasMovementInput && InputManager.NewPlayer.GetButton(InputManager.Actions.Run);
		}
	}

	public void SetLeanToggle(bool on)
	{
		leanToggleAllowed = on;
		LeanValue = LocomotionInputWrapper.LeanDirection.NotLeaning;
	}

	public void SetCrouchToggle(bool on)
	{
		crouchToggleAllowed = on;
		CrouchRequested = false;
	}

	public void SetRunToggle(bool on)
	{
		runToggleAllowed = on;
		RunRequested = false;
		runToggleStartTime = 0f;
	}

	public void ResetAxis(bool primary)
	{
		Debug.LogError("LocomotionInputNonVr does not support 'ResetAxis'. This should not have been called!");
	}

	public bool ResetLean()
	{
		if (LeanValue != LocomotionInputWrapper.LeanDirection.NotLeaning)
		{
			LeanValue = LocomotionInputWrapper.LeanDirection.NotLeaning;
			return true;
		}
		return false;
	}

	public void Dispose()
	{
	}
}
