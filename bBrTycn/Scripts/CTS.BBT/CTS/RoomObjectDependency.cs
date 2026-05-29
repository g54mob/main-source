using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class RoomObjectDependency : MonoBehaviour, IDependencyResolver<VFXData>
	{
		[SerializeField]
		private ReceiverReference<RoomObject>[] _roomReceivers;

		public void ResolveDependencies(GameObject obj, VFXData data)
		{
			if (_roomReceivers == null || _roomReceivers.Length == 0)
			{
				return;
			}
			RoomObject componentInParent = obj.GetComponentInParent<RoomObject>();
			if (!(componentInParent == null))
			{
				ReceiverReference<RoomObject>[] roomReceivers = _roomReceivers;
				foreach (ReceiverReference<RoomObject> receiverReference in roomReceivers)
				{
					receiverReference.Give(componentInParent);
				}
			}
		}
	}
}
