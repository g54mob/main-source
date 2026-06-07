using UnityEngine;

public class InstructionDropZone : MonoBehaviour
{
	[SerializeField]
	private GameObject parentSlotObject;

	public bool IsRootLevel { get; set; }

	public bool IsZoneHidden { get; set; }

	public InstructionsList InstructionsList { get; set; }

	public GameObject ParentSlotObject => parentSlotObject;
}
