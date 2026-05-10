namespace Mono.Security.Protocol.Ntlm
{
	public class Type3Message : MessageBase
	{
		private NtlmAuthLevel _level;

		private byte[] _challenge;

		private string _host;

		private string _domain;

		private string _username;

		private string _password;

		private Type2Message _type2;

		private byte[] _lm;

		private byte[] _nt;

		public string Domain
		{
			set
			{
			}
		}

		public string Password
		{
			set
			{
			}
		}

		public string Username
		{
			set
			{
			}
		}

		public Type3Message(Type2Message type2)
			: base(0)
		{
		}

		~Type3Message()
		{
		}

		protected override void Decode(byte[] message)
		{
		}

		private string DecodeString(byte[] buffer, int offset, int len)
		{
			return null;
		}

		private byte[] EncodeString(string text)
		{
			return null;
		}

		public override byte[] GetBytes()
		{
			return null;
		}
	}
}
