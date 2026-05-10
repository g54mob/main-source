using System;
using System.Collections;
using System.Security.Cryptography;
using Mono.Security.Cryptography;

namespace Mono.Security.X509
{
	public class PKCS12 : ICloneable
	{
		public class DeriveBytes
		{
			private static byte[] keyDiversifier;

			private static byte[] ivDiversifier;

			private static byte[] macDiversifier;

			private string _hashName;

			private int _iterations;

			private byte[] _password;

			private byte[] _salt;

			public string HashName
			{
				set
				{
				}
			}

			public int IterationCount
			{
				set
				{
				}
			}

			public byte[] Password
			{
				set
				{
				}
			}

			public byte[] Salt
			{
				set
				{
				}
			}

			private void Adjust(byte[] a, int aOff, byte[] b)
			{
			}

			private byte[] Derive(byte[] diversifier, int n)
			{
				return null;
			}

			public byte[] DeriveKey(int size)
			{
				return null;
			}

			public byte[] DeriveIV(int size)
			{
				return null;
			}

			public byte[] DeriveMAC(int size)
			{
				return null;
			}
		}

		private byte[] _password;

		private ArrayList _keyBags;

		private ArrayList _secretBags;

		private X509CertificateCollection _certs;

		private bool _keyBagsChanged;

		private bool _secretBagsChanged;

		private bool _certsChanged;

		private int _iterations;

		private ArrayList _safeBags;

		private RandomNumberGenerator _rng;

		private static int password_max_length;

		public string Password
		{
			set
			{
			}
		}

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

		public ArrayList Keys => null;

		public X509CertificateCollection Certificates => null;

		internal RandomNumberGenerator RNG => null;

		public static int MaximumPasswordLength => 0;

		public PKCS12()
		{
		}

		public PKCS12(byte[] data)
		{
		}

		public PKCS12(byte[] data, string password)
		{
		}

		private void Decode(byte[] data)
		{
		}

		~PKCS12()
		{
		}

		private bool Compare(byte[] expected, byte[] actual)
		{
			return false;
		}

		private SymmetricAlgorithm GetSymmetricAlgorithm(string algorithmOid, byte[] salt, int iterationCount)
		{
			return null;
		}

		public byte[] Decrypt(string algorithmOid, byte[] salt, int iterationCount, byte[] encryptedData)
		{
			return null;
		}

		public byte[] Decrypt(PKCS7.EncryptedData ed)
		{
			return null;
		}

		public byte[] Encrypt(string algorithmOid, byte[] salt, int iterationCount, byte[] data)
		{
			return null;
		}

		private DSAParameters GetExistingParameters(out bool found)
		{
			found = default(bool);
			return default(DSAParameters);
		}

		private void AddPrivateKey(PKCS8.PrivateKeyInfo pki)
		{
		}

		private void ReadSafeBag(ASN1 safeBag)
		{
		}

		private ASN1 Pkcs8ShroudedKeyBagSafeBag(AsymmetricAlgorithm aa, IDictionary attributes)
		{
			return null;
		}

		private ASN1 CertificateSafeBag(X509Certificate x509, IDictionary attributes)
		{
			return null;
		}

		private byte[] MAC(byte[] password, byte[] salt, int iterations, byte[] data)
		{
			return null;
		}

		public byte[] GetBytes()
		{
			return null;
		}

		private PKCS7.ContentInfo EncryptedContentInfo(ASN1 safeBags, string algorithmOid)
		{
			return null;
		}

		public void AddCertificate(X509Certificate cert)
		{
		}

		public void AddCertificate(X509Certificate cert, IDictionary attributes)
		{
		}

		public void RemoveCertificate(X509Certificate cert)
		{
		}

		public void RemoveCertificate(X509Certificate cert, IDictionary attrs)
		{
		}

		private bool CompareAsymmetricAlgorithm(AsymmetricAlgorithm a1, AsymmetricAlgorithm a2)
		{
			return false;
		}

		public void AddPkcs8ShroudedKeyBag(AsymmetricAlgorithm aa, IDictionary attributes)
		{
		}

		public object Clone()
		{
			return null;
		}
	}
}
