using Rewired;
using UnityEngine;

public class Func_TooltipOnMouseEnter : MonoBehaviour, IInteractable
{
	[SerializeField]
	private string localization_Name_Table;

	[SerializeField]
	private string localization_Name_Key;

	[SerializeField]
	private string localization_Description_Table;

	[SerializeField]
	private string localization_Description_Key;

	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private bool isBattleModeOnly;

	[SerializeField]
	private bool doNotShowInEditMode;

	private bool isTooltipOn;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	private void ShowTooltip()
	{
	}

	private void HideTooltip()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}
}
