using Document;

public class UITextColorMapper : UIColorMapper
{
	[ColorEntity]
	public int normalColor;

	protected override void RefreshColors(Holder holder, int applyState = 0)
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
