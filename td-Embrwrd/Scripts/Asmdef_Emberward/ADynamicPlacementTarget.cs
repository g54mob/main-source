using System.Collections.Generic;
using UnityEngine;

public abstract class ADynamicPlacementTarget : MonoBehaviour, IDynamicPlacementTarget
{
	[SerializeField]
	protected List<eTowerSizeType> list_DynamicPlacementSizeType;

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	public abstract Transform GetPlacementTransform();

	public abstract bool HasTower();

	public abstract void PlaceTowerProc(ABaseTower tower);

	public abstract void RemoveTowerProc(ABaseTower tower);
}
