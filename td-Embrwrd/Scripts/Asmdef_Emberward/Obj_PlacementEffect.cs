using System;
using System.Collections.Generic;
using UnityEngine;

public class Obj_PlacementEffect : MonoBehaviour
{
	[Serializable]
	public class RingMaterialSet
	{
		public eTowerRangeType rangeType;

		public Material placementMode;

		public Material disabled;
	}

	[SerializeField]
	private Transform node_RangeRingScale;

	[SerializeField]
	private Renderer renderer_RangeRing;

	[SerializeField]
	private List<RingMaterialSet> list_RingMaterialSet;

	[SerializeField]
	private Spin spin;

	[SerializeField]
	private Vector3 ringSpinSpeed_Fast;

	[SerializeField]
	private Vector3 ringSpinSpeed_Slow;

	[SerializeField]
	[Header("材質控制功能")]
	private ObjectMaterialControl materialControl;

	private ePlacementStatus curStatus;

	private ABaseTower targetTower;

	private float attackRange;

	private float minAttackRange;

	public void Initialize(Transform target, ABaseTower tower)
	{
	}

	private void Update()
	{
	}

	public void SetStatus(ePlacementStatus status)
	{
	}

	private bool IsStatusAvaliable(ePlacementStatus status)
	{
		return false;
	}

	public void SetRingCenter(Vector3 center)
	{
	}

	public void SetRingRange(float range, float minRange = 0f)
	{
	}

	private void UpdateRingRangeSetting()
	{
	}

	public void SetRingType(ePlacementStatus status, eTowerRangeType rangeType)
	{
	}
}
