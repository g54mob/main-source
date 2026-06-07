namespace RTLTMPro
{
	public static class RTLSupport
	{
		public const int DefaultBufferSize = 2048;

		private static FastStringBuilder inputBuilder;

		private static FastStringBuilder glyphFixerOutput;

		static RTLSupport()
		{
		}

		public static void FixRTL(string input, FastStringBuilder output, bool farsi = true, bool fixTextTags = true, bool preserveNumbers = false)
		{
		}
	}
}
