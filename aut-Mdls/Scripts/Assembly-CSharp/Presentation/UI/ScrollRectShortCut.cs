using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class ScrollRectShortCut : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _inputAction;

		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private float _sensitivity = 0.1f;

		[SerializeField]
		private float _deceleration = 0.5f;

		[SerializeField]
		private float _speedMultiplier = 10f;

		[SerializeField]
		private float _zoomLevelWeight = 1f;

		private float _currentSensitivity;

		private Vector2 _velocity01 = Vector2.zero;

		private void Awake()
		{
			_currentSensitivity = _sensitivity;
		}

		private void Update()
		{
			if (_scrollRect.isActiveAndEnabled)
			{
				UpdateVelocity();
				Vector2 vector = _currentSensitivity * Time.deltaTime * _velocity01;
				_scrollRect.content.anchoredPosition -= vector * _speedMultiplier;
			}
		}

		private void UpdateVelocity()
		{
			Vector2 vector = _inputAction.action.ReadValue<Vector2>();
			if (vector.sqrMagnitude < 0.01f)
			{
				_velocity01 -= _deceleration * Time.deltaTime * _velocity01;
			}
			else
			{
				_velocity01 = vector.normalized;
			}
		}

		public void ScaleSensitivityFromDefault(float scalar)
		{
			_currentSensitivity = Mathf.Lerp(_sensitivity, _sensitivity * scalar, _zoomLevelWeight);
		}
	}
}
