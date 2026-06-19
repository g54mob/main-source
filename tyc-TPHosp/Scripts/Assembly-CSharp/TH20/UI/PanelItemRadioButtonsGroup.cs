using System;

namespace TH20.UI
{
	public class PanelItemRadioButtonsGroup : PanelItem
	{
		private int _currentButtonID = -1;

		private PanelItemToggleButton[] _toggleButtonArray;

		[NonSerialized]
		public Action<int> OnButtonSelected;

		public override void Setup()
		{
			base.Setup();
			_toggleButtonArray = GetComponentsInChildren<PanelItemToggleButton>(includeInactive: true);
			for (int i = 0; i < _toggleButtonArray.Length; i++)
			{
				PanelItemToggleButton obj = _toggleButtonArray[i];
				obj.ButtonID = i;
				DynamicButton component = obj.GetComponent<DynamicButton>();
				if ((bool)component)
				{
					int id = i;
					component.onPrimaryDown.AddListener(delegate
					{
						SelectButton(id);
					});
				}
			}
		}

		public void SelectButtonOnly(int buttonID)
		{
			if (buttonID == _currentButtonID)
			{
				return;
			}
			_currentButtonID = buttonID;
			for (int i = 0; i < _toggleButtonArray.Length; i++)
			{
				PanelItemToggleButton panelItemToggleButton = _toggleButtonArray[i];
				if (i == _currentButtonID)
				{
					panelItemToggleButton.SetPressedState(state: true);
				}
				else
				{
					panelItemToggleButton.SetPressedState(state: false);
				}
			}
		}

		public void SelectButton(int buttonID)
		{
			SelectButtonOnly(buttonID);
			OnButtonSelected.InvokeSafe(_currentButtonID);
		}

		public PanelItemToggleButton[] GetToggleButtons()
		{
			return _toggleButtonArray;
		}
	}
}
