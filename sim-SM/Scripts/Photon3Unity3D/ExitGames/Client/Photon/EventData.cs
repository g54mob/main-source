namespace ExitGames.Client.Photon
{
	public class EventData
	{
		public byte Code;

		public readonly ParameterDictionary Parameters;

		public byte SenderKey;

		private int sender;

		public byte CustomDataKey;

		private object customData;

		public object this[byte key]
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public int Sender
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public object CustomData
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		internal void Reset()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToStringFull()
		{
			return null;
		}
	}
}
