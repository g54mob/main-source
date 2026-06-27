using System;
using System.Text;
using System.Text.RegularExpressions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	internal class StringWildcardMatchingStrategy : IStringComparisonStrategy
	{
		public string ExpectationDescription
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(Negate ? "Did not expect " : "Expected ").Append("{context:string}").Append(IgnoreCase ? " to match the equivalent of" : " to match")
					.Append(" {0}{reason}, ");
				return stringBuilder.ToString();
			}
		}

		public bool Negate { get; init; }

		public bool IgnoreCase { get; init; }

		public bool IgnoreAllNewlines { get; init; }

		public bool IgnoreNewlineStyle { get; init; }

		public void ValidateAgainstMismatch(AssertionChain assertionChain, string subject, string expected)
		{
			if (IsMatch(subject, expected) == Negate)
			{
				if (Negate)
				{
					assertionChain.FailWith(ExpectationDescription + "but {1} matches.", expected, subject);
				}
				else
				{
					assertionChain.FailWith(ExpectationDescription + "but {1} does not.", expected, subject);
				}
			}
		}

		private bool IsMatch(string subject, string expected)
		{
			RegexOptions regexOptions = (IgnoreCase ? (RegexOptions.IgnoreCase | RegexOptions.CultureInvariant) : RegexOptions.None);
			string input = CleanNewLines(subject);
			string pattern = ConvertWildcardToRegEx(CleanNewLines(expected));
			return Regex.IsMatch(input, pattern, regexOptions | RegexOptions.Singleline);
		}

		private static string ConvertWildcardToRegEx(string wildcardExpression)
		{
			return "^" + SystemExtensions.Replace(SystemExtensions.Replace(Regex.Escape(wildcardExpression), "\\*", ".*", StringComparison.Ordinal), "\\?", ".", StringComparison.Ordinal) + "$";
		}

		private string CleanNewLines(string input)
		{
			if (IgnoreAllNewlines)
			{
				return input.RemoveNewLines();
			}
			if (IgnoreNewlineStyle)
			{
				return input.RemoveNewlineStyle();
			}
			return input;
		}
	}
}
