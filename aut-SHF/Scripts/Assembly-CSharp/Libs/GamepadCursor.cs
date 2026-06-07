using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Libs
{
	public class GamepadCursor : MonoBehaviour
	{
		[FormerlySerializedAs("sensitivity")]
		[Tooltip("Higher numbers for more mouse movement on joystick press.Warning: diagonal movement lost at lower sensitivity (<1000)")]
		public Vector2 _sensitivity;

		[FormerlySerializedAs("bias")]
		[Tooltip("Counteract tendency for cursor to move more easily in some directions")]
		public Vector2 _bias;

		public Vector2 _dpadSensitivity;

		private Vector2 _leftStick;

		private Vector2 _dpadInput;

		private Vector2 _mousePosition;

		private Vector2 _warpPosition;

		private Vector2 _overflow;

		private EventSystem _eventSystem;

		private bool _isEnable;

		public bool IsEnable => false;

		public void SetEnable(bool enable)
		{
		}

		private void Update()
		{
		}
	}
}
