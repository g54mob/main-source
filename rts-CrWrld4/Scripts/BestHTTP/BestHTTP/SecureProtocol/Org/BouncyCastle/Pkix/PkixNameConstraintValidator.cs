using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixNameConstraintValidator
	{
		private static readonly DerObjectIdentifier SerialNumberOid;

		private ISet excludedSubtreesDN;

		private ISet excludedSubtreesDNS;

		private ISet excludedSubtreesEmail;

		private ISet excludedSubtreesURI;

		private ISet excludedSubtreesIP;

		private ISet excludedSubtreesOtherName;

		private ISet permittedSubtreesDN;

		private ISet permittedSubtreesDNS;

		private ISet permittedSubtreesEmail;

		private ISet permittedSubtreesURI;

		private ISet permittedSubtreesIP;

		private ISet permittedSubtreesOtherName;

		private static bool WithinDNSubtree(Asn1Sequence dns, Asn1Sequence subtree)
		{
			return false;
		}

		public void CheckPermittedDN(Asn1Sequence dn)
		{
		}

		public void CheckExcludedDN(Asn1Sequence dn)
		{
		}

		private ISet IntersectDN(ISet permitted, ISet dns)
		{
			return null;
		}

		private ISet UnionDN(ISet excluded, Asn1Sequence dn)
		{
			return null;
		}

		private ISet IntersectOtherName(ISet permitted, ISet otherNames)
		{
			return null;
		}

		private void IntersectOtherName(OtherName otherName1, OtherName otherName2, ISet intersect)
		{
		}

		private ISet UnionOtherName(ISet permitted, OtherName otherName)
		{
			return null;
		}

		private ISet IntersectEmail(ISet permitted, ISet emails)
		{
			return null;
		}

		private ISet UnionEmail(ISet excluded, string email)
		{
			return null;
		}

		private ISet IntersectIP(ISet permitted, ISet ips)
		{
			return null;
		}

		private ISet UnionIP(ISet excluded, byte[] ip)
		{
			return null;
		}

		private ISet UnionIPRange(byte[] ipWithSubmask1, byte[] ipWithSubmask2)
		{
			return null;
		}

		private ISet IntersectIPRange(byte[] ipWithSubmask1, byte[] ipWithSubmask2)
		{
			return null;
		}

		private byte[] IpWithSubnetMask(byte[] ip, byte[] subnetMask)
		{
			return null;
		}

		private byte[][] ExtractIPsAndSubnetMasks(byte[] ipWithSubmask1, byte[] ipWithSubmask2)
		{
			return null;
		}

		private byte[][] MinMaxIPs(byte[] ip1, byte[] subnetmask1, byte[] ip2, byte[] subnetmask2)
		{
			return null;
		}

		private bool IsOtherNameConstrained(OtherName constraint, OtherName otherName)
		{
			return false;
		}

		private bool IsOtherNameConstrained(ISet constraints, OtherName otherName)
		{
			return false;
		}

		private void CheckPermittedOtherName(ISet permitted, OtherName name)
		{
		}

		private void CheckExcludedOtherName(ISet excluded, OtherName name)
		{
		}

		private bool IsEmailConstrained(string constraint, string email)
		{
			return false;
		}

		private bool IsEmailConstrained(ISet constraints, string email)
		{
			return false;
		}

		private void CheckPermittedEmail(ISet permitted, string email)
		{
		}

		private void CheckExcludedEmail(ISet excluded, string email)
		{
		}

		private bool IsDnsConstrained(string constraint, string dns)
		{
			return false;
		}

		private bool IsDnsConstrained(ISet constraints, string dns)
		{
			return false;
		}

		private void CheckPermittedDns(ISet permitted, string dns)
		{
		}

		private void CheckExcludedDns(ISet excluded, string dns)
		{
		}

		private bool IsDirectoryConstrained(ISet constraints, Asn1Sequence directory)
		{
			return false;
		}

		private void CheckPermittedDirectory(ISet permitted, Asn1Sequence directory)
		{
		}

		private void CheckExcludedDirectory(ISet excluded, Asn1Sequence directory)
		{
		}

		private bool IsUriConstrained(string constraint, string uri)
		{
			return false;
		}

		private bool IsUriConstrained(ISet constraints, string uri)
		{
			return false;
		}

		private void CheckPermittedUri(ISet permitted, string uri)
		{
		}

		private void CheckExcludedUri(ISet excluded, string uri)
		{
		}

		private bool IsIPConstrained(byte[] constraint, byte[] ip)
		{
			return false;
		}

		private bool IsIPConstrained(ISet constraints, byte[] ip)
		{
			return false;
		}

		private void CheckPermittedIP(ISet permitted, byte[] ip)
		{
		}

		private void CheckExcludedIP(ISet excluded, byte[] ip)
		{
		}

		private bool WithinDomain(string testDomain, string domain)
		{
			return false;
		}

		private void UnionEmail(string email1, string email2, ISet union)
		{
		}

		private void unionURI(string email1, string email2, ISet union)
		{
		}

		private ISet IntersectDns(ISet permitted, ISet dnss)
		{
			return null;
		}

		private ISet UnionDns(ISet excluded, string dns)
		{
			return null;
		}

		private void IntersectEmail(string email1, string email2, ISet intersect)
		{
		}

		private ISet IntersectUri(ISet permitted, ISet uris)
		{
			return null;
		}

		private ISet UnionUri(ISet excluded, string uri)
		{
			return null;
		}

		private void IntersectUri(string email1, string email2, ISet intersect)
		{
		}

		private static string ExtractHostFromURL(string url)
		{
			return null;
		}

		public void checkPermitted(GeneralName name)
		{
		}

		public void checkExcluded(GeneralName name)
		{
		}

		public void IntersectPermittedSubtree(Asn1Sequence permitted)
		{
		}

		private string ExtractNameAsString(GeneralName name)
		{
			return null;
		}

		public void IntersectEmptyPermittedSubtree(int nameType)
		{
		}

		public void AddExcludedSubtree(GeneralSubtree subtree)
		{
		}

		private static byte[] Max(byte[] ip1, byte[] ip2)
		{
			return null;
		}

		private static byte[] Min(byte[] ip1, byte[] ip2)
		{
			return null;
		}

		private static int CompareTo(byte[] ip1, byte[] ip2)
		{
			return 0;
		}

		private static byte[] Or(byte[] ip1, byte[] ip2)
		{
			return null;
		}

		public int HashCode()
		{
			return 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private int HashCollection(ICollection c)
		{
			return 0;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		private bool CollectionsAreEqual(ICollection coll1, ICollection coll2)
		{
			return false;
		}

		private bool SpecialEquals(object o1, object o2)
		{
			return false;
		}

		private string StringifyIP(byte[] ip)
		{
			return null;
		}

		private string StringifyIPCollection(ISet ips)
		{
			return null;
		}

		private string StringifyOtherNameCollection(ISet otherNames)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
