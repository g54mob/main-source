using NaughtyAttributes;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class ShowMenuOpenUIOnClick : OpenUIOnClick
	{
		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _uiMenuLocator;

		[SerializeField]
		[EnumFlags]
		private AbstractUIMenuData.ToggleTypes _uiToggles;

		public override void FireOpenUIEvent()
		{
			_showUIMenuEvent.Fire(new UIMenuBehaviourData(_uiMenuLocator.UIMenu, _objectView.FactoryObject, _uiToggles, _behaviour));
		}
	}
}
