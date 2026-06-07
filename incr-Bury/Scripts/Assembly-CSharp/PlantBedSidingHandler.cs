using UnityEngine;

public class PlantBedSidingHandler : MonoBehaviour
{
	[SerializeField]
	private PlantBed ourPlantBed;

	private void Start()
	{
		DeparentFromOurPlantBed();
	}

	private void Update()
	{
		if (!ourPlantBed)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void DeparentFromOurPlantBed()
	{
		base.gameObject.transform.SetParent(null);
		base.gameObject.transform.eulerAngles = Vector3.zero;
	}
}
