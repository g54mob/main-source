using System.Collections;
using UnityEngine;

namespace RuralGasStation
{
	public class GarageDoor : IDoor
	{
		[SerializeField]
		private Animator _animator;

		private float _delay = 4.5f;

		private bool _isOpen;

		private bool _canOpen = true;

		public override void Handle()
		{
			if (_canOpen)
			{
				if (!_isOpen)
				{
					Open();
				}
				else
				{
					Close();
				}
			}
		}

		private void Close()
		{
			_animator.SetTrigger("Close");
			_isOpen = !_isOpen;
			_canOpen = false;
			StartCoroutine(DelayBeforeOpen());
		}

		private void Open()
		{
			_animator.SetTrigger("Open");
			_isOpen = !_isOpen;
			_canOpen = false;
			StartCoroutine(DelayBeforeOpen());
		}

		private IEnumerator DelayBeforeOpen()
		{
			yield return new WaitForSeconds(_delay);
			_canOpen = true;
		}
	}
}
