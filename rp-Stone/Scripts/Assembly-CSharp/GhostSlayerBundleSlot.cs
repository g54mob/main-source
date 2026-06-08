public class GhostSlayerBundleSlot : LimitedTimeBundleSlot
{
	public AsciiString itemName;

	public AsciiString bonusKi;

	public AsciiString treasureCounts;

	protected override void Start()
	{
		base.Start();
		string value = "☆☆☆☆☆ " + Te.xt("tid_shop_staff") + " +11";
		itemName.SetValue(value);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		itemName.Draw(r, offsetX, offsetY);
		bonusKi.Draw(r, offsetX, offsetY);
		treasureCounts.Draw(r, offsetX, offsetY);
	}
}
