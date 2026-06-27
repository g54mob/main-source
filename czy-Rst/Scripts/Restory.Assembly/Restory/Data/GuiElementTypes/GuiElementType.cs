using Restory.Data.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Restory.Data.GuiElementTypes
{
	[CreateAssetMenu(menuName = "Restory/GUI/Gui Element Type", fileName = "newGuiElementType", order = 20)]
	public class GuiElementType : RestoryEntityInfoBase
	{
		[FormerlySerializedAs("rewiredRuleSetTag")]
		[SerializeField]
		private RewiredLayoutRuleSet rewiredLayoutRuleSet;

		public RewiredLayoutRuleSet RewiredLayoutRuleSet => rewiredLayoutRuleSet;
	}
}
