using System;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class MMChannelData
	{
		public MMChannelModes MMChannelMode;

		public int Channel;

		public MMChannel MMChannelDefinition;

		public MMChannelData(MMChannelModes mode, int channel, MMChannel channelDefinition)
		{
			MMChannelMode = mode;
			Channel = channel;
			MMChannelDefinition = channelDefinition;
		}
	}
}
