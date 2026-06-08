using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public class HashingWrapperCRC32 : HashingWrapper
	{
		public HashingWrapperCRC32()
			: base(CryptoUtilFactory.GetChecksumInstance(CoreChecksumAlgorithm.CRC32))
		{
		}
	}
}
