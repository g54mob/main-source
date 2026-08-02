using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Avoid")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-avoid.html")]
	public sealed class AIMAvoid : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Avoid Avoid = new Avoid();

		[Tooltip("Sets up the visualization of the plane perpendicular to the obstacle.")]
		[SerializeField]
		private PlaneGizmo PlaneGizmo = new PlaneGizmo();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => Avoid;

		public override bool ThreadSafe => true;

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			PlaneGizmo.Draw(base.transform.position, Avoid.PlaneDirection1, Avoid.PlaneDirection2);
		}
	}
}
