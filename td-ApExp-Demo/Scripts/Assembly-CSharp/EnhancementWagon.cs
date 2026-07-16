using UnityEngine;

[CreateAssetMenu(fileName = "New Wagon Size", menuName = "Wagons/Create New Wagon SO")]
public class EnhancementWagon : Enhancement
{
	public int IndexInShop;

	[field: SerializeField]
	public GameObject WagonPrefab { get; private set; }

	[field: SerializeField]
	public int ModuleSlotCount { get; private set; }
}
