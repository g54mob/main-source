using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialSensorPartsLogic : GenericTutorialLogic
	{
		public TutorialBattleTarget[] Targets;

		private int _destroyedTargetsCount;

		private void Awake()
		{
			for (int i = 0; i < Targets.Length; i++)
			{
				Targets[i].ActivateTarget();
			}
		}

		public override void OnUpdate()
		{
			_destroyedTargetsCount = 0;
			for (int i = 0; i < Targets.Length; i++)
			{
				if (Targets[i] == null)
				{
					_destroyedTargetsCount++;
				}
			}
		}

		public override bool IsCompleted()
		{
			return _destroyedTargetsCount >= Targets.Length;
		}

		public override string TutorialLabel()
		{
			string translation = LocalizationManager.GetTermTranslation("Tutorial/BattleTutorialStatus");
			LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", _destroyedTargetsCount.ToString());
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
