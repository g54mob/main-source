using System.Runtime.CompilerServices;
using UnityEngine;

namespace Dreamteck.Splines
{
	[ExecuteInEditMode]
	[AddComponentMenu("Dreamteck/Splines/Users/Spline Projector")]
	public class SplineProjector : SplineTracer
	{
		public enum Mode
		{
			Accurate = 0,
			Cached = 1
		}

		[SerializeField]
		[HideInInspector]
		private Mode _mode;

		[SerializeField]
		[HideInInspector]
		private bool _autoProject;

		[SerializeField]
		[HideInInspector]
		[Range(3f, 8f)]
		private int _subdivide;

		[SerializeField]
		[HideInInspector]
		private Transform _projectTarget;

		[SerializeField]
		[HideInInspector]
		private Transform applyTarget;

		[SerializeField]
		[HideInInspector]
		private GameObject _targetObject;

		[SerializeField]
		[HideInInspector]
		public Vector2 _offset;

		[SerializeField]
		[HideInInspector]
		public Vector3 _rotationOffset;

		[SerializeField]
		[HideInInspector]
		private Vector3 lastPosition;

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

		public bool autoProject
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int subdivide
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Transform projectTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public event SplineReachHandler onEndReached
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event SplineReachHandler onBeginningReached
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Reset()
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

		protected override void LateRun()
		{
		}

		protected override void PostBuild()
		{
		}

		protected override void OnSplineChanged()
		{
		}

		private void Project()
		{
		}

		public void CalculateProjection()
		{
		}
	}
}
