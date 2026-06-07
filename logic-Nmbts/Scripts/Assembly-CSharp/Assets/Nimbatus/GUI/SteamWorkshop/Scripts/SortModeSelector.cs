using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class SortModeSelector : MonoBehaviour
	{
		public EnumChooser Chooser;

		private DroneBrowserManager _manager;

		public EWorkshopSortMode CurrentSortMode;

		public void Init(DroneBrowserManager droneBrowserManager)
		{
			_manager = droneBrowserManager;
			Chooser.Init<EWorkshopSortMode>(EWorkshopSortMode.Trend);
			CurrentSortMode = EWorkshopSortMode.Trend;
		}

		public void Update()
		{
			if ((EWorkshopSortMode)(object)Chooser.SelectedOption != CurrentSortMode)
			{
				CurrentSortMode = (EWorkshopSortMode)(object)Chooser.SelectedOption;
				_manager.UpdatePage();
			}
		}
	}
}
