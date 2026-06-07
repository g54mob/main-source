using System.Collections;
using System.Text;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class X509Name : Asn1Encodable
	{
		public static readonly DerObjectIdentifier C;

		public static readonly DerObjectIdentifier O;

		public static readonly DerObjectIdentifier OU;

		public static readonly DerObjectIdentifier T;

		public static readonly DerObjectIdentifier CN;

		public static readonly DerObjectIdentifier Street;

		public static readonly DerObjectIdentifier SerialNumber;

		public static readonly DerObjectIdentifier L;

		public static readonly DerObjectIdentifier ST;

		public static readonly DerObjectIdentifier Surname;

		public static readonly DerObjectIdentifier GivenName;

		public static readonly DerObjectIdentifier Initials;

		public static readonly DerObjectIdentifier Generation;

		public static readonly DerObjectIdentifier UniqueIdentifier;

		public static readonly DerObjectIdentifier BusinessCategory;

		public static readonly DerObjectIdentifier PostalCode;

		public static readonly DerObjectIdentifier DnQualifier;

		public static readonly DerObjectIdentifier Pseudonym;

		public static readonly DerObjectIdentifier DateOfBirth;

		public static readonly DerObjectIdentifier PlaceOfBirth;

		public static readonly DerObjectIdentifier Gender;

		public static readonly DerObjectIdentifier CountryOfCitizenship;

		public static readonly DerObjectIdentifier CountryOfResidence;

		public static readonly DerObjectIdentifier NameAtBirth;

		public static readonly DerObjectIdentifier PostalAddress;

		public static readonly DerObjectIdentifier DmdName;

		public static readonly DerObjectIdentifier TelephoneNumber;

		public static readonly DerObjectIdentifier OrganizationIdentifier;

		public static readonly DerObjectIdentifier Name;

		public static readonly DerObjectIdentifier EmailAddress;

		public static readonly DerObjectIdentifier UnstructuredName;

		public static readonly DerObjectIdentifier UnstructuredAddress;

		public static readonly DerObjectIdentifier E;

		public static readonly DerObjectIdentifier DC;

		public static readonly DerObjectIdentifier UID;

		private static readonly bool[] defaultReverse;

		public static readonly Hashtable DefaultSymbols;

		public static readonly Hashtable RFC2253Symbols;

		public static readonly Hashtable RFC1779Symbols;

		public static readonly Hashtable DefaultLookup;

		private readonly IList ordering;

		private readonly X509NameEntryConverter converter;

		private IList values;

		private IList added;

		private Asn1Sequence seq;

		private string cachedStrRepresentation;

		public static bool DefaultReverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		static X509Name()
		{
		}

		public static X509Name GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static X509Name GetInstance(object obj)
		{
			return null;
		}

		protected X509Name()
		{
		}

		protected X509Name(Asn1Sequence seq)
		{
		}

		public X509Name(IList ordering, IDictionary attributes)
		{
		}

		public X509Name(IList ordering, IDictionary attributes, X509NameEntryConverter converter)
		{
		}

		public X509Name(IList oids, IList values)
		{
		}

		public X509Name(IList oids, IList values, X509NameEntryConverter converter)
		{
		}

		public X509Name(string dirName)
		{
		}

		public X509Name(string dirName, X509NameEntryConverter converter)
		{
		}

		public X509Name(bool reverse, string dirName)
		{
		}

		public X509Name(bool reverse, string dirName, X509NameEntryConverter converter)
		{
		}

		public X509Name(bool reverse, IDictionary lookUp, string dirName)
		{
		}

		private DerObjectIdentifier DecodeOid(string name, IDictionary lookUp)
		{
			return null;
		}

		public X509Name(bool reverse, IDictionary lookUp, string dirName, X509NameEntryConverter converter)
		{
		}

		public IList GetOidList()
		{
			return null;
		}

		public IList GetValueList()
		{
			return null;
		}

		public IList GetValueList(DerObjectIdentifier oid)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public bool Equivalent(X509Name other, bool inOrder)
		{
			return false;
		}

		public bool Equivalent(X509Name other)
		{
			return false;
		}

		private static bool equivalentStrings(string s1, string s2)
		{
			return false;
		}

		private static string canonicalize(string s)
		{
			return null;
		}

		private static Asn1Object decodeObject(string v)
		{
			return null;
		}

		private static string stripInternalSpaces(string str)
		{
			return null;
		}

		private void AppendValue(StringBuilder buf, IDictionary oidSymbols, DerObjectIdentifier oid, string val)
		{
		}

		public string ToString(bool reverse, IDictionary oidSymbols)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
