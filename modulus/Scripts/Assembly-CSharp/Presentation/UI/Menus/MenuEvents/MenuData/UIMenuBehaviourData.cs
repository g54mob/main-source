using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class UIMenuBehaviourData : AbstractUIMenuData
	{
		public readonly FactoryObjectBehaviour Behaviour;

		public readonly FactoryObject FactoryObject;

		public UIMenuBehaviourData(UIMenu uiMenu, FactoryObject factoryObject, ToggleTypes toggles, FactoryObjectBehaviour behaviour)
			: base(uiMenu, UIDomain.Factory, toggles)
		{
			Behaviour = behaviour;
			FactoryObject = factoryObject;
		}

		public UIMenuBehaviourData(UIMenu uiMenu, FactoryObject factoryObject, UIMenuState state, FactoryObjectBehaviour behaviour)
			: base(uiMenu, UIDomain.Factory, state)
		{
			Behaviour = behaviour;
			FactoryObject = factoryObject;
		}
	}
}
