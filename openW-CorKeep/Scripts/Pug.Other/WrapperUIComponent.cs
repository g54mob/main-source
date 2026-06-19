public class WrapperUIComponent : UIComponentMonoBehaviour
{
	public PivotPosition pivot;

	public int renderWidthPixels;

	public int renderHeightPixels;

	public override PivotPosition GetUIComponentPivotPosition()
	{
		return pivot;
	}

	public override float GetUIComponentRenderWidth()
	{
		return (float)renderWidthPixels * 0.0625f;
	}

	public override float GetUIComponentRenderHeight()
	{
		return (float)renderHeightPixels * 0.0625f;
	}
}
