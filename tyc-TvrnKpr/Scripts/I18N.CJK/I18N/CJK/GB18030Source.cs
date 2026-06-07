namespace I18N.CJK
{
	internal class GB18030Source
	{
		private class GB18030Map
		{
			public readonly int UStart;

			public readonly int UEnd;

			public readonly long GStart;

			public readonly long GEnd;

			public readonly bool Dummy;

			public GB18030Map(int ustart, int uend, long gstart, long gend, bool dummy)
			{
			}
		}

		private unsafe static readonly byte* gbx2uni;

		private unsafe static readonly byte* uni2gbx;

		private static readonly int gbx2uniSize;

		private static readonly int uni2gbxSize;

		private static readonly long gbxBase;

		private static readonly long gbxSuppBase;

		private static readonly GB18030Map[] ranges;

		private GB18030Source()
		{
		}

		static GB18030Source()
		{
		}

		public static void Unlinear(byte[] bytes, int start, long gbx)
		{
		}

		public unsafe static void Unlinear(byte* bytes, long gbx)
		{
		}

		public static long FromGBX(byte[] bytes, int start)
		{
			return 0L;
		}

		public static long FromUCSSurrogate(int cp)
		{
			return 0L;
		}

		public static long FromUCS(int cp)
		{
			return 0L;
		}

		private static long FromGBXRaw(byte b1, byte b2, byte b3, byte b4, bool supp)
		{
			return 0L;
		}

		private static int ToUcsRaw(int idx)
		{
			return 0;
		}

		private static long ToGbxRaw(int idx)
		{
			return 0L;
		}
	}
}
