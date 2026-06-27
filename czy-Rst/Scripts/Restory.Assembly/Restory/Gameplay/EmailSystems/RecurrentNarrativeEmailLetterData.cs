using System;
using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems
{
	[Serializable]
	public class RecurrentNarrativeEmailLetterData
	{
		public EmailMessageInfo Message;

		public DateTime ResendDateTime;
	}
}
