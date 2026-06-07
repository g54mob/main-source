using UnityEngine;
using Utils.Enums;

namespace Presentation.UI
{
	public class CameraPanningUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject _upArrow;

		[SerializeField]
		private GameObject _downArrow;

		[SerializeField]
		private GameObject _leftArrow;

		[SerializeField]
		private GameObject _rightArrow;

		[SerializeField]
		private AvailableCamMovementChangedEvent _availableMovementDirectionsChangedEvent;

		private void Awake()
		{
			_availableMovementDirectionsChangedEvent.Register(OnUpdateMovementDirections);
		}

		private void OnDestroy()
		{
			_availableMovementDirectionsChangedEvent.UnRegister(OnUpdateMovementDirections);
		}

		private void OnUpdateMovementDirections(MovementDirectionFlags availableDirectionFlags)
		{
			_upArrow.SetActive(availableDirectionFlags.HasFlag(MovementDirectionFlags.Up));
			_downArrow.SetActive(availableDirectionFlags.HasFlag(MovementDirectionFlags.Down));
			_leftArrow.SetActive(availableDirectionFlags.HasFlag(MovementDirectionFlags.Left));
			_rightArrow.SetActive(availableDirectionFlags.HasFlag(MovementDirectionFlags.Right));
		}
	}
}
