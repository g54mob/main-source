using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/CargoPool asset")]
public class CargoPoolReferences : ScriptableObject
{
	[Serializable]
	public struct CargoPoolData
	{
		public CargoEffectsType cargoEffectsType;

		public GameObject cargoEffectsPrefab;

		public int poolSize;
	}

	[Header("Cargo specific data")]
	public List<CargoPoolData> poolData = new List<CargoPoolData>();
}
