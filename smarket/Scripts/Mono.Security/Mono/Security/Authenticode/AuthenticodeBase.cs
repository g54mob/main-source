using System.IO;
using System.Security.Cryptography;

namespace Mono.Security.Authenticode
{
	public class AuthenticodeBase
	{
		private byte[] fileblock;

		private Stream fs;

		private int blockNo;

		private int blockLength;

		private int peOffset;

		private int dirSecurityOffset;

		private int dirSecuritySize;

		private int coffSymbolTableOffset;

		private bool pe64;

		internal int PEOffset => 0;

		internal void Open(string filename)
		{
		}

		internal void Open(byte[] rawdata)
		{
		}

		internal void Close()
		{
		}

		internal void ReadFirstBlock()
		{
		}

		internal int ProcessFirstBlock()
		{
			return 0;
		}

		internal byte[] GetSecurityEntry()
		{
			return null;
		}

		internal byte[] GetHash(HashAlgorithm hash)
		{
			return null;
		}
	}
}
