using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Obj_Trap_PoisonWell : MonoBehaviour, IInteractable
{
	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private Obj_AreaMonsterDetector detector;

	[Header("每秒造成怪物多少%當前生命值的傷害")]
	[SerializeField]
	private int damage;

	[SerializeField]
	private float damageInterval;

	private float damageCooldown;

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
