using UnityEngine;

namespace Dreamteck.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[AddComponentMenu("Dreamteck/Splines/Users/Surface Generator")]
	public class SurfaceGenerator : MeshGenerator
	{
		[SerializeField]
		[HideInInspector]
		private float _expand;

		[SerializeField]
		[HideInInspector]
		private float _extrude;

		[SerializeField]
		[HideInInspector]
		private Vector2 _sideUvScale;

		[SerializeField]
		[HideInInspector]
		private Vector2 _sideUvOffset;

		[SerializeField]
		[HideInInspector]
		private float _sideUvRotation;

		[SerializeField]
		[HideInInspector]
		private SplineComputer _extrudeSpline;

		[SerializeField]
		[HideInInspector]
		private Vector3 _extrudeOffset;

		[SerializeField]
		[HideInInspector]
		private SplineSample[] extrudeResults;

		[SerializeField]
		[HideInInspector]
		private Vector3[] identityVertices;

		[SerializeField]
		[HideInInspector]
		private Vector3[] identityNormals;

		[SerializeField]
		[HideInInspector]
		private Vector2[] projectedVerts;

		[SerializeField]
		[HideInInspector]
		private int[] surfaceTris;

		[SerializeField]
		[HideInInspector]
		private int[] wallTris;

		[SerializeField]
		[HideInInspector]
		private double _extrudeFrom;

		[SerializeField]
		[HideInInspector]
		private double _extrudeTo;

		[SerializeField]
		[HideInInspector]
		private bool _uniformUvs;

		private Vector3 _trsRight;

		private Vector3 _trsUp;

		private Vector3 _trsForward;

		public float expand
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float extrude
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public double extrudeClipFrom
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double extrudeClipTo
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public Vector2 sideUvScale
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 sideUvOffset
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float sideUvRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public SplineComputer extrudeSpline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 extrudeOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool uniformUvs
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override string meshName => null;

		protected override void Awake()
		{
		}

		protected override void BuildMesh()
		{
		}

		private void LateUpdate()
		{
		}

		public void Generate()
		{
		}

		private void GenerateSurfaceTris(bool flip)
		{
		}

		private int WriteTris(ref int[] tris, ref int[] target, int vertexOffset, int trisOffset, bool flip)
		{
			return 0;
		}

		private bool IsClockwise(Vector2[] points2D)
		{
			return false;
		}

		private void GetIdentityVerts(Vector3 center, Vector3 normal, bool clockwise)
		{
		}

		private void GetProjectedVertices(int count, out Vector3 center, out Vector3 normal)
		{
			center = default(Vector3);
			normal = default(Vector3);
		}
	}
}
