using System;
using System.Collections;
using System.Reflection;
using System.Security.Cryptography;

namespace Mono.Security.X509
{
	[DefaultMember("Item")]
	public class X509Crl
	{
		public class X509CrlEntry
		{
			private byte[] sn;

			private DateTime revocationDate;

			private X509ExtensionCollection extensions;

			public byte[] SerialNumber => null;

			public DateTime RevocationDate => default(DateTime);

			public X509ExtensionCollection Extensions => null;

			internal X509CrlEntry(ASN1 entry)
			{
			}
		}

		private string issuer;

		private byte version;

		private DateTime thisUpdate;

		private DateTime nextUpdate;

		private ArrayList entries;

		private string signatureOID;

		private byte[] signature;

		private X509ExtensionCollection extensions;

		private byte[] encoded;

		private byte[] hash_value;

		public X509ExtensionCollection Extensions => null;

		public byte[] Hash => null;

		public string IssuerName => null;

		public DateTime NextUpdate => default(DateTime);

		public X509Crl(byte[] crl)
		{
		}

		private void Parse(byte[] crl)
		{
		}

		private bool Compare(byte[] array1, byte[] array2)
		{
			return false;
		}

		public X509CrlEntry GetCrlEntry(X509Certificate x509)
		{
			return null;
		}

		public X509CrlEntry GetCrlEntry(byte[] serialNumber)
		{
			return null;
		}

		internal bool VerifySignature(DSA dsa)
		{
			return false;
		}

		internal bool VerifySignature(RSA rsa)
		{
			return false;
		}

		public bool VerifySignature(AsymmetricAlgorithm aa)
		{
			return false;
		}
	}
}
