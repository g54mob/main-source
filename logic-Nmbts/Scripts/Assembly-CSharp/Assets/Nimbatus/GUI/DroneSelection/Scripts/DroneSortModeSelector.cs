using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DroneSortModeSelector : MonoBehaviour
	{
		public EnumChooser Chooser;

		private DroneSelectionManager _manager;

		public static EDroneSortMode CurrentSortMode;

		public void Init(DroneSelectionManager droneBrowserManager)
		{
			_manager = droneBrowserManager;
			Chooser.Init<EDroneSortMode>(CurrentSortMode);
		}

		public void Update()
		{
			if ((EDroneSortMode)(object)Chooser.SelectedOption != CurrentSortMode)
			{
				CurrentSortMode = (EDroneSortMode)(object)Chooser.SelectedOption;
				_manager.UpdateList();
			}
		}
	}
}
