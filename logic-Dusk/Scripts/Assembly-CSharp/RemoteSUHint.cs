public class RemoteSUHint : BaseMessageHint
{
	public RemoteSUHint(object data)
		: base("use 'remote {0}' to remotely power the generator\r\n'help remote' for more info", data, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_SU_RMT", true);
		return base.Completed();
	}
}
