using System;
using System.Collections.Generic;

namespace ShellFileDialogs
{
	public static class FileOpenDialog
	{
		public static IReadOnlyList<string> ShowMultiSelectDialog(IntPtr parentHWnd, string title, string initialDirectory, string defaultFileName, IReadOnlyCollection<Filter> filters, int? selectedFilterZeroBasedIndex)
		{
			return null;
		}

		public static string ShowSingleSelectDialog(IntPtr parentHWnd, string title, string initialDirectory, string defaultFileName, IReadOnlyCollection<Filter> filters, int? selectedFilterZeroBasedIndex)
		{
			return null;
		}

		private static IReadOnlyList<string> ShowDialog(IntPtr parentHWnd, string title, string initialDirectory, string defaultFileName, IReadOnlyCollection<Filter> filters, int? selectedFilterZeroBasedIndex, FileOpenOptions flags)
		{
			return null;
		}

		private static IReadOnlyList<string> ShowDialogInner(IFileOpenDialog dialog, IntPtr parentHWnd, string title, string initialDirectory, string defaultFileName, IReadOnlyCollection<Filter> filters, int selectedFilterZeroBasedIndex, FileOpenOptions flags)
		{
			return null;
		}
	}
}
