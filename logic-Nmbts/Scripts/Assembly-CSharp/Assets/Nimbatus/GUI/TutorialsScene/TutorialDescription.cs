using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TutorialsScene
{
	public class TutorialDescription : MonoBehaviour
	{
		public UILabel Label;

		public UITexture CompletedIcon;

		public UITexture IncompletedIcon;

		public void Update()
		{
			if (Label != null && GenericTutorialLogic.Instance != null)
			{
				Label.text = GenericTutorialLogic.Instance.TutorialLabel();
				CompletedIcon.enabled = GenericTutorialLogic.Instance.IsCompleted();
				IncompletedIcon.enabled = !GenericTutorialLogic.Instance.IsCompleted();
			}
		}
	}
}
