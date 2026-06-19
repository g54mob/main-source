using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Sentry.Extensibility;

namespace Sentry
{
	internal static class GraphQLContentExtractor
	{
		internal static async Task<GraphQLRequestContent?> ExtractRequestContentAsync(HttpRequestMessage request, SentryOptions? options)
		{
			string text = await ExtractContentAsync(request?.Content, options).ConfigureAwait(continueOnCapturedContext: false);
			return (text != null) ? new GraphQLRequestContent(text, options) : null;
		}

		internal static async Task<JsonElement?> ExtractResponseContentAsync(HttpResponseMessage response, SentryOptions? options)
		{
			string text = await ExtractContentAsync(response?.Content, options).ConfigureAwait(continueOnCapturedContext: false);
			return (text != null) ? new JsonElement?(JsonDocument.Parse(text).RootElement.Clone()) : ((JsonElement?)null);
		}

		private static void TrySeek(Stream? stream, long position)
		{
			if (stream != null && stream.CanSeek)
			{
				stream.Position = position;
			}
		}

		private static async Task<string?> ExtractContentAsync(HttpContent? content, SentryOptions? options)
		{
			if (content == null)
			{
				return null;
			}
			Stream contentStream;
			try
			{
				await content.LoadIntoBufferAsync().ConfigureAwait(continueOnCapturedContext: false);
				contentStream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				options?.LogDebug("Unable to read GraphQL content stream: " + ex.Message);
				return null;
			}
			if (!contentStream.CanRead)
			{
				return null;
			}
			long originalPosition = (contentStream.CanSeek ? contentStream.Position : 0);
			try
			{
				TrySeek(contentStream, 0L);
				using StreamReader reader = new StreamReader(contentStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, -1, leaveOpen: true);
				return await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex2)
			{
				options?.LogDebug("Unable to extract GraphQL content: " + ex2.Message);
				return null;
			}
			finally
			{
				TrySeek(contentStream, originalPosition);
			}
		}
	}
}
