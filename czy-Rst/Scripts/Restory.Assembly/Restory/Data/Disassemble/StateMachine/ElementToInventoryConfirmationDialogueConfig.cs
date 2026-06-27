using UnityEngine;

namespace Restory.Data.Disassemble.StateMachine
{
	[CreateAssetMenu(menuName = "Restory/Disassemble/StateMachine/ElementToInventoryConfirmationDialogueConfig", fileName = "ElementToInventoryConfirmationDialogueConfig")]
	public class ElementToInventoryConfirmationDialogueConfig : ScriptableObject
	{
		[SerializeField]
		private string dialogueTextLocalizationKey;

		public string DialogueTextLocalizationKey => dialogueTextLocalizationKey;
	}
}
