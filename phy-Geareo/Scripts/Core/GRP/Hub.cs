using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.ImUI;
using Rhizomatic.Reactive;

namespace GRP
{
	public class Hub : Thing<HubConfig>, IExpositorUI, IExpositorEdit
	{
		public int defaultChannel;

		public StateList<Channel> channels;

		public Dictionary<int, Channel> channelsById;

		public int lastId;

		public UndoSnapshot expositorSnapshot;

		private Project project;

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		public Channel CreateChannel()
		{
			return null;
		}

		public void RemoveChannel(Channel channel)
		{
		}

		public Channel GetChannel(int id)
		{
			return null;
		}

		public void Deserialize(HubData data)
		{
		}

		public HubData Serialize()
		{
			return null;
		}

		public void OnExpositorUI(ImUIBuilder ui)
		{
		}

		public void OnExpositorEditStart()
		{
		}

		public UndoStep OnExpositorEditEnd()
		{
			return null;
		}
	}
}
