using Data.Variables;
using Presentation.Locators;
using Presentation.UI.Menus.HudPanelTabGroups;
using UnityEngine;

namespace Presentation.UI.Freighters
{
	public class FreightersUI : TabGroupPanel
	{
		[SerializeField]
		private GameObject _listPanel;

		[SerializeField]
		private GameObject _controlPanel;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		[SerializeField]
		private BoolVariableSO _freightersControlMode;

		[SerializeField]
		private CameraViewLocator _mainCameraViewLocator;

		[SerializeField]
		private float _cameraPixelOffset = 600f;

		private void Start()
		{
			_controlPanel.SetActive(value: false);
			_listPanel.SetActive(value: true);
			_selectedFreighterInUI.ValueChanged += SelectedFreighterChanged;
			_freightersControlMode.ValueChanged += SetControlMode;
		}

		private void OnDestroy()
		{
			_selectedFreighterInUI.ValueChanged -= SelectedFreighterChanged;
			_freightersControlMode.ValueChanged -= SetControlMode;
		}

		private void SetControlMode(bool value)
		{
			_listPanel.SetActive(!value);
			_controlPanel.SetActive(value);
			_mainCameraViewLocator.CameraView.SetCameraFollowOffset(value ? _cameraPixelOffset : 0f);
		}

		private void SelectedFreighterChanged(int selectedFreighter)
		{
			SetControlMode(selectedFreighter >= 0);
		}
	}
}
