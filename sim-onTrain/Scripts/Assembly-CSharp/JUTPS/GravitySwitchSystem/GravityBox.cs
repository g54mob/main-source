using UnityEngine;

namespace JUTPS.GravitySwitchSystem
{
	[AddComponentMenu("JU TPS/Third Person System/Gravity Switcher/Gravity Box")]
	public class GravityBox : MonoBehaviour
	{
		[Header("Settings")]
		public float GravityForce = -35f;

		public string[] TagsToIgnore;

		[Header("Alignment")]
		public bool AlignRigidbodies;

		public bool AlignCharacters;

		public float AlignmentForce = -35f;

		public float DistanceToStopAligment;

		private void Update()
		{
			JUGravity.SimulateGravityBox(base.transform.position, base.transform.lossyScale, base.transform.rotation, -base.transform.up, GravityForce, AlignRigidbodies, AlignmentForce, DistanceToStopAligment, out var collider, TagsToIgnore);
			if (AlignCharacters)
			{
				JUGravity.AlignJUTPSCharacterUpOrientation(collider, base.transform.up);
			}
		}
	}
}
