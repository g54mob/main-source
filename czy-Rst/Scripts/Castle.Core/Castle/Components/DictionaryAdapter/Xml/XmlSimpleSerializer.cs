using System;
using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlSimpleSerializer<T> : XmlTypeSerializer
	{
		private readonly Func<T, string> getString;

		private readonly Func<string, T> getObject;

		public override XmlTypeKind Kind => XmlTypeKind.Simple;

		public XmlSimpleSerializer(Func<T, string> getString, Func<string, T> getObject)
		{
			this.getString = getString;
			this.getObject = getObject;
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			return getObject(node.Value);
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			node.Value = getString((T)value);
		}
	}
	public static class XmlSimpleSerializer
	{
		public static readonly XmlTypeSerializer ForBoolean = new XmlSimpleSerializer<bool>(XmlConvert.ToString, XmlConvert.ToBoolean);

		public static readonly XmlTypeSerializer ForChar = new XmlSimpleSerializer<char>(XmlConvert.ToString, XmlConvert.ToChar);

		public static readonly XmlTypeSerializer ForSByte = new XmlSimpleSerializer<sbyte>(XmlConvert.ToString, XmlConvert.ToSByte);

		public static readonly XmlTypeSerializer ForInt16 = new XmlSimpleSerializer<short>(XmlConvert.ToString, XmlConvert.ToInt16);

		public static readonly XmlTypeSerializer ForInt32 = new XmlSimpleSerializer<int>(XmlConvert.ToString, XmlConvert.ToInt32);

		public static readonly XmlTypeSerializer ForInt64 = new XmlSimpleSerializer<long>(XmlConvert.ToString, XmlConvert.ToInt64);

		public static readonly XmlTypeSerializer ForByte = new XmlSimpleSerializer<byte>(XmlConvert.ToString, XmlConvert.ToByte);

		public static readonly XmlTypeSerializer ForUInt16 = new XmlSimpleSerializer<ushort>(XmlConvert.ToString, XmlConvert.ToUInt16);

		public static readonly XmlTypeSerializer ForUInt32 = new XmlSimpleSerializer<uint>(XmlConvert.ToString, XmlConvert.ToUInt32);

		public static readonly XmlTypeSerializer ForUInt64 = new XmlSimpleSerializer<ulong>(XmlConvert.ToString, XmlConvert.ToUInt64);

		public static readonly XmlTypeSerializer ForSingle = new XmlSimpleSerializer<float>(XmlConvert.ToString, XmlConvert.ToSingle);

		public static readonly XmlTypeSerializer ForDouble = new XmlSimpleSerializer<double>(XmlConvert.ToString, XmlConvert.ToDouble);

		public static readonly XmlTypeSerializer ForDecimal = new XmlSimpleSerializer<decimal>(XmlConvert.ToString, XmlConvert.ToDecimal);

		public static readonly XmlTypeSerializer ForTimeSpan = new XmlSimpleSerializer<TimeSpan>(XmlConvert.ToString, XmlConvert.ToTimeSpan);

		public static readonly XmlTypeSerializer ForDateTime = new XmlSimpleSerializer<DateTime>(XmlConvert_ToString, XmlConvert_ToDateTime);

		public static readonly XmlTypeSerializer ForDateTimeOffset = new XmlSimpleSerializer<DateTimeOffset>(XmlConvert.ToString, XmlConvert.ToDateTimeOffset);

		public static readonly XmlTypeSerializer ForGuid = new XmlSimpleSerializer<Guid>(XmlConvert.ToString, XmlConvert.ToGuid);

		public static readonly XmlTypeSerializer ForByteArray = new XmlSimpleSerializer<byte[]>(Convert.ToBase64String, Convert.FromBase64String);

		public static readonly XmlTypeSerializer ForUri = new XmlSimpleSerializer<Uri>((Uri u) => u.ToString(), (string s) => new Uri(s, UriKind.RelativeOrAbsolute));

		private static string XmlConvert_ToString(DateTime value)
		{
			return XmlConvert.ToString(value, XmlDateTimeSerializationMode.RoundtripKind);
		}

		private static DateTime XmlConvert_ToDateTime(string value)
		{
			return XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.RoundtripKind);
		}
	}
}
