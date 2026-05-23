using System;
using System.Collections.Generic;
using UnityEngine;

public class VisHider : MonoBehaviour
{
	[Serializable]
	public class Hideable
	{
		public GameObject go;

		public int partitionMask;
	}

	public List<Hideable> hideables = new List<Hideable>();

	public List<VisHiderPartition> partitions = new List<VisHiderPartition>();

	private int partitionBits;

	private bool firstFrame;

	private void Start()
	{
		firstFrame = true;
		foreach (VisHiderPartition partition in partitions)
		{
			partition.CheckMomentVisited();
		}
	}

	private void LateUpdate()
	{
		int num = partitionBits;
		partitionBits = 0;
		foreach (VisHiderPartition partition in partitions)
		{
			if (partition.containsPlayer)
			{
				partitionBits |= partition.bit;
			}
		}
		if (!firstFrame && num == partitionBits)
		{
			return;
		}
		foreach (Hideable hideable in hideables)
		{
			bool flag = (hideable.partitionMask & partitionBits) != 0;
			if (flag != hideable.go.activeSelf)
			{
				hideable.go.SetActive(flag);
			}
		}
		firstFrame = false;
	}
}
