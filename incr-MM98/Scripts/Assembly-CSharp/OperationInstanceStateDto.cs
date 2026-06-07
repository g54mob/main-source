using MessagePack;

[MessagePackObject(false)]
public class OperationInstanceStateDto
{
	[Key(0)]
	public float Time;

	[Key(1)]
	public float Duration;
}
