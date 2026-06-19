using System.Collections.Generic;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private List<PlayerActionMode> _actionModes;

	private PlayerActionMode _currentActionsHandler;

	[SerializeField]
	private ControlGuide _escapeControlGuide;

	public static PlayerController Instance { get; private set; }

	[field: SerializeField]
	public PlayerMovement Movement { get; private set; }

	[field: SerializeField]
	public PlayerCamera Camera { get; private set; }

	[field: SerializeField]
	public PlayerInventory Inventory { get; private set; }

	[field: SerializeField]
	public PlayerStats Stats { get; private set; }

	[field: SerializeField]
	public BlankPlayerActionMode BlankActions { get; private set; }

	[field: SerializeField]
	public DefaultActionsHandler DefaultActions { get; private set; }

	[field: SerializeField]
	public PausedPlayerActions PauseActions { get; private set; }

	[field: SerializeField]
	public BuildingActionMode BuildActions { get; private set; }

	[field: SerializeField]
	public DeconstructionActionMode DeconstructionActions { get; private set; }

	[field: SerializeField]
	public UpgradePlayerActions UpgradeActions { get; private set; }

	[field: SerializeField]
	public DevConsoleActionMode DevActions { get; private set; }

	[field: SerializeField]
	public CinematicActionMode CinematicActions { get; private set; }

	[field: SerializeField]
	public PipelineActionMode PipelineActions { get; private set; }

	[field: SerializeField]
	public ItemBookActionMode ItemBookActions { get; private set; }

	public BoolContainer ModeLocked { get; private set; }

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void ToggleBuildActionState()
	{
	}

	public void ToggleCurrentActionState()
	{
	}

	public void ToggleActionHandler(PlayerActionMode setTo)
	{
	}
}
