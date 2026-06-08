using System;
using System.Security.Cryptography;
using AWSSDK.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Util
{
	public class CrtCrc32c : HashAlgorithm
	{
		private uint _rollingResult;

		public override void Initialize()
		{
			_rollingResult = 0u;
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			byte[] array2 = new byte[cbSize];
			Buffer.BlockCopy(array, ibStart, array2, 0, cbSize);
			_rollingResult = ChecksumCRTWrapper.Crc32C(array2, _rollingResult);
		}

		protected override byte[] HashFinal()
		{
			byte[] bytes = BitConverter.GetBytes(_rollingResult);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse((Array)bytes);
			}
			return bytes;
		}
	}
}
