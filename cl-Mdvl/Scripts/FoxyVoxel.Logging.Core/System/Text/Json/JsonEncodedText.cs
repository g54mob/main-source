using System.Runtime.InteropServices;

namespace System.Text.Json
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct JsonEncodedText
	{
		public static JsonEncodedText Encode(string text)
		{
			return default(JsonEncodedText);
		}
	}
}
