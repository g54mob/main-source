using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Obj_Trap_WallArrow : MonoBehaviour, IInteractable
{
	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float shootInterval;

	[SerializeField]
	private GameObject bulletPrefab;

	[SerializeField]
	private Transform shootPosition;

	private float shootCooldown;

	private bool isActive;

	private bool isTooltipOn;

	private bool isOutlineOn;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ToggleActive(bool isOn)
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
