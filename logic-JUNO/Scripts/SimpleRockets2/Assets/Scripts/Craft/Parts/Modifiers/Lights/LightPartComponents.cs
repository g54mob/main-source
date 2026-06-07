using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	public class LightPartComponents : MonoBehaviour
	{
		[SerializeField]
		private Transform _arm1;

		[SerializeField]
		private Transform _arm2;

		[SerializeField]
		private Transform _lightContainer;

		[SerializeField]
		private Transform _mount;

		[SerializeField]
		[Tooltip("The length of the arm mesh beyond the point at which the light pivots.")]
		private float _armExtensionBeyondLightPivot;

		[Tooltip("The height of the mount mesh above its pivot point.")]
		[SerializeField]
		private float _mountHeightAbovePivot;

		[Tooltip("The height of the mount mesh below its pivot point.")]
		[SerializeField]
		private float _mountHeightBelowPivot;

		public Transform Arm1 => _arm1;

		public Transform Arm2 => _arm2;

		public float ArmExtensionBeyondLightPivot => _armExtensionBeyondLightPivot;

		public Transform LightContainer => _lightContainer;

		public Transform Mount => _mount;

		public float MountHeightAbovePivot => _mountHeightAbovePivot;

		public float MountHeightBelowPivot => _mountHeightBelowPivot;
	}
}
