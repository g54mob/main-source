using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowAngularVelocity : MonoBehaviour
	{
		public UILabel Label;

		public UILabel NumberLabel;

		public void Update()
		{
			float num = 0f;
			TestAreaRaceManager testAreaRaceManager;
			if (RuntimeGlobals.NimbatusPlayer != null)
			{
				num = RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.CurrentAngularVelocity;
			}
			else if ((object)(testAreaRaceManager = BaseRaceManager.Instance as TestAreaRaceManager) != null)
			{
				num = testAreaRaceManager.PlayerDrone.RootDronePart.CurrentAngularVelocity;
			}
			string termTranslation = LocalizationManager.GetTermTranslation("MainScene/AngularVelocity");
			Label.text = termTranslation;
			NumberLabel.text = num.ToString("###0") + " " + LocalizationManager.GetTermTranslation("Units/DegreePerSecond");
		}
	}
}
