using System.IO;
using Novell.Directory.Ldap.Asn1;
using Novell.Directory.Ldap.Rfc2251;

namespace Novell.Directory.Ldap.Extensions
{
	public class ListReplicasResponse : LdapExtendedResponse
	{
		private string[] replicaList;

		public virtual string[] ReplicaList
		{
			get
			{
				return replicaList;
			}
		}

		public ListReplicasResponse(RfcLdapMessage rfcMessage)
			: base(rfcMessage)
		{
			if (ResultCode != 0)
			{
				replicaList = new string[0];
				return;
			}
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
			Asn1Sequence asn1Sequence = (Asn1Sequence)lBERDecoder.decode(value);
			if (asn1Sequence == null)
			{
				throw new IOException("Decoding error");
			}
			int num = asn1Sequence.size();
			replicaList = new string[num];
			for (int i = 0; i < num; i++)
			{
				Asn1OctetString asn1OctetString = (Asn1OctetString)asn1Sequence.get_Renamed(i);
				if (asn1OctetString == null)
				{
					throw new IOException("Decoding error");
				}
				replicaList[i] = asn1OctetString.stringValue();
				if (replicaList[i] == null)
				{
					throw new IOException("Decoding error");
				}
			}
		}
	}
}
