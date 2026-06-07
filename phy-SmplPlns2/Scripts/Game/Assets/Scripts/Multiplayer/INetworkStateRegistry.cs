namespace Assets.Scripts.Multiplayer
{
	public interface INetworkStateRegistry
	{
		void AddState(INetworkStateReceiver receiver, int addState);

		int Register(INetworkStateReceiver receiver, string uniqueName);

		void SetState(INetworkStateReceiver receiver, int state);

		void Unregister(INetworkStateReceiver receiver);
	}
}
