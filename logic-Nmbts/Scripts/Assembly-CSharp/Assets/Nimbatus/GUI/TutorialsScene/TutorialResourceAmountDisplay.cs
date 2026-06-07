using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TutorialsScene
{
	public class TutorialResourceAmountDisplay : MonoBehaviour
	{
		public UILabel Label;

		public void Update()
		{
			if (Label != null && GenericTutorialLogic.Instance != null)
			{
				TutorialResourceGatheringLogic tutorialResourceGatheringLogic = GenericTutorialLogic.Instance as TutorialResourceGatheringLogic;
				if (tutorialResourceGatheringLogic != null)
				{
					Label.text = Mathf.CeilToInt(tutorialResourceGatheringLogic.GetResourceFakeAmount()).ToString();
				}
			}
		}
	}
}
