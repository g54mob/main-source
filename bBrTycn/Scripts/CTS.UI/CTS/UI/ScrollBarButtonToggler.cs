using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	public class ScrollBarButtonToggler : CTSBehaviour
	{
		public enum EType
		{
			Max = 0,
			Min = 1
		}

		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		[SerializeField]
		private Scrollbar _scrollbar;

		[SerializeField]
		private EType _toggleType;

		private readonly LockToggle _buttonLock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_buttonLock.Add(_button);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_scrollbar.onValueChanged.AddListener(OnScrollBarChanged);
			OnScrollBarChanged(_scrollbar.value);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_scrollbar.onValueChanged.RemoveListener(OnScrollBarChanged);
		}

		private void OnScrollBarChanged(float value)
		{
			if (_toggleType == EType.Max)
			{
				_buttonLock.SetLock(value >= 1f);
			}
			else
			{
				_buttonLock.SetLock(value <= 0f);
			}
		}
	}
}
