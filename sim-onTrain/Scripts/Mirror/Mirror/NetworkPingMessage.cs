namespace Mirror
{
	public struct NetworkPingMessage : NetworkMessage
	{
		public double localTime;

		public NetworkPingMessage(double value)
		{
			localTime = value;
		}
	}
}
