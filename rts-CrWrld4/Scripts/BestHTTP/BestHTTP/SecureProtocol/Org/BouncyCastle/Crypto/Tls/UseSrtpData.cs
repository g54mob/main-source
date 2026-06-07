namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class UseSrtpData
	{
		protected readonly int[] mProtectionProfiles;

		protected readonly byte[] mMki;

		public virtual int[] ProtectionProfiles => null;

		public virtual byte[] Mki => null;

		public UseSrtpData(int[] protectionProfiles, byte[] mki)
		{
		}
	}
}
