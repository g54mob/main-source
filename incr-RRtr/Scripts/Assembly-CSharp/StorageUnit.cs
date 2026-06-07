using UnityEngine;

public class StorageUnit : MonoBehaviour
{
	private Collider2D collider;

	[SerializeField]
	private bool fertilizerFacilityOverride;

	private void Start()
	{
		collider = GetComponent<Collider2D>();
		if (fertilizerFacilityOverride)
		{
			GameManager.ins.fertilizerFacilities.Add(collider);
		}
		else
		{
			GameManager.ins.storageUnits.Add(collider);
		}
	}

	private void OnDestroy()
	{
		if (fertilizerFacilityOverride)
		{
			GameManager.ins.fertilizerFacilities.Remove(collider);
		}
		else
		{
			GameManager.ins.storageUnits.Remove(collider);
		}
	}
}
