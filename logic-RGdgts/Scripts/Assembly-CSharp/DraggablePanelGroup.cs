using UnityEngine;

public abstract class DraggablePanelGroup : MonoBehaviour
{
	protected DraggablePanel[] panels;

	public virtual void Awake()
	{
	}

	public bool APanelIsOpen()
	{
		return false;
	}

	public abstract void OnPanelOpen(DraggablePanel panel);

	public abstract void OnPanelClose(DraggablePanel panel);
}
