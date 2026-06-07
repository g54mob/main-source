using System;
using System.Collections.Generic;

namespace ShellFileDialogs
{
	internal static class Utility
	{
		private static readonly Guid _ishellItem2Guid;

		public static IReadOnlyList<string> GetFileNames(IShellItemArray items)
		{
			return null;
		}

		public static IShellItem2 ParseShellItem2Name(string value)
		{
			return null;
		}

		public static string GetFileNameFromShellItem(IShellItem item)
		{
			return null;
		}

		public static IShellItem GetShellItemAt(IShellItemArray array, int i)
		{
			return null;
		}

		public static void SetFilters(IFileDialog dialog, IReadOnlyCollection<Filter> filters, int selectedFilterZeroBasedIndex)
		{
		}

		public static FilterSpec[] CreateFilterSpec(IReadOnlyCollection<Filter> filters)
		{
			return null;
		}

		public static bool ValidateDialogShowHResult(this HResult dialogHResult)
		{
			return false;
		}
	}
}
