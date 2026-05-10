namespace Mono.Security.Protocol.Ntlm
{
	public abstract class MessageBase
	{
		private static byte[] header;

		private int _type;

		private NtlmFlags _flags;

		public NtlmFlags Flags
		{
			get
			{
				return default(NtlmFlags);
			}
			set
			{
			}
		}

		public int Type => 0;

		protected MessageBase(int messageType)
		{
		}

		protected byte[] PrepareMessage(int messageSize)
		{
			return null;
		}

		protected virtual void Decode(byte[] message)
		{
		}

		protected bool CheckHeader(byte[] message)
		{
			return false;
		}

		public abstract byte[] GetBytes();
	}
}
