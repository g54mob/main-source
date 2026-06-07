using System.Collections;
using UnityEngine;

namespace RuralGasStation
{
	public class WindowVerticalMovement : IDoor
	{
		[SerializeField]
		private float _openHeight = 2f;

		[SerializeField]
		private float _closeHeight;

		[SerializeField]
		private float _moveSpeed = 2f;

		private float _delay = 0.3f;

		private bool _isOpen;

		private bool _canOpen = true;

		public override void Handle()
		{
			if (_canOpen)
			{
				if (!_isOpen)
				{
					StartCoroutine(MoveWindow(_openHeight));
				}
				else
				{
					StartCoroutine(MoveWindow(_closeHeight));
				}
			}
		}

		private IEnumerator MoveWindow(float targetHeight)
		{
			_canOpen = false;
			float startHeight = base.transform.localPosition.y;
			while (!Mathf.Approximately(startHeight, targetHeight))
			{
				startHeight = Mathf.MoveTowards(startHeight, targetHeight, _moveSpeed * Time.deltaTime);
				Vector3 localPosition = base.transform.localPosition;
				localPosition = new Vector3(localPosition.x, startHeight, localPosition.z);
				base.transform.localPosition = localPosition;
				yield return null;
			}
			Vector3 localPosition2 = base.transform.localPosition;
			localPosition2 = new Vector3(localPosition2.x, targetHeight, localPosition2.z);
			base.transform.localPosition = localPosition2;
			_isOpen = !_isOpen;
			yield return new WaitForSeconds(_delay);
			_canOpen = true;
		}
	}
}
