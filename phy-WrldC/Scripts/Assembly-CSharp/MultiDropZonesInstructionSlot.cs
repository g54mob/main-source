using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MultiDropZonesInstructionSlot : InstructionSlotBase
{
	[SerializeField]
	private InstructionDropZone[] instructionDropZones;

	[SerializeField]
	private Button[] buttons;

	[SerializeField]
	private TextMeshProUGUI[] buttonsIcons;

	public InstructionDropZone[] InstructionDropZones => instructionDropZones;

	protected override void Awake()
	{
		base.Awake();
		for (int i = 0; i < buttons.Length; i++)
		{
			Button obj = buttons[i];
			InstructionDropZone instructionDropZone = instructionDropZones[i];
			TextMeshProUGUI buttonIcon = buttonsIcons[i];
			obj.onClick.AddListener(delegate
			{
				ButtonHandler(instructionDropZone, buttonIcon);
			});
		}
	}

	protected virtual void InternalInitialize(Instruction instruction)
	{
		if (instructionDropZones.Length >= 1)
		{
			instructionDropZones[0].InstructionsList = instruction.FirstInstructionsList;
		}
		if (instructionDropZones.Length >= 2)
		{
			instructionDropZones[1].InstructionsList = instruction.SecondInstructionsList;
		}
		SetZoneVisibility(0, !instruction.FirstInstructionsList.IsListHidden);
		SetZoneVisibility(1, !instruction.SecondInstructionsList.IsListHidden);
	}

	private void ButtonHandler(InstructionDropZone instructionDropZone, TextMeshProUGUI buttonIcon)
	{
		instructionDropZone.gameObject.SetActive(!instructionDropZone.gameObject.activeSelf);
		instructionDropZone.IsZoneHidden = !instructionDropZone.gameObject.activeSelf;
		instructionDropZone.InstructionsList.IsListHidden = instructionDropZone.IsZoneHidden;
		buttonIcon.SetText(instructionDropZone.gameObject.activeSelf ? "\uf056" : "\uf055");
	}

	private void SetZoneVisibility(int zoneIndex, bool isVisible)
	{
		if (zoneIndex < instructionDropZones.Length)
		{
			instructionDropZones[zoneIndex].gameObject.SetActive(isVisible);
			instructionDropZones[zoneIndex].IsZoneHidden = !isVisible;
			instructionDropZones[zoneIndex].InstructionsList.IsListHidden = !isVisible;
			buttonsIcons[zoneIndex].SetText(isVisible ? "\uf056" : "\uf055");
		}
	}
}
