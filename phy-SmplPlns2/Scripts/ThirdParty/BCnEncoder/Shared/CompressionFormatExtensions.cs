namespace BCnEncoder.Shared
{
	public static class CompressionFormatExtensions
	{
		public static bool IsCompressedFormat(this CompressionFormat format)
		{
			if ((uint)format <= 4u)
			{
				return false;
			}
			return true;
		}

		public static bool IsHdrFormat(this CompressionFormat format)
		{
			if ((uint)(format - 11) <= 1u)
			{
				return true;
			}
			return false;
		}
	}
}
