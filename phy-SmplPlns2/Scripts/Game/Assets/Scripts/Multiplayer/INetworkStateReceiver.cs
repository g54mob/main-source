namespace Assets.Scripts.Multiplayer
{
	public interface INetworkStateReceiver
	{
		int ReceiverId { get; }

		void SetState(int state, bool initialValue);
	}
}
