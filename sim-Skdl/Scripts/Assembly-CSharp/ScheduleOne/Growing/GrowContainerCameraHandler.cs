using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Growing
{
	public class GrowContainerCameraHandler : MonoBehaviour
	{
		public enum ECameraPosition
		{
			Closeup = 0,
			Midshot = 1,
			Fullshot = 2,
			BirdsEye = 3
		}

		[SerializeField]
		private bool RotateCameraContainerToFacePlayer;

		[SerializeField]
		private bool SnapRotationToRightAngles;

		[SerializeField]
		private Transform _midshotCamera;

		[SerializeField]
		private Transform _closeupCamera;

		[SerializeField]
		private Transform _fullshotContainer;

		[SerializeField]
		private Transform _birdsEyeCamera;

		[Header("Debug & Development")]
		[SerializeField]
		private ECameraPosition _debugCameraPosition;

		public void PositionCameraContainer()
		{
		}

		public Transform GetCameraPosition(ECameraPosition pos, bool autoPosition = true)
		{
			return null;
		}

		[Button]
		private void SetCameraPosition()
		{
		}
	}
}
