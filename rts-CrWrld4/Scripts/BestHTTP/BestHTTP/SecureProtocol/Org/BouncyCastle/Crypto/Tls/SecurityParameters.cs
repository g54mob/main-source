namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class SecurityParameters
	{
		internal int entity;

		internal int cipherSuite;

		internal byte compressionAlgorithm;

		internal int prfAlgorithm;

		internal int verifyDataLength;

		internal byte[] masterSecret;

		internal byte[] clientRandom;

		internal byte[] serverRandom;

		internal byte[] sessionHash;

		internal byte[] pskIdentity;

		internal byte[] srpIdentity;

		internal short maxFragmentLength;

		internal bool truncatedHMac;

		internal bool encryptThenMac;

		internal bool extendedMasterSecret;

		public virtual int Entity => 0;

		public virtual int CipherSuite => 0;

		public virtual byte CompressionAlgorithm => 0;

		public virtual int PrfAlgorithm => 0;

		public virtual int VerifyDataLength => 0;

		public virtual byte[] MasterSecret => null;

		public virtual byte[] ClientRandom => null;

		public virtual byte[] ServerRandom => null;

		public virtual byte[] SessionHash => null;

		public virtual byte[] PskIdentity => null;

		public virtual byte[] SrpIdentity => null;

		public virtual bool IsExtendedMasterSecret => false;

		internal virtual void Clear()
		{
		}
	}
}
