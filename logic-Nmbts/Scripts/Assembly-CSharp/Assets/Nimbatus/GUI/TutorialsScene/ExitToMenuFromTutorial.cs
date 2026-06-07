using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TutorialsScene
{
	public class ExitToMenuFromTutorial : MonoBehaviour
	{
		public void OnClick()
		{
			if (GenericTutorialLogic.Instance != null)
			{
				GenericTutorialLogic.Instance.BackToMenu();
			}
		}
	}
}
