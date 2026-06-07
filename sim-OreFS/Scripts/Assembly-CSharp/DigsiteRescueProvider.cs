using System.Collections.Generic;
using UnityEngine;

public class DigsiteRescueProvider : MonoBehaviour
{
	[SerializeField]
	private List<Transform> truckRescuePoints = new List<Transform>();

	private void OnEnable()
	{
		if (VehicleRescueManager.Instance != null)
		{
			VehicleRescueManager.Instance.RegisterDigsiteProvider(this);
		}
	}

	private void OnDisable()
	{
		if (VehicleRescueManager.Instance != null)
		{
			VehicleRescueManager.Instance.UnregisterDigsiteProvider(this);
		}
	}

	public Transform GetTruckRescuePoint(int truckIndex)
	{
		if (truckIndex >= 0 && truckIndex < truckRescuePoints.Count)
		{
			return truckRescuePoints[truckIndex];
		}
		return null;
	}
}
