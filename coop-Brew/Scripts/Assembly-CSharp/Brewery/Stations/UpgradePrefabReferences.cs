using System;
using UnityEngine;

namespace Brewery.Stations
{
	[Serializable]
	public class UpgradePrefabReferences
	{
		[Header("Tier 1")]
		public GameObject tier1SensorPrefab;

		[Header("Tier 2")]
		public GameObject tier2SensorPrefab;

		public GameObject tier2ContainerPrefab;
	}
}
