using UnityEngine;

public interface IDynamicPlacementTarget
{
	Transform GetPlacementTransform();

	bool HasTower();

	void PlaceTower(ABaseTower tower)
	{
	}

	void PlaceTowerProc(ABaseTower tower);

	void RemoveTower(ABaseTower tower)
	{
	}

	void RemoveTowerProc(ABaseTower tower);

	Vector3 GetGridControlPosition()
	{
		return default(Vector3);
	}
}
