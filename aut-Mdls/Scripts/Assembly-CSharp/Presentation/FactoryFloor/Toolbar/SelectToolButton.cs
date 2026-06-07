using Events;
using Events.FactoryFloor.Tools;
using Logic.FactoryTools;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class SelectToolButton : ToolBarButton
	{
		[Space]
		[SerializeField]
		private bool _useSelectToolEvent;

		[SerializeField]
		[HideIf("_useSelectToolEvent")]
		private BaseEvent _selectToolButtonPressedEvent;

		[SerializeField]
		[ShowIf("_useSelectToolEvent")]
		private SelectToolEvent _selectToolEvent;

		[Space]
		[SerializeField]
		private FactoryTool _factoryTool;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		private bool _isSelected;

		public override bool IsSelected
		{
			get
			{
				if (!_isSelected)
				{
					if (_toolSystemLocator != null)
					{
						return _toolSystemLocator.ToolSystem.SelectedTool == _factoryTool;
					}
					return false;
				}
				return true;
			}
		}

		public override string BreadcrumbId => _factoryTool.BreadcrumbId;

		protected override void ButtonPressed()
		{
			if (_useSelectToolEvent)
			{
				_selectToolEvent.Fire(_factoryTool);
			}
			else
			{
				_selectToolButtonPressedEvent.Fire();
			}
			base.ButtonPressed();
		}

		public override void Selected()
		{
			_isSelected = true;
			base.Selected();
		}

		public override void DeSelected()
		{
			_isSelected = false;
			base.DeSelected();
		}
	}
}
