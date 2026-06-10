using System;

namespace MoreMountains.FeedbacksForThirdParty
{
	[Serializable]
	public class NVHapticFile
	{
		public NVVersion version;

		public NVMetadata metadata;

		public NVSignals signals;
	}
}
