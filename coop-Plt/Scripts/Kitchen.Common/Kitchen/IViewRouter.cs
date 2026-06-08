namespace Kitchen
{
	public interface IViewRouter
	{
		void Update();

		void BroadcastUpdate<T>(ViewIdentifier id, T data, MessageType type = MessageType.ViewUpdate) where T : IViewData;

		void BroadcastCommand<T>(T update) where T : ICommandUpdate;

		void Dispose();
	}
}
