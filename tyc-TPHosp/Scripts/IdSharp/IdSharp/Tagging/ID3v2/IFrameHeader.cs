namespace IdSharp.Tagging.ID3v2
{
	public interface IFrameHeader
	{
		int FrameSize { get; }

		int FrameSizeTotal { get; }

		int FrameSizeExcludingAdditions { get; }

		bool IsTagAlterPreservation { get; set; }

		bool IsFileAlterPreservation { get; set; }

		bool IsReadOnly { get; set; }

		bool IsCompressed { get; set; }

		byte? EncryptionMethod { get; set; }

		byte? GroupingIdentity { get; set; }

		int DecompressedSize { get; set; }

		bool UsesUnsynchronization { get; set; }
	}
}
