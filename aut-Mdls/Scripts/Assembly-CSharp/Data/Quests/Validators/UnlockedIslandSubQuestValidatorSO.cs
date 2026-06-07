using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Events.Islands;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Unlocked Island", fileName = "UnlockedIsland", order = 4)]
	public class UnlockedIslandSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private UnlockedIslandEventSO _unlockedIslandEvent;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private int _islandsCountToHaveUnlocked;

		[SerializeField]
		private float _effectDelayTime = 2f;

		private bool _init;

		private bool _islandWasUnlocked;

		private float _timer;

		public override bool IsValid()
		{
			if (!_init)
			{
				if (_unlockedIslandsPersistentSO.UnlockedIslandCount >= _islandsCountToHaveUnlocked)
				{
					_islandWasUnlocked = true;
				}
				else
				{
					_unlockedIslandEvent.Register(OnIslandUnlocked);
				}
				_init = true;
				_timer = 0f;
			}
			if (_islandWasUnlocked)
			{
				_timer += Time.deltaTime;
				if (_timer >= _effectDelayTime)
				{
					return true;
				}
			}
			return false;
		}

		private void OnIslandUnlocked(IslandObject _)
		{
			if (_unlockedIslandsPersistentSO.UnlockedIslandCount >= _islandsCountToHaveUnlocked)
			{
				_islandWasUnlocked = true;
			}
		}

		public override void Reset()
		{
			_init = false;
			_islandWasUnlocked = false;
			_timer = 0f;
			_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
		}
	}
}
