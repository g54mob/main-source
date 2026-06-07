using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	public class TimeStampTokenGenerator
	{
		private int accuracySeconds;

		private int accuracyMillis;

		private int accuracyMicros;

		private bool ordering;

		private GeneralName tsa;

		private string tsaPolicyOID;

		private AsymmetricKeyParameter key;

		private X509Certificate cert;

		private string digestOID;

		private BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr;

		private BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr;

		private IX509Store x509Certs;

		private IX509Store x509Crls;

		public TimeStampTokenGenerator(AsymmetricKeyParameter key, X509Certificate cert, string digestOID, string tsaPolicyOID)
		{
		}

		public TimeStampTokenGenerator(AsymmetricKeyParameter key, X509Certificate cert, string digestOID, string tsaPolicyOID, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr, BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
		{
		}

		public void SetCertificates(IX509Store certificates)
		{
		}

		public void SetCrls(IX509Store crls)
		{
		}

		public void SetAccuracySeconds(int accuracySeconds)
		{
		}

		public void SetAccuracyMillis(int accuracyMillis)
		{
		}

		public void SetAccuracyMicros(int accuracyMicros)
		{
		}

		public void SetOrdering(bool ordering)
		{
		}

		public void SetTsa(GeneralName tsa)
		{
		}

		public TimeStampToken Generate(TimeStampRequest request, BigInteger serialNumber, DateTime genTime)
		{
			return null;
		}
	}
}
