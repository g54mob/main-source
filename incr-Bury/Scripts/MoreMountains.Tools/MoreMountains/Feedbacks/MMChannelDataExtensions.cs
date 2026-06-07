namespace MoreMountains.Feedbacks
{
	public static class MMChannelDataExtensions
	{
		public static MMChannelData Set(this MMChannelData data, MMChannelModes mode, int channel, MMChannel channelDefinition)
		{
			data.MMChannelMode = mode;
			data.Channel = channel;
			data.MMChannelDefinition = channelDefinition;
			return data;
		}
	}
}
