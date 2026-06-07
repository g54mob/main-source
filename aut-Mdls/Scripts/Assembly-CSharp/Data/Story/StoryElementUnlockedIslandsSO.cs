using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Events.Islands;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementUnlockedIslandsSO", menuName = "Story/StoryElementUnlockedIslandsSO")]
	public class StoryElementUnlockedIslandsSO : StoryElementSO
	{
		[SerializeField]
		private UnlockedIslandEventSO _unlockedIslandEvent;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private int _islandsCountToHaveUnlocked;

		public override void Initialize()
		{
			if (EnoughIslandsUnlocked())
			{
				TryExecute();
			}
			else
			{
				_unlockedIslandEvent.Register(OnIslandUnlocked);
			}
		}

		private void OnIslandUnlocked(IslandObject _)
		{
			if (EnoughIslandsUnlocked())
			{
				_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
				TryExecute();
			}
		}

		private bool EnoughIslandsUnlocked()
		{
			return _unlockedIslandsPersistentSO.UnlockedIslandCount >= _islandsCountToHaveUnlocked;
		}

		public override void Destroy()
		{
			_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
		}
	}
}
