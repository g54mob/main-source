using Data.FactoryFloor.Behaviours;
using Presentation.UI.LayoutElements;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class MonotonerUI : FactoryPanelUIMenu
	{
		[Header("Monotoner UI")]
		[SerializeField]
		private SwitchToggle _toggleColorSwitch;

		private MonotonerBehaviour _behaviour;

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as MonotonerBehaviour;
			if (_state == AbstractUIMenuData.UIMenuState.ConfigureMode)
			{
				_toggleColorSwitch.OnValueChanged.AddListener(TogglePaintColor);
				_behaviour.OnChangedPaintMode.RegisterMainThread(OnPaintColorChanged);
				OnPaintColorChanged(_behaviour.IsPaintingBlack);
			}
		}

		public override void HideMenu()
		{
			_toggleColorSwitch.OnValueChanged.RemoveListener(TogglePaintColor);
			_behaviour.OnChangedPaintMode.UnRegisterMainThread(OnPaintColorChanged);
			base.HideMenu();
		}

		private void TogglePaintColor(bool isBlack)
		{
			_behaviour.ToggleColor();
		}

		private void OnPaintColorChanged(bool isBlackPaint)
		{
			_toggleColorSwitch.SetIsOnWithoutNotify(isBlackPaint);
		}
	}
}
