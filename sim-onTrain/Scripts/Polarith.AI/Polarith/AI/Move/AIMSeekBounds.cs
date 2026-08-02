using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Seek Bounds")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-seekfleebounds.html")]
	public sealed class AIMSeekBounds : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public SeekBounds SeekBounds = new SeekBounds();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => SeekBounds;

		public override bool ThreadSafe => true;
	}
}
