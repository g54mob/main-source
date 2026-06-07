using System;

namespace UMA
{
	[Serializable]
	public struct SharedColorDef
	{
		public string name;

		public int count;

		public ColorDef[] channels;

		public string[] shaderParms;

		public SharedColorDef(string Name, int ChannelCount)
		{
			name = null;
			count = 0;
			channels = null;
			shaderParms = null;
		}

		public void SetChannels(ColorDef[] Channels)
		{
		}
	}
}
