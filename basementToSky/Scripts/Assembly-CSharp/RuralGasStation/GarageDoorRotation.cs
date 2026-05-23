using System.Collections;
using UnityEngine;

namespace RuralGasStation
{
	public class GarageDoorRotation : IDoor
	{
		[SerializeField]
		private float _openAngle = 90f;

		[SerializeField]
		private float _closeAngle;

		[SerializeField]
		private float _rotationSpeed = 50f;

		private float _delay = 0.5f;

		private bool _isOpen;

		private bool _canOpen = true;

		public override void Handle()
		{
			if (_canOpen)
			{
				if (!_isOpen)
				{
					StartCoroutine(RotateDoor(_openAngle));
				}
				else
				{
					StartCoroutine(RotateDoor(_closeAngle));
				}
			}
		}

		private IEnumerator RotateDoor(float targetAngle)
		{
			_canOpen = false;
			float startAngle = NormalizeAngle(base.transform.localEulerAngles.y);
			targetAngle = NormalizeAngle(targetAngle);
			while (!Mathf.Approximately(startAngle, targetAngle))
			{
				startAngle = Mathf.MoveTowardsAngle(startAngle, targetAngle, _rotationSpeed * Time.deltaTime);
				base.transform.localRotation = Quaternion.Euler(0f, startAngle, 0f);
				yield return null;
			}
			base.transform.localRotation = Quaternion.Euler(0f, targetAngle, 0f);
			_isOpen = !_isOpen;
			yield return new WaitForSeconds(_delay);
			_canOpen = true;
		}

		private float NormalizeAngle(float angle)
		{
			angle %= 360f;
			if (angle < 0f)
			{
				angle += 360f;
			}
			return angle;
		}
	}
}
