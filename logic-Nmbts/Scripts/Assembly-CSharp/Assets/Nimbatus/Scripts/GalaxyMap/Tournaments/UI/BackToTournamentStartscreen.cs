using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class BackToTournamentStartscreen : MonoBehaviour
	{
		public TournamentUI Manager;

		public void OnClick()
		{
			Manager.ShowStartScreen();
		}
	}
}
