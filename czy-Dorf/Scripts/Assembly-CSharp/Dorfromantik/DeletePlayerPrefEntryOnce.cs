using UnityEngine;

namespace Dorfromantik
{
	public class DeletePlayerPrefEntryOnce : MonoBehaviour
	{
		[SerializeField]
		private string playerPrefKeyToDelete = "";

		[SerializeField]
		private string playerPrefKeyToRememberDeletion = "";

		private void Start()
		{
			if (PlayerPrefs.GetInt(playerPrefKeyToRememberDeletion, 0) == 0)
			{
				PlayerPrefs.DeleteKey(playerPrefKeyToDelete);
				PlayerPrefs.SetInt(playerPrefKeyToRememberDeletion, 1);
				Debug.Log("Deleted Player Prefs " + playerPrefKeyToDelete);
			}
		}
	}
}
