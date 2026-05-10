using System.Collections;
using System.Security.Cryptography;

namespace Mono.Security.Cryptography
{
	public sealed class PKCS8
	{
		public class PrivateKeyInfo
		{
			private int _version;

			private string _algorithm;

			private byte[] _key;

			private ArrayList _list;

			public string Algorithm
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public byte[] PrivateKey
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public PrivateKeyInfo()
			{
			}

			public PrivateKeyInfo(byte[] data)
			{
			}

			private void Decode(byte[] data)
			{
			}

			public byte[] GetBytes()
			{
				return null;
			}

			private static byte[] RemoveLeadingZero(byte[] bigInt)
			{
				return null;
			}

			private static byte[] Normalize(byte[] bigInt, int length)
			{
				return null;
			}

			public static RSA DecodeRSA(byte[] keypair)
			{
				return null;
			}

			public static byte[] Encode(RSA rsa)
			{
				return null;
			}

			public static DSA DecodeDSA(byte[] privateKey, DSAParameters dsaParameters)
			{
				return null;
			}

			public static byte[] Encode(DSA dsa)
			{
				return null;
			}

			public static byte[] Encode(AsymmetricAlgorithm aa)
			{
				return null;
			}
		}

		public class EncryptedPrivateKeyInfo
		{
			private string _algorithm;

			private byte[] _salt;

			private int _iterations;

			private byte[] _data;

			public string Algorithm
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public byte[] EncryptedData
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public byte[] Salt => null;

			public int IterationCount
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public EncryptedPrivateKeyInfo()
			{
			}

			public EncryptedPrivateKeyInfo(byte[] data)
			{
			}

			private void Decode(byte[] data)
			{
			}

			public byte[] GetBytes()
			{
				return null;
			}
		}
	}
}
