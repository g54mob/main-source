using System;
using UnityEngine;

[Serializable]
public class AnimationState
{
	public AnimationCurveWrapper torqueX;

	public AnimationCurveWrapper torqueY;

	public AnimationCurveWrapper torqueZ;

	public Vector3 rotMod = new Vector3(1f, 1f, 1f);

	public float length = -1f;

	public AnimationGroupStateMachine statemachineRef;

	public bool repeat = true;

	public bool needsGroundedRequirement;

	public GroundedMode groundedRequirementsMode;

	private float currZDir;

	private float lastZDir = float.PositiveInfinity;

	private bool hasPlayed;

	private bool isGrounded;

	public Vector3 GetTorqueAtTime(float time)
	{
		currZDir = CurveUtil.EvaluateAverageCurveWrapperTime(torqueZ, time, time - Time.fixedDeltaTime) * rotMod.z;
		CheckDirSwitchReqs();
		lastZDir = currZDir;
		if (NeedsGrounded())
		{
			return Vector3.zero;
		}
		return new Vector3(CurveUtil.EvaluateAverageCurveWrapperTime(torqueX, time, time - Time.fixedDeltaTime) * rotMod.x, CurveUtil.EvaluateAverageCurveWrapperTime(torqueY, time, time - Time.fixedDeltaTime) * rotMod.y, CurveUtil.EvaluateAverageCurveWrapperTime(torqueZ, time, time - Time.fixedDeltaTime) * rotMod.z);
	}

	public bool IsMovingUp()
	{
		return currZDir < 0f;
	}

	private void CheckDirSwitchReqs()
	{
		if (groundedRequirementsMode == GroundedMode.OnZDirSwitch)
		{
			CheckDirSwitch(currZDir, lastZDir);
		}
	}

	private void CheckDirSwitch(float currentDir, float prevDir)
	{
		if (prevDir != float.PositiveInfinity && lastZDir < 0f && currZDir > 0f && !statemachineRef.CheckAllGrounded())
		{
			SetGrounded(grounded: false);
		}
	}

	public void CheckRequirements()
	{
		if (!NeedsGrounded())
		{
			return;
		}
		if (groundedRequirementsMode == GroundedMode.OnCycleStart)
		{
			if (statemachineRef.CheckAllGrounded())
			{
				SetGrounded(grounded: true);
			}
		}
		else if (groundedRequirementsMode == GroundedMode.OnZDirSwitch)
		{
			if (lastZDir == float.PositiveInfinity)
			{
				SetGrounded(grounded: true);
			}
			else if (statemachineRef.CheckAllGrounded())
			{
				SetGrounded(grounded: true);
			}
		}
	}

	public bool HasFilledRequirements()
	{
		if (NeedsGrounded())
		{
			return false;
		}
		return true;
	}

	private bool NeedsGrounded()
	{
		if (needsGroundedRequirement)
		{
			return !isGrounded;
		}
		return false;
	}

	private void SetGrounded(bool grounded)
	{
		isGrounded = grounded;
	}

	public void Reset()
	{
		OnRemove();
		length = -1f;
		hasPlayed = false;
	}

	public void OnRemove()
	{
		hasPlayed = true;
		SetGrounded(!needsGroundedRequirement);
	}

	public bool CanPlay()
	{
		if (!repeat && hasPlayed)
		{
			return false;
		}
		return true;
	}

	public float GetLength()
	{
		if (length == -1f)
		{
			ComputeLength();
		}
		return length;
	}

	private void ComputeLength()
	{
		float a = ((torqueX != null) ? torqueX.GetTotalTime() : 0f);
		float b = ((torqueY != null) ? torqueY.GetTotalTime() : 0f);
		float b2 = ((torqueZ != null) ? torqueZ.GetTotalTime() : 0f);
		float a2 = Mathf.Max(a, b);
		a2 = Mathf.Max(a2, b2);
		length = a2;
	}
}
