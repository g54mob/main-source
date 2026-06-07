using System;
using Novell.Directory.Ldap.Asn1;
using Novell.Directory.Ldap.Rfc2251;
using Novell.Directory.Ldap.Utilclass;

namespace Novell.Directory.Ldap
{
	public class LdapIntermediateResponse : LdapResponse
	{
		private static RespExtensionSet registeredResponses = new RespExtensionSet();

		public static void register(string oid, Type extendedResponseClass)
		{
			registeredResponses.registerResponseExtension(oid, extendedResponseClass);
		}

		public static RespExtensionSet getRegisteredResponses()
		{
			return registeredResponses;
		}

		public LdapIntermediateResponse(RfcLdapMessage message)
			: base(message)
		{
		}

		public string getID()
		{
			RfcLdapOID responseName = ((RfcIntermediateResponse)message.Response).getResponseName();
			if (responseName == null)
			{
				return null;
			}
			return responseName.stringValue();
		}

		[CLSCompliant(false)]
		public sbyte[] getValue()
		{
			Asn1OctetString response = ((RfcIntermediateResponse)message.Response).getResponse();
			if (response == null)
			{
				return null;
			}
			return response.byteValue();
		}
	}
}
