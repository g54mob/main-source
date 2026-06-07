using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	internal class Rfc3281CertPathUtilities
	{
		internal static void ProcessAttrCert7(IX509AttributeCertificate attrCert, PkixCertPath certPath, PkixCertPath holderCertPath, PkixParameters pkixParams)
		{
		}

		internal static void CheckCrls(IX509AttributeCertificate attrCert, PkixParameters paramsPKIX, X509Certificate issuerCert, DateTime validDate, IList certPathCerts)
		{
		}

		internal static void AdditionalChecks(IX509AttributeCertificate attrCert, PkixParameters pkixParams)
		{
		}

		internal static void ProcessAttrCert5(IX509AttributeCertificate attrCert, PkixParameters pkixParams)
		{
		}

		internal static void ProcessAttrCert4(X509Certificate acIssuerCert, PkixParameters pkixParams)
		{
		}

		internal static void ProcessAttrCert3(X509Certificate acIssuerCert, PkixParameters pkixParams)
		{
		}

		internal static PkixCertPathValidatorResult ProcessAttrCert2(PkixCertPath certPath, PkixParameters pkixParams)
		{
			return null;
		}

		internal static PkixCertPath ProcessAttrCert1(IX509AttributeCertificate attrCert, PkixParameters pkixParams)
		{
			return null;
		}

		private static void CheckCrl(DistributionPoint dp, IX509AttributeCertificate attrCert, PkixParameters paramsPKIX, DateTime validDate, X509Certificate issuerCert, CertStatus certStatus, ReasonsMask reasonMask, IList certPathCerts)
		{
		}
	}
}
