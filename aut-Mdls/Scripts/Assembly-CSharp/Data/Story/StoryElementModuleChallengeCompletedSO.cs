using Events;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementModuleChallengeCompletedSO", menuName = "Story/StoryElementModuleChallengeCompletedSO")]
	public class StoryElementModuleChallengeCompletedSO : StoryElementSO
	{
		[SerializeField]
		private BaseEvent _moduleChallengeCompleted;

		public override void Initialize()
		{
			_moduleChallengeCompleted.Register(OnModuleChallengeCompleted);
		}

		private void OnModuleChallengeCompleted()
		{
			TryExecute();
		}

		public override void Destroy()
		{
			_moduleChallengeCompleted.UnRegister(OnModuleChallengeCompleted);
		}
	}
}
