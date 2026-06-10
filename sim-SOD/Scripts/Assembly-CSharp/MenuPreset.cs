using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "menu_data", menuName = "Database/Menu Preset")]
public class MenuPreset : SoCustomComparison
{
	[Header("Items Sold")]
	[ReorderableList]
	public List<InteractablePreset> itemsSold;

	[Tooltip("If true a receipt will always be created with these items...")]
	public bool createReceipt;

	public AudioEvent purchaseAudio;

	[Space(7f)]
	public int syncDiskSlots;

	public List<SyncDiskPreset.Manufacturer> fromManufacturers;

	public List<SyncDiskPreset> syncDisks;
}
