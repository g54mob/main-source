namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal class CombinedHash : TlsHandshakeHash, IDigest
	{
		protected TlsContext mContext;

		protected IDigest mMd5;

		protected IDigest mSha1;

		public virtual string AlgorithmName => null;

		internal CombinedHash()
		{
		}

		internal CombinedHash(CombinedHash t)
		{
		}

		public virtual void Init(TlsContext context)
		{
		}

		public virtual TlsHandshakeHash NotifyPrfDetermined()
		{
			return null;
		}

		public virtual void TrackHashAlgorithm(byte hashAlgorithm)
		{
		}

		public virtual void SealHashAlgorithms()
		{
		}

		public virtual TlsHandshakeHash StopTracking()
		{
			return null;
		}

		public virtual IDigest ForkPrfHash()
		{
			return null;
		}

		public virtual byte[] GetFinalHash(byte hashAlgorithm)
		{
			return null;
		}

		public virtual int GetByteLength()
		{
			return 0;
		}

		public virtual int GetDigestSize()
		{
			return 0;
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		protected virtual void Ssl3Complete(IDigest d, byte[] ipad, byte[] opad, int padLength)
		{
		}
	}
}
