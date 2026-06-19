using Mirror;

namespace Aggro.Core.Networking
{
	public struct NetBehaviourId
	{
		public readonly NetworkIdentity networkIdentity;

		public readonly uint behaviourId;

		public bool isValid
		{
			get
			{
				if (behaviourId != 0)
				{
					return (object)networkIdentity != null;
				}
				return false;
			}
		}

		public static NetBehaviourId invalid => default(NetBehaviourId);

		internal NetBehaviourId(NetworkIdentity networkIdentity, uint behaviourId)
		{
			this.networkIdentity = networkIdentity;
			this.behaviourId = behaviourId;
		}

		public T Get<T>() where T : NetworkEntityBehaviourBase
		{
			TryGet<T>(out var behaviour);
			return behaviour;
		}

		public bool TryGet<T>(out T behaviour) where T : NetworkEntityBehaviourBase
		{
			if ((object)networkIdentity != null && networkIdentity.TryGetEntity(out var entity) && entity.behaviour.TryGetNetworkBehaviour<T>(behaviourId, out behaviour))
			{
				return true;
			}
			behaviour = null;
			return false;
		}
	}
}
