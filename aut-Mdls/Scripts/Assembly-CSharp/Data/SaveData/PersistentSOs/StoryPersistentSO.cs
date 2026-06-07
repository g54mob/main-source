using Presentation.Locators;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Story", fileName = "StoryPersistentSO", order = 0)]
	public class StoryPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private StoryManagerLocator _storyManagerLocator;

		[SerializeField]
		private IntroManagerLocator _introManagerLocator;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			StorySaveData storySaveData = saveData as StorySaveData;
			_storyManagerLocator.StoryManager.ApplyCompletedStories(storySaveData.CompletedStories);
			_introManagerLocator.IntroManager.ApplySaveData(storySaveData.CompletedIntro);
		}

		public override void ResetToDefaults()
		{
			_storyManagerLocator.StoryManager.ResetToDefault();
			_introManagerLocator.IntroManager.ResetToDefault();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new StorySaveData(_storyManagerLocator.StoryManager.CompletedStories, _introManagerLocator.IntroManager.CompletedIntro);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			bool num = TryLoadSaveDataInternal<StorySaveData>(fullPath);
			if (!num)
			{
				_storyManagerLocator.StoryManager.TryStartStory();
				_introManagerLocator.IntroManager.TryStartIntro();
			}
			return num;
		}
	}
}
