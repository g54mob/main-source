using System.Collections;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ExitToDroneWorkshop : MonoBehaviour
	{
		public bool AutoExitOnGameOver;

		public bool SaveWeaponPresets;

		private bool _shouldEnd = true;

		public void Update()
		{
			if (AutoExitOnGameOver && RuntimeGlobals.IsGameOver && _shouldEnd)
			{
				StartCoroutine(ReturnToWorkshop());
				_shouldEnd = false;
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				OnClick();
			}
		}

		public void OnClick()
		{
			if (SaveWeaponPresets)
			{
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.UpdateWeaponPresets();
			}
			RuntimeGlobals.IsGameOver = false;
			RuntimeGlobals.IsGamePaused = false;
			NimbatusSceneManager.LoadScene("DroneWorkshopScene");
		}

		private IEnumerator ReturnToWorkshop()
		{
			if (SaveWeaponPresets)
			{
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.UpdateWeaponPresets();
			}
			yield return new WaitForSeconds(0.05f);
			RuntimeGlobals.IsGameOver = false;
			RuntimeGlobals.IsGamePaused = false;
			NimbatusSceneManager.LoadScene("DroneWorkshopScene");
		}
	}
}
