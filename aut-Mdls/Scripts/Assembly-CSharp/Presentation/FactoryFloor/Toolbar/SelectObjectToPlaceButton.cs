using Data.Operator;
using Events.Generic;
using Logic.FactoryTools;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class SelectObjectToPlaceButton : ToolBarButton
	{
		[SerializeField]
		private IntEvent _placementToolButtonPressedEvent;

		[SerializeField]
		private FactoryObjectData _factoryObjectData;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		[SerializeField]
		private PlacementTool _placementTool;

		public override bool IsSelected
		{
			get
			{
				if (_toolSystemLocator.ToolSystem.SelectedTool == _placementTool)
				{
					return _placementTool.IsSelectedBlueprint(_factoryObjectData);
				}
				return false;
			}
		}

		public override string BreadcrumbId => _factoryObjectData.BreadcrumbId;

		public void SetItem(FactoryObjectData factoryObjectData)
		{
			_factoryObjectData = factoryObjectData;
		}

		public void SwitchToAreaEvent(IntEvent areaEvent)
		{
			_placementToolButtonPressedEvent = areaEvent;
		}

		protected override void ButtonPressed()
		{
			_placementToolButtonPressedEvent.Fire(_factoryObjectData.ID);
			base.ButtonPressed();
		}
	}
}
