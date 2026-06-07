using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TutorialsScene
{
	public class ExitToDroneWorkshopFromTutorial : MonoBehaviour
	{
		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				OnClick();
			}
		}

		public void OnClick()
		{
			if (GenericTutorialLogic.Instance != null)
			{
				GenericTutorialLogic.Instance.BackToWorkshop(false);
			}
		}
	}
}
