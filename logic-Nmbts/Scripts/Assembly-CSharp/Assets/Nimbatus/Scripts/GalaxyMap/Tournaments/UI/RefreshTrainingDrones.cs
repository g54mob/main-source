using Assets.Nimbatus.GUI.Common.Scripts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class RefreshTrainingDrones : MonoBehaviour
	{
		public DisplayTrainingDrones TrainingDronesDisplay;

		public void OnClick()
		{
			TrainingDronesDisplay.UpdateDrones();
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				LocalizationManager.GetTermTranslation("Tournaments/RandomizeDrones");
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
