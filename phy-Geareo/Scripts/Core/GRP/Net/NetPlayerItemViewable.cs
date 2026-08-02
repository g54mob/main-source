using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Net
{
	public class NetPlayerItemViewable : Viewable, IListItemView<NetPlayer>
	{
		[TextCrew]
		public string username;

		public NetPlayer model { get; private set; }

		public NetPlayerItemViewable(NetPlayer player)
		{
		}
	}
}
