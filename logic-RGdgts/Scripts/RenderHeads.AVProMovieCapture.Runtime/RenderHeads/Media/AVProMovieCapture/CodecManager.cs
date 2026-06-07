namespace RenderHeads.Media.AVProMovieCapture
{
	public static class CodecManager
	{
		private static bool _isEnumerated;

		private static CodecList _videoCodecs;

		private static CodecList _audioCodecs;

		public static CodecList VideoCodecs => null;

		public static CodecList AudioCodecs => null;

		public static Codec FindCodec(CodecType codecType, string name)
		{
			return null;
		}

		public static int GetCodecCount(CodecType codecType)
		{
			return 0;
		}

		private static void CheckInit()
		{
		}

		private static CodecList GetCodecs(CodecType codecType)
		{
			return null;
		}

		private static void EnumerateCodecs()
		{
		}
	}
}
