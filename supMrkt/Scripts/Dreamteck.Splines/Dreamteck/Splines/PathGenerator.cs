using UnityEngine;

namespace Dreamteck.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[AddComponentMenu("Dreamteck/Splines/Users/Path Generator")]
	public class PathGenerator : MeshGenerator
	{
		[SerializeField]
		[HideInInspector]
		private int _slices;

		[SerializeField]
		[HideInInspector]
		[Tooltip("This will inflate sample sizes based on the angle between two samples in order to preserve geometry width")]
		private bool _compensateCorners;

		[SerializeField]
		[HideInInspector]
		private bool _useShapeCurve;

		[SerializeField]
		[HideInInspector]
		private AnimationCurve _shape;

		[SerializeField]
		[HideInInspector]
		private AnimationCurve _lastShape;

		[SerializeField]
		[HideInInspector]
		private float _shapeExposure;

		public int slices
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool useShapeCurve
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool compensateCorners
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float shapeExposure
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve shape
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override string meshName => null;

		protected override void Reset()
		{
		}

		protected override void BuildMesh()
		{
		}

		private void GenerateVertices()
		{
		}
	}
}
