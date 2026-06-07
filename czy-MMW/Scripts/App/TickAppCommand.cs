public class TickAppCommand : AppCommand
{
	private float _frameTime;

	public bool Configure(float timestamp, float frameTime)
	{
		base.Timestamp = timestamp;
		_frameTime = frameTime;
		return true;
	}

	public override void Reset()
	{
		_frameTime = 0f;
	}

	public override bool Execute(IApp receiver)
	{
		receiver.Tick(base.Timestamp, _frameTime);
		return true;
	}
}
