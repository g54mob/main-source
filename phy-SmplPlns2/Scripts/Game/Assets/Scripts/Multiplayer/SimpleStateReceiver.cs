using System;
using Assets.Scripts.Flight;

namespace Assets.Scripts.Multiplayer
{
	public class SimpleStateReceiver : INetworkStateReceiver
	{
		private INetworkStateRegistry _stateRegistry;

		public int ReceiverId { get; private set; }

		public int State { get; private set; }

		private event Action<SimpleStateReceiver> StateChanged;

		public SimpleStateReceiver(string uniqueName)
		{
			_stateRegistry = FlightSceneScript.Instance.NetworkStateRegistry;
			ReceiverId = _stateRegistry.Register(this, uniqueName);
		}

		public void AddState(int addState)
		{
			_stateRegistry.AddState(this, addState);
		}

		public void OnDestroy()
		{
			_stateRegistry.Unregister(this);
		}

		public void SetState(int state)
		{
			_stateRegistry.SetState(this, state);
			SetStateLocal(state, initialValue: false);
		}

		void INetworkStateReceiver.SetState(int state, bool initialValue)
		{
			SetStateLocal(state, initialValue);
		}

		private void SetStateLocal(int state, bool initialValue)
		{
			if (State != state)
			{
				State = state;
				if (!initialValue)
				{
					this.StateChanged?.Invoke(this);
				}
			}
		}
	}
}
