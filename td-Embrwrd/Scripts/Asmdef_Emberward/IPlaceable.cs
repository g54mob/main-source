using System.Collections.Generic;
using UnityEngine;

public interface IPlaceable
{
	void SwitchToPlacementMode(object data);

	ePlaceableType GetPlaceableType();

	List<Collider> GetCollisionColliders();

	List<Collider> GetPlacementColliders();

	Vector3 GetPlacementOffset();

	void OnPlacementProc();
}
