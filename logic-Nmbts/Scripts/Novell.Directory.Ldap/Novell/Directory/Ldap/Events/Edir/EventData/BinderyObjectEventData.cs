using System.Text;
using Novell.Directory.Ldap.Asn1;

namespace Novell.Directory.Ldap.Events.Edir.EventData
{
	public class BinderyObjectEventData : BaseEdirEventData
	{
		protected string strEntryDN;

		protected int nType;

		protected int nEmuObjFlags;

		protected int nSecurity;

		protected string strName;

		public string EntryDN
		{
			get
			{
				return strEntryDN;
			}
		}

		public int ValueType
		{
			get
			{
				return nType;
			}
		}

		public int EmuObjFlags
		{
			get
			{
				return nEmuObjFlags;
			}
		}

		public int Security
		{
			get
			{
				return nSecurity;
			}
		}

		public string Name
		{
			get
			{
				return strName;
			}
		}

		public BinderyObjectEventData(EdirEventDataType eventDataType, Asn1Object message)
			: base(eventDataType, message)
		{
			int[] len = new int[1];
			strEntryDN = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			nType = ((Asn1Integer)decoder.decode(decodedData, len)).intValue();
			nEmuObjFlags = ((Asn1Integer)decoder.decode(decodedData, len)).intValue();
			nSecurity = ((Asn1Integer)decoder.decode(decodedData, len)).intValue();
			strName = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			DataInitDone();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[BinderyObjectEvent");
			stringBuilder.AppendFormat("(EntryDn={0})", strEntryDN);
			stringBuilder.AppendFormat("(Type={0})", nType);
			stringBuilder.AppendFormat("(EnumOldFlags={0})", nEmuObjFlags);
			stringBuilder.AppendFormat("(Secuirty={0})", nSecurity);
			stringBuilder.AppendFormat("(Name={0})", strName);
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
