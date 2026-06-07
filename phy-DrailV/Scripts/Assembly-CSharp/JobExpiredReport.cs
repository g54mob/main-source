using System;
using System.Collections;
using UnityEngine;

public class JobExpiredReport : MonoBehaviour, IInventoryItemLocalizer
{
	[NonSerialized]
	public string jobId;

	private IEnumerator Start()
	{
		yield return null;
		RespawnOnDrop component = GetComponent<RespawnOnDrop>();
		if (component != null)
		{
			component.ignoreDistanceFromSpawnPosition = true;
		}
		else
		{
			Debug.LogError("RespawnOnDrop not found on JobExpiredReport!", this);
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
