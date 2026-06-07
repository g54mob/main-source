using System.Collections.Generic;
using UnityEngine;

public class MilestoneGrouper : MonoBehaviour
{
	public List<PickUppable> milestones;

	private bool hasActivatedGroup;

	private void Start()
	{
		GameManager.Singleton.allMilestoneGroupers.Add(this);
	}

	private void OnDestroy()
	{
		GameManager.Singleton.allMilestoneGroupers.Remove(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!hasActivatedGroup && !GameManager.Singleton.hasTimerElapsed_IsNighttime && other.CompareTag("MilestoneActivator"))
		{
			ActivateAllOfOurMilestones();
			hasActivatedGroup = true;
		}
	}

	public void ActivateGroupIfMissingMilestone()
	{
		foreach (PickUppable milestone in milestones)
		{
			if (!(milestone == null) && !milestone.gameObject.activeSelf)
			{
				ActivateAllOfOurMilestones();
			}
		}
	}

	private void ActivateAllOfOurMilestones()
	{
		foreach (PickUppable milestone in milestones)
		{
			if ((bool)milestone && milestone.gameObject.activeSelf)
			{
				milestone.ActivateMilestoneObjectPhysics();
			}
		}
	}
}
