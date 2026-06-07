using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[SelectionBase]
public class Obj_IceBlock : ADynamicPlacementTarget
{
	protected enum eState
	{
		IDLE = 0,
		MOVING = 1
	}

	[SerializeField]
	private float speed;

	[SerializeField]
	private eState state;

	[SerializeField]
	private List<Renderer> list_Renderers;

	[SerializeField]
	private Collider collider;

	[SerializeField]
	private Transform node_TowerPlacement;

	[SerializeField]
	private GameObject node_Arrows;

	[SerializeField]
	private List<Obj_IceBlockControlArrow> list_ControlArrows;

	private bool isRegisteredDynamicPlacementTarget;

	private bool isOutlineOn;

	private bool isTooltipOn;

	private Tweener tween;

	private eDirectionType curMoveDirection;

	private bool isArrowOn;

	private bool isClickOnThisObject;

	private ABaseTower attachedTower;

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	private void Start()
	{
	}

	private void ToggleArrows(bool isOn)
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void OnDisable()
	{
	}

	private void OnGridObjectChanged(GameObject @object)
	{
	}

	private void OnIceBlockMoveFinish(Obj_IceBlock block)
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	public void OnControlArrowClicked(eDirectionType directionType)
	{
	}

	public void Move(eDirectionType direction)
	{
	}

	private void UpdateArrows()
	{
	}

	private void LateUpdate()
	{
	}

	private bool CheckColliderHit()
	{
		return false;
	}

	private bool CheckDirectionValid(eDirectionType direction)
	{
		return false;
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
	}

	public override Transform GetPlacementTransform()
	{
		return null;
	}

	public override void PlaceTowerProc(ABaseTower tower)
	{
	}

	public override void RemoveTowerProc(ABaseTower tower)
	{
	}

	public override bool HasTower()
	{
		return false;
	}
}
