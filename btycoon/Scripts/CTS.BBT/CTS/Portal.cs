using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(1)]
	public class Portal : MonoBehaviour
	{
		private Room _room;

		private static int layerMask;

		private Vector3 _testPosition;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialization()
		{
			layerMask = 1 << LayerMask.NameToLayer("Default");
		}

		private void Awake()
		{
			_testPosition = base.transform.position + Vector3.forward + Vector3.up * 2.4f;
			if (Physics.Raycast(_testPosition, Vector3.down, out var hitInfo, 2f, layerMask, QueryTriggerInteraction.Collide))
			{
				hitInfo.collider.TryGetComponent<Room>(out _room);
			}
		}
	}
}
