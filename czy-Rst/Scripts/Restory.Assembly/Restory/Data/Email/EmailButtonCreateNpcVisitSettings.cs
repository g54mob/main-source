using System;
using Restory.Data.NPCs;

namespace Restory.Data.Email
{
	[Serializable]
	public class EmailButtonCreateNpcVisitSettings : EmailButtonSettingsBase
	{
		public StoryNpcInfo NpcToVisit;

		public int DelayBeforeVisitInMinutes;

		public int DelayAfterVisitInMinutes;

		public string NpcTextureID;
	}
}
