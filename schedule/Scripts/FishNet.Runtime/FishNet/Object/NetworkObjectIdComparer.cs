using System.Collections.Generic;

namespace FishNet.Object
{
	public class NetworkObjectIdComparer : IEqualityComparer<NetworkObject>
	{
		public bool Equals(NetworkObject x, NetworkObject y)
		{
			return false;
		}

		public int GetHashCode(NetworkObject obj)
		{
			return 0;
		}
	}
}
