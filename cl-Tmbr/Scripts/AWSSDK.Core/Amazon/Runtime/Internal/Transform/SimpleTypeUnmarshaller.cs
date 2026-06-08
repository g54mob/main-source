using System;
using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	internal static class SimpleTypeUnmarshaller<T>
	{
		public static T Unmarshall(XmlUnmarshallerContext context)
		{
			return (T)Convert.ChangeType(context.ReadText(), typeof(T), CultureInfo.InvariantCulture);
		}

		public static T Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string text = context.ReadText(ref reader);
			if (text == null)
			{
				return default(T);
			}
			return (T)Convert.ChangeType(text, typeof(T), CultureInfo.InvariantCulture);
		}
	}
}
