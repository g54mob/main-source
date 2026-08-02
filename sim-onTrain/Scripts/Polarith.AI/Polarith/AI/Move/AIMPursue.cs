using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Pursue")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-pursueevade.html")]
	public sealed class AIMPursue : AIMRadiusSteeringBehaviour
	{
		[SerializeField]
		private SphereGizmo targetGizmo = new SphereGizmo();

		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Pursue Pursue = new Pursue();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => Pursue;

		public override bool ThreadSafe => true;

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (targetGizmo.Enabled)
			{
				targetGizmo.Draw(Pursue.TargetPosition);
			}
		}
	}
}
