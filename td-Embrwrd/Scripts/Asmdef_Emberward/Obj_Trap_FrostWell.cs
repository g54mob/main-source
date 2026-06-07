using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Obj_Trap_FrostWell : MonoBehaviour, IInteractable
{
	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private Obj_AreaMonsterDetector detector;

	[SerializeField]
	private float chillDuration;

	[SerializeField]
	private float triggerInterval;

	private float triggerCooldown;

	private List<AMonsterBase> list_MonstersDetected;

	private bool isTooltipOn;

	private bool isOutlineOn;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnMouseOver()
	{
	}

	private void OnMouseExit()
	{
	}

	public void OnRayStay()
	{
	}

	public void OnRayExit()
	{
	}
}
