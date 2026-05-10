using System;
using System.Security.Cryptography;
using Mono.Security.X509;

namespace Mono.Security.Authenticode
{
	public class AuthenticodeDeformatter : AuthenticodeBase
	{
		private string filename;

		private byte[] rawdata;

		private byte[] hash;

		private X509CertificateCollection coll;

		private ASN1 signedHash;

		private DateTime timestamp;

		private X509Certificate signingCertificate;

		private int reason;

		private bool trustedRoot;

		private bool trustedTimestampRoot;

		private byte[] entry;

		private X509Chain signerChain;

		private X509Chain timestampChain;

		public byte[] RawData
		{
			set
			{
			}
		}

		public X509Certificate SigningCertificate => null;

		public AuthenticodeDeformatter()
		{
		}

		public AuthenticodeDeformatter(byte[] rawData)
		{
		}

		private bool CheckSignature()
		{
			return false;
		}

		private bool CompareIssuerSerial(string issuer, byte[] serial, X509Certificate x509)
		{
			return false;
		}

		private bool VerifySignature(PKCS7.SignedData sd, byte[] calculatedMessageDigest, HashAlgorithm ha)
		{
			return false;
		}

		private bool VerifyCounterSignature(PKCS7.SignerInfo cs, byte[] signature)
		{
			return false;
		}

		private void Reset()
		{
		}
	}
}
