using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TrainingDroneDifficultySelector : MonoBehaviour
	{
		public DisplayTrainingDrones DroneDisplay;

		public EnumChooser Chooser;

		public void Start()
		{
			Chooser.Init<ETrainingDifficulty>(DisplayTrainingDrones.ActiveDifficulty);
		}

		public void Update()
		{
			if ((ETrainingDifficulty)(object)Chooser.SelectedOption != DisplayTrainingDrones.ActiveDifficulty)
			{
				DisplayTrainingDrones.ActiveDifficulty = (ETrainingDifficulty)(object)Chooser.SelectedOption;
				DroneDisplay.UpdateDrones();
			}
		}
	}
}
