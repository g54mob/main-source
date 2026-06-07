using System;
using UnityEngine;

[SelectionBase]
public class Obj_ScrapMasterPlatform_1x1 : ADynamicPlacementTarget, IInteractable
{
	[SerializeField]
	private Renderer renderer_Platform;

	[SerializeField]
	private Transform node_PlacementPosition;

	[SerializeField]
	private ParticleSystem particle_BuildTowerNotify;

	[SerializeField]
	private ABaseTower attachedTower;

	private bool isAnimPlaying;

	public Action<ABaseTower> OnTowerPlaced;

	[SerializeField]
	private int damagePercentage;

	[SerializeField]
	private int rangePercentage;

	private Vector3 lastFramePosition;

	private bool isInitialized;

	public bool IsAnimPlaying => false;

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	private void Start()
	{
	}

	public void Initialize()
	{
	}

	public override Transform GetPlacementTransform()
	{
		return null;
	}

	private void Update()
	{
	}

	public override void PlaceTowerProc(ABaseTower tower)
	{
	}

	public void ScaleAroundPoint(Transform target, Vector3 pivot, float scaleFactor)
	{
	}

	public override void RemoveTowerProc(ABaseTower tower)
	{
	}

	public override bool HasTower()
	{
		return false;
	}

	public void SetTowerBuff(int damagePercentage, int rangePercentage)
	{
	}

	public void UpdateTowerBuff()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayStay()
	{
	}

	public void OnRayExit()
	{
	}

	public void OnRayClickDown()
	{
	}

	public void OnRayClickHold()
	{
	}

	public void OnRayClickUp()
	{
	}
}
