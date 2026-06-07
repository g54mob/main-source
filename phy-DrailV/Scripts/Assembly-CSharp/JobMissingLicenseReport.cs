using System;
using System.Collections;
using UnityEngine;

public class JobMissingLicenseReport : MonoBehaviour, IInventoryItemLocalizer
{
	[NonSerialized]
	public string jobId = "";

	private IEnumerator Start()
	{
		if (string.IsNullOrEmpty(jobId))
		{
			Debug.LogError(jobId + " not set. This should not happen!", this);
		}
		yield return null;
		RespawnOnDrop component = GetComponent<RespawnOnDrop>();
		if (component != null)
		{
			component.ignoreDistanceFromSpawnPosition = true;
		}
		else
		{
			Debug.LogError("RespawnOnDrop not found on JobMissingLicenseReport!", this);
		}
	}

	public string GetNameParam()
	{
		return jobId;
	}

	public string GetCustomDescription()
	{
		return null;
	}
}
