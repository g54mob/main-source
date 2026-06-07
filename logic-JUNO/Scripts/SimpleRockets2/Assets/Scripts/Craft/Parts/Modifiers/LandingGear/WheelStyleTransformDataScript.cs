using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	public class WheelStyleTransformDataScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _colliderTransform;

		[SerializeField]
		private Transform _slantAngleRoot;

		[SerializeField]
		private Transform _suspension;

		[SerializeField]
		private Transform _suspensionAttachmentPoint;

		[SerializeField]
		private Transform _wheelAssemblyRoot;

		[SerializeField]
		private Transform _wheelSpinRoot;

		[SerializeField]
		private Transform _wheelSuspensionTravelRoot;

		[SerializeField]
		private Transform _wheelTurnRoot;

		public Transform ColliderTransform => _colliderTransform;

		public Transform SlantAngleRoot => _slantAngleRoot;

		public Transform Suspension => _suspension;

		public Transform SuspensionAttachmentAPoint => _suspensionAttachmentPoint;

		public Transform WheelAssemblyRoot => _wheelAssemblyRoot;

		public Transform WheelSpinRoot
		{
			get
			{
				return _wheelSpinRoot;
			}
			set
			{
				_wheelSpinRoot = value;
			}
		}

		public Transform WheelSuspensionTravelRoot
		{
			get
			{
				return _wheelSuspensionTravelRoot;
			}
			set
			{
				_wheelSuspensionTravelRoot = value;
			}
		}

		public Transform WheelTurnRoot
		{
			get
			{
				return _wheelTurnRoot;
			}
			set
			{
				_wheelTurnRoot = value;
			}
		}
	}
}
