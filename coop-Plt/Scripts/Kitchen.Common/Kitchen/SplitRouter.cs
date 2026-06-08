using System.Collections.Generic;

namespace Kitchen
{
	public class SplitRouter : IViewRouter
	{
		private List<IViewRouter> Destinations;

		public SplitRouter()
		{
			Destinations = new List<IViewRouter>();
		}

		public void Dispose()
		{
		}

		public void Update()
		{
		}

		public void AddDestination(IViewRouter destination)
		{
			Destinations.Add(destination);
		}

		public void BroadcastUpdate<T>(ViewIdentifier e, T data, MessageType type = MessageType.ViewUpdate) where T : IViewData
		{
			foreach (IViewRouter destination in Destinations)
			{
				destination.BroadcastUpdate(e, data, type);
			}
		}

		public void BroadcastCommand<T>(T update) where T : ICommandUpdate
		{
			foreach (IViewRouter destination in Destinations)
			{
				destination.BroadcastCommand(update);
			}
		}
	}
}
