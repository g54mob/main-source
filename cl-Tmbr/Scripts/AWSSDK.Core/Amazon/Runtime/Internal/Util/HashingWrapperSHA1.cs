using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public class HashingWrapperSHA1 : HashingWrapper
	{
		public HashingWrapperSHA1()
			: base(CryptoUtilFactory.GetChecksumInstance(CoreChecksumAlgorithm.SHA1))
		{
		}
	}
}
