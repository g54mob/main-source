using System.Collections.Generic;
using UnityEngine;

public class Func_OutlineOnMouseEnter : MonoBehaviour, IInteractable
{
	[SerializeField]
	private OutlineController.eOutlineType outlineType;

	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private bool isBattleModeOnly;

	[SerializeField]
	private bool isExcludeEditmode;

	[SerializeField]
	private bool isExcludeBuffmode;

	[SerializeField]
	private bool isLevelNotFinishedOnly;

	private bool isOutlineOn;

	private void Reset()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	private void ShowOutline()
	{
	}

	private void HideOutline()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}
}
