using System;

namespace NAudio.Wave
{
	public class XingHeader
	{
		[Flags]
		private enum XingHeaderOptions
		{
			Frames = 1,
			Bytes = 2,
			Toc = 4,
			VbrScale = 8
		}

		private static int[] sr_table;

		private int vbrScale;

		private int startOffset;

		private int endOffset;

		private int tocOffset;

		private int framesOffset;

		private int bytesOffset;

		private Mp3Frame frame;

		public int Frames
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Bytes
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int VbrScale => 0;

		public Mp3Frame Mp3Frame => null;

		private static int ReadBigEndian(byte[] buffer, int offset)
		{
			return 0;
		}

		private void WriteBigEndian(byte[] buffer, int offset, int value)
		{
		}

		public static XingHeader LoadXingHeader(Mp3Frame frame)
		{
			return null;
		}

		private XingHeader()
		{
		}
	}
}
