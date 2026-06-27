using Restory.Data.SaveLoad.Containers;
using UnityEngine;

namespace Restory.Data.Elements
{
	[CreateAssetMenu(menuName = "Restory/Quests/QuestItemInfo", fileName = "Name - QuestItemInfo")]
	public class QuestItemInfo : ElementInfo
	{
		[SerializeField]
		private SerializableTransform localTransform;

		public SerializableTransform LocalTransform => localTransform;
	}
}
