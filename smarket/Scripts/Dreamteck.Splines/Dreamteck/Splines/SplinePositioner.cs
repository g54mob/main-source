using UnityEngine;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Spline Positioner")]
	[ExecuteInEditMode]
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
		private SplineTracer _followTarget;

		[SerializeField]
		[HideInInspector]
		private float _followTargetDistance;

		[SerializeField]
		[HideInInspector]
		private bool _followLoop;

		[SerializeField]
		[HideInInspector]
		private Spline.Direction _followTargetDirection;

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

		public SplineTracer followTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float followTargetDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool followLoop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Spline.Direction followTargetDirection
		{
			get
			{
				return default(Spline.Direction);
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

		private void OnFollowTargetMotionApplied()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
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

		public override void SetPercent(double percent, bool checkTriggers = false, bool handleJunctions = false)
		{
		}

		public override void SetDistance(float distance, bool checkTriggers = false, bool handleJunctions = false)
		{
		}
	}
}
