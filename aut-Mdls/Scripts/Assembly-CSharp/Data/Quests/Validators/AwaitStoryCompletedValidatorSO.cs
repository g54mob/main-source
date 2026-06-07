using Data.Story;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Story Completed", fileName = "AwaitStoryCompleted", order = 6)]
	public class AwaitStoryCompletedValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private StoryElementSO _storyElementSO;

		private bool _isSetup;

		private bool _isCompleted;

		public override bool IsValid()
		{
			_isCompleted = _storyElementSO.IsComplete;
			if (!_isCompleted && !_isSetup)
			{
				_storyElementSO.OnStoryCompleted += OnStoryCompleted;
				_isSetup = true;
			}
			return _isCompleted;
		}

		private void OnStoryCompleted(StoryElementSO _)
		{
			_isCompleted = true;
		}

		public override void Reset()
		{
			if (_isSetup)
			{
				_storyElementSO.OnStoryCompleted -= OnStoryCompleted;
			}
			_isCompleted = false;
			_isSetup = false;
		}
	}
}
