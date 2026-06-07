using System.IO;
using Novell.Directory.Ldap.Asn1;
using Novell.Directory.Ldap.Rfc2251;

namespace Novell.Directory.Ldap.Extensions
{
	public class GetBindDNResponse : LdapExtendedResponse
	{
		private string identity;

		public virtual string Identity
		{
			get
			{
				return identity;
			}
		}

		public GetBindDNResponse(RfcLdapMessage rfcMessage)
			: base(rfcMessage)
		{
			if (ResultCode == 0)
			{
				sbyte[] value = Value;
				if (value == null)
				{
					throw new IOException("No returned value");
				}
				LBERDecoder lBERDecoder = new LBERDecoder();
				if (lBERDecoder == null)
				{
					throw new IOException("Decoding error");
				}
				Asn1OctetString asn1OctetString = (Asn1OctetString)lBERDecoder.decode(value);
				if (asn1OctetString == null)
				{
					throw new IOException("Decoding error");
				}
				identity = asn1OctetString.stringValue();
				if (identity == null)
				{
					throw new IOException("Decoding error");
				}
			}
			else
			{
				identity = "";
			}
		}
	}
}
