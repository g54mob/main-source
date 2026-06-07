namespace JWT
{
	public class JwtParts
	{
		private enum JwtPartsIndex
		{
			Header = 0,
			Payload = 1,
			Signature = 2
		}

		public string Header => null;

		public string Payload => null;

		public string Signature => null;

		public string[] Parts { get; }

		public JwtParts(string token)
		{
		}

		public JwtParts(string[] parts)
		{
		}
	}
}
