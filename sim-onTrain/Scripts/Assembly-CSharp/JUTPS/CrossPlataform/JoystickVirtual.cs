using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace JUTPS.CrossPlataform
{
	[AddComponentMenu("JU TPS/Mobile/Joystick")]
	public class JoystickVirtual : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IPointerUpHandler
	{
		[Range(0f, 1f)]
		public float JoystickMaxDistance = 0.45f;

		public Image BackgroundImage;

		public Image JoystickImage;

		private Vector3 _inputVector;

		public bool IsPressed;

		[Range(0f, 1f)]
		public float Intensity;

		private Vector2 startPos;

		public Vector3 InputVector => _inputVector;

		private void Start()
		{
			startPos = JoystickImage.rectTransform.position;
		}

		private void Update()
		{
			RefreshJoystickPointPosition();
		}

		public void OnPointerDown(PointerEventData e)
		{
			IsPressed = true;
			OnDrag(e);
		}

		public void OnDrag(PointerEventData e)
		{
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BackgroundImage.rectTransform, e.position, e.pressEventCamera, out var localPoint))
			{
				localPoint.x /= BackgroundImage.rectTransform.sizeDelta.x;
				localPoint.y /= BackgroundImage.rectTransform.sizeDelta.y;
				_inputVector = new Vector3(localPoint.x * 2f + 1f, 0f, localPoint.y * 2f - 1f);
				_inputVector = ((_inputVector.magnitude > 1f) ? _inputVector.normalized : _inputVector);
				JoystickImage.rectTransform.anchoredPosition = new Vector3(_inputVector.x * (BackgroundImage.rectTransform.sizeDelta.x * JoystickMaxDistance), _inputVector.z * (BackgroundImage.rectTransform.sizeDelta.y * JoystickMaxDistance));
			}
		}

		public void OnPointerUp(PointerEventData e)
		{
			IsPressed = false;
			_inputVector = Vector3.zero;
			JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
		}

		private void OnDisable()
		{
			_inputVector = Vector3.zero;
		}

		public void RefreshJoystickPointPosition()
		{
			Vector2 anchoredPosition = new Vector2(_inputVector.x * (BackgroundImage.rectTransform.sizeDelta.x * JoystickMaxDistance), _inputVector.z * (BackgroundImage.rectTransform.sizeDelta.y * JoystickMaxDistance));
			JoystickImage.rectTransform.anchoredPosition = anchoredPosition;
			Intensity = InputVector.magnitude;
		}

		public float Horizontal()
		{
			if (_inputVector.x != 0f)
			{
				return _inputVector.x;
			}
			return 0f;
		}

		public float Vertical()
		{
			if (_inputVector.z != 0f)
			{
				return _inputVector.z;
			}
			return 0f;
		}
	}
}
