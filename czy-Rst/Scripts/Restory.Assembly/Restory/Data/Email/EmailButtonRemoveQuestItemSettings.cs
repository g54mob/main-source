using System;
using Restory.Data.Elements;

namespace Restory.Data.Email
{
	[Serializable]
	public class EmailButtonRemoveQuestItemSettings : EmailBlockableButtonSettingsBase
	{
		public QuestItemInfo QuestItemToRemove;
	}
}
