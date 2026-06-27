using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions.Common;
using FluentAssertions.Formatting;

namespace FluentAssertions.Execution
{
	internal class FailureMessageFormatter
	{
		private static readonly char[] Blanks = new char[4] { '\r', '\n', ' ', '\t' };

		private string reason;

		private ContextDataDictionary contextData;

		private string identifier;

		private string fallbackIdentifier;

		public FailureMessageFormatter(FormattingOptions formattingOptions)
		{
			_003CformattingOptions_003EP = formattingOptions;
			base._002Ector();
		}

		public FailureMessageFormatter WithReason(string reason)
		{
			this.reason = SanitizeReason(reason ?? string.Empty);
			return this;
		}

		private static string SanitizeReason(string reason)
		{
			if (!string.IsNullOrEmpty(reason))
			{
				reason = EnsurePrefix("because", reason);
				reason = reason.EscapePlaceholders();
				if (!StartsWithBlank(reason))
				{
					return " " + reason;
				}
				return reason;
			}
			return string.Empty;
		}

		private static string EnsurePrefix(string prefix, string text)
		{
			string text2 = ExtractLeadingBlanksFrom(text);
			string text3 = text.Substring(text2.Length);
			if (text3.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
			{
				return text;
			}
			return text2 + prefix + " " + text3;
		}

		private static string ExtractLeadingBlanksFrom(string text)
		{
			string text2 = text.TrimStart(Blanks);
			int length = text.Length - text2.Length;
			return text.Substring(0, length);
		}

		private static bool StartsWithBlank(string text)
		{
			if (text.Length > 0)
			{
				return Blanks.Contains(text[0]);
			}
			return false;
		}

		public FailureMessageFormatter WithContext(ContextDataDictionary contextData)
		{
			this.contextData = contextData;
			return this;
		}

		public FailureMessageFormatter WithIdentifier(string identifier)
		{
			this.identifier = identifier;
			return this;
		}

		public FailureMessageFormatter WithFallbackIdentifier(string fallbackIdentifier)
		{
			this.fallbackIdentifier = fallbackIdentifier;
			return this;
		}

		public string Format(string message, object[] messageArgs)
		{
			message = SystemExtensions.Replace(message, "{reason}", reason, StringComparison.Ordinal);
			message = SubstituteIdentifier(message, identifier?.EscapePlaceholders(), fallbackIdentifier);
			message = SubstituteContextualTags(message, contextData);
			message = FormatArgumentPlaceholders(message, messageArgs);
			return message;
		}

		private static string SubstituteIdentifier(string message, string identifier, string fallbackIdentifier)
		{
			message = Regex.Replace(message, "(?:\\s|^)\\{context(?:\\:(?<default>[a-zA-Z\\s]+))?\\}", delegate(Match match)
			{
				if (!string.IsNullOrEmpty(identifier))
				{
					return " " + identifier;
				}
				string value = match.Groups["default"].Value;
				if (!string.IsNullOrEmpty(value))
				{
					return " " + value;
				}
				return (!string.IsNullOrEmpty(fallbackIdentifier)) ? (" " + fallbackIdentifier) : " object";
			});
			return message.TrimStart(Array.Empty<char>());
		}

		private static string SubstituteContextualTags(string message, ContextDataDictionary contextData)
		{
			return Regex.Replace(message, "(?<!\\{)\\{(?<key>[a-zA-Z]+)(?:\\:(?<default>[a-zA-Z\\s]+))?\\}(?!\\})", delegate(Match match)
			{
				string value = match.Groups["key"].Value;
				return contextData.AsStringOrDefault(value)?.EscapePlaceholders() ?? match.Groups["default"].Value;
			});
		}

		private string FormatArgumentPlaceholders(string failureMessage, object[] failureArgs)
		{
			object[] args = ((IEnumerable<object>)failureArgs).Select((Func<object, object>)((object a) => Formatter.ToString(a, _003CformattingOptions_003EP))).ToArray();
			try
			{
				return string.Format(CultureInfo.InvariantCulture, failureMessage, args);
			}
			catch (FormatException ex)
			{
				return "**WARNING** failure message '" + failureMessage + "' could not be formatted with string.Format" + Environment.NewLine + ex.StackTrace;
			}
		}
	}
}
