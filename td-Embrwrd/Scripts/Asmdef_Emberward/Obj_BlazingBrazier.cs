using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Obj_BlazingBrazier : MonoBehaviour
{
	[SerializeField]
	private int range;

	[SerializeField]
	private GameObject node_Model;

	[SerializeField]
	private GameObject node_Range;

	[SerializeField]
	private Renderer renderer;

	[SerializeField]
	private ParticleSystem particle_Flame;

	private float detectInterval;

	private float detectTimer;

	private List<Vector3Int> list_AllGridsInRange;

	private List<Obj_TetrisBlock> list_ProcessedTetrisBlocks;

	private bool isOutlineOn;

	private bool isTooltipOn;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void DetectFrozenBlocks()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}
}
