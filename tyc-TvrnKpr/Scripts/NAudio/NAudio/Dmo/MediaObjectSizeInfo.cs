namespace NAudio.Dmo
{
	public class MediaObjectSizeInfo
	{
		public int Size { get; private set; }

		public int MaxLookahead { get; }

		public int Alignment { get; }

		public MediaObjectSizeInfo(int size, int maxLookahead, int alignment)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
