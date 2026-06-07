using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class FinishTournamentButton : MonoBehaviour
	{
		public TournamentUI Manager;

		public UIToggle UploadToggle;

		public void Start()
		{
			if (SteamManager.ModsActive)
			{
				UploadToggle.value = false;
				UploadToggle.gameObject.SetActive(false);
			}
			else
			{
				UploadToggle.value = true;
				UploadToggle.gameObject.SetActive(true);
			}
		}

		public void OnClick()
		{
			StartCoroutine(Manager.FinishTournament(!SteamManager.ModsActive && UploadToggle.value));
		}
	}
}
