using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
	public float Health = 10f;

	public float HealthRate = 10f;

	public float Tier2Requirement = 20f;

	public float Tier3Requirement = 40f;

	public float Tier4Requirement = 80f;

	public bool bIsPlanted;

	public float GrowLoopDelay = 1f;

	private int Stage;

	private List<GameObject> Crops = new List<GameObject>();

	public GameObject Tier1Crop;

	public GameObject Tier2Crop;

	public GameObject Tier3Crop;

	public GameObject Tier4Crop;

	public GameObject CropContainer;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Plant()
	{
		for (int i = 0; i < CropContainer.transform.childCount; i++)
		{
			Vector3 position = CropContainer.transform.GetChild(i).transform.position;
			GameObject item = Object.Instantiate(Tier1Crop, position, Quaternion.identity);
			Crops.Add(item);
		}
		Stage = 1;
		StartCoroutine(StartGrowing());
	}

	private IEnumerator StartGrowing()
	{
		yield return new WaitForSeconds(GrowLoopDelay);
		Health += HealthRate;
		switch (Stage)
		{
		case 1:
			if (Health >= Tier2Requirement)
			{
				Grow(Tier2Crop);
				Stage++;
			}
			break;
		case 2:
			if (Health >= Tier3Requirement)
			{
				Grow(Tier3Crop);
				Stage++;
			}
			break;
		case 3:
			if (Health >= Tier4Requirement)
			{
				Grow(Tier4Crop);
				Stage++;
			}
			break;
		}
		StartCoroutine(StartGrowing());
	}

	private void Grow(GameObject NextStage)
	{
		for (int i = 0; i < Crops.Count; i++)
		{
			Object.Destroy(Crops[i]);
		}
		Crops.Clear();
		for (int j = 0; j < CropContainer.transform.childCount; j++)
		{
			Vector3 position = CropContainer.transform.GetChild(j).transform.position;
			GameObject item = Object.Instantiate(NextStage, position, Quaternion.identity);
			Crops.Add(item);
		}
	}
}
