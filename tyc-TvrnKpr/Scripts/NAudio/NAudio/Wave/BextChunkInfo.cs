using System;

namespace NAudio.Wave
{
	public class BextChunkInfo
	{
		public string Description { get; set; }

		public string Originator { get; set; }

		public string OriginatorReference { get; set; }

		public DateTime OriginationDateTime { get; set; }

		public string OriginationDate => null;

		public string OriginationTime => null;

		public long TimeReference { get; set; }

		public ushort Version => 0;

		public string UniqueMaterialIdentifier { get; set; }

		public byte[] Reserved { get; }

		public string CodingHistory { get; set; }
	}
}
