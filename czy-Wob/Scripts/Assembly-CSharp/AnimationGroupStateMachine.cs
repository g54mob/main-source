using System.Collections.Generic;
using UnityEngine;

public class AnimationGroupStateMachine
{
	public LegGroup groupRef;

	public bool loopMovement = true;

	public float initialOffset;

	public List<AnimationState> animationStates = new List<AnimationState>();

	public float inMotionAngularDrag;

	private int currentStateIndex;

	private float timeActive;

	private float lastTimeActive;

	public void AddState(AnimationState newState, int index = -1)
	{
		newState.statemachineRef = this;
		if (index == -1)
		{
			animationStates.Add(newState);
		}
		else
		{
			animationStates.Insert(index, newState);
		}
	}

	public bool IsMovingUp()
	{
		return GetCurrentState().IsMovingUp();
	}

	public void AddActiveTime(float timeToAdd)
	{
		SetActiveTime(timeActive + timeToAdd);
	}

	private void SetActiveTime(float newTime)
	{
		if (timeActive == newTime)
		{
			return;
		}
		lastTimeActive = timeActive;
		timeActive = newTime;
		if (GetCurrentState().HasFilledRequirements() || !(timeActive >= groupRef.initialOffset))
		{
			float length = GetCurrentState().GetLength();
			if (loopMovement && length != 0f && (int)(GetPreviousOffsetTime() / length) != (int)(GetOffsetTime() / length))
			{
				AdvanceState();
			}
		}
	}

	private void AdvanceState()
	{
		timeActive = initialOffset;
		lastTimeActive = timeActive;
		animationStates[currentStateIndex].OnRemove();
		int num = currentStateIndex;
		int num2 = 0;
		AdvanceStateIndex();
		while (!animationStates[currentStateIndex].CanPlay())
		{
			AdvanceStateIndex();
			if (currentStateIndex == num)
			{
				num2++;
				if (num2 > 2)
				{
					Debug.LogError("Infinite loop of unplayable animation states.");
					break;
				}
			}
		}
	}

	private void AdvanceStateIndex()
	{
		currentStateIndex++;
		if (currentStateIndex >= animationStates.Count)
		{
			currentStateIndex = 0;
		}
	}

	public void OnCurvesUpdated()
	{
		for (int i = 0; i < animationStates.Count; i++)
		{
			AnimationState animationState = animationStates[i];
			WrapMode postWrapMode = ((!loopMovement) ? WrapMode.Once : WrapMode.Loop);
			if (animationState.torqueX != null)
			{
				animationState.torqueX.SetPostWrapMode(postWrapMode);
			}
			if (animationState.torqueY != null)
			{
				animationState.torqueY.SetPostWrapMode(postWrapMode);
			}
			if (animationState.torqueZ != null)
			{
				animationState.torqueZ.SetPostWrapMode(postWrapMode);
			}
			animationState.Reset();
		}
	}

	public void Reset()
	{
		groupRef.ResetLimbsAngularDrag();
		if (timeActive != 0f || lastTimeActive != 0f)
		{
			timeActive = 0f;
			lastTimeActive = 0f;
			currentStateIndex = 0;
			for (int i = 0; i < animationStates.Count; i++)
			{
				animationStates[i].Reset();
			}
		}
	}

	private float GetOffsetTime()
	{
		return timeActive - initialOffset;
	}

	private float GetPreviousOffsetTime()
	{
		return lastTimeActive - initialOffset;
	}

	private bool CanStartCycle()
	{
		return timeActive >= initialOffset;
	}

	public void CheckRequirements()
	{
		GetCurrentState().CheckRequirements();
	}

	public Vector3 GetCurrentTorque()
	{
		if (!CanStartCycle())
		{
			groupRef.ResetLimbsAngularDrag();
			return Vector3.zero;
		}
		AnimationState currentState = GetCurrentState();
		if (!currentState.HasFilledRequirements())
		{
			groupRef.ResetLimbsAngularDrag();
			return Vector3.zero;
		}
		groupRef.SetLimbsAngularDrag(inMotionAngularDrag);
		return currentState.GetTorqueAtTime(GetOffsetTime());
	}

	private AnimationState GetCurrentState()
	{
		return animationStates[currentStateIndex];
	}

	public bool CheckAllGrounded()
	{
		for (int i = 0; i < groupRef.groundedRequirements.Count; i++)
		{
			if (!ObjectStatusUtil.CheckObjectGrounded(groupRef.groundedRequirements[i], 0.01f, groupRef.groundedRequirements[i].transform.root.localScale.x))
			{
				return false;
			}
		}
		return true;
	}
}
