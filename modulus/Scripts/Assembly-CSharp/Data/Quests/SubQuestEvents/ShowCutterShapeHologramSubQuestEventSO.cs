using Data.Shapes;
using Events.Onboarding;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show Cutter ShapeHologram", fileName = "ShowCutterShapeHologram", order = 0)]
	public class ShowCutterShapeHologramSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private ShowCutterShapeHologramEvent _showCutterShapeHologramEvent;

		[SerializeField]
		private ShapeDataSO _shapeData;

		[SerializeField]
		private int _interval;

		public override void Execute()
		{
			_showCutterShapeHologramEvent.Fire((_shapeData.Data, _interval));
		}
	}
}
