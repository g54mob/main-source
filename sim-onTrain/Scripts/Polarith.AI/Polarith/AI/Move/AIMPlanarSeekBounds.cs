using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Planar Seek Bounds")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planarseekfleebounds.html")]
	public sealed class AIMPlanarSeekBounds : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public PlanarSeekBounds PlanarSeekBounds = new PlanarSeekBounds();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => PlanarSeekBounds;

		public override bool ThreadSafe => true;
	}
}
