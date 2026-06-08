public class NavigateHint : BaseMessageHint
{
	public NavigateHint(object data)
		: base("try 'navigate {0}' from the schematic view\r\n'help navigate' for more info", data, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_NAVIGATE", true);
		return base.Completed();
	}
}
