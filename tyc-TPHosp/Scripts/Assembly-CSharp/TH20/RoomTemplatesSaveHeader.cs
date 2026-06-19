using System;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class RoomTemplatesSaveHeader
	{
		[Key(0)]
		public DateTime Date = TimeUtils.MinDateTimeUTC;

		[Key(1)]
		public VersionNumber Version = new VersionNumber();
	}
}
