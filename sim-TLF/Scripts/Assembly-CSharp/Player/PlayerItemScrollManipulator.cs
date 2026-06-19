using Items;
using UnityEngine;
using Zenject;

namespace Player
{
	public class PlayerItemScrollManipulator : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerViewRaycaster;

		[SerializeField]
		private float _sensitivity;

		[Inject]
		private IPlayerInputService _inputService;

		private void OnEnable()
		{
			_inputService.OnRotate += TryScroll;
		}

		private void OnDisable()
		{
			_inputService.OnRotate -= TryScroll;
		}

		private void TryScroll(float value)
		{
			if (_playerViewRaycaster == null || !_playerViewRaycaster.Hit.transform)
			{
				return;
			}
			IScrollManipulatable component = _playerViewRaycaster.Hit.transform.GetComponent<IScrollManipulatable>();
			if (component != null)
			{
				if (value > 0f)
				{
					component.ScrollUp(value * _sensitivity);
				}
				else
				{
					component.ScrollDown(value * _sensitivity);
				}
			}
		}
	}
}
