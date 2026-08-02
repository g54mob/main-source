using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Flee")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-seekflee.html")]
	public sealed class AIMFlee : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Flee Flee = new Flee();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => Flee;

		public override bool ThreadSafe => true;
	}
}
