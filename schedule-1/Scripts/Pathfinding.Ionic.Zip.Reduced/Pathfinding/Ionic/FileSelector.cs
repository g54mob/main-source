using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Pathfinding.Ionic.Zip;

namespace Pathfinding.Ionic
{
	public class FileSelector
	{
		private enum ParseState
		{
			Start = 0,
			OpenParen = 1,
			CriterionDone = 2,
			ConjunctionPending = 3,
			Whitespace = 4
		}

		private static class RegexAssertions
		{
			public static readonly string PrecededByOddNumberOfSingleQuotes;

			public static readonly string FollowedByOddNumberOfSingleQuotesAndLineEnd;

			public static readonly string PrecededByEvenNumberOfSingleQuotes;

			public static readonly string FollowedByEvenNumberOfSingleQuotesAndLineEnd;
		}

		internal SelectionCriterion _Criterion;

		public string SelectionCriteria
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool TraverseReparsePoints { get; set; }

		public FileSelector(string selectionCriteria)
		{
		}

		public FileSelector(string selectionCriteria, bool traverseDirectoryReparsePoints)
		{
		}

		private static string NormalizeCriteriaExpression(string source)
		{
			return null;
		}

		private static SelectionCriterion _ParseCriterion(string s)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		private bool Evaluate(string filename)
		{
			return false;
		}

		[Conditional("SelectorTrace")]
		private void SelectorTrace(string format, params object[] args)
		{
		}

		public ICollection<string> SelectFiles(string directory)
		{
			return null;
		}

		public ReadOnlyCollection<string> SelectFiles(string directory, bool recurseDirectories)
		{
			return null;
		}

		private bool Evaluate(ZipEntry entry)
		{
			return false;
		}

		public ICollection<ZipEntry> SelectEntries(ZipFile zip)
		{
			return null;
		}

		public ICollection<ZipEntry> SelectEntries(ZipFile zip, string directoryPathInArchive)
		{
			return null;
		}
	}
}
