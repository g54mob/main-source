using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRescuePanel : MonoBehaviour
{
	[Header("Prefab")]
	[SerializeField]
	private GameObject vehicleRescueRowPrefab;

	[Header("Content")]
	[SerializeField]
	private Transform content;

	[Header("Refresh")]
	[SerializeField]
	private float refreshInterval = 2f;

	private readonly List<VehicleRescueRowUI> spawnedRows = new List<VehicleRescueRowUI>();

	private Coroutine refreshRoutine;

	private void OnEnable()
	{
		PopulateRows();
		refreshRoutine = StartCoroutine(RefreshLoop());
	}

	private void OnDisable()
	{
		if (refreshRoutine != null)
		{
			StopCoroutine(refreshRoutine);
			refreshRoutine = null;
		}
		ClearRows();
	}

	private void PopulateRows()
	{
		ClearRows();
		if (VehicleRescueManager.Instance == null)
		{
			return;
		}
		Dictionary<T_BuildingItemSO, int> counter = new Dictionary<T_BuildingItemSO, int>();
		IReadOnlyList<VehicleRescueManager.TruckRescueEntry> trucks = VehicleRescueManager.Instance.Trucks;
		for (int i = 0; i < trucks.Count; i++)
		{
			VehicleRescueManager.TruckRescueEntry truckRescueEntry = trucks[i];
			if (!(truckRescueEntry.vehicle == null))
			{
				int nextNumber = GetNextNumber(counter, truckRescueEntry.vehicle.vehicleItem);
				VehicleRescueRowUI component = Object.Instantiate(vehicleRescueRowPrefab, content).GetComponent<VehicleRescueRowUI>();
				component.Initialize(truckRescueEntry.vehicle, 1, i, nextNumber);
				spawnedRows.Add(component);
			}
		}
		IReadOnlyList<VehicleRescueManager.ForkliftRescueEntry> forklifts = VehicleRescueManager.Instance.Forklifts;
		for (int j = 0; j < forklifts.Count; j++)
		{
			VehicleRescueManager.ForkliftRescueEntry forkliftRescueEntry = forklifts[j];
			if (!(forkliftRescueEntry.vehicle == null))
			{
				int nextNumber2 = GetNextNumber(counter, forkliftRescueEntry.vehicle.vehicleItem);
				VehicleRescueRowUI component2 = Object.Instantiate(vehicleRescueRowPrefab, content).GetComponent<VehicleRescueRowUI>();
				component2.Initialize(forkliftRescueEntry.vehicle, 0, j, nextNumber2);
				spawnedRows.Add(component2);
			}
		}
	}

	private int GetNextNumber(Dictionary<T_BuildingItemSO, int> counter, T_BuildingItemSO item)
	{
		if (item == null)
		{
			return 1;
		}
		counter.TryGetValue(item, out var value);
		return counter[item] = value + 1;
	}

	private void ClearRows()
	{
		foreach (VehicleRescueRowUI spawnedRow in spawnedRows)
		{
			if (spawnedRow != null)
			{
				Object.Destroy(spawnedRow.gameObject);
			}
		}
		spawnedRows.Clear();
	}

	private IEnumerator RefreshLoop()
	{
		WaitForSeconds wait = new WaitForSeconds(refreshInterval);
		while (true)
		{
			yield return wait;
			foreach (VehicleRescueRowUI spawnedRow in spawnedRows)
			{
				if (spawnedRow != null)
				{
					spawnedRow.RefreshStatus();
				}
			}
		}
	}
}
