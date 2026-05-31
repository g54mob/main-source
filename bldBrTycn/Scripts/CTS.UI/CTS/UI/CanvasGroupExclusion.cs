using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public class CanvasGroupExclusion : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroupController _toHide;

		[SerializeField]
		private CanvasGroupController _toObserve;

		private LockToggle _toggle;

		private void Awake()
		{
			if ((bool)_toHide)
			{
				_toggle = new LockToggle(_toHide);
			}
		}

		private void OnDisable()
		{
			if ((bool)_toObserve)
			{
				_toObserve.CanvasShowning -= OnCanvasShowning;
			}
		}

		private void OnEnable()
		{
			if ((bool)_toObserve)
			{
				_toObserve.CanvasShowning += OnCanvasShowning;
			}
		}

		private void OnCanvasShowning(bool value)
		{
			if (_toggle != null)
			{
				_toggle.SetLock(value);
			}
		}
	}
}
