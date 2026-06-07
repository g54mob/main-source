using UnityEngine;

public class DrawerContentModule : DrawerContent
{
	public ModuleGestaltVariationEnum moduleGestaltVariationId;

	private int rotation;

	protected Module module;

	protected Vector2 size;

	protected Vector2 pivot;

	public override void Init(float position, int sortingLayerID, int sortingOrder, DraggablePanel.Direction direction)
	{
	}

	public virtual void SetModule(ModuleGestaltVariationEnum moduleGestaltVariationId, int rotation)
	{
	}

	public override float GetSize(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMin(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public override float GetMax(DraggablePanel.Direction direction)
	{
		return 0f;
	}

	public Module GetModule()
	{
		return null;
	}

	protected virtual bool IsModuleVisible()
	{
		return false;
	}

	protected void RefreshModuleVisibility()
	{
	}

	private void LateUpdate()
	{
	}
}
