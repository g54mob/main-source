using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public class HashingWrapperCRC64NVME : HashingWrapper
	{
		public HashingWrapperCRC64NVME()
			: base(CryptoUtilFactory.GetChecksumInstance(CoreChecksumAlgorithm.CRC64NVME))
		{
		}
	}
}
