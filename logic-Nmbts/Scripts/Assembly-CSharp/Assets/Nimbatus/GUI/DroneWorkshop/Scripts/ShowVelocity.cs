using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowVelocity : MonoBehaviour
	{
		public UILabel Label;

		public UILabel NumberLabel;

		public void Update()
		{
			float num = 0f;
			TestAreaRaceManager testAreaRaceManager;
			if (RuntimeGlobals.NimbatusPlayer != null)
			{
				num = RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.CurrentVelocity;
			}
			else if ((object)(testAreaRaceManager = BaseRaceManager.Instance as TestAreaRaceManager) != null)
			{
				num = testAreaRaceManager.PlayerDrone.RootDronePart.CurrentVelocity;
			}
			string termTranslation = LocalizationManager.GetTermTranslation("MainScene/Velocity");
			Label.text = termTranslation;
			NumberLabel.text = num.ToString("###0") + " " + LocalizationManager.GetTermTranslation("Units/MeterPerSecond");
		}
	}
}
