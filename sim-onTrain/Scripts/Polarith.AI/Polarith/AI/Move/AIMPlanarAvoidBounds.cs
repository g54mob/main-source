using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Planar Avoid Bounds")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planaravoidbounds.html")]
	public sealed class AIMPlanarAvoidBounds : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public PlanarAvoidBounds PlanarAvoidBounds = new PlanarAvoidBounds();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => PlanarAvoidBounds;

		public override bool ThreadSafe => true;
	}
}
