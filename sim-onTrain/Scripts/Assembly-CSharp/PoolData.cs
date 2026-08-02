using System;
using UnityEngine;

[Serializable]
public class PoolData
{
	[Header("Pool Settings")]
	public string poolName;

	public GameObject prefab;

	public int poolSize;

	public bool isBlood;
}
