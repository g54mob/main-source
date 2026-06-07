using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu
{
	public class UnpauseGame : MonoBehaviour
	{
		public void OnClick()
		{
			RuntimeGlobals.IsGamePaused = false;
		}
	}
}
