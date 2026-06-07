using System.Text;
using Novell.Directory.Ldap.Asn1;

namespace Novell.Directory.Ldap.Events.Edir.EventData
{
	public class ValueEventData : BaseEdirEventData
	{
		protected string strAttribute;

		protected string strClassId;

		protected string strData;

		protected byte[] binData;

		protected string strEntry;

		protected string strPerpetratorDN;

		protected string strSyntax;

		protected DSETimeStamp timeStampObj;

		protected int nVerb;

		public string Attribute
		{
			get
			{
				return strAttribute;
			}
		}

		public string ClassId
		{
			get
			{
				return strClassId;
			}
		}

		public string Data
		{
			get
			{
				return strData;
			}
		}

		public byte[] BinaryData
		{
			get
			{
				return binData;
			}
		}

		public string Entry
		{
			get
			{
				return strEntry;
			}
		}

		public string PerpetratorDN
		{
			get
			{
				return strPerpetratorDN;
			}
		}

		public string Syntax
		{
			get
			{
				return strSyntax;
			}
		}

		public DSETimeStamp TimeStamp
		{
			get
			{
				return timeStampObj;
			}
		}

		public int Verb
		{
			get
			{
				return nVerb;
			}
		}

		public ValueEventData(EdirEventDataType eventDataType, Asn1Object message)
			: base(eventDataType, message)
		{
			int[] len = new int[1];
			strPerpetratorDN = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			strEntry = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			strAttribute = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			strSyntax = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			strClassId = ((Asn1OctetString)decoder.decode(decodedData, len)).stringValue();
			timeStampObj = new DSETimeStamp((Asn1Sequence)decoder.decode(decodedData, len));
			Asn1OctetString asn1OctetString = (Asn1OctetString)decoder.decode(decodedData, len);
			strData = asn1OctetString.stringValue();
			binData = SupportClass.ToByteArray(asn1OctetString.byteValue());
			nVerb = ((Asn1Integer)decoder.decode(decodedData, len)).intValue();
			DataInitDone();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[ValueEventData");
			stringBuilder.AppendFormat("(Attribute={0})", strAttribute);
			stringBuilder.AppendFormat("(Classid={0})", strClassId);
			stringBuilder.AppendFormat("(Data={0})", strData);
			stringBuilder.AppendFormat("(Data={0})", binData);
			stringBuilder.AppendFormat("(Entry={0})", strEntry);
			stringBuilder.AppendFormat("(Perpetrator={0})", strPerpetratorDN);
			stringBuilder.AppendFormat("(Syntax={0})", strSyntax);
			stringBuilder.AppendFormat("(TimeStamp={0})", timeStampObj);
			stringBuilder.AppendFormat("(Verb={0})", nVerb);
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
