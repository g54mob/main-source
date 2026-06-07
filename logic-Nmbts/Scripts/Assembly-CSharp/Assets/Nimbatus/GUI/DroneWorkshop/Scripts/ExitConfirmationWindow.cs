using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ExitConfirmationWindow : MonoBehaviour
	{
		public void Awake()
		{
			base.gameObject.SetActive(false);
		}

		public void Show()
		{
			base.gameObject.SetActive(true);
		}

		public void Yes()
		{
			base.gameObject.SetActive(false);
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.RevertActiveDrone();
			NimbatusSceneManager.LoadScene(DronePartManager.ReturnScene);
		}

		public void No()
		{
			base.gameObject.SetActive(false);
		}
	}
}
