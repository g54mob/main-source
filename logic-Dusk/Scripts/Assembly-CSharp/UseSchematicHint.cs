public class UseSchematicHint : BaseMessageHint
{
	public UseSchematicHint()
		: base("Try issuing commands from the schematic view", null, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_SV_INPUT", true);
		return base.Completed();
	}
}
