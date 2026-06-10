using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.Construction
{
	public class ReservablePosition
	{
		private Vec3Int position;

		private IGoapAgentOwner agentOwner;

		public Vec3Int Position => position;

		public bool Reserved => agentOwner != null;

		public ReservablePosition(Vec3Int position)
		{
			this.position = position;
		}

		public bool Reserve(IGoapAgentOwner agentOwner)
		{
			if (Reserved)
			{
				return false;
			}
			this.agentOwner = agentOwner;
			this.agentOwner.OnDisposedEvent += OnAgentOwnerDisposed;
			return true;
		}

		public void Release(IGoapAgentOwner agentOwner)
		{
			if (agentOwner != null && this.agentOwner == agentOwner)
			{
				this.agentOwner.OnDisposedEvent -= OnAgentOwnerDisposed;
				this.agentOwner = null;
			}
		}

		private void OnAgentOwnerDisposed(IGameDisposable disposable)
		{
			Release(agentOwner);
		}
	}
}
