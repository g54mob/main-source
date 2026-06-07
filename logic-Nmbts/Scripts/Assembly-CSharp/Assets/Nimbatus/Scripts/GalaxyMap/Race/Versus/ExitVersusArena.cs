using Assets.Nimbatus.Scripts.Common.LevelTransition;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Versus
{
	public class ExitVersusArena : MonoBehaviour
	{
		public void OnClick()
		{
			BaseRaceManager.Instance.OnRaceEnded(null, false);
			NimbatusSceneManager.GoToBookmarkedScene();
		}
	}
}
