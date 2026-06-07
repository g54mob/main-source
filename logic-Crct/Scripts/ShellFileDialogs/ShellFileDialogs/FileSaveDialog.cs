using System;
using System.Collections.Generic;

namespace ShellFileDialogs
{
	public static class FileSaveDialog
	{
		public static string ShowDialog(IntPtr parentHWnd, string title, string initialDirectory, string defaultFileName, IReadOnlyCollection<Filter> filters, int selectedFilterZeroBasedIndex = -1)
		{
			return null;
		}

		private static string ShowDialogInner(IFileSaveDialog dialog, IntPtr parentHWnd, string title, string initialDirectory, string defaultFileName, IReadOnlyCollection<Filter> filters, int selectedFilterZeroBasedIndex = -1)
		{
			return null;
		}
	}
}
