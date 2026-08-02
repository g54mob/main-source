using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class Channel : Thing<ChannelConfig>
	{
		public ChannelId id;

		public State<string> name;

		public State<string> color;

		public State<bool> keyboard;

		public ChannelData Serialize()
		{
			return null;
		}

		public void Deserialize(ChannelData data)
		{
		}
	}
}
