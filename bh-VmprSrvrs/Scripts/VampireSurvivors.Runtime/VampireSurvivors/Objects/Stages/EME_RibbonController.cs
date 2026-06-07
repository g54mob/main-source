using UnityEngine;

namespace VampireSurvivors.Objects.Stages
{
	public class EME_RibbonController : MonoBehaviour
	{
		private enum RibbonState
		{
			TravelingToNewTarget = 0,
			ReachedTarget = 1,
			FadingOnTargetChanged = 2,
			Disabled = 3
		}

		[SerializeField]
		private EME_Ribbon _ribbon;

		[SerializeField]
		private float _travelToNewTargetDuration;

		[SerializeField]
		private float _fadeTimeOnTargetChanged;

		private RibbonState _currentState;

		private float _timeInCurrentState;

		private float _toTargetPercent;

		private Vector3 _targetPosition;

		private Vector3 _nextTargetPosition;

		private Camera _mainCamera;

		public bool RibbonDisabled => false;

		private void Awake()
		{
		}

		public void DisableRibbon()
		{
		}

		public void UpdateRibbon(Vector3 playerPosition)
		{
		}

		public void SetNewTargetPosition(Vector3 newTargetPosition, bool skipFadeOut = false, bool skipFadeIn = false)
		{
		}

		private void ChangeState(RibbonState newState)
		{
		}
	}
}
