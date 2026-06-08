using System;
using System.Security.Cryptography;
using ThirdParty.Ionic.Zlib;

namespace Amazon.Runtime.Internal.Util
{
	public class Crc32Managed : HashAlgorithm
	{
		private readonly CRC32 _crc32;

		public Crc32Managed()
		{
			_crc32 = new CRC32();
		}

		public override void Initialize()
		{
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			_crc32.SlurpBlock(array, ibStart, cbSize);
		}

		protected override byte[] HashFinal()
		{
			byte[] bytes = BitConverter.GetBytes(_crc32.Crc32Result);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse((Array)bytes);
			}
			return bytes;
		}
	}
}
