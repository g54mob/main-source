using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Prefab Styles Data")]
public class PrefabStylesData : ScriptableObject
{
	[Header("Logic Instruction Slot Prefabs")]
	[Space(5f)]
	public GameObject keyTriggerInstructionSlotPrefab;

	public GameObject comparatorInstructionSlotPrefab;

	public GameObject setInstructionSlotPrefab;

	public GameObject accumulatorInstructionPrefab;

	public GameObject operationInstructionPrefab;

	public GameObject delayInstructionSlotPrefab;

	public GameObject groupInstructionSlorPrefab;

	[Header("Quick Inventory Prefabs")]
	[Space(5f)]
	public GameObject quickInventoryTabPrefab;

	public GameObject quickInventorySlotPrefab;

	public GameObject leQuickInventoryTabPrefab;

	public GameObject leQuickInventorySlotPrefab;
}
