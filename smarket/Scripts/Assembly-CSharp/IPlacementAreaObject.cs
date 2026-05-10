using UnityEngine;

public interface IPlacementAreaObject
{
	Bounds Bounds { get; }

	Bounds LocalBounds { get; }

	Transform transform { get; }

	GameObject gameObject { get; }

	void OnRemovedFromPlacementArea();

	void OnPlacedOnPlacementArea();
}
