using Data.Variables;
using Logic.FactoryTools;
using Presentation.Locators;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Quests", fileName = "QuestPersistentSO", order = 0)]
	public class QuestPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private QuestManagerLocator _questManagerLocator;

		[SerializeField]
		private PlacementTool _placementTool;

		[SerializeField]
		private ShowTutorialSO _showTutorialSO;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			QuestsSaveData questsSaveData = saveData as QuestsSaveData;
			_questManagerLocator.QuestManager.SetQuestIndex(questsSaveData.CurrentIndex, questsSaveData.ShowTutorial);
		}

		public override void ResetToDefaults()
		{
			if (_questManagerLocator.QuestManager != null)
			{
				_questManagerLocator.QuestManager.Reset(completeCurrentQuest: false);
			}
			_placementTool.SetAllowRotating(allowRotation: true);
			_placementTool.SetAllowMirroring(allowMirroring: true);
		}

		public override AbstractSaveData GetSaveData()
		{
			return new QuestsSaveData(_questManagerLocator.QuestManager.CurrentQuestIndex, _showTutorialSO.Value);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			bool num = TryLoadSaveDataInternal<QuestsSaveData>(fullPath);
			if (!num)
			{
				_questManagerLocator.QuestManager.SetQuestIndex(0, _showTutorialSO.Value);
			}
			return num;
		}
	}
}
