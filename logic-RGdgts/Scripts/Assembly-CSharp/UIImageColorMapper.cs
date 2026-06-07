using Document;

public class UIImageColorMapper : UIColorMapper
{
	[ColorEntity]
	public int normalColor;

	protected override void RefreshColors(Holder holder, int stateToApply = 0)
	{
	}

	public int GetColorEntity()
	{
		return 0;
	}

	public void SetColorEntity(DocumentElementsColor elementColor)
	{
	}
}
