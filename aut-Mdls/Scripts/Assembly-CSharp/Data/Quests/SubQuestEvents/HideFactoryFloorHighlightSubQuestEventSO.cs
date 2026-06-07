using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Hide FactoryFloor Highlight", fileName = "HideFactoryFloorHighlight", order = 15)]
	public class HideFactoryFloorHighlightSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private ShowFactoryFloorHighlightSubQuestEventSO _showEvent;

		public override void Execute()
		{
			if (_showEvent.SpawnedHighlight != null)
			{
				Object.Destroy(_showEvent.SpawnedHighlight.gameObject);
			}
			if (_showEvent.SpawnedFactoryFloorHighlight != null)
			{
				Object.Destroy(_showEvent.SpawnedFactoryFloorHighlight.gameObject);
			}
		}
	}
}
