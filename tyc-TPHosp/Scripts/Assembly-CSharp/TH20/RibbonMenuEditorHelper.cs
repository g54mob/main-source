using UnityEngine;

namespace TH20
{
	[ExecuteInEditMode]
	public class RibbonMenuEditorHelper : MonoBehaviour
	{
		[SerializeField]
		private RibbonMenu _ribbonMenu;

		[SerializeField]
		private RibbonMenu.Mode _targetMode;

		[SerializeField]
		private bool _showBuildMenu;

		[SerializeField]
		private bool _updateEveryFrame;

		private RibbonMenu.Mode _currentMode;

		private bool _currentShowBuildMenu;

		private GameObject[] _previousBarEnabledGameObjects;

		private GameObject[] _previousBodyEnabledGameObjects;

		public void Update()
		{
		}

		private void UpdateTransitions()
		{
			switch (_targetMode)
			{
			case RibbonMenu.Mode.Hire:
				_ribbonMenu.Settings.TableHeaders.SetActive(value: true);
				RibbonMenuBarAnimator.TransitionInstantly(_ribbonMenu.BarAnimatorSettings, _ribbonMenu.HireStateSettings.BarWidth, _ribbonMenu.HireStateSettings.BarLeftSectionWidth, _ribbonMenu.HireStateSettings.BarGameObjects, _previousBarEnabledGameObjects);
				RibbonMenuBodyAnimator.TransitionInstantly(_ribbonMenu.BodyAnimatorSettings, ref _ribbonMenu.HireStateSettings.BodyAnimatorTarget, _ribbonMenu.HireStateSettings.BodyGameObjects, _previousBodyEnabledGameObjects);
				break;
			case RibbonMenu.Mode.Rooms:
				_ribbonMenu.Settings.TableHeaders.SetActive(value: false);
				RibbonMenuBarAnimator.TransitionInstantly(_ribbonMenu.BarAnimatorSettings, _ribbonMenu.RoomsStateSettings.BarWidth, _ribbonMenu.RoomsStateSettings.BarLeftSectionWidth, _ribbonMenu.RoomsStateSettings.BarGameObjects, _previousBarEnabledGameObjects);
				RibbonMenuBodyAnimator.TransitionInstantly(_ribbonMenu.BodyAnimatorSettings, ref _ribbonMenu.RoomsStateSettings.BodyAnimatorTarget, _ribbonMenu.RoomsStateSettings.BodyGameObjects, _previousBodyEnabledGameObjects);
				break;
			case RibbonMenu.Mode.Items:
				_ribbonMenu.Settings.TableHeaders.SetActive(value: false);
				RibbonMenuBarAnimator.TransitionInstantly(_ribbonMenu.BarAnimatorSettings, _ribbonMenu.ItemsStateSettings.BarWidth, _ribbonMenu.ItemsStateSettings.BarLeftSectionWidth, _ribbonMenu.ItemsStateSettings.BarGameObjects, _previousBarEnabledGameObjects);
				_ribbonMenu.RibbonMenuItemsState.RefreshUGCButtonState();
				RibbonMenuBodyAnimator.TransitionInstantly(_ribbonMenu.BodyAnimatorSettings, ref _ribbonMenu.ItemsStateSettings.BodyTableAnimatorTarget, _ribbonMenu.ItemsStateSettings.BodyGameObjects, _previousBodyEnabledGameObjects);
				break;
			}
			if (_showBuildMenu)
			{
				RibbonMenuBarAnimator.TransitionInstantly(_ribbonMenu.BarAnimatorSettings, _ribbonMenu.BuildStateSettings.BarWidth, _ribbonMenu.BuildStateSettings.BarLeftSectionWidth, _ribbonMenu.BuildStateSettings.BarGameObjects, _previousBarEnabledGameObjects);
			}
		}
	}
}
