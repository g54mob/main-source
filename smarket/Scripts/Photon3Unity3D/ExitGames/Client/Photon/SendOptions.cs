namespace ExitGames.Client.Photon
{
	public struct SendOptions
	{
		public static readonly SendOptions SendReliable;

		public static readonly SendOptions SendUnreliable;

		public DeliveryMode DeliveryMode;

		public bool Encrypt;

		public byte Channel;

		public bool Reliability
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
	}
}
