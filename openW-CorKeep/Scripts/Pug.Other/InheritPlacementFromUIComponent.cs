using NaughtyAttributes;

public class InheritPlacementFromUIComponent : UIComponentMonoBehaviour
{
	public UIComponentMonoBehaviour uiComponent;

	public bool inheritWidth = true;

	[HideIf("inheritWidth")]
	[AllowNesting]
	public float width;

	public bool inheritHeight = true;

	[HideIf("inheritHeight")]
	[AllowNesting]
	public float height;

	public bool inheritPivotPosition = true;

	[HideIf("inheritPivotPosition")]
	[AllowNesting]
	public PivotPosition pivotPosition;

	public override void RenderUIComponent(bool force = false)
	{
		uiComponent.RenderUIComponent(force);
	}

	public override float GetUIComponentRenderWidth()
	{
		if (!inheritWidth)
		{
			return width;
		}
		return uiComponent.GetUIComponentRenderWidth();
	}

	public override float GetUIComponentRenderHeight()
	{
		if (!inheritHeight)
		{
			return height;
		}
		return uiComponent.GetUIComponentRenderHeight();
	}

	protected override bool IsUIComponentRenderingDependentOnChildren()
	{
		return false;
	}

	public override PivotPosition GetUIComponentPivotPosition()
	{
		if (!inheritPivotPosition)
		{
			return pivotPosition;
		}
		return uiComponent.GetUIComponentPivotPosition();
	}
}
