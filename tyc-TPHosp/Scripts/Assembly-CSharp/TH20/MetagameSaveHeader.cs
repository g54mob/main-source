using System;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class MetagameSaveHeader
	{
		[Key(0)]
		public DateTime Date = TimeUtils.MinDateTimeUTC;

		[Key(1)]
		public VersionNumber Version = new VersionNumber();

		[Key(2)]
		public string OrganisationName;

		[Key(3)]
		public int TotalStars;

		[Key(4)]
		public int TotalSilver;

		[Key(5)]
		public int TotalFoundationValue;

		[Key(6)]
		public byte[] ThumbnailPNG;

		[Key(7)]
		public bool IsSandboxUnlocked;

		public MetagameSaveHeader()
		{
		}

		public MetagameSaveHeader(MetagameSaveHeader_FS old)
		{
			Date = old.Date;
			Version = old.Version;
			OrganisationName = old.OrganisationName;
			TotalStars = old.TotalStars;
			TotalSilver = old.TotalSilver;
			TotalFoundationValue = old.TotalFoundationValue;
			ThumbnailPNG = old.ThumbnailPNG.Bytes;
		}
	}
}
