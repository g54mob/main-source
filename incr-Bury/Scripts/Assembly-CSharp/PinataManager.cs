using System.Collections.Generic;
using UnityEngine;

public class PinataManager : MonoBehaviour
{
	public static PinataManager Singleton;

	private bool hasSpawnedPinatas;

	[SerializeField]
	private List<Transform> pinataSpawnZones_0;

	[SerializeField]
	private List<Transform> pinataSpawnZones_1;

	[SerializeField]
	private List<Transform> pinataSpawnZones_2;

	[SerializeField]
	private List<Transform> pinataSpawnZones_3;

	[SerializeField]
	private List<Transform> pinataSpawnZones_4;

	private List<List<Transform>> pinataSpawnZones_Master = new List<List<Transform>>();

	[SerializeField]
	private GameObject pinata_Prefab;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		SetupMasterSpawnZonesList();
	}

	private void Update()
	{
		if (!hasSpawnedPinatas && GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			SpawnPinatas();
			hasSpawnedPinatas = true;
		}
	}

	private void SetupMasterSpawnZonesList()
	{
		pinataSpawnZones_Master.Add(pinataSpawnZones_0);
		pinataSpawnZones_Master.Add(pinataSpawnZones_1);
		pinataSpawnZones_Master.Add(pinataSpawnZones_2);
		pinataSpawnZones_Master.Add(pinataSpawnZones_3);
		pinataSpawnZones_Master.Add(pinataSpawnZones_4);
	}

	private void SpawnPinatas()
	{
		if (PlayerStats.Singleton.pinata_Unlocked)
		{
			for (int i = 0; i <= PlayerStats.Singleton.pinata_ZoneSpawnTier && i <= PlayerStats.Singleton.pinata_ZoneSpawnTier; i++)
			{
				Vector3 position = pinataSpawnZones_Master[i][Random.Range(0, pinataSpawnZones_Master[i].Count)].position;
				position.y = Random.Range(7f, 9f);
				Object.Instantiate(pinata_Prefab, position, Quaternion.Euler(new Vector3(0f, Random.Range(0, 360), 0f))).GetComponent<Pinata>().SetPinataTier(i);
			}
		}
	}
}
