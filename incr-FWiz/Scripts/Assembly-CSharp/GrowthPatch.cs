using System.Collections.Generic;
using UnityEngine;

public class GrowthPatch : MonoBehaviour
{
	[SerializeField]
	private List<GrowthPatchPlant> _plants;

	[SerializeField]
	private Transform _itemSpawnPointMin;

	[SerializeField]
	private Transform _itemSpawnPointMax;

	public ItemType ItemType;

	public float Dir;

	public float DirRand;

	public float SendDistance;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHarvest()
	{
	}
}
