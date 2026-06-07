using System;
using System.Collections.Generic;

namespace PlaylistsNET.Models
{
	public class HlsMasterPlaylistEntry : HlsPlaylistEntry
	{
		[Obsolete("The PROGRAM-ID attribute of the EXT-X-STREAM-INF tag was removed in protocol version 6.")]
		public int? ProgramId { get; set; }

		public int Bandwidth { get; set; }

		public int? AverageBandwidth { get; set; }

		public List<string> Codecs { get; set; }

		public string Resolution { get; set; }

		public double? FrameRate { get; set; }

		public string HdcpLevel { get; set; }

		public string Audio { get; set; }

		public string Video { get; set; }

		public string Subtitles { get; set; }

		public string ClosedCaptions { get; set; }

		public HlsMasterPlaylistEntry()
		{
			Codecs = new List<string>();
		}
	}
}
