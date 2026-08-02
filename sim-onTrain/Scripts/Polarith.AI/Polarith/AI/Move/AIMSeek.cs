using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Seek")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-seekflee.html")]
	public sealed class AIMSeek : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Seek Seek = new Seek();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => Seek;

		public override bool ThreadSafe => true;
	}
}
