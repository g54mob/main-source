using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class Rfc3280CertPathUtilities
	{
		private static readonly PkixCrlUtilities CrlUtilities;

		internal static readonly string ANY_POLICY;

		internal static readonly int KEY_CERT_SIGN;

		internal static readonly int CRL_SIGN;

		internal static readonly string[] CrlReasons;

		internal static void ProcessCrlB2(DistributionPoint dp, object cert, X509Crl crl)
		{
		}

		internal static void ProcessCertBC(PkixCertPath certPath, int index, PkixNameConstraintValidator nameConstraintValidator)
		{
		}

		internal static void PrepareNextCertA(PkixCertPath certPath, int index)
		{
		}

		internal static PkixPolicyNode ProcessCertD(PkixCertPath certPath, int index, ISet acceptablePolicies, PkixPolicyNode validPolicyTree, IList[] policyNodes, int inhibitAnyPolicy)
		{
			return null;
		}

		internal static void ProcessCrlB1(DistributionPoint dp, object cert, X509Crl crl)
		{
		}

		internal static ReasonsMask ProcessCrlD(X509Crl crl, DistributionPoint dp)
		{
			return null;
		}

		internal static ISet ProcessCrlF(X509Crl crl, object cert, X509Certificate defaultCRLSignCert, AsymmetricKeyParameter defaultCRLSignKey, PkixParameters paramsPKIX, IList certPathCerts)
		{
			return null;
		}

		internal static AsymmetricKeyParameter ProcessCrlG(X509Crl crl, ISet keys)
		{
			return null;
		}

		internal static X509Crl ProcessCrlH(ISet deltaCrls, AsymmetricKeyParameter key)
		{
			return null;
		}

		private static void CheckCrl(DistributionPoint dp, PkixParameters paramsPKIX, X509Certificate cert, DateTime validDate, X509Certificate defaultCRLSignCert, AsymmetricKeyParameter defaultCRLSignKey, CertStatus certStatus, ReasonsMask reasonMask, IList certPathCerts)
		{
		}

		protected static void CheckCrls(PkixParameters paramsPKIX, X509Certificate cert, DateTime validDate, X509Certificate sign, AsymmetricKeyParameter workingPublicKey, IList certPathCerts)
		{
		}

		internal static PkixPolicyNode PrepareCertB(PkixCertPath certPath, int index, IList[] policyNodes, PkixPolicyNode validPolicyTree, int policyMapping)
		{
			return null;
		}

		internal static ISet[] ProcessCrlA1ii(DateTime currentDate, PkixParameters paramsPKIX, X509Certificate cert, X509Crl crl)
		{
			return null;
		}

		internal static ISet ProcessCrlA1i(DateTime currentDate, PkixParameters paramsPKIX, X509Certificate cert, X509Crl crl)
		{
			return null;
		}

		internal static void ProcessCertF(PkixCertPath certPath, int index, PkixPolicyNode validPolicyTree, int explicitPolicy)
		{
		}

		internal static void ProcessCertA(PkixCertPath certPath, PkixParameters paramsPKIX, int index, AsymmetricKeyParameter workingPublicKey, X509Name workingIssuerName, X509Certificate sign)
		{
		}

		internal static int PrepareNextCertI1(PkixCertPath certPath, int index, int explicitPolicy)
		{
			return 0;
		}

		internal static int PrepareNextCertI2(PkixCertPath certPath, int index, int policyMapping)
		{
			return 0;
		}

		internal static void PrepareNextCertG(PkixCertPath certPath, int index, PkixNameConstraintValidator nameConstraintValidator)
		{
		}

		internal static int PrepareNextCertJ(PkixCertPath certPath, int index, int inhibitAnyPolicy)
		{
			return 0;
		}

		internal static void PrepareNextCertK(PkixCertPath certPath, int index)
		{
		}

		internal static int PrepareNextCertL(PkixCertPath certPath, int index, int maxPathLength)
		{
			return 0;
		}

		internal static int PrepareNextCertM(PkixCertPath certPath, int index, int maxPathLength)
		{
			return 0;
		}

		internal static void PrepareNextCertN(PkixCertPath certPath, int index)
		{
		}

		internal static void PrepareNextCertO(PkixCertPath certPath, int index, ISet criticalExtensions, IList pathCheckers)
		{
		}

		internal static int PrepareNextCertH1(PkixCertPath certPath, int index, int explicitPolicy)
		{
			return 0;
		}

		internal static int PrepareNextCertH2(PkixCertPath certPath, int index, int policyMapping)
		{
			return 0;
		}

		internal static int PrepareNextCertH3(PkixCertPath certPath, int index, int inhibitAnyPolicy)
		{
			return 0;
		}

		internal static int WrapupCertA(int explicitPolicy, X509Certificate cert)
		{
			return 0;
		}

		internal static int WrapupCertB(PkixCertPath certPath, int index, int explicitPolicy)
		{
			return 0;
		}

		internal static void WrapupCertF(PkixCertPath certPath, int index, IList pathCheckers, ISet criticalExtensions)
		{
		}

		internal static PkixPolicyNode WrapupCertG(PkixCertPath certPath, PkixParameters paramsPKIX, ISet userInitialPolicySet, int index, IList[] policyNodes, PkixPolicyNode validPolicyTree, ISet acceptablePolicies)
		{
			return null;
		}

		internal static void ProcessCrlC(X509Crl deltaCRL, X509Crl completeCRL, PkixParameters pkixParams)
		{
		}

		internal static void ProcessCrlI(DateTime validDate, X509Crl deltacrl, object cert, CertStatus certStatus, PkixParameters pkixParams)
		{
		}

		internal static void ProcessCrlJ(DateTime validDate, X509Crl completecrl, object cert, CertStatus certStatus)
		{
		}

		internal static PkixPolicyNode ProcessCertE(PkixCertPath certPath, int index, PkixPolicyNode validPolicyTree)
		{
			return null;
		}
	}
}
