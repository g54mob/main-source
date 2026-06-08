public class DockHint : BaseMessageHint
{
	public DockHint(object data)
		: base("use 'dock {0}' from schematic view to re-dock your\r\nship to airlock {0}.  'help dock' for more info", data, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_ALOCK_DOCK", true);
		return base.Completed();
	}
}
