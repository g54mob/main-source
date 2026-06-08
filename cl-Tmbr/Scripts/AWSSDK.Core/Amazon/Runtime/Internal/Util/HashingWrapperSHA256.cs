using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public class HashingWrapperSHA256 : HashingWrapper
	{
		public HashingWrapperSHA256()
			: base(CryptoUtilFactory.GetChecksumInstance(CoreChecksumAlgorithm.SHA256))
		{
		}
	}
}
