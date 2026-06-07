using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class AbandonTournamentButton : MonoBehaviour
	{
		private TournamentUI _manager;

		public void Init(TournamentUI manager)
		{
			_manager = manager;
		}

		public void OnClick()
		{
			StartCoroutine(_manager.ResetTournament());
		}
	}
}
