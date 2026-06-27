using Restory.Data.Elements.Condition;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementConditionsMaterialsProvidingService
	{
		private readonly ElementConditionsMaterialsTable elementConditionsMaterialsTable;

		public ElementConditionsMaterialsProvidingService(ElementConditionsMaterialsTable elementConditionsMaterialsTable)
		{
			this.elementConditionsMaterialsTable = elementConditionsMaterialsTable;
		}

		public bool TryGetCorrespondingMaterial(Material materialToCheck, ElementConditionBase elementCondition, out Material foundCorrespondingMaterial)
		{
			return elementConditionsMaterialsTable.TryGetCorrespondingMaterial(materialToCheck, elementCondition, out foundCorrespondingMaterial);
		}
	}
}
