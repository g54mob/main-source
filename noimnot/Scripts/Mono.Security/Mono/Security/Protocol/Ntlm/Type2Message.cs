namespace Mono.Security.Protocol.Ntlm
{
	public class Type2Message : MessageBase
	{
		private byte[] _nonce;

		private string _targetName;

		private byte[] _targetInfo;

		public byte[] Nonce => null;

		public string TargetName => null;

		public byte[] TargetInfo => null;

		public Type2Message(byte[] message)
			: base(0)
		{
		}

		~Type2Message()
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
