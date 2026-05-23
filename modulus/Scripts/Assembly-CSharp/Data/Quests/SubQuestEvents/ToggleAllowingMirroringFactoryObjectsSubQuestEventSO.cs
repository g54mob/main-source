using Logic.FactoryTools;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Toggle Allowing Mirroring FactoryObjects", fileName = "ToggleAllowingMirroringFactoryObjects", order = 22)]
	public class ToggleAllowingMirroringFactoryObjectsSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private PlacementTool _placementTool;

		[SerializeField]
		private bool _allowMirroring;

		public override void Execute()
		{
			_placementTool.SetAllowMirroring(_allowMirroring);
		}
	}
}
