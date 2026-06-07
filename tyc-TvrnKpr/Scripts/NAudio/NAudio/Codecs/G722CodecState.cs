namespace NAudio.Codecs
{
	public class G722CodecState
	{
		public bool ItuTestMode { get; set; }

		public bool Packed { get; private set; }

		public bool EncodeFrom8000Hz { get; private set; }

		public int BitsPerSample { get; private set; }

		public int[] QmfSignalHistory { get; private set; }

		public Band[] Band { get; private set; }

		public uint InBuffer { get; internal set; }

		public int InBits { get; internal set; }

		public uint OutBuffer { get; internal set; }

		public int OutBits { get; internal set; }

		public G722CodecState(int rate, G722Flags options)
		{
		}
	}
}
