using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal.Extensions
{
	internal static class HttpClientExtensions
	{
		public static async Task<JsonElement> ReadAsJsonAsync(this HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
		{
			Stream stream = await content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			using (stream)
			{
				using JsonDocument jsonDocument = await JsonDocument.ParseAsync(stream, default(JsonDocumentOptions), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return jsonDocument.RootElement.Clone();
			}
		}

		public static JsonElement ReadAsJson(this HttpContent content)
		{
			using Stream utf8Json = content.ReadAsStream();
			using JsonDocument jsonDocument = JsonDocument.Parse(utf8Json);
			return jsonDocument.RootElement.Clone();
		}

		public static string ReadAsString(this HttpContent content)
		{
			using Stream stream = content.ReadAsStream();
			using StreamReader streamReader = new StreamReader(stream);
			return streamReader.ReadToEnd();
		}
	}
}
