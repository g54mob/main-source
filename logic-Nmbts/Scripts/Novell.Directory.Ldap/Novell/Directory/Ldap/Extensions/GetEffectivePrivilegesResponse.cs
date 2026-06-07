using System.IO;
using Novell.Directory.Ldap.Asn1;
using Novell.Directory.Ldap.Rfc2251;

namespace Novell.Directory.Ldap.Extensions
{
	public class GetEffectivePrivilegesResponse : LdapExtendedResponse
	{
		private int privileges;

		public virtual int Privileges
		{
			get
			{
				return privileges;
			}
		}

		public GetEffectivePrivilegesResponse(RfcLdapMessage rfcMessage)
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
				Asn1Integer asn1Integer = (Asn1Integer)lBERDecoder.decode(value);
				if (asn1Integer == null)
				{
					throw new IOException("Decoding error");
				}
				privileges = asn1Integer.intValue();
			}
			else
			{
				privileges = 0;
			}
		}
	}
}
