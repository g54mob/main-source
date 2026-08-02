using Rhizomatic.Reactive;

namespace GRP.Net
{
	public class NetProjectPlayerViewable : Viewable, IListItemView<NetPlayer>
	{
		public NetProjectViewable project;

		public NetProjectPlayerData data;

		public NetPlayer model { get; set; }

		public NetProjectPlayerViewable(NetProjectViewable project, NetPlayer player)
		{
		}
	}
}
