using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LegGroup
{
	public string label;

	public List<GameObject> legs;

	public List<GameObject> groundedRequirements = new List<GameObject>();

	public GroundedMode groundedRequirementsMode = GroundedMode.OnCycleStart;

	public KeyCode keyController;

	public bool loopMovement;

	public float initialOffset;

	public float inMotionAngularDrag;

	public AnimationCurveWrapper torqueX;

	public AnimationCurveWrapper torqueY;

	public AnimationCurveWrapper torqueZ;

	public Vector3 rotMod = new Vector3(1f, 1f, 1f);

	public bool autoCreateInitialState = true;

	private float currentAngularDrag;

	private List<Limb> limbs = new List<Limb>();

	private AnimationGroupStateMachine statemachine = new AnimationGroupStateMachine();

	public float length;

	public void Initialize()
	{
		FindLimbs();
		SetupInitialStatemachine();
		OnCurvesUpdated();
	}

	public bool IsMovingUp()
	{
		return statemachine.IsMovingUp();
	}

	public void AddNewState(AnimationState newState, int index = -1)
	{
		statemachine.AddState(newState, index);
	}

	public void ResetLimbsAngularDrag()
	{
		SetLimbsAngularDrag(0f);
	}

	public void SetLimbsAngularDrag(float drag)
	{
		if (drag != currentAngularDrag)
		{
			for (int i = 0; i < limbs.Count; i++)
			{
				limbs[i].SetLimbAngularDrag(drag);
			}
			currentAngularDrag = drag;
		}
	}

	private void FindLimbs()
	{
		for (int i = 0; i < legs.Count; i++)
		{
			limbs.Add(legs[i].transform.parent.GetComponentInChildren<Limb>());
		}
	}

	private void SetupInitialStatemachine()
	{
		statemachine.groupRef = this;
		statemachine.loopMovement = loopMovement;
		statemachine.initialOffset = initialOffset;
		statemachine.inMotionAngularDrag = inMotionAngularDrag;
		if (autoCreateInitialState)
		{
			AnimationState animationState = new AnimationState();
			animationState.torqueX = torqueX;
			animationState.torqueY = torqueY;
			animationState.torqueZ = torqueZ;
			animationState.rotMod = rotMod;
			if (groundedRequirements.Count > 0)
			{
				animationState.needsGroundedRequirement = true;
				animationState.groundedRequirementsMode = groundedRequirementsMode;
			}
			statemachine.AddState(animationState);
			statemachine.OnCurvesUpdated();
		}
	}

	public void AddActiveTime(float timeToAdd)
	{
		statemachine.AddActiveTime(timeToAdd);
	}

	public void Reset()
	{
		statemachine.Reset();
		ResetLimbsAngularDrag();
	}

	private void OnCurvesUpdated()
	{
		statemachine.OnCurvesUpdated();
	}

	public void CheckRequirements()
	{
		statemachine.CheckRequirements();
	}

	public Vector3 EvaluationRotation()
	{
		return statemachine.GetCurrentTorque();
	}
}
