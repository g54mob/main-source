using System.Collections.Generic;
using System.Linq;
using Events.UI.ModuleViewer;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Check Pinned Modules", fileName = "CheckPinnedModules", order = 10)]
	public class CheckPinnedModulesSubquestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private PinnedModulesViewLocator _locator;

		[SerializeField]
		private List<BuildingObjectDataAndShapeData> _desiredPins;

		public override bool IsValid()
		{
			foreach (BuildingObjectDataAndShapeData desiredPin in _desiredPins)
			{
				DioramaEditorSave.DioramaShapeCollection dioramaShapeCollection = desiredPin.buildingObjectData.DioramaSave.DioramaShapesDictionary.Values.ElementAt(desiredPin.shapeDataIndex);
				if (!_locator.PinnedModulesBarView.IsModulePinned(desiredPin.buildingObjectData.GetModuleViewerData, dioramaShapeCollection.ShapeData.Data))
				{
					return false;
				}
			}
			return true;
		}

		public override void Reset()
		{
		}
	}
}
