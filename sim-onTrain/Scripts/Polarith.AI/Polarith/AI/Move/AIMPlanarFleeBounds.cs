using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Planar Flee Bounds")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planarseekfleebounds.html")]
	public sealed class AIMPlanarFleeBounds : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public PlanarFleeBounds PlanarFleeBounds = new PlanarFleeBounds();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => PlanarFleeBounds;

		public override bool ThreadSafe => true;
	}
}
