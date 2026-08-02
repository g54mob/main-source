using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Evade")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-pursueevade.html")]
	public sealed class AIMEvade : AIMRadiusSteeringBehaviour
	{
		[SerializeField]
		private SphereGizmo targetGizmo = new SphereGizmo();

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Evade Evade = new Evade();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => Evade;

		public override bool ThreadSafe => true;

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (targetGizmo.Enabled)
			{
				targetGizmo.Draw(Evade.TargetPosition);
			}
		}
	}
}
