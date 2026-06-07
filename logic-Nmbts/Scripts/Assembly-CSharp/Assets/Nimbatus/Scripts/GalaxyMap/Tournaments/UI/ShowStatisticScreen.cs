using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class ShowStatisticScreen : MonoBehaviour
	{
		public TournamentUI Manager;

		public void OnClick()
		{
			Manager.ShowStatisticScreen(true);
		}
	}
}
