using UnityEngine;

[SelectionBase]
public class Obj_WaterBarrel : ADynamicPlacementTarget, IInteractable
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Renderer renderer_Barrel;

	[SerializeField]
	private Transform node_PlacementPosition;

	[SerializeField]
	private ABaseTower attachedTower;

	private bool isAnimPlaying;

	public bool IsAnimPlaying => false;

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
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

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}
}
