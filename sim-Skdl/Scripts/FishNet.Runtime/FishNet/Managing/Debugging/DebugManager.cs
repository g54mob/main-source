using UnityEngine;

namespace FishNet.Managing.Debugging
{
	[AddComponentMenu("FishNet/Manager/DebugManager")]
	[DisallowMultipleComponent]
	public class DebugManager : MonoBehaviour
	{
		public bool WriteSceneObjectDetails;

		public bool ObserverRpcLinks;

		public bool TargetRpcLinks;

		public bool ReplicateRpcLinks;

		public bool ReconcileRpcLinks;

		public bool ServerRpcLinks;
	}
}
