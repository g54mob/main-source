using CTS.Core;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(1)]
	public class RoomDetection : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private RoomObject _roomObject;

		private void OnTriggerExit(Collider other)
		{
			_roomObject.TryFindCurrentRoom();
		}
	}
}
