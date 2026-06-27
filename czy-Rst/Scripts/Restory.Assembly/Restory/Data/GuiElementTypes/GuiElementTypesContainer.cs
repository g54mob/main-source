using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.GuiElementTypes
{
	public class GuiElementTypesContainer : ScriptableObject
	{
		[SerializeField]
		private GuiElementType[] values;

		public IReadOnlyCollection<GuiElementType> Values => values;
	}
}
