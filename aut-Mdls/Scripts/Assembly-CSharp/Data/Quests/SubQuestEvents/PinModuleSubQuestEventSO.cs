using System.Linq;
using Data.Buildings;
using Events.UI.ModuleViewer;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Pin Module", fileName = "PinModule", order = 10)]
	public class PinModuleSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private PinModuleUIEvent _pinModuleUIEvent;

		[SerializeField]
		private BuildingObjectData _buildingObjectData;

		[SerializeField]
		private int _currentShapeIndex;

		[SerializeField]
		private PinnedModulesViewLocator _pinnedModulesViewLocator;

		public override void Execute()
		{
			DioramaEditorSave.DioramaShapeCollection dioramaShapeCollection = _buildingObjectData.DioramaSave.DioramaShapesDictionary.Values.ElementAt(_currentShapeIndex);
			if (!_pinnedModulesViewLocator.PinnedModulesBarView.IsModulePinned(_buildingObjectData.GetModuleViewerData, dioramaShapeCollection.ShapeData.Data))
			{
				_pinModuleUIEvent.Fire((_buildingObjectData.GetModuleViewerData, _currentShapeIndex));
			}
		}
	}
}
