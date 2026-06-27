using System;
using UnityEngine;

namespace Restory.Data.Remapping
{
	[Serializable]
	public struct TargetRewiredActionElementMap
	{
		[RewiredCategoriesDropdown]
		public int CategoryMapId;

		[Space]
		[RewiredActionsDropdown]
		public int ActionId;

		public TargetRewiredActionElementMap(int actionId, int categoryMapId)
		{
			ActionId = actionId;
			CategoryMapId = categoryMapId;
		}
	}
}
