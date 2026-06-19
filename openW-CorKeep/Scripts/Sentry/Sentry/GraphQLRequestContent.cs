using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Internal.GraphQL;

namespace Sentry
{
	internal class GraphQLRequestContent
	{
		private static readonly Regex Expression = new Regex("\\s*(?<operationType>\\bquery\\b|\\bmutation\\b|\\bsubscription\\b)\\s*(?<operationName>\\w+)?\\s*(?<query>{.*})\\s*", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

		private static JsonSerializerOptions SerializerOptions => new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		private IReadOnlyDictionary<string, object> Items { get; }

		internal string? RequestContent { get; }

		public string? Query { get; }

		public string? OperationName { get; }

		public string? OperationType { get; }

		public GraphQLRequestContent(string? requestContent, SentryOptions? options = null)
		{
			RequestContent = requestContent;
			if (requestContent == null)
			{
				Items = new Dictionary<string, object>().AsReadOnly();
				return;
			}
			try
			{
				Items = GraphQLRequestContentReader.Read(requestContent);
			}
			catch (Exception ex)
			{
				options?.LogDebug("Unable to parse GraphQL request content: " + ex.Message);
				Items = new Dictionary<string, object>().AsReadOnly();
				return;
			}
			if (Items.TryGetValue("operationName", out object value))
			{
				OperationName = value?.ToString();
			}
			if (Items.TryGetValue("query", out object value2))
			{
				Query = value2?.ToString();
			}
			Match match = Expression.Match(Query ?? requestContent);
			if (match.Success)
			{
				if (OperationType == null)
				{
					OperationType = match.Groups["operationType"].Value;
				}
				if (OperationName == null)
				{
					OperationName = match.Groups["operationName"].Value;
				}
			}
			if (string.IsNullOrEmpty(OperationType))
			{
				OperationType = "query";
			}
		}

		public string OperationNameOrFallback()
		{
			return OperationName ?? "graphql";
		}

		public string OperationTypeOrFallback()
		{
			return OperationType ?? "graphql.operation";
		}
	}
}
