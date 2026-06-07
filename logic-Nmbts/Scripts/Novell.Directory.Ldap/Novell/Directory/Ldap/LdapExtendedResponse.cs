using System;
using Novell.Directory.Ldap.Asn1;
using Novell.Directory.Ldap.Rfc2251;
using Novell.Directory.Ldap.Utilclass;

namespace Novell.Directory.Ldap
{
	public class LdapExtendedResponse : LdapResponse
	{
		private static RespExtensionSet registeredResponses;

		public virtual string ID
		{
			get
			{
				RfcLdapOID responseName = ((RfcExtendedResponse)message.Response).ResponseName;
				if (responseName == null)
				{
					return null;
				}
				return responseName.stringValue();
			}
		}

		public static RespExtensionSet RegisteredResponses
		{
			get
			{
				return registeredResponses;
			}
		}

		[CLSCompliant(false)]
		public virtual sbyte[] Value
		{
			get
			{
				Asn1OctetString response = ((RfcExtendedResponse)message.Response).Response;
				if (response == null)
				{
					return null;
				}
				return response.byteValue();
			}
		}

		static LdapExtendedResponse()
		{
			registeredResponses = new RespExtensionSet();
		}

		public LdapExtendedResponse(RfcLdapMessage message)
			: base(message)
		{
		}

		public static void register(string oid, Type extendedResponseClass)
		{
			registeredResponses.registerResponseExtension(oid, extendedResponseClass);
		}
	}
}
