using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class SkeinParameters : ICipherParameters
	{
		public class Builder
		{
			private IDictionary parameters;

			public Builder()
			{
			}

			public Builder(IDictionary paramsMap)
			{
			}

			public Builder(SkeinParameters parameters)
			{
			}

			public Builder Set(int type, byte[] value)
			{
				return null;
			}

			public Builder SetKey(byte[] key)
			{
				return null;
			}

			public Builder SetPersonalisation(byte[] personalisation)
			{
				return null;
			}

			public Builder SetPersonalisation(DateTime date, string emailAddress, string distinguisher)
			{
				return null;
			}

			public Builder SetPublicKey(byte[] publicKey)
			{
				return null;
			}

			public Builder SetKeyIdentifier(byte[] keyIdentifier)
			{
				return null;
			}

			public Builder SetNonce(byte[] nonce)
			{
				return null;
			}

			public SkeinParameters Build()
			{
				return null;
			}
		}

		public const int PARAM_TYPE_KEY = 0;

		public const int PARAM_TYPE_CONFIG = 4;

		public const int PARAM_TYPE_PERSONALISATION = 8;

		public const int PARAM_TYPE_PUBLIC_KEY = 12;

		public const int PARAM_TYPE_KEY_IDENTIFIER = 16;

		public const int PARAM_TYPE_NONCE = 20;

		public const int PARAM_TYPE_MESSAGE = 48;

		public const int PARAM_TYPE_OUTPUT = 63;

		private IDictionary parameters;

		public SkeinParameters()
		{
		}

		private SkeinParameters(IDictionary parameters)
		{
		}

		public IDictionary GetParameters()
		{
			return null;
		}

		public byte[] GetKey()
		{
			return null;
		}

		public byte[] GetPersonalisation()
		{
			return null;
		}

		public byte[] GetPublicKey()
		{
			return null;
		}

		public byte[] GetKeyIdentifier()
		{
			return null;
		}

		public byte[] GetNonce()
		{
			return null;
		}
	}
}
