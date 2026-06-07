using System.Collections;
using DV.Booklets.Rendered;
using DV.Interaction;
using UnityEngine;

public class JobReport : MultipleRenderedTexturesBooklet, IInventoryItemLocalizer
{
	public string jobID = "[ID NOT SET]";

	private IEnumerator Start()
	{
		base.gameObject.AddComponent<JobReportUse>();
		yield return null;
		RespawnOnDrop component = GetComponent<RespawnOnDrop>();
		if (component != null)
		{
			component.ignoreDistanceFromSpawnPosition = true;
		}
		else
		{
			Debug.LogError("RespawnOnDrop not found on JobReport!", this);
		}
	}

	public string GetNameParam()
	{
		return jobID;
	}

	public string GetCustomDescription()
	{
		return null;
	}
}
