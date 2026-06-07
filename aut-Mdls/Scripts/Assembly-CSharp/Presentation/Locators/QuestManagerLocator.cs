using Logic.Quests;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/QuestManager", fileName = "QuestManagerLocator", order = 0)]
	public class QuestManagerLocator : ScriptableObject
	{
		[HideInInspector]
		public QuestManager QuestManager;
	}
}
