using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public class DevicePlacementPointCorrector : MonoBehaviour
	{
		[SerializeField]
		private ElementSocket dependentSocket;

		[SerializeField]
		public Vector3 defaultPosition;

		[SerializeField]
		public Quaternion defaultRotation;

		[SerializeField]
		public Vector3 correctedPosition;

		[SerializeField]
		public Quaternion correctedRotation;

		private void OnEnable()
		{
			dependentSocket.OnNestedElementChanged += ResolveDependentSocketChanged;
			ResolveDependentSocketChanged(dependentSocket);
		}

		private void OnDisable()
		{
			dependentSocket.OnNestedElementChanged -= ResolveDependentSocketChanged;
		}

		private void ResolveDependentSocketChanged(ElementSocket socket)
		{
			if ((bool)socket.NestedElement)
			{
				base.transform.SetLocalPositionAndRotation(defaultPosition, defaultRotation);
			}
			else
			{
				base.transform.SetLocalPositionAndRotation(correctedPosition, correctedRotation);
			}
		}
	}
}
