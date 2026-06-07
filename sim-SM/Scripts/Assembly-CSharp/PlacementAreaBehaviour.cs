using UnityEngine;

public abstract class PlacementAreaBehaviour
{
	public abstract void OnAdded(SortableBox box);

	public abstract void OnRemoved(SortableBox box);

	public abstract void HandlePlacement(SortableBox sortableBox, Vector3 localPosition, Vector3 localEulerAngles);

	public abstract void ToggleCollision(SortableBox box, bool value);
}
