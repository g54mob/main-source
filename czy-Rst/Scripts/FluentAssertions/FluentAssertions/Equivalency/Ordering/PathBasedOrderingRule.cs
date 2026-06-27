using System;
using System.Text.RegularExpressions;

namespace FluentAssertions.Equivalency.Ordering
{
	internal class PathBasedOrderingRule : IOrderingRule
	{
		private readonly string path;

		public bool Invert { get; init; }

		public PathBasedOrderingRule(string path)
		{
			this.path = path;
		}

		public OrderStrictness Evaluate(IObjectInfo objectInfo)
		{
			string text = objectInfo.Path;
			if (!ContainsIndexingQualifiers(path))
			{
				text = RemoveInitialIndexQualifier(text);
			}
			if (text.Equals(path, StringComparison.OrdinalIgnoreCase))
			{
				if (!Invert)
				{
					return OrderStrictness.Strict;
				}
				return OrderStrictness.NotStrict;
			}
			return OrderStrictness.Irrelevant;
		}

		private static bool ContainsIndexingQualifiers(string path)
		{
			if (SystemExtensions.Contains(path, '[', StringComparison.Ordinal))
			{
				return SystemExtensions.Contains(path, ']', StringComparison.Ordinal);
			}
			return false;
		}

		private string RemoveInitialIndexQualifier(string sourcePath)
		{
			Regex regex = new Regex("^\\[[0-9]+]\\.");
			if (!regex.IsMatch(path))
			{
				Match match = regex.Match(sourcePath);
				if (match.Success)
				{
					sourcePath = sourcePath.Substring(match.Length);
				}
			}
			return sourcePath;
		}

		public override string ToString()
		{
			return "Be " + (Invert ? "not strict" : "strict") + " about the order of collection items when path is " + path;
		}
	}
}
