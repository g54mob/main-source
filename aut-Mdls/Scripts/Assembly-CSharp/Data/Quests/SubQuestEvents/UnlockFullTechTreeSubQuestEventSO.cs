using Presentation.Locators;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Unlock Full TechTree", fileName = "UnlockFullTechTree", order = 4)]
	public class UnlockFullTechTreeSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private TechTreeManagerLocator _techTreeManagerLocator;

		public override void Execute()
		{
			_techTreeManagerLocator.TechTreeManager.UnlockAllNodes();
		}
	}
}
