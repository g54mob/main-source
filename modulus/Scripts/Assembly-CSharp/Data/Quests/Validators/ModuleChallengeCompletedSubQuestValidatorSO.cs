using Events;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Module Challenge Completed", fileName = "ModuleChallengeCompleted", order = 11)]
	public class ModuleChallengeCompletedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BaseEvent _moduleChallengeCompleted;

		[SerializeField]
		private ModuleChallengeSO _moduleChallengeSO;

		private bool _isSetup;

		private bool _challengeCompleted;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_isSetup = true;
				if (_moduleChallengeSO.GetTotalDeliveredModuleChallenges() != 0)
				{
					return true;
				}
				_moduleChallengeCompleted.Register(ModuleChallengeCompleted);
			}
			return _challengeCompleted;
		}

		private void ModuleChallengeCompleted()
		{
			_challengeCompleted = true;
		}

		public override void Reset()
		{
			_isSetup = false;
			_challengeCompleted = false;
			_moduleChallengeCompleted.UnRegister(ModuleChallengeCompleted);
		}
	}
}
