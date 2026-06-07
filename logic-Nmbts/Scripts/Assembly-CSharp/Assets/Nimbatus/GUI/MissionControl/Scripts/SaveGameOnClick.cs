using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class SaveGameOnClick : MonoBehaviour
	{
		public bool CleanupFolders;

		public bool TriggerEvent;

		public void OnClick()
		{
			SaveManager.StoreSaveGame(CleanupFolders, TriggerEvent);
		}
	}
}
