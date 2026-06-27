using System;
using Restory.Data.Elements;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class PlacedQuestItemData
	{
		public QuestItemInfo QuestItemInfo;

		public SerializableTransform QuestItemTransform;
	}
}
