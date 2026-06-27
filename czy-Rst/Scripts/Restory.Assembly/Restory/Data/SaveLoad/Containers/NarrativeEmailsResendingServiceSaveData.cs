using System;
using Restory.Gameplay.EmailSystems;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class NarrativeEmailsResendingServiceSaveData
	{
		public RecurrentNarrativeEmailLetterData[] RecurrentEmails;
	}
}
