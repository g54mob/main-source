namespace Mono.Security.Protocol.Ntlm
{
	public class Type1Message : MessageBase
	{
		private string _host;

		private string _domain;

		public string Domain
		{
			set
			{
			}
		}

		public string Host
		{
			set
			{
			}
		}

		public Type1Message()
			: base(0)
		{
		}

		protected override void Decode(byte[] message)
		{
		}

		public override byte[] GetBytes()
		{
			return null;
		}
	}
}
