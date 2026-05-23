using Events;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementModuleChallengeSetCompletedSO", menuName = "Story/StoryElementModuleChallengeSetCompletedSO")]
	public class StoryElementModuleChallengeSetCompletedSO : StoryElementSO
	{
		[SerializeField]
		private BaseEvent _moduleChallengeCompleted;

		[SerializeField]
		private ModuleChallengeSO _moduleChallengeSO;

		[SerializeField]
		private int _requiredClaimedSetsAmount = 1;

		public override void Initialize()
		{
			if (EnoughClaimedSets())
			{
				TryExecute();
			}
			else
			{
				_moduleChallengeCompleted.Register(OnModuleChallengeCompleted);
			}
		}

		private void OnModuleChallengeCompleted()
		{
			if (EnoughClaimedSets())
			{
				TryExecute();
			}
		}

		private bool EnoughClaimedSets()
		{
			return _moduleChallengeSO.GetClaimedSetsAmount() >= _requiredClaimedSetsAmount;
		}

		public override void Destroy()
		{
			_moduleChallengeCompleted.UnRegister(OnModuleChallengeCompleted);
		}
	}
}
