using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ExitDroneWorkshop : MonoBehaviour
	{
		public bool RevertDroneChanges;

		public ExitConfirmationWindow ExitConfirmationWindow;

		public void OnClick()
		{
			if (RevertDroneChanges && ExitConfirmationWindow != null)
			{
				ExitConfirmationWindow.Show();
			}
			else
			{
				NimbatusSceneManager.LoadScene(DronePartManager.ReturnScene);
			}
		}
	}
}
