using System.Collections.Generic;
using System.Text;

namespace Coherence.Plugins.NativeLauncher
{
	internal class LineSplitter
	{
		private StringBuilder stringBuilder;

		private List<string> linesCache;

		private int currentLinePos;

		private bool lastCarriageReturn;

		public LineSplitter(int size)
		{
		}

		public IReadOnlyList<string> Append(char[] data, int length)
		{
			return null;
		}

		public string Flush()
		{
			return null;
		}
	}
}
