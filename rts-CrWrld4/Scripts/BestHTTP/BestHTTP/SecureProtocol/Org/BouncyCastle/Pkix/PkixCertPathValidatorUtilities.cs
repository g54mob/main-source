using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixCertPathValidatorUtilities
	{
		private static readonly PkixCrlUtilities CrlUtilities;

		internal static readonly string ANY_POLICY;

		internal static readonly string CRL_NUMBER;

		internal static readonly int KEY_CERT_SIGN;

		internal static readonly int CRL_SIGN;

		internal static readonly string[] crlReasons;

		internal static TrustAnchor FindTrustAnchor(X509Certificate cert, ISet trustAnchors)
		{
			return null;
		}

		internal static bool IsIssuerTrustAnchor(X509Certificate cert, ISet trustAnchors)
		{
			return false;
		}

		internal static void AddAdditionalStoresFromAltNames(X509Certificate cert, PkixParameters pkixParams)
		{
		}

		internal static DateTime GetValidDate(PkixParameters paramsPKIX)
		{
			return default(DateTime);
		}

		internal static X509Name GetIssuerPrincipal(object cert)
		{
			return null;
		}

		internal static bool IsSelfIssued(X509Certificate cert)
		{
			return false;
		}

		internal static AlgorithmIdentifier GetAlgorithmIdentifier(AsymmetricKeyParameter key)
		{
			return null;
		}

		internal static bool IsAnyPolicy(ISet policySet)
		{
			return false;
		}

		internal static void AddAdditionalStoreFromLocation(string location, PkixParameters pkixParams)
		{
		}

		private static BigInteger GetSerialNumber(object cert)
		{
			return null;
		}

		internal static ISet GetQualifierSet(Asn1Sequence qualifiers)
		{
			return null;
		}

		internal static PkixPolicyNode RemovePolicyNode(PkixPolicyNode validPolicyTree, IList[] policyNodes, PkixPolicyNode _node)
		{
			return null;
		}

		private static void RemovePolicyNodeRecurse(IList[] policyNodes, PkixPolicyNode _node)
		{
		}

		internal static void PrepareNextCertB1(int i, IList[] policyNodes, string id_p, IDictionary m_idp, X509Certificate cert)
		{
		}

		internal static PkixPolicyNode PrepareNextCertB2(int i, IList[] policyNodes, string id_p, PkixPolicyNode validPolicyTree)
		{
			return null;
		}

		internal static void GetCertStatus(DateTime validDate, X509Crl crl, object cert, CertStatus certStatus)
		{
		}

		internal static AsymmetricKeyParameter GetNextWorkingKey(IList certs, int index)
		{
			return null;
		}

		internal static DateTime GetValidCertDateFromValidityModel(PkixParameters paramsPkix, PkixCertPath certPath, int index)
		{
			return default(DateTime);
		}

		internal static ICollection FindCertificates(X509CertStoreSelector certSelect, IList certStores)
		{
			return null;
		}

		internal static void GetCrlIssuersFromDistributionPoint(DistributionPoint dp, ICollection issuerPrincipals, X509CrlStoreSelector selector, PkixParameters pkixParams)
		{
		}

		internal static ISet GetCompleteCrls(DistributionPoint dp, object cert, DateTime currentDate, PkixParameters paramsPKIX)
		{
			return null;
		}

		internal static ISet GetDeltaCrls(DateTime currentDate, PkixParameters paramsPKIX, X509Crl completeCRL)
		{
			return null;
		}

		private static bool isDeltaCrl(X509Crl crl)
		{
			return false;
		}

		internal static ICollection FindCertificates(X509AttrCertStoreSelector certSelect, IList certStores)
		{
			return null;
		}

		internal static void AddAdditionalStoresFromCrlDistributionPoint(CrlDistPoint crldp, PkixParameters pkixParams)
		{
		}

		internal static bool ProcessCertD1i(int index, IList[] policyNodes, DerObjectIdentifier pOid, ISet pq)
		{
			return false;
		}

		internal static void ProcessCertD1ii(int index, IList[] policyNodes, DerObjectIdentifier _poid, ISet _pq)
		{
		}

		internal static ICollection FindIssuerCerts(X509Certificate cert, PkixBuilderParameters pkixParams)
		{
			return null;
		}

		internal static Asn1Object GetExtensionValue(IX509Extension ext, DerObjectIdentifier oid)
		{
			return null;
		}
	}
}
