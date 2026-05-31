namespace ExitGames.Client.Photon
{
	public class OperationResponse
	{
		public byte OperationCode;

		public short ReturnCode;

		public string DebugMessage;

		public ParameterDictionary Parameters;

		public object this[byte parameterCode]
		{
			get
			{
				return null;
			}
			set
			{
			}
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
