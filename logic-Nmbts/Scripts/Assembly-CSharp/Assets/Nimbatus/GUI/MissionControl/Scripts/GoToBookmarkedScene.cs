using Assets.Nimbatus.Scripts.Common.LevelTransition;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class GoToBookmarkedScene : MonoBehaviour
	{
		public void OnClick()
		{
			NimbatusSceneManager.GoToBookmarkedScene();
		}
	}
}
