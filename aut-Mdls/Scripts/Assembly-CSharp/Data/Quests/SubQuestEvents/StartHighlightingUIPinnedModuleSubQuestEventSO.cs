using System;
using Data.Buildings;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Start Highlighting PinnedModule", fileName = "StartHighlightingUIPinnedModule", order = 7)]
	public class StartHighlightingUIPinnedModuleSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private BuildingObjectData _buildingObjectData;

		[SerializeField]
		private int _currentShapeIndex;

		public event Action<ModuleViewerData, int> OnStartHighlightingPinnedModule = delegate
		{
		};

		public override void Execute()
		{
			this.OnStartHighlightingPinnedModule?.Invoke(_buildingObjectData.GetModuleViewerData, _currentShapeIndex);
		}
	}
}
