namespace Mono.Security.Protocol.Ntlm
{
	public static class ChallengeResponse2
	{
		private static byte[] magic;

		private static byte[] nullEncMagic;

		private static byte[] Compute_LM(string password, byte[] challenge)
		{
			return null;
		}

		private static byte[] Compute_NTLM_Password(string password)
		{
			return null;
		}

		private static byte[] Compute_NTLM(string password, byte[] challenge)
		{
			return null;
		}

		private static void Compute_NTLMv2_Session(string password, byte[] challenge, out byte[] lm, out byte[] ntlm)
		{
			lm = null;
			ntlm = null;
		}

		private static byte[] Compute_NTLMv2(Type2Message type2, string username, string password, string domain)
		{
			return null;
		}

		public static void Compute(Type2Message type2, NtlmAuthLevel level, string username, string password, string domain, out byte[] lm, out byte[] ntlm)
		{
			lm = null;
			ntlm = null;
		}

		private static byte[] GetResponse(byte[] challenge, byte[] pwd)
		{
			return null;
		}

		private static byte[] PrepareDESKey(byte[] key56bits, int position)
		{
			return null;
		}

		private static byte[] PasswordToKey(string password, int position)
		{
			return null;
		}
	}
}
