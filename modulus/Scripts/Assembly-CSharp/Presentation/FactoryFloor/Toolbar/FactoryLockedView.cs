using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class FactoryLockedView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private GameObject _locked;

		[SerializeField]
		private GameObject _unlocked;

		[SerializeField]
		private Selectable _button;

		private bool _isLocked;

		private bool _isForcedLock;

		private bool _isVisuallyUnavailable;

		public bool IsForcedLock
		{
			set
			{
				_isLocked = value;
				_isForcedLock = value;
				UpdateUnlockVisuals();
			}
		}

		public bool IsLocked
		{
			get
			{
				return GetIsLocked();
			}
			set
			{
				_isLocked = value;
				UpdateUnlockVisuals();
			}
		}

		public bool IsVisuallyUnavailable
		{
			get
			{
				return _isVisuallyUnavailable;
			}
			set
			{
				_isVisuallyUnavailable = value;
				_canvasGroup.alpha = (_isVisuallyUnavailable ? 0.4f : 1f);
			}
		}

		protected virtual void Start()
		{
			UpdateUnlockVisuals();
		}

		protected virtual bool GetIsLocked()
		{
			return _isLocked;
		}

		protected void UpdateUnlockVisuals()
		{
			bool flag = _isForcedLock || GetIsLocked();
			if ((bool)_canvasGroup)
			{
				_canvasGroup.alpha = (flag ? 0.4f : 1f);
				_canvasGroup.interactable = !flag;
			}
			if ((bool)_locked)
			{
				_locked.SetActive(flag);
			}
			if ((bool)_unlocked)
			{
				_unlocked.SetActive(!flag);
			}
			if ((bool)_button)
			{
				_button.interactable = !flag;
			}
		}
	}
}
