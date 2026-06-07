using System.Text;
using Novell.Directory.Ldap.Asn1;

namespace Novell.Directory.Ldap.Events.Edir.EventData
{
	public class ChangeAddressEventData : BaseEdirEventData
	{
		protected int nFlags;

		protected int nProto;

		protected int address_family;

		protected string strAddress;

		protected string pstk_name;

		protected string source_module;

		public int Flags
		{
			get
			{
				return nFlags;
			}
		}

		public int Proto
		{
			get
			{
				return nProto;
			}
		}

		public int AddressFamily
		{
			get
			{
				return address_family;
			}
		}

		public string Address
		{
			get
			{
				return strAddress;
			}
		}

		public string PstkName
		{
			get
			{
				return pstk_name;
			}
		}

		public string SourceModule
		{
			get
			{
				return source_module;
			}
		}

		public ChangeAddressEventData(EdirEventDataType eventDataType, Asn1Object message)
			: base(eventDataType, message)
		{
			int[] len = new int[1];
			nFlags = ((Asn1Integer)decoder.decode(decodedData, len)).intValue();
			nProto = ((Asn1Integer)decoder.decode(decodedData, len)).intValue();
			address_family = ((Asn1Integer)decoder.decode(decodedData, len)).intValue();
			strAddress = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			pstk_name = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			source_module = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			DataInitDone();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[ChangeAddresssEvent");
			stringBuilder.AppendFormat("(flags={0})", nFlags);
			stringBuilder.AppendFormat("(proto={0})", nProto);
			stringBuilder.AppendFormat("(addrFamily={0})", address_family);
			stringBuilder.AppendFormat("(address={0})", strAddress);
			stringBuilder.AppendFormat("(pstkName={0})", pstk_name);
			stringBuilder.AppendFormat("(source={0})", source_module);
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
