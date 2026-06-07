using UnityEngine;

public abstract class DrawerContent : MonoBehaviour
{
	public float position;

	public DraggablePanel.Direction direction;

	public virtual void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
	{
	}

	public abstract float GetSize(DraggablePanel.Direction direction);

	public abstract float GetMin(DraggablePanel.Direction direction);

	public abstract float GetMax(DraggablePanel.Direction direction);
}
