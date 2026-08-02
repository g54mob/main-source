using Rhizomatic.ImUI;
using Rhizomatic.UI;

namespace GRP
{
	public class ChannelImUIView : ImUIView<ChannelImUIState>
	{
		public DropdownAdapter channels;

		public int channelId;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(ChannelImUIState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
