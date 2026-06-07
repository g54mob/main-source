using Data.FactoryFloor.FactoryObjectBehaviours;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class DisplayCaseUI : FactoryPanelUIMenu
	{
		[SerializeField]
		private Button _resetButton;

		private DisplayBehaviour _behaviour;

		protected override void Initialized()
		{
			base.Initialized();
			_behaviour = _factoryObjectBehaviour as DisplayBehaviour;
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			_resetButton.onClick.AddListener(HandleReset);
		}

		private void HandleReset()
		{
			_behaviour.Reset();
		}

		public override void HideMenu()
		{
			_resetButton.onClick.RemoveListener(HandleReset);
			base.HideMenu();
		}
	}
}
