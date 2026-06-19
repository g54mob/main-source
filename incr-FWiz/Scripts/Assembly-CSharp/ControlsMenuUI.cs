using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsMenuUI : MonoBehaviour
{
	private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

	private ControlsMenuUIControl _selectedControl;

	[SerializeField]
	private ControlsMenuUIControl _controlUIPrefab;

	private List<ControlsMenuUIControl> _controlUIs;

	[SerializeField]
	private Transform _controlUIsParent;

	private static readonly string[] _controlsExcludedInRebind;

	public EventReference StartRebindSound;

	public EventReference CompleteRebindSound;

	public EventReference CancelRebindSound;

	private void OnEnable()
	{
	}

	public void SelectControl(ControlsMenuUIControl control)
	{
	}

	public void StartInteractiveRebind()
	{
	}

	private void RebindCompleted()
	{
	}

	private void RebindCancelled()
	{
	}

	public void OnEndRebind()
	{
	}

	private void OnDisable()
	{
	}
}
