using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun
{
	public struct InstantiateParameters
	{
		public int[] viewIDs;

		public byte objLevelPrefix;

		public object[] data;

		public byte group;

		public Quaternion rotation;

		public Vector3 position;

		public string prefabName;

		public Player creator;

		public int timestamp;

		public InstantiateParameters(string prefabName, Vector3 position, Quaternion rotation, byte group, object[] data, byte objLevelPrefix, int[] viewIDs, Player creator, int timestamp)
		{
			this.viewIDs = null;
			this.objLevelPrefix = 0;
			this.data = null;
			this.group = 0;
			this.rotation = default(Quaternion);
			this.position = default(Vector3);
			this.prefabName = null;
			this.creator = null;
			this.timestamp = 0;
		}
	}
}
