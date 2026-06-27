using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	internal class StringEqualityStrategy : IStringComparisonStrategy
	{
		private readonly IEqualityComparer<string> comparer;

		private readonly string predicateDescription;

		public string ExpectationDescription => "Expected {context:string} to " + predicateDescription + " ";

		public StringEqualityStrategy(IEqualityComparer<string> comparer, string predicateDescription)
		{
			this.comparer = comparer;
			this.predicateDescription = predicateDescription;
		}

		public void ValidateAgainstMismatch(AssertionChain assertionChain, string subject, string expected)
		{
			ValidateAgainstSuperfluousWhitespace(assertionChain, subject, expected);
			if (expected.IsLongOrMultiline() || subject.IsLongOrMultiline())
			{
				int num = subject.IndexOfFirstMismatch(expected, comparer);
				if (num == -1)
				{
					ValidateAgainstLengthDifferences(assertionChain, subject, expected);
					return;
				}
				string text = $"at index {num}";
				string text2 = subject.Substring(0, num);
				int num2 = text2.Count((char c) => c == '\n');
				if (num2 > 0)
				{
					int num3 = text2.LastIndexOf('\n');
					int num4 = text2.Length - num3;
					text = $"on line {num2 + 1} and column {num4} (index {num})";
				}
				assertionChain.FailWith(ExpectationDescription + "the same string{reason}, but they differ " + text + ":" + Environment.NewLine + GetMismatchSegmentForLongStrings(subject, expected, num) + ".");
			}
			else if (ValidateAgainstLengthDifferences(assertionChain, subject, expected))
			{
				int num5 = subject.IndexOfFirstMismatch(expected, comparer);
				if (num5 != -1)
				{
					assertionChain.FailWith(ExpectationDescription + "{0}{reason}, but {1} differs near " + subject.IndexedSegmentAt(num5) + ".", expected, subject);
				}
			}
		}

		private void ValidateAgainstSuperfluousWhitespace(AssertionChain assertion, string subject, string expected)
		{
			assertion.ForCondition(expected.Length <= subject.Length || !comparer.Equals(expected.TrimEnd(Array.Empty<char>()), subject)).FailWith(ExpectationDescription + "{0}{reason}, but it misses some extra whitespace at the end.", expected).Then.ForCondition(subject.Length <= expected.Length || !comparer.Equals(subject.TrimEnd(Array.Empty<char>()), expected)).FailWith(ExpectationDescription + "{0}{reason}, but it has unexpected whitespace at the end.", expected);
		}

		private bool ValidateAgainstLengthDifferences(AssertionChain assertion, string subject, string expected)
		{
			assertion.ForCondition(subject.Length == expected.Length).FailWith(delegate
			{
				string mismatchSegmentForStringsOfDifferentLengths = GetMismatchSegmentForStringsOfDifferentLengths(subject, expected);
				return new FailReason(ExpectationDescription + "{0} with a length of {1}{reason}, but {2} has a length of {3}, differs near " + mismatchSegmentForStringsOfDifferentLengths + ".", expected, expected.Length, subject, subject.Length);
			});
			return assertion.Succeeded;
		}

		private string GetMismatchSegmentForStringsOfDifferentLengths(string subject, string expected)
		{
			int num = subject.IndexOfFirstMismatch(expected, comparer);
			if (num == -1)
			{
				num = Math.Max(0, subject.Length - 1);
			}
			return subject.IndexedSegmentAt(num);
		}

		private static string GetMismatchSegmentForLongStrings(string subject, string expected, int firstIndexOfMismatch)
		{
			int startIndexOfPhraseToShowBeforeTheMismatchingIndex = GetStartIndexOfPhraseToShowBeforeTheMismatchingIndex(subject, firstIndexOfMismatch);
			int num = firstIndexOfMismatch - startIndexOfPhraseToShowBeforeTheMismatchingIndex + "  \"".Length;
			if (startIndexOfPhraseToShowBeforeTheMismatchingIndex > 0)
			{
				num++;
			}
			int num2 = startIndexOfPhraseToShowBeforeTheMismatchingIndex;
			string source = subject.Substring(num2, firstIndexOfMismatch - num2);
			num += source.Count((char c) => (c == '\n' || c == '\r') ? true : false);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(' ', num).Append('↓').AppendLine(" (actual)");
			AppendPrefixAndEscapedPhraseToShowWithEllipsisAndSuffix(stringBuilder, "  \"", subject, startIndexOfPhraseToShowBeforeTheMismatchingIndex, "\"");
			AppendPrefixAndEscapedPhraseToShowWithEllipsisAndSuffix(stringBuilder, "  \"", expected, startIndexOfPhraseToShowBeforeTheMismatchingIndex, "\"");
			stringBuilder.Append(' ', num).Append('↑').Append(" (expected)");
			return stringBuilder.ToString();
		}

		private static void AppendPrefixAndEscapedPhraseToShowWithEllipsisAndSuffix(StringBuilder stringBuilder, string prefix, string text, int indexOfStartingPhrase, string suffix)
		{
			int lengthOfPhraseToShowOrDefaultLength = GetLengthOfPhraseToShowOrDefaultLength(text.Substring(indexOfStartingPhrase, text.Length - indexOfStartingPhrase));
			stringBuilder.Append(prefix);
			if (indexOfStartingPhrase > 0)
			{
				stringBuilder.Append('…');
			}
			stringBuilder.Append(SystemExtensions.Replace(SystemExtensions.Replace(text.Substring(indexOfStartingPhrase, lengthOfPhraseToShowOrDefaultLength), "\r", "\\r", StringComparison.OrdinalIgnoreCase), "\n", "\\n", StringComparison.OrdinalIgnoreCase));
			if (text.Length > indexOfStartingPhrase + lengthOfPhraseToShowOrDefaultLength)
			{
				stringBuilder.Append('…');
			}
			stringBuilder.AppendLine(suffix);
		}

		private static int GetStartIndexOfPhraseToShowBeforeTheMismatchingIndex(string value, int indexOfFirstMismatch)
		{
			if (indexOfFirstMismatch <= 10)
			{
				return 0;
			}
			int num = Math.Max(indexOfFirstMismatch - 16, 0);
			int num2 = value.IndexOf(' ', num, 11) - num;
			if (num2 >= 0)
			{
				return num + num2 + 1;
			}
			return indexOfFirstMismatch - 10;
		}

		private static int GetLengthOfPhraseToShowOrDefaultLength(string value)
		{
			int num = value.LastIndexOf(' ', Math.Min(26, value.Length) - 1);
			if (num >= 15)
			{
				return num;
			}
			return Math.Min(20, value.Length);
		}
	}
}
