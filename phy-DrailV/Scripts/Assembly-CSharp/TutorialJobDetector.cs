using System;
using UnityEngine;

public class TutorialJobDetector : MonoBehaviour
{
	public event Action JobSpawned;

	private void OnTriggerEnter(Collider other)
	{
		if (base.enabled && other.GetComponentInChildren<JobBooklet>()?.GetComponent<InventoryItemSpec>() != null)
		{
			this.JobSpawned?.Invoke();
			base.enabled = false;
		}
	}
}
