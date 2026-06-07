using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public class AsymmetricKeyEntry : Pkcs12Entry
	{
		private readonly AsymmetricKeyParameter key;

		public AsymmetricKeyParameter Key => null;

		public AsymmetricKeyEntry(AsymmetricKeyParameter key)
			: base(null)
		{
		}

		[Obsolete]
		public AsymmetricKeyEntry(AsymmetricKeyParameter key, Hashtable attributes)
			: base(null)
		{
		}

		public AsymmetricKeyEntry(AsymmetricKeyParameter key, IDictionary attributes)
			: base(null)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
