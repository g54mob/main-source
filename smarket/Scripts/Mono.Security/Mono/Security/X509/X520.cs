namespace Mono.Security.X509
{
	public class X520
	{
		public abstract class AttributeTypeAndValue
		{
			private string oid;

			private string attrValue;

			private int upperBound;

			private byte encoding;

			public string Value
			{
				set
				{
				}
			}

			protected AttributeTypeAndValue(string oid, int upperBound)
			{
			}

			protected AttributeTypeAndValue(string oid, int upperBound, byte encoding)
			{
			}

			internal ASN1 GetASN1(byte encoding)
			{
				return null;
			}

			internal ASN1 GetASN1()
			{
				return null;
			}

			private byte SelectBestEncoding()
			{
				return 0;
			}
		}

		public class CommonName : AttributeTypeAndValue
		{
			public CommonName()
				: base(null, 0)
			{
			}
		}

		public class SerialNumber : AttributeTypeAndValue
		{
			public SerialNumber()
				: base(null, 0)
			{
			}
		}

		public class LocalityName : AttributeTypeAndValue
		{
			public LocalityName()
				: base(null, 0)
			{
			}
		}

		public class StateOrProvinceName : AttributeTypeAndValue
		{
			public StateOrProvinceName()
				: base(null, 0)
			{
			}
		}

		public class OrganizationName : AttributeTypeAndValue
		{
			public OrganizationName()
				: base(null, 0)
			{
			}
		}

		public class OrganizationalUnitName : AttributeTypeAndValue
		{
			public OrganizationalUnitName()
				: base(null, 0)
			{
			}
		}

		public class EmailAddress : AttributeTypeAndValue
		{
			public EmailAddress()
				: base(null, 0)
			{
			}
		}

		public class DomainComponent : AttributeTypeAndValue
		{
			public DomainComponent()
				: base(null, 0)
			{
			}
		}

		public class UserId : AttributeTypeAndValue
		{
			public UserId()
				: base(null, 0)
			{
			}
		}

		public class Oid : AttributeTypeAndValue
		{
			public Oid(string oid)
				: base(null, 0)
			{
			}
		}

		public class Title : AttributeTypeAndValue
		{
			public Title()
				: base(null, 0)
			{
			}
		}

		public class CountryName : AttributeTypeAndValue
		{
			public CountryName()
				: base(null, 0)
			{
			}
		}

		public class DnQualifier : AttributeTypeAndValue
		{
			public DnQualifier()
				: base(null, 0)
			{
			}
		}

		public class Surname : AttributeTypeAndValue
		{
			public Surname()
				: base(null, 0)
			{
			}
		}

		public class GivenName : AttributeTypeAndValue
		{
			public GivenName()
				: base(null, 0)
			{
			}
		}

		public class Initial : AttributeTypeAndValue
		{
			public Initial()
				: base(null, 0)
			{
			}
		}
	}
}
