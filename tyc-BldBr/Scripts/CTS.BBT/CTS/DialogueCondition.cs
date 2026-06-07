using CTS.Utilities;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DialogueCondition : MonoCondition
	{
		public override bool IsConditionValid()
		{
			if (!DialogueManager.IsConversationActive)
			{
				return true;
			}
			return !DialogueLua.GetConversationField(DialogueManager.LastConversationID, "Is a dialogue").AsBool;
		}
	}
}
