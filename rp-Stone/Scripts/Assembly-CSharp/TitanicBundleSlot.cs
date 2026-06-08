public class TitanicBundleSlot : LimitedTimeBundleSlot
{
	public AsciiString itemName1;

	public AsciiString itemName2;

	protected override void Start()
	{
		base.Start();
		Utils.PreloadAsyncPrefab("titanic_bundle_details_icon");
		string[] array = Utils.BreakIntoLines(Te.xt("tid_shop_blade_of_god"), Width - 2);
		if (array.Length == 1)
		{
			itemName1.SetValue(array[0]);
			itemName2.Clear();
		}
		else
		{
			itemName1.SetValue(array[0]);
			itemName2.SetValue(array[1]);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		itemName1.Draw(r, offsetX, offsetY);
		itemName2.Draw(r, offsetX, offsetY);
	}
}
