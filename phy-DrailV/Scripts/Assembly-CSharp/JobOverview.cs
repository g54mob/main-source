using System.Collections;
using DV.CabControls;
using DV.Interaction;
using DV.Logic.Job;
using UnityEngine;

public class JobOverview : MonoBehaviour, IInventoryItemLocalizer
{
	public Job job;

	private void Start()
	{
		if (job == null)
		{
			Debug.LogError("Job not found. This should not happen", this);
		}
		else
		{
			base.gameObject.AddComponent<JobOverviewUse>();
		}
	}

	public void DestroyJobOverview()
	{
		ItemBase component = GetComponent<ItemBase>();
		if (component != null)
		{
			if (component.IsGrabbed())
			{
				StartCoroutine(UngrabAndDestroyCoro(component));
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}
		else
		{
			Debug.LogError("Couldn't find ItemBase on JobOverview!");
		}
	}

	private IEnumerator UngrabAndDestroyCoro(ItemBase item)
	{
		item.ForceEndInteraction();
		yield return null;
		Object.Destroy(base.gameObject);
	}

	public string GetNameParam()
	{
		return job.ID;
	}

	public string GetCustomDescription()
	{
		return null;
	}
}
