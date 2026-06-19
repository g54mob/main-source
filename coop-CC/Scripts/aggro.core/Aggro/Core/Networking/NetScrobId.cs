namespace Aggro.Core.Networking
{
	public struct NetScrobId
	{
		public readonly uint id;

		public bool isValid => id != 0;

		public static NetScrobId invalid => default(NetScrobId);

		internal NetScrobId(uint id)
		{
			this.id = id;
		}

		public T Get<T>() where T : NetworkScriptableObject
		{
			NetworkObjectDatabase.TryGetNetworkScrob<NetworkScriptableObject>(id, out var scrob);
			return scrob as T;
		}

		public bool TryGet<T>(out T scrob) where T : NetworkScriptableObject
		{
			if (NetworkObjectDatabase.TryGetNetworkScrob<NetworkScriptableObject>(id, out var scrob2) && scrob2 is T val)
			{
				scrob = val;
				return true;
			}
			scrob = null;
			return false;
		}
	}
}
