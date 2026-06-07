using Events;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class ToolbarView : MonoBehaviour
	{
		[SerializeField]
		private ToolBarButton _selectedButton;

		[SerializeField]
		private BaseEvent _actionCanceledEvent;

		private ToolBarButton[] _allButtons;

		private ToolBarButton _defaultButton;

		private void Awake()
		{
			_allButtons = GetComponentsInChildren<ToolBarButton>(includeInactive: true);
			ToolBarButton[] allButtons = _allButtons;
			foreach (ToolBarButton obj in allButtons)
			{
				obj.Pressed += OnNewButtonPressed;
				obj.DeSelected();
			}
			_selectedButton.Selected();
			_defaultButton = _selectedButton;
			_actionCanceledEvent.Register(ReturnToDefaultTool);
		}

		private void OnDestroy()
		{
			_actionCanceledEvent.UnRegister(ReturnToDefaultTool);
		}

		private void ReturnToDefaultTool()
		{
			OnNewButtonPressed(_defaultButton);
		}

		private void OnNewButtonPressed(ToolBarButton button)
		{
			_selectedButton.DeSelected();
			_selectedButton = button;
			_selectedButton.Selected();
		}
	}
}
