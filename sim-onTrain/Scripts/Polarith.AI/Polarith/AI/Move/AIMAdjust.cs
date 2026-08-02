using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Adjust")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-adjust.html")]
	public sealed class AIMAdjust : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Adjust Adjust = new Adjust();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => Adjust;

		public override bool ThreadSafe => true;

		protected override void Reset()
		{
			base.Reset();
			Adjust.ValueWriting = ValueWritingType.Addition;
		}
	}
}
