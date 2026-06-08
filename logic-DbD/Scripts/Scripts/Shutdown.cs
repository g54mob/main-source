using UnityEngine;

public class Shutdown : MonoBehaviour
{
	[SerializeField]
	private EmergencyMessagePopup emergencyMessagePopup;

	private void OnEnable()
	{
		GetComponent<AudioSource>().PlayDelayed(0.3f);
		if (!CreateTables.DEV_MODE)
		{
			emergencyMessagePopup.InstantiatePopupMessage(MessageSpawner.MessageCodes.FirstShutdown, 0.5f);
		}
	}

	public static void ExitGame()
	{
		if (CreateTables.DEV_MODE)
		{
			Save.EraseSave();
			return;
		}
		Save.SaveGame();
		Application.Quit();
	}
}
