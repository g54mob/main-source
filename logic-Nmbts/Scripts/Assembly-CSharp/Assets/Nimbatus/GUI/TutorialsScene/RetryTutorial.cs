using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TutorialsScene
{
	public class RetryTutorial : MonoBehaviour
	{
		public void OnClick()
		{
			if (GenericTutorialLogic.Instance != null)
			{
				GenericTutorialLogic.Instance.BackToWorkshop(true);
			}
		}
	}
}
