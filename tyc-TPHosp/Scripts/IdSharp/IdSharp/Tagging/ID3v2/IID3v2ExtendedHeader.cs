using System.IO;

namespace IdSharp.Tagging.ID3v2
{
	public interface IID3v2ExtendedHeader
	{
		int SizeExcludingSizeBytes { get; }

		int SizeIncludingSizeBytes { get; }

		bool IsCRCDataPresent { get; set; }

		int PaddingSize { get; set; }

		int CRC32 { get; }

		bool IsTagAnUpdate { get; set; }

		bool IsTagRestricted { get; set; }

		ITagRestrictions TagRestrictions { get; }

		void ReadFrom(TagReadingInfo tagReadingInfo, Stream stream);

		byte[] GetBytes(ID3v2TagVersion tagVersion);
	}
}
