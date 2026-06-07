using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestLootTableData_default", menuName = "Tower Factory/Procedural Generation/Chest Loot Table Data")]
public class ChestLootTableData : ScriptableObject
{
	[Serializable]
	public struct FChestLoot
	{
		[SerializeField]
		private ResourceData resource;

		[SerializeField]
		private Vector2Int minMaxDistance;

		public ResourceData Resource => resource;

		public Vector2Int MinMaxDistance => minMaxDistance;
	}

	[SerializeField]
	private List<FChestLoot> loot;

	public List<FChestLoot> Loot => loot;
}
