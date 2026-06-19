using System;
using FullSerializerSave;
using JetBrains.Annotations;

namespace TH20
{
	[fsObject("2", new Type[] { typeof(MetagameSaveHeaderV1) })]
	public class MetagameSaveHeader_FS
	{
		public DateTime Date;

		public VersionNumber Version;

		public string OrganisationName;

		public int TotalStars;

		public int TotalSilver;

		public int TotalFoundationValue;

		public ByteArray ThumbnailPNG;

		public MetagameSaveHeader_FS()
		{
		}

		[UsedImplicitly]
		public MetagameSaveHeader_FS(MetagameSaveHeaderV1 old)
		{
			Date = old.Date;
			Version = old.Version;
			OrganisationName = old.OrganisationName;
			TotalStars = old.TotalStars;
			TotalSilver = old.TotalSilver;
			TotalFoundationValue = old.TotalFoundationValue;
			ThumbnailPNG = new ByteArray
			{
				Bytes = old.ThumbnailPNG
			};
		}
	}
}
