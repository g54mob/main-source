using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialMovementLogic : GenericTutorialLogic
	{
		public TutorialMovementTarget[] Targets;

		private int _currentTarget;

		private void Awake()
		{
			if (Targets.Length != 0)
			{
				Targets[0].ActivateTarget();
			}
		}

		public override void OnUpdate()
		{
			if (_currentTarget < Targets.Length && Targets[_currentTarget].State == TutorialMovementTarget.EMovementTargetState.ActiveTurnedOn)
			{
				_currentTarget++;
				if (_currentTarget < Targets.Length)
				{
					Targets[_currentTarget].ActivateTarget();
				}
			}
		}

		public override bool IsCompleted()
		{
			return _currentTarget >= Targets.Length;
		}

		public override string TutorialLabel()
		{
			string translation = LocalizationManager.GetTermTranslation("Tutorial/LogicPartsTutorialStatus");
			LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", _currentTarget.ToString());
			LocalizationManager.ApplyLocalizationParams(ref translation, "Goal", Targets.Length.ToString());
			return translation;
		}

		public override Vector3 CursorPosition()
		{
			if (_currentTarget < Targets.Length)
			{
				return Targets[_currentTarget].transform.position;
			}
			return Vector3.zero;
		}

		public override bool IsCursorVisible()
		{
			if (_currentTarget < Targets.Length)
			{
				return true;
			}
			return false;
		}
	}
}
