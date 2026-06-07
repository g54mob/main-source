using Data.Shapes;
using UnityEngine;

namespace Events.Onboarding
{
	[CreateAssetMenu(menuName = "Events/Onboarding/Show Cutter ShapeHologram", fileName = "ShowCutterShapeHologramEvent", order = 0)]
	public class ShowCutterShapeHologramEvent : BaseEvent<(ShapeData, int)>
	{
	}
}
