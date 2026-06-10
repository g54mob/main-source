namespace ICSharpCode.SharpZipLib.BZip2
{
	internal static class BZip2Constants
	{
		public static readonly int[] RandomNumbers;

		public const int BaseBlockSize = 100000;

		public const int MaximumAlphaSize = 258;

		public const int MaximumCodeLength = 23;

		public const int RunA = 0;

		public const int RunB = 1;

		public const int GroupCount = 6;

		public const int GroupSize = 50;

		public const int NumberOfIterations = 4;

		public const int MaximumSelectors = 18002;

		public const int OvershootBytes = 20;
	}
}
