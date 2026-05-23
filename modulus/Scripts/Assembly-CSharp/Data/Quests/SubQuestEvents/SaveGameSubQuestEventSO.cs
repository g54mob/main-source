using Data.Variables;
using Logic.Factory;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Save Game", fileName = "SaveGame", order = 99)]
	public class SaveGameSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		public override void Execute()
		{
			_factorySaver.SaveFactory(_currentSavePath.Value);
		}
	}
}
