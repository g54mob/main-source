using System;
using FullSerializerSave;

namespace TH20
{
	[fsObject("1", new Type[] { })]
	public class MetagameSaveHeaderV1
	{
		public DateTime Date;

		public VersionNumber Version;

		public string OrganisationName;

		public int TotalStars;

		public int TotalSilver;

		public int TotalFoundationValue;

		public byte[] ThumbnailPNG;
	}
}
