using Coherence.Connection;
using Coherence.Entities;
using UnityEngine;

namespace Coherence.Toolkit
{
	public struct SpawnInfo
	{
		public string assetId;

		public bool isFromGroup;

		public Vector3 position;

		public Quaternion? rotation;

		public Entity connectedEntity;

		public ClientID? clientId;

		public string uniqueId;

		public ConnectionType? connectionType;

		public ICoherenceSync prefab;

		public ICoherenceBridge bridge;

		internal ComponentUpdates ComponentUpdates;

		public T GetBindingValue<T>(string bindingName)
		{
			return default(T);
		}
	}
}
