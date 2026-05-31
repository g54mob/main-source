using System;
using CTS.Core;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DialogueEvents : CTSBehaviour
	{
		public static event Action<EActors, EMood> ConversationLinePlaying;

		public void OnConversationLineStarted(Subtitle subtitle)
		{
			Field field = Field.Lookup(subtitle.dialogueEntry.fields, "Mood");
			EMood eMood = ((field != null) ? DialogueHelper.TryConvertEnum<EMood>(field.value) : EMood.Neutral);
			if (eMood != EMood.Neutral)
			{
				DialogueEvents.ConversationLinePlaying?.Invoke(DialogueHelper.TryConvertEnum<EActors>(subtitle.speakerInfo.nameInDatabase), eMood);
			}
		}
	}
}
