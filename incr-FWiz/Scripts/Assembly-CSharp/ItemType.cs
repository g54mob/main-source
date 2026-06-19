using FMODUnity;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Item Type", menuName = "Project/Item Type")]
public class ItemType : ScriptableObject, ICheckpoint
{
	public string ID;

	public LocalizedString Title;

	public Sprite Icon;

	public EventReference CollectSound;

	public EventReference DropSound;

	public float FuelValue;

	public bool DemoLocked;

	public Checkpoint HintCheckpoint;

	public LocalizedString SourceTitle;

	public string CheckpointID => null;
}
