using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Obj_Trap_SwingAxe : MonoBehaviour, IInteractable
{
	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Obj_AreaMonsterDetector detector;

	[SerializeField]
	private List<Transform> list_TowerDetectNodes;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float vulnerableTime;

	private List<AMonsterBase> list_MonstersDetected;

	private bool isTooltipOn;

	private bool isOutlineOn;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnBattleEnd()
	{
	}

	public void TriggerDamage()
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
