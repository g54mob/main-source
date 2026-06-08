public class TransportSUHint : BaseMessageHint
{
	public TransportSUHint(int droneNumber, object data)
		: base("Room {0} has a receiver in it!  Use 'transport " + droneNumber.ToString() + " {0}'\r\nto transport drone " + droneNumber + " to that room.  'help transport'\r\nfor more info", data, 30f)
	{
	}

	public override IHintState Completed()
	{
		GameSaveFile.Save("HNT_SU_TPT", true);
		return base.Completed();
	}
}
