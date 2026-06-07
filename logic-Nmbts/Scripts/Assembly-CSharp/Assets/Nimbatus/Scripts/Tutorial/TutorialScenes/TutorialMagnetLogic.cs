using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialMagnetLogic : GenericTutorialLogic
	{
		[HideInInspector]
		public int collectedObjects;

		public int amountOfObjectsToCollect = 3;

		private void Awake()
		{
		}

		public override void OnUpdate()
		{
		}

		public override bool IsCompleted()
		{
			return collectedObjects >= amountOfObjectsToCollect;
		}

		public override string TutorialLabel()
		{
			string translation = LocalizationManager.GetTermTranslation("Tutorial/MagnetTutorialStatus");
			LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", collectedObjects.ToString());
			LocalizationManager.ApplyLocalizationParams(ref translation, "Goal", amountOfObjectsToCollect.ToString());
			return translation;
		}

		public override Vector3 CursorPosition()
		{
			return Vector3.zero;
		}

		public override bool IsCursorVisible()
		{
			return false;
		}
	}
}
