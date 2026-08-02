using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Steering/AIM Avoid Bounds")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-avoidbounds.html")]
	public sealed class AIMAvoidBounds : AIMRadiusSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public AvoidBounds AvoidBounds = new AvoidBounds();

		[Tooltip("Sets up the visualization of the plane perpendicular to the obstacle.")]
		[SerializeField]
		private PlaneGizmo PlaneGizmo = new PlaneGizmo();

		public override RadiusSteeringBehaviour RadiusSteeringBehaviour => AvoidBounds;

		public override bool ThreadSafe => true;

		private void OnDrawGizmosSelected()
		{
			PlaneGizmo.Draw(AvoidBounds.Intersection, AvoidBounds.PlaneDirection1, AvoidBounds.PlaneDirection2);
		}
	}
}
