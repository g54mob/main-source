using System;
using UnityEngine;

[Serializable]
public class Customer
{
	public string name;

	public GameObject prefab;

	[Range(0f, 100f)]
	public float spawnChance;

	[Range(0f, 100f)]
	public int minimumProgressLevel;
}
