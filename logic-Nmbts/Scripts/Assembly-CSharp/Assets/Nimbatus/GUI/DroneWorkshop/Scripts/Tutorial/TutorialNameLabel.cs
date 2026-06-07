using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Tutorial
{
	public class TutorialNameLabel : MonoBehaviour
	{
		public UILabel Label;

		public void Start()
		{
			if (!(GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial == null))
			{
				Label.text = GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial.Name.GetTranslation();
			}
		}
	}
}
