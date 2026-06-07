namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class SupplementalDataEntry
	{
		protected readonly int mDataType;

		protected readonly byte[] mData;

		public virtual int DataType => 0;

		public virtual byte[] Data => null;

		public SupplementalDataEntry(int dataType, byte[] data)
		{
		}
	}
}
