using Logic.FactoryTools;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Toggle Allowing Rotating FactoryObjects", fileName = "ToggleAllowingRotatingFactoryObjects", order = 21)]
	public class ToggleAllowingRotatingFactoryObjectsSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private PlacementTool _placementTool;

		[SerializeField]
		private bool _allowRotating;

		public override void Execute()
		{
			_placementTool.SetAllowRotating(_allowRotating);
		}
	}
}
