using System.Text.Encodings.Web;

namespace System.Text.Json
{
	public struct JsonWriterOptions
	{
		public bool Indented { get; set; }

		public bool SkipValidation { get; set; }

		public JavaScriptEncoder Encoder { get; set; }
	}
}
