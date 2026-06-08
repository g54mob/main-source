public class CustomQuestsRowUnlock : DialogButton
{
	public AsciiString newIndicator;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		newIndicator.Draw(r, offsetX, offsetY);
	}
}
