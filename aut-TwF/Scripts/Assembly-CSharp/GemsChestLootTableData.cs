using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GemsChestLootTableData_default", menuName = "Tower Factory/Procedural Generation/Gems Chest Loot Table Data")]
public class GemsChestLootTableData : ScriptableObject
{
	[Serializable]
	public struct FGemsChestLoot
	{
		[SerializeField]
		private GemData gemData;

		[SerializeField]
		private Vector2Int minMaxDistance;

		public GemData GemData => gemData;

		public Vector2Int MinMaxDistance => minMaxDistance;
	}

	[SerializeField]
	private List<FGemsChestLoot> loot;

	public List<FGemsChestLoot> Loot => loot;
}
