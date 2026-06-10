using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "actions_data", menuName = "Database/Interactable Actions Preset")]
public class InteractableActionsPreset : SoCustomComparison
{
	[Tooltip("Additional actions able to be performed")]
	[BoxGroup("Primary Actions")]
	public List<InteractablePreset.InteractionAction> actions;

	[Space(7f)]
	[BoxGroup("Locked-in Interaction 1")]
	[Tooltip("Disable the collider when locked-in")]
	public bool disableCollider;

	[BoxGroup("Locked-in Interaction 1")]
	public List<InteractablePreset.InteractionAction> lockedInActions1;

	[BoxGroup("Locked-in Interaction 2")]
	[Space(7f)]
	public List<InteractablePreset.InteractionAction> lockedInActions2;

	[Space(7f)]
	[BoxGroup("Physics Pick Up Actions")]
	public List<InteractablePreset.InteractionAction> physicsActions;
}
