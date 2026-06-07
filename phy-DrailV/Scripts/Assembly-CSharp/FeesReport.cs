using System;
using System.Collections;
using UnityEngine;

public class FeesReport : MonoBehaviour, IInventoryItemLocalizer
{
	[NonSerialized]
	public string feeId;

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
			Debug.LogError("RespawnOnDrop not found on FeesReport!", this);
		}
	}

	public string GetNameParam()
	{
		return feeId;
	}

	public string GetCustomDescription()
	{
		return null;
	}
}
