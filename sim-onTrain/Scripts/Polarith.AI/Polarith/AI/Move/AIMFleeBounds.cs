using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Flee Bounds")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-seekfleebounds.html")]
	public sealed class AIMFleeBounds : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public FleeBounds FleeBounds = new FleeBounds();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => FleeBounds;

		public override bool ThreadSafe => true;
	}
}
