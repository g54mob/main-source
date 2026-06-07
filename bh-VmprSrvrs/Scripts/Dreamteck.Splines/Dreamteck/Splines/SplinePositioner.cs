using UnityEngine;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Spline Positioner")]
	public class SplinePositioner : SplineTracer
	{
		public enum Mode
		{
			Percent = 0,
			Distance = 1
		}

		[SerializeField]
		[HideInInspector]
		private GameObject _targetObject;

		[SerializeField]
		[HideInInspector]
		private float _position;

		[SerializeField]
		[HideInInspector]
		private Mode _mode;

		private float _lastPosition;

		public GameObject targetObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public double position
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public Mode mode
		{
			get
			{
				return default(Mode);
			}
			set
			{
			}
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}

		protected override Transform GetTransform()
		{
			return null;
		}

		protected override Rigidbody GetRigidbody()
		{
			return null;
		}

		protected override Rigidbody2D GetRigidbody2D()
		{
			return null;
		}

		protected override void PostBuild()
		{
		}

		public override void SetPercent(double percent, bool checkTriggers = false, bool handleJuncitons = false)
		{
		}

		public override void SetDistance(float distance, bool checkTriggers = false, bool handleJuncitons = false)
		{
		}
	}
}
