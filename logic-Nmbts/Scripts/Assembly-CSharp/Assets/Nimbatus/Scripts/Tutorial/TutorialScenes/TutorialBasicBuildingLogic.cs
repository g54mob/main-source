using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialBasicBuildingLogic : GenericTutorialLogic
	{
		public TutorialKeepTouchingTarget[] Targets;

		private int _touchCount;

		public override void OnUpdate()
		{
			_touchCount = 0;
			if (Targets.Length == 0)
			{
				return;
			}
			TutorialKeepTouchingTarget[] targets = Targets;
			for (int i = 0; i < targets.Length; i++)
			{
				if (targets[i].Touched)
				{
					_touchCount++;
				}
			}
		}

		public override bool IsCompleted()
		{
			return _touchCount == Targets.Length;
		}

		public override string TutorialLabel()
		{
			string translation = LocalizationManager.GetTermTranslation("Tutorial/MovementTutorialStatus");
			LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", _touchCount.ToString());
			LocalizationManager.ApplyLocalizationParams(ref translation, "Goal", Targets.Length.ToString());
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
