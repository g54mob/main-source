using EasyTextEffects.Editor.MyBoxCopy.Attributes;
using UnityEngine;

namespace WorldEnvironment
{
	public class JoystickDriver : MonoBehaviour
	{
		[SerializeField]
		private bool _driveX;

		[SerializeField]
		private bool _driveY;

		[Space(5f)]
		[SerializeField]
		private float _minInputX;

		[SerializeField]
		private float _maxInputX;

		[ConditionalField(new string[] { "_driveX" })]
		[SerializeField]
		private Vector3 _axisX = Vector3.right;

		[ConditionalField(new string[] { "_driveX" })]
		[SerializeField]
		private float _minRotX;

		[ConditionalField(new string[] { "_driveX" })]
		[SerializeField]
		private float _maxRotX;

		[ConditionalField(new string[] { "_driveX" })]
		[SerializeField]
		private bool _revertX;

		[Space(5f)]
		[SerializeField]
		private float _minInputY;

		[SerializeField]
		private float _maxInputY;

		[ConditionalField(new string[] { "_driveY" })]
		[SerializeField]
		private Vector3 _axisY = Vector3.forward;

		[ConditionalField(new string[] { "_driveY" })]
		[SerializeField]
		private float _minRotY;

		[ConditionalField(new string[] { "_driveY" })]
		[SerializeField]
		private float _maxRotY;

		[ConditionalField(new string[] { "_driveY" })]
		[SerializeField]
		private bool _revertY;

		private float _currentX;

		private float _currentY;

		public void DriveX(float value)
		{
			float num = Mathf.InverseLerp(_minInputX, _maxInputX, value);
			if (_revertX)
			{
				num = 1f - num;
			}
			_currentX = Mathf.Lerp(_minRotX, _maxRotX, num);
			ApplyRotation();
		}

		public void DriveY(float value)
		{
			float num = Mathf.InverseLerp(_minInputY, _maxInputY, value);
			if (_revertY)
			{
				num = 1f - num;
			}
			_currentY = Mathf.Lerp(_minRotY, _maxRotY, num);
			ApplyRotation();
		}

		private void ApplyRotation()
		{
			base.transform.localRotation = Quaternion.AngleAxis(_currentX, _axisX) * Quaternion.AngleAxis(_currentY, _axisY);
		}
	}
}
