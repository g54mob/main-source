using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace System.Text.Json
{
	public sealed class JsonSerializerOptions
	{
		public bool WriteIndented { get; set; }

		public JsonIgnoreCondition DefaultIgnoreCondition { get; set; }

		public JavaScriptEncoder Encoder { get; set; }
	}
}
