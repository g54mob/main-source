using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class LoadMainMenu : MonoBehaviour
	{
		public void Awake()
		{
			RuntimeGlobals.ResetToDefault();
			NimbatusSceneManager.LoadScene("MainMenuScene");
		}
	}
}
