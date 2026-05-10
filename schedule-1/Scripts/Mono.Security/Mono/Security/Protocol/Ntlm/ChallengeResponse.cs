using System;

namespace Mono.Security.Protocol.Ntlm
{
	[Obsolete("Use of this API is highly discouraged, it selects legacy-mode LM/NTLM authentication, which sends your password in very weak encryption over the wire even if the server supports the more secure NTLMv2 / NTLMv2 Session. You need to use the new `Type3Message (Type2Message)' constructor to use the more secure NTLMv2 / NTLMv2 Session authentication modes. These require the Type 2 message from the server to compute the response.")]
	public class ChallengeResponse : IDisposable
	{
		private static byte[] magic;

		private static byte[] nullEncMagic;

		private bool _disposed;

		private byte[] _challenge;

		private byte[] _lmpwd;

		private byte[] _ntpwd;

		public string Password
		{
			set
			{
			}
		}

		public byte[] Challenge
		{
			set
			{
			}
		}

		public byte[] LM => null;

		public byte[] NT => null;

		public ChallengeResponse()
		{
		}

		public ChallengeResponse(string password, byte[] challenge)
		{
		}

		~ChallengeResponse()
		{
		}

		public void Dispose()
		{
		}

		private void Dispose(bool disposing)
		{
		}

		private byte[] GetResponse(byte[] pwd)
		{
			return null;
		}

		private byte[] PrepareDESKey(byte[] key56bits, int position)
		{
			return null;
		}

		private byte[] PasswordToKey(string password, int position)
		{
			return null;
		}
	}
}
