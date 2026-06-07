using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSteelMillSwitchChecker : MonoBehaviour
{
	[SerializeField]
	private Transform[] junctionFinders;

	private Collider[] overlapColliders = new Collider[8];

	private Junction[] junctions;

	private HashSet<int> invertedJunctionIndices = new HashSet<int> { 4 };

	private float detectionRadius = 15f;

	private bool initialized;

	private bool canCheck;

	[InspectorButton("InitializeAndStartChecking", true, true)]
	public bool initializeAndStartChecking;

	public event Action PathSet;

	private void OnDestroy()
	{
		if (UnloadWatcher.isUnloading || junctions == null)
		{
			return;
		}
		Junction[] array = junctions;
		foreach (Junction junction in array)
		{
			if (junction != null)
			{
				junction.Switched -= OnJunctionSwitched;
			}
		}
	}

	public void InitializeAndStartChecking()
	{
		if (FindJunctions())
		{
			Junction[] array = junctions;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Switched += OnJunctionSwitched;
			}
			canCheck = true;
			CheckStatesAndFire();
		}
	}

	private bool FindJunctions()
	{
		if (initialized)
		{
			return true;
		}
		if (junctionFinders == null || junctionFinders.Length == 0)
		{
			Debug.LogError("Junction finders not assigned.", this);
			return false;
		}
		junctions = new Junction[junctionFinders.Length];
		int layerMask = 1 << LayerMask.NameToLayer("Laser_Pointer_Target");
		for (int i = 0; i < junctionFinders.Length; i++)
		{
			int num = Physics.OverlapSphereNonAlloc(junctionFinders[i].position, detectionRadius, overlapColliders, layerMask, QueryTriggerInteraction.Collide);
			for (int j = 0; j < num; j++)
			{
				Junction componentInChildren = overlapColliders[j].transform.parent.GetComponentInChildren<Junction>(includeInactive: true);
				if (componentInChildren != null)
				{
					junctions[i] = componentInChildren;
					break;
				}
			}
		}
		initialized = true;
		return true;
	}

	public void StopChecking()
	{
		if (!canCheck)
		{
			return;
		}
		Junction[] array = junctions;
		foreach (Junction junction in array)
		{
			if (junction != null)
			{
				junction.Switched -= OnJunctionSwitched;
			}
		}
		canCheck = false;
	}

	private void OnJunctionSwitched(Junction.SwitchMode _, int __)
	{
		CheckStatesAndFire();
	}

	public bool IsAlligned()
	{
		for (int i = 0; i < junctions.Length; i++)
		{
			if (junctions[i].selectedBranch != (invertedJunctionIndices.Contains(i) ? 1 : 0))
			{
				return false;
			}
		}
		return true;
	}

	private void CheckStatesAndFire()
	{
		if (canCheck && IsAlligned())
		{
			Junction[] array = junctions;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Switched -= OnJunctionSwitched;
			}
			this.PathSet?.Invoke();
		}
	}

	public void ResetSwitches()
	{
		if (!FindJunctions())
		{
			return;
		}
		for (int i = 0; i < junctions.Length; i++)
		{
			if (i == 0)
			{
				if (junctions[i].selectedBranch != 1)
				{
					junctions[i].Switch(Junction.SwitchMode.FORCED);
				}
			}
			else if (junctions[i].selectedBranch != (invertedJunctionIndices.Contains(i) ? 1 : 0))
			{
				junctions[i].Switch(Junction.SwitchMode.FORCED);
			}
		}
	}
}
