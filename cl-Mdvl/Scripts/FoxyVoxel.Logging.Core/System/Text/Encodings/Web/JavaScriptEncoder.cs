using System.Text.Unicode;

namespace System.Text.Encodings.Web
{
	public class JavaScriptEncoder
	{
		public static JavaScriptEncoder Create(UnicodeRange range)
		{
			return new JavaScriptEncoder();
		}
	}
}
