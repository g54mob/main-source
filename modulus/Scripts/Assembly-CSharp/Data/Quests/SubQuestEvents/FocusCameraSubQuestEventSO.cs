using Presentation.Locators;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Focus Camera", fileName = "FocusCamera", order = 4)]
	public class FocusCameraSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private Vector3 _targetPosition;

		[SerializeField]
		[Range(0f, 1f)]
		private float _targetZoomLevel = 0.5f;

		[SerializeField]
		[Range(0f, 360f)]
		private float _targetYRotation = 180f;

		[SerializeField]
		[Range(25f, 70f)]
		private float _targetYUpRotation = 50f;

		public override void Execute()
		{
			_cameraViewLocator.CameraView.LerpToTarget(_targetPosition, _targetZoomLevel, _targetYRotation, _targetYUpRotation, blockInput: true);
		}
	}
}
