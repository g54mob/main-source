using Assets.Nimbatus.Scripts.Common.LevelTransition;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class ExitToReturnScene : MonoBehaviour
	{
		public void OnClick()
		{
			NimbatusSceneManager.LoadScene(NimbatusSceneManager.GetReturnScene());
		}
	}
}
