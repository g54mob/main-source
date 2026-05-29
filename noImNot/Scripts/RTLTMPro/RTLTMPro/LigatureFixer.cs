using System.Collections.Generic;

namespace RTLTMPro
{
	public static class LigatureFixer
	{
		private static readonly List<int> LtrTextHolder;

		private static readonly List<int> TagTextHolder;

		private static readonly Dictionary<char, char> MirroredCharsMap;

		private static readonly HashSet<char> MirroredCharsSet;

		private static void FlushBufferToOutput(List<int> buffer, FastStringBuilder output)
		{
		}

		public static void Fix(FastStringBuilder input, FastStringBuilder output, bool farsi, bool fixTextTags, bool preserveNumbers)
		{
		}
	}
}
