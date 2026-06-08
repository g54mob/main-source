using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public class HashingWrapperCRC32C : HashingWrapper
	{
		public HashingWrapperCRC32C()
			: base(CryptoUtilFactory.GetChecksumInstance(CoreChecksumAlgorithm.CRC32C))
		{
		}
	}
}
