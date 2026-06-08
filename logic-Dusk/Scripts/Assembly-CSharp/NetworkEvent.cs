public class NetworkEvent
{
	public NetworkEventType Type { get; set; }

	public object Data { get; set; }

	public NetworkEvent(NetworkEventType type)
	{
		Type = type;
	}

	public NetworkEvent(NetworkEventType type, object data)
	{
		Type = type;
		Data = data;
	}
}
