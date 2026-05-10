using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_WorkerMgr_SortingToggle : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private Image _iconContainer;

		[SerializeField]
		private Sprite _normalIcon;

		[SerializeField]
		private Sprite _reverseIcon;

		private ToggleGroup _toggleGroup;

		private UI_WorkerMgr_Layouter _layouter;

		private IComparer<Worker> _comparer;

		private bool _isReversed;

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
			_iconContainer.overrideSprite = _normalIcon;
		}

		private void OnDestroy()
		{
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Disable();
		}

		public void Setup(UI_WorkerMgr_Layouter layouter, ToggleGroup toggleGroup, IComparer<Worker> comparer)
		{
			_toggleGroup = toggleGroup;
			_toggle.group = _toggleGroup;
			_layouter = layouter;
			_comparer = comparer;
		}

		public void Disable()
		{
			if (_toggle.isOn)
			{
				_toggleGroup.allowSwitchOff = true;
				_toggle.isOn = false;
			}
		}

		private void OnToggleChanged(bool isOn)
		{
			if (!isOn)
			{
				SetReverse(isReverse: false);
				return;
			}
			_toggleGroup.allowSwitchOff = false;
			_layouter.Reorder(_comparer, _isReversed);
			SetReverse(!_isReversed);
		}

		private void SetReverse(bool isReverse)
		{
			if (isReverse != _isReversed)
			{
				_isReversed = isReverse;
				_iconContainer.overrideSprite = (_isReversed ? _reverseIcon : _normalIcon);
			}
		}
	}
}
