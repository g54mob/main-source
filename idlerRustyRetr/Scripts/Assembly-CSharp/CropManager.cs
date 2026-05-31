using System;
using UnityEngine;

[ExecuteInEditMode]
public class CropManager : MonoBehaviour
{
	[Serializable]
	public struct GMO
	{
		public GmoTier tier;

		public float grow;

		public int water;

		public int biofuel;

		public int harvest;

		public int earnings;
	}

	public enum GmoTier
	{
		None = 0,
		Common = 1,
		Rare = 2,
		Legendary = 3,
		Uber = 4
	}

	public AnimalSO[] animalCatalog;

	public CropSO[] cropCatalog;

	public bool[] cropUnlocked;

	public int[] cropsHarvested;

	public GMO[] cropGmoStats;

	private void Awake()
	{
		UpdateIndexes();
		cropGmoStats = new GMO[cropCatalog.Length];
	}

	private void Update()
	{
		if (!Application.isPlaying)
		{
			cropUnlocked = new bool[cropCatalog.Length];
			cropsHarvested = new int[cropCatalog.Length];
			UpdateIndexes();
			cropGmoStats = new GMO[cropCatalog.Length];
		}
	}

	public void UpdateIndexes()
	{
		for (int i = 0; i < cropCatalog.Length; i++)
		{
			cropCatalog[i].cropIndexInList = i;
		}
		for (int j = 0; j < animalCatalog.Length; j++)
		{
			animalCatalog[j].animalIndexInList = j;
		}
	}

	public void SetGMOStatTo(int i, GMO gmo)
	{
		ResetGMO(i);
		cropGmoStats[i] = gmo;
	}

	private void ResetGMO(int i)
	{
		cropGmoStats[i] = default(GMO);
	}
}
